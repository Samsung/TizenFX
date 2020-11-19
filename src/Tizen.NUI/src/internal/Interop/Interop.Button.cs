using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Button
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_Property_DISABLED_get")]
            public static extern int ButtonPropertyDisabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_Property_AUTO_REPEATING_get")]
            public static extern int ButtonPropertyAutoRepeatingGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_Property_INITIAL_AUTO_REPEATING_DELAY_get")]
            public static extern int ButtonPropertyInitialAutoRepeatingDelayGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_Property_NEXT_AUTO_REPEATING_DELAY_get")]
            public static extern int ButtonPropertyNextAutoRepeatingDelayGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_Property_TOGGLABLE_get")]
            public static extern int ButtonPropertyTogglableGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_Property_SELECTED_get")]
            public static extern int ButtonPropertySelectedGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_Property_LABEL_get")]
            public static extern int ButtonPropertyLabelGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Button_Property")]
            public static extern global::System.IntPtr NewButtonProperty();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Button_Property")]
            public static extern void DeleteButtonProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Button__SWIG_0")]
            public static extern global::System.IntPtr NewButton();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Button__SWIG_1")]
            public static extern global::System.IntPtr NewButton(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_Assign")]
            public static extern global::System.IntPtr ButtonAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_DownCast")]
            public static extern global::System.IntPtr ButtonDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Button")]
            public static extern void DeleteButton(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_IsDisabled")]
            public static extern bool ButtonIsDisabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_IsAutoRepeating")]
            public static extern bool ButtonIsAutoRepeating(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_GetInitialAutoRepeatingDelay")]
            public static extern float ButtonGetInitialAutoRepeatingDelay(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_GetNextAutoRepeatingDelay")]
            public static extern float ButtonGetNextAutoRepeatingDelay(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_IsTogglableButton")]
            public static extern bool ButtonIsTogglableButton(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_IsSelected")]
            public static extern bool ButtonIsSelected(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_PressedSignal")]
            public static extern global::System.IntPtr ButtonPressedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_ReleasedSignal")]
            public static extern global::System.IntPtr ButtonReleasedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_ClickedSignal")]
            public static extern global::System.IntPtr ButtonClickedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_StateChangedSignal")]
            public static extern global::System.IntPtr ButtonStateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_UNSELECTED_VISUAL_get")]
            public static extern int ButtonPropertyUnselectedVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_SELECTED_VISUAL_get")]
            public static extern int ButtonPropertySelectedVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_DISABLED_SELECTED_VISUAL_get")]
            public static extern int ButtonPropertyDisabledSelectedVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_DISABLED_UNSELECTED_VISUAL_get")]
            public static extern int ButtonPropertyDisabledUnselectedVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_UNSELECTED_BACKGROUND_VISUAL_get")]
            public static extern int ButtonPropertyUnselectedBackgroundVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_SELECTED_BACKGROUND_VISUAL_get")]
            public static extern int ButtonPropertySelectedBackgroundVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get")]
            public static extern int ButtonPropertyDisabledUnselectedBackgroundVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get")]
            public static extern int ButtonPropertyDisabledSelectedBackgroundVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_LABEL_RELATIVE_ALIGNMENT_get")]
            public static extern int ButtonPropertyLabelRelativeAlignmentGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_LABEL_PADDING_get")]
            public static extern int ButtonPropertyLabelPaddingGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Button_Property_VISUAL_PADDING_get")]
            public static extern int ButtonPropertyVisualPaddingGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Button_SWIGUpcast")]
            public static extern global::System.IntPtr ButtonUpcast(global::System.IntPtr jarg1);
        }
    }
}