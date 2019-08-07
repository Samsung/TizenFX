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
            public static extern global::System.IntPtr AutofillContainer_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_New")]
            public static extern global::System.IntPtr AutofillContainer_New(string jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AutofillContainer__SWIG_1")]
            public static extern global::System.IntPtr new_AutofillContainer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AutofillContainer__SWIG_0")]
            public static extern global::System.IntPtr new_AutofillContainer__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_Assign")]
            public static extern global::System.IntPtr AutofillContainer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AutofillContainer")]
            public static extern void delete_AutofillContainer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_DownCast")]
            public static extern global::System.IntPtr AutofillContainer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_AddAutofillItem")]
            public static extern void AutofillContainer_AddAutofillView(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, string jarg4, string jarg5, uint jarg6, bool jarg7);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_RemoveAutofillItem")]
            public static extern void AutofillContainer_RemoveAutofillItem(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_SaveAutofillData")]
            public static extern void AutofillContainer_SaveAutofillData(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_RequestFillData")]
            public static extern void AutofillContainer_RequestFillData(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillServiceName")]
            public static extern string AutofillContainer_GetAutofillServiceName(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillServiceMessage")]
            public static extern string AutofillContainer_GetAutofillServiceMessage(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillServiceImagePath")]
            public static extern string AutofillContainer_GetAutofillServiceImagePath(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetListCount")]
            public static extern uint AutofillContainer_GetListItemCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetListItem")]
            public static extern string AutofillContainer_GetListItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_SetSelectedItem")]
            public static extern void AutofillContainer_SetSelectedItem(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_AutofillServiceShownSignal")]
            public static extern global::System.IntPtr AutofillContainer_AutofillServiceEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_AutofillListShownSignal")]
            public static extern global::System.IntPtr AutofillContainer_AutofillListEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}