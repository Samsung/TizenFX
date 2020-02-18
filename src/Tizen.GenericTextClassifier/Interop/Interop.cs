using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Tizen.GenericTextClassifier;

namespace Tizen.GenericTextClassifier
{
    [StructLayout(LayoutKind.Sequential)]

    static partial class Interop
    {
        public static class GTCAPI
        {
            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_initialize")]
            public static extern int TextClassifierInitialize();

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_deinitialize")]
            public static extern int TextClassifierDeinitialize();
            
            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_create")]
            public static extern int TextClassifierCreate(IntPtr classifierHandle,  string appId, string userId);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_destroy")]
            public static extern int TextClassifierDestroy(IntPtr classifierHandle);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_get_category")]
            public static extern int TextClassifierGetCategory(IntPtr classifierHandle, string textData, int textDataLen, out CategoryListStruct categoryList);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_add_category")]
            public static extern int TextClassifierAddCategory(IntPtr classifierHandle, string categoryName);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_delete_category")]
            public static extern int TextClassifierDeleteCategory(IntPtr classifierHandle, string categoryName);

            [DllImport(Libraries.GTC_LIB, EntryPoint = "text_classifier_update_category")]
            public static extern int TextClassifierUpdateCategory(IntPtr classifierHandle, string categoryName, string textData, int textDataLen);
            
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
                SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}
