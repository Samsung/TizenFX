/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;
using System.Linq;

using static CoreUI.DataTypes.NativeCustomExportFunctions;
using EoG = CoreUI.Wrapper.Globals;

namespace CoreUI
{

namespace Wrapper
{

internal static class Globals
{
    /// <summary>Represents the type of the native CoreUI_Class.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal enum CoreUIClassType
    {
        /// <summary>Regular EFL classes.</summary>
        /// <since_tizen> 6 </since_tizen>
        Regular = 0,
        /// <summary>Non-instantiable efl classes (i.e. Abstracts).</summary>
        /// <since_tizen> 6 </since_tizen>
        RegularNoInstant,
        /// <summary>Interface types.</summary>
        /// <since_tizen> 6 </since_tizen>
        Interface,
        /// <summary>Mixins types.</summary>
        /// <since_tizen> 6 </since_tizen>
        Mixin,
        /// <summary>Invalid class type.</summary>
        /// <since_tizen> 6 </since_tizen>
        Invalid
    }

    [return: MarshalAs(UnmanagedType.U1)]
    internal delegate bool efl_object_init_delegate();
    static readonly FunctionWrapper<efl_object_init_delegate> efl_object_init_ptr =
        new FunctionWrapper<efl_object_init_delegate>(CoreUI.Libs.EoModule, "efl_object_init");
    internal static bool efl_object_init() => efl_object_init_ptr.Value.Delegate();

    internal delegate void efl_object_shutdown_delegate();
    static readonly FunctionWrapper<efl_object_shutdown_delegate> efl_object_shutdown_ptr = new FunctionWrapper<efl_object_shutdown_delegate>(CoreUI.Libs.EoModule, "efl_object_shutdown");
    internal static void efl_object_shutdown() => efl_object_shutdown_ptr.Value.Delegate();
    // [DllImport(CoreUI.Libs.Eo)] internal static extern void efl_object_shutdown();

    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr efl_mono_wrapper_supervisor_get(IntPtr eo);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void efl_mono_wrapper_supervisor_set(IntPtr eo, IntPtr ws);

    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        _efl_add_internal_start([MarshalAs(UnmanagedType.LPStr)] String file, int line,
                                IntPtr klass, IntPtr parent, byte is_ref, byte is_fallback);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        _efl_add_internal_start_bindings([MarshalAs(UnmanagedType.LPStr)] String file, int line, IntPtr klass, IntPtr parent,
                                         byte is_ref, byte is_fallback, IntPtr substitute_ctor, IntPtr data);
    internal delegate  IntPtr
        _efl_add_end_delegate(IntPtr eo, byte is_ref, byte is_fallback);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        _efl_add_end(IntPtr eo, byte is_ref, byte is_fallback);
    internal delegate  IntPtr
        efl_ref_delegate(IntPtr eo);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_ref(IntPtr eo);
    internal delegate  void
        efl_unref_delegate(IntPtr eo);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        efl_unref(IntPtr eo);
    internal delegate  int
        efl_ref_count_delegate(IntPtr eo);
    [DllImport(CoreUI.Libs.Eo)] internal static extern int
        efl_ref_count(IntPtr eo);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        efl_mono_wrapper_supervisor_callbacks_set(CoreUI.FreeWrapperSupervisorCb freeWrapperSupervisorCb);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        efl_mono_native_dispose(IntPtr eo);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        efl_mono_thread_safe_native_dispose(IntPtr eo);
    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        efl_mono_thread_safe_efl_unref(IntPtr eo);

    [DllImport(CoreUI.Libs.CustomExports)] internal static extern void
        efl_mono_thread_safe_free_cb_exec(IntPtr free_cb, IntPtr cb_data);

    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_name_get(IntPtr eo);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr extn46, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr extn46, IntPtr extn47, IntPtr term);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr extn46, IntPtr extn47, IntPtr extn48, IntPtr term);

    internal delegate  byte efl_class_functions_set_delegate(IntPtr klass_id, IntPtr object_ops, IntPtr class_ops);
    [DllImport(CoreUI.Libs.Eo)] internal static extern byte efl_class_functions_set(IntPtr klass_id, IntPtr object_ops, IntPtr class_ops);
    internal delegate  IntPtr efl_data_scope_get_delegate(IntPtr obj, IntPtr klass);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr efl_data_scope_get(IntPtr obj, IntPtr klass);
    internal delegate  IntPtr efl_super_delegate(IntPtr obj, IntPtr klass);

    /// <summary>Gets a native pointer to <c>obj</c> that forwards the method call to its parent
    /// implementation.
    ///
    /// <para>For generated code use only.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="obj">The native pointer to be prepared.</param>
    /// <param name="klass">The current class.</param>
    /// <returns>The native pointer to <c>obj</c> prepared to call the parent implementation of <c>klass</c>.</returns>
    internal static IntPtr Super(IntPtr obj, IntPtr klass)
    {
        return efl_super(obj, klass);
    }

    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr efl_super(IntPtr obj, IntPtr klass);
    internal delegate  IntPtr efl_class_get_delegate(IntPtr obj);
    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr efl_class_get(IntPtr obj);

    /// <summary>Gets the native EO class pointer for the given object.
    /// <para>For generated code use only.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="obj">The native pointer to the <see cref="CoreUI.Object" /> instance to get the native class
    /// from.</param>
    /// <returns>The native class pointer or <see cref="IntPtr.Zero" /> if no such class existis.</returns>
    internal static IntPtr GetClass(IntPtr obj)
    {
        return efl_class_get(obj);
    }

    [DllImport(CoreUI.Libs.Eo)] internal static extern CoreUIClassType efl_class_type_get(IntPtr klass);
    internal delegate  IntPtr dlerror_delegate();
    [DllImport(CoreUI.Libs.Evil)] internal static extern IntPtr dlerror();

    [DllImport(CoreUI.Libs.Eo)] internal static extern IntPtr efl_constructor(IntPtr obj);

    [DllImport(CoreUI.Libs.CustomExports)] internal static extern IntPtr efl_mono_avoid_top_level_constructor_callback_addr_get();

