using LocalDB;
using Android.Content;
using Android.Preferences;
using Android.Graphics;
using System;
using System.IO;

namespace LocalDBDroid
{
    public class LocalDb : ALocalDB
    {
        private ISharedPreferences _preferences;
        private Context _context;

        /// <summary>
        /// Initializes a new unnamed local database.
        /// </summary>
        /// <param name="context">The context of SharedPreferences.</param>
        public LocalDb(Context context)
        {
            _context = context;
            Create();
        }

        /// <summary>
        /// Initializes a new local database with a specified name.
        /// </summary>
        /// <param name="context">The context of SharedPreferences.</param>
        /// <param name="dbName">Name of the database.</param>
        public LocalDb(Context context, string dbName)
        {
            if (string.IsNullOrWhiteSpace(dbName))
            {
                return;
            }

            _context = context;

            Create(dbName);
        }

        protected override void Create(string localDbName)
        {
            _localDbName = localDbName;
            _preferences = _context.GetSharedPreferences(_localDbName, FileCreationMode.Private);
        }
        
        protected override void Create()
        {
            _preferences = PreferenceManager.GetDefaultSharedPreferences(_context);
        }
        
        /// <summary>
        /// Dispose the local database.
        /// </summary>
        public override void Dispose()
        {
            _preferences = null;
            
        }

        /// <summary>
        /// Deletes local database.
        /// </summary>
        public void Delete()
        {
            ISharedPreferencesEditor editor = _preferences.Edit();
            editor.Clear();
            editor.Commit();
            Dispose();
        }

        /// <summary>
        /// Deletes value by key local database.
        /// </summary>
        public override void Delete(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            ISharedPreferencesEditor editor = _preferences.Edit();
            editor.Remove(key);
            editor.Apply();
            Dispose();
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

            if (_preferences == null)
            {
                CreateIfNotExist();
            }

            return _preferences.GetString(key, defValue);
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

            if (_preferences == null)
            {
                CreateIfNotExist();
            }

            return _preferences.GetInt(key, defValue);
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

            if (_preferences == null)
            {
                CreateIfNotExist();
            }

            return _preferences.GetLong(key, defValue);
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

            if (_preferences == null)
            {
                CreateIfNotExist();
            }

            return _preferences.GetFloat(key, defValue);
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

            if (_preferences == null)
            {
                CreateIfNotExist();
            }

            return _preferences.GetFloat(key, (float)defValue);
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

            if (_preferences == null)
            {
                CreateIfNotExist();
            }

            return _preferences.GetBoolean(key, defValue);
        }

        /// <summary>
        /// Loads Android.Graphics.Color by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The definition value.</param>
        /// <returns>Android.Graphics.Color by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public Color LoadData(string key, Color defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            CreateIfNotExist();

            string hexaString = LoadData(key, "");

            if (hexaString == null || hexaString == "")
            {
                return defValue;
            }

            return Color.ParseColor(hexaString);
        }

        /// <summary>
        /// Loads Android.Graphics.Bitmap by key ((If database is not exist, it will be created)(If there is no value by this key, returns default value)).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The definition value.</param>
        /// <returns>Android.Graphics.Bitmap by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public Bitmap LoadData(string key, Bitmap defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            CreateIfNotExist();

            string baseString = LoadData(key, "");

            if (baseString == null || baseString == "")
            {
                return defValue;
            }

            byte[] data = Convert.FromBase64String(baseString);
            Bitmap bitmap = BitmapFactory.DecodeByteArray(data, 0, data.Length);

            return bitmap;
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

            ISharedPreferencesEditor editor = _preferences.Edit();
            editor.PutString(key, value);
            editor.Apply();
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

            ISharedPreferencesEditor editor = _preferences.Edit();
            editor.PutInt(key, value);
            editor.Apply();
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

            ISharedPreferencesEditor editor = _preferences.Edit();
            editor.PutLong(key, value);
            editor.Apply();
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

            ISharedPreferencesEditor editor = _preferences.Edit();
            editor.PutFloat(key, value);
            editor.Apply();
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

            ISharedPreferencesEditor editor = _preferences.Edit();
            editor.PutFloat(key, (float)value);
            editor.Apply();
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

            ISharedPreferencesEditor editor = _preferences.Edit();
            editor.PutBoolean(key, value);
            editor.Apply();
        }

        /// <summary>
        /// Saves Android.Graphics.Color by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="colorValue">The color value.</param>
        public void SaveData(string key, Color colorValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            string hexaString = "#" + colorValue.R.ToString("X2") + colorValue.G.ToString("X2") + colorValue.B.ToString("X2");
            SaveData(key, hexaString);
        }

        /// <summary>
        /// Saves Android.Graphics.Bitmap by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="imageValue">The image value.</param>
        public void SaveData(string key, Bitmap imageValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            MemoryStream stream = new MemoryStream();
            imageValue.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            byte[] data = stream.ToArray();
            string baseString = Convert.ToBase64String(data);

            SaveData(key, baseString);
        }
        #endregion

        private void CreateIfNotExist()
        {
            if (_preferences != null)
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
