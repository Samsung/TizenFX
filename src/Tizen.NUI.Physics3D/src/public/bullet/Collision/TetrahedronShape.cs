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
	public class BuSimplex1To4 : PolyhedralConvexAabbCachingShape
	{
		internal BuSimplex1To4(ConstructionInfo info)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BuSimplex1To4()
		{
			IntPtr native = btBU_Simplex1to4_new();
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BuSimplex1To4(global::System.Numerics.Vector3 pt0)
		{
			IntPtr native = btBU_Simplex1to4_new2(ref pt0);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BuSimplex1To4(global::System.Numerics.Vector3 pt0, global::System.Numerics.Vector3 pt1)
		{
			IntPtr native = btBU_Simplex1to4_new3(ref pt0, ref pt1);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BuSimplex1To4(global::System.Numerics.Vector3 pt0, global::System.Numerics.Vector3 pt1, global::System.Numerics.Vector3 pt2)
		{
			IntPtr native = btBU_Simplex1to4_new4(ref pt0, ref pt1, ref pt2);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BuSimplex1To4(global::System.Numerics.Vector3 pt0, global::System.Numerics.Vector3 pt1, global::System.Numerics.Vector3 pt2, global::System.Numerics.Vector3 pt3)
		{
			IntPtr native = btBU_Simplex1to4_new5(ref pt0, ref pt1, ref pt2, ref pt3);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddVertexRef(ref global::System.Numerics.Vector3 pt)
		{
			btBU_Simplex1to4_addVertex(Native, ref pt);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddVertex(global::System.Numerics.Vector3 pt)
		{
			btBU_Simplex1to4_addVertex(Native, ref pt);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetIndex(int i)
		{
			return btBU_Simplex1to4_getIndex(Native, i);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Reset()
		{
			btBU_Simplex1to4_reset(Native);
		}
	}
}
