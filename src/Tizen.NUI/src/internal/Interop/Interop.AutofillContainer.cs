using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class AutofillContainer
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_SWIGUpcast")]
            public static extern global::System.IntPtr AutofillContainerUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_New")]
            public static extern global::System.IntPtr AutofillContainerNew(string jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AutofillContainer__SWIG_1")]
            public static extern global::System.IntPtr NewAutofillContainer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AutofillContainer__SWIG_0")]
            public static extern global::System.IntPtr NewAutofillContainer();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_Assign")]
            public static extern global::System.IntPtr AutofillContainerAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AutofillContainer")]
            public static extern void DeleteAutofillContainer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_DownCast")]
            public static extern global::System.IntPtr AutofillContainerDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_AddAutofillItem")]
            public static extern void AutofillContainerAddAutofillView(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, string jarg4, string jarg5, uint jarg6, bool jarg7);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_RemoveAutofillItem")]
            public static extern void AutofillContainerRemoveAutofillItem(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_SaveAutofillData")]
            public static extern void AutofillContainerSaveAutofillData(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_RequestFillData")]
            public static extern void AutofillContainerRequestFillData(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillServiceName")]
            public static extern string AutofillContainerGetAutofillServiceName(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillServiceMessage")]
            public static extern string AutofillContainerGetAutofillServiceMessage(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillServiceImagePath")]
            public static extern string AutofillContainerGetAutofillServiceImagePath(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetListCount")]
            public static extern uint AutofillContainerGetListItemCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetListItem")]
            public static extern string AutofillContainerGetListItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_SetSelectedItem")]
            public static extern void AutofillContainerSetSelectedItem(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_AutofillServiceShownSignal")]
            public static extern global::System.IntPtr AutofillContainerAutofillServiceEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_AutofillListShownSignal")]
            public static extern global::System.IntPtr AutofillContainerAutofillListEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}