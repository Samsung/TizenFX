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
	public class CylinderShape : ConvexInternalShape
	{
		protected internal CylinderShape()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CylinderShape(global::System.Numerics.Vector3 halfExtents)
		{
			IntPtr native = btCylinderShape_new(ref halfExtents);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CylinderShape(float halfExtentX, float halfExtentY, float halfExtentZ)
		{
			IntPtr native = btCylinderShape_new2(halfExtentX, halfExtentY, halfExtentZ);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HalfExtentsWithMargin
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btCylinderShape_getHalfExtentsWithMargin(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HalfExtentsWithoutMargin
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btCylinderShape_getHalfExtentsWithoutMargin(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Radius => btCylinderShape_getRadius(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UpAxis => btCylinderShape_getUpAxis(Native);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CylinderShapeX : CylinderShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CylinderShapeX(global::System.Numerics.Vector3 halfExtents)
		{
			IntPtr native = btCylinderShapeX_new(ref halfExtents);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CylinderShapeX(float halfExtentX, float halfExtentY, float halfExtentZ)
		{
			IntPtr native = btCylinderShapeX_new2(halfExtentX, halfExtentY, halfExtentZ);
			InitializeCollisionShape(native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CylinderShapeZ : CylinderShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CylinderShapeZ(global::System.Numerics.Vector3 halfExtents)
		{
			IntPtr native = btCylinderShapeZ_new(ref halfExtents);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CylinderShapeZ(float halfExtentX, float halfExtentY, float halfExtentZ)
		{
			IntPtr native = btCylinderShapeZ_new2(halfExtentX, halfExtentY, halfExtentZ);
			InitializeCollisionShape(native);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CylinderShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexInternalShapeData ConvexInternalShapeData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UpAxis;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(CylinderShapeData), fieldName).ToInt32(); }
	}
}
