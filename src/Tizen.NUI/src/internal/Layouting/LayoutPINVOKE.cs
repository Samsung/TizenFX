/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    class LayoutPINVOKE
    {
        // LayoutController

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_LayoutController")]
        public static extern global::System.IntPtr LayoutController_New();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_LayoutController")]
        public static extern global::System.IntPtr delete_LayoutController(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LayoutController_SetCallback")]
        public static extern void LayoutController_SetCallback(global::System.Runtime.InteropServices.HandleRef jarg1, LayoutController.Callback jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LayoutController_GetId")]
        public static extern int LayoutController_GetId(global::System.Runtime.InteropServices.HandleRef jarg1);
	  }
}
