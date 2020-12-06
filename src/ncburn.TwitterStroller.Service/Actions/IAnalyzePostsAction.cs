using ncburn.TwitterStroller.Shared;

namespace ncburn.TwitterStroller.Service.Actions
{
	public interface IAnalyzePostsAction
	{
		PostStatistics Analyze();
	}
}
