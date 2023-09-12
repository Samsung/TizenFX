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
using System.Numerics;
using System.ComponentModel;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Box2DShape : PolyhedralConvexShape
	{
		private Vector3Array _normals;
		private Vector3Array _vertices;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Box2DShape(global::System.Numerics.Vector3 boxHalfExtents)
		{
			IntPtr native = btBox2dShape_new(ref boxHalfExtents);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Box2DShape(float boxHalfExtent)
		{
			IntPtr native = btBox2dShape_new2(boxHalfExtent);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Box2DShape(float boxHalfExtentX, float boxHalfExtentY, float boxHalfExtentZ)
		{
			IntPtr native = btBox2dShape_new3(boxHalfExtentX, boxHalfExtentY, boxHalfExtentZ);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetPlaneEquation(out global::System.Numerics.Vector4 plane, int i)
		{
			btBox2dShape_getPlaneEquation(Native, out plane, i);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Centroid
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btBox2dShape_getCentroid(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HalfExtentsWithMargin
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btBox2dShape_getHalfExtentsWithMargin(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HalfExtentsWithoutMargin
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btBox2dShape_getHalfExtentsWithoutMargin(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array Normals
		{
			get
			{
				if (_normals == null)
				{
					_normals = new Vector3Array(btBox2dShape_getNormals(Native), 4);
				}
				return _normals;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array Vertices
		{
			get
			{
				if (_vertices == null)
				{
					_vertices = new Vector3Array(btBox2dShape_getVertices(Native), 4);
				}
				return _vertices;
			}
		}
	}
}
