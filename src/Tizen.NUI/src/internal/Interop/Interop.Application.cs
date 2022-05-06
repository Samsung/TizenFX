/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

 using System;
 using System.ComponentModel;
 using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Application
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MakeCallback")]
            public static extern global::System.IntPtr MakeCallback(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_PreInitialize")]
            public static extern void PreInitialize();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_0")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_1")]
            public static extern global::System.IntPtr New(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_2")]
            public static extern global::System.IntPtr New(int jarg1, string jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_3")]
            public static extern global::System.IntPtr New(int jarg1, string jarg3, int jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Application__SWIG_0")]
            public static extern global::System.IntPtr NewApplication();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Application__SWIG_1")]
            public static extern global::System.IntPtr NewApplication(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Application")]
            public static extern void DeleteApplication(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_MainLoop__SWIG_1")]
            public static extern void MainLoop(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_Lower")]
            public static extern void Lower(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_Quit")]
            public static extern void Quit(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_AddIdle")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool AddIdle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetWindow")]
            public static extern global::System.IntPtr GetWindow(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetWindowsListSize")]
            public static extern uint GetWindowsListSize();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetWindowsFromList")]
            public static extern global::System.IntPtr GetWindowsFromList(uint jarg1);

            //window handle test
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetWindowHandleFromNUI")]
            public static extern global::System.IntPtr GetWindowHandleFromNUI(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetResourcePath")]
            public static extern string GetResourcePath();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetLanguage")]
            public static extern string GetLanguage(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetRegion")]
            public static extern string GetRegion(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_4")]
            public static extern global::System.IntPtr New(int jarg1, string jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_5")]
            public static extern global::System.IntPtr New(int jarg1, string jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, int jarg6);

            // Keep this structure layout binary compatible with the respective C++ structure!
            [EditorBrowsable(EditorBrowsableState.Never)]
            [StructLayout(LayoutKind.Sequential)]
            public class AccessibilityDelegate
            {
                private AccessibilityDelegate()
                {
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public static AccessibilityDelegate Instance { get; } = new AccessibilityDelegate();

                // TODO (C# 9.0):
                // Replace the following syntax (3 lines of code per field):
                //
                //     [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                //     public delegate ReturnType AccessibilityMethodName(IntPtr self, ArgumentTypes...)
                //     public AccessibilityMethodName MethodName;
                //
                // with the function pointer syntax (1 line of code per field):
                //
                //     public delegate* unmanaged[Cdecl]<ReturnType, ArgumentTypes...> MethodName;
                //
                // This will make it easier to verify that the structures are compatible between C# and C++
                // when adding new fields (preferably at the end), because the C# syntax will look very similar
                // to the C++ syntax.

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetToolkitName(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetToolkitName GetToolkitName; // 1

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetVersion(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetVersion GetVersion; // 2
            }

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Application_DuplicateString")]
            public static extern IntPtr AccessibilityApplicationDuplicateString(string arg);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Application_SetAppAccessibilityDelegate")]
            public static extern IntPtr AccessibilityApplicationSetAppAccessibilityDelegate(HandleRef arg1_application, IntPtr arg2_accessibilityDelegate, int arg3_accessibilityDelegateSize);
        }
    }
}