    [DllImport(CoreUI.Libs.Eo)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        efl_event_callback_priority_add(IntPtr obj, IntPtr desc, short priority, IntPtr cb, IntPtr data);

    [DllImport(CoreUI.Libs.Eo)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        efl_event_callback_del(IntPtr obj, IntPtr desc, IntPtr cb, IntPtr data);

    [DllImport(CoreUI.Libs.Eo)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        efl_event_callback_call(IntPtr obj, IntPtr desc, IntPtr event_info);

    /// <summary>Calls the callbacks associated to an event.
    /// <para>For generated code use only.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="obj">The native pointer to the <see cref="CoreUI.Object" /> instance that will be the emitter
    /// of the event.</param>
    /// <param name="desc">The native event description.</param>
    /// <param name="event_info">The native payload of the event.</param>
    /// <returns><c>false</c> if one of the callbacks aborted the call. <c>true</c> otherwise.</returns>
    internal static bool CallEventCallback(IntPtr obj, IntPtr desc, IntPtr event_info)
    {
        return efl_event_callback_call(obj, desc, event_info);
    }

    internal const int RTLD_NOW = 2;

    internal delegate byte class_initializer(IntPtr klass);

    internal static T GetParamHelper<T>(Nullable<T> v) where T : struct
    {
        return v.Value;
    }

    internal static U GetParamHelper<U>(U v)
    {
        return v;
    }

    internal static bool ParamHelperCheck<T>(Nullable<T> v) where T : struct
    {
        return v.HasValue;
    }

    internal static bool ParamHelperCheck<U>(U v)
    {
        return v != null;
    }

    internal static IntPtr register_class(String class_name, IntPtr base_klass, System.Type type)
    {
        ClassDescription description;
        description.version = 2; // EO_VERSION
        description.name = class_name;
        description.class_type = 0; // REGULAR
        description.data_size = (UIntPtr)0;
        description.class_initializer = IntPtr.Zero;
        description.class_constructor = IntPtr.Zero;
        description.class_destructor = IntPtr.Zero;

        class_initializer init = (IntPtr kls) =>
        {
            return Globals.class_initializer_call(kls, type);
        };

        description.class_initializer = Marshal.GetFunctionPointerForDelegate(init);

        IntPtr description_ptr = CoreUI.DataTypes.MemoryNative.Alloc(Marshal.SizeOf(description));
        Marshal.StructureToPtr(description, description_ptr, false);

        // FIXME: description_ptr seems to be leaking memory even after an eo_shutdown

        var interface_list = EoG.get_efl_interfaces(type);

        CoreUI.DataTypes.Log.Debug($"Going to register new class named {class_name}");
        IntPtr klass = EoG.call_efl_class_new(description_ptr, base_klass, interface_list);
        if (klass == IntPtr.Zero)
        {
            CoreUI.DataTypes.Log.Error("klass was not registered");
        }
        else
        {
            CoreUI.DataTypes.Log.Debug("Registered class successfully");
        }

        return klass;
    }

    internal static List<IntPtr> get_efl_interfaces(System.Type type)
    {
        System.Type base_type = type.BaseType;

        var ifaces_lst = new List<IntPtr>();
        var base_ifaces = base_type.GetInterfaces();
        var ifaces = type.GetInterfaces();
        foreach (var iface in ifaces)
        {
            if (!System.Array.Exists(base_ifaces, element => element == iface))
            {
                var attrs = System.Attribute.GetCustomAttributes(iface);
                foreach (var attr in attrs)
                {
                    if (attr is CoreUI.Wrapper.NativeClass)
                    {
                        ifaces_lst.Add(((CoreUI.Wrapper.NativeClass)attr).GetCoreUIClass());
                        break;
                    }
                }
            }
        }

        return ifaces_lst;
    }

    private static CoreUI.Wrapper.NativeClass GetNativeClass(System.Type type)
    {
        var attrs = System.Attribute.GetCustomAttributes(type, false);
        foreach (var attr in attrs)
        {
            if (attr is CoreUI.Wrapper.NativeClass)
            {
                return (CoreUI.Wrapper.NativeClass)attr;
            }
        }

        return null;
    }

    internal static System.Collections.Generic.List<string>
        GetUserMethods(System.Type type)
    {
        var r = new System.Collections.Generic.List<string>();
        var flags =
            System.Reflection.BindingFlags.Instance
            | System.Reflection.BindingFlags.DeclaredOnly
            | System.Reflection.BindingFlags.Public
            | System.Reflection.BindingFlags.NonPublic;

        for (var base_type = type;;base_type = base_type.BaseType)
        {
            r.AddRange(base_type.GetMethods(flags)
                       .AsParallel().Select(info=>info.Name).ToList());
            if (IsGeneratedClass(base_type.BaseType))
            {
                break;
            }

            if (base_type.BaseType == null)
            {
                break;
            }
        }

        return r;
    }

    internal static byte class_initializer_call(IntPtr klass, System.Type type)
    {
        CoreUI.DataTypes.Log.Debug($"called with 0x{klass.ToInt64():x} {type}");
        var derived = type.BaseType;
        CoreUI.Wrapper.NativeClass nativeClass = GetNativeClass(derived);

        while (nativeClass == null)
        {
            derived = derived.BaseType;
            if (derived == null)
                break;
            nativeClass = GetNativeClass(derived);
        }

        if (nativeClass != null)
        {
            CoreUI.DataTypes.Log.Debug("nativeClass != null");
            var descs = nativeClass.GetEoOps(type, true);
            var count = descs.Count;
            IntPtr descs_ptr = IntPtr.Zero;

            if (count > 0)
            {
                descs_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(descs[0]) * count);
            }

            IntPtr ptr = descs_ptr;
            for (int i = 0; i != count; ++i)
            {
               Marshal.StructureToPtr(descs[i], ptr, false);
               ptr = IntPtr.Add(ptr, Marshal.SizeOf(descs[0]));
            }

            CoreUIObjectOps ops;
            ops.descs = descs_ptr;
            ops.count = (UIntPtr)count;
            IntPtr ops_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(ops));
            Marshal.StructureToPtr(ops, ops_ptr, false);
            CoreUI.Wrapper.Globals.efl_class_functions_set(klass, ops_ptr, IntPtr.Zero);
            //EoKlass = klass;
        }
        else
        {
            CoreUI.DataTypes.Log.Debug("nativeClass == null");
        }

       return 1;
    }

    internal static IntPtr call_efl_class_new(IntPtr desc, IntPtr bk, List<IntPtr> il = null)
    {
        IntPtr nul = IntPtr.Zero;
        int iface_list_count = (il == null ? 0 : il.Count);
        switch (iface_list_count)
        {
            default: return nul;
            case  0: return EoG.efl_class_new(desc, bk, nul);
            case  1: return EoG.efl_class_new(desc, bk, il[0], nul);
            case  2: return EoG.efl_class_new(desc, bk, il[0], il[1], nul);
            case  3: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], nul);
            case  4: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], nul);
            case  5: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], nul);
            case  6: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], nul);
            case  7: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], nul);
            case  8: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], nul);
            case  9: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], nul);
            case 10: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], nul);
            case 11: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], nul);
            case 12: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], nul);
            case 13: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], nul);
            case 14: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], nul);
            case 15: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], nul);
            case 16: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], nul);
            case 17: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], nul);
            case 18: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], nul);
            case 19: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], nul);
            case 20: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], nul);
            case 21: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], nul);
            case 22: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], nul);
            case 23: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], nul);
            case 24: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], nul);
            case 25: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], nul);
            case 26: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], nul);
            case 27: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], nul);
            case 28: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], nul);
            case 29: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], nul);
            case 30: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], nul);
            case 31: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], nul);
            case 32: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], nul);
            case 33: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], nul);
            case 34: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], nul);
            case 35: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], nul);
            case 36: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], nul);
            case 37: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], nul);
            case 38: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], nul);
            case 39: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], nul);
            case 40: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], il[39], nul);
            case 41: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], il[39], il[40], nul);
            case 42: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], il[39], il[40], il[41], nul);
            case 43: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], il[39], il[40], il[41], il[42], nul);
            case 44: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], il[39], il[40], il[41], il[42], il[43], nul);
            case 45: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], il[39], il[40], il[41], il[42], il[43], il[44], nul);
            case 46: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], il[39], il[40], il[41], il[42], il[43], il[44], il[45], nul);
            case 47: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], il[39], il[40], il[41], il[42], il[43], il[44], il[45], il[46], nul);
            case 48: return EoG.efl_class_new(desc, bk, il[0], il[1], il[2], il[3], il[4], il[5], il[6], il[7], il[8], il[9], il[10], il[11], il[12], il[13], il[14], il[15], il[16], il[17], il[18], il[19], il[20], il[21], il[22], il[23], il[24], il[25], il[26], il[27], il[28], il[29], il[30], il[31], il[32], il[33], il[34], il[35], il[36], il[37], il[38], il[39], il[40], il[41], il[42], il[43], il[44], il[45], il[46], il[47], nul);
        }
    }

    internal static CoreUI.Wrapper.WrapperSupervisor WrapperSupervisorPtrToManaged(IntPtr wsPtr)
    {
        return (CoreUI.Wrapper.WrapperSupervisor) GCHandle.FromIntPtr(wsPtr).Target;
    }

    internal static CoreUI.Wrapper.WrapperSupervisor GetWrapperSupervisor(IntPtr eo)
    {
        var wsPtr = CoreUI.Wrapper.Globals.efl_mono_wrapper_supervisor_get(eo);
        if (wsPtr == IntPtr.Zero)
        {
            return null;
        }

        return WrapperSupervisorPtrToManaged(wsPtr);
    }

    internal static void SetWrapperSupervisor(IntPtr eo, CoreUI.Wrapper.WrapperSupervisor ws)
    {
        GCHandle gch = GCHandle.Alloc(ws);
        CoreUI.Wrapper.Globals.efl_mono_wrapper_supervisor_set(eo, GCHandle.ToIntPtr(gch));
    }

    internal static void free_dict_values(Dictionary<String, IntPtr> dict)
    {
        foreach (IntPtr ptr in dict.Values)
        {
            CoreUI.DataTypes.MemoryNative.Free(ptr);
        }
    }

    internal static void free_stringshare_values(Dictionary<String, IntPtr> dict)
    {
        foreach (IntPtr ptr in dict.Values)
        {
            CoreUI.DataTypes.NativeMethods.eina_stringshare_del(ptr);
        }
    }

    internal static void free_gchandle(IntPtr ptr)
    {
        GCHandle handle = GCHandle.FromIntPtr(ptr);
        handle.Free();
    }

    internal static System.Threading.Tasks.Task<CoreUI.DataTypes.Value> WrapAsync(CoreUI.DataTypes.Future future, CancellationToken token)
    {
        // Creates a task that will wait for SetResult for completion.
        // TaskCompletionSource is used to create tasks for 'external' Task sources.
        var tcs = new System.Threading.Tasks.TaskCompletionSource<CoreUI.DataTypes.Value>();

        // Flag to be passed to the cancell callback
        bool fulfilled = false;

        future.Then((CoreUI.DataTypes.Value received) =>
        {
            lock (future)
            {
                // Convert an failed Future to a failed Task.
                if (received.GetValueType() == CoreUI.DataTypes.ValueType.Error)
                {
                    CoreUI.DataTypes.Error err;
                    received.Get(out err);
                    if (err == CoreUI.DataTypes.Error.ECANCELED)
                    {
                        tcs.SetCanceled();
                    }
                    else
                    {
                        tcs.TrySetException(new CoreUI.FutureException(err));
                    }
                }
                else
                {
                    // Async receiver methods may consume the value C# wrapper, like when awaiting in the start of an
                    // using block. In order to continue to forward the value correctly to the next futures
                    // in the chain, we give the Async wrapper a copy of the received wrapper.
                    tcs.SetResult(new CoreUI.DataTypes.Value(received));
                }

                fulfilled = true;
                return received;
            }
        });
        // Callback to be called when the token is cancelled.
        token.Register(() =>
        {
            lock (future)
            {
                // Will trigger the Then callback above with an CoreUI.DataTypes.Error
                if (!fulfilled)
                {
                    future.Cancel();
                }
            }
        });

        return tcs.Task;
    }

    /// <summary>Returns whether the given type was generated by eolian-mono</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="managedType">The type to check.</param>
    /// <returns>True if generated by eolian-mono. False otherwise.</returns>
    private static bool IsGeneratedClass(System.Type managedType)
    {
        return GetNativeClass(managedType) != null;
    }

    /// <summary>Creates a new wrapper for the given Eo id.
    ///
    /// <para>If the Eo have a WrapperSupervisor, it returns the C# instance handle stored in its
    /// WrapperSupervisor. otherwise, we use reflection to get the correct C# type to re-wrap it.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ///
    /// <param name="handle">The Eo id to be wrapped.</param>
    /// <param name="shouldIncRef">Whether we should increase the refcount of the Eo instance.</param>
    /// <returns>The C# wrapper for this instance.</returns>
    internal static CoreUI.Wrapper.IWrapper CreateWrapperFor(System.IntPtr handle, bool shouldIncRef=true)
    {

        if (handle == IntPtr.Zero)
        {
            return null;
        }

        CoreUI.Wrapper.Globals.efl_ref(handle);
        try
        {
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(handle);
            if (ws != null && ws.Target != null)
            {
                if (!shouldIncRef)
                {
                    CoreUI.Wrapper.Globals.efl_unref(handle);
                }

                return ws.Target;
            }

            IntPtr eoKlass = efl_class_get(handle);

            if (eoKlass == IntPtr.Zero)
            {
                throw new InvalidOperationException($"Can't get Eo class for object handle 0x{handle.ToInt64():x}");
            }

            var managedType = ClassRegister.GetManagedType(eoKlass);

            if (managedType == null)
            {
                IntPtr nativeName = efl_class_name_get(eoKlass);
                var name = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(nativeName);

                throw new InvalidOperationException($"Can't get Managed class for object handle 0x{handle.ToInt64():x} with native class [{name}]");
            }

            Debug.Assert(IsGeneratedClass(managedType));
            System.Reflection.ConstructorInfo constructor = null;

            try
            {
                var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                constructor = managedType.GetConstructor(flags, null, new Type[1] { typeof(WrappingHandle) }, null);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Can't get constructor for type {managedType}");
            }

            WrappingHandle wh = new WrappingHandle(handle);
            var ret = (CoreUI.Wrapper.IWrapper) constructor.Invoke(new object[1] { wh });

            if (ret == null)
            {
                throw new InvalidOperationException($"Can't construct type {managedType} from IntPtr handle");
            }

            if (shouldIncRef)
            {
                CoreUI.Wrapper.Globals.efl_ref(handle);
            }

            return ret;
        }
        finally
        {
            CoreUI.Wrapper.Globals.efl_unref(handle);
        }
    }

    private static CoreUI.FreeWrapperSupervisorCb FreeWrapperSupervisorCallbackDelegate = new CoreUI.FreeWrapperSupervisorCb(FreeWrapperSupervisorCallback);
    internal static void FreeWrapperSupervisorCallback(IntPtr eo)
    {
        try
        {
            var wsPtr = CoreUI.Wrapper.Globals.efl_mono_wrapper_supervisor_get(eo);
            if (wsPtr == IntPtr.Zero)
            {
                CoreUI.DataTypes.Log.Error($"Invalid wrapper supervisor [Eo pointer: {eo.ToInt64():x}]");
                return;
            }

            CoreUI.Wrapper.Globals.efl_mono_wrapper_supervisor_set(eo, IntPtr.Zero);

            GCHandle gch = GCHandle.FromIntPtr(wsPtr);
            var ws = (CoreUI.Wrapper.WrapperSupervisor) gch.Target;
            foreach (var item in ws.EoEvents)
            {
                if (!efl_event_callback_del(eo, item.Key.desc, item.Value.evtCallerPtr, wsPtr))
                {
                    CoreUI.DataTypes.Log.Error($"Failed to remove event proxy for event {item.Key.desc} [eo: {eo.ToInt64():x}; cb: {item.Value.evtCallerPtr.ToInt64():x}]");
                }
            }

            // Free the native eo
            CoreUI.Wrapper.Globals.efl_unref(eo);

            // now the WrapperSupervisor can be collected, and so its member:
            //     - the event dictionary
            //     - and the ObjectWrapper if it is still pinned
            gch.Free();
        }
        catch (Exception e)
        {
            CoreUI.DataTypes.Log.Error(e.ToString());
            CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
        }
    }

    internal static void SetNativeDisposeCallbacks()
    {
        efl_mono_wrapper_supervisor_callbacks_set(FreeWrapperSupervisorCallbackDelegate);
    }

    internal static void ThreadSafeFreeCbExec(CoreUI.DataTypes.Callbacks.EinaFreeCb cbFreeCb, IntPtr cbData)
    {
        CoreUI.DataTypes.Callbacks.EinaFreeCb cb = (IntPtr gcHandlePtr) => {
            cbFreeCb(cbData);
            GCHandle gcHandle = GCHandle.FromIntPtr(gcHandlePtr);
            gcHandle.Free();
        };

        Monitor.Enter(CoreUI.All.InitLock);
        if (CoreUI.All.MainLoopInitialized)
        {
            IntPtr cbPtr = Marshal.GetFunctionPointerForDelegate(cb);
            var handle = GCHandle.Alloc(cb);
            var handlePtr = GCHandle.ToIntPtr(handle);

            efl_mono_thread_safe_free_cb_exec(cbPtr, handlePtr);
        }
        Monitor.Exit(CoreUI.All.InitLock);
    }

    internal static IEnumerable<T> AccessorToIEnumerable<T>(IntPtr accessor)
    {
        if (accessor == IntPtr.Zero)
           throw new ArgumentException("accessor is null", nameof(accessor));

        IntPtr data = IntPtr.Zero;
        uint position = 0;

        while (CoreUI.DataTypes.AccessorNativeFunctions.eina_accessor_data_get(accessor, position, out data))
        {
            yield return CoreUI.DataTypes.TraitFunctions.NativeToManaged<T>(data);
            position += 1;
        }
    }

    internal static IntPtr IEnumerableToAccessor<T>(IEnumerable<T> enumerable, bool isMoved)
    {
        if (enumerable == null)
        {
            throw new ArgumentException("enumerable is null", nameof(enumerable));
        }

        // If we are a wrapper around an existing CoreUI.DataTypes.Accessor, we can just forward
        // it and avoid unnecessary copying in non-owning transfers.
        var wrappedAccessor = enumerable as CoreUI.DataTypes.Accessor<T>;

        if (wrappedAccessor != null && !isMoved)
        {
            return wrappedAccessor.Handle;
        }

        // TODO: Check if we're either an CoreUI.DataTypes.List or CoreUI.DataTypes.Collection?
        // We could just rewrap their native accessors
        IntPtr[] intPtrs = new IntPtr[enumerable.Count()];

        int i = 0;
        foreach (T data in enumerable)
        {
            intPtrs[i] = CoreUI.DataTypes.TraitFunctions.ManagedToNativeAlloc<T>(data);
            i++;
        }

        GCHandle pinnedArray = GCHandle.Alloc(intPtrs, GCHandleType.Pinned);
        IntPtr nativeAccessor = IntPtr.Zero;

        if (isMoved)
        {
            // We need a custom accessor that would unpin the data when freed.
            nativeAccessor = CoreUI.DataTypes.AccessorNativeFunctions.eina_mono_owned_carray_length_accessor_new(pinnedArray.AddrOfPinnedObject(),
                                                                                                     (uint)IntPtr.Size,
                                                                                                     (uint)intPtrs.Length,
                                                                                                     free_gchandle,
                                                                                                     GCHandle.ToIntPtr(pinnedArray));
        }
        else
        {
            // FIXME: Leaking....
            nativeAccessor = CoreUI.DataTypes.AccessorNativeFunctions.eina_carray_length_accessor_new(pinnedArray.AddrOfPinnedObject(),
                                                                                          (uint)(IntPtr.Size),
                                                                                          (uint)intPtrs.Length);
        }

        if (nativeAccessor == IntPtr.Zero)
        {
            pinnedArray.Free();
            throw new InvalidOperationException("Failed to get native accessor for the given container");
        }

        return nativeAccessor;
    }

    internal static IEnumerable<T> IteratorToIEnumerable<T>(IntPtr iterator)
    {
        if (iterator == IntPtr.Zero)
           throw new ArgumentException("iterator is null", nameof(iterator));

        while (CoreUI.DataTypes.IteratorNativeFunctions.eina_iterator_next(iterator, out IntPtr data))
        {
            yield return CoreUI.DataTypes.TraitFunctions.NativeToManaged<T>(data);
        }
    }

    internal static IntPtr IEnumerableToIterator<T>(IEnumerable<T> enumerable, bool isMoved)
    {
        if (enumerable == null)
        {
            throw new ArgumentException("enumerable is null", nameof(enumerable));
        }

        // If we are a wrapper around an existing CoreUI.DataTypes.Iterator, we can just forward
        // it and avoid unnecessary copying in non-owning transfers.
        var wrappedIterator = enumerable as CoreUI.DataTypes.Iterator<T>;

        if (wrappedIterator != null && !isMoved)
        {
            return wrappedIterator.Handle;
        }

        var list = new List<IntPtr>();
        foreach (T data in enumerable)
        {
            list.Add(CoreUI.DataTypes.TraitFunctions.ManagedToNativeAlloc<T>(data));
        }

        IntPtr[] dataArray = list.ToArray();
        GCHandle pinnedArray = GCHandle.Alloc(dataArray, GCHandleType.Pinned);
        IntPtr ret = CoreUI.DataTypes.IteratorNativeFunctions.eina_carray_length_iterator_new(pinnedArray.AddrOfPinnedObject(), (uint)(IntPtr.Size), (uint)dataArray.Length);

        if (!isMoved)
        {
            // FIXME Need to free ret and unpin pinnedArray in the future.
        }

        return ret;
    }

    internal static IList<T> NativeListToIList<T>(IntPtr nativeList)
    {
        if (nativeList == IntPtr.Zero)
            throw new ArgumentException("nativeList is null", nameof(nativeList));

        IntPtr l;
        List<T> list = new List<T>();
        for (l = nativeList; l != IntPtr.Zero; l = CoreUI.DataTypes.ListNativeFunctions.eina_list_next_custom_export_mono(l))
        {
            list.Add(CoreUI.DataTypes.TraitFunctions.NativeToManaged<T>(CoreUI.DataTypes.ListNativeFunctions.eina_list_data_get_custom_export_mono(l)));
        }
        return list;
    }

    internal static IntPtr IListToNativeList<T>(IList<T> list, bool isMoved)
    {
        if (list == null)
            throw new ArgumentException("list is null", nameof(list));

        // If we are a wrapper around an existing CoreUI.DataTypes.List, we can just forward
        // it and avoid unnecessary copying in non-owning transfers.
        var wrappedList = list as CoreUI.DataTypes.List<T>;

        if (wrappedList != null && !isMoved)
        {
            return wrappedList.Handle;
        }

        IntPtr nativeList = IntPtr.Zero;
        foreach (T data in list)
        {
            nativeList = CoreUI.DataTypes.ListNativeFunctions.eina_list_append(nativeList, CoreUI.DataTypes.TraitFunctions.ManagedToNativeAlloc(data)); //FIXME: need to free
        }

        if (!isMoved)
        {
            // FIXME Need to free ret and unpin pinnedArray in the future.
        }

        return nativeList;
    }

    internal static IList<T> NativeArrayToIList<T>(IntPtr nativeArray)
    {
        if (nativeArray == IntPtr.Zero)
            throw new ArgumentException("nativeArray is null", nameof(nativeArray));

        List<T> list = new List<T>();
        UpdateListFromNativeArray(list, nativeArray);

        // FIXME need to free `list` if the returned list is not @moved
        return list;
    }

    internal static IntPtr IListToNativeArray<T>(IList<T> list, bool isMoved)
    {
        if (list == null)
            throw new ArgumentException("list is null", nameof(list));

        // If we are a wrapper around an existing CoreUI.DataTypes.Array, we can just forward
        // it and avoid unnecessary copying in non-owning transfers.
        var wrappedArray = list as CoreUI.DataTypes.Array<T>;

        if (wrappedArray != null && !isMoved)
        {
            return wrappedArray.Handle;
        }

        IntPtr nativeArray = CoreUI.DataTypes.ArrayNativeFunctions.eina_array_new(4);
        foreach (T data in list)
        {
            CoreUI.DataTypes.ArrayNativeFunctions.eina_array_push_custom_export_mono(nativeArray, CoreUI.DataTypes.TraitFunctions.ManagedToNativeAlloc(data)); //FIXME: need to free
        }

        if (!isMoved)
        {
            // FIXME Need to free ret and unpin pinnedArray in the future.
        }

        return nativeArray;
    }

    internal static void UpdateListFromNativeArray<T>(IList<T> list, IntPtr nativeArray)
    {
        // Do not update if list Handle is same to nativeArray. They already updated in native code.
        var wrappedArray = list as CoreUI.DataTypes.Array<T>;
        if (wrappedArray != null && wrappedArray.Handle == nativeArray)
            return;

        list.Clear();
        if (nativeArray == IntPtr.Zero)
        {
            return;
        }

        uint count = CoreUI.DataTypes.ArrayNativeFunctions.eina_array_count_custom_export_mono(nativeArray);
        for (uint i = 0; i < count; i++)
        {
            list.Add(CoreUI.DataTypes.TraitFunctions.NativeToManaged<T>(CoreUI.DataTypes.ArrayNativeFunctions.eina_array_data_get_custom_export_mono(nativeArray, i)));
        }
    }

} // Globals

