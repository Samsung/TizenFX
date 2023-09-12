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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	internal class ListDebugView
	{
		private global::System.Collections.IEnumerable _list;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListDebugView(global::System.Collections.IEnumerable list)
		{
			_list = list;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Collections.ArrayList Items
		{
			get
			{
				var list = new global::System.Collections.ArrayList();
				foreach (var o in _list)
					list.Add(o);
				return list;
			}
		}
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CompoundShapeChildArrayEnumerator : IEnumerator<CompoundShapeChild>
	{
		private int _i;
		private int _count;
		private CompoundShapeChild[] _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CompoundShapeChildArrayEnumerator(CompoundShapeChildArray array)
		{
			_array = array._backingArray;
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
		public CompoundShapeChild Current => _array[_i];

		object global::System.Collections.IEnumerator.Current => _array[_i];
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UIntArrayEnumerator : IEnumerator<uint>
	{
		private int _i;
		private int _count;
		private  IList<uint> _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UIntArrayEnumerator(IList<uint> array)
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
		public uint Current => _array[_i];

		object global::System.Collections.IEnumerator.Current => _array[_i];
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CompoundShapeChildArray : FixedSizeArray<CompoundShapeChild>, IList<CompoundShapeChild>
	{
		internal CompoundShapeChild[] _backingArray = new CompoundShapeChild[0];

		internal CompoundShapeChildArray(IntPtr compoundShape)
			: base(compoundShape, 0)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddChildShape(ref Matrix4x4 localTransform, CollisionShape shape)
		{
			IntPtr childListOld = (Count != 0) ? btCompoundShape_getChildList(Native) : IntPtr.Zero;
			btCompoundShape_addChildShape(Native, ref localTransform, shape.Native);
			IntPtr childList = btCompoundShape_getChildList(Native);

			// Adjust the native pointer of existing children if the array was reallocated.
			if (childListOld != childList)
			{
				for (int i = 0; i < Count; i++)
				{
					_backingArray[i].Native = btCompoundShapeChild_array_at(childList, i);
				}
			}

			// Add the child to the backing store.
			int childIndex = Count;
			Count++;
			Array.Resize(ref _backingArray, Count);
			_backingArray[childIndex] = new CompoundShapeChild(btCompoundShapeChild_array_at(childList, childIndex), shape);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(CompoundShapeChild item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CompoundShapeChild this[int index]
		{
			get => _backingArray[index];
			set => throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(CompoundShapeChild item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyTo(CompoundShapeChild[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IEnumerator<CompoundShapeChild> GetEnumerator()
		{
			return new CompoundShapeChildArrayEnumerator(this);
		}

		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return new CompoundShapeChildArrayEnumerator(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveChildShape(CollisionShape shape)
		{
			IntPtr shapePtr = shape.Native;
			for (int i = 0; i < Count; i++)
			{
				if (_backingArray[i].ChildShape.Native == shapePtr)
				{
					RemoveChildShapeByIndex(i);
				}
			}
		}

		internal void RemoveChildShapeByIndex(int childShapeIndex)
		{
			btCompoundShape_removeChildShapeByIndex(Native, childShapeIndex);
			Count--;

			// Swap the last item with the item to be removed like Bullet does.
			if (childShapeIndex != Count)
			{
				CompoundShapeChild lastItem = _backingArray[Count];
				lastItem.Native = _backingArray[childShapeIndex].Native;
				_backingArray[childShapeIndex] = lastItem;
			}
			_backingArray[Count] = null;
		}
	}

	[DebuggerTypeProxy(typeof(ListDebugView))]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UIntArray : FixedSizeArray<uint>, IList<uint>
	{
		internal UIntArray(IntPtr native, int count)
			: base(native, count)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(uint item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint this[int index]
		{
			get
			{
				if ((uint)index >= (uint)Count)
				{
					throw new ArgumentOutOfRangeException(nameof(index));
				}
				return (uint)Marshal.ReadInt32(Native, index * sizeof(uint));
			}
			set
			{
				if ((uint)index >= (uint)Count)
				{
					throw new ArgumentOutOfRangeException(nameof(index));
				}
				Marshal.WriteInt32(Native, index * sizeof(uint), (int)value);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(uint item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyTo(uint[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IEnumerator<uint> GetEnumerator()
		{
			return new UIntArrayEnumerator(this);
		}

		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return new UIntArrayEnumerator(this);
		}
	}
}
