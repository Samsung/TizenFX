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
	public class AlignedManifoldArrayDebugView
	{
		private readonly AlignedManifoldArray _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedManifoldArrayDebugView(AlignedManifoldArray array)
		{
			_array = array;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold[] Items
		{
			get
			{
				var array = new PersistentManifold[_array.Count];
				for (int i = 0; i < _array.Count; i++)
				{
					array[i] = _array[i];
				}
				return array;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedManifoldArrayEnumerator : IEnumerator<PersistentManifold>
	{
		private int _i;
		private readonly int _count;
		private readonly AlignedManifoldArray _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedManifoldArrayEnumerator(AlignedManifoldArray array)
		{
			_array = array;
			_count = array.Count;
			_i = -1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold Current => _array[_i];

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

	[Serializable, DebuggerTypeProxy(typeof(AlignedManifoldArrayDebugView)), DebuggerDisplay("Count = {Count}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedManifoldArray : BulletDisposableObject, IList<PersistentManifold>
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedManifoldArray()
		{
			IntPtr native = btAlignedObjectArray_btPersistentManifoldPtr_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(PersistentManifold item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Insert(int index, PersistentManifold item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold this[int index]
		{
			get
			{
				if ((uint)index >= (uint)Count)
				{
					throw new ArgumentOutOfRangeException(nameof(index));
				}
				return new PersistentManifold(btAlignedObjectArray_btPersistentManifoldPtr_at(Native, index), this);
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Add(PersistentManifold item)
		{
			btAlignedObjectArray_btPersistentManifoldPtr_push_back(Native, item.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clear()
		{
			btAlignedObjectArray_btPersistentManifoldPtr_resizeNoInitialize(Native, 0);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(PersistentManifold item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyTo(PersistentManifold[] array, int arrayIndex)
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
		public int Count => btAlignedObjectArray_btPersistentManifoldPtr_size(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsReadOnly => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Remove(PersistentManifold item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IEnumerator<PersistentManifold> GetEnumerator()
		{
			return new AlignedManifoldArrayEnumerator(this);
		}

		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return new AlignedManifoldArrayEnumerator(this);
		}

		protected override void Dispose(bool disposing)
		{
			btAlignedObjectArray_btPersistentManifoldPtr_delete(Native);
		}
	}
}
