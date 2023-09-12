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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PoolAllocator : BulletDisposableObject
	{
		internal PoolAllocator(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PoolAllocator(int elemSize, int maxElements)
		{
			IntPtr native = btPoolAllocator_new(elemSize, maxElements);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Allocate(int size)
		{
			return btPoolAllocator_allocate(Native, size);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void FreeMemory(IntPtr ptr)
		{
			btPoolAllocator_freeMemory(Native, ptr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ValidPtr(IntPtr ptr)
		{
			return btPoolAllocator_validPtr(Native, ptr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ElementSize => btPoolAllocator_getElementSize(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FreeCount => btPoolAllocator_getFreeCount(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MaxCount => btPoolAllocator_getMaxCount(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr PoolAddress => btPoolAllocator_getPoolAddress(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UsedCount => btPoolAllocator_getUsedCount(Native);

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btPoolAllocator_delete(Native);
			}
		}
	}
}
