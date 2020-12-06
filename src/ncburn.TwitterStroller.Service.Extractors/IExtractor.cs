using System.Collections.Generic;

namespace ncburn.TwitterStroller.Service.Extractors
{
	public interface IExtractor
	{
		IDictionary<string, CoreStatistics> Extract(string post);
	}
}
