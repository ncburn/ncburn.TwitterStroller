using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ncburn.TwitterStroller.Clients.Twitter
{
	public class TwitterClient : HttpClient, ISocialMediaClient
	{
		private ApplicationCredentials _credentials;
		private ILogger<TwitterClient> _logger;

		public TwitterClient(ApplicationCredentials credentials, ILogger<TwitterClient> logger)
		{
			_credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public Task<IEnumerable<string>> GetSamples()
		{
			throw new NotImplementedException();
		}
	}
}
