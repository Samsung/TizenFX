/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Represents a collection of <see cref="ImageTransform"/> objects that can be individually accessed by index.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ImageTransformCollection : IEnumerable<ImageTransform>, IList<ImageTransform>
    {
        private List<ImageTransform> _list = new List<ImageTransform>();

        /// <summary>
        /// Initializes a new instance of the ImageTransformCollection class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ImageTransformCollection()
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="ImageTransform"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the <see cref="ImageTransform"/> to get or set.</param>
        /// <value>The <see cref="ImageTransform"/> at the specified index.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than 0.<br/>
        ///     -or-<br/>
        ///     index is equal to or greater than <see cref="Count"/>.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public ImageTransform this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        /// <summary>
        /// Gets the number of items contained in the TransformCollection.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Count => _list.Count;

        bool ICollection<ImageTransform>.IsReadOnly => false;

        /// <summary>
        /// Adds a <see cref="ImageTransform"/> to the end of the collection.
        /// </summary>
        /// <param name="item">The <see cref="ImageTransform"/> to add.</param>
        /// <remarks>
        /// <see cref="ImageTransformCollection"/> accepts null as a valid value for reference types and allows duplicate elements.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public void Add(ImageTransform item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _list.Add(item);
        }

        /// <summary>
        /// Removes all items.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Clear() => _list.Clear();

        /// <summary>
        /// Determines whether the <see cref="ImageTransformCollection"/> contains the specified item.
        /// </summary>
        /// <param name="item">The <see cref="ImageTransform"/> to locate in the collection.</param>
        /// <returns>true if the <see cref="ImageTransform"/> is found in the collection; otherwise, false.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool Contains(ImageTransform item) => _list.Contains(item);

        /// <summary>
        /// Copies the items of the collection to an array, starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the items copied from the collection.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception>
        /// <exception cref="ArgumentException">
        /// The number of elements in the source collection is greater than the available space from arrayIndex to the end of the destination array.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public void CopyTo(ImageTransform[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        /// <summary>
        /// Determines the index of the specified item in the collection.
        /// </summary>
        /// <param name="item">The <see cref="ImageTransform"/> to locate in the collection.</param>
        /// <returns>The index of value if found in the <see cref="ImageTransformCollection"/>; otherwise, -1.</returns>
        /// <since_tizen> 4 </since_tizen>
        public int IndexOf(ImageTransform item) => _list.IndexOf(item);

        /// <summary>
        /// Inserts a <see cref="ImageTransform"/> into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The <see cref="ImageTransform"/> to insert into the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than 0.<br/>
        ///     -or-<br/>
        ///     index is greater than <see cref="Count"/>.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public void Insert(int index, ImageTransform item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _list.Insert(index, item);
        }

        /// <summary>
        /// Removes the first occurrence of the specified <see cref="ImageTransform"/> from the collection.
        /// </summary>
        /// <param name="item">The <see cref="ImageTransform"/> to remove.</param>
        /// <returns>true if <paramref name="item"/> was removed from the collection; otherwise, false.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool Remove(ImageTransform item) => _list.Remove(item);

        /// <summary>
        /// Removes the <see cref="ImageTransform"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than 0.<br/>
        ///     -or-<br/>
        ///     index is equal to or greater than <see cref="Count"/>.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public void RemoveAt(int index) => _list.RemoveAt(index);

        /// <summary>
        /// Returns an enumerator that can iterate through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        /// <since_tizen> 4 </since_tizen>
        public IEnumerator<ImageTransform> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}
