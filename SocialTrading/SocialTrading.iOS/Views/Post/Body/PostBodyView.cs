using System;
using System.Drawing;
using System.ComponentModel;

using UIKit;
using Foundation;
using CoreGraphics;

using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Post.Interfaces.Body;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
	public partial class PostBodyView : UIView, IComponent, IViewPostBody
	{
        public IPresenterPostBody Presenter { set; get; }

        public ISite Site { get; set; }

        public event EventHandler Disposed;

        public int Width { get; set; }
	    private Action _setImage;

	    private int _postId;
	    private Action<int, nfloat> PostBodyHeightCounted;


        public PostBodyView(IntPtr handle) : base(handle)
		{
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			if (Site != null)
			{
				return;
			}

			NSBundle.MainBundle.LoadNib("PostBodyView", this, null);

			InvokeOnMainThread(() =>
			{
				var frame = _rootView.Frame;
				frame.Height = Frame.Height;
				frame.Width = Frame.Width;
				_rootView.Frame = frame;
				AddSubview(_rootView);
			});
        }

        private void SetActions()
        {
            if (!Presenter.IsPostDetailed)
            {
                UITapGestureRecognizer labelTap = new UITapGestureRecognizer(() =>
                {
                    Presenter.ReadMoreClick();
                });

                _contentLabel.UserInteractionEnabled = true;
                _contentLabel.AddGestureRecognizer(labelTap);
            }
        }

        public void SetConfig()
		{
			SetActions();
		}

	    public void CacheImage(string imageUrl)
	    {
	        using (var url = new NSUrl(imageUrl))
	        using (var data = NSData.FromUrl(url))
	        {
	            if (data == null)
	            {
	                return;
	            }

	            NSData imageData = UIImage.LoadFromData(data)?.AsPNG();
	            string encodedImage = imageData?.GetBase64EncodedData(NSDataBase64EncodingOptions.None).ToString();

                Presenter.SaveCachedImage(encodedImage);
	        }
        }

	    public void SetActionOnCountingHeight(Action<int, nfloat> postBodyHeightCounted, int id)
	    {
	        _postId = id;
	        PostBodyHeightCounted = postBodyHeightCounted;
	    }

	    public void SetImage(string image)
	    {
	        InvokeOnMainThread(() =>
	        {
                if (image == null)
                {
                    _image.Image = null;
                    _heightImageConstraint.Constant = 0;
                    _contentDownConstraint.Constant = 0;
                }
                else
                {

                    _contentDownConstraint.Constant = 16;

                    float width = (float)(Width);// - _endImageConstraint.Constant - _startImageConstraint.Constant);

                    var imageHiRes = FromBase64(image);

                    _image.Image = imageHiRes;

                    var aspectRatio = imageHiRes.Size.Height / imageHiRes.Size.Width;

                    var height = width * aspectRatio;

                    UIGraphics.BeginImageContext(new SizeF(width, (float)height));
                    imageHiRes.Draw(new RectangleF(0, 0, width, (float)height));
                    var imageLowRes = UIGraphics.GetImageFromCurrentImageContext();
                    imageHiRes = null;
                    UIGraphics.EndImageContext();

                    _image.Image = imageLowRes;
                    _heightImageConstraint.Constant = height;
                    _widthImageConstraint.Constant = width;
                }

                SetNeedsLayout();

                PostBodyHeightCounted?.Invoke(_postId, _heightImageConstraint.Constant + _contentLabel.Frame.Height + _contentUpConstraint.Constant + _contentDownConstraint.Constant);

                LayoutIfNeeded();
	        });
	    }


	    private UIImage FromBase64(string base64)
	    {
	        var encodedDataAsBytes = Convert.FromBase64String(base64);
	        var data = NSData.FromArray(encodedDataAsBytes);

	        return UIImage.LoadFromData(data);
        }

        private UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
            {
                return UIImage.LoadFromData(data);
            }
        }

        public void SetContent(string content, string readMore, ITextViewTheme mainTheme, ITextViewTheme attrTheme, int position)
        {
            InvokeOnMainThread(() =>
            {
                _contentLabel.SetTheme(mainTheme, content, attrTheme, readMore, position);

                CalculateContentlabelHeight();
            });
        }

        public void SetContent(string content, ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _contentLabel.SetTheme(theme);
                _contentLabel.Text = content;

                CalculateContentlabelHeight();
            });
        }

        private void CalculateContentlabelHeight()
        {
            var calculatedHeight = _contentLabel.SizeThatFits(new CGSize(_contentLabel.Frame.Width - 5, float.MaxValue)).Height;

            _contentLabel.Frame = new CGRect(_contentLabel.Frame.Location, new CGSize(_contentLabel.Frame.Width, calculatedHeight));

            SetNeedsLayout();
        }
	}
}