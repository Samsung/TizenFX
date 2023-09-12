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
	public class ConeShape : ConvexInternalShape
	{
		protected internal ConeShape()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConeShape(float radius, float height)
		{
			IntPtr native = btConeShape_new(radius, height);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ConeUpIndex
		{
			get => btConeShape_getConeUpIndex(Native);
			set => btConeShape_setConeUpIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Height
		{
			get => btConeShape_getHeight(Native);
			set => btConeShape_setHeight(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Radius
		{
			get => btConeShape_getRadius(Native);
			set => btConeShape_setRadius(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConeShapeX : ConeShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConeShapeX(float radius, float height)
		{
			IntPtr native = btConeShapeX_new(radius, height);
			InitializeCollisionShape(native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConeShapeZ : ConeShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConeShapeZ(float radius, float height)
		{
			IntPtr native = btConeShapeZ_new(radius, height);
			InitializeCollisionShape(native);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct ConeShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexInternalShapeData ConvexInternalShapeData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UpAxis;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(ConeShapeData), fieldName).ToInt32(); }
	}
}
