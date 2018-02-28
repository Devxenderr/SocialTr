using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LocalDB
{
    public abstract class ALocalDB : IDisposable
    {
        protected string _localDbName;

        /// <summary>
        /// Creates new unnamed local database.
        /// </summary>
        protected abstract void Create();

        /// <summary>
        /// Creates new unnamed local database.
        /// </summary>
        protected abstract void Create(string localDbName);

        /// <summary>
        /// Dispose the local database.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Deletes value by key local database.
        /// </summary>
        public abstract void Delete(string key);

        /// <summary>
        /// Saves string by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public abstract void SaveData(string key, string value);

        /// <summary>
        /// Saves int by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public abstract void SaveData(string key, int value);

        /// <summary>
        /// Saves long by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public abstract void SaveData(string key, long value);

        /// <summary>
        /// Saves float by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public abstract void SaveData(string key, float value);

        /// <summary>
        /// Saves double by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">The value.</param>
        public abstract void SaveData(string key, double value);

        /// <summary>
        /// Saves bool by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key (If the key invalid, value will not be saved).</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public abstract void SaveData(string key, bool value);

        /// <summary>
        /// Loads string by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>String by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public abstract string LoadData(string key, string defValue);

        /// <summary>
        /// Loads int by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Int by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public abstract int    LoadData(string key, int defValue);

        /// <summary>
        /// Loads long by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Long by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public abstract long   LoadData(string key, long defValue);

        /// <summary>
        /// Loads float by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Float by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public abstract float  LoadData(string key, float defValue);

        /// <summary>
        /// Loads double by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Double by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public abstract double LoadData(string key, double defValue);

        /// <summary>
        /// Loads bool by key (If database is not exist, it will be created).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>Bool by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public abstract bool LoadData(string key, bool defValue);

        /// <summary>
        /// Saves the object of custom class.
        /// </summary>
        /// <typeparam name="T">Custom class.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SaveObject<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            var json = JsonConvert.SerializeObject(value);
            SaveData(key, json);
        }

        /// <summary>
        /// Loads the object of custom class (Class must have JSON ctor).
        /// </summary>
        /// <typeparam name="T">Custom class (Class must have JSON ctor).</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>The custom class object by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public T LoadObject<T>(string key, T defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            string objString = LoadData(key, "");

            if (string.IsNullOrWhiteSpace(objString))
            {
                return defValue;
            }

            return JsonConvert.DeserializeObject<T>(objString);
        }


        /// <summary>
        /// Saves the objects of custom class.
        /// </summary>
        /// <typeparam name="T">Custom class.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SaveObject<T>(string key, IEnumerable<T> value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            string json = JsonConvert.SerializeObject(value);
            SaveData(key, json);
        }

        /// <summary>
        /// Loads the objects of custom class (Class must have JSON ctor).
        /// </summary>
        /// <typeparam name="T">Custom class (Class must have JSON ctor).</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="defValue">The default value.</param>
        /// <returns>The custom class object by key (If database is not exist, or there is not any value by this key, returns default value).</returns>
        public IEnumerable<T> LoadObject<T>(string key, IEnumerable<T> defValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return defValue;
            }

            string objString = LoadData(key, "");

            if (string.IsNullOrWhiteSpace(objString))
            {
                return defValue;
            }

            return JsonConvert.DeserializeObject<IEnumerable<T>>(objString);
        }
    }
}
