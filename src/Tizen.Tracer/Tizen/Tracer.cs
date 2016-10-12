// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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

