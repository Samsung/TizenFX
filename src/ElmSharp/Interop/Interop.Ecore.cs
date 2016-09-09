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
    internal static partial class Ecore
    {
        internal delegate void EcoreCallback(IntPtr data);
        internal delegate bool EcoreTaskCallback(IntPtr data);

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
    }
}
