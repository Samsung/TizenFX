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
	public class Face : BulletDisposableObject
	{
		internal Face(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		public Face()
		{
			IntPtr native = btFace_new();
			InitializeUserOwned(native);
		}
		/*
		public AlignedIntArray Indices
		{
			get { return new AlignedIntArray(btFace_getIndices(Native)); }
		}

		public ScalarArray Plane
		{
			get { return new ScalarArray(btFace_getPlane(Native)); }
		}
		*/

		protected override void Dispose(bool disposing)
		{
			btFace_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConvexPolyhedron : BulletDisposableObject
	{
		//AlignedFaceArray _faces;
		AlignedVector3Array _uniqueEdges;
		AlignedVector3Array _vertices;

		internal ConvexPolyhedron(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexPolyhedron()
		{
			IntPtr native = btConvexPolyhedron_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Initialize()
		{
			btConvexPolyhedron_initialize(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Initialize2()
		{
			btConvexPolyhedron_initialize2(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProjectRef(ref Matrix4x4 trans, ref global::System.Numerics.Vector3 dir, out float minProj, out float maxProj,
			out global::System.Numerics.Vector3 witnesPtMin, out global::System.Numerics.Vector3 witnesPtMax)
		{
			btConvexPolyhedron_project(Native, ref trans, ref dir, out minProj,
				out maxProj, out witnesPtMin, out witnesPtMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Project(Matrix4x4 trans, global::System.Numerics.Vector3 dir, out float minProj, out float maxProj,
			out global::System.Numerics.Vector3 witnesPtMin, out global::System.Numerics.Vector3 witnesPtMax)
		{
			btConvexPolyhedron_project(Native, ref trans, ref dir, out minProj,
				out maxProj, out witnesPtMin, out witnesPtMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool TestContainment()
		{
			return btConvexPolyhedron_testContainment(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Extents
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btConvexPolyhedron_getExtents(Native, out value);
				return value;
			}
			set => btConvexPolyhedron_setExtents(Native, ref value);
		}
		/*
		public AlignedFaceArray Faces
		{
			get { return btConvexPolyhedron_getFaces(Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalCenter
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btConvexPolyhedron_getLocalCenter(Native, out value);
				return value;
			}
			set => btConvexPolyhedron_setLocalCenter(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 C
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btConvexPolyhedron_getMC(Native, out value);
				return value;
			}
			set => btConvexPolyhedron_setMC(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 E
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btConvexPolyhedron_getME(Native, out value);
				return value;
			}
			set => btConvexPolyhedron_setME(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Radius
		{
			get => btConvexPolyhedron_getRadius(Native);
			set => btConvexPolyhedron_setRadius(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedVector3Array UniqueEdges
		{
			get
			{
				if (_uniqueEdges == null)
				{
					_uniqueEdges = new AlignedVector3Array(btConvexPolyhedron_getUniqueEdges(Native));
				}
				return _uniqueEdges;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedVector3Array Vertices
		{
			get
			{
				if (_vertices == null)
				{
					_vertices = new AlignedVector3Array(btConvexPolyhedron_getVertices(Native));
				}
				return _vertices;
			}
		}

		protected override void Dispose(bool disposing)
		{
			btConvexPolyhedron_delete(Native);
		}
	}
}
