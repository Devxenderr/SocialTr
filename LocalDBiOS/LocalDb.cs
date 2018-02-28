using System;
using LocalDB;
using Foundation;
using UIKit;

namespace LocalDBiOS
{
    public class LocalDb : ALocalDB
    {
        private NSUserDefaults _userDefaults;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalDb" /> class.
        /// </summary>
        public LocalDb()
        {
            Create();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalDb" /> class.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        public LocalDb(string dbName)
        {
            if (string.IsNullOrWhiteSpace(dbName))
            {
                return;
            }

            Create(dbName);
        }

        protected override void Create()
        {
            _userDefaults = NSUserDefaults.StandardUserDefaults;
        }
        
        protected override void Create(string localDbName)
        {
            _localDbName = localDbName;
            _userDefaults = new NSUserDefaults(_localDbName, NSUserDefaultsType.SuiteName);
        }

        /// <summary>
        /// Dispose the local database.
        /// </summary>
        public override void Dispose()
        {
            _userDefaults = null;
        }

        ///// <summary>
        ///// Deletes local database.
        ///// </summary>
        //public void Delete()
        //{
        //    NSUserDefaults.StandardUserDefaults.RemoveObject(_localDbName);
        //    string appDomain = NSBundle.MainBundle.BundleIdentifier;
        //    _userDefaults.RemovePersistentDomain(appDomain);
        //}

        // <summary>
        /// Deletes value by key local database.
        /// </summary>
        public override void Delete(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            _userDefaults.RemoveObject(key);
        }

        #region LoadData
        /// <summary>
        /// Loads string by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>String by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public override string LoadData(string key, string defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            if (_userDefaults == null)
            {
                CreateIfNotExist();
            }

            string result = _userDefaults.StringForKey(key);
            
            if(string.IsNullOrWhiteSpace(result))
            {
                return defValue;
            }
                         
            return result;
        }

        /// <summary>
        /// Loads int by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Int by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public override int LoadData(string key, int defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            if (_userDefaults == null)
            {
                CreateIfNotExist();
            }

            int result;
            var resultString = _userDefaults.StringForKey(key);

            if (string.IsNullOrEmpty(resultString))
            {
                result = defValue;
            }
            else
            {
                int.TryParse(resultString, out result);
            }

            return result;
        }

        /// <summary>
        /// Loads long by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Long by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public override long LoadData(string key, long defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            if (_userDefaults == null)
            {
                CreateIfNotExist();
            }

            long result;
            var resultString = _userDefaults.StringForKey(key);

            if (string.IsNullOrEmpty(resultString))
            {
                result = defValue;
            }
            else
            {
                long.TryParse(resultString, out result);
            }

            return result;
        }

        /// <summary>
        /// Loads float by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Float by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public override float LoadData(string key, float defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            if (_userDefaults == null)
            {
                CreateIfNotExist();
            }

            float result;
            var resultString = _userDefaults.StringForKey(key);

            if (string.IsNullOrEmpty(resultString))
            {
                result = defValue;
            }
            else
            {
                float.TryParse(resultString, out result);
            }

            return result;
        }

        /// <summary>
        /// Loads double by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Double by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public override double LoadData(string key, double defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            if (_userDefaults == null)
            {
                CreateIfNotExist();
            }

            double result;
            var resultString = _userDefaults.StringForKey(key);

            if (string.IsNullOrEmpty(resultString))
            {
                result = defValue;
            }
            else
            {
                double.TryParse(resultString, out result);
            }

            return result;
        }

        /// <summary>
        /// Loads bool by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Bool by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public override bool LoadData(string key, bool defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            if (_userDefaults == null)
            {
                CreateIfNotExist();
            }

            bool result;
            var resultString = _userDefaults.StringForKey(key);

            if (string.IsNullOrEmpty(resultString))
            {
                result = defValue;
            }
            else
            {
                bool.TryParse(resultString, out result);
            }

            return result;
        }

        /// <summary>
        /// Loads UIKit.UIColor by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>UIKit.UIColor by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public UIColor LoadData(string key, UIColor defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            CreateIfNotExist();

            string hexString = LoadData(key, "");

            if (hexString == null || hexString == "")
            {
                return defValue;
            }

            hexString = hexString.Replace("#", "");

            int red = Int32.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int green = Int32.Parse(hexString.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int blue = Int32.Parse(hexString.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);

            return UIColor.FromRGB(red, green, blue);
        }


        /// <summary>
        /// Loads UIKit.UIImage by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>UIKit.UIImage by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public UIImage LoadData(string key, UIImage defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            CreateIfNotExist();

            string hexString = LoadData(key, "");

            if (hexString == null || hexString == "")
            {
                return defValue;
            }
            
            byte[] encodedDataAsBytes = Convert.FromBase64String(hexString);
            NSData data = NSData.FromArray(encodedDataAsBytes);
            return UIImage.LoadFromData(data);
        }
        #endregion

        #region SaveData
        /// <summary>
        /// Saves string by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public override void SaveData(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            CreateIfNotExist();
            _userDefaults.SetString(value, key);
        }

        /// <summary>
        /// Saves int by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public override void SaveData(string key, int value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            CreateIfNotExist();
            _userDefaults.SetString(value.ToString(), key);
        }

        /// <summary>
        /// Saves long by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public override void SaveData(string key, long value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            CreateIfNotExist();
            _userDefaults.SetString(value.ToString(), key);
        }

        /// <summary>
        /// Saves float by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public override void SaveData(string key, float value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            CreateIfNotExist();
            _userDefaults.SetString(value.ToString(), key);
        }

        /// <summary>
        /// Saves double by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public override void SaveData(string key, double value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            CreateIfNotExist();
            _userDefaults.SetString(value.ToString(), key);
        }

        /// <summary>
        /// Saves bool by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public override void SaveData(string key, bool value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            CreateIfNotExist();
            _userDefaults.SetString(value.ToString(), key);
        }

        /// <summary>
        /// Saves UIKit.UiColor by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="colorValue">The color value.</param>
        public void SaveData(string key, UIColor colorValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            CreateIfNotExist();

            nfloat red;
            nfloat green;
            nfloat blue;
            nfloat alpha;

            colorValue.GetRGBA(out red, out green, out blue, out alpha);
            string hex = string.Format("#{0}", BitConverter.ToString(new byte[] { Convert.ToByte(red * 255), Convert.ToByte(green * 255), Convert.ToByte(blue * 255) })).Replace("-", string.Empty);
            SaveData(key, hex);
        }

        /// <summary>
        /// Saves UIKit.UIImage by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="imageValue">The image value.</param>
        public void SaveData(string key, UIImage imageValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            CreateIfNotExist();

            NSData imageData = imageValue.AsPNG();
            string encodedImage = imageData.GetBase64EncodedData(NSDataBase64EncodingOptions.None).ToString();
            SaveData(key, encodedImage);
        }

        #endregion

        private void CreateIfNotExist()
        {
            if (_userDefaults != null)
            {
                return;
            }

            if (_localDbName == null)
            {
                Create();
            }
            else
            {
                Create(_localDbName);
            }
        }
    }
}
