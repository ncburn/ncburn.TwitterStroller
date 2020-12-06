using ncburn.TwitterStroller.Shared;

namespace ncburn.TwitterStroller.Service.Actions
{
	public interface IAnalyzeUrlsAction
	{
		UrlStatistics Analyze();
	}
}
