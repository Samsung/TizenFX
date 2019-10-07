#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

using static UIKit.DataTypes.NativeCustomExportFunctions;
using EoG = UIKit.Wrapper.Globals;

namespace UIKit
{

namespace Wrapper
{

public class Globals
{
    /// <summary>Represents the type of the native UIKit_Class.</summary>
    public enum UIKitClassType
    {
        /// <summary>Regular EFL classes.</summary>
        Regular = 0,
        /// <summary>Non-instantiable efl classes (i.e. Abstracts).</summary>
        RegularNoInstant,
        /// <summary>Interface types.</summary>
        Interface,
        /// <summary>Mixins types.</summary>
        Mixin,
        /// <summary>Invalid class type.</summary>
        Invalid
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool efl_object_init_delegate();
    public static FunctionWrapper<efl_object_init_delegate> efl_object_init_ptr =
        new FunctionWrapper<efl_object_init_delegate>(UIKit.Libs.EoModule, "efl_object_init");
    public static bool efl_object_init() => efl_object_init_ptr.Value.Delegate();

    public delegate void efl_object_shutdown_delegate();
    public static FunctionWrapper<efl_object_shutdown_delegate> efl_object_shutdown_ptr = new FunctionWrapper<efl_object_shutdown_delegate>(UIKit.Libs.EoModule, "efl_object_shutdown");
    public static void efl_object_shutdown() => efl_object_shutdown_ptr.Value.Delegate();
    // [DllImport(UIKit.Libs.Eo)] public static extern void efl_object_shutdown();

    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr efl_mono_wrapper_supervisor_get(IntPtr eo);
    [DllImport(UIKit.Libs.CustomExports)] public static extern void efl_mono_wrapper_supervisor_set(IntPtr eo, IntPtr ws);

    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        _efl_add_internal_start([MarshalAs(UnmanagedType.LPStr)] String file, int line,
                                IntPtr klass, IntPtr parent, byte is_ref, byte is_fallback);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        _efl_add_internal_start_bindings([MarshalAs(UnmanagedType.LPStr)] String file, int line, IntPtr klass, IntPtr parent,
                                         byte is_ref, byte is_fallback, IntPtr substitute_ctor, IntPtr data);
    public delegate  IntPtr
        _efl_add_end_delegate(IntPtr eo, byte is_ref, byte is_fallback);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        _efl_add_end(IntPtr eo, byte is_ref, byte is_fallback);
    public delegate  IntPtr
        efl_ref_delegate(IntPtr eo);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_ref(IntPtr eo);
    public delegate  void
        efl_unref_delegate(IntPtr eo);
    [DllImport(UIKit.Libs.CustomExports)] public static extern void
        efl_unref(IntPtr eo);
    public delegate  int
        efl_ref_count_delegate(IntPtr eo);
    [DllImport(UIKit.Libs.Eo)] public static extern int
        efl_ref_count(IntPtr eo);
    [DllImport(UIKit.Libs.CustomExports)] public static extern void
        efl_mono_wrapper_supervisor_callbacks_set(UIKit.FreeWrapperSupervisorCb freeWrapperSupervisorCb);
    [DllImport(UIKit.Libs.CustomExports)] public static extern void
        efl_mono_native_dispose(IntPtr eo);
    [DllImport(UIKit.Libs.CustomExports)] public static extern void
        efl_mono_thread_safe_native_dispose(IntPtr eo);
    [DllImport(UIKit.Libs.CustomExports)] public static extern void
        efl_mono_thread_safe_efl_unref(IntPtr eo);

    [DllImport(UIKit.Libs.CustomExports)] public static extern void
        efl_mono_thread_safe_free_cb_exec(IntPtr free_cb, IntPtr cb_data);

    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_name_get(IntPtr eo);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr extn46, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr extn46, IntPtr extn47, IntPtr term);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr extn46, IntPtr extn47, IntPtr extn48, IntPtr term);

