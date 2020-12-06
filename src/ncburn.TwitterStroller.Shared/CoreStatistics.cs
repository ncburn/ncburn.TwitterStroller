namespace ncburn.TwitterStroller.Service.Extractors
{
	public class CoreStatistics
	{
		/// <summary>
		///		Total posts processed by an extractor.
		/// </summary>
		public int TotalPosts { get; set; }

		/// <summary>
		///		The number of posts containing the text being searched for by the extractor.
		/// </summary>
		public int NumberPostContainingFoundText { get; set; }
	}
}
