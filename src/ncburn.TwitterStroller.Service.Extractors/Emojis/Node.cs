using System;
using System.Collections.Generic;

namespace ncburn.TwitterStroller.Service.Extractors.Emojis
{
	public class Node : Dictionary<char, Node>
	{
		public bool IsLastCharInEmoji { get; set; } = false;
		public Node Children { get; set; }

		public Node()
		{
		}

		public Node(Node children)
		{
			Children = children ?? throw new ArgumentNullException(nameof(children));
		}
	}
}
