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
    internal static partial class Ecore
    {
        internal delegate void EcoreCallback(IntPtr data);
        internal delegate bool EcoreTaskCallback(IntPtr data);
        internal delegate void EcoreEventCallback(IntPtr data, int type, IntPtr evt);

        [DllImport(Libraries.Ecore)]
        internal static extern int ecore_init();

        [DllImport(Libraries.Ecore)]
        internal static extern int ecore_shutdown();

        [DllImport(Libraries.Ecore)]
        internal static extern void ecore_main_loop_begin();

        [DllImport(Libraries.Ecore)]
        internal static extern void ecore_main_loop_quit();

        [DllImport(Libraries.Ecore)]
        internal static extern bool ecore_main_loop_glib_integrate();

        [DllImport(Libraries.Ecore)]
        internal static extern IntPtr ecore_idler_add(EcoreTaskCallback callback, IntPtr data);

        [DllImport(Libraries.Ecore)]
        internal static extern void ecore_main_loop_thread_safe_call_async(EcoreTaskCallback callback, IntPtr data);

        [DllImport(Libraries.Ecore)]
        internal static extern IntPtr ecore_main_loop_thread_safe_call_sync(EcoreTaskCallback callback, IntPtr data);

        [DllImport(Libraries.Ecore)]
        internal static extern IntPtr ecore_idler_del(IntPtr idler);

        [DllImport(Libraries.Ecore)]
        internal static extern IntPtr ecore_timer_add(double interval, EcoreTaskCallback callback, IntPtr data);

        [DllImport(Libraries.Ecore)]
        internal static extern IntPtr ecore_timer_del(IntPtr timer);

        [DllImport(Libraries.Ecore)]
        internal static extern IntPtr ecore_animator_add(EcoreTaskCallback func, IntPtr data);

        [DllImport(Libraries.Ecore)]
        internal static extern IntPtr ecore_animator_del(IntPtr animator);

        [DllImport(Libraries.Ecore)]
        internal static extern double ecore_time_get();

        [DllImport(Libraries.Ecore)]
        internal static extern IntPtr ecore_event_handler_add(int type, EcoreEventCallback func, IntPtr data);

        [DllImport(Libraries.Ecore)]
        internal static extern IntPtr ecore_event_handler_del(IntPtr handler);
    }
}
