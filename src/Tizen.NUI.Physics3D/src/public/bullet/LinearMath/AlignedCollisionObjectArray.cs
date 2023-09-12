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
	public class AlignedCollisionObjectArrayDebugView
	{
		private readonly AlignedCollisionObjectArray _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedCollisionObjectArrayDebugView(AlignedCollisionObjectArray array)
		{
			_array = array;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject[] Items
		{
			get
			{
				var array = new CollisionObject[_array.Count];
				for (int i = 0; i < _array.Count; i++)
				{
					array[i] = _array[i];
				}
				return array;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedCollisionObjectArrayEnumerator : IEnumerator<CollisionObject>
	{
		private int _i = -1;
		private readonly int _count;
		private readonly IList<CollisionObject> _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedCollisionObjectArrayEnumerator(IList<CollisionObject> array)
		{
			_array = array;
			_count = array.Count;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject Current => _array[_i];

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

	[Serializable, DebuggerTypeProxy(typeof(AlignedCollisionObjectArrayDebugView)), DebuggerDisplay("Count = {Count}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedCollisionObjectArray : BulletObject, IList<CollisionObject>
	{
		private CollisionWorld _collisionWorld;
		private List<CollisionObject> _backingList;

		internal AlignedCollisionObjectArray(IntPtr native)
		{
			Initialize(native);
		}

		internal AlignedCollisionObjectArray(IntPtr native, CollisionWorld collisionWorld)
		{
			Initialize(native);
			if (collisionWorld != null)
			{
				_collisionWorld = collisionWorld;
				_backingList = new List<CollisionObject>();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Add(CollisionObject item)
		{
			if (_collisionWorld != null)
			{
				if (item is RigidBody)
				{
					if (item.CollisionShape == null)
					{
						return;
					}
					btDynamicsWorld_addRigidBody(_collisionWorld.Native, item.Native);
				}
				else if (item is SoftBody.SoftBody)
				{
					btSoftRigidDynamicsWorld_addSoftBody(_collisionWorld.Native, item.Native);
				}
				else
				{
					btCollisionWorld_addCollisionObject(_collisionWorld.Native, item.Native);
				}
				SetBodyBroadphaseHandle(item, _collisionWorld.Broadphase);
				_backingList.Add(item);
			}
			else
			{
				btAlignedObjectArray_btCollisionObjectPtr_push_back(Native, item.Native);
			}
		}

		internal void Add(CollisionObject item, int group, int mask)
		{
			if (item is RigidBody)
			{
				if (item.CollisionShape == null)
				{
					return;
				}
				btDynamicsWorld_addRigidBody2(_collisionWorld.Native, item.Native, group, mask);
			}
			else if (item is SoftBody.SoftBody)
			{
				if (_collisionWorld is SoftBody.DeformableMultiBodyDynamicsWorld)
				{
					btDeformableMultiBodyDynamicsWorld_addSoftBody(_collisionWorld.Native, item.Native, group, mask);
				}
				else
				{
					btSoftRigidDynamicsWorld_addSoftBody3(_collisionWorld.Native, item.Native, group, mask);
				}
			}
			else
			{
				btCollisionWorld_addCollisionObject3(_collisionWorld.Native, item.Native, group, mask);
			}
			SetBodyBroadphaseHandle(item, _collisionWorld.Broadphase);
			_backingList.Add(item);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clear()
		{
			for (int i = Count - 1; i >= 0; i--)
			{
				RemoveAt(i);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(CollisionObject item)
		{
			return IndexOf(item) != -1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyTo(CollisionObject[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array));

			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException(nameof(array));

			int count = Count;
			if (arrayIndex + count > array.Length)
				throw new ArgumentException("Array too small.", "array");

			int i;
			for (i = 0; i < count; i++)
			{
				array[arrayIndex + i] = this[i];
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(CollisionObject item)
		{
			if (item == null)
			{
				return -1;
			}
			return btAlignedObjectArray_btCollisionObjectPtr_findLinearSearch2(Native, item.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Insert(int index, CollisionObject item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Remove(CollisionObject item)
		{
			int index = IndexOf(item);
			if (index == -1)
			{
				return false;
			}

			RemoveAt(index);
			return true;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveAt(int index)
		{
			if (_backingList == null)
			{
				throw new NotImplementedException();
				//btAlignedObjectArray_btCollisionObjectPtr_remove(itemPtr);
			}

			CollisionObject item = this[index];
			IntPtr itemPtr = item.Native;

			if (item is SoftBody.SoftBody)
			{
				btSoftRigidDynamicsWorld_removeSoftBody(_collisionWorld.Native, itemPtr);
			}
			else if (item is RigidBody)
			{
				btDynamicsWorld_removeRigidBody(_collisionWorld.Native, itemPtr);
			}
			else
			{
				btCollisionWorld_removeCollisionObject(_collisionWorld.Native, itemPtr);
			}
			item.BroadphaseHandle = null;

			// Swap the last item with the item to be removed like Bullet does.
			int count = _backingList.Count - 1;
			if (index != count)
			{
				_backingList[index] = _backingList[count];
			}
			_backingList.RemoveAt(count);
		}

		private void SetBodyBroadphaseHandle(CollisionObject item, BroadphaseInterface broadphase)
		{
			IntPtr broadphaseHandle = btCollisionObject_getBroadphaseHandle(item.Native);
			if (broadphase is DbvtBroadphase)
			{
				item.BroadphaseHandle = new DbvtProxy(broadphaseHandle);
			}
			// TODO: implement AxisSweep3::Handle
			/*
			else if (broadphase is AxisSweep3)
			{
				item.BroadphaseHandle = new AxisSweep3::Handle(broadphaseHandle);
			}
			else if (broadphase is AxisSweep3_32Bit)
			{
				item.BroadphaseHandle = new AxisSweep3_32Bit::Handle(broadphaseHandle);
			}
			*/
			else
			{
				item.BroadphaseHandle = new BroadphaseProxy(broadphaseHandle);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IEnumerator<CollisionObject> GetEnumerator()
		{
			if (_backingList != null)
			{
				return _backingList.GetEnumerator();
			}
			else
			{
				return new AlignedCollisionObjectArrayEnumerator(this);
			}
		}

		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			if (_backingList != null)
			{
				return _backingList.GetEnumerator();
			}
			else
			{
				return new AlignedCollisionObjectArrayEnumerator(this);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject this[int index]
		{
			get
			{
				if (_backingList != null)
				{
					return _backingList[index];
				}
				if ((uint)index >= (uint)Count)
				{
					throw new ArgumentOutOfRangeException(nameof(index));
				}
				return CollisionObject.GetManaged(btAlignedObjectArray_btCollisionObjectPtr_at(Native, index));
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Count => btAlignedObjectArray_btCollisionObjectPtr_size(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsReadOnly => false;
	}
}
