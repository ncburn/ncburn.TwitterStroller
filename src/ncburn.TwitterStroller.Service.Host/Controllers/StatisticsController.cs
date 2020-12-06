using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ncburn.TwitterStroller.Service.Actions;
using System;
using Microsoft.AspNetCore.Http;

namespace ncburn.TwitterStroller.Service.Controllers
{
	[Route("v1/statistics")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		IAnalyzePostsAction _analyzePostsAction;
		IAnalyzeEmojisAction _analyzeEmojisAction;
		IAnalyzeHashTagsAction _analyzeHashTagsAction;
		IAnalyzeUrlsAction _analyzeUrlsAction;
		ILogger _logger;

		public StatisticsController(
			IAnalyzePostsAction analyzePostsAction,
			IAnalyzeEmojisAction analyzeEmojisAction,
			IAnalyzeHashTagsAction analyzeHashTagsAction,
			IAnalyzeUrlsAction analyzeUrlsAction,
			ILogger logger)
		{
			_analyzePostsAction = analyzePostsAction ?? throw new ArgumentNullException(nameof(analyzePostsAction));
			_analyzeEmojisAction = analyzeEmojisAction ?? throw new ArgumentNullException(nameof(analyzeEmojisAction));
			_analyzeHashTagsAction = analyzeHashTagsAction ?? throw new ArgumentNullException(nameof(analyzeHashTagsAction));
			_analyzeUrlsAction = analyzeUrlsAction ?? throw new ArgumentNullException(nameof(analyzeUrlsAction));
			_logger = logger;

		}

		[HttpGet("posts")]
		public IActionResult GetPostStatistics()
		{
			try
			{
				_logger?.LogDebug("Getting post statistics");

				var postStatistics = _analyzePostsAction.Analyze();

				_logger?.LogDebug("Statistics received. Returning post statistics.");

				return Ok(postStatistics);
			}
			catch (Exception exception)
			{
				_logger?.LogError("Failed to get post statistics. {exception}", exception.Message);

				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet("topemojis")]
		public IActionResult GetTopEmojis()
		{
			try
			{
				_logger?.LogDebug("Getting emoji statistics");

				var emojiStatistics = _analyzeEmojisAction.Analyze();

				_logger?.LogDebug("Statistics received. Returning emoji statistics.");

				return Ok(emojiStatistics);
			}
			catch (Exception exception)
			{
				_logger?.LogError("Failed to get emoji statistics. {exception}", exception.Message);

				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet("tophashtags")]
		public IActionResult GetTopHashTags()
		{
			try
			{
				_logger?.LogDebug("Getting hashtag statistics");

				var hashtagStatistics = _analyzeHashTagsAction.Analyze();

				_logger?.LogDebug("Statistics received. Returning hashtag statistics.");

				return Ok(hashtagStatistics);
			}
			catch (Exception exception)
			{
				_logger?.LogError("Failed to get hashtag statistics. {exception}", exception.Message);

				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet("urls")]
		public IActionResult GetUrlStatistics()
		{
			try
			{
				_logger?.LogDebug("Getting URL statistics");

				var hashtagStatistics = _analyzeUrlsAction.Analyze();

				_logger?.LogDebug("Statistics received. Returning URL statistics.");

				return Ok(hashtagStatistics);
			}
			catch (Exception exception)
			{
				_logger?.LogError("Failed to get URL statistics. {exception}", exception.Message);

				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
