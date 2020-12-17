using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ViewProperty
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_STYLE_NAME_get")]
            public static extern int StyleNameGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_KEY_INPUT_FOCUS_get")]
            public static extern int KeyInputFocusGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BACKGROUND_get")]
            public static extern int BackgroundGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_MARGIN_get")]
            public static extern int MarginGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_PADDING_get")]
            public static extern int PaddingGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_View_Property")]
            public static extern global::System.IntPtr NewViewProperty();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_View_Property")]
            public static extern void DeleteViewProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_TOOLTIP_get")]
            public static extern int TooltipGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_STATE_get")]
            public static extern int StateGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_SUB_STATE_get")]
            public static extern int SubStateGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_LEFT_FOCUSABLE_ACTOR_ID_get")]
            public static extern int LeftFocusableActorIdGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get")]
            public static extern int RightFocusableActorIdGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_UP_FOCUSABLE_ACTOR_ID_get")]
            public static extern int UpFocusableActorIdGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_DOWN_FOCUSABLE_ACTOR_ID_get")]
            public static extern int DownFocusableActorIdGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_UPDATE_SIZE_HINT_get")]
            public static extern int UpdateSizeHintGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_SHADOW_get")]
            public static extern int ShadowGet();
        }
    }
}
