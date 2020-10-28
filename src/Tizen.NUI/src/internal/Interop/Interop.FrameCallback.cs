using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FrameCallback
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_New")]
            public static extern global::System.IntPtr FrameUpdateCallback_New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_SWIGUpcast")]
            public static extern global::System.IntPtr FrameUpdateCallback_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_AddCallback")]
            public static extern global::System.IntPtr FrameUpdateCallback_AddCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_AddMainThreadCallback")]
            public static extern global::System.IntPtr FrameUpdateCallback_AddMainThreadCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_RemoveCallback")]
            public static extern global::System.IntPtr FrameUpdateCallback_RemoveCallback(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_GetPosition")]
            public static extern global::System.IntPtr FrameUpdateCallback_GetPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_SetPosition")]
            public static extern global::System.IntPtr FrameUpdateCallback_SetPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_BakePosition")]
            public static extern global::System.IntPtr FrameUpdateCallback_BakePosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_GetSize")]
            public static extern global::System.IntPtr FrameUpdateCallback_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_SetSize")]
            public static extern global::System.IntPtr FrameUpdateCallback_SetSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_BakeSize")]
            public static extern global::System.IntPtr FrameUpdateCallback_BakeSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_GetScale")]
            public static extern global::System.IntPtr FrameUpdateCallback_GetScale(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_SetScale")]
            public static extern global::System.IntPtr FrameUpdateCallback_SetScale(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_BakeScale")]
            public static extern global::System.IntPtr FrameUpdateCallback_BakeScale(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_GetColor")]
            public static extern global::System.IntPtr FrameUpdateCallback_GetColor(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_SetColor")]
            public static extern global::System.IntPtr FrameUpdateCallback_SetColor(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_BakeColor")]
            public static extern global::System.IntPtr FrameUpdateCallback_BakeColor(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_SetAlphaFunction")]
            public static extern void FrameUpdateCallback_SetAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_GetAlphaFunction")]
            public static extern global::System.IntPtr FrameUpdateCallback_GetAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_SetDuration")]
            public static extern void FrameUpdateCallback_SetDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameUpdateCallback_GetDuration")]
            public static extern float FrameUpdateCallback_GetDuration(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}