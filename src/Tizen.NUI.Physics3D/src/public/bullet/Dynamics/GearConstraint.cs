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
	public class GearConstraint : TypedConstraint
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public GearConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, global::System.Numerics.Vector3 axisInA,
		 	global::System.Numerics.Vector3 axisInB, float ratio = 1.0f)
		{
			IntPtr native = btGearConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref axisInA, ref axisInB, ratio);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AxisA
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGearConstraint_getAxisA(Native, out value);
				return value;
			}
			set => btGearConstraint_setAxisA(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AxisB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGearConstraint_getAxisB(Native, out value);
				return value;
			}
			set => btGearConstraint_setAxisB(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Ratio
		{
			get => btGearConstraint_getRatio(Native);
			set => btGearConstraint_setRatio(Native, value);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GearConstraintFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintFloatData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AxisInA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AxisInB;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Ratio;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(GearConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GearConstraintDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintDoubleData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AxisInA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AxisInB;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double Ratio;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(GearConstraintDoubleData), fieldName).ToInt32(); }
	}
}
