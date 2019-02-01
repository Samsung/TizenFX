#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

using static Eina.NativeCustomExportFunctions;
using EoG = Efl.Eo.Globals;

namespace Efl { namespace Eo {

public class Globals {
    [DllImport(efl.Libs.Eo)] public static extern void efl_object_init();
    [DllImport(efl.Libs.Eo)] public static extern void efl_object_shutdown();
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        _efl_add_internal_start([MarshalAs(UnmanagedType.LPStr)] String file, int line,
                                IntPtr klass, IntPtr parent, byte is_ref, byte is_fallback);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        _efl_add_end(IntPtr eo, byte is_ref, byte is_fallback);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_ref(IntPtr eo);
    [DllImport(efl.Libs.CustomExports)] public static extern void
        efl_unref(IntPtr eo);
    [DllImport(efl.Libs.Eo)] public static extern int
        efl_ref_count(IntPtr eo);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr extn46, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr extn46, IntPtr extn47, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_class_new(IntPtr class_description, IntPtr parent, IntPtr extn1, IntPtr extn2, IntPtr extn3, IntPtr extn4, IntPtr extn5, IntPtr extn6, IntPtr extn7, IntPtr extn8, IntPtr extn9, IntPtr extn10, IntPtr extn11, IntPtr extn12, IntPtr extn13, IntPtr extn14, IntPtr extn15, IntPtr extn16, IntPtr extn17, IntPtr extn18, IntPtr extn19, IntPtr extn20, IntPtr extn21, IntPtr extn22, IntPtr extn23, IntPtr extn24, IntPtr extn25, IntPtr extn26, IntPtr extn27, IntPtr extn28, IntPtr extn29, IntPtr extn30, IntPtr extn31, IntPtr extn32, IntPtr extn33, IntPtr extn34, IntPtr extn35, IntPtr extn36, IntPtr extn37, IntPtr extn38, IntPtr extn39, IntPtr extn40, IntPtr extn41, IntPtr extn42, IntPtr extn43, IntPtr extn44, IntPtr extn45, IntPtr extn46, IntPtr extn47, IntPtr extn48, IntPtr term);
    [DllImport(efl.Libs.Eo)] public static extern byte efl_class_functions_set(IntPtr klass_id, IntPtr object_ops, IntPtr class_ops);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr efl_data_scope_get(IntPtr obj, IntPtr klass);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr efl_super(IntPtr obj, IntPtr klass);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr efl_class_get(IntPtr obj);
#if WIN32
    public static IntPtr RTLD_DEFAULT = new IntPtr(1);
#else
    public static IntPtr RTLD_DEFAULT = new IntPtr(0);
#endif
    [DllImport(efl.Libs.Evil)] public static extern IntPtr dlerror();
    [DllImport(efl.Libs.Evil)] public static extern IntPtr dlsym
       (IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] String name);

   [DllImport(efl.Libs.Eo)] public static extern bool efl_event_callback_priority_add(
              System.IntPtr obj,
              IntPtr desc,
              short priority,
              Efl.EventCb cb,
              System.IntPtr data);
   [DllImport(efl.Libs.Eo)] public static extern bool efl_event_callback_del(
              System.IntPtr obj,
              IntPtr desc,
              Efl.EventCb cb,
              System.IntPtr data);
    [DllImport(efl.Libs.Eo)] public static extern IntPtr
        efl_object_legacy_only_event_description_get([MarshalAs(UnmanagedType.LPStr)] String name);

    public static System.Collections.Concurrent.ConcurrentDictionary<System.Type, System.IntPtr> klasses
        = new System.Collections.Concurrent.ConcurrentDictionary<System.Type, System.IntPtr>();
    
    public const int RTLD_NOW = 2;

    public delegate byte class_initializer(IntPtr klass);

