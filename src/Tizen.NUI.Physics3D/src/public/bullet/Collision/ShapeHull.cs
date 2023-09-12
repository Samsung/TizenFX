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
	public class ShapeHull : BulletDisposableObject
	{
		private readonly ConvexShape _shape;
		private UIntArray _indices;
		private Vector3Array _vertices;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ShapeHull(ConvexShape shape)
		{
			IntPtr native = btShapeHull_new(shape.Native);
			InitializeUserOwned(native);
			_shape = shape;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool BuildHull(float margin, int highRes = 0)
		{
			return btShapeHull_buildHull(Native, margin, highRes);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr IndexPointer => btShapeHull_getIndexPointer(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UIntArray Indices
		{
			get
			{
				if (_indices == null)
				{
					_indices = new UIntArray(IndexPointer, NumIndices);
				}
				return _indices;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumIndices => btShapeHull_numIndices(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumTriangles => btShapeHull_numTriangles(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumVertices => btShapeHull_numVertices(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr VertexPointer => btShapeHull_getVertexPointer(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array Vertices
		{
			get
			{
				if (_vertices == null || _vertices.Count != NumVertices)
				{
					_vertices = new Vector3Array(VertexPointer, NumVertices);
				}
				return _vertices;
			}
		}

		protected override void Dispose(bool disposing)
		{
			btShapeHull_delete(Native);
		}
	}
}
