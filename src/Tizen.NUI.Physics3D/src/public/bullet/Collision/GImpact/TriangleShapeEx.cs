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
	public class GimTriangleContact : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public GimTriangleContact()
		{
			IntPtr native = GIM_TRIANGLE_CONTACT_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GimTriangleContact(GimTriangleContact other)
		{
			IntPtr native = GIM_TRIANGLE_CONTACT_new2(other.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyFrom(GimTriangleContact other)
		{
			GIM_TRIANGLE_CONTACT_copy_from(Native, other.Native);
		}
		/*
		public void MergePoints(global::System.Numerics.Vector4 plane, float margin, global::System.Numerics.Vector3 points, int pointCount)
		{
			GIM_TRIANGLE_CONTACT_merge_points(Native, ref plane, margin, ref points, pointCount);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float PenetrationDepth
		{
			get => GIM_TRIANGLE_CONTACT_getPenetration_depth(Native);
			set => GIM_TRIANGLE_CONTACT_setPenetration_depth(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PointCount
		{
			get => GIM_TRIANGLE_CONTACT_getPoint_count(Native);
			set => GIM_TRIANGLE_CONTACT_setPoint_count(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array Points => new Vector3Array(GIM_TRIANGLE_CONTACT_getPoints(Native), 16);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector4 SeparatingNormal
		{
			get
			{
			 global::System.Numerics.Vector4 value;
				GIM_TRIANGLE_CONTACT_getSeparating_normal(Native, out value);
				return value;
			}
			set => GIM_TRIANGLE_CONTACT_setSeparating_normal(Native, ref value);
		}

		protected override void Dispose(bool disposing)
		{
			GIM_TRIANGLE_CONTACT_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PrimitiveTriangle : BulletDisposableObject
	{
		internal PrimitiveTriangle(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PrimitiveTriangle()
		{
			IntPtr native = btPrimitiveTriangle_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyTransform(Matrix4x4 transform)
		{
			btPrimitiveTriangle_applyTransform(Native, ref transform);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildTriPlane()
		{
			btPrimitiveTriangle_buildTriPlane(Native);
		}
		/*
		public int ClipTriangle(PrimitiveTriangle other, global::System.Numerics.Vector3 clippedPoints)
		{
			return btPrimitiveTriangle_clip_triangle(Native, other.Native, ref clippedPoints);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool FindTriangleCollisionClipMethod(PrimitiveTriangle other, GimTriangleContact contacts)
		{
			return btPrimitiveTriangle_find_triangle_collision_clip_method(Native, other.Native, contacts.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetEdgePlane(int edgeIndex, out global::System.Numerics.Vector4 plane)
		{
			btPrimitiveTriangle_get_edge_plane(Native, edgeIndex, out plane);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool OverlapTestConservative(PrimitiveTriangle other)
		{
			return btPrimitiveTriangle_overlap_test_conservative(Native, other.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Dummy
		{
			get => btPrimitiveTriangle_getDummy(Native);
			set => btPrimitiveTriangle_setDummy(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Margin
		{
			get => btPrimitiveTriangle_getMargin(Native);
			set => btPrimitiveTriangle_setMargin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector4 Plane
		{
			get
			{
			 global::System.Numerics.Vector4 value;
				btPrimitiveTriangle_getPlane(Native, out value);
				return value;
			}
			set => btPrimitiveTriangle_setPlane(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array Vertices => new Vector3Array(btPrimitiveTriangle_getVertices(Native), 3);

		protected override void Dispose(bool disposing)
		{
			btPrimitiveTriangle_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriangleShapeEx : TriangleShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleShapeEx()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btTriangleShapeEx_new();
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleShapeEx(global::System.Numerics.Vector3 p0, global::System.Numerics.Vector3 p1, global::System.Numerics.Vector3 p2) 
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btTriangleShapeEx_new2(ref p0, ref p1, ref p2);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleShapeEx(TriangleShapeEx other) 
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btTriangleShapeEx_new3(other.Native);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyTransform(Matrix4x4 transform)
		{
			btTriangleShapeEx_applyTransform(Native, ref transform);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildTriPlane(out global::System.Numerics.Vector4 plane)
		{
			btTriangleShapeEx_buildTriPlane(Native, out plane);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool OverlapTestConservative(TriangleShapeEx other)
		{
			return btTriangleShapeEx_overlap_test_conservative(Native, other.Native);
		}
	}
}
