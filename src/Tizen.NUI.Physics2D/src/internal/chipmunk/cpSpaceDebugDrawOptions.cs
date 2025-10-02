/*
 * Copyright (c) 2023 Codefoco (codefoco@codefoco.com)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Runtime.InteropServices;
using cpDataPointer = System.IntPtr;
using cpShape = System.IntPtr;
using cpSpaceDebugDrawCircleImpl = System.IntPtr;
using cpSpaceDebugDrawColorForShapeImpl = System.IntPtr;
using cpSpaceDebugDrawDotImpl = System.IntPtr;
using cpSpaceDebugDrawFatSegmentImpl = System.IntPtr;
using cpSpaceDebugDrawFlags = System.Int32;
using cpSpaceDebugDrawPolygonImpl = System.IntPtr;
using cpSpaceDebugDrawSegmentImpl = System.IntPtr;
using cpVertPointer = System.IntPtr;
using voidptr_t = System.IntPtr;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
using ObjCRuntime;
#endif

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Struct used with Space.DebugDraw() containing drawing callbacks and other drawing settings.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct cpSpaceDebugDrawOptions
    {
        /// <summary>
        /// Function that will be invoked to draw circles.
        /// </summary>
        cpSpaceDebugDrawCircleImpl drawCircle;

        /// <summary>
        /// Function that will be invoked to draw line segments.
        /// </summary>
        cpSpaceDebugDrawSegmentImpl drawSegment;

        /// <summary>
        /// Function that will be invoked to draw thick line segments.
        /// </summary>
        cpSpaceDebugDrawFatSegmentImpl drawFatSegment;

        /// <summary>
        /// Function that will be invoked to draw convex polygons.
        /// </summary>
        cpSpaceDebugDrawPolygonImpl drawPolygon;

        /// <summary>
        /// Function that will be invoked to draw dots.
        /// </summary>
        cpSpaceDebugDrawDotImpl drawDot;

        /// <summary>
        /// Flags that request which things to draw (collision shapes, constraints, contact points).
        /// </summary>
        cpSpaceDebugDrawFlags flags;

        /// <summary>
        /// Outline color passed to the drawing function.
        /// </summary>
        DebugColor shapeOutlineColor;

        /// <summary>
        /// Function that decides what fill color to draw shapes using.
        /// </summary>
        cpSpaceDebugDrawColorForShapeImpl colorForShape;

        /// <summary>
        /// Color passed to drawing functions for constraints.
        /// </summary>
        DebugColor constraintColor;

        /// <summary>
        /// Color passed to drawing functions for collision points.
        /// </summary>
        DebugColor collisionPointColor;

        /// <summary>
        /// User defined context pointer passed to all of the callback functions as the 'data' argument.
        /// </summary>
        cpDataPointer data;

        private IntPtr ToPointer()
        {
            IntPtr drawOptionsPtr = NativeInterop.AllocStructure<cpSpaceDebugDrawOptions>();

            Marshal.StructureToPtr<cpSpaceDebugDrawOptions>(this, drawOptionsPtr, false);

            return drawOptionsPtr;
        }


#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(SpaceDebugDrawCircleImpl))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void SpaceDebugDrawCircleCallback(Vect pos, double angle, double radius, DebugColor outlineColor, DebugColor fillColor, voidptr_t data)
        {
            IDebugDraw debugDraw = NativeInterop.FromIntPtr<IDebugDraw>(data);

            debugDraw.DrawCircle(pos, angle, radius, outlineColor, fillColor);
        }

        private static SpaceDebugDrawCircleImpl spaceDebugDrawCircleCallback = SpaceDebugDrawCircleCallback;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(SpaceDebugDrawSegmentImpl))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void SpaceDebugDrawSegmentCallback(Vect a, Vect b, DebugColor color, voidptr_t data)
        {
            IDebugDraw debugDraw = NativeInterop.FromIntPtr<IDebugDraw>(data);

            debugDraw.DrawSegment(a, b, color);
        }

        private static SpaceDebugDrawSegmentImpl spaceDebugDrawSegmentCallback = SpaceDebugDrawSegmentCallback;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(SpaceDebugDrawFatSegmentImpl))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void SpaceDebugDrawFatSegmentCallback(Vect a, Vect b, double radius, DebugColor outlineColor, DebugColor fillColor, voidptr_t data)
        {
            IDebugDraw debugDraw = NativeInterop.FromIntPtr<IDebugDraw>(data);

            debugDraw.DrawFatSegment(a, b, radius, outlineColor, fillColor);
        }

        private static SpaceDebugDrawFatSegmentImpl spaceDebugDrawFatSegmentCallback = SpaceDebugDrawFatSegmentCallback;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(SpaceDebugDrawPolygonImpl))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void SpaceDebugDrawPolygonCallback(int count, cpVertPointer verts, double radius, DebugColor outlineColor, DebugColor fillColor, voidptr_t data)
        {
            IDebugDraw debugDraw = NativeInterop.FromIntPtr<IDebugDraw>(data);

            Vect[] vectors = NativeInterop.PtrToStructureArray<Vect>(verts, count);

            debugDraw.DrawPolygon(vectors, radius, outlineColor, fillColor);
        }

        private static SpaceDebugDrawPolygonImpl spaceDebugDrawPolygonCallback = SpaceDebugDrawPolygonCallback;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(SpaceDebugDrawDotImpl))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void SpaceDebugDrawDotCallback(double size, Vect pos, DebugColor color, voidptr_t data)
        {
            IDebugDraw debugDraw = NativeInterop.FromIntPtr<IDebugDraw>(data);

            debugDraw.DrawDot(size, pos, color);
        }

        private static SpaceDebugDrawDotImpl spaceDebugDrawDotCallback = SpaceDebugDrawDotCallback;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(SpaceDebugDrawColorForShapeImpl))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static DebugColor SpaceDebugDrawColorForShapeCallback(cpShape handleShape, voidptr_t data)
        {
            IDebugDraw debugDraw = NativeInterop.FromIntPtr<IDebugDraw>(data);
            var shape = Shape.FromHandle(handleShape);

            return debugDraw.ColorForShape(shape);
        }

        private static SpaceDebugDrawColorForShapeImpl spaceDebugDrawColorForShapeCallback = SpaceDebugDrawColorForShapeCallback;


        public IntPtr AcquireDebugDrawOptions(IDebugDraw debugDraw, DebugDrawFlags flags, DebugDrawColors colors)
        {
            this.flags = (int)flags;
            collisionPointColor = colors.CollisionPoint;
            constraintColor = colors.Constraint;
            shapeOutlineColor = colors.ShapeOutline;

            drawCircle = spaceDebugDrawCircleCallback.ToFunctionPointer();
            drawSegment = spaceDebugDrawSegmentCallback.ToFunctionPointer();
            drawFatSegment = spaceDebugDrawFatSegmentCallback.ToFunctionPointer();
            drawPolygon = spaceDebugDrawPolygonCallback.ToFunctionPointer();
            drawDot = spaceDebugDrawDotCallback.ToFunctionPointer();
            colorForShape = spaceDebugDrawColorForShapeCallback.ToFunctionPointer();

            data = NativeInterop.RegisterHandle(debugDraw);

            return ToPointer();
        }

        public void ReleaseDebugDrawOptions(IntPtr debugDrawOptionsPointer)
        {
            NativeInterop.ReleaseHandle(data);
            NativeInterop.FreeStructure(debugDrawOptionsPointer);
        }
    }
}
