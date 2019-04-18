using System.Collections.Generic;

namespace app_datumation.Extensions
{
    public static class DictionaryExtenstions
    {
        public static KeyValuePair<TKey, TValue>? Find<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
        {
            TValue value;
            return source.TryGetValue(key, out value) ? new KeyValuePair<TKey, TValue>(key, value) : (KeyValuePair<TKey, TValue>?)null;
        }
    }
}