/// <summary>
/// Internal struct used by the binding to pass the native handle pointer
/// to the managed object wrapping constructor.
/// Internal usage only: do not use this class in inherited classes.
/// </summary>
/// <since_tizen> 6 </since_tizen>
internal struct WrappingHandle
{
    public WrappingHandle(IntPtr h)
    {
        NativeHandle = h;
    }

    public IntPtr NativeHandle { get; private set; }
}

/// <summary>
/// Manage the initialization and cleanup for the CoreUI object subsystem.
/// </summary>
/// <since_tizen> 6 </since_tizen>
public static class Config
{
    /// <summary>
    /// Initialize the EFL object subsystem.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static void Init()
    {
        Globals.efl_object_init();
        Globals.SetNativeDisposeCallbacks();
    }

    /// <summary>
    /// Shutdown the EFL object subsystem.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static void Shutdown()
    {
        Globals.efl_object_shutdown();
    }
}

[System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Interface,
                       AllowMultiple = false,
                       Inherited = false)
]
abstract class NativeClass : System.Attribute
{
    internal abstract IntPtr GetCoreUIClass();
    internal abstract System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited);
}

/// <summary>Attribute for private native classes.
///
/// <para>For internal usage by generated code only.</para></summary>
/// <since_tizen> 6 </since_tizen>
class PrivateNativeClass : NativeClass
{
    internal override IntPtr GetCoreUIClass()
    {
        return IntPtr.Zero;
    }

    internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
    {
        return null;
    }
}

[System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Interface |
                       System.AttributeTargets.Enum |
                       System.AttributeTargets.Delegate |
                       System.AttributeTargets.Struct,
                       AllowMultiple = false,
                       Inherited = false)
]
internal class BindingEntityAttribute: System.Attribute
{
    public static bool IsBindingEntity(System.Type t)
    {
        return Attribute.GetCustomAttribute(t, typeof(BindingEntityAttribute), false) != null;
    }
}

public interface IWrapper
{
    /// <summary>Pointer to internal Eo instance.</summary>
    /// <since_tizen> 6 </since_tizen>
    IntPtr NativeHandle
    {
        get;
    }

    /// <summary>Pointer to internal Eo class.</summary>
    /// <since_tizen> 6 </since_tizen>
    IntPtr NativeClass
    {
        get;
    }
}

internal static class ClassRegister
{
    internal static System.Type GetManagedType(IntPtr klass)
    {
        System.Type t;
        if (CoreUI.Wrapper.ClassRegister.typeFromKlass.TryGetValue(klass, out t))
        {
            return t;
        }

        // If it isn't on the dictionary then it is a Native binding class
        IntPtr namePtr = CoreUI.Wrapper.Globals.efl_class_name_get(klass);
        if (namePtr == IntPtr.Zero)
        {
            throw new System.InvalidOperationException($"Could not get Native class name. Handle: {klass}");
        }
#pragma warning disable CA1307
        string name = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(namePtr)
            .Replace("_", ""); // Convert CoreUI C name to C# name
#pragma warning restore CA1307

        // Check if this is an internal implementation of an abstract class
        var abstract_impl_suffix = "Realized";
        if (name.EndsWith(abstract_impl_suffix, StringComparison.Ordinal))
        {
            name = name.Substring(0, name.Length - abstract_impl_suffix.Length);
            var lastDot = name.LastIndexOf(".", StringComparison.Ordinal);
            var klassName = name.Substring(lastDot + 1);
            name += "+" + klassName + abstract_impl_suffix; // '+' is the separator for nested classes
        }

        // When converting to managed, interfaces and mixins gets the 'I' prefix.
        var klass_type = CoreUI.Wrapper.Globals.efl_class_type_get(klass);
        if (klass_type == CoreUI.Wrapper.Globals.CoreUIClassType.Interface || klass_type == CoreUI.Wrapper.Globals.CoreUIClassType.Mixin)
        {
            var pos = name.LastIndexOf(".", StringComparison.Ordinal);
            name = name.Insert(pos + 1, "I"); // -1 if not found, inserts at 0 normally
        }

        //TIZEN_ONLY(20191004): Change the Efl to CoreUI prefix
        if (name.Contains("Efl."))
          name = name.Replace("Efl", "CoreUI");
        //
        //TIZEN_ONLY(20191126): Change the Ui to UI prefix
        if (name.Contains("Ui."))
          name = name.Replace("Ui", "UI");
        //

        var curr_asm = typeof(IWrapper).Assembly;
        t = curr_asm.GetType(name);
        if (t == null)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly == curr_asm)
                {
                    continue;
                }

