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
	public class StaticPlaneShape : ConcaveShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StaticPlaneShape(global::System.Numerics.Vector3 planeNormal, float planeConstant)
		{
			IntPtr native = btStaticPlaneShape_new(ref planeNormal, planeConstant);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float PlaneConstant => btStaticPlaneShape_getPlaneConstant(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 PlaneNormal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btStaticPlaneShape_getPlaneNormal(Native, out value);
				return value;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct StaticPlaneShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShapeData CollisionShapeData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LocalScaling;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData PlaneNormal;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float PlaneConstant;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(StaticPlaneShapeData), fieldName).ToInt32(); }
	}
}
