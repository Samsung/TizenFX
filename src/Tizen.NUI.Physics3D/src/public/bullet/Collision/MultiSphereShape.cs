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
using System.Runtime.InteropServices;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class MultiSphereShape : ConvexInternalAabbCachingShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiSphereShape(global::System.Numerics.Vector3[] positions, float[] radi)
		{
			IntPtr native = btMultiSphereShape_new(positions, radi, (radi.Length < positions.Length) ? radi.Length : positions.Length);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiSphereShape(Vector3Array positions, float[] radi)
		{
			IntPtr native = btMultiSphereShape_new2(positions.Native, radi, (radi.Length < positions.Count) ? radi.Length : positions.Count);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetSpherePosition(int index)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiSphereShape_getSpherePosition(Native, index, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetSphereRadius(int index)
		{
			return btMultiSphereShape_getSphereRadius(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SphereCount => btMultiSphereShape_getSphereCount(Native);
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct MultiSphereShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexInternalShapeData ConvexInternalShapeData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PositionAndRadius LocalPositionArrayPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LocalPositionArraySize;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(MultiSphereShapeData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct PositionAndRadius
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData Position;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Radius;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(PositionAndRadius), fieldName).ToInt32(); }
	}
}