    public static IntPtr register_class(String class_name, IntPtr base_klass, System.Type type)
    {
        ClassDescription description;
        description.version = 2; // EO_VERSION
        description.name = class_name;
        description.class_type = 0; // REGULAR
        description.data_size = (UIntPtr)8;
        description.class_initializer = IntPtr.Zero;
        description.class_constructor = IntPtr.Zero;
        description.class_destructor = IntPtr.Zero;

        class_initializer init = (IntPtr kls) =>
            {
                return Globals.class_initializer_call(kls, type);
            };
        
        description.class_initializer = Marshal.GetFunctionPointerForDelegate(init);

        IntPtr description_ptr = Eina.MemoryNative.Alloc(Marshal.SizeOf(description));
        Marshal.StructureToPtr(description, description_ptr, false);

        var interface_list = EoG.get_efl_interfaces(type);

        System.Console.WriteLine ("Interafaces: {0}", interface_list.Count);

        Eina.Log.Debug("Going to register!");
        IntPtr klass = EoG.call_efl_class_new(description_ptr, base_klass, interface_list);
        if(klass == IntPtr.Zero)
        {
            Eina.Log.Error("klass was not registered");
            Console.WriteLine("klass was not registered");
        }
        else
            Eina.Log.Debug("Registered class successfully");
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
                  if (attr is Efl.Eo.NativeClass) {
                    ifaces_lst.Add(((Efl.Eo.NativeClass)attr).GetEflClass());
                    break;
                  }
               }
            }
        }
        return ifaces_lst;
    }
    private static Efl.Eo.NativeClass get_native_class(System.Type type)
    {
        var attrs = System.Attribute.GetCustomAttributes(type);
        foreach (var attr in attrs)
        {
            if (attr is Efl.Eo.NativeClass) {
                return (Efl.Eo.NativeClass)attr;
            }
        }
        return null;
    }
    public static byte class_initializer_call(IntPtr klass, System.Type type)
    {
        Console.WriteLine("class_intiailizer_call 0x{1} {0}", type, klass);
        Efl.Eo.NativeClass nativeClass = get_native_class(type.BaseType);

        if (nativeClass != null)
        {
            Console.WriteLine("nativeClass != null");
            var descs = nativeClass.GetEoOps(type);
            var count = descs.Count;

            var all_interfaces = type.GetInterfaces();
            var base_interfaces = type.BaseType.GetInterfaces();
            foreach (var iface in all_interfaces)
            {
                if (!System.Array.Exists(base_interfaces, element => element == iface))
                {
                    var nc = get_native_class(iface);
                    if(nc != null)
                    {
                        var moredescs = nc.GetEoOps(type);
                        Console.WriteLine("adding {0} more descs to registration", moredescs.Count);
                        descs.AddRange(moredescs);
                        count = descs.Count;
                    }
                }
            }
            
            IntPtr descs_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(descs[0])*count);
            IntPtr ptr = descs_ptr;
            for(int i = 0; i != count; ++i)
            {
               Marshal.StructureToPtr(descs[i], ptr, false);
               ptr = IntPtr.Add(ptr, Marshal.SizeOf(descs[0]));
            }
            Efl_Object_Ops ops;
            ops.descs = descs_ptr;
            ops.count = (UIntPtr)count;
            IntPtr ops_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(ops));
            Marshal.StructureToPtr(ops, ops_ptr, false);
            Efl.Eo.Globals.efl_class_functions_set(klass, ops_ptr, IntPtr.Zero);
            //EoKlass = klass;
        }
        else
            Console.WriteLine("nativeClass == null");
            
       return 1;
    }
    public static IntPtr call_efl_class_new(IntPtr desc, IntPtr bk, List<IntPtr> il = null)
    {
        IntPtr nul = IntPtr.Zero;
        int iface_list_count = (il == null ? 0 : il.Count);
        switch(iface_list_count)
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
    public static IntPtr instantiate_start(IntPtr klass, Efl.Object parent)
    {
        Eina.Log.Debug($"Instantiating from klass 0x{klass.ToInt64():x}");
        Console.WriteLine($"Instantiating from klass 0x{klass.ToInt64():x}");
        System.IntPtr parent_ptr = System.IntPtr.Zero;
        if(parent != null)
            parent_ptr = parent.NativeHandle;

        System.IntPtr eo = Efl.Eo.Globals._efl_add_internal_start("file", 0, klass, parent_ptr, 1, 0);
        if (eo == System.IntPtr.Zero)
        {
            throw new Exception("Instantiation failed");
        }
        
        Console.WriteLine($"Eo instance right after internal_start 0x{eo.ToInt64():x} with refcount {Efl.Eo.Globals.efl_ref_count(eo)}");
        Console.WriteLine($"Parent was 0x{parent_ptr.ToInt64()}");
        return eo;
    }

    public static IntPtr instantiate_end(IntPtr eo) {
        Eina.Log.Debug("calling efl_add_internal_end");
        eo = Efl.Eo.Globals._efl_add_end(eo, 1, 0);
        Eina.Log.Debug($"efl_add_end returned eo 0x{eo.ToInt64():x}");
        return eo;
    }
    public static void data_set(Efl.Eo.IWrapper obj)
    {
      Eina.Log.Debug($"Calling data_scope_get with obj {obj.NativeHandle.ToInt64():x} and klass {obj.NativeClass.ToInt64():x}");
      IntPtr pd = Efl.Eo.Globals.efl_data_scope_get(obj.NativeHandle, obj.NativeClass);
      {
          GCHandle gch = GCHandle.Alloc(obj);
          EolianPD epd;
          epd.pointer = GCHandle.ToIntPtr(gch);
          Marshal.StructureToPtr(epd, pd, false);
      }
    }
    public static Efl.Eo.IWrapper data_get(IntPtr pd)
    {
        EolianPD epd = (EolianPD)Marshal.PtrToStructure(pd, typeof(EolianPD));
        if(epd.pointer != IntPtr.Zero)
        {
            GCHandle gch = GCHandle.FromIntPtr(epd.pointer);
            return (Efl.Eo.IWrapper)gch.Target;
        }
        else
            return null;
    }

    public static IntPtr cached_string_to_intptr(Dictionary<String, IntPtr> dict, String str)
    {
        IntPtr ptr = IntPtr.Zero;

        if (str == null)
            return ptr;

        if (!dict.TryGetValue(str, out ptr))
        {
            ptr = Eina.StringConversion.ManagedStringToNativeUtf8Alloc(str);
            dict[str] = ptr;
        }

        return ptr;
    }

    public static IntPtr cached_stringshare_to_intptr(Dictionary<String, IntPtr> dict, String str)
    {
        IntPtr ptr = IntPtr.Zero;

        if (str == null)
            return ptr;

        if (!dict.TryGetValue(str, out ptr))
        {
            ptr = Eina.Stringshare.eina_stringshare_add(str);
            dict[str] = ptr;
        }

        return ptr;
    }

    public static void free_dict_values(Dictionary<String, IntPtr> dict)
    {
        foreach(IntPtr ptr in dict.Values)
        {
            Eina.MemoryNative.Free(ptr);
        }
    }

    public static void free_stringshare_values(Dictionary<String, IntPtr> dict)
    {
        foreach(IntPtr ptr in dict.Values)
        {
            Eina.Stringshare.eina_stringshare_del(ptr);
        }
    }

    public static void free_gchandle(IntPtr ptr)
    {
        GCHandle handle = GCHandle.FromIntPtr(ptr);
        handle.Free();
    }

    public static System.Threading.Tasks.Task<Eina.Value> WrapAsync(Eina.Future future, CancellationToken token)
    {
        // Creates a task that will wait for SetResult for completion.
        // TaskCompletionSource is used to create tasks for 'external' Task sources.
        var tcs = new System.Threading.Tasks.TaskCompletionSource<Eina.Value>();

        // Flag to be passed to the cancell callback
        bool fulfilled = false;

        future.Then((Eina.Value received) => {
                lock (future)
                {
                    // Convert an failed Future to a failed Task.
                    if (received.GetValueType() == Eina.ValueType.Error)
                    {
                        Eina.Error err;
                        received.Get(out err);
                        if (err == Eina.Error.ECANCELED)
                            tcs.SetCanceled();
                        else
                            tcs.TrySetException(new Efl.FutureException(received));
                    }
                    else
                    {
                        // Will mark the returned task below as completed.
                        tcs.SetResult(received);
                    }
                    fulfilled = true;
                    return received;
                }
        });
        // Callback to be called when the token is cancelled.
        token.Register(() => {
                lock (future)
                {
                    // Will trigger the Then callback above with an Eina.Error
                    if (!fulfilled)
                        future.Cancel();
                }
        });

        return tcs.Task;
    }
} // Globals

