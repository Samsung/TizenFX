using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FrameCallbackInterface
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FrameCallbackInterface")]
            public static extern global::System.IntPtr new_FrameCallbackInterface();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_director_connect")]
            public static extern void FrameCallbackInterface_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, Tizen.NUI.FrameCallbackInterface.SwigDelegateFrameCallbackInterface delegate0);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPosition")]
            public static extern bool FraemCallbackInterface_GetPosition(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetPosition")]
            public static extern bool FraemCallbackInterface_SetPosition(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakePosition")]
            public static extern bool FraemCallbackInterface_BakePosition(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPositionAndSize")]
            public static extern bool FraemCallbackInterface_GetPositionAndSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector, global::System.Runtime.InteropServices.HandleRef vector2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetSize")]
            public static extern bool FraemCallbackInterface_GetSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetSize")]
            public static extern bool FraemCallbackInterface_SetSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeSize")]
            public static extern bool FraemCallbackInterface_BakeSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetScale")]
            public static extern bool FraemCallbackInterface_GetScale(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetScale")]
            public static extern bool FraemCallbackInterface_SetScale(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeScale")]
            public static extern bool FraemCallbackInterface_BakeScale(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetColor")]
            public static extern bool FraemCallbackInterface_GetColor(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetColor")]
            public static extern bool FraemCallbackInterface_SetColor(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeColor")]
            public static extern bool FraemCallbackInterface_BakeColor(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_AddFrameCallback")]
            public static extern void FraemCallbackInterface_AddFrameCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_RemoveFrameCallback")]
            public static extern void FraemCallbackInterface_RemoveFrameCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);
        }
    }
}
