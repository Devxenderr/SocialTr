using System.Collections.Generic;

using Android.Views;
using Android.Support.V7.Widget;

using SocialTrading.Droid.ViewHolders;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;

namespace SocialTrading.Droid.Adapters
{
    internal class PostsRecyclerAdapter : RecyclerView.Adapter
    {
        public override int ItemCount => PostIds?.Count ?? 0;

        public List<string> PostIds {
            get => _postIds;
            set
            {
                if (value != null && value.Count != 0)
                {
                    _postIds = value;
                    NotifyDataSetChanged();
                }
            }
        }

        private List<string> _postIds;

        private readonly IRepositoryQc _repositoryQc;
        private readonly IRepositoryPost _repository;
        private readonly INotificationCenter _notification;
        private readonly PostOtherThemeStrings _otherThemeStrings;


        public PostsRecyclerAdapter(INotificationCenter notification, IRepositoryPost repository, IRepositoryQc repositoryQc,
            PostOtherThemeStrings otherThemeStrings)
        {           
            _repository = repository;
            _repositoryQc = repositoryQc;
            _notification = notification;

            _otherThemeStrings = otherThemeStrings;
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var newsViewHolder = holder as PostsViewHolder;

            newsViewHolder?.CreateViper(PostIds[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PostCard, parent, false);
            return new PostsViewHolder(
                itemView:               itemView,
                notification:           _notification,
                repository:             _repository,
                repositoryQc:           _repositoryQc,
                otherThemeStrings:      _otherThemeStrings          
            );
        }
    }
}