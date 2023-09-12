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

namespace Tizen.NUI.Physics3D.Bullet.SoftBody
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedJointArrayDebugView
	{
		private AlignedJointArray _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedJointArrayDebugView(AlignedJointArray array)
		{
			_array = array;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Joint[] Items
		{
			get
			{
				int count = _array.Count;
				var array = new Joint[count];
				for (int i = 0; i < count; i++)
				{
					array[i] = _array[i];
				}
				return array;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedJointArrayEnumerator : IEnumerator<Joint>
	{
		private int _i;
		private int _count;
		private AlignedJointArray _array;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedJointArrayEnumerator(AlignedJointArray array)
		{
			_array = array;
			_count = array.Count;
			_i = -1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Joint Current => _array[_i];

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

	[Serializable, DebuggerTypeProxy(typeof(AlignedJointArrayDebugView)), DebuggerDisplay("Count = {Count}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AlignedJointArray : BulletObject, IList<Joint>
	{
		internal AlignedJointArray(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(Joint item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Insert(int index, Joint item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Joint this[int index]
		{
			get
			{
				if ((uint)index >= (uint)Count)
				{
					throw new ArgumentOutOfRangeException(nameof(index));
				}
				return Joint.GetManaged(btAlignedObjectArray_btSoftBody_JointPtr_at(Native, index));
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Add(Joint item)
		{
			btAlignedObjectArray_btSoftBody_JointPtr_push_back(Native, item.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clear()
		{
			btAlignedObjectArray_btSoftBody_JointPtr_resizeNoInitialize(Native, 0);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(Joint item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyTo(Joint[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Count => btAlignedObjectArray_btSoftBody_JointPtr_size(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsReadOnly => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Remove(Joint item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IEnumerator<Joint> GetEnumerator()
		{
			return new AlignedJointArrayEnumerator(this);
		}

		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return new AlignedJointArrayEnumerator(this);
		}
	}
}
