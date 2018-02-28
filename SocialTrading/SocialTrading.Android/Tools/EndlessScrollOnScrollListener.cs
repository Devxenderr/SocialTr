using System;

using Android.Support.V7.Widget;

namespace SocialTrading.Droid.Tools
{
    public class EndlessScrollOnScrollListener : RecyclerView.OnScrollListener
    {
        public event Action LoadMoreEvent;
        private readonly LinearLayoutManager _layoutManager;


        public EndlessScrollOnScrollListener(LinearLayoutManager layoutManager)
        {
            _layoutManager = layoutManager;
        }


        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);

            var visibleItemCount = recyclerView.ChildCount;
            var totalItemCount = recyclerView.GetAdapter().ItemCount;
            var pastVisiblesItems = _layoutManager?.FindFirstVisibleItemPosition();

            if (visibleItemCount + pastVisiblesItems >= totalItemCount)
            {
                LoadMoreEvent?.Invoke();
            }
        }
    }
}