public static class Config
{
    public static void Init()
    {
        Globals.efl_object_init();
    }

    public static void Shutdown()
    {
        Globals.efl_object_shutdown();
    }
}

[System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Interface,
                       AllowMultiple = false,
                       Inherited = true)
]
public abstract class NativeClass : System.Attribute
{
    public abstract IntPtr GetEflClass();
    public abstract System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type);
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

public interface IOwnershipTag
{
}

public class OwnTag : IOwnershipTag
{
}

public class NonOwnTag : IOwnershipTag
{
}

public class MarshalTest<T, U> : ICustomMarshaler
    where U : IOwnershipTag
{
    public static ICustomMarshaler GetInstance(string cookie)
    {
        Eina.Log.Debug("MarshalTest.GetInstace cookie " + cookie);
        return new MarshalTest<T, U>();
    }
    public void CleanUpManagedData(object ManagedObj)
    {
        //Eina.Log.Warning("MarshalTest.CleanUpManagedData not implemented");
        //throw new NotImplementedException();
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
        //Eina.Log.Warning("MarshalTest.CleanUpNativeData not implemented");
        //throw new NotImplementedException();
    }

    public int GetNativeDataSize()
    {
        Eina.Log.Debug("MarshalTest.GetNativeDataSize");
        return 0;
        //return 8;
    }

    public IntPtr MarshalManagedToNative(object ManagedObj)
    {
        Eina.Log.Debug("MarshalTest.MarshallManagedToNative");
        var r = ((IWrapper)ManagedObj).NativeHandle;
        if (typeof(U) == typeof(OwnTag))
            Efl.Eo.Globals.efl_ref(r);
        return r;
    }

    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        Eina.Log.Debug("MarshalTest.MarshalNativeToManaged");
        if (typeof(U) != typeof(OwnTag))
            Efl.Eo.Globals.efl_ref(pNativeData);
        return Activator.CreateInstance(typeof(T), new System.Object[] {pNativeData});
//        return null;
    }
}

