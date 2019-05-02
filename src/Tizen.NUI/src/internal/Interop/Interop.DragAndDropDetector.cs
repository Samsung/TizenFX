using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class DragAndDropDetector
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_DragAndDropDetector")]
            public static extern global::System.IntPtr new_DragAndDropDetector();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_DragAndDropDetector")]
            public static extern void delete_DragAndDropDetector(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDropDetector_GetContent")]
            public static extern string DragAndDropDetector_GetContent(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDropDetector_GetCurrentScreenPosition")]
            public static extern global::System.IntPtr DragAndDropDetector_GetCurrentScreenPosition(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDropDetector_EnteredSignal")]
            public static extern global::System.IntPtr DragAndDropDetector_EnteredSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDropDetector_ExitedSignal")]
            public static extern global::System.IntPtr DragAndDropDetector_ExitedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDropDetector_MovedSignal")]
            public static extern global::System.IntPtr DragAndDropDetector_MovedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDropDetector_DroppedSignal")]
            public static extern global::System.IntPtr DragAndDropDetector_DroppedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDropDetector_SWIGUpcast")]
            public static extern global::System.IntPtr DragAndDropDetector_SWIGUpcast(global::System.IntPtr jarg1);

        }
    }
}