                t = assembly.GetType(name);
                if (t != null)
                {
                    break;
                }
            }

            if (t == null)
            {
                return typeof(CoreUI.ObjectRealized);
            }
        }

        AddToKlassTypeBiDictionary(klass, t); // Cache it in the dictionary
        return t;
    }

    internal static IntPtr GetKlass(System.Type objectType)
    {
        IntPtr klass;
        if (klassFromType.TryGetValue(objectType, out klass))
        {
            return klass;
        }

        // Check if it is a Native binding class
        klass = GetNativeKlassPtr(objectType);
        if (klass != IntPtr.Zero)
        {
            // Add to the dictionary cache
            AddToKlassTypeBiDictionary(klass, objectType);
            return klass;
        }

        // Unregistered Inherited class, let's register it
        IntPtr baseKlass = GetNativeBaseKlassPtr(objectType);
        if (baseKlass == IntPtr.Zero)
        {
            throw new System.InvalidOperationException($"Could not get base C# binding class for Inherited type: {objectType.FullName}");
        }

        return RegisterKlass(baseKlass, objectType);
    }

    internal static IntPtr GetInheritKlassOrRegister(IntPtr baseKlass, System.Type objectType)
    {
        IntPtr klass;
        if (klassFromType.TryGetValue(objectType, out klass))
        {
            return klass;
        }

        return RegisterKlass(baseKlass, objectType);
    }

    private static IntPtr RegisterKlass(IntPtr baseKlass, System.Type objectType)
    {
        lock (klassAllocLock)
        {
            IntPtr newKlass = CoreUI.Wrapper.Globals.register_class(objectType.FullName, baseKlass, objectType);
            if (newKlass == IntPtr.Zero)
            {
                throw new System.InvalidOperationException($"Failed to register class '{objectType.FullName}'");
            }

            AddToKlassTypeBiDictionary(newKlass, objectType);
            return newKlass;
        }
    }

    private static IntPtr GetNativeBaseKlassPtr(System.Type objectType)
    {
        for (System.Type t = objectType.BaseType; t != null; t = t.BaseType)
        {
            var ptr = GetNativeKlassPtr(t);
            if (ptr != IntPtr.Zero)
            {
                return ptr;
            }
        }

        throw new System.InvalidOperationException($"Class '{objectType.FullName}' is not an CoreUI object");
    }

    private static IntPtr GetNativeKlassPtr(System.Type objectType)
    {
        if (objectType == null)
        {
            return IntPtr.Zero;
        }

        if (objectType.IsInterface)
        {
            // Try to get the *NativeMethods class
            var nativeMethods = (CoreUI.Wrapper.NativeClass)System.Attribute.GetCustomAttributes(objectType)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass);
            if (nativeMethods == null)
                return IntPtr.Zero;

            return nativeMethods.GetCoreUIClass();
        }

        var method = objectType.GetMethod("GetCoreUIClassStatic",
                                          System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

        if (method == null)
        {
            return IntPtr.Zero;
        }

        return (IntPtr)(method.Invoke(null, null));
    }

    internal static void AddToKlassTypeBiDictionary(IntPtr klassPtr, System.Type objectType)
    {
        klassFromType[objectType] = klassPtr;
        typeFromKlass[klassPtr] = objectType;
    }

    internal static readonly System.Collections.Concurrent.ConcurrentDictionary<System.Type, System.IntPtr> klassFromType
        = new System.Collections.Concurrent.ConcurrentDictionary<System.Type, System.IntPtr>();

    internal static readonly System.Collections.Concurrent.ConcurrentDictionary<System.IntPtr, System.Type> typeFromKlass
        = new System.Collections.Concurrent.ConcurrentDictionary<System.IntPtr, System.Type>();

    private static readonly object klassAllocLock = new object();
}

