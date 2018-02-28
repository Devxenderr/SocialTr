using System;
using System.Collections.Generic;

using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Support.V7.Widget;

using SocialTrading.Tools.Interfaces;
using SocialTrading.Droid.ViewHolders;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;

namespace SocialTrading.Droid.Adapters.Recycler
{
    public class MoreOptionsRecyclerAdapter : RecyclerView.Adapter
    {
        private readonly List<Tuple<Type, EItemsOptions>> _dataSource;
        private readonly IRouterOptionsCell _router;

        public override int ItemCount => _dataSource.Count;


        public MoreOptionsRecyclerAdapter(List<Tuple<Type, EItemsOptions>> dataSource, IRouterOptionsCell router)
        {
            _dataSource = dataSource;
            _router = router;
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ISetDataForMoreCells holderSetData)
            {
                holderSetData.SetData(_dataSource[position].Item2);
            }
        }

        public override int GetItemViewType(int position)
        {
            if (_dataSource[position].Item1 == typeof(IProfileCell))
            {
                return 0;
            }
            else if(_dataSource[position].Item1 == typeof(IOptionCell))
            {
                return 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Wrong type of cell!");
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == 0)
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ProfileCellView, parent, false);
                RelativeLayout relativeLayout = new RelativeLayout(parent.Context);
                relativeLayout.AddView(itemView);

                View dividingLine = new View(parent.Context);
                RelativeLayout.LayoutParams parameters = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
                parameters.AddRule(LayoutRules.Below, itemView.Id);
                dividingLine.LayoutParameters = parameters;
                dividingLine.SetBackgroundColor(Color.LightGray);
                relativeLayout.AddView(dividingLine);

                return new ProfileViewHolder(relativeLayout);
            }
            else if (viewType == 1)
            {
                View optionView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.OptionsCellView, parent, false);
                return new OptionViewHolder(optionView, _router);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Wrong type of cell!");
            }
        }
    }
}