public class StringPassOwnershipMarshaler : ICustomMarshaler {
    public object MarshalNativeToManaged(IntPtr pNativeData) {
        var ret = Eina.StringConversion.NativeUtf8ToManagedString(pNativeData);
        Eina.MemoryNative.Free(pNativeData);
        return ret;
    }

    public IntPtr MarshalManagedToNative(object managedObj) {
        return Eina.MemoryNative.StrDup((string)managedObj);
    }

    public void CleanUpNativeData(IntPtr pNativeData) {
        // No need to cleanup. C will take care of it.
    }

    public void CleanUpManagedData(object managedObj) {
    }

    public int GetNativeDataSize() {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie) {
        if (marshaler == null) {
            marshaler = new StringPassOwnershipMarshaler();
        }
        return marshaler;
    }
    static private StringPassOwnershipMarshaler marshaler;
}

public class StringKeepOwnershipMarshaler: ICustomMarshaler {
    public object MarshalNativeToManaged(IntPtr pNativeData) {
        return Eina.StringConversion.NativeUtf8ToManagedString(pNativeData);
    }

    public IntPtr MarshalManagedToNative(object managedObj) {
        return Eina.StringConversion.ManagedStringToNativeUtf8Alloc((string)managedObj);
    }

    public void CleanUpNativeData(IntPtr pNativeData) {
        // No need to free. The Native side will keep the ownership.
    }

    public void CleanUpManagedData(object managedObj) {
    }

    public int GetNativeDataSize() {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie) {
        if (marshaler == null) {
            marshaler = new StringKeepOwnershipMarshaler();
        }
        return marshaler;
    }
    static private StringKeepOwnershipMarshaler marshaler;
}

public class StringsharePassOwnershipMarshaler : ICustomMarshaler {
    public object MarshalNativeToManaged(IntPtr pNativeData) {
        var ret = Eina.StringConversion.NativeUtf8ToManagedString(pNativeData);
        Eina.Stringshare.eina_stringshare_del(pNativeData);
        return ret;
    }

