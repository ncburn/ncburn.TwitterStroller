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
	}
}
