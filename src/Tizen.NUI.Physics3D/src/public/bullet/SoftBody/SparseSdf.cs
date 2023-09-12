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

namespace Tizen.NUI.Physics3D.Bullet.SoftBody
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SparseSdf : BulletObject
	{
		internal SparseSdf(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DefaultVoxelSize
		{
			get => btSparseSdf3_getDefaultVoxelsz(Native);
			set => btSparseSdf3_setDefaultVoxelsz(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GarbageCollect(int lifetime = 256)
		{
			btSparseSdf3_GarbageCollect(Native, lifetime);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Initialize(int hashSize = 2383, int clampCells = 256 * 1024)
		{
			btSparseSdf3_Initialize(Native, hashSize, clampCells);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RemoveReferences(CollisionShape pcs)
		{
			return btSparseSdf3_RemoveReferences(Native, (pcs != null) ? pcs.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Reset()
		{
			btSparseSdf3_Reset(Native);
		}
	}
}
