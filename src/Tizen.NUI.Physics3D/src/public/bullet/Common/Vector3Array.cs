/*
 * Copyright (c) 2013-2022 Andres Traks
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from the use of this software.
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it freely,
 * subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
    internal class Vector3ListDebugView
    {
        private IList<global::System.Numerics.Vector3> _list;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3ListDebugView(IList<global::System.Numerics.Vector3> list)
        {
            _list = list;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3[] Items
        {
            get
            {
                var arr = new global::System.Numerics.Vector3[_list.Count];
                _list.CopyTo(arr, 0);
                return arr;
            }
        }
    };

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Vector3ArrayEnumerator : IEnumerator<global::System.Numerics.Vector3>
    {
        private int _i;
        private readonly int _count;
        private readonly IList<global::System.Numerics.Vector3> _array;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3ArrayEnumerator(IList<global::System.Numerics.Vector3> array)
        {
            _array = array;
            _count = array.Count;
            _i = -1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MoveNext()
        {
            _i++;
            return _i != _count;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reset()
        {
            _i = 0;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 Current => _array[_i];

        object global::System.Collections.IEnumerator.Current => _array[_i];
    }

    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy(typeof(Vector3ListDebugView))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Vector3Array : FixedSizeArray<global::System.Numerics.Vector3>, IList<global::System.Numerics.Vector3>
    {
        internal Vector3Array(IntPtr native, int count)
            : base(native, count)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndexOf(global::System.Numerics.Vector3 item)
        {
            for (int i = 0; i < Count; i++)
            {
                global::System.Numerics.Vector3 value;
                btVector3_array_at(Native, i, out value);
                if (value.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 this[int index]
        {
            get
            {
                if ((uint)index >= (uint)Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                global::System.Numerics.Vector3 value;
                btVector3_array_at(Native, index, out value);
                return value;
            }
            set
            {
                if ((uint)index >= (uint)Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                btVector3_array_set(Native, index, ref value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Contains(global::System.Numerics.Vector3 item)
        {
            return IndexOf(item) != -1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CopyTo(global::System.Numerics.Vector3[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(array));

            int count = Count;
            if (arrayIndex + count > array.Length)
                throw new ArgumentException("Array too small.", "array");

            for (int i = 0; i < count; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerator<global::System.Numerics.Vector3> GetEnumerator()
        {
            return new Vector3ArrayEnumerator(this);
        }

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
        {
            return new Vector3ArrayEnumerator(this);
        }
    }
}
