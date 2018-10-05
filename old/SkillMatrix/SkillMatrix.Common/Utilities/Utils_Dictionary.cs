using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SkillMatrix.Common
{
    public partial class Utilities
    {
        //cannot do IDictionary because can hide ConcurrentDictionary
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory = null)
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
            {
                return value;
            }
            if (factory == null) factory = key1 => Activator.CreateInstance<TValue>();
            return dictionary[key] = factory(key);
        }

        //cannot do IDictionary because can hide ConcurrentDictionary
        public static void TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory = null)
            
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
            {
                return;
            }
            if (factory == null) factory = key1 => Activator.CreateInstance<TValue>();
            dictionary[key] = factory(key);
        }

        //cannot do IDictionary because can hide ConcurrentDictionary
        public static void TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue valueToAdd)
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
            {
                return;
            }
            dictionary[key] = valueToAdd;
        }


        /// <summary>
        /// Returns object if found in dictionary or default(TValue)
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue TryGet<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
            {
                return value;
            }
            return default(TValue);
        }

        /// <summary>
        /// Returns object if found in dictionary or null value
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object TryGet(this IDictionary dictionary, object key)
        {
            if (dictionary.Contains(key))
            {
                return dictionary[key];
            }
            return null;
        }


        public static Dictionary<TKey, TSource> ToDictionarySafe<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return ToDictionarySafe<TSource, TKey, TSource>(source, keySelector, IdentityFunction<TSource>.Instance, null);
        }

        public static Dictionary<TKey, TSource> ToDictionarySafe<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return ToDictionarySafe<TSource, TKey, TSource>(source, keySelector, IdentityFunction<TSource>.Instance, comparer);
        }

        public static Dictionary<TKey, TElement> ToDictionarySafe<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return ToDictionarySafe<TSource, TKey, TElement>(source, keySelector, elementSelector, null);
        }

        public static Dictionary<TKey, TElement> ToDictionarySafe<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (keySelector == null) throw new ArgumentNullException("keySelector");
            if (elementSelector == null) throw new ArgumentNullException("elementSelector");
            var d = new Dictionary<TKey, TElement>(comparer);
            foreach (TSource element in source) d[keySelector(element)] =  elementSelector(element);
            return d;
        }

        public static IDictionary<string, object> ToDictionary(this object o)
        {
            if (o is IDictionary<string, object>) return (IDictionary<string, object>)o;

            Type type = o.GetType();
            return type.GetProperties()
                .Select(n => n.Name)
                .ToDictionary(k => k, k => type.GetProperty(k).GetValue(o, null));
        }
        
        internal class IdentityFunction<TElement>
        {
            public static Func<TElement, TElement> Instance
            {
                get { return x => x; }
            }
        }


    }
}