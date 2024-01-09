﻿/*
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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ProcessorController
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ProcessorController_Without_Initialize")]
            public static extern global::System.IntPtr NewWithoutInitialize();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ProcessorController_Initialize")]
            public static extern void Initialize(global::System.Runtime.InteropServices.HandleRef processorController);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ProcessorController_SetCallback")]
            public static extern void SetCallback(global::System.Runtime.InteropServices.HandleRef processorController, Tizen.NUI.ProcessorController.ProcessorEventHandler processorCallback);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ProcessorController_RemoveCallback")]
            public static extern void RemoveCallback(global::System.Runtime.InteropServices.HandleRef processorController, Tizen.NUI.ProcessorController.ProcessorEventHandler processorCallback);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ProcessorController_Awake")]
            public static extern void Awake(global::System.Runtime.InteropServices.HandleRef processorController);
        }
    }
}
