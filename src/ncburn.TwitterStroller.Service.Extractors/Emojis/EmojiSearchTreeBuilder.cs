using System;
using System.Collections.Generic;

namespace ncburn.TwitterStroller.Service.Extractors.Emojis
{
	public class EmojiSearchTreeBuilder<T>
	{
		private EmojiSearchTree _searchTree = new EmojiSearchTree();
		private IEnumerable<T> _dataList;
		private Func<T, IEnumerable<string>> _selector;

		public EmojiSearchTreeBuilder<T> WithData(IEnumerable<T> dataList)
		{
			_dataList = dataList ?? throw new ArgumentNullException(nameof(dataList));

			return this;
		}

		public EmojiSearchTreeBuilder<T> WithSelector(Func<T, IEnumerable<string>> selector)
		{
			_selector = selector ?? throw new ArgumentNullException(nameof(selector));

			return this;
		}

		public EmojiSearchTree Build()
		{
			foreach (var data in _dataList)
			{
				foreach (var emoji in _selector(data))
				{
					_searchTree.AddEmoji(emoji);
				}
			}

			return _searchTree;
		}
	}
}
