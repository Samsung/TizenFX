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
	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum Point2PointFlags
	{
		None = 0,
		Erp = 1,
		Cfm = 2
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConstraintSetting
	{
		internal IntPtr Native;

		internal ConstraintSetting(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Damping
		{
			get => btConstraintSetting_getDamping(Native);
			set => btConstraintSetting_setDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ImpulseClamp
		{
			get => btConstraintSetting_getImpulseClamp(Native);
			set => btConstraintSetting_setImpulseClamp(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Tau
		{
			get => btConstraintSetting_getTau(Native);
			set => btConstraintSetting_setTau(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Point2PointConstraint : TypedConstraint
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Point2PointConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
		 	global::System.Numerics.Vector3 pivotInA, global::System.Numerics.Vector3 pivotInB)
		{
			IntPtr native = btPoint2PointConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref pivotInA, ref pivotInB);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Point2PointConstraint(RigidBody rigidBodyA, global::System.Numerics.Vector3 pivotInA)
		{
			IntPtr native = btPoint2PointConstraint_new2(rigidBodyA.Native, ref pivotInA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, GetFixedBody());
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo1NonVirtual(ConstraintInfo1 info)
		{
			btPoint2PointConstraint_getInfo1NonVirtual(Native, info.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix4x4 body0Trans, Matrix4x4 body1Trans)
		{
			btPoint2PointConstraint_getInfo2NonVirtual(Native, info.Native, ref body0Trans,
				ref body1Trans);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateRhs(float timeStep)
		{
			btPoint2PointConstraint_updateRHS(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Point2PointFlags Flags => btPoint2PointConstraint_getFlags(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 PivotInA
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btPoint2PointConstraint_getPivotInA(Native, out value);
				return value;
			}
			set => btPoint2PointConstraint_setPivotA(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 PivotInB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btPoint2PointConstraint_getPivotInB(Native, out value);
				return value;
			}
			set => btPoint2PointConstraint_setPivotB(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConstraintSetting Setting => new ConstraintSetting(btPoint2PointConstraint_getSetting(Native));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseSolveConstraintObsolete
		{
			get => btPoint2PointConstraint_getUseSolveConstraintObsolete(Native);
			set => btPoint2PointConstraint_setUseSolveConstraintObsolete(Native, value);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct Point2PointConstraintFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintFloatData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData PivotInA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData PivotInB;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Point2PointConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct Point2PointConstraintDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintDoubleData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData PivotInA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData PivotInB;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Point2PointConstraintDoubleData), fieldName).ToInt32(); }
	}
}
