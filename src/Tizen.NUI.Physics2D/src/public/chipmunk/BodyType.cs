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

using System.ComponentModel;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Chipmunk supports three different types of bodies with unique behavioral and performance
    /// characteristics.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BodyType
    {
        /// <summary>
        /// Dynamic bodies are the default body type. They react to collisions, are affected by
        /// forces and gravity, and have a finite amount of mass. These are the type of bodies that
        /// you want the physics engine to simulate for you. Dynamic bodies interact with all types
        /// of bodies and can generate collision callbacks.
        /// </summary>
        Dynamic,

        /// <summary>
        /// Kinematic bodies are bodies that are controlled from your code instead of from the
        /// physics engine. They aren't affected by gravity and they have an infinite amount of
        /// mass, so they don’t react to collisions or forces with other bodies. Kinematic bodies
        /// are controlled by setting their velocity, which will cause them to move. Good examples
        /// of kinematic bodies might include things like moving platforms. Objects that are
        /// touching or jointed to a kinematic body are never allowed to fall asleep.
        /// </summary>
        Kinematic,

        /// <summary>
        /// Static bodies are bodies that never (or rarely) move. Using static bodies for things
        /// like terrain offers a big performance boost over other body types -- Chipmunk doesn't
        /// need to check for collisions between static objects and it never needs to update their
        /// collision information. Additionally, because static bodies don’t move, Chipmunk knows
        /// it’s safe to let objects that are touching or jointed to them fall asleep. Generally,
        /// all of your level geometry will be attached to a static body, except for things like
        /// moving platforms or doors. Every space provides a built-in static body for your
        /// convenience. Static bodies can be moved, but there is a performance penalty as the
        /// collision information is recalculated. There is no penalty for having multiple static
        /// bodies, and it can be useful in simplifying your code to allow different parts of your
        /// static geometry to be initialized or moved separately.
        /// </summary>
        Static
    }
}
