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
            public static extern int View_Property_STYLE_NAME_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BACKGROUND_COLOR_get")]
            public static extern int View_Property_BACKGROUND_COLOR_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BACKGROUND_IMAGE_get")]
            public static extern int View_Property_BACKGROUND_IMAGE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_KEY_INPUT_FOCUS_get")]
            public static extern int View_Property_KEY_INPUT_FOCUS_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BACKGROUND_get")]
            public static extern int View_Property_BACKGROUND_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_MARGIN_get")]
            public static extern int View_Property_MARGIN_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_PADDING_get")]
            public static extern int View_Property_PADDING_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_View_Property")]
            public static extern global::System.IntPtr new_View_Property();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_View_Property")]
            public static extern void delete_View_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_TOOLTIP_get")]
            public static extern int View_Property_TOOLTIP_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_STATE_get")]
            public static extern int View_Property_STATE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_SUB_STATE_get")]
            public static extern int View_Property_SUB_STATE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_LEFT_FOCUSABLE_ACTOR_ID_get")]
            public static extern int View_Property_LEFT_FOCUSABLE_ACTOR_ID_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get")]
            public static extern int View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_UP_FOCUSABLE_ACTOR_ID_get")]
            public static extern int View_Property_UP_FOCUSABLE_ACTOR_ID_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_DOWN_FOCUSABLE_ACTOR_ID_get")]
            public static extern int View_Property_DOWN_FOCUSABLE_ACTOR_ID_get();
        }
    }
}