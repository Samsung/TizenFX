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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CapsuleShape : ConvexInternalShape
	{
		protected internal CapsuleShape()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CapsuleShape(float radius, float height)
		{
			IntPtr native = btCapsuleShape_new(radius, height);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float HalfHeight => btCapsuleShape_getHalfHeight(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Radius => btCapsuleShape_getRadius(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UpAxis => btCapsuleShape_getUpAxis(Native);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CapsuleShapeX : CapsuleShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CapsuleShapeX(float radius, float height)
		{
			IntPtr native = btCapsuleShapeX_new(radius, height);
			InitializeCollisionShape(native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CapsuleShapeZ : CapsuleShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CapsuleShapeZ(float radius, float height)
		{
			IntPtr native = btCapsuleShapeZ_new(radius, height);
			InitializeCollisionShape(native);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CapsuleShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexInternalShapeData ConvexInternalShapeData;
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UpAxis;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(CapsuleShapeData), fieldName).ToInt32(); }
	}
}
