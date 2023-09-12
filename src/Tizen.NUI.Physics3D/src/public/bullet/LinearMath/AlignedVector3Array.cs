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
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(Vector3ListDebugView))]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedVector3Array : BulletObject, IList<global::System.Numerics.Vector3>
	{
		internal AlignedVector3Array(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(global::System.Numerics.Vector3 item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Insert(int index, global::System.Numerics.Vector3 item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
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
				btAlignedObjectArray_btVector3_at(Native, index, out value);
				return value;
			}
			set
			{
				if ((uint)index >= (uint)Count)
				{
					throw new ArgumentOutOfRangeException(nameof(index));
				}
				btAlignedObjectArray_btVector3_set(Native, index, ref value);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Add(global::System.Numerics.Vector3 item)
		{
			btAlignedObjectArray_btVector3_push_back(Native, ref item);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clear()
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(global::System.Numerics.Vector3 item)
		{
			throw new NotImplementedException();
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
		public int Count => btAlignedObjectArray_btVector3_size(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsReadOnly => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Remove(global::System.Numerics.Vector3 item)
		{
			throw new NotImplementedException();
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
