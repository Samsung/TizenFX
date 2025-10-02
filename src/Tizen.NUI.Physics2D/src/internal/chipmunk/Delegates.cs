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

using System.Runtime.InteropServices;
using System.Security;
using cpArbiter = System.IntPtr;
using cpBody = System.IntPtr;
using cpBool = System.Byte;
using cpConstraint = System.IntPtr;
using cpContactPointSetPointer = System.IntPtr;
using cpHandle = System.IntPtr;
using cpShape = System.IntPtr;
using cpSpace = System.IntPtr;
using cpVertPointer = System.IntPtr;
using voidptr_t = System.IntPtr;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
using ObjCRuntime;
#endif

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Delegate method to iterate over arbiters.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void BodyArbiterIteratorFunction(cpBody body, cpArbiter arbiter, voidptr_t data);

    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void BodyVelocityFunction(cpBody body, Vect gravity, double damping, double dt);

    /// <summary>
    /// Rigid body position update function type.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void BodyPositionFunction(cpBody body, double dt);

    /// <summary>
    /// Delegate method to iterate over constraints.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void BodyConstraintIteratorFunction(cpBody body, cpConstraint constraint, voidptr_t data);

    /// <summary>
    /// Delegate method to iterate over shapes.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void BodyShapeIteratorFunction(cpBody body, cpShape shape, voidptr_t data);

    /// <summary>
    /// Collision begin event function callback type. Returning false from a begin callback causes
    /// the collision to be ignored until the the separate callback is called when the objects stop
    /// colliding.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void CollisionBeginFunction(cpArbiter arbiter, cpSpace space, voidptr_t userData);

    /// <summary>
    /// Collision pre-solve event function callback type. Returning false from a pre-step callback
    /// causes the collision to be ignored until the next step.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate cpBool CollisionPreSolveFunction(cpArbiter arbiter, cpSpace space, voidptr_t userData);

    /// <summary>
    /// Collision Post-Solve .
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void CollisionPostSolveFunction(cpArbiter arbiter, cpSpace space, voidptr_t userData);

    /// <summary>
    /// Collision separate event function callback type.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void CollisionSeparateFunction(cpArbiter arbiter, cpSpace space, voidptr_t userData);

    /// <summary>
    /// Post Step callback function type.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void PostStepFunction(cpSpace space, voidptr_t key, voidptr_t data);

    /// <summary>
    /// Nearest point query callback function type.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpacePointQueryFunction(cpShape shape, Vect point, double distance, Vect gradient, voidptr_t data);

    /// <summary>
    /// Segment query callback function type.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpaceSegmentQueryFunction(cpShape shape, Vect point, Vect normal, double alpha, voidptr_t data);

    /// <summary>
    /// Rectangle Query callback function type.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpaceBBQueryFunction(cpShape shape, voidptr_t data);

    /// <summary>
    /// Space/object iterator callback function type.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpaceObjectIteratorFunction(cpHandle handle, voidptr_t data);

    /// <summary>
    /// Callback type for a function that draws a filled, stroked circle.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpaceDebugDrawCircleImpl(Vect pos, double angle, double radius, DebugColor outlineColor, DebugColor fillColor, voidptr_t data);

    /// <summary>
    /// Callback type for a function that draws a line segment.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpaceDebugDrawSegmentImpl(Vect a, Vect b, DebugColor color, voidptr_t data);

    /// <summary>
    /// Callback type for a function that draws a thick line segment.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpaceDebugDrawFatSegmentImpl(Vect a, Vect b, double radius, DebugColor outlineColor, DebugColor fillColor, voidptr_t data);

    /// <summary>
    /// Callback type for a function that draws a convex polygon.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpaceDebugDrawPolygonImpl(int count, cpVertPointer verts, double radius, DebugColor outlineColor, DebugColor fillColor, voidptr_t data);

    /// <summary>
    /// Callback type for a function that draws a dot.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpaceDebugDrawDotImpl(double size, Vect pos, DebugColor color, voidptr_t data);

    /// <summary>
    /// Callback type for a function that returns a color for a given shape. This gives you an
    /// opportunity to color shapes based on how they are used in your engine.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate DebugColor SpaceDebugDrawColorForShapeImpl(cpShape shape, voidptr_t data);

    /// <summary>
    /// Callback function type that gets called after/before solving a joint.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void ConstraintSolveFunction(cpConstraint constraint, cpSpace space);

    /// <summary>
    /// Function type used for damped spring force callbacks.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate double DampedSpringForceFunction(cpConstraint spring, double dist);

    /// <summary>
    /// Function type used for damped rotary spring force callbacks
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate double DampedRotarySpringTorqueFunction(cpConstraint spring, double relativeAngle);

    /// <summary>
    /// Shape query callback function type.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void SpaceShapeQueryFunction(cpShape shape, cpContactPointSetPointer points, voidptr_t data);

    /// <summary>
    /// Function type used as a callback from the marching squares algorithm to output a line
    /// segment. It passes you the two endpoints and your context pointer.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate void MarchSegmentFunction(Vect v0, Vect v1, voidptr_t data);

    /// <summary>
    /// Function type used as a callback from the marching squares algorithm to sample an image function.
    /// It passes you the point to sample and your context pointer, and you return the density.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    [MonoNativeFunctionWrapper]
#endif
    internal delegate double MarchSampleFunction(Vect point, voidptr_t data);
}
