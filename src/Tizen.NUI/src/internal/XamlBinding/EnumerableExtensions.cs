/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> GetGesturesFor<T>(this IEnumerable<IGestureRecognizer> gestures, Func<T, bool> predicate = null) where T : GestureRecognizer
        {
            if (gestures == null)
                yield break;

            if (predicate == null)
                predicate = x => true;

            foreach (IGestureRecognizer item in gestures)
            {
                var gesture = item as T;
                if (gesture != null && predicate(gesture))
                {
                    yield return gesture;
                }
            }
        }

        internal static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, T item)
        {
            foreach (T x in enumerable)
                yield return x;

            yield return item;
        }

        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        public static int IndexOf<T>(this IEnumerable<T> enumerable, T item)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            var i = 0;
            foreach (T element in enumerable)
            {
                if (Equals(element, item))
                    return i;

                i++;
            }

            return -1;
        }

        public static int IndexOf<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            var i = 0;
            foreach (T element in enumerable)
            {
                if (predicate(element))
                    return i;

                i++;
            }

            return -1;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> enumerable, T item)
        {
            yield return item;

            foreach (T x in enumerable)
                yield return x;
        }
    }
}
