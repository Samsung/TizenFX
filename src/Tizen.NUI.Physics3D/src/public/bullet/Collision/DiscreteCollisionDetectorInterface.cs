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
	public abstract class DiscreteCollisionDetectorInterface : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class ClosestPointInput : BulletDisposableObject
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ClosestPointInput()
			{
				IntPtr native = btDiscreteCollisionDetectorInterface_ClosestPointInput_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public float MaximumDistanceSquared
			{
				get => btDiscreteCollisionDetectorInterface_ClosestPointInput_getMaximumDistanceSquared(Native);
				set => btDiscreteCollisionDetectorInterface_ClosestPointInput_setMaximumDistanceSquared(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public Matrix4x4 TransformA
			{
				get
				{
					Matrix4x4 value;
					btDiscreteCollisionDetectorInterface_ClosestPointInput_getTransformA(Native, out value);
					return value;
				}
				set => btDiscreteCollisionDetectorInterface_ClosestPointInput_setTransformA(Native, ref value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public Matrix4x4 TransformB
			{
				get
				{
					Matrix4x4 value;
					btDiscreteCollisionDetectorInterface_ClosestPointInput_getTransformB(Native, out value);
					return value;
				}
				set => btDiscreteCollisionDetectorInterface_ClosestPointInput_setTransformB(Native, ref value);
			}

			protected override void Dispose(bool disposing)
			{
				btDiscreteCollisionDetectorInterface_ClosestPointInput_delete(Native);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract class Result : BulletDisposableObject
		{
			protected internal Result()
			{
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void AddContactPoint(global::System.Numerics.Vector3 normalOnBInWorld, global::System.Numerics.Vector3 pointInWorld,
				float depth)
			{
				btDiscreteCollisionDetectorInterface_Result_addContactPoint(Native,
					ref normalOnBInWorld, ref pointInWorld, depth);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void SetShapeIdentifiersA(int partId0, int index0)
			{
				btDiscreteCollisionDetectorInterface_Result_setShapeIdentifiersA(
					Native, partId0, index0);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void SetShapeIdentifiersB(int partId1, int index1)
			{
				btDiscreteCollisionDetectorInterface_Result_setShapeIdentifiersB(
					Native, partId1, index1);
			}

			protected override void Dispose(bool disposing)
			{
				btDiscreteCollisionDetectorInterface_Result_delete(Native);
			}
		}

		protected internal DiscreteCollisionDetectorInterface()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetClosestPoints(ClosestPointInput input, Result output, DebugDraw debugDraw,
			bool swapResults = false)
		{
			btDiscreteCollisionDetectorInterface_getClosestPoints(Native, input.Native,
				output.Native, debugDraw != null ? debugDraw.Native : IntPtr.Zero, swapResults);
		}

		protected override void Dispose(bool disposing)
		{
			btDiscreteCollisionDetectorInterface_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class StorageResult : DiscreteCollisionDetectorInterface.Result
	{
		internal StorageResult() // public
		{
			//IntPtr native = btStorageResultWrapper_new();
			//InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ClosestPointInB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btStorageResult_getClosestPointInB(Native, out value);
				return value;
			}
			set => btStorageResult_setClosestPointInB(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Distance
		{
			get => btStorageResult_getDistance(Native);
			set => btStorageResult_setDistance(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 NormalOnSurfaceB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btStorageResult_getNormalOnSurfaceB(Native, out value);
				return value;
			}
			set => btStorageResult_setNormalOnSurfaceB(Native, ref value);
		}
	}
}
