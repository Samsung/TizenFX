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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DbvtNodePtrArrayEnumerator : IEnumerator<DbvtNode>
	{
		private int _i;
		private int _count;
		private IList<DbvtNode> _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNodePtrArrayEnumerator(IList<DbvtNode> array)
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
		public DbvtNode Current => _array[_i];

		object global::System.Collections.IEnumerator.Current => _array[_i];
	}

	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DbvtNodePtrArray : FixedSizeArray<DbvtNode>, IList<DbvtNode>
	{
		internal DbvtNodePtrArray(IntPtr native, int count)
			: base(native, count)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(DbvtNode item)
		{
			return btDbvtNodePtr_array_index_of(Native, item != null ? item.Native : IntPtr.Zero, Count);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode this[int index]
		{
			get
			{
				if ((uint)index >= (uint)Count)
				{
					throw new ArgumentOutOfRangeException(nameof(index));
				}
				IntPtr ptr = btDbvtNodePtr_array_at(Native, index);
				return (ptr != IntPtr.Zero) ? new DbvtNode(ptr) : null;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(DbvtNode item)
		{
			return IndexOf(item) != -1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyTo(DbvtNode[] array, int arrayIndex)
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
		public IEnumerator<DbvtNode> GetEnumerator()
		{
			return new DbvtNodePtrArrayEnumerator(this);
		}

		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return new DbvtNodePtrArrayEnumerator(this);
		}
	}
}
