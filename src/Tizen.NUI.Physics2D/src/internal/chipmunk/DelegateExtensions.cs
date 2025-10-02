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

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Create a ToFunctionPointer extension method for each delegate type. Unfortunately C# 7.0
    /// can't do something like that (you will need C# 7.3), thus we create one extension method for
    /// each delegate public static IntPtr ToFunctionPointer T (this T d) where T : Delegate
    /// </summary>
    static internal class DelegateExtensions
    {
        public static IntPtr ToFunctionPointer(this BodyArbiterIteratorFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<BodyArbiterIteratorFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this BodyConstraintIteratorFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<BodyConstraintIteratorFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this BodyShapeIteratorFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<BodyShapeIteratorFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this BodyVelocityFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<BodyVelocityFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this BodyPositionFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<BodyPositionFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this CollisionBeginFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<CollisionBeginFunction>(d);
        }


        public static IntPtr ToFunctionPointer(this CollisionPreSolveFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<CollisionPreSolveFunction>(d);
        }


        public static IntPtr ToFunctionPointer(this CollisionPostSolveFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<CollisionPostSolveFunction>(d);
        }


        public static IntPtr ToFunctionPointer(this CollisionSeparateFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<CollisionSeparateFunction>(d);
        }


        public static IntPtr ToFunctionPointer(this PostStepFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<PostStepFunction>(d);
        }


        public static IntPtr ToFunctionPointer(this SpaceSegmentQueryFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceSegmentQueryFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this SpacePointQueryFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpacePointQueryFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this SpaceBBQueryFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceBBQueryFunction>(d);
        }


        public static IntPtr ToFunctionPointer(this SpaceObjectIteratorFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceObjectIteratorFunction>(d);
        }


        public static IntPtr ToFunctionPointer(this SpaceDebugDrawCircleImpl d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceDebugDrawCircleImpl>(d);
        }


        public static IntPtr ToFunctionPointer(this SpaceDebugDrawSegmentImpl d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceDebugDrawSegmentImpl>(d);
        }

        public static IntPtr ToFunctionPointer(this SpaceDebugDrawFatSegmentImpl d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceDebugDrawFatSegmentImpl>(d);
        }

        public static IntPtr ToFunctionPointer(this SpaceDebugDrawPolygonImpl d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceDebugDrawPolygonImpl>(d);
        }

        public static IntPtr ToFunctionPointer(this SpaceDebugDrawDotImpl d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceDebugDrawDotImpl>(d);
        }

        public static IntPtr ToFunctionPointer(this SpaceDebugDrawColorForShapeImpl d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceDebugDrawColorForShapeImpl>(d);
        }


        public static IntPtr ToFunctionPointer(this ConstraintSolveFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<ConstraintSolveFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this DampedSpringForceFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<DampedSpringForceFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this DampedRotarySpringTorqueFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<DampedRotarySpringTorqueFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this SpaceShapeQueryFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<SpaceShapeQueryFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this MarchSegmentFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<MarchSegmentFunction>(d);
        }

        public static IntPtr ToFunctionPointer(this MarchSampleFunction d)
        {
            if (d == null)
            {
                return IntPtr.Zero;
            }

            return Marshal.GetFunctionPointerForDelegate<MarchSampleFunction>(d);
        }
    }
}