/// <summary>Custom marshaler for Eo objects that do not move ownership between native and managed code.
///
/// <para>For internal usage by generated code.</para>
///
/// </summary>
/// <since_tizen> 6 </since_tizen>
class MarshalEoNoMove : ICustomMarshaler
{
    private static ICustomMarshaler instance = new MarshalEoNoMove();

    /// <summary>
    /// Gets an instance of this marshaler.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="cookie">Cookie to identify the marshaler. Unused.</param>
    /// <returns>The marshaler instance.</returns>
    [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "The same marshaler is used for all cases.")]
    public static ICustomMarshaler GetInstance(string cookie) => instance;

    /// <summary>
    /// Clean ups the managed data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ManagedObj">The object to be cleaned.</param>
    public void CleanUpManagedData(object ManagedObj)
    {
    }

    /// <summary>
    /// Clean ups the native data if it was created.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pNativeData">The native data to be cleaned.</param>
    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    /// <summary>
    /// Gets the native data size.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The data size in bytes.</returns>
    public int GetNativeDataSize() => -1;

    /// <summary>
    /// Marshals the given managed object to its native handle.
    /// <para>As this marshaler does not move the reference, the managed code
    /// can keep its reference and does not need to incref.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ManagedObj">The object to be marshalled.</param>
    /// <returns>The marshalled native data.</returns>
    public IntPtr MarshalManagedToNative(object ManagedObj)
    {
        if (ManagedObj == null)
        {
            return IntPtr.Zero;
        }

        IWrapper wrapper = ManagedObj as IWrapper;

        if (wrapper == null)
        {
            throw new ArgumentException("Managed object to be marshalled must be an IWrapper.");
        }

        return wrapper.NativeHandle;
    }

    /// <summary>
    /// Marshals the given native pointer into a managed object.
    /// <para>The given native object has its reference count incremented in order to make
    /// the C# wrapper capable of accessing it while the wrapper is alive.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pNativeData">The native pointer to the EO object.</param>
    /// <returns>The managed wrapper for the given native object.</returns>
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return CoreUI.Wrapper.Globals.CreateWrapperFor(pNativeData, shouldIncRef : true);
    }
}

