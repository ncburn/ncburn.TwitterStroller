using ncburn.TwitterStroller.Service.Extractors.Emojis;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ncburn.TwitterStroller.Service.Extractors.Tests.Emojis
{
	public static class EmojiSearchTreeBuilderTestsData
	{
		public static IEnumerable<object[]> TestBuildReturnsExpectedSearchTreeData
		{
			get
			{
				var expectedSearchTree = new EmojiSearchTree();
				expectedSearchTree.AddEmojis(new List<string> { "😀", ":-)", "☹", ":-(" });
				yield return new object[]
				{
					"",
					new JArray(
						new JObject(
							new JProperty("unified", "😀"),
							new JProperty("text", ":-)")),
						new JObject(
							new JProperty("unified", "☹"),
							new JProperty("text", ":-("))),
					expectedSearchTree
				};
			}
		}
	}
}