    public delegate  byte efl_class_functions_set_delegate(IntPtr klass_id, IntPtr object_ops, IntPtr class_ops);
    [DllImport(UIKit.Libs.Eo)] public static extern byte efl_class_functions_set(IntPtr klass_id, IntPtr object_ops, IntPtr class_ops);
    public delegate  IntPtr efl_data_scope_get_delegate(IntPtr obj, IntPtr klass);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr efl_data_scope_get(IntPtr obj, IntPtr klass);
    public delegate  IntPtr efl_super_delegate(IntPtr obj, IntPtr klass);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr efl_super(IntPtr obj, IntPtr klass);
    public delegate  IntPtr efl_class_get_delegate(IntPtr obj);
    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr efl_class_get(IntPtr obj);
    [DllImport(UIKit.Libs.Eo)] public static extern UIKitClassType efl_class_type_get(IntPtr klass);
    public delegate  IntPtr dlerror_delegate();
    [DllImport(UIKit.Libs.Evil)] public static extern IntPtr dlerror();

    [DllImport(UIKit.Libs.Eo)] public static extern IntPtr efl_constructor(IntPtr obj);

    [DllImport(UIKit.Libs.CustomExports)] public static extern IntPtr efl_mono_avoid_top_level_constructor_callback_addr_get();

    [DllImport(UIKit.Libs.Eo)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        efl_event_callback_priority_add(IntPtr obj, IntPtr desc, short priority, IntPtr cb, IntPtr data);

    [DllImport(UIKit.Libs.Eo)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        efl_event_callback_del(IntPtr obj, IntPtr desc, IntPtr cb, IntPtr data);

    [DllImport(UIKit.Libs.Eo)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        efl_event_callback_call(IntPtr obj, IntPtr desc, IntPtr event_info);

    public const int RTLD_NOW = 2;

    public delegate byte class_initializer(IntPtr klass);

    public static T GetParamHelper<T>(Nullable<T> v) where T : struct
    {
        return v.Value;
    }

    public static U GetParamHelper<U>(U v)
    {
        return v;
    }

    public static bool ParamHelperCheck<T>(Nullable<T> v) where T : struct
    {
        return v.HasValue;
    }

    public static bool ParamHelperCheck<U>(U v)
    {
        return v != null;
    }

    public static IntPtr register_class(String class_name, IntPtr base_klass, System.Type type)
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

        IntPtr description_ptr = UIKit.DataTypes.MemoryNative.Alloc(Marshal.SizeOf(description));
        Marshal.StructureToPtr(description, description_ptr, false);

        // FIXME: description_ptr seems to be leaking memory even after an eo_shutdown

        var interface_list = EoG.get_efl_interfaces(type);

        UIKit.DataTypes.Log.Debug($"Going to register new class named {class_name}");
        IntPtr klass = EoG.call_efl_class_new(description_ptr, base_klass, interface_list);
        if (klass == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error("klass was not registered");
        }
        else
        {
            UIKit.DataTypes.Log.Debug("Registered class successfully");
        }

        return klass;
    }

    public static List<IntPtr> get_efl_interfaces(System.Type type)
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
                    if (attr is UIKit.Wrapper.NativeClass)
                    {
                        ifaces_lst.Add(((UIKit.Wrapper.NativeClass)attr).GetUIKitClass());
                        break;
                    }
                }
            }
        }

