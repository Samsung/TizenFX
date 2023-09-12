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
	public class ConvexPointCloudShape : PolyhedralConvexAabbCachingShape
	{
		private Vector3Array _unscaledPoints;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexPointCloudShape()
		{
			IntPtr native = btConvexPointCloudShape_new();
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexPointCloudShape(Vector3Array points, int numPoints, global::System.Numerics.Vector3 localScaling,
			bool computeAabb = true)
		{
			IntPtr native = btConvexPointCloudShape_new2(points.Native, numPoints, ref localScaling,
				computeAabb);
			InitializeCollisionShape(native);

			_unscaledPoints = points;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetScaledPoint(int index, out global::System.Numerics.Vector3 value)
		{
			btConvexPointCloudShape_getScaledPoint(Native, index, out value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetScaledPoint(int index)
		{
		 	global::System.Numerics.Vector3 value;
			btConvexPointCloudShape_getScaledPoint(Native, index, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPoints(Vector3Array points, int numPoints, bool computeAabb = true)
		{
			btConvexPointCloudShape_setPoints(Native, points.Native, numPoints,
				computeAabb);
			_unscaledPoints = points;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPoints(Vector3Array points, int numPoints, bool computeAabb, global::System.Numerics.Vector3 localScaling)
		{
			btConvexPointCloudShape_setPoints2(Native, points.Native, numPoints,
				computeAabb, ref localScaling);
			_unscaledPoints = points;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumPoints => btConvexPointCloudShape_getNumPoints(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array UnscaledPoints
		{
			get
			{
				if (_unscaledPoints == null || _unscaledPoints.Count != NumPoints)
				{
					IntPtr unscaledPointsPtr = btConvexPointCloudShape_getUnscaledPoints(Native);
					if (unscaledPointsPtr != IntPtr.Zero)
					{
						_unscaledPoints = new Vector3Array(unscaledPointsPtr, NumPoints);
					}
				}
				return _unscaledPoints;
			}
			set
			{
				SetPoints(value, value.Count);
			}
		}
	}
}