    public IntPtr MarshalManagedToNative(object managedObj) {
        return Eina.Stringshare.eina_stringshare_add((string)managedObj);
    }

    public void CleanUpNativeData(IntPtr pNativeData) {
        // No need to free as it's for own() parameters.
    }

    public void CleanUpManagedData(object managedObj) {
    }

    public int GetNativeDataSize() {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie) {
        if (marshaler == null) {
            marshaler = new StringsharePassOwnershipMarshaler();
        }
        return marshaler;
    }
    static private StringsharePassOwnershipMarshaler marshaler;
}

public class StringshareKeepOwnershipMarshaler : ICustomMarshaler {
    public object MarshalNativeToManaged(IntPtr pNativeData) {
        return Eina.StringConversion.NativeUtf8ToManagedString(pNativeData);
    }

    public IntPtr MarshalManagedToNative(object managedObj) {
        return Eina.Stringshare.eina_stringshare_add((string)managedObj);
    }

    public void CleanUpNativeData(IntPtr pNativeData) {
        // No need to free, as the native side will keep ownership.
    }

    public void CleanUpManagedData(object managedObj) {
    }

    public int GetNativeDataSize() {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie) {
        if (marshaler == null) {
            marshaler = new StringshareKeepOwnershipMarshaler();
        }
        return marshaler;
    }
    static private StringshareKeepOwnershipMarshaler marshaler;
}

public class StrbufPassOwnershipMarshaler : ICustomMarshaler {
    public object MarshalNativeToManaged(IntPtr pNativeData) {
        return new Eina.Strbuf(pNativeData, Eina.Ownership.Managed);
    }

    public IntPtr MarshalManagedToNative(object managedObj) {
        Eina.Strbuf buf = managedObj as Eina.Strbuf;
        buf.ReleaseOwnership();
        return buf.Handle;
    }

    public void CleanUpNativeData(IntPtr pNativeData) {
        // No need to cleanup. C will take care of it.
    }

    public void CleanUpManagedData(object managedObj) {
    }

    public int GetNativeDataSize() {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie) {
        if (marshaler == null) {
            marshaler = new StrbufPassOwnershipMarshaler();
        }
        return marshaler;
    }
    static private StrbufPassOwnershipMarshaler marshaler;
}

public class StrbufKeepOwnershipMarshaler: ICustomMarshaler {
    public object MarshalNativeToManaged(IntPtr pNativeData) {
        return new Eina.Strbuf(pNativeData, Eina.Ownership.Unmanaged);
    }

    public IntPtr MarshalManagedToNative(object managedObj) {
        Eina.Strbuf buf = managedObj as Eina.Strbuf;
        return buf.Handle;
    }

    public void CleanUpNativeData(IntPtr pNativeData) {
        // No need to free. The Native side will keep the ownership.
    }

    public void CleanUpManagedData(object managedObj) {
    }

    public int GetNativeDataSize() {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie) {
        if (marshaler == null) {
            marshaler = new StrbufKeepOwnershipMarshaler();
        }
        return marshaler;
    }
    static private StrbufKeepOwnershipMarshaler marshaler;
}



} // namespace eo

/// <summary>General exception for errors inside the binding.</summary>
public class EflException : Exception
{
    /// <summary>Create a new EflException with the given message.</summary>
    public EflException(string message) : base(message)
    {
    }
}

/// <summary>Exception to be raised when a Task fails due to a failed Eina.Future.</summary>
public class FutureException : EflException
{
    /// <summary>The error code returned by the failed Eina.Future.</summary>
    public Eina.Error Error { get; private set; }

    /// <summary>Construct a new exception from the Eina.Error stored in the given Eina.Value.</summary>
    public FutureException(Eina.Value value) : base("Future failed.")
    {
        if (value.GetValueType() != Eina.ValueType.Error)
            throw new ArgumentException("FutureException must receive an Eina.Value with Eina.Error.");
        Eina.Error err;
        value.Get(out err);
        Error = err;
    }
}

} // namespace efl
