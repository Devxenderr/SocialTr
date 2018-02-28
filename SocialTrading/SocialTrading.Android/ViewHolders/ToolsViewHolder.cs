using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace SocialTrading.Droid.ViewHolders
{
    internal class ToolsViewHolder : RecyclerView.ViewHolder
    {
        public TextView ToolTextView { get; }
        public RelativeLayout ToolRelLayouot { get; set; }
        public Action<string> ToolClick;

        public ToolsViewHolder(View view) : base(view)
        {
            ToolTextView = view.FindViewById<TextView>(Resource.Id.toolCard_toolName_textView);
            ToolRelLayouot = view.FindViewById<RelativeLayout>(Resource.Id.toolCard_relLayout);
            if (!ToolRelLayouot.HasOnClickListeners)
            {
                ToolRelLayouot.Click += OnToolClick;
            }
        }

        private void OnToolClick(object sender, EventArgs e)
        {
            ToolClick?.Invoke(ToolTextView.Text);
        }
    }
}