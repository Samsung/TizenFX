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
using System.Runtime.InteropServices.Marshalling;

internal static partial class Interop
{
    internal static partial class Glib
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool GSourceFunc(IntPtr userData);

        [LibraryImport(Libraries.Glib, EntryPoint = "g_idle_add", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial uint IdleAdd(GSourceFunc d, IntPtr data);

        [LibraryImport(Libraries.Glib, EntryPoint = "g_source_remove", StringMarshalling = StringMarshalling.Utf8)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static partial bool RemoveSource(uint source);

        [LibraryImport(Libraries.Glib, EntryPoint = "g_idle_source_new", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr IdleSourceNew();

        [LibraryImport(Libraries.Glib, EntryPoint = "g_source_set_callback", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void SourceSetCallback(IntPtr source, GSourceFunc func, IntPtr data, IntPtr notify);

        [LibraryImport(Libraries.Glib, EntryPoint = "g_source_attach", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial uint SourceAttach(IntPtr source, IntPtr context);

        [LibraryImport(Libraries.Glib, EntryPoint = "g_source_unref", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void SourceUnref(IntPtr source);

        [LibraryImport(Libraries.Glib, EntryPoint = "g_main_context_get_thread_default", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr MainContextGetThreadDefault();
    }
}





