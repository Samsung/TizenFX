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

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class FixedSizeArray<T> : BulletObject
	{
		protected internal FixedSizeArray(IntPtr native, int count)
		{
			Initialize(native);
			Count = count;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Count { get; protected set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsReadOnly => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Add(T item)
		{
			throw new NotSupportedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clear()
		{
			throw new NotSupportedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Remove(T item)
		{
			throw new NotSupportedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveAt(int index)
		{
			throw new NotSupportedException();
		}
	}
}
