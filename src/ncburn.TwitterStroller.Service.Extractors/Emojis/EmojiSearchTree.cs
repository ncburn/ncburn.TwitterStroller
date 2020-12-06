using System;
using System.Collections.Generic;
using System.Text;

namespace ncburn.TwitterStroller.Service.Extractors.Emojis
{
	public class EmojiSearchTree
	{
		public Node RootNode { get; private set; }

		public int Count { get; private set; }

		public EmojiSearchTree()
		{
			RootNode = new Node();
		}

		public EmojiSearchTree(Node root)
		{
			RootNode = root ?? throw new ArgumentNullException(nameof(root));
		}

		public IEnumerable<string> GetEmojis(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				yield break;
			}

			foreach (var emojiString in FindNextEmoji(text, RootNode))
			{
				yield return emojiString;
			}
		}

		public void AddEmoji(string emoji)
		{
			var currentNode = RootNode;

			foreach(var character in emoji)
			{
				if (currentNode.TryGetValue(character, out var existingNode))
				{
					currentNode = existingNode;
				}
				else
				{
					var newNode = new Node();
					newNode.IsLastCharInEmoji = false;
					currentNode.Add(character, newNode);
					currentNode = newNode;
				}
			}

			currentNode.IsLastCharInEmoji = true;
			Count += 1;
		}

		public void AddEmojis(IEnumerable<string> emojis)
		{
			foreach (var emoji in emojis)
			{
				AddEmoji(emoji);
			}
		}

		private IEnumerable<string> FindNextEmoji(
			IEnumerable<char> characters,
			Node rootNode)
		{
			var emojiString = new StringBuilder();
			var charEnumerator = characters.GetEnumerator();
			var hasCharacters = true;

			while(charEnumerator.MoveNext())
			{
				var currentNode = rootNode;
				while(hasCharacters && currentNode.TryGetValue(charEnumerator.Current, out var foundNode))
				{
					emojiString.Append(charEnumerator.Current);
					if (foundNode.IsLastCharInEmoji)
					{
						yield return emojiString.ToString();

						currentNode = rootNode;
						emojiString.Clear();
					}
					else
					{
						currentNode = foundNode;
					}

					hasCharacters = charEnumerator.MoveNext();
				}
			}
		}
	}
}
