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
        internal static partial class TransitionSet
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TransitionSet")]
            public static extern IntPtr NewEmpty();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_New")]
            public static extern IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TransitionSet")]
            public static extern void Delete(HandleRef transitionSet);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TransitionSet_Set")]
            public static extern IntPtr NewTransitionSet(HandleRef transitionSet);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Assign")]
            public static extern IntPtr Assign(HandleRef destination, HandleRef source);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_AddTransition")]
            public static extern void AddTransition(HandleRef transitionSet, HandleRef transition);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_GetTransitionAt")]
            public static extern IntPtr GetTransitionAt(HandleRef transitionSet, uint index);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_GetTransitionCount")]
            public static extern uint GetTransitionCount(HandleRef transitionSet);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Play")]
            public static extern void Play(HandleRef transitionSet);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_FinishedSignal")]
            public static extern IntPtr FinishedSignal(HandleRef nuiTransitionSet);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Signal_Empty")]
            public static extern bool TransitionSetFinishedSignalEmpty(HandleRef transitionSet);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Signal_GetConnectionCount")]
            public static extern uint TransitionSetFinishedSignalGetConnectionCount(HandleRef transitionSet);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Signal_Connect")]
            public static extern void TransitionSetFinishedSignalConnect(HandleRef transitionSet, HandleRef func);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Signal_Disconnect")]
            public static extern void TransitionSetFinishedSignalDisconnect(HandleRef transitionSet, HandleRef func);
        }
    }
}
