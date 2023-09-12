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
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PolarDecomposition : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public PolarDecomposition(float tolerance = 0.0001f, int maxIterations = 16)
		{
			IntPtr native = btPolarDecomposition_new(tolerance, (uint)maxIterations);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint Decompose(ref Matrix4x4 a, out Matrix4x4 u, out Matrix4x4 h)
		{
			return btPolarDecomposition_decompose(Native, ref a, out u, out h);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint MaxIterations()
		{
			return btPolarDecomposition_maxIterations(Native);
		}

		protected override void Dispose(bool disposing)
		{
			btPolarDecomposition_delete(Native);
		}
	}
}
