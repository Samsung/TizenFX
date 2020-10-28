﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class EventThreadCallback
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_EventThreadCallback")]
            public static extern global::System.IntPtr new_EventThreadCallback(Tizen.NUI.EventThreadCallback.CallbackDelegate delegate1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_EventThreadCallback")]
            public static extern void delete_EventThreadCallback(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EventThreadCallback_Trigger")]
            public static extern void EventThreadCallback_Trigger(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}