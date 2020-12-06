using System.Collections.Generic;

namespace ncburn.TwitterStroller.Shared
{
	public class TopEmojis
	{
		public ISet<string> Emojis { get; set; }
		public double PercentPostsWithEmojis { get; set; }
	}
}
