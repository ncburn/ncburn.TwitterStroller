using System.Collections.Generic;
using System.Threading.Tasks;

namespace ncburn.TwitterStroller.Clients
{
	public interface ISocialMediaClient
	{
		Task<IEnumerable<string>> GetSamples();
	}
}
