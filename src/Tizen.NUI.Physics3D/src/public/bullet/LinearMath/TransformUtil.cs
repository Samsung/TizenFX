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
	public static class TransformUtil
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void CalculateDiffAxisAngle(ref Matrix4x4 transform0, ref Matrix4x4 transform1,
			out global::System.Numerics.Vector3 axis, out float angle)
		{
			btTransformUtil_calculateDiffAxisAngle(ref transform0, ref transform1,
				out axis, out angle);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void CalculateDiffAxisAngleQuaternion(ref Quaternion orn0, ref Quaternion orn1a,
			out global::System.Numerics.Vector3 axis, out float angle)
		{
			btTransformUtil_calculateDiffAxisAngleQuaternion(ref orn0, ref orn1a,
				out axis, out angle);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void CalculateVelocity(ref Matrix4x4 transform0, ref Matrix4x4 transform1,
			float timeStep, out global::System.Numerics.Vector3 linVel, out global::System.Numerics.Vector3 angVel)
		{
			btTransformUtil_calculateVelocity(ref transform0, ref transform1, timeStep,
				out linVel, out angVel);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void CalculateVelocityQuaternion(ref global::System.Numerics.Vector3 pos0, ref global::System.Numerics.Vector3 pos1,
			ref Quaternion orn0, ref Quaternion orn1, float timeStep, out global::System.Numerics.Vector3 linVel, out global::System.Numerics.Vector3 angVel)
		{
			btTransformUtil_calculateVelocityQuaternion(ref pos0, ref pos1, ref orn0,
				ref orn1, timeStep, out linVel, out angVel);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void IntegrateTransform(ref Matrix4x4 curTrans, ref global::System.Numerics.Vector3 linvel, ref global::System.Numerics.Vector3 angvel,
			float timeStep, out Matrix4x4 predictedTransform)
		{
			btTransformUtil_integrateTransform(ref curTrans, ref linvel, ref angvel,
				timeStep, out predictedTransform);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConvexSeparatingDistanceUtil : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexSeparatingDistanceUtil(float boundingRadiusA, float boundingRadiusB)
		{
			IntPtr native = btConvexSeparatingDistanceUtil_new(boundingRadiusA, boundingRadiusB);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InitSeparatingDistance(ref global::System.Numerics.Vector3 separatingVector, float separatingDistance,
			ref Matrix4x4 transA, ref Matrix4x4 transB)
		{
			btConvexSeparatingDistanceUtil_initSeparatingDistance(Native, ref separatingVector,
				separatingDistance, ref transA, ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateSeparatingDistance(ref Matrix4x4 transA, ref Matrix4x4 transB)
		{
			btConvexSeparatingDistanceUtil_updateSeparatingDistance(Native, ref transA,
				ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ConservativeSeparatingDistance => btConvexSeparatingDistanceUtil_getConservativeSeparatingDistance(Native);

		protected override void Dispose(bool disposing)
		{
			btConvexSeparatingDistanceUtil_delete(Native);
		}
	}
}