        return ifaces_lst;
    }

    private static UIKit.Wrapper.NativeClass GetNativeClass(System.Type type)
    {
        var attrs = System.Attribute.GetCustomAttributes(type, false);
        foreach (var attr in attrs)
        {
            if (attr is UIKit.Wrapper.NativeClass)
            {
                return (UIKit.Wrapper.NativeClass)attr;
            }
        }

        return null;
    }

    public static System.Collections.Generic.List<System.Reflection.MethodInfo>
        GetUserMethods(System.Type type)
    {
        var r = new System.Collections.Generic.List<System.Reflection.MethodInfo>();
        var flags = System.Reflection.BindingFlags.Instance
                    | System.Reflection.BindingFlags.DeclaredOnly
                    | System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.NonPublic;
        r.AddRange(type.GetMethods(flags));
        var base_type = type.BaseType;

        for (;base_type != null; base_type = base_type.BaseType)
        {
            if (IsGeneratedClass(base_type))
            {
                return r;
            }

            r.AddRange(base_type.GetMethods(flags));
        }
        return r;
    }

    public static byte class_initializer_call(IntPtr klass, System.Type type)
    {
        UIKit.DataTypes.Log.Debug($"called with 0x{klass.ToInt64():x} {type}");
        var derived = type.BaseType;
        UIKit.Wrapper.NativeClass nativeClass = GetNativeClass(derived);

        while (nativeClass == null)
        {
            derived = derived.BaseType;
            if (derived == null)
                break;
            nativeClass = GetNativeClass(derived);
        }

        if (nativeClass != null)
        {
            UIKit.DataTypes.Log.Debug("nativeClass != null");
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

            UIKit_Object_Ops ops;
            ops.descs = descs_ptr;
            ops.count = (UIntPtr)count;
            IntPtr ops_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(ops));
            Marshal.StructureToPtr(ops, ops_ptr, false);
            UIKit.Wrapper.Globals.efl_class_functions_set(klass, ops_ptr, IntPtr.Zero);
            //EoKlass = klass;
        }
        else
        {
            UIKit.DataTypes.Log.Debug("nativeClass == null");
        }

       return 1;
    }

    public static IntPtr call_efl_class_new(IntPtr desc, IntPtr bk, List<IntPtr> il = null)
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

    public static UIKit.Wrapper.WrapperSupervisor WrapperSupervisorPtrToManaged(IntPtr wsPtr)
    {
        return (UIKit.Wrapper.WrapperSupervisor) GCHandle.FromIntPtr(wsPtr).Target;
    }

    public static UIKit.Wrapper.WrapperSupervisor GetWrapperSupervisor(IntPtr eo)
    {
        var wsPtr = UIKit.Wrapper.Globals.efl_mono_wrapper_supervisor_get(eo);
        if (wsPtr == IntPtr.Zero)
        {
            return null;
        }

        return WrapperSupervisorPtrToManaged(wsPtr);
    }

    public static void SetWrapperSupervisor(IntPtr eo, UIKit.Wrapper.WrapperSupervisor ws)
    {
        GCHandle gch = GCHandle.Alloc(ws);
        UIKit.Wrapper.Globals.efl_mono_wrapper_supervisor_set(eo, GCHandle.ToIntPtr(gch));
    }

    public static void free_dict_values(Dictionary<String, IntPtr> dict)
    {
        foreach (IntPtr ptr in dict.Values)
        {
            UIKit.DataTypes.MemoryNative.Free(ptr);
        }
    }

    public static void free_stringshare_values(Dictionary<String, IntPtr> dict)
    {
        foreach (IntPtr ptr in dict.Values)
        {
            UIKit.DataTypes.NativeMethods.eina_stringshare_del(ptr);
        }
    }

    public static void free_gchandle(IntPtr ptr)
    {
        GCHandle handle = GCHandle.FromIntPtr(ptr);
        handle.Free();
    }

    public static System.Threading.Tasks.Task<UIKit.DataTypes.Value> WrapAsync(UIKit.DataTypes.Future future, CancellationToken token)
    {
        // Creates a task that will wait for SetResult for completion.
        // TaskCompletionSource is used to create tasks for 'external' Task sources.
        var tcs = new System.Threading.Tasks.TaskCompletionSource<UIKit.DataTypes.Value>();

        // Flag to be passed to the cancell callback
        bool fulfilled = false;

        future.Then((UIKit.DataTypes.Value received) =>
        {
            lock (future)
            {
                // Convert an failed Future to a failed Task.
                if (received.GetValueType() == UIKit.DataTypes.ValueType.Error)
                {
                    UIKit.DataTypes.Error err;
                    received.Get(out err);
                    if (err == UIKit.DataTypes.Error.ECANCELED)
                    {
                        tcs.SetCanceled();
                    }
                    else
                    {
                        tcs.TrySetException(new UIKit.FutureException(received));
                    }
                }
                else
                {
                    // Async receiver methods may consume the value C# wrapper, like when awaiting in the start of an
                    // using block. In order to continue to forward the value correctly to the next futures
                    // in the chain, we give the Async wrapper a copy of the received wrapper.
                    tcs.SetResult(new UIKit.DataTypes.Value(received));
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
                // Will trigger the Then callback above with an UIKit.DataTypes.Error
                if (!fulfilled)
                {
                    future.Cancel();
                }
            }
        });

        return tcs.Task;
    }

    /// <summary>Returns whether the given type was generated by eolian-mono</summary>
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
    ///
    /// <param name="handle">The Eo id to be wrapped.</param>
    /// <param name="shouldIncRef">Whether we should increase the refcount of the Eo instance.</param>
    /// <returns>The C# wrapper for this instance.</returns>
    public static UIKit.Wrapper.IWrapper CreateWrapperFor(System.IntPtr handle, bool shouldIncRef=true)
    {

        if (handle == IntPtr.Zero)
        {
            return null;
        }

        UIKit.Wrapper.Globals.efl_ref(handle);
        try
        {
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(handle);
            if (ws != null && ws.Target != null)
            {
                if (!shouldIncRef)
                {
                    UIKit.Wrapper.Globals.efl_unref(handle);
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
                var name = UIKit.DataTypes.StringConversion.NativeUtf8ToManagedString(nativeName);

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
            var ret = (UIKit.Wrapper.IWrapper) constructor.Invoke(new object[1] { wh });

            if (ret == null)
            {
                throw new InvalidOperationException($"Can't construct type {managedType} from IntPtr handle");
            }

            if (shouldIncRef)
            {
                UIKit.Wrapper.Globals.efl_ref(handle);
            }

            return ret;
        }
        finally
        {
            UIKit.Wrapper.Globals.efl_unref(handle);
        }
    }

    private static UIKit.FreeWrapperSupervisorCb FreeWrapperSupervisorCallbackDelegate = new UIKit.FreeWrapperSupervisorCb(FreeWrapperSupervisorCallback);
    public static void FreeWrapperSupervisorCallback(IntPtr eo)
    {
        try
        {
            var wsPtr = UIKit.Wrapper.Globals.efl_mono_wrapper_supervisor_get(eo);
            if (wsPtr == IntPtr.Zero)
            {
                UIKit.DataTypes.Log.Error($"Invalid wrapper supervisor [Eo pointer: {eo.ToInt64():x}]");
                return;
            }

            UIKit.Wrapper.Globals.efl_mono_wrapper_supervisor_set(eo, IntPtr.Zero);

            GCHandle gch = GCHandle.FromIntPtr(wsPtr);
            var ws = (UIKit.Wrapper.WrapperSupervisor) gch.Target;
            foreach (var item in ws.EoEvents)
            {
                if (!efl_event_callback_del(eo, item.Key.desc, item.Value.evtCallerPtr, wsPtr))
                {
                    UIKit.DataTypes.Log.Error($"Failed to remove event proxy for event {item.Key.desc} [eo: {eo.ToInt64():x}; cb: {item.Value.evtCallerPtr.ToInt64():x}]");
                }
            }

            // Free the native eo
            UIKit.Wrapper.Globals.efl_unref(eo);

            // now the WrapperSupervisor can be collected, and so its member:
            //     - the event dictionary
            //     - and the ObjectWrapper if it is still pinned
            gch.Free();
        }
        catch (Exception e)
        {
            UIKit.DataTypes.Log.Error(e.ToString());
            UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
        }
    }

    public static void SetNativeDisposeCallbacks()
    {
        efl_mono_wrapper_supervisor_callbacks_set(FreeWrapperSupervisorCallbackDelegate);
    }

    public static void ThreadSafeFreeCbExec(EinaFreeCb cbFreeCb, IntPtr cbData)
    {
        EinaFreeCb cb = (IntPtr gcHandlePtr) => {
            cbFreeCb(cbData);
            GCHandle gcHandle = GCHandle.FromIntPtr(gcHandlePtr);
            gcHandle.Free();
        };

        Monitor.Enter(UIKit.All.InitLock);
        if (UIKit.All.MainLoopInitialized)
        {
            IntPtr cbPtr = Marshal.GetFunctionPointerForDelegate(cb);
            var handle = GCHandle.Alloc(cb);
            var handlePtr = GCHandle.ToIntPtr(handle);

            efl_mono_thread_safe_free_cb_exec(cbPtr, handlePtr);
        }
        Monitor.Exit(UIKit.All.InitLock);
    }

    /// <summary>
    /// Internal struct used by the binding to pass the native handle pointer
    /// to the managed object wrapping constructor.
    /// Internal usage only: do not use this class in inherited classes.
    /// </summary>
    public struct WrappingHandle
    {
        public WrappingHandle(IntPtr h)
        {
            NativeHandle = h;
        }

        public IntPtr NativeHandle { get; private set; }
    }

} // Globals

public static class Config
{

    public static void Init()
    {
        Globals.efl_object_init();
        Globals.SetNativeDisposeCallbacks();
    }

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
public abstract class NativeClass : System.Attribute
{
    public abstract IntPtr GetUIKitClass();
    public abstract System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited);
}

/// <summary>Attribute for private native classes.
///
/// <para>For internal usage by generated code only.</para></summary>
public class PrivateNativeClass : NativeClass
{
    public override IntPtr GetUIKitClass()
    {
        return IntPtr.Zero;
    }

    public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
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
public class BindingEntity: System.Attribute
{
    public static bool IsBindingEntity(System.Type t)
    {
        return Attribute.GetCustomAttribute(t, typeof(BindingEntity), false) != null;
    }
}

public interface IWrapper
{
    /// <summary>Pointer to internal Eo instance.</summary>
    IntPtr NativeHandle
    {
        get;
    }

    /// <summary>Pointer to internal Eo class.</summary>
    IntPtr NativeClass
    {
        get;
    }
}

public static class ClassRegister
{
    public static System.Type GetManagedType(IntPtr klass)
    {
        System.Type t;
        if (UIKit.Wrapper.ClassRegister.typeFromKlass.TryGetValue(klass, out t))
        {
            return t;
        }

        // If it isn't on the dictionary then it is a Native binding class
        IntPtr namePtr = UIKit.Wrapper.Globals.efl_class_name_get(klass);
        if (namePtr == IntPtr.Zero)
        {
            throw new System.InvalidOperationException($"Could not get Native class name. Handle: {klass}");
        }

        string name = UIKit.DataTypes.StringConversion.NativeUtf8ToManagedString(namePtr)
                      .Replace("_", ""); // Convert UIKit C name to C# name

        // Check if this is an internal implementation of an abstract class
        var abstract_impl_suffix = "Realized";
        if (name.EndsWith(abstract_impl_suffix))
        {
            name = name.Substring(0, name.Length - abstract_impl_suffix.Length);
            var lastDot = name.LastIndexOf(".");
            var klassName = name.Substring(lastDot + 1);
            name += "+" + klassName + abstract_impl_suffix; // '+' is the separator for nested classes
        }

        // When converting to managed, interfaces and mixins gets the 'I' prefix.
        var klass_type = UIKit.Wrapper.Globals.efl_class_type_get(klass);
        if (klass_type == UIKit.Wrapper.Globals.UIKitClassType.Interface || klass_type == UIKit.Wrapper.Globals.UIKitClassType.Mixin)
        {
            var pos = name.LastIndexOf(".");
            name = name.Insert(pos + 1, "I"); // -1 if not found, inserts at 0 normally
        }

        //TIZEN_ONLY(20191004): Change the Efl to UIKit prefix
        if (name.Contains("Efl."))
          name = name.Replace("Efl", "UIKit");
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
                return typeof(UIKit.ObjectRealized);
            }
        }

        AddToKlassTypeBiDictionary(klass, t); // Cache it in the dictionary
        return t;
    }

    public static IntPtr GetKlass(System.Type objectType)
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

    public static IntPtr GetInheritKlassOrRegister(IntPtr baseKlass, System.Type objectType)
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
            IntPtr newKlass = UIKit.Wrapper.Globals.register_class(objectType.FullName, baseKlass, objectType);
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

        throw new System.InvalidOperationException($"Class '{objectType.FullName}' is not an UIKit object");
    }

    private static IntPtr GetNativeKlassPtr(System.Type objectType)
    {
        if (objectType == null)
        {
            return IntPtr.Zero;
        }

        if (objectType.IsInterface)
        {
            // Try to get the *Concrete class
            var assembly = objectType.Assembly;
            objectType = assembly.GetType(objectType.FullName + "Concrete");

            if (objectType == null)
            {
                return IntPtr.Zero;
            }
        }

        var method = objectType.GetMethod("GetUIKitClassStatic",
                                          System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

        if (method == null)
        {
            return IntPtr.Zero;
        }

        return (IntPtr)(method.Invoke(null, null));
    }

    public static void AddToKlassTypeBiDictionary(IntPtr klassPtr, System.Type objectType)
    {
        klassFromType[objectType] = klassPtr;
        typeFromKlass[klassPtr] = objectType;
    }

    public static System.Collections.Concurrent.ConcurrentDictionary<System.Type, System.IntPtr> klassFromType
        = new System.Collections.Concurrent.ConcurrentDictionary<System.Type, System.IntPtr>();

    public static System.Collections.Concurrent.ConcurrentDictionary<System.IntPtr, System.Type> typeFromKlass
        = new System.Collections.Concurrent.ConcurrentDictionary<System.IntPtr, System.Type>();

    private static readonly object klassAllocLock = new object();
}

public interface IOwnershipTag
{
}

public class OwnTag : IOwnershipTag
{
}

public class NonOwnTag : IOwnershipTag
{
}

public class MarshalEo<U> : ICustomMarshaler
    where U : IOwnershipTag
{
    public static ICustomMarshaler GetInstance(string cookie)
    {
        UIKit.DataTypes.Log.Debug("MarshalWrapper.GetInstace cookie " + cookie);
        return new MarshalEo<U>();
    }

    public void CleanUpManagedData(object ManagedObj)
    {
        //UIKit.DataTypes.Log.Warning("MarshalWrapper.CleanUpManagedData not implemented");
        //throw new NotImplementedException();
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
        //UIKit.DataTypes.Log.Warning("MarshalWrapper.CleanUpNativeData not implemented");
        //throw new NotImplementedException();
    }

    public int GetNativeDataSize()
    {
        UIKit.DataTypes.Log.Debug("MarshalWrapper.GetNativeDataSize");
        return 0;
        //return 8;
    }

    public IntPtr MarshalManagedToNative(object ManagedObj)
    {
        UIKit.DataTypes.Log.Debug("MarshalWrapper.MarshallManagedToNative");

        if (ManagedObj == null)
        {
            return IntPtr.Zero;
        }

        var r = ((IWrapper)ManagedObj).NativeHandle;
        if (typeof(U) == typeof(OwnTag))
        {
            UIKit.Wrapper.Globals.efl_ref(r);
        }

        return r;
    }

    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return UIKit.Wrapper.Globals.CreateWrapperFor(pNativeData, shouldIncRef : typeof(U) != typeof(OwnTag));
    }
}

