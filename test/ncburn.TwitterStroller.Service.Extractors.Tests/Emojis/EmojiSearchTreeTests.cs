using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ncburn.TwitterStroller.Service.Extractors.Emojis;
using System.Collections.Generic;
using System.Linq;

namespace ncburn.TwitterStroller.Service.Extractors.Tests.Emojis
{
	[TestClass]
	public class EmojiSearchTreeTests
	{
		[TestMethod]
		[DynamicData(
			nameof(EmojiSearchTreeTestsData.TestGetEmojisReturnsExpectedEmojisData),
			typeof(EmojiSearchTreeTestsData))]
		public void GetEmojisReturnsExpectedEmojis(
			string description,
			string textToSearch,
			EmojiSearchTree searchTree,
			IList<string> expectedEmojis)
		{
			// Arrange
			// Act
			var foundEmojis = searchTree.GetEmojis(textToSearch).ToList();

			// Assert
			foundEmojis.Should().BeEquivalentTo(expectedEmojis, description);
		}

		[TestMethod]
		public void AddEmojisWhereSearchTreeHasExpectedCount()
		{
			// Arrange
			var searchTree = new EmojiSearchTree();
			var emojiList = new List<string>
			{
				":-)",
				":)",
				"😊"
			};

			// Act
			searchTree.AddEmojis(emojiList);

			// Assert
			searchTree.Count.Should().Be(emojiList.Count);
		}
	}
}
