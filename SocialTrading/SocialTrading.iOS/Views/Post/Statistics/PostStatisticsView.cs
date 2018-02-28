using UIKit;
using Foundation;
using CoreGraphics;

using System;
using System.ComponentModel;

using SocialTrading.Locale;
using SocialTrading.Vipers.Post.Interfaces.Statistics;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class PostStatisticsView : UIView, IComponent, IViewPostStatistics
    {
        public PostStatisticsView (IntPtr handle) : base (handle)
        {
        }

        public ISite Site { get ; set; }
        public IPresenterPostStatistics Presenter { set; get; }

        public event EventHandler Disposed;

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			if (Site != null)
			{
				return;
			}

			NSBundle.MainBundle.LoadNib("PostStatisticsView", this, null);

			InvokeOnMainThread(() =>
			{
				var frame = _rootView.Frame;
				frame.Height = Frame.Height;
				frame.Width = Frame.Width;
				_rootView.Frame = frame;
				AddSubview(_rootView);
			});
		}

		public void SetConfig()
		{
			InvokeOnMainThread(() =>
			{
                _shortLabel.Text = Localization.Lang.ShortLabel;
                _longLabel.Text = Localization.Lang.LongLabel;
                _dealsLabel.Text = Localization.Lang.Deals;
                _pnlLabel.Text = Localization.Lang.PnL;
            });

		}

		public void SetDeals(string deals)
        {
			InvokeOnMainThread(() =>
		    {
                _dealsValueLabel.Text = deals; 
		    });

		}

        public void SetDealsStateNone()
        {
			InvokeOnMainThread(() =>
			{
				_dealsValueLabel.TextColor = UIColor.Black;

			});
        }

        public void SetDealsStatePositive()
        {
			InvokeOnMainThread(() =>
			{
                _dealsValueLabel.TextColor = UIColor.Green;

			});
        }

       public void SetLong(int size)
        {
			var heiht = _shortLineLabel.Frame.Height;
			var x = _shortLineLabel.Frame.X;
			var y = _shortLineLabel.Frame.Y;

            InvokeOnMainThread(() =>
			{
                _longLineLabel.Frame = new CGRect(x, y, size, heiht);

			});
        }

        public void SetLongPercent(string percent)
        {
			InvokeOnMainThread(() =>
			{
                _longValueLabel.Text = percent;
			});
        }

        public void SetPnL(string PnL)
        {
			InvokeOnMainThread(() =>
			{
                _pnlValueLabel.Text = PnL;
			});
        }

        public void SetPnLStateNegative()
        {
			InvokeOnMainThread(() =>
			{
                _pnlValueLabel.TextColor = UIColor.Red;
			});
        }

        public void SetPnLStateNone()
        {
			InvokeOnMainThread(() =>
			{
                _pnlValueLabel.TextColor = UIColor.Black;
			});
        }

        public void SetPnLStatePositive()
        {
			InvokeOnMainThread(() =>
			{
				_pnlValueLabel.TextColor = UIColor.Green;
			});
        }

        public void SetShortPercent(string percent)
        {
			InvokeOnMainThread(() =>
			{
                _shortValueLabel.Text = percent;
			});
        }


        public int GetStatisticsLineSize()
        {
            return Convert.ToInt32(_shortLineLabel.Frame.Width);
        }


    }
}