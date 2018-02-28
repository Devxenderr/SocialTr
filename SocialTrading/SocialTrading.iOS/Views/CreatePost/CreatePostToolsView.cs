using UIKit;
using Foundation;

using System;
using System.ComponentModel;
using System.Collections.Generic;

using SocialTrading.iOS.Cells;
using SocialTrading.iOS.Theme;
using SocialTrading.Tools.Interfaces;
using SocialTrading.iOS.Controllers.DataSources;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Tools.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class CreatePostToolsView : UIView, IComponent, ISetConfig, IViewTools
    {
        public IPresenterToolsForView Presenter { private get; set; }

		public CreatePostToolsView (IntPtr handle) : base (handle)
        {
        }

        private UIBarButtonItem _backButton;

        #region IComponent realization
        public ISite Site { get; set; }
        public event EventHandler Disposed;
        #endregion


        public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			if (Site != null)
			{
				return;
			}

			NSBundle.MainBundle.LoadNib("CreatePostToolsView", this, null);

			InvokeOnMainThread(() =>
			{
				var frame = _rootView.Frame;
				frame.Height = Frame.Height;
				frame.Width = Frame.Width;
				_rootView.Frame = frame;
				AddSubview(_rootView);
			});

            _toolsCollectionView.RegisterNib(ToolViewCell.Key, ToolViewCell.Nib);
		}

        private void RowSelectedHandler(int rowIndex)
        {
            Presenter.CellClick(rowIndex);
        }


		public void SetConfig()
		{
            _searchBar.Delegate = new CustomSearchBarDelegate(searchText => Presenter.SearchEdit(searchText));
        }

        #region IViewTools
        
        public void SetSearchTheme(string editTextBackground, string textColor, string textSize, string fontStyle)
        {
            _searchBar.SetTheme(editTextBackground, textColor, textSize, fontStyle);
        }

        public void SetCollectionViewTheme(string dividingLineColor, string dividingLineSize, string dividingLineType)
        {
            _toolsCollectionView.SetThemeTableViewSeparator(dividingLineColor, dividingLineSize, dividingLineType);
        }

        public void SetEnableCell(int index, IViewTheme viewTheme, ITextViewTheme labelTheme)
        {
            var indexPath = NSIndexPath.FromRowSection(index, 0);
            var cell = (ToolViewCell)_toolsCollectionView.CellAt(indexPath);

            cell?.SetThemes(viewTheme, labelTheme);
        }

        public void Scroll(int index)
        {
            _toolsCollectionView.ScrollToRow(NSIndexPath.FromRowSection(index, 0), UITableViewScrollPosition.Middle, true);
        }

        public void SetDataSource(List<string> listTools, IToolsStylesHolder stylesHolder)
        {
            _toolsCollectionView.DataSource = new ToolsDataSource(listTools, stylesHolder);
            _toolsCollectionView.Delegate = new CustomDelegate(RowSelectedHandler);
            _toolsCollectionView.ReloadData();
        }
        
        #endregion


        //====================  CustomDelegate classes ===========
        private class CustomDelegate : UITableViewDelegate
		{
            private readonly Action<int> _rowSelectedHandler;

            public CustomDelegate(Action<int> rowSelectedHandler)
            {
                _rowSelectedHandler = rowSelectedHandler;
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
                return 50;
			}

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                tableView.CellAt(indexPath).SelectionStyle = UITableViewCellSelectionStyle.None;

                _rowSelectedHandler?.Invoke(indexPath.Row);
            }
		}

        private class CustomSearchBarDelegate : NSObject, IUISearchBarDelegate
        {
            private readonly Action<string> _textChangedHandler;

            public CustomSearchBarDelegate(Action<string> textChangedHandler)
            {
                _textChangedHandler = textChangedHandler;
            }

            [Export("searchBar:textDidChange:")]
            public void TextChanged(UISearchBar searchBar, string searchText)
            {
                _textChangedHandler?.Invoke(searchText);
            }
        }
    }
}