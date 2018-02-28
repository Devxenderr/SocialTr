using System;
using System.Collections.Generic;

using Android.Views;
using Android.Support.V7.Widget;

using SocialTrading.Droid.Theme;
using SocialTrading.Droid.ViewHolders;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Tools.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Droid.Adapters.Recycler
{
    internal class CreatePostToolsRecyclerAdapter : RecyclerView.Adapter
    {
        public RecyclerView RecyclerView { get; set; }
        public IToolsStylesHolder StylesHolder { get; set; }
        public List<string> ToolsList { get; set; }

        public Action<int> CellClick;

        private int _selectedCell = -1;


        public override int ItemCount => ToolsList?.Count ?? 0;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var toolsHolder = holder as ToolsViewHolder;
            toolsHolder.ToolTextView.Text = ToolsList[position];

            if (position == _selectedCell)
            {
                SetCellTheme(toolsHolder, StylesHolder.SelectedCellTheme, StylesHolder.ToolNameTheme);
            }
            else
            {
                SetCellTheme(toolsHolder, StylesHolder.UnselectedCellTheme, StylesHolder.ToolNameTheme);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ToolCard, parent, false);

            var viewHolder = new ToolsViewHolder(itemView)
            {
                ToolClick = s =>
                {
                    CellClick.Invoke(ToolsList.IndexOf(s));
                }
            };

            return viewHolder;
        }


        private void SetCellTheme(ToolsViewHolder viewHolder, IViewTheme viewTheme, ITextViewTheme textViewTheme)
        {
            viewHolder.ToolRelLayouot.SetTheme(viewTheme);
            viewHolder.ToolTextView.SetTheme(textViewTheme);
        }

        public void SetCellTheme(IViewTheme viewTheme, ITextViewTheme textViewTheme, int index)
        {
            _selectedCell = index;

            var holder = RecyclerView.FindViewHolderForAdapterPosition(index) as ToolsViewHolder; // TODO: problem in indecies
            // TODO: while searching after click on item holder is null -> NullRefException
            SetCellTheme(holder, viewTheme, textViewTheme);
        }
    }
}