/// <summary>Custom marshaler for Eo objects that move ownership between native and managed code.
///
/// <para>For internal usage by generated code.</para>
///
/// </summary>
/// <since_tizen> 6 </since_tizen>
class MarshalEoMove : ICustomMarshaler
{
    private static ICustomMarshaler instance = new MarshalEoMove();

    /// <summary>
    /// Gets an instance of this marshaler.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="cookie">Cookie to identify the marshaler. Unused.</param>
    /// <returns>The marshaler instance.</returns>
    [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "The same marshaler is used for all cases.")]
    public static ICustomMarshaler GetInstance(string cookie) => instance;

    /// <summary>
    /// Clean ups the managed data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ManagedObj">The object to be cleaned.</param>
    public void CleanUpManagedData(object ManagedObj)
    {
    }

    /// <summary>
    /// Clean ups the native data if it was created.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pNativeData">The native data to be cleaned.</param>
    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    /// <summary>
    /// Gets the native data size.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The data size in bytes.</returns>
    public int GetNativeDataSize() => -1;

    /// <summary>
    /// Marshals the given managed object to its native handle.
    /// <para>The wrapper given as parameter needs to keep a reference to the native
    /// object, so the EO has its refcount incremented.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ManagedObj">The object to be marshalled.</param>
    /// <returns>The marshalled native data.</returns>
    public IntPtr MarshalManagedToNative(object ManagedObj)
    {
        if (ManagedObj == null)
        {
            return IntPtr.Zero;
        }

        IWrapper wrapper = ManagedObj as IWrapper;

        if (wrapper == null)
        {
            throw new ArgumentException("Managed object to be marshalled must be an IWrapper.");
        }

        return CoreUI.Wrapper.Globals.efl_ref(wrapper.NativeHandle);
    }

    /// <summary>
    /// Marshals the given native pointer into a managed object.
    /// <para>The returned wrapper "steals" the reference to keep it alive.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pNativeData">The native pointer to the EO object.</param>
    /// <returns>The managed wrapper for the given native object.</returns>
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return CoreUI.Wrapper.Globals.CreateWrapperFor(pNativeData, shouldIncRef : false);
    }
}

