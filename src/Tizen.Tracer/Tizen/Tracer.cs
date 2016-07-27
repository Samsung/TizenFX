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
    public static class Tracer
    {
        public static void Begin (String name)
        {
            Interop.Tracer.Begin (name);
        }

        public static void End ()
        {
            Interop.Tracer.End ();
        }

        public static void AsyncBegin (int cookie, String name)
        {
            Interop.Tracer.AsyncBegin (cookie, name);
        }

        public static void AsyncEnd (int cookie, String name)
        {
            Interop.Tracer.AsyncEnd (cookie, name);
        }

        public static void TraceValue (int value, String name)
        {
            Interop.Tracer.TraceValue (value, name);
        }
    }
}

