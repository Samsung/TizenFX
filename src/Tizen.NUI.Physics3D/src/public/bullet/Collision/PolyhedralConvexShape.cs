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
	public abstract class PolyhedralConvexShape : ConvexInternalShape
	{
		private ConvexPolyhedron _convexPolyhedron;

		protected internal PolyhedralConvexShape()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetEdge(int i, out global::System.Numerics.Vector3 pa, out global::System.Numerics.Vector3 pb)
		{
			btPolyhedralConvexShape_getEdge(Native, i, out pa, out pb);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetPlane(out global::System.Numerics.Vector3 planeNormal, out global::System.Numerics.Vector3 planeSupport, int i)
		{
			btPolyhedralConvexShape_getPlane(Native, out planeNormal, out planeSupport,
				i);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetVertex(int i, out global::System.Numerics.Vector3 vtx)
		{
			btPolyhedralConvexShape_getVertex(Native, i, out vtx);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool InitializePolyhedralFeatures(int shiftVerticesByMargin = 0)
		{
			return btPolyhedralConvexShape_initializePolyhedralFeatures(Native,
				shiftVerticesByMargin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsInsideRef(ref global::System.Numerics.Vector3 pt, float tolerance)
		{
			return btPolyhedralConvexShape_isInside(Native, ref pt, tolerance);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsInside(global::System.Numerics.Vector3 pt, float tolerance)
		{
			return btPolyhedralConvexShape_isInside(Native, ref pt, tolerance);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPolyhedralFeatures(ConvexPolyhedron polyhedron)
		{
			btPolyhedralConvexShape_setPolyhedralFeatures(Native, polyhedron.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexPolyhedron ConvexPolyhedron
		{
			get
			{
				if (_convexPolyhedron == null)
				{
					IntPtr ptr = btPolyhedralConvexShape_getConvexPolyhedron(Native);
					if (ptr == IntPtr.Zero)
					{
						return null;
					}
					_convexPolyhedron = new ConvexPolyhedron();
				}
				return _convexPolyhedron;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumEdges => btPolyhedralConvexShape_getNumEdges(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumPlanes => btPolyhedralConvexShape_getNumPlanes(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumVertices => btPolyhedralConvexShape_getNumVertices(Native);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class PolyhedralConvexAabbCachingShape : PolyhedralConvexShape
	{
		protected internal PolyhedralConvexAabbCachingShape()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetNonvirtualAabbRef(ref Matrix4x4 trans, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax,
			float margin)
		{
			btPolyhedralConvexAabbCachingShape_getNonvirtualAabb(Native, ref trans,
				out aabbMin, out aabbMax, margin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetNonvirtualAabb(Matrix4x4 trans, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax,
			float margin)
		{
			btPolyhedralConvexAabbCachingShape_getNonvirtualAabb(Native, ref trans,
				out aabbMin, out aabbMax, margin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RecalcLocalAabb()
		{
			btPolyhedralConvexAabbCachingShape_recalcLocalAabb(Native);
		}
	}
}