///<summary>Marshals between System.Type instances and Eo classes (IntPtrs).</summary>
/// <since_tizen> 6 </since_tizen>
class MarshalCoreUIClass : ICustomMarshaler
{
    internal static ICustomMarshaler GetInstance(string cookie)
    {
        CoreUI.DataTypes.Log.Debug("MarshalCoreUIClass.GetInstance cookie " + cookie);
        return new MarshalCoreUIClass();
    }

    public void CleanUpManagedData(object ManagedObj)
    {
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    public int GetNativeDataSize()
    {
        CoreUI.DataTypes.Log.Debug("MarshalCoreUIClass.GetNativeDataSize");
        return 0;
    }

    public IntPtr MarshalManagedToNative(object ManagedObj)
    {
        CoreUI.DataTypes.Log.Debug("MarshalCoreUIClass.MarshallManagedToNative");
        if (ManagedObj == null)
        {
            return IntPtr.Zero;
        }

        var t = (System.Type)ManagedObj;
        return CoreUI.Wrapper.ClassRegister.GetKlass(t);
    }

    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        CoreUI.DataTypes.Log.Debug("MarshalCoreUIClass.MarshalNativeToManaged");
        if (pNativeData == IntPtr.Zero)
        {
            return null;
        }

        return CoreUI.Wrapper.ClassRegister.GetManagedType(pNativeData);
    }
}

class StringPassOwnershipMarshaler : ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        var ret = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(pNativeData);
        CoreUI.DataTypes.MemoryNative.Free(pNativeData);
        return ret;
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return CoreUI.DataTypes.MemoryNative.StrDup((string)managedObj);
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
        // No need to cleanup. C will take care of it.
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    internal static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StringPassOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StringPassOwnershipMarshaler marshaler;
}

class StringKeepOwnershipMarshaler: ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(pNativeData);
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return CoreUI.DataTypes.StringConversion.ManagedStringToNativeUtf8Alloc((string)managedObj);
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
        // No need to free. The Native side will keep the ownership.
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    internal static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StringKeepOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StringKeepOwnershipMarshaler marshaler;
}

class StringsharePassOwnershipMarshaler : ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        var ret = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(pNativeData);
        CoreUI.DataTypes.NativeMethods.eina_stringshare_del(pNativeData);
        return ret;
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return CoreUI.DataTypes.MemoryNative.AddStringshare((string)managedObj);
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
        // No need to free as it's for own() parameters.
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    internal static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StringsharePassOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StringsharePassOwnershipMarshaler marshaler;
}

class StringshareKeepOwnershipMarshaler : ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(pNativeData);
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return CoreUI.DataTypes.MemoryNative.AddStringshare((string)managedObj);
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
        // No need to free, as the native side will keep ownership.
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    internal static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StringshareKeepOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StringshareKeepOwnershipMarshaler marshaler;
}

class StrbufPassOwnershipMarshaler : ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return new CoreUI.DataTypes.Strbuf(pNativeData, CoreUI.DataTypes.Ownership.Managed);
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        CoreUI.DataTypes.Strbuf buf = managedObj as CoreUI.DataTypes.Strbuf;
        buf.ReleaseOwnership();
        return buf.Handle;
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
        // No need to cleanup. C will take care of it.
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    internal static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StrbufPassOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StrbufPassOwnershipMarshaler marshaler;
}

class StrbufKeepOwnershipMarshaler: ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return new CoreUI.DataTypes.Strbuf(pNativeData, CoreUI.DataTypes.Ownership.Unmanaged);
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        CoreUI.DataTypes.Strbuf buf = managedObj as CoreUI.DataTypes.Strbuf;
        return buf.Handle;
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
        // No need to free. The Native side will keep the ownership.
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    internal static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StrbufKeepOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StrbufKeepOwnershipMarshaler marshaler;
}

} // namespace eo

/// <summary>General exception for errors inside the binding.</summary>
/// <since_tizen> 6 </since_tizen>
public class CoreUIException : Exception
{
    /// <summary>
    ///   Default Constructor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUIException()
    {
    }

    /// <summary>Create a new CoreUIException with the given message.</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUIException(string message) : base(message)
    {
    }

    /// <summary>
    ///   Create a new CoreUIException with the given message and inner exception.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception.</param>
    public CoreUIException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

/// <summary>Exception to be raised when a Task fails due to a failed CoreUI.DataTypes.Future.</summary>
/// <since_tizen> 6 </since_tizen>
public class FutureException : CoreUIException
{
    /// <summary>The error code returned by the failed CoreUI.DataTypes.Future.</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Error Error { get; private set; }

    /// <summary>
    ///   Default constructor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public FutureException() : this(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION)
    {
    }

    /// <summary>
    ///   Construct a new exception from the <see cref="CoreUI.DataTypes.Error" />
    /// with a given message
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="message">The message of the exception.</param>
    public FutureException(string message)
        : this(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION, message)
    {
    }

    /// <summary>
    ///   Construct a new exception from the <see cref="CoreUI.DataTypes.Error" />
    /// with a given message and inner exception.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception.</param>
    public FutureException(string message, Exception innerException)
        : this(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION, message, innerException)
    {
    }

    /// <summary>
    ///   Construct a new exception from the <see cref="CoreUI.DataTypes.Error" />
    /// with a given error.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="error">The error of the exception..</param>
    public FutureException(CoreUI.DataTypes.Error error)
        : this(error, "Future failed.")
    {
    }

    /// <summary>
    ///   Construct a new exception from the <see cref="CoreUI.DataTypes.Error" />
    /// with a given error and message.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="error">The error of the exception..</param>
    /// <param name="message">The message of the exception.</param>
    public FutureException(CoreUI.DataTypes.Error error, string message)
        : this(error, message, null)
    {
    }

    /// <summary>
    ///   Construct a new exception from the <see cref="CoreUI.DataTypes.Error" />
    /// with a given error, message and innerException.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="error">The error of the exception..</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception.</param>
    public FutureException(CoreUI.DataTypes.Error error, string message,
                           Exception innerException)
        : base(message, innerException) => Error = error;
}
} // namespace CoreUI