///<summary>Marshals between System.Type instances and Eo classes (IntPtrs).</summary>
public class MarshalUIKitClass : ICustomMarshaler
{
    public static ICustomMarshaler GetInstance(string cookie)
    {
        UIKit.DataTypes.Log.Debug("MarshalUIKitClass.GetInstance cookie " + cookie);
        return new MarshalUIKitClass();
    }

    public void CleanUpManagedData(object ManagedObj)
    {
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    public int GetNativeDataSize()
    {
        UIKit.DataTypes.Log.Debug("MarshalUIKitClass.GetNativeDataSize");
        return 0;
    }

    public IntPtr MarshalManagedToNative(object ManagedObj)
    {
        UIKit.DataTypes.Log.Debug("MarshalUIKitClass.MarshallManagedToNative");
        if (ManagedObj == null)
        {
            return IntPtr.Zero;
        }

        var t = (System.Type)ManagedObj;
        return UIKit.Wrapper.ClassRegister.GetKlass(t);
    }

    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        UIKit.DataTypes.Log.Debug("MarshalUIKitClass.MarshalNativeToManaged");
        if (pNativeData == IntPtr.Zero)
        {
            return null;
        }

        return UIKit.Wrapper.ClassRegister.GetManagedType(pNativeData);
    }
}

