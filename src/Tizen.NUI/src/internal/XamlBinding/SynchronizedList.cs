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

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tizen.NUI.Binding
{
    internal class SynchronizedList<T> : IList<T>, IReadOnlyList<T>
    {
        readonly List<T> list = new List<T>();
        ReadOnlyCollection<T> snapshot;

        public void Add(T item)
        {
            lock (list)
            {
                list.Add(item);
                snapshot = null;
            }
        }

        public void Clear()
        {
            lock (list)
            {
                list.Clear();
                snapshot = null;
            }
        }

        public bool Contains(T item)
        {
            lock (list)
                return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (list)
                list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                lock (list)
                    return list.Count;
            }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            lock (list)
            {
                if (list.Remove(item))
                {
                    snapshot = null;
                    return true;
                }

                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (list)
            {
                if (snapshot == null)
                {
                    snapshot = new ReadOnlyCollection<T>(list.ToList());
                }
                return snapshot.GetEnumerator();
            }
        }

        public int IndexOf(T item)
        {
            lock (list)
                return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            lock (list)
            {
                list.Insert(index, item);
                snapshot = null;
            }
        }

        public T this[int index]
        {
            get
            {
                lock (list)
                {
                    ReadOnlyCollection<T> snap = snapshot;
                    if (snap != null)
                        return snap[index];

                    return list[index];
                }
            }

            set
            {
                lock (list)
                {
                    list[index] = value;
                    snapshot = null;
                }
            }
        }

        public void RemoveAt(int index)
        {
            lock (list)
            {
                list.RemoveAt(index);
                snapshot = null;
            }
        }
    }
}
