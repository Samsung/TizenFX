using System.Collections.Generic;

namespace Tizen.NUI.Xaml
{
    internal static class IDictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> collection)
        {
            foreach (var kvp in collection)
                dictionary.Add(kvp);
        }
    }
}