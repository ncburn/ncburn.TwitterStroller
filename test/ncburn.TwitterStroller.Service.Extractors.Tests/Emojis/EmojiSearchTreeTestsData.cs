using ncburn.TwitterStroller.Service.Extractors.Emojis;
using System.Collections.Generic;

namespace ncburn.TwitterStroller.Service.Extractors.Tests.Emojis
{
	public static class EmojiSearchTreeTestsData
	{
		private static EmojiSearchTree _emojis = new EmojiSearchTree();

		static EmojiSearchTreeTestsData()
		{
			_emojis.AddEmojis(
				new List<string>
				{
					":-)",
					":)",
					"😊"
				});
		}

		public static IEnumerable<object[]> TestGetEmojisReturnsExpectedEmojisData
		{
			get
			{
				yield return new object[]
				{
					"Null text parameter",
					"",
					_emojis,
					new List<string>(),
				};

				yield return new object[]
				{
					"Finds :-) in generic text",
					"Lorem ipsum dolor sit amet, consectetur :-) adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
					_emojis,
					new List<string> { ":-)" }
				};

				yield return new object[]
				{
					"Finds :) in generic text",
					"Lorem ipsum dolor sit amet, consectetur :) adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
					_emojis,
					new List<string> { ":)" }
				};

				yield return new object[]
				{
					"Finds 😊 at the end of the string",
					"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. 😊",
					_emojis,
					new List<string> { "😊" }
				};

				yield return new object[]
				{
					"Finds multiple emojis in text",
					"Lorem ipsum dolor sit amet, consectetur :-) adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea 😊commodo consequat. :) Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
					_emojis,
					new List<string> { ":-)", "😊", ":)" }
				};

				yield return new object[]
				{
					"Finds multiple emojis in text with multiple instances same emoji",
					"Lorem ipsum dolor sit amet, consectetur :-) adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad :-) minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea 😊commodo consequat. :) Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
					_emojis,
					new List<string> { ":-)", ":-)", "😊", ":)" }
				};
			}
		}
	}
}
