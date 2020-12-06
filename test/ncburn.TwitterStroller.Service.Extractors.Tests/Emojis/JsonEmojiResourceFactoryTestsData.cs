using System.Collections.Generic;

namespace ncburn.TwitterStroller.Service.Extractors.Tests.Emojis
{
	public static class JsonEmojiResourceFactoryTestsData
	{
		public static IEnumerable<object[]> TestUnifiedRepresentationToUtf16StringReturnsExpectedData
		{
			get
			{
				yield return new object[]
				{
					"Single UTF-32 code point",
					"1F638",
					"😸"
				};
			}
		}
	}
}
