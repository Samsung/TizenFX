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
using System.Collections.Generic;
using System.ComponentModel;
using cpArbiter = System.IntPtr;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// The <see cref="Arbiter"/> object encapsulates a pair of colliding shapes and all of the data
    /// about their collision.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Arbiter : IEquatable<Arbiter>
    {
#pragma warning disable IDE0032
        readonly cpArbiter arbiter;
#pragma warning restore IDE0032

        /// <summary>
        /// Native handle of <see cref="Arbiter"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public cpArbiter Handle => arbiter;

        internal Arbiter(cpArbiter handle)
        {
            arbiter = handle;
        }

        /// <summary>
        /// The restitution (elasticity) that will be applied to the pair of colliding objects.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Restitution
        {
            get => NativeMethods.cpArbiterGetRestitution(arbiter);
            set => NativeMethods.cpArbiterSetRestitution(arbiter, value);
        }

        /// <summary>
        /// Friction coefficient that will be applied to the pair of colliding objects.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Friction
        {
            get => NativeMethods.cpArbiterGetFriction(arbiter);
            set => NativeMethods.cpArbiterSetFriction(arbiter, value);
        }

        /// <summary>
        /// The relative surface velocity of the two shapes in contact.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect SurfaceVelocity
        {
            get => NativeMethods.cpArbiterGetSurfaceVelocity(arbiter);
            set => NativeMethods.cpArbiterSetSurfaceVelocity(arbiter, value);
        }

        /// <summary>
        /// Calculate the total impulse including the friction that was applied by this arbiter.
        /// This function should only be called from a post-solve, post-step or cpBodyEachArbiter
        /// callback.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect TotalImpulse => NativeMethods.cpArbiterTotalImpulse(arbiter);

        /// <summary>
        /// Calculate the amount of energy lost in a collision including static, but not dynamic friction.
        /// This function should only be called from a post-solve, post-step or cpBodyEachArbiter callback.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double TotalKE => NativeMethods.cpArbiterTotalKE(arbiter);

        /// <summary>
        /// Mark a collision pair to be ignored until the two objects separate. Pre-solve and
        /// post-solve callbacks will not be called, but the separate callback will be called.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Ignore() => NativeMethods.cpArbiterIgnore(arbiter) != 0;

        /// <summary>
        /// Return the colliding shapes involved for this arbiter. The order of their
        /// <see cref="Shape.CollisionType"/> values will match the order set when the collision
        /// handler was registered.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetShapes(out Shape a, out Shape b)
        {
            IntPtr ptrA;
            IntPtr ptrB;

            NativeMethods.cpArbiterGetShapes(arbiter, out ptrA, out ptrB);

            a = Shape.FromHandle(ptrA);
            b = Shape.FromHandle(ptrB);
        }

        /// <summary>
        /// Return the colliding bodies involved for this arbiter. The order of the
        /// <see cref="Shape.CollisionType"/> values the bodies are associated with will match the
        /// order set when the collision handler was registered.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetBodies(out Body a, out Body b)
        {
            IntPtr ptrA;
            IntPtr ptrB;

            NativeMethods.cpArbiterGetBodies(arbiter, out ptrA, out ptrB);

            a = Body.FromHandle(ptrA);
            b = Body.FromHandle(ptrB);
        }

        /// <summary>
        /// The contact point set for an arbiter. This can be a very powerful feature, but use it
        /// with caution!
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContactPointSet ContactPointSet
        {
            get
            {
                cpContactPointSet pointSet = NativeMethods.cpArbiterGetContactPointSet(arbiter);
                return ContactPointSet.FromContactPointSet(pointSet);
            }
            set
            {
                cpContactPointSet pointSet = value.ToContactPointSet();
                NativeMethods.cpArbiterSetContactPointSet(arbiter, ref pointSet);
            }
        }

        /// <summary>
        /// Arbitrary user data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Data
        {
            get
            {
                IntPtr handle = NativeMethods.cpArbiterGetUserData(arbiter);

                if (handle == IntPtr.Zero)
                {
                    return null;
                }

                return NativeInterop.FromIntPtrAndFree<object>(handle);
            }
            set
            {
                var gcHandle = IntPtr.Zero;

                if (value != null)
                {
                    gcHandle = NativeInterop.RegisterHandle(value);
                }

                NativeMethods.cpArbiterSetUserData(arbiter, gcHandle);
            }
        }

        /// <summary>
        /// Returns true if this is the first step a pair of objects started colliding.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFirstContact => NativeMethods.cpArbiterIsFirstContact(arbiter) != 0;

        /// <summary>
        /// Returns true if the separate callback is due to a shape being removed from the space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsRemoval => NativeMethods.cpArbiterIsRemoval(arbiter) != 0;

        /// <summary>
        /// Get the number of contact points for this arbiter.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count => NativeMethods.cpArbiterGetCount(arbiter);

        /// <summary>
        /// Get the normal of the collision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Normal => NativeMethods.cpArbiterGetNormal(arbiter);

        /// <summary>
        /// Get the position of the <paramref name="i"/>th contact point on the surface of the first
        /// shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect GetPointA(int i)
        {
            return NativeMethods.cpArbiterGetPointA(arbiter, i);
        }

        /// <summary>
        /// Get the position of the <paramref name="i"/>th contact point on the surface of the
        /// second shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect GetPointB(int i)
        {
            return NativeMethods.cpArbiterGetPointB(arbiter, i);
        }

        /// <summary>
        /// Get the depth (amount of overlap) of the <paramref name="i"/>th contact point.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double GetDepth(int i)
        {
            return NativeMethods.cpArbiterGetDepth(arbiter, i);
        }

        /// <summary>
        /// If you want a custom callback to invoke the wildcard callback for the first collision
        /// type, you must call this function explicitly. You must decide how to handle the
        /// wildcard's return value since it may disagree with the other wildcard handler's return
        /// value or your own.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CallWildcardBeginA(Space space)
        {
            NativeMethods.cpArbiterCallWildcardBeginA(arbiter, space.Handle);
        }

        /// <summary>
        /// If you want a custom callback to invoke the wildcard callback for the second collision
        /// type, you must call this function explicitly. You must decide how to handle the
        /// wildcard's return value since it may disagree with the other wildcard handler's return
        /// value or your own.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CallWildcardBeginB(Space space)
        {
            NativeMethods.cpArbiterCallWildcardBeginB(arbiter, space.Handle);
        }

        /// <summary>
        /// If you want a custom callback to invoke the wildcard callback for the first collision
        /// type, you must call this function explicitly. You must decide how to handle the
        /// wildcard's return value since it may disagree with the other wildcard handler's return
        /// value or your own.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CallWildcardPreSolveA(Space space)
        {
            return NativeMethods.cpArbiterCallWildcardPreSolveA(arbiter, space.Handle) != 0;
        }

        /// <summary>
        /// If you want a custom callback to invoke the wildcard callback for the second collision
        /// type, you must call this function explicitly. You must decide how to handle the
        /// wildcard's return value since it may disagree with the other wildcard handler's return
        /// value or your own.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CallWildcardPreSolveB(Space space)
        {
            return NativeMethods.cpArbiterCallWildcardPreSolveB(arbiter, space.Handle) != 0;
        }

        /// <summary>
        /// If you want a custom callback to invoke the wildcard callback for the first collision
        /// type, you must call this function explicitly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CallWildcardPostSolveA(Space space)
        {
            NativeMethods.cpArbiterCallWildcardPostSolveA(arbiter, space.Handle);
        }

        /// <summary>
        /// If you want a custom callback to invoke the wildcard callback for the second collision
        /// type, you must call this function explicitly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CallWildcardPostSolveB(Space space)
        {
            NativeMethods.cpArbiterCallWildcardPostSolveB(arbiter, space.Handle);
        }

        /// <summary>
        /// If you want a custom callback to invoke the wildcard callback for the first collision
        /// type, you must call this function explicitly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CallWildcardSeparateA(Space space)
        {
            NativeMethods.cpArbiterCallWildcardSeparateA(arbiter, space.Handle);
        }

        /// <summary>
        /// If you want a custom callback to invoke the wildcard callback for the second collision
        /// type, you must call this function explicitly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CallWildcardSeparateB(Space space)
        {
            NativeMethods.cpArbiterCallWildcardSeparateB(arbiter, space.Handle);
        }

        /// <summary>
        /// Return true if an arbiter is equal to another.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(Arbiter other)
        {
            return arbiter == other.arbiter;
        }

        /// <summary>
        /// Check if an arbiter is equal to the given object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            var other = obj as Arbiter?;

            if (other == null)
                return false;

            return Equals(other.Value);
        }

        /// <summary>
        /// Return the arbiter's handle prefixed by 'Handle: '.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return $"Handle: {arbiter}";
        }

        /// <summary>
        /// Get the hash code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return 932982278 + EqualityComparer<cpArbiter>.Default.GetHashCode(arbiter);
        }

        /// <summary>
        /// Check if one arbiter is equal to another.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Arbiter left, Arbiter right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Check if one arbiter is inequal to another.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Arbiter left, Arbiter right)
        {
            return !(left == right);
        }
    }
}
