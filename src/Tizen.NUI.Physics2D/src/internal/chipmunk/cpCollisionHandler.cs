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
using cpCollisionFunction = System.IntPtr;
using cpCollisionHandlerPointer = System.IntPtr;
using cpCollisionType = System.UIntPtr;
using cpDataPointer = System.IntPtr;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Struct that holds function callback pointers to configure custom collision handling.
    /// Collision handlers have a pair of types;
    /// when a collision occurs between two shapes that have these types, the collision handler functions are triggered.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct cpCollisionHandler
    {
        /// <summary>
        /// Collision type identifier of the first shape that this handler recognizes.
        /// In the collision handler callback, the shape with this type will be the first argument. Read only.
        /// </summary>
        public cpCollisionType typeA;

        /// <summary>
        /// Collision type identifier of the second shape that this handler recognizes.
        /// In the collision handler callback, the shape with this type will be the second argument. Read only.
        /// </summary>
        public cpCollisionType typeB;

        /// <summary>
        /// This function is called when two shapes with types that match this collision handler begin colliding.
        /// </summary>
        public cpCollisionFunction beginFunction;

        /// <summary>
        /// This function is called each step when two shapes with types that match this collision handler are colliding.
        /// It's called before the collision solver runs so that you can affect a collision's outcome.
        /// </summary>
        public cpCollisionFunction preSolveFunction;

        /// <summary>
        /// This function is called each step when two shapes with types that match this collision handler are colliding.
        /// It's called after the collision solver runs so that you can read back information about the collision to trigger events in your game.
        /// </summary>
        public cpCollisionFunction postSolveFunction;

        /// <summary>
        /// This function is called when two shapes with types that match this collision handler stop colliding.
        /// </summary>
        public cpCollisionFunction separateFunction;

        /// <summary>
        /// This is a user definable context pointer that is passed to all of the collision handler functions.
        /// </summary>
        public cpDataPointer userData;

        public static cpCollisionHandler FromHandle(cpCollisionHandlerPointer handle)
        {
            return Marshal.PtrToStructure<cpCollisionHandler>(handle);
        }

        internal static void ToPointer(cpCollisionHandler handler, cpCollisionFunction handle)
        {
            Marshal.StructureToPtr(handler, handle, false);
        }
    }
}
