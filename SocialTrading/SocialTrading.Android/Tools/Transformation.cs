using Android.Graphics;

using Square.Picasso;

namespace SocialTrading.Droid.Tools
{
    class Transformation : Java.Lang.Object, ITransformation
    {
        public string Key => "aspectRatio()";
        private int _width;


        public Transformation(int width)
        {
            _width = width;
        }


        public Bitmap Transform(Bitmap source)
        {
            if (_width == 0)
            {
                return source;
            }

            var aspectRatio = (float)source.Height / (float)source.Width;
            var bitmap = Bitmap.CreateScaledBitmap(source, _width, (int)(_width * aspectRatio), true);

            if (bitmap != source)
            {
                source.Recycle();
            }

            return bitmap;
        }
    }
}