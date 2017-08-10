/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen
{
    /// <summary>
    /// Provides functions for writing trace message to the system trace buffer.
    /// </summary>
    public static class Tracer
    {
        /// <summary>
        /// Writes a trace event to indicate that a synchronous event has begun.
        /// </summary>
        /// <remarks>
        /// The specific error code can be obtained using the Tizen.Internals.Errors.ErrorFacts.GetLastResult() method.
        /// </remarks>
        /// <param name="name">The name of event (optionally containing format specifiers)</param>
        /// <seealso cref="Tizen.Tracer.End()"/>
        public static void Begin (String name)
        {
            Interop.Tracer.Begin (name);
        }

        /// <summary>
        /// Writes a trace event to indicate that the synchronous event has ended.
        /// </summary>
        /// <remarks>
        /// Tizen.Tracer.End() ends the most recently called Tizen.Tracer.Begin().
        /// The specific error code can be obtained using the Tizen.Internals.Errors.ErrorFacts.GetLastResult() method.
        /// </remarks>
        /// <seealso cref="Tizen.Tracer.Begin()"/>
        public static void End ()
        {
            Interop.Tracer.End ();
        }

        /// <summary>
        /// Writes a trace event to indicate that an asynchronous event has begun.
        /// </summary>
        /// <remarks>
        /// The specific error code can be obtained using the Tizen.Internals.Errors.ErrorFacts.GetLastResult() method.
        /// </remarks>
        /// <param name="cookie">An unique identifier for distinguishing simultaneous events</param>
        /// <param name="name">The name of event (optionally containing format specifiers)</param>
        /// <seealso cref="Tizen.Tracer.AsyncEnd()"/>
        public static void AsyncBegin (int cookie, String name)
        {
            Interop.Tracer.AsyncBegin (cookie, name);
        }

        /// <summary>
        /// Writes a trace event to indicate that the asynchronous event has ended.
        /// </summary>
        /// <remarks>
        /// Tizen.Tracer.AsyncEnd() ends matched Tizen.Tracer.AsyncBegin() which has same cookie and name.
        /// The specific error code can be obtained using the Tizen.Internals.Errors.ErrorFacts.GetLastResult() method.
        /// </remarks>
        /// <param name="cookie">An unique identifier for distinguishing simultaneous events</param>
        /// <param name="name">The name of event (optionally containing format specifiers)</param>
        /// <seealso cref="Tizen.Tracer.AsyncBegin()"/>
        public static void AsyncEnd (int cookie, String name)
        {
            Interop.Tracer.AsyncEnd (cookie, name);
        }

        /// <summary>
        /// Writes a trace event to track change of integer value.
        /// </summary>
        /// <remarks>
        /// The specific error code can be obtained using the Tizen.Internals.Errors.ErrorFacts.GetLastResult() method.
        /// </remarks>
        /// <param name="value">The integer variable to trace</param>
        /// <param name="name">The name of event (optionally containing format specifiers)</param>
        public static void TraceValue (int value, String name)
        {
            Interop.Tracer.TraceValue (value, name);
        }
    }
}

