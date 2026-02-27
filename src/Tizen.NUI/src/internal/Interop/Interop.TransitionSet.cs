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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TransitionSet
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TransitionSet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Delete(IntPtr transitionSet);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TransitionSet_Set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr NewTransitionSet(IntPtr transitionSet);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr Assign(IntPtr destination, IntPtr source);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_AddTransition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddTransition(IntPtr transitionSet, IntPtr transition);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_GetTransitionAt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetTransitionAt(IntPtr transitionSet, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_GetTransitionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetTransitionCount(IntPtr transitionSet);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Play", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Play(IntPtr transitionSet);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_FinishedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr FinishedSignal(IntPtr nuiTransitionSet);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Signal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool TransitionSetFinishedSignalEmpty(IntPtr transitionSet);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Signal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint TransitionSetFinishedSignalGetConnectionCount(IntPtr transitionSet);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Signal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TransitionSetFinishedSignalConnect(IntPtr transitionSet, IntPtr func);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TransitionSet_Signal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TransitionSetFinishedSignalDisconnect(IntPtr transitionSet, IntPtr func);
        }
    }
}



