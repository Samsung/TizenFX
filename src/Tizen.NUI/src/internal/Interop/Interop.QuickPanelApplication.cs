/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class QuickPanelApplication
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_QuickPanelApplication_1")]
            public static extern global::System.IntPtr QuickPanelApplication_New_1(int argc, string argv, string styleSheet, int windowMode, int serviceType, bool scrolling);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_QuickPanelApplication_2")]
            public static extern global::System.IntPtr QuickPanelApplication_New_2(int argc, string argv, string styleSheet, int windowMode, int serviceType, bool scrolling, global::System.Runtime.InteropServices.HandleRef jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_QuickPanelApplication_SWIG1")]
            public static extern global::System.IntPtr new_QuickPanelApplication__SWIG_1(global::System.Runtime.InteropServices.HandleRef swigCPtr);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_assign_QuickPanelApplication")]
            public static extern global::System.IntPtr QuickPanelApplication_Assign(global::System.Runtime.InteropServices.HandleRef swigCPtr, global::System.Runtime.InteropServices.HandleRef swigCPtr2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_QuickPanelApplication")]
            public static extern global::System.IntPtr delete_QuickPanelApplication(global::System.Runtime.InteropServices.HandleRef swigCPtr);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_QuickPanelApplication_SetScrollable")]
            public static extern void CSharp_Dali_QuickPanelApplication_SetScrollable(global::System.Runtime.InteropServices.HandleRef swigCPtr, bool set);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_QuickPanelApplication_GetServiceType")]
            public static extern int CSharp_Dali_QuickPanelApplication_GetServiceType(global::System.Runtime.InteropServices.HandleRef swigCPtr);

        }
    }
}
