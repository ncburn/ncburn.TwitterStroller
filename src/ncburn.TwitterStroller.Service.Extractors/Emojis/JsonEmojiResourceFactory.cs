using Microsoft.Extensions.Logging;
using ncburn.TwitterStroller.Service.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ncburn.TwitterStroller.Service.Extractors.Emojis
{
	public class JsonEmojiResourceFactory
	{
		private ILogger _logger;

		public JsonEmojiResourceFactory(ILogger logger)
		{
			_logger = logger;
		}

		public async Task<EmojiSearchTree> Create()
		{
			_logger?.LogDebug("Retrieving emoji JSON from resource");

			JToken json;

			using (var stream = new MemoryStream(Resources.emojis_json))
			using (var reader = new StreamReader(stream))
			using (var jsonTextReader = new JsonTextReader(reader))
			{
				json = await Task.Run(() => JToken.ReadFrom(jsonTextReader));
			}

			_logger?.LogDebug("Emoji JSON loaded from resource");

			return new EmojiSearchTreeBuilder<JToken>()
				.WithSelector(GetEmojiFromJson)
				.WithData(json)
				.Build();
		}

		public static string UnifiedRepresentationToUtf16String(string unified)
		{
			var utf16String = new StringBuilder();
			var codePointTokens = unified.Split('-');
			foreach (var codePointToken in codePointTokens)
			{
				if (int.TryParse(codePointToken, NumberStyles.HexNumber, NumberFormatInfo.InvariantInfo, out var parsedCodePoint))
				{
					utf16String.Append(char.ConvertFromUtf32(parsedCodePoint));
				}
				else
				{
					throw new InvalidCodePointException($"Can no load emoji list from resource. '{unified}' contains invalid characters");
				}
			}

			return utf16String.ToString();
		}

		private static IEnumerable<string> GetEmojiFromJson(JToken json)
		{
			yield return UnifiedRepresentationToUtf16String(json["unified"].ToString());
			yield return json["text"].ToString();
		}
	}
}
