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
using System.Collections.Generic;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConvexHullShape : PolyhedralConvexAabbCachingShape
	{
		private Vector3Array _unscaledPoints;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexHullShape()
		{
			IntPtr native = btConvexHullShape_new();
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexHullShape(float[] points)
			: this(points, points.Length / 3, 3 * sizeof(float))
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexHullShape(float[] points, int numPoints, int stride = 3 * sizeof(float))
		{
			IntPtr native = btConvexHullShape_new4(points, numPoints, stride);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexHullShape(IEnumerable<global::System.Numerics.Vector3> points, int numPoints)
		{
			IntPtr native = btConvexHullShape_new();
			InitializeCollisionShape(native);

			int i = 0;
			foreach (global::System.Numerics.Vector3 v in points)
			{
			 	global::System.Numerics.Vector3 viter = v;
				AddPointRef(ref viter, false);
				i++;
				if (i == numPoints)
				{
					break;
				}
			}
			RecalcLocalAabb();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexHullShape(IEnumerable<global::System.Numerics.Vector3> points)
		{
			IntPtr native = btConvexHullShape_new();
			InitializeCollisionShape(native);

			foreach (global::System.Numerics.Vector3 v in points)
			{
			 	global::System.Numerics.Vector3 viter = v;
				AddPointRef(ref viter, false);
			}
			RecalcLocalAabb();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddPointRef(ref global::System.Numerics.Vector3 point, bool recalculateLocalAabb = true)
		{
			btConvexHullShape_addPoint(Native, ref point, recalculateLocalAabb);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddPoint(global::System.Numerics.Vector3 point, bool recalculateLocalAabb = true)
		{
			btConvexHullShape_addPoint(Native, ref point, recalculateLocalAabb);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetScaledPoint(int i, out global::System.Numerics.Vector3 value)
		{
			btConvexHullShape_getScaledPoint(Native, i, out value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetScaledPoint(int i)
		{
		 	global::System.Numerics.Vector3 value;
			btConvexHullShape_getScaledPoint(Native, i, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void OptimizeConvexHull()
		{
			btConvexHullShape_optimizeConvexHull(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumPoints => btConvexHullShape_getNumPoints(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array UnscaledPoints
		{
			get
			{
				if (_unscaledPoints == null || _unscaledPoints.Count != NumPoints)
				{
					_unscaledPoints = new Vector3Array(btConvexHullShape_getUnscaledPoints(Native), NumPoints);
				}
				return _unscaledPoints;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct ConvexHullShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexInternalShapeData ConvexInternalShapeData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr UnscaledPointsFloatPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr UnscaledPointsDoublePtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumUnscaledPoints;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(ConvexHullShapeData), fieldName).ToInt32(); }
	}
}