public class StringPassOwnershipMarshaler : ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        var ret = UIKit.DataTypes.StringConversion.NativeUtf8ToManagedString(pNativeData);
        UIKit.DataTypes.MemoryNative.Free(pNativeData);
        return ret;
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return UIKit.DataTypes.MemoryNative.StrDup((string)managedObj);
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

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StringPassOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StringPassOwnershipMarshaler marshaler;
}

public class StringKeepOwnershipMarshaler: ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return UIKit.DataTypes.StringConversion.NativeUtf8ToManagedString(pNativeData);
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return UIKit.DataTypes.StringConversion.ManagedStringToNativeUtf8Alloc((string)managedObj);
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

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StringKeepOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StringKeepOwnershipMarshaler marshaler;
}

public class StringsharePassOwnershipMarshaler : ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        var ret = UIKit.DataTypes.StringConversion.NativeUtf8ToManagedString(pNativeData);
        UIKit.DataTypes.NativeMethods.eina_stringshare_del(pNativeData);
        return ret;
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return UIKit.DataTypes.MemoryNative.AddStringshare((string)managedObj);
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

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StringsharePassOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StringsharePassOwnershipMarshaler marshaler;
}

public class StringshareKeepOwnershipMarshaler : ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return UIKit.DataTypes.StringConversion.NativeUtf8ToManagedString(pNativeData);
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return UIKit.DataTypes.MemoryNative.AddStringshare((string)managedObj);
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

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StringshareKeepOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StringshareKeepOwnershipMarshaler marshaler;
}

