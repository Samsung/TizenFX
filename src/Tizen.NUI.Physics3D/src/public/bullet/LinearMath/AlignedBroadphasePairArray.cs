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
	public class AlignedBroadphasePairArrayDebugView
	{
		private readonly AlignedBroadphasePairArray _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedBroadphasePairArrayDebugView(AlignedBroadphasePairArray array)
		{
			_array = array;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphasePair[] Items
		{
			get
			{
				var array = new BroadphasePair[_array.Count];
				for (int i = 0; i < _array.Count; i++)
				{
					array[i] = _array[i];
				}
				return array;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedBroadphasePairArrayEnumerator : IEnumerator<BroadphasePair>
	{
		private int _i = -1;
		private readonly int _count;
		private readonly AlignedBroadphasePairArray _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedBroadphasePairArrayEnumerator(AlignedBroadphasePairArray array)
		{
			_array = array;
			_count = array.Count;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphasePair Current => _array[_i];

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
		}

		object global::System.Collections.IEnumerator.Current => _array[_i];

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
	}

	[Serializable, DebuggerTypeProxy(typeof(AlignedBroadphasePairArrayDebugView)), DebuggerDisplay("Count = {Count}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedBroadphasePairArray : IList<BroadphasePair>
	{
		internal IntPtr Native;

		internal AlignedBroadphasePairArray(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(BroadphasePair item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Insert(int index, BroadphasePair item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphasePair this[int index]
		{
			get
			{
				if ((uint)index >= (uint)Count)
				{
					throw new ArgumentOutOfRangeException(nameof(index));
				}
				return new BroadphasePair(btAlignedObjectArray_btBroadphasePair_at(Native, index));
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Add(BroadphasePair item)
		{
			btAlignedObjectArray_btBroadphasePair_push_back(Native, item.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clear()
		{
			btAlignedObjectArray_btBroadphasePair_resizeNoInitialize(Native, 0);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(BroadphasePair item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyTo(BroadphasePair[] array, int arrayIndex)
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
		public int Count => btAlignedObjectArray_btBroadphasePair_size(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsReadOnly => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Remove(BroadphasePair item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IEnumerator<BroadphasePair> GetEnumerator()
		{
			return new AlignedBroadphasePairArrayEnumerator(this);
		}

		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return new AlignedBroadphasePairArrayEnumerator(this);
		}
	}
}
