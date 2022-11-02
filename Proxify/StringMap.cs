using System;
using System.Collections.Generic;

namespace CustomCollection.Tests
{
    // Do not change the name of this class
    public class StringMap<TValue> : IStringMap<TValue>
        where TValue: class
    {

        /// <summary> Returns number of elements in a map</summary>
        public int Count => _map.Count;

        /// <summary>
        /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
        /// </summary>
        // Do not change this property
        public TValue DefaultValue { get; set; }


        public StringMap()
        {
            _map = new Dictionary<string, TValue>();
        }
        
        /// <summary>
        /// Adds a given key and value to a map.
        /// If the given key already exists in a map, then the value associated with this key should be overriden.
        /// </summary>
        /// <returns>true if the value for the key was overriden otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        /// <exception cref="System.ArgumentNullException">If the value is null</exception>
        public bool AddElement(string key, TValue value)
        {
            Console.WriteLine($"key: {key} value: {value.ToString()}");
            if (key == null)
                throw new ArgumentNullException( nameof(key), "The key cannot be null");

            if (key == String.Empty)
                throw new ArgumentException("The key cannot be an empty string", nameof(key));

            if (value == null)
                throw new ArgumentException("The value cannot be null", nameof(value));
            
            if (_map.ContainsKey(key))
            {
                _map.Remove(key);
                _map.Add(key, value);
                return true;
            }
            _map.Add(key, value);
            return false;
        }

        /// <summary>
        /// Removes a given key and associated value from a map.
        /// </summary>
        /// <returns>true if the key was in the map and was removed otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        public bool RemoveElement(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The key cannot be null");

            if (key == String.Empty)
                throw new ArgumentException("The cannot be empty", nameof(key));
            
            
            if (_map.ContainsKey(key))
            {
                _map.Remove(key);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the value associated with a given key.
        /// </summary>
        /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
        /// <exception cref="System.ArgumentNullException">If a key is null</exception>
        /// <exception cref="System.ArgumentException">If a key is an empty string</exception>
        public TValue GetValue(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The key cannot be null");

            if (key == String.Empty)
                throw new ArgumentException("The cannot be empty", nameof(key));
            
            if (_map.ContainsKey(key))
            {
                return _map[key];
            }

            return DefaultValue;
        }

        private readonly Dictionary<string, TValue> _map;
    }
}
