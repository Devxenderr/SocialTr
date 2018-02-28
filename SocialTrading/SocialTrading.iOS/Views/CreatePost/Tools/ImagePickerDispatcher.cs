using System;

using UIKit;
using Foundation;

namespace SocialTrading.iOS.Views
{
    public class ImagePickerDispatcher : IDisposable
    {
        public UIImagePickerController ImagePicker { get; set; }
        public Action<string> OnGetImageFromGallery;
        private bool _subsribed = false;

        public ImagePickerDispatcher()
        {
            ImagePicker = new UIImagePickerController()
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            if (!_subsribed)
            {
                ImagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
                ImagePicker.Canceled += Handle_Canceled;

                _subsribed = true;
            }
        }

        private void Handle_Canceled(object sender, EventArgs e)
        {
            ImagePicker.DismissModalViewController(true);
        }

        private void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            if (e.Info[UIImagePickerController.OriginalImage] is UIImage originalImage)
            {
                NSData imageData = originalImage.AsPNG();
                string encodedImage = imageData.GetBase64EncodedData(NSDataBase64EncodingOptions.None).ToString();
                OnGetImageFromGallery?.Invoke(encodedImage);
            }

            ImagePicker.DismissModalViewController(true);
        }

        public void Dispose()
        {
            ImagePicker.FinishedPickingMedia -= Handle_FinishedPickingMedia;
            ImagePicker.Canceled -= Handle_Canceled;

            OnGetImageFromGallery = null;

            ImagePicker.Dispose();
        }
    }
}
