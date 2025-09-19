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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Glib
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool GSourceFunc(IntPtr userData);

        [DllImport(Libraries.Glib, EntryPoint = "g_idle_add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint IdleAdd(GSourceFunc d, IntPtr data);

        [DllImport(Libraries.Glib, EntryPoint = "g_source_remove", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool RemoveSource(uint source);

        [DllImport(Libraries.Glib, EntryPoint = "g_idle_source_new", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr IdleSourceNew();

        [DllImport(Libraries.Glib, EntryPoint = "g_source_set_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SourceSetCallback(IntPtr source, GSourceFunc func, IntPtr data, IntPtr notify);

        [DllImport(Libraries.Glib, EntryPoint = "g_source_attach", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint SourceAttach(IntPtr source, IntPtr context);

        [DllImport(Libraries.Glib, EntryPoint = "g_source_unref", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SourceUnref(IntPtr source);

        [DllImport(Libraries.Glib, EntryPoint = "g_main_context_get_thread_default", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr MainContextGetThreadDefault();

        [DllImport(Libraries.Glib, EntryPoint = "g_timeout_source_new", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TimeoutSourceNew(uint interval);
    }
}
