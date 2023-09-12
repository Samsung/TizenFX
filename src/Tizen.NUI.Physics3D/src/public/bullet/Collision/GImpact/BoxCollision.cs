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

using System.Numerics;
using System;
using System.ComponentModel;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BoxBoxTransformCache : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BoxBoxTransformCache()
		{
			IntPtr native = BT_BOX_BOX_TRANSFORM_CACHE_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateAbsoluteMatrix()
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_absolute_matrix(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateFromFullInvertRef(ref Matrix4x4 transform0, ref Matrix4x4 transform1)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_from_full_invert(Native, ref transform0, ref transform1);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateFromFullInvert(Matrix4x4 transform0, Matrix4x4 transform1)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_from_full_invert(Native, ref transform0, ref transform1);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateFromFullHomogenicRef(ref Matrix4x4 transform0, ref Matrix4x4 transform1)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_from_homogenic(Native, ref transform0, ref transform1);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateFromFullHomogenic(Matrix4x4 transform0, Matrix4x4 transform1)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_from_homogenic(Native, ref transform0, ref transform1);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TransformRef(ref global::System.Numerics.Vector3 point, out global::System.Numerics.Vector3 value)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_transform(Native, ref point, out value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Transform(global::System.Numerics.Vector3 point)
		{
		 global::System.Numerics.Vector3 value;
			BT_BOX_BOX_TRANSFORM_CACHE_transform(Native, ref point, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 AbsoluteRotation
		{
			get
			{
				Matrix4x4 value;
				BT_BOX_BOX_TRANSFORM_CACHE_getAR(Native, out value);
				return value;
			}
			set { BT_BOX_BOX_TRANSFORM_CACHE_setAR(Native, ref value); }
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 Rotation1To0
		{
			get
			{
				Matrix4x4 value;
				BT_BOX_BOX_TRANSFORM_CACHE_getR1to0(Native, out value);
				return value;
			}
			set { BT_BOX_BOX_TRANSFORM_CACHE_setR1to0(Native, ref value); }
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Translation1To0
		{
			get
			{
			 global::System.Numerics.Vector3 value;
				BT_BOX_BOX_TRANSFORM_CACHE_getT1to0(Native, out value);
				return value;
			}
			set { BT_BOX_BOX_TRANSFORM_CACHE_setT1to0(Native, ref value); }
		}

		protected override void Dispose(bool disposing)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class Aabb : BulletDisposableObject
	{
		internal Aabb(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb()
		{
			IntPtr native = btAABB_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb(global::System.Numerics.Vector3 v1, global::System.Numerics.Vector3 v2, global::System.Numerics.Vector3 v3)
		{
			IntPtr native = btAABB_new2(ref v1, ref v2, ref v3);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb(global::System.Numerics.Vector3 v1, global::System.Numerics.Vector3 v2, global::System.Numerics.Vector3 v3, float margin)
		{
			IntPtr native = btAABB_new3(ref v1, ref v2, ref v3, margin);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb(Aabb other)
		{
			IntPtr native = btAABB_new4(other.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb(Aabb other, float margin)
		{
			IntPtr native = btAABB_new5(other.Native, margin);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyTransformRef(ref Matrix4x4 transform)
		{
			btAABB_appy_transform(Native, ref transform);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyTransform(Matrix4x4 transform)
		{
			btAABB_appy_transform(Native, ref transform);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyTransformTransCache(BoxBoxTransformCache transformCache)
		{
			btAABB_appy_transform_trans_cache(Native, transformCache.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CollidePlaneRef(ref global::System.Numerics.Vector4 plane)
		{
			return btAABB_collide_plane(Native, ref plane);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CollidePlane(global::System.Numerics.Vector4 plane)
		{
			return btAABB_collide_plane(Native, ref plane);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CollideRayRef(ref global::System.Numerics.Vector3 origin, ref global::System.Numerics.Vector3 direction)
		{
			return btAABB_collide_ray(Native, ref origin, ref direction);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CollideRay(global::System.Numerics.Vector3 origin, global::System.Numerics.Vector3 direction)
		{
			return btAABB_collide_ray(Native, ref origin, ref direction);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CollideTriangleExactRef(ref global::System.Numerics.Vector3 p1, ref global::System.Numerics.Vector3 p2, ref global::System.Numerics.Vector3 p3, ref global::System.Numerics.Vector4 trianglePlane)
		{
			return btAABB_collide_triangle_exact(Native, ref p1, ref p2, ref p3,
				ref trianglePlane);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CollideTriangleExact(global::System.Numerics.Vector3 p1, global::System.Numerics.Vector3 p2, global::System.Numerics.Vector3 p3, global::System.Numerics.Vector4 trianglePlane)
		{
			return btAABB_collide_triangle_exact(Native, ref p1, ref p2, ref p3,
				ref trianglePlane);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyWithMargin(Aabb other, float margin)
		{
			btAABB_copy_with_margin(Native, other.Native, margin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void FindIntersection(Aabb other, Aabb intersection)
		{
			btAABB_find_intersection(Native, other.Native, intersection.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetCenterExtend(out global::System.Numerics.Vector3 center, out global::System.Numerics.Vector3 extend)
		{
			btAABB_get_center_extend(Native, out center, out extend);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasCollision(Aabb other)
		{
			return btAABB_has_collision(Native, other.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void IncrementMargin(float margin)
		{
			btAABB_increment_margin(Native, margin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Invalidate()
		{
			btAABB_invalidate(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Merge(Aabb box)
		{
			btAABB_merge(Native, box.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool OverlappingTransCache(Aabb box, BoxBoxTransformCache transformCache,
			bool fullTest)
		{
			return btAABB_overlapping_trans_cache(Native, box.Native, transformCache.Native,
				fullTest);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool OverlappingTransConservativeRef(Aabb box, ref Matrix4x4 transform1To0)
		{
			return btAABB_overlapping_trans_conservative(Native, box.Native, ref transform1To0);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool OverlappingTransConservative(Aabb box, Matrix4x4 transform1To0)
		{
			return btAABB_overlapping_trans_conservative(Native, box.Native, ref transform1To0);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool OverlappingTransConservative2(Aabb box, BoxBoxTransformCache transform1To0)
		{
			return btAABB_overlapping_trans_conservative2(Native, box.Native, transform1To0.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PlaneIntersectionType PlaneClassify(global::System.Numerics.Vector4 plane)
		{
			return btAABB_plane_classify(Native, ref plane);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProjectionIntervalRef(ref global::System.Numerics.Vector3 direction, out float vmin, out float vmax)
		{
			btAABB_projection_interval(Native, ref direction, out vmin, out vmax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProjectionInterval(global::System.Numerics.Vector3 direction, out float vmin, out float vmax)
		{
			btAABB_projection_interval(Native, ref direction, out vmin, out vmax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Max
		{
			get
			{
			 global::System.Numerics.Vector3 value;
				btAABB_getMax(Native, out value);
				return value;
			}
			set { btAABB_setMax(Native, ref value); }
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Min
		{
			get
			{
			 global::System.Numerics.Vector3 value;
				btAABB_getMin(Native, out value);
				return value;
			}
			set { btAABB_setMin(Native, ref value); }
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btAABB_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum PlaneIntersectionType
	{
		BackPlane,
		CollidePlane,
		FrontPlane
	}
}
