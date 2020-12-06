using System.Collections.Generic;

namespace ncburn.TwitterStroller.Shared
{
	public class UrlStatistics
	{
		public double PercentPostsWithUrls { get; set; }
		public double PercentPostsWithImageUrl { get; set; }
		public ISet<string> TopDomains { get; set; }
	}
}
