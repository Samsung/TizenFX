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
	public class TriangleShape : PolyhedralConvexShape
	{
		private Vector3Array _vertices;

		internal TriangleShape(ConstructionInfo info)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleShape()
		{
			IntPtr native = btTriangleShape_new();
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleShape(global::System.Numerics.Vector3 p0, global::System.Numerics.Vector3 p1, global::System.Numerics.Vector3 p2)
		{
			IntPtr native = btTriangleShape_new2(ref p0, ref p1, ref p2);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalcNormal(out global::System.Numerics.Vector3 normal)
		{
			btTriangleShape_calcNormal(Native, out normal);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetPlaneEquation(int i, out global::System.Numerics.Vector3 planeNormal, out global::System.Numerics.Vector3 planeSupport)
		{
			btTriangleShape_getPlaneEquation(Native, i, out planeNormal, out planeSupport);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr GetVertexPtr(int index)
		{
			return btTriangleShape_getVertexPtr(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array Vertices
		{
			get
			{
				if (_vertices == null)
				{
					_vertices = new Vector3Array(btTriangleShape_getVertices1(Native), 3);
				}
				return _vertices;
			}
		}
	}
}
