// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Tracer
	{
		[DllImport(Libraries.ttrace, EntryPoint = "trace_begin")]
		internal static extern int Begin (String name);

		[DllImport(Libraries.ttrace, EntryPoint = "trace_end")]
		internal static extern int End ();

		[DllImport(Libraries.ttrace, EntryPoint = "trace_async_begin")]
		internal static extern int AsyncBegin (int cookie, String name);

		[DllImport(Libraries.ttrace, EntryPoint = "trace_async_end")]
		internal static extern int AsyncEnd (int cookie, String name);

		[DllImport(Libraries.ttrace, EntryPoint = "trace_update_counter")]
		internal static extern int TraceValue (int value, String name);
    }
}
