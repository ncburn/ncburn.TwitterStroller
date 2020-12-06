using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ncburn.TwitterStroller.Service.Extractors.Emojis;
using System.Threading.Tasks;

namespace ncburn.TwitterStroller.Service.Extractors.Tests.Emojis
{
	[TestClass]
	public class JsonEmojiResourceFactoryTests
	{
		[TestMethod]
		public async Task CreateReturnsWithNoExceptions()
		{
			// Arrange
			var logger = new Mock<ILogger>();
			var emojiFactory = new JsonEmojiResourceFactory(logger.Object);

			// Act
			var resultingSearchTree = await emojiFactory.Create();

			// Assert
			resultingSearchTree.Should().NotBeNull();
			resultingSearchTree.Count.Should().BeGreaterThan(0);
		}

		[TestMethod]
		[DynamicData(
			nameof(JsonEmojiResourceFactoryTestsData.TestUnifiedRepresentationToUtf16StringReturnsExpectedData),
			typeof(JsonEmojiResourceFactoryTestsData))]
		public void UnifiedRepresentationToUtf16StringReturnsExpected(
			string description,
			string unifiedRepresentation,
			string expectedEmoji)
		{
			// Arrange
			// Act
			var resultingString = JsonEmojiResourceFactory.UnifiedRepresentationToUtf16String(unifiedRepresentation);

			// Assert
			resultingString.Should().Be(expectedEmoji, description);
		}
	}
}
