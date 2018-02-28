using UIKit;
using Foundation;

using System;
using System.ComponentModel;
using System.Collections.Generic;

using SocialTrading.iOS.Cells;
using SocialTrading.Tools.Enumerations;
using SocialTrading.iOS.Controllers.DataSources;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;


namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class MoreOptionsView : UIView, IComponent
    {
        public UINavigationBar NavigationBar { get; set; }
        public UINavigationItem NavigationItem { get; set; }

        public IPresenterOptionsCellForView Presenter { get; set; }

        public MoreOptionsView(IntPtr handle) : base(handle)
        {
        }

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

            NSBundle.MainBundle.LoadNib("MoreOptionsView", this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });

            _moreOptionsTableView.RegisterNib(ProfileTableViewCell.Key, ProfileTableViewCell.Nib);
            _moreOptionsTableView.RegisterNib(OptionsTableViewCell.Key, OptionsTableViewCell.Nib);
        }

        public void SetConfig()
        {
            _moreOptionsTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

        }

        public void SetCellAutoHeight()
        {
            _moreOptionsTableView.RowHeight = UITableView.AutomaticDimension;
            _moreOptionsTableView.EstimatedRowHeight = 100;
        }

        public void SetDataSource(List<Tuple<Type, EItemsOptions>> dataSource, UIViewController controller)
        {
            _moreOptionsTableView.DataSource = new MoreOptionsDataSourse(dataSource, controller);
            _moreOptionsTableView.Delegate = new CustomDelegate(RowSelectedHandler);
        }

        private void RowSelectedHandler(int rowIndex)
        {

        }
       

        private class CustomDelegate : UITableViewDelegate
        {
            private Action<int> _rowSelectedHandler;

            public CustomDelegate(Action<int> rowSelectedHandler)
            {
                _rowSelectedHandler = rowSelectedHandler;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                _rowSelectedHandler?.Invoke(indexPath.Row);
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                if (indexPath.Row == 0)
                {
                    return 100;
                }
                return 50;
            }
        }
    }
}