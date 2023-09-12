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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet.SoftBody
{
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class BodyArray : FixedSizeArray<Body>, IList<Body>
	{
		internal BodyArray(IntPtr native, int count)
			: base(native, count)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Body this[int index]
		{
			get
			{
				if ((uint)index >= (uint)Count)
				{
					throw new ArgumentOutOfRangeException(nameof(index));
				}
				IntPtr ptr = btSoftBody_Body_array_at(Native, index);
				return new Body(ptr, this);
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contains(Body item)
		{
			return IndexOf(item) != -1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyTo(Body[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexOf(Body item)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IEnumerator<Body> GetEnumerator()
		{
			return new GenericListEnumerator<Body>(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new GenericListEnumerator<Body>(this);
		}
	}
}
