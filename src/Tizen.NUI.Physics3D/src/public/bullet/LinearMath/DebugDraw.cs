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

﻿/*
 * C# / XNA  port of Bullet (c) 2011 Mark Neale <xexuxjy@hotmail.com>
 *
 * Bullet Continuous Collision Detection and Physics Library
 * Copyright (c) 2003-2008 Erwin Coumans  http://www.bulletphysics.com/
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose, 
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *	claim that you wrote the original software. If you use this software
 *	in a product, an acknowledgment in the product documentation would be
 *	appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *	misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System;
using System.ComponentModel;
using System.Security;
using System.Runtime.InteropServices;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class DebugDraw : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawAabbUnmanagedDelegate([In] ref global::System.Numerics.Vector3 from, [In] ref global::System.Numerics.Vector3 to, [In] ref global::System.Numerics.Vector3 color);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawArcUnmanagedDelegate([In] ref global::System.Numerics.Vector3 center, [In] ref global::System.Numerics.Vector3 normal, [In] ref global::System.Numerics.Vector3 axis, float radiusA, float radiusB,
			float minAngle, float maxAngle, ref global::System.Numerics.Vector3 color, bool drawSect, float stepDegrees);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawBoxUnmanagedDelegate([In] ref global::System.Numerics.Vector3 bbMin, [In] ref global::System.Numerics.Vector3 bbMax, [In] ref Matrix4x4 trans, [In] ref global::System.Numerics.Vector3 color);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawCapsuleUnmanagedDelegate(float radius, float halfHeight, int upAxis, [In] ref Matrix4x4 transform, [In] ref global::System.Numerics.Vector3 color);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawConeUnmanagedDelegate(float radius, float height, int upAxis, [In] ref Matrix4x4 transform, [In] ref global::System.Numerics.Vector3 color);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawContactPointUnmanagedDelegate([In] ref global::System.Numerics.Vector3 pointOnB, [In] ref global::System.Numerics.Vector3 normalOnB, float distance, int lifeTime, [In] ref global::System.Numerics.Vector3 color);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawCylinderUnmanagedDelegate(float radius, float halfHeight, int upAxis, [In] ref Matrix4x4 transform, [In] ref global::System.Numerics.Vector3 color);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawLineUnmanagedDelegate([In] ref global::System.Numerics.Vector3 from, [In] ref global::System.Numerics.Vector3 to, [In] ref global::System.Numerics.Vector3 color);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawPlaneUnmanagedDelegate([In] ref global::System.Numerics.Vector3 planeNormal, float planeConst, [In] ref Matrix4x4 transform, [In] ref global::System.Numerics.Vector3 color);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawSphereUnmanagedDelegate(float radius, [In] ref Matrix4x4 transform, [In] ref global::System.Numerics.Vector3 color);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawSpherePatchUnmanagedDelegate([In] ref global::System.Numerics.Vector3 center, [In] ref global::System.Numerics.Vector3 up, [In] ref global::System.Numerics.Vector3 axis, float radius,
			float minTh, float maxTh, float minPs, float maxPs, [In] ref global::System.Numerics.Vector3 color, float stepDegrees);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawTransformUnmanagedDelegate([In] ref Matrix4x4 transform, float orthoLen);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawTriangleUnmanagedDelegate([In] ref global::System.Numerics.Vector3 v0, [In] ref global::System.Numerics.Vector3 v1, [In] ref global::System.Numerics.Vector3 v2, [In] ref global::System.Numerics.Vector3 color, float alpha);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void SimpleCallback(int x);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate DebugDrawModes GetDebugModeUnmanagedDelegate();

		private readonly DrawAabbUnmanagedDelegate _drawAabb;
		private readonly DrawArcUnmanagedDelegate _drawArc;
		private readonly DrawBoxUnmanagedDelegate _drawBox;
		private readonly DrawCapsuleUnmanagedDelegate _drawCapsule;
		private readonly DrawConeUnmanagedDelegate _drawCone;
		private readonly DrawContactPointUnmanagedDelegate _drawContactPoint;
		private readonly DrawCylinderUnmanagedDelegate _drawCylinder;
		private readonly DrawLineUnmanagedDelegate _drawLine;
		private readonly DrawPlaneUnmanagedDelegate _drawPlane;
		private readonly DrawSphereUnmanagedDelegate _drawSphere;
		private readonly DrawSpherePatchUnmanagedDelegate _drawSpherePatch;
		private readonly DrawTransformUnmanagedDelegate _drawTransform;
		private readonly DrawTriangleUnmanagedDelegate _drawTriangle;
		private readonly GetDebugModeUnmanagedDelegate _getDebugMode;
		private readonly SimpleCallback _cb;

		internal static DebugDraw GetManaged(IntPtr debugDrawer)
		{
			if (debugDrawer == IntPtr.Zero)
			{
				return null;
			}

			IntPtr handle = btIDebugDrawWrapper_getGCHandle(debugDrawer);
			return GCHandle.FromIntPtr(handle).Target as DebugDraw;
		}
		
		private void SimpleCallbackUnmanaged(int x)
		{
			throw new NotImplementedException();
		}

		private DebugDrawModes GetDebugModeUnmanaged()
		{
			return DebugMode;
		}

		public DebugDraw()
		{
			_drawAabb = new DrawAabbUnmanagedDelegate(DrawAabb);
			_drawArc = new DrawArcUnmanagedDelegate(DrawArc);
			_drawBox = new DrawBoxUnmanagedDelegate(DrawBox);
			_drawCapsule = new DrawCapsuleUnmanagedDelegate(DrawCapsule);
			_drawCone = new DrawConeUnmanagedDelegate(DrawCone);
			_drawContactPoint = new DrawContactPointUnmanagedDelegate(DrawContactPoint);
			_drawCylinder = new DrawCylinderUnmanagedDelegate(DrawCylinder);
			_drawLine = new DrawLineUnmanagedDelegate(DrawLine);
			_drawPlane = new DrawPlaneUnmanagedDelegate(DrawPlane);
			_drawSphere = new DrawSphereUnmanagedDelegate(DrawSphere);
			_drawSpherePatch = new DrawSpherePatchUnmanagedDelegate(DrawSpherePatch);
			_drawTransform = new DrawTransformUnmanagedDelegate(DrawTransform);
			_drawTriangle = new DrawTriangleUnmanagedDelegate(DrawTriangle);
			_getDebugMode = new GetDebugModeUnmanagedDelegate(GetDebugModeUnmanaged);
			_cb = new SimpleCallback(SimpleCallbackUnmanaged);

			IntPtr native = btIDebugDrawWrapper_new(
				GCHandle.ToIntPtr(GCHandle.Alloc(this)),
				Marshal.GetFunctionPointerForDelegate(_drawAabb),
				Marshal.GetFunctionPointerForDelegate(_drawArc),
				Marshal.GetFunctionPointerForDelegate(_drawBox),
				Marshal.GetFunctionPointerForDelegate(_drawCapsule),
				Marshal.GetFunctionPointerForDelegate(_drawCone),
				Marshal.GetFunctionPointerForDelegate(_drawContactPoint),
				Marshal.GetFunctionPointerForDelegate(_drawCylinder),
				Marshal.GetFunctionPointerForDelegate(_drawLine),
				Marshal.GetFunctionPointerForDelegate(_drawPlane),
				Marshal.GetFunctionPointerForDelegate(_drawSphere),
				Marshal.GetFunctionPointerForDelegate(_drawSpherePatch),
				Marshal.GetFunctionPointerForDelegate(_drawTransform),
				Marshal.GetFunctionPointerForDelegate(_drawTriangle),
				Marshal.GetFunctionPointerForDelegate(_getDebugMode),
				Marshal.GetFunctionPointerForDelegate(_cb));
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract void DrawLine(ref global::System.Numerics.Vector3 from, ref global::System.Numerics.Vector3 to, ref global::System.Numerics.Vector3 color);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract void Draw3DText(ref global::System.Numerics.Vector3 location, String textString);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract void ReportErrorWarning(String warningString);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract DebugDrawModes DebugMode { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DrawLine(global::System.Numerics.Vector3 from, global::System.Numerics.Vector3 to, global::System.Numerics.Vector3 color)
		{
			DrawLine(ref from, ref to, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawLine(ref global::System.Numerics.Vector3 from, ref global::System.Numerics.Vector3 to, ref global::System.Numerics.Vector3 fromColor, ref global::System.Numerics.Vector3 toColor)
		{
			DrawLine(ref from, ref to, ref fromColor);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawAabb(ref global::System.Numerics.Vector3 from, ref global::System.Numerics.Vector3 to, ref global::System.Numerics.Vector3 color)
		{
			global::System.Numerics.Vector3 a = from;
			a.X = to.X;
			DrawLine(ref from, ref a, ref color);

		 	global::System.Numerics.Vector3 b = to;
			b.Y = from.Y;
			DrawLine(ref b, ref to, ref color);
			DrawLine(ref a, ref b, ref color);

		 	global::System.Numerics.Vector3 c = from;
			c.Z = to.Z;
			DrawLine(ref from, ref c, ref color);
			DrawLine(ref b, ref c, ref color);

			b.Y = to.Y;
			b.Z = from.Z;
			DrawLine(ref b, ref to, ref color);
			DrawLine(ref a, ref b, ref color);

			a.Y = to.Y;
			a.X = from.X;
			DrawLine(ref from, ref a, ref color);
			DrawLine(ref a, ref b, ref color);

			b.X = from.X;
			b.Z = to.Z;
			DrawLine(ref c, ref b, ref color);
			DrawLine(ref a, ref b, ref color);
			DrawLine(ref b, ref to, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawArc(ref global::System.Numerics.Vector3 center, ref global::System.Numerics.Vector3 normal, ref global::System.Numerics.Vector3 axis, float radiusA, float radiusB,
			float minAngle, float maxAngle, ref global::System.Numerics.Vector3 color, bool drawSect, float stepDegrees = 10.0f)
		{
			global::System.Numerics.Vector3 xAxis = radiusA * axis;
			global::System.Numerics.Vector3 yAxis = radiusB * global::System.Numerics.Vector3.Cross(normal, axis);
			float step = stepDegrees * MathUtil.SIMD_RADS_PER_DEG;
			int nSteps = (int)((maxAngle - minAngle) / step);
			if (nSteps == 0)
			{
				nSteps = 1;
			}
			global::System.Numerics.Vector3 prev = center + xAxis * (float)global::System.Math.Cos(minAngle) + yAxis * (float)global::System.Math.Sin(minAngle);
			if (drawSect)
			{
				DrawLine(ref center, ref prev, ref color);
			}
			for (int i = 1; i <= nSteps; i++)
			{
				float angle = minAngle + (maxAngle - minAngle) * i / nSteps;
				global::System.Numerics.Vector3 next = center + xAxis * (float)global::System.Math.Cos(angle) + yAxis * (float)global::System.Math.Sin(angle);
				DrawLine(ref prev, ref next, ref color);
				prev = next;
			}
			if (drawSect)
			{
				DrawLine(ref center, ref prev, ref color);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawBox(ref global::System.Numerics.Vector3 bbMin, ref global::System.Numerics.Vector3 bbMax, ref global::System.Numerics.Vector3 color)
		{
			//Vector3 p1 = bbMin;
		 	global::System.Numerics.Vector3 p2 = new global::System.Numerics.Vector3(bbMax.X, bbMin.Y, bbMin.Z);
		 	global::System.Numerics.Vector3 p3 = new global::System.Numerics.Vector3(bbMax.X, bbMax.Y, bbMin.Z);
		 	global::System.Numerics.Vector3 p4 = new global::System.Numerics.Vector3(bbMin.X, bbMax.Y, bbMin.Z);
		 	global::System.Numerics.Vector3 p5 = new global::System.Numerics.Vector3(bbMin.X, bbMin.Y, bbMax.Z);
		 	global::System.Numerics.Vector3 p6 = new global::System.Numerics.Vector3(bbMax.X, bbMin.Y, bbMax.Z);
			//Vector3 p7 = bbMax;
		 	global::System.Numerics.Vector3 p8 = new global::System.Numerics.Vector3(bbMin.X, bbMax.Y, bbMax.Z);

			DrawLine(ref bbMin, ref p2, ref color);
			DrawLine(ref p2, ref p3, ref color);
			DrawLine(ref p3, ref p4, ref color);
			DrawLine(ref p4, ref bbMin, ref color);

			DrawLine(ref bbMin, ref p5, ref color);
			DrawLine(ref p2, ref p6, ref color);
			DrawLine(ref p3, ref bbMax, ref color);
			DrawLine(ref p4, ref p8, ref color);

			DrawLine(ref p5, ref p6, ref color);
			DrawLine(ref p6, ref bbMax, ref color);
			DrawLine(ref bbMax, ref p8, ref color);
			DrawLine(ref p8, ref p5, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawBox(ref global::System.Numerics.Vector3 bbMin, ref global::System.Numerics.Vector3 bbMax, ref Matrix4x4 trans, ref global::System.Numerics.Vector3 color)
		{
		 	global::System.Numerics.Vector3 p1, p2, p3, p4, p5, p6, p7, p8;
		 	global::System.Numerics.Vector3 point = bbMin;
			p1 = global::System.Numerics.Vector3.Transform(point, trans);
			point.X = bbMax.X;
			p2 = global::System.Numerics.Vector3.Transform(point, trans);
			point.Y = bbMax.Y;
			p3 = global::System.Numerics.Vector3.Transform(point, trans);
			point.X = bbMin.X;
			p4 = global::System.Numerics.Vector3.Transform(point, trans);
			point.Z = bbMax.Z;
			p8 = global::System.Numerics.Vector3.Transform(point, trans);
			point.X = bbMax.X;
			p7 = global::System.Numerics.Vector3.Transform(point, trans);
			point.Y = bbMin.Y;
			p6 = global::System.Numerics.Vector3.Transform(point, trans);
			point.X = bbMin.X;
			p5 = global::System.Numerics.Vector3.Transform(point, trans);

			DrawLine(ref p1, ref p2, ref color);
			DrawLine(ref p2, ref p3, ref color);
			DrawLine(ref p3, ref p4, ref color);
			DrawLine(ref p4, ref p1, ref color);

			DrawLine(ref p1, ref p5, ref color);
			DrawLine(ref p2, ref p6, ref color);
			DrawLine(ref p3, ref p7, ref color);
			DrawLine(ref p4, ref p8, ref color);

			DrawLine(ref p5, ref p6, ref color);
			DrawLine(ref p6, ref p7, ref color);
			DrawLine(ref p7, ref p8, ref color);
			DrawLine(ref p8, ref p5, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawCapsule(float radius, float halfHeight, int upAxis, ref Matrix4x4 transform, ref global::System.Numerics.Vector3 color)
		{
			const int stepDegrees = 30;

			void DrawCapsuleCap(ref global::System.Numerics.Vector3 capOffset, ref Matrix4x4 capTransform, ref global::System.Numerics.Vector3 capColor, float axisDirection)
			{
				Matrix4x4 childTransform = capTransform;
				childTransform.Translation = global::System.Numerics.Vector3.Transform(capOffset, capTransform);
				Matrix4x4 childBasis = childTransform.GetBasis();
			 	global::System.Numerics.Vector3 center = childTransform.Translation;
			 	global::System.Numerics.Vector3 up = childBasis.GetColumn((upAxis + 1) % 3);
			 	global::System.Numerics.Vector3 axis = axisDirection * childBasis.GetColumn(upAxis);
				float minTh = -MathUtil.SIMD_HALF_PI;
				float maxTh = MathUtil.SIMD_HALF_PI;
				float minPs = -MathUtil.SIMD_HALF_PI;
				float maxPs = MathUtil.SIMD_HALF_PI;

				DrawSpherePatch(ref center, ref up, ref axis, radius, minTh, maxTh, minPs, maxPs, ref capColor, stepDegrees);
			}

		 	global::System.Numerics.Vector3 capStart = global::System.Numerics.Vector3.Zero;
			capStart.SetComponent(upAxis, -halfHeight);

		 	global::System.Numerics.Vector3 capEnd = global::System.Numerics.Vector3.Zero;
			capEnd.SetComponent(upAxis, halfHeight);

			DrawCapsuleCap(ref capStart, ref transform, ref color, -1);
			DrawCapsuleCap(ref capEnd, ref transform, ref color, 1);

			// Draw some additional lines
		 	global::System.Numerics.Vector3 start = transform.Translation;
			Matrix4x4 basis = transform.GetBasis();
			for (int i = 0; i < 360; i += stepDegrees)
			{
				float primaryDirection = (float)global::System.Math.Sin(i * MathUtil.SIMD_RADS_PER_DEG) * radius;
				float secondaryDirection = (float)global::System.Math.Cos(i * MathUtil.SIMD_RADS_PER_DEG) * radius;
				capEnd.SetComponent((upAxis + 1) % 3, primaryDirection);
				capStart.SetComponent((upAxis + 1) % 3, primaryDirection);
				capEnd.SetComponent((upAxis + 2) % 3, secondaryDirection);
				capStart.SetComponent((upAxis + 2) % 3, secondaryDirection);
				DrawLine(start + global::System.Numerics.Vector3.Transform(capStart, basis), start + global::System.Numerics.Vector3.Transform(capEnd, basis), color);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawCone(float radius, float height, int upAxis, ref Matrix4x4 transform, ref global::System.Numerics.Vector3 color)
		{
		 	global::System.Numerics.Vector3 start = transform.Translation;

		 	global::System.Numerics.Vector3 offsetHeight = global::System.Numerics.Vector3.Zero;
			offsetHeight.SetComponent(upAxis, height * 0.5f);
		 	global::System.Numerics.Vector3 offsetRadius = global::System.Numerics.Vector3.Zero;
			offsetRadius.SetComponent((upAxis + 1) % 3, radius);

		 	global::System.Numerics.Vector3 offset2Radius = global::System.Numerics.Vector3.Zero;
			offsetRadius.SetComponent((upAxis + 2) % 3, radius);

			Matrix4x4 basis = transform.GetBasis();
		 	global::System.Numerics.Vector3 from = start + global::System.Numerics.Vector3.Transform(offsetHeight, basis);
		 	global::System.Numerics.Vector3 to = start + global::System.Numerics.Vector3.Transform(-offsetHeight, basis);
			DrawLine(from, to + offsetRadius, color);
			DrawLine(from, to - offsetRadius, color);
			DrawLine(from, to + offset2Radius, color);
			DrawLine(from, to - offset2Radius, color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawContactPoint(ref global::System.Numerics.Vector3 pointOnB, ref global::System.Numerics.Vector3 normalOnB, float distance, int lifeTime, ref global::System.Numerics.Vector3 color)
		{
		 	global::System.Numerics.Vector3 to = pointOnB + normalOnB * 1; // distance
			DrawLine(ref pointOnB, ref to, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawCylinder(float radius, float halfHeight, int upAxis, ref Matrix4x4 transform, ref global::System.Numerics.Vector3 color)
		{
		 	global::System.Numerics.Vector3 start = transform.Translation;
			Matrix4x4 basis = transform.GetBasis();
		 	global::System.Numerics.Vector3 offsetHeight = global::System.Numerics.Vector3.Zero;
			offsetHeight.SetComponent(upAxis, halfHeight);
		 	global::System.Numerics.Vector3 offsetRadius = global::System.Numerics.Vector3.Zero;
			offsetRadius.SetComponent((upAxis + 1) % 3, radius);
			DrawLine(start + global::System.Numerics.Vector3.Transform(offsetHeight + offsetRadius, basis), start + global::System.Numerics.Vector3.Transform(-offsetHeight + offsetRadius, basis), color);
			DrawLine(start + global::System.Numerics.Vector3.Transform(offsetHeight - offsetRadius, basis), start + global::System.Numerics.Vector3.Transform(-offsetHeight - offsetRadius, basis), color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawPlane(ref global::System.Numerics.Vector3 planeNormal, float planeConst, ref Matrix4x4 transform, ref global::System.Numerics.Vector3 color)
		{
		 	global::System.Numerics.Vector3 planeOrigin = planeNormal * planeConst;
		 	global::System.Numerics.Vector3 vec0, vec1;
			PlaneSpace1(ref planeNormal, out vec0, out vec1);
			const float vecLen = 100f;
		 	global::System.Numerics.Vector3 pt0 = planeOrigin + vec0 * vecLen;
		 	global::System.Numerics.Vector3 pt1 = planeOrigin - vec0 * vecLen;
		 	global::System.Numerics.Vector3 pt2 = planeOrigin + vec1 * vecLen;
		 	global::System.Numerics.Vector3 pt3 = planeOrigin - vec1 * vecLen;
			pt0 = global::System.Numerics.Vector3.Transform(pt0, transform);
			pt1 = global::System.Numerics.Vector3.Transform(pt1, transform);
			pt2 = global::System.Numerics.Vector3.Transform(pt2, transform);
			pt3 = global::System.Numerics.Vector3.Transform(pt3, transform);
			DrawLine(ref pt0, ref pt1, ref color);
			DrawLine(ref pt2, ref pt3, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawSphere(float radius, ref Matrix4x4 transform, ref global::System.Numerics.Vector3 color)
		{
		 	global::System.Numerics.Vector3 start = transform.Translation;
			Matrix4x4 basis = transform.GetBasis();

		 	global::System.Numerics.Vector3 xoffs = global::System.Numerics.Vector3.Transform(new global::System.Numerics.Vector3(radius, 0, 0), basis);
		 	global::System.Numerics.Vector3 yoffs = global::System.Numerics.Vector3.Transform(new global::System.Numerics.Vector3(0, radius, 0), basis);
		 	global::System.Numerics.Vector3 zoffs = global::System.Numerics.Vector3.Transform(new global::System.Numerics.Vector3(0, 0, radius), basis);

			global::System.Numerics.Vector3 xn = start - xoffs;
		 	global::System.Numerics.Vector3 xp = start + xoffs;
		 	global::System.Numerics.Vector3 yn = start - yoffs;
		 	global::System.Numerics.Vector3 yp = start + yoffs;
		 	global::System.Numerics.Vector3 zn = start - zoffs;
		 	global::System.Numerics.Vector3 zp = start + zoffs;

			// XY
			DrawLine(ref xn, ref yp, ref color);
			DrawLine(ref yp, ref xp, ref color);
			DrawLine(ref xp, ref yn, ref color);
			DrawLine(ref yn, ref xn, ref color);

			// XZ
			DrawLine(ref xn, ref zp, ref color);
			DrawLine(ref zp, ref xp, ref color);
			DrawLine(ref xp, ref zn, ref color);
			DrawLine(ref zn, ref xn, ref color);

			// YZ
			DrawLine(ref yn, ref zp, ref color);
			DrawLine(ref zp, ref yp, ref color);
			DrawLine(ref yp, ref zn, ref color);
			DrawLine(ref zn, ref yn, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawSphere(ref global::System.Numerics.Vector3 p, float radius, ref global::System.Numerics.Vector3 color)
		{
			Matrix4x4 tr = Matrix4x4.CreateTranslation(p);
			DrawSphere(radius, ref tr, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawSpherePatch(ref global::System.Numerics.Vector3 center, ref global::System.Numerics.Vector3 up, ref global::System.Numerics.Vector3 axis, float radius,
			float minTh, float maxTh, float minPs, float maxPs, ref global::System.Numerics.Vector3 color)
		{
			DrawSpherePatch(ref center, ref up, ref axis, radius, minTh, maxTh, minPs, maxPs, ref color, 10.0f);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawSpherePatch(ref global::System.Numerics.Vector3 center, ref global::System.Numerics.Vector3 up, ref global::System.Numerics.Vector3 axis, float radius,
			float minTh, float maxTh, float minPs, float maxPs, ref global::System.Numerics.Vector3 color, float stepDegrees)
		{
		 	global::System.Numerics.Vector3[] vA;
		 	global::System.Numerics.Vector3[] vB;
		 	global::System.Numerics.Vector3[] pvA, pvB, pT;
		 	global::System.Numerics.Vector3 npole = center + up * radius;
		 	global::System.Numerics.Vector3 spole = center - up * radius;
		 	global::System.Numerics.Vector3 arcStart = global::System.Numerics.Vector3.Zero;
			float step = stepDegrees * MathUtil.SIMD_RADS_PER_DEG;
		 	global::System.Numerics.Vector3 kv = up;
		 	global::System.Numerics.Vector3 iv = axis;

		 	global::System.Numerics.Vector3 jv = global::System.Numerics.Vector3.Cross(kv, iv);
			bool drawN = false;
			bool drawS = false;
			if (minTh <= -MathUtil.SIMD_HALF_PI)
			{
				minTh = -MathUtil.SIMD_HALF_PI + step;
				drawN = true;
			}
			if (maxTh >= MathUtil.SIMD_HALF_PI)
			{
				maxTh = MathUtil.SIMD_HALF_PI - step;
				drawS = true;
			}
			if (minTh > maxTh)
			{
				minTh = -MathUtil.SIMD_HALF_PI + step;
				maxTh = MathUtil.SIMD_HALF_PI - step;
				drawN = drawS = true;
			}
			int n_hor = (int)((maxTh - minTh) / step) + 1;
			if (n_hor < 2) n_hor = 2;
			float step_h = (maxTh - minTh) / (n_hor - 1);
			bool isClosed;
			if (minPs > maxPs)
			{
				minPs = -MathUtil.SIMD_PI + step;
				maxPs = MathUtil.SIMD_PI;
				isClosed = true;
			}
			else if ((maxPs - minPs) >= MathUtil.SIMD_PI * 2f)
			{
				isClosed = true;
			}
			else
			{
				isClosed = false;
			}
			int n_vert = (int)((maxPs - minPs) / step) + 1;
			if (n_vert < 2) n_vert = 2;

			vA = new global::System.Numerics.Vector3[n_vert];
			vB = new global::System.Numerics.Vector3[n_vert];
			pvA = vA; pvB = vB;

			float step_v = (maxPs - minPs) / (float)(n_vert - 1);
			for (int i = 0; i < n_hor; i++)
			{
				float th = minTh + i * step_h;
				float sth = radius * (float)global::System.Math.Sin(th);
				float cth = radius * (float)global::System.Math.Cos(th);
				for (int j = 0; j < n_vert; j++)
				{
					float psi = minPs + (float)j * step_v;
					float sps = (float)global::System.Math.Sin(psi);
					float cps = (float)global::System.Math.Cos(psi);
					pvB[j] = center + cth * cps * iv + cth * sps * jv + sth * kv;
					if (i != 0)
					{
						DrawLine(ref pvA[j], ref pvB[j], ref color);
					}
					else if (drawS)
					{
						DrawLine(ref spole, ref pvB[j], ref color);
					}
					if (j != 0)
					{
						DrawLine(ref pvB[j - 1], ref pvB[j], ref color);
					}
					else
					{
						arcStart = pvB[j];
					}
					if ((i == (n_hor - 1)) && drawN)
					{
						DrawLine(ref npole, ref pvB[j], ref color);
					}
					if (isClosed)
					{
						if (j == (n_vert - 1))
						{
							DrawLine(ref arcStart, ref pvB[j], ref color);
						}
					}
					else
					{
						if (((i == 0) || (i == (n_hor - 1))) && ((j == 0) || (j == (n_vert - 1))))
						{
							DrawLine(ref center, ref pvB[j], ref color);
						}
					}
				}
				pT = pvA; pvA = pvB; pvB = pT;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawTriangle(ref global::System.Numerics.Vector3 v0, ref global::System.Numerics.Vector3 v1, ref global::System.Numerics.Vector3 v2, ref global::System.Numerics.Vector3 n0, ref global::System.Numerics.Vector3 n1, ref global::System.Numerics.Vector3 n2, ref global::System.Numerics.Vector3 color, float alpha)
		{
			DrawTriangle(ref v0, ref v1, ref v2, ref color, alpha);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawTriangle(ref global::System.Numerics.Vector3 v0, ref global::System.Numerics.Vector3 v1, ref global::System.Numerics.Vector3 v2, ref global::System.Numerics.Vector3 color, float alpha)
		{
			DrawLine(ref v0, ref v1, ref color);
			DrawLine(ref v1, ref v2, ref color);
			DrawLine(ref v2, ref v0, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DrawTransform(ref Matrix4x4 transform, float orthoLen)
		{
		 	global::System.Numerics.Vector3 start = transform.Translation;
			Matrix4x4 basis = transform.GetBasis();

		 	global::System.Numerics.Vector3 ortho = new global::System.Numerics.Vector3(orthoLen, 0, 0);
		 	global::System.Numerics.Vector3 colour = new global::System.Numerics.Vector3(0.7f, 0, 0);
			global::System.Numerics.Vector3 temp = global::System.Numerics.Vector3.Transform(ortho, basis);
			temp += start;
			DrawLine(ref start, ref temp, ref colour);

			ortho.X = 0;
			ortho.Y = orthoLen;
			colour.X = 0;
			colour.Y = 0.7f;
			temp = global::System.Numerics.Vector3.Transform(ortho, basis);
			temp += start;
			DrawLine(ref start, ref temp, ref colour);

			ortho.Y = 0;
			ortho.Z = orthoLen;
			colour.Y = 0;
			colour.Z = 0.7f;
			temp = global::System.Numerics.Vector3.Transform(ortho, basis);
			temp += start;
			DrawLine(ref start, ref temp, ref colour);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void PlaneSpace1(ref global::System.Numerics.Vector3 n, out global::System.Numerics.Vector3 p, out global::System.Numerics.Vector3 q)
		{
			if (global::System.Math.Abs(n.Z) > MathUtil.SIMDSQRT12)
			{
				// choose p in y-z plane
				float a = n.Y * n.Y + n.Z * n.Z;
				float k = MathUtil.RecipSqrt(a);
				p = new global::System.Numerics.Vector3(0, -n.Z * k, n.Y * k);
				// set q = n x p
				q = new global::System.Numerics.Vector3(a * k, -n.X * p.Z, n.X * p.Y);
			}
			else
			{
				// choose p in x-y plane
				float a = n.X * n.X + n.Y * n.Y;
				float k = MathUtil.RecipSqrt(a);
				p = new global::System.Numerics.Vector3(-n.Y * k, n.X * k, 0);
				// set q = n x p
				q = new global::System.Numerics.Vector3(-n.Z * p.Y, n.Z * p.X, a * k);
			}
		}

		protected override void Dispose(bool disposing)
		{
			btIDebugDraw_delete(Native);
		}
	}
}
