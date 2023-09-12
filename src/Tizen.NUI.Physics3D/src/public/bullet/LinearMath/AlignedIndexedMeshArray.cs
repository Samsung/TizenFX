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
	public class AlignedIndexedMeshArrayDebugView
	{
		private readonly AlignedIndexedMeshArray _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedIndexedMeshArrayDebugView(AlignedIndexedMeshArray array)
		{
			_array = array;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IndexedMesh[] Items
		{
			get
			{
				var array = new IndexedMesh[_array.Count];
				for (int i = 0; i < _array.Count; i++)
				{
					array[i] = _array[i];
				}
				return array;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedIndexedMeshArrayEnumerator : IEnumerator<IndexedMesh>
	{
		private int _i;
		private readonly int _count;
		private readonly AlignedIndexedMeshArray _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedIndexedMeshArrayEnumerator(AlignedIndexedMeshArray array)
		{
			_array = array;
			_count = array.Count;
			_i = -1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IndexedMesh Current => _array[_i];

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

	[Serializable, DebuggerTypeProxy(typeof(AlignedIndexedMeshArrayDebugView)), DebuggerDisplay("Count = {Count}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedIndexedMeshArray : BulletObject, IList<IndexedMesh>
	{
		private List<IndexedMesh> _backingList = new List<IndexedMesh>();
		private readonly TriangleIndexVertexArray _triangleIndexVertexArray;

		internal AlignedIndexedMeshArray(IntPtr native, TriangleIndexVertexArray triangleIndexVertexArray)
		{
			Initialize(native);
			_triangleIndexVertexArray = triangleIndexVertexArray;

			int count = btAlignedObjectArray_btIndexedMesh_size(Native);
			for (int i = 0; i < count; i++)
			{
				var mesh = new IndexedMesh(btAlignedObjectArray_btIndexedMesh_at(native, i), this);
				_backingList.Add(mesh);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(IndexedMesh item)
		{
			if (item == null)
			{
				return -1;
			}
			return _backingList.IndexOf(item);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Insert(int index, IndexedMesh item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IndexedMesh this[int index]
		{
			get => _backingList[index];
			set
			{
				throw new NotImplementedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Add(IndexedMesh item)
		{
			btTriangleIndexVertexArray_addIndexedMesh(_triangleIndexVertexArray.Native, item.Native, item.IndexType);
			_backingList.Add(item);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clear()
		{
			btAlignedObjectArray_btIndexedMesh_resizeNoInitialize(Native, 0);
			_backingList.Clear();

		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(IndexedMesh item)
		{
			return _backingList.Contains(item);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyTo(IndexedMesh[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array));

			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException(nameof(array));

			int count = Count;
			if (arrayIndex + count > array.Length)
				throw new ArgumentException("Array too small.", nameof(array));

			for (int i = 0; i < count; i++)
			{
				array[arrayIndex + i] = _backingList[i];
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Count => _backingList.Count;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsReadOnly => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Remove(IndexedMesh item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IEnumerator<IndexedMesh> GetEnumerator()
		{
			return _backingList.GetEnumerator();
		}

		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return _backingList.GetEnumerator();
		}
	}
}
