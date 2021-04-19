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

namespace Tizen.NUI
{
    using global::System;
    using global::System.Runtime.InteropServices;

    internal static partial class Interop
    {
        internal static partial class TransitionItemBase
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TransitionBase")]
            public static extern IntPtr NewEmpty();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_New")]
            public static extern IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TransitionBase")]
            public static extern void Delete(HandleRef transition);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TransitionBase_Set")]
            public static extern IntPtr NewTransitionItemBase(HandleRef transition);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_Assign")]
            public static extern IntPtr Assign(HandleRef destination, HandleRef source);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_SetDuration")]
            public static extern void SetDuration(HandleRef transition, float seconds);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_GetDuration")]
            public static extern float GetDuration(HandleRef transition);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_SetDelay")]
            public static extern void SetDelay(HandleRef transition, float seconds);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_GetDelay")]
            public static extern float GetDelay(HandleRef transition);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_SetTimePeriod")]
            public static extern void SetTimePeriod(HandleRef transition, HandleRef seconds);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_SetAlphaFunction")]
            public static extern void SetAlphaFunction(HandleRef transition, HandleRef seconds);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_GetAlphaFunction")]
            public static extern IntPtr GetAlphaFunction(HandleRef transition);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionBase_TransitionWithChild")]
            public static extern void TransitionWithChild(HandleRef transition, bool transitionWithChild);
        }
    }
}
