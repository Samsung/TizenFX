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
	public class ConvexCast : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class CastResult : BulletDisposableObject
		{
			private DebugDraw _debugDrawer;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public CastResult()
			{
				IntPtr native = btConvexCast_CastResult_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void DebugDraw(float fraction)
			{
				btConvexCast_CastResult_DebugDraw(Native, fraction);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void DrawCoordSystem(Matrix4x4 trans)
			{
				btConvexCast_CastResult_drawCoordSystem(Native, ref trans);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void ReportFailure(int errNo, int numIterations)
			{
				btConvexCast_CastResult_reportFailure(Native, errNo, numIterations);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public float AllowedPenetration
			{
				get => btConvexCast_CastResult_getAllowedPenetration(Native);
				set => btConvexCast_CastResult_setAllowedPenetration(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public DebugDraw DebugDrawer
			{
				get => _debugDrawer;
				set
				{
					_debugDrawer = value;
					btConvexCast_CastResult_setDebugDrawer(Native, value != null ? value.Native : IntPtr.Zero);
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public float Fraction
			{
				get => btConvexCast_CastResult_getFraction(Native);
				set => btConvexCast_CastResult_setFraction(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public global::System.Numerics.Vector3 HitPoint
			{
				get
				{
				 	global::System.Numerics.Vector3 value;
					btConvexCast_CastResult_getHitPoint(Native, out value);
					return value;
				}
				set => btConvexCast_CastResult_setHitPoint(Native, ref value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public Matrix4x4 HitTransformA
			{
				get
				{
					Matrix4x4 value;
					btConvexCast_CastResult_getHitTransformA(Native, out value);
					return value;
				}
				set => btConvexCast_CastResult_setHitTransformA(Native, ref value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public Matrix4x4 HitTransformB
			{
				get
				{
					Matrix4x4 value;
					btConvexCast_CastResult_getHitTransformB(Native, out value);
					return value;
				}
				set => btConvexCast_CastResult_setHitTransformB(Native, ref value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public global::System.Numerics.Vector3 Normal
			{
				get
				{
				 	global::System.Numerics.Vector3 value;
					btConvexCast_CastResult_getNormal(Native, out value);
					return value;
				}
				set => btConvexCast_CastResult_setNormal(Native, ref value);
			}

			protected override void Dispose(bool disposing)
			{
				btConvexCast_CastResult_delete(Native);
			}
		}

		protected internal ConvexCast()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CalcTimeOfImpact(Matrix4x4 fromA, Matrix4x4 toA, Matrix4x4 fromB, Matrix4x4 toB,
			CastResult result)
		{
			return btConvexCast_calcTimeOfImpact(Native, ref fromA, ref toA, ref fromB,
				ref toB, result.Native);
		}

		protected override void Dispose(bool disposing)
		{
			btConvexCast_delete(Native);
		}
	}
}
