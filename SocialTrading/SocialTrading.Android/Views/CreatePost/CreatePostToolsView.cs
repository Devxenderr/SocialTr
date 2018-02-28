using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;

using System.Collections.Generic;

using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Adapters.Recycler;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Tools.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;

using SearchView = Android.Widget.SearchView;

namespace SocialTrading.Droid.Views.CreatePost
{
    public class CreatePostToolsView : LinearLayout, IViewTools
    {
        private Holder _holder;
        private CreatePostToolsRecyclerAdapter _adapter;
        private SimpleDividerItemDecoration _decorator;

        public IPresenterToolsForView Presenter { set; get; }

        #region For RelativeLayout

        public CreatePostToolsView(Context context) : base(context)
        {
            Init(context);
        }

        public CreatePostToolsView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public CreatePostToolsView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public CreatePostToolsView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            LayoutInflater inflater = ((Activity)context).LayoutInflater;
            inflater.Inflate(Resource.Layout.CreatePostToolsView, this, true);

            _holder = new Holder(this);

            _holder.ToolsRecyclerView.SetLayoutManager(new LinearLayoutManager(Context));
            _adapter = new CreatePostToolsRecyclerAdapter();
            _holder.ToolsRecyclerView.SetAdapter(_adapter);
            _decorator = new SimpleDividerItemDecoration(Context);
            _holder.ToolsRecyclerView.AddItemDecoration(_decorator);

            SetButtonsActions();
        }

        private void SetButtonsActions()
        {
            if (!_holder.ToolsSearchView.HasOnClickListeners)
            {
                _holder.ToolsSearchView.QueryTextChange += (sender, args) =>
                {
                    Presenter.SearchEdit(_holder.ToolsSearchView.Query);
                };
            }
            _adapter.CellClick = OnCellClick;
        }

        private void OnCellClick(int index)
        {
            Presenter.CellClick(index);
        }

        #endregion
        
        public void SetCollectionViewTheme(string dividingLineColor, string dividingLineSize, string dividingLineType)
        {
        }

        private ImageView GetImageViewFromSearchView(LinearLayout ll)
        {
            for (var i = 0; i < ll?.ChildCount; i++)
            {
                if (ll?.GetChildAt(i) is ImageView item)
                {
                    return item;
                }
                else if (ll?.GetChildAt(i) is LinearLayout internalLl)
                {
                    return GetImageViewFromSearchView(internalLl);
                }
            }

            return null;
        }

        public void SetSearchTheme(string editTextBackground, string textColor, string textSize, string fontStyle)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                var scale = (int)Resources.DisplayMetrics.Density;
                var imageView = GetImageViewFromSearchView(_holder.ToolsSearchView);

                imageView.SetMinimumWidth(int.MaxValue);
                imageView.SetPadding(21 * scale, 12 * scale, 21 * scale, 12 * scale);
                imageView.SetScaleType(ImageView.ScaleType.FitStart);

                _holder.ToolsSearchView.SetTheme(
                   editTextBackground: editTextBackground,
                   textColor: textColor,
                   textSize: textSize,
                   fontStyle: fontStyle
                );
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetStroke(3, Color.LightGray);
                _holder.ToolsSearchView.Background = gradientDrawable;
            });
        }

        public void Scroll(int index)
        {
           
        }

        public void SetEnableCell(int index, IViewTheme viewTheme, ITextViewTheme textViewTheme)
        {
            if (index == -1)
            {
                return;
            }

            _adapter.SetCellTheme(viewTheme, textViewTheme, index);
        }

        public void SetDataSource(List<string> listTools, IToolsStylesHolder stylesHolder)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _adapter = new CreatePostToolsRecyclerAdapter
                {
                    CellClick = OnCellClick,
                    ToolsList = listTools,
                    StylesHolder = stylesHolder,
                    RecyclerView = _holder.ToolsRecyclerView
                };

                _holder.ToolsRecyclerView.SetAdapter(_adapter);
                _holder.ToolsRecyclerView.AddItemDecoration(_decorator);
            });
        }

        private class Holder
        {
            public Holder(View viewGroup)
            {
                ToolsSearchView = viewGroup.FindViewById<SearchView>(Resource.Id.createPost_tools_searchView);
                ToolsRecyclerView = viewGroup.FindViewById<RecyclerView>(Resource.Id.createPost_tools_recyclerView);
            }
            
            public SearchView ToolsSearchView { get; }
            public RecyclerView ToolsRecyclerView { get; }
        }


        private class SimpleDividerItemDecoration : RecyclerView.ItemDecoration
        {
            private Drawable _divider;
            
            public SimpleDividerItemDecoration(Context context)
            {
                _divider = ContextCompat.GetDrawable(context, Resource.Drawable.toolsLineDivider);
            }

            public override void OnDrawOver(Canvas c, RecyclerView parent, RecyclerView.State state)
            {
                int left = parent.PaddingLeft;
                int right = parent.Width - parent.PaddingRight;

                int childCount = parent.ChildCount;
                for (int i = 0; i < childCount; i++)
                {
                    View child = parent.GetChildAt(i);


                    RecyclerView.LayoutParams myParams = (RecyclerView.LayoutParams) child.LayoutParameters;

                    int top = child.Bottom + myParams.BottomMargin;
                    int bottom = top + _divider.IntrinsicHeight;

                    _divider.SetBounds(left, top, right, bottom);
                    _divider.Draw(c);

                }     
            }
        }
    }
}