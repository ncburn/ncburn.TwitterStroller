using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ncburn.TwitterStroller.Service.Extractors.Emojis;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ncburn.TwitterStroller.Service.Extractors.Tests.Emojis
{
	[TestClass]
	public class EmojiSearchTreeBuilderTests
	{
		[TestMethod]
		[DynamicData(
			nameof(EmojiSearchTreeBuilderTestsData.TestBuildReturnsExpectedSearchTreeData),
			typeof(EmojiSearchTreeBuilderTestsData))]
		public void BuildUsingJsonReturnsExpectedSearchTree(
			string description,
			JToken json,
			EmojiSearchTree expectedSearchTree)
		{
			// Arrange
			var builder = new EmojiSearchTreeBuilder<JToken>();

			builder.WithData(json);
			builder.WithSelector(SelectEmojisFromJson);

			// Act
			var actualSearchTree = builder.Build();

			// Assert
			actualSearchTree.Should().BeEquivalentTo(expectedSearchTree, description);
		}

		private static IEnumerable<string> SelectEmojisFromJson(JToken json)
		{
			yield return json["unified"].ToString();
			yield return json["text"].ToString();
		}
	}
}
