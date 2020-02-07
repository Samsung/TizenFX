using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Tizen.GenericTextClassifier;

namespace Tizen.GenericTextClassifier
{
    [StructLayout(LayoutKind.Sequential)]

    /*public struct CategoryListStruct
    {
        internal char[] first_category;
        internal char[] second_category;
        internal char[] third_category;
        internal float first_category_score;
        internal float second_category_score;
        internal float third_category_score;
    }*/

    static partial class Interop
    {
        public static class VconfAPI
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void DeviceCallback(IntPtr result, IntPtr data);

            [DllImport(Libraries.VCONF_LIB, EntryPoint = "vconf_notify_key_changed")]
            internal static extern int GetDeviceCallback(string handle, DeviceCallback cb, IntPtr data);

            [DllImport("/usr/lib/libvconf.so.0", EntryPoint = "vconf_get_str")]
            public static extern string GetString(string input);

            [DllImport("/usr/lib/libvconf.so.0", EntryPoint = "vconf_get_int")]
            public static extern bool GetInt(string input, ref int data);
        }

        public static class GTCAPI
        {
            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_initialize")]
            public static extern int TextClassifierInitialize();

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_deinitialize")]
            public static extern int TextClassifierDeinitialize();
            
            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_create")]
            public static extern int TextClassifierCreate(IntPtr classifier_handle,  String app_id, String user_id);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_destroy")]
            public static extern int TextClassifierDestroy(IntPtr classifier_handle);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_get_category")]
            public static extern int TextClassifierGetCategory(IntPtr classifier_handle, String text_data, int text_data_len, ref CategoryListStruct category_list);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_add_category")]
            public static extern int TextClassifierAddCategory(IntPtr classifier_handle, String category_name);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_delete_category")]
            public static extern int TextClassifierDeleteCategory(IntPtr classifier_handle, String category_name);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_update_category")]
            public static extern int TextClassifierUpdateCategory(IntPtr classifier_handle, String category_name, String text_data, int text_data_len);
            
        }

        internal sealed class SafeClassifierHandle : SafeHandle
        {
            public SafeClassifierHandle() : base(IntPtr.Zero, true)
            {
            }

            public SafeClassifierHandle(IntPtr handle) : base(handle, true)
            {
            }

            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }

            protected override bool ReleaseHandle()
            {
                throw new NotImplementedException();
            }
        }
    }
}
