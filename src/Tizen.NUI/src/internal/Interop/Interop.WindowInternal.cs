using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WindowInternal
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_ShowIndicator")]
            public static extern void Window_ShowIndicator(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetIndicatorBgOpacity")]
            public static extern void Window_SetIndicatorBgOpacity(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RotateIndicator")]
            public static extern void Window_RotateIndicator(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_AddAvailableOrientation")]
            public static extern void Window_AddAvailableOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RemoveAvailableOrientation")]
            public static extern void Window_RemoveAvailableOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetPreferredOrientation")]
            public static extern void Window_SetPreferredOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetPreferredOrientation")]
            public static extern int Window_GetPreferredOrientation(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetDragAndDropDetector")]
            public static extern global::System.IntPtr Window_GetDragAndDropDetector(global::System.Runtime.InteropServices.HandleRef jarg1);
            

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetNativeHandle")]
            public static extern global::System.IntPtr Window_GetNativeHandle(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