public class StrbufPassOwnershipMarshaler : ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return new UIKit.DataTypes.Strbuf(pNativeData, UIKit.DataTypes.Ownership.Managed);
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        UIKit.DataTypes.Strbuf buf = managedObj as UIKit.DataTypes.Strbuf;
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

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new StrbufPassOwnershipMarshaler();
        }

        return marshaler;
    }

    static private StrbufPassOwnershipMarshaler marshaler;
}

public class StrbufKeepOwnershipMarshaler: ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return new UIKit.DataTypes.Strbuf(pNativeData, UIKit.DataTypes.Ownership.Unmanaged);
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        UIKit.DataTypes.Strbuf buf = managedObj as UIKit.DataTypes.Strbuf;
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

    public static ICustomMarshaler GetInstance(string cookie)
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
public class UIKitException : Exception
{
    /// <summary>Create a new UIKitException with the given message.</summary>
    public UIKitException(string message) : base(message)
    {
    }
}

/// <summary>Exception to be raised when a Task fails due to a failed UIKit.DataTypes.Future.</summary>
public class FutureException : UIKitException
{
    /// <summary>The error code returned by the failed UIKit.DataTypes.Future.</summary>
    public UIKit.DataTypes.Error Error { get; private set; }

    /// <summary>Construct a new exception from the UIKit.DataTypes.Error stored in the given UIKit.DataTypes.Value.</summary>
    public FutureException(UIKit.DataTypes.Value value) : base("Future failed.")
    {
        if (value.GetValueType() != UIKit.DataTypes.ValueType.Error)
        {
            throw new ArgumentException("FutureException must receive an UIKit.DataTypes.Value with UIKit.DataTypes.Error.");
        }

        UIKit.DataTypes.Error err;
        value.Get(out err);
        Error = err;
    }
}

} // namespace UIKit
