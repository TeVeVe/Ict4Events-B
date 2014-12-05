using System.Collections.Generic;

namespace SharedClasses.Extensions
{
    public static class DictionaryExtensions
    {
        public static T SafeGetValue<TKey, TValue, T>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            if (!dictionary.ContainsKey(key))
                return default(T);

            return (T)(object)dictionary[key];
        }

        public static T SafeGetValue<T>(this Dictionary<string, object> dictionary, string key)
        {
            return dictionary.SafeGetValue<string, object, T>(key);
        }
    }
}