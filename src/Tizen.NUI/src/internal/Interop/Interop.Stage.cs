using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Stage
        {
            static Stage()
            {
                ulong ret = Interop.Util.GetNanoSeconds();
                Tizen.Log.Error("NUI", "Stage : " + ret);
            }

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_DEFAULT_BACKGROUND_COLOR_get")]
            public static extern global::System.IntPtr Stage_DEFAULT_BACKGROUND_COLOR_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_DEBUG_BACKGROUND_COLOR_get")]
            public static extern global::System.IntPtr Stage_DEBUG_BACKGROUND_COLOR_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Stage__SWIG_0")]
            public static extern global::System.IntPtr new_Stage__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetCurrent")]
            public static extern global::System.IntPtr Stage_GetCurrent();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_IsInstalled")]
            public static extern bool Stage_IsInstalled();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Stage")]
            public static extern void delete_Stage(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Stage__SWIG_1")]
            public static extern global::System.IntPtr new_Stage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_Assign")]
            public static extern global::System.IntPtr Stage_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_Add")]
            public static extern void Stage_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_Remove")]
            public static extern void Stage_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetSize")]
            public static extern global::System.IntPtr Stage_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetRenderTaskList")]
            public static extern global::System.IntPtr Stage_GetRenderTaskList(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetLayerCount")]
            public static extern uint Stage_GetLayerCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetLayer")]
            public static extern global::System.IntPtr Stage_GetLayer(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetRootLayer")]
            public static extern global::System.IntPtr Stage_GetRootLayer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_SetBackgroundColor")]
            public static extern void Stage_SetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetBackgroundColor")]
            public static extern global::System.IntPtr Stage_GetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetDpi")]
            public static extern global::System.IntPtr Stage_GetDpi(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetObjectRegistry")]
            public static extern global::System.IntPtr Stage_GetObjectRegistry(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_KeepRendering")]
            public static extern void Stage_KeepRendering(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_SetRenderingBehavior")]
            public static extern void Stage_SetRenderingBehavior(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetRenderingBehavior")]
            public static extern int Stage_GetRenderingBehavior(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_SWIGUpcast")]
            public static extern global::System.IntPtr Stage_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}