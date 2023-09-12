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
using System.Runtime.InteropServices;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Generic6DofSpringConstraint : Generic6DofConstraint
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Generic6DofSpringConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
			Matrix4x4 frameInA, Matrix4x4 frameInB, bool useLinearReferenceFrameA)
		{
			IntPtr native = btGeneric6DofSpringConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref frameInA, ref frameInB, useLinearReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Generic6DofSpringConstraint(RigidBody rigidBodyB, Matrix4x4 frameInB,
			bool useLinearReferenceFrameB)
		{
			IntPtr native = btGeneric6DofSpringConstraint_new2(rigidBodyB.Native, ref frameInB,
				useLinearReferenceFrameB);
			InitializeUserOwned(native);
			InitializeMembers(GetFixedBody(), rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void EnableSpring(int index, bool onOff)
		{
			btGeneric6DofSpringConstraint_enableSpring(Native, index, onOff);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetDamping(int index)
		{
			return btGeneric6DofSpringConstraint_getDamping(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetEquilibriumPoint(int index)
		{
			return btGeneric6DofSpringConstraint_getEquilibriumPoint(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetStiffness(int index)
		{
			return btGeneric6DofSpringConstraint_getStiffness(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsSpringEnabled(int index)
		{
			return btGeneric6DofSpringConstraint_isSpringEnabled(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetDamping(int index, float damping)
		{
			btGeneric6DofSpringConstraint_setDamping(Native, index, damping);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetEquilibriumPoint()
		{
			btGeneric6DofSpringConstraint_setEquilibriumPoint(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetEquilibriumPoint(int index)
		{
			btGeneric6DofSpringConstraint_setEquilibriumPoint2(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetEquilibriumPoint(int index, float val)
		{
			btGeneric6DofSpringConstraint_setEquilibriumPoint3(Native, index, val);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetStiffness(int index, float stiffness)
		{
			btGeneric6DofSpringConstraint_setStiffness(Native, index, stiffness);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct Generic6DofSpringConstraintFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Generic6DofConstraintFloatData SixDofData;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int[] SpringEnabled;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float[] EquilibriumPoint;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float[] SpringStiffness;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float[] SpringDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofSpringConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct Generic6DofSpringConstraintDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Generic6DofConstraintDoubleData SixDofData;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int[] SpringEnabled;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double[] EquilibriumPoint;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double[] SpringStiffness;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double[] SpringDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofSpringConstraintDoubleData), fieldName).ToInt32(); }
	}
}
