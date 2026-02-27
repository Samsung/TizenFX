/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Application
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MakeCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MakeCallback(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_PreInitialize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PreInitialize();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_IsSupportPreInitializedCreation", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsSupportPreInitializedCreation();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetPreInitializeWindow", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetPreInitializeWindow();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int jarg1, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int jarg1, string jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Application__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewApplication();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Application__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewApplication(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(global::System.IntPtr jarg1, global::System.IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Application", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteApplication(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_Lower", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Lower(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_Quit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Quit(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_AddIdle", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddIdle(global::System.IntPtr jarg1, global::System.IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetWindow", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetWindow(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetWindowsListSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetWindowsListSize();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetWindowsFromList", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetWindowsFromList(uint jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetResourcePath", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetResourcePath();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetLanguage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetLanguage(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_GetRegion", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetRegion(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int jarg1, string jarg3, int jarg4, global::System.IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_5", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int argc, string argv, string styleSheet, int windowMode, global::System.IntPtr initRectangle, int windowType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__SWIG_6", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int argc, string argv, string jarg3, int jarg4, global::System.IntPtr jarg5, [MarshalAs(UnmanagedType.U1)] bool jarg7);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New_WithWindowData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int argc, string argv, string styleSheet, [MarshalAs(UnmanagedType.U1)] bool uiThread, global::System.IntPtr windowData);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_FlushUpdateMessages", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FlushUpdateMessages(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetScreenSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetScreenSize();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetGeometryHittestEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetGeometryHittestEnabled([MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsGeometryHittestEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsGeometryHittestEnabled();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetAvailableScreens", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetAvailableScreens();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_SetApplicationLocale", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetApplicationLocale(global::System.IntPtr application, string locale);
        }
    }
}
