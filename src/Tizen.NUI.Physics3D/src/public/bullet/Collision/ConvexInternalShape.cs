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

using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class ConvexInternalShape : ConvexShape
	{
		protected internal ConvexInternalShape()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetSafeMargin(float minDimension, float defaultMarginMultiplier = 0.1f)
		{
			btConvexInternalShape_setSafeMargin(Native, minDimension, defaultMarginMultiplier);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetSafeMarginRef(ref global::System.Numerics.Vector3 halfExtents, float defaultMarginMultiplier = 0.1f)
		{
			btConvexInternalShape_setSafeMargin2(Native, ref halfExtents, defaultMarginMultiplier);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetSafeMargin(global::System.Numerics.Vector3 halfExtents, float defaultMarginMultiplier = 0.1f)
		{
			btConvexInternalShape_setSafeMargin2(Native, ref halfExtents, defaultMarginMultiplier);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ImplicitShapeDimensions
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btConvexInternalShape_getImplicitShapeDimensions(Native, out value);
				return value;
			}
			set { btConvexInternalShape_setImplicitShapeDimensions(Native, ref value); }
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalScalingNV
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btConvexInternalShape_getLocalScalingNV(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MarginNV => btConvexInternalShape_getMarginNV(Native);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class ConvexInternalAabbCachingShape : ConvexInternalShape
	{
		protected internal ConvexInternalAabbCachingShape()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RecalcLocalAabb()
		{
			btConvexInternalAabbCachingShape_recalcLocalAabb(Native);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct ConvexInternalShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShapeData CollisionShapeData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LocalScaling;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData ImplicitShapeDimensions;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CollisionMargin;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(ConvexInternalShapeData), fieldName).ToInt32(); }
	}
}
