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
        internal static partial class ScaleTransitionItem
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScaleTransition_New_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New(IntPtr view, float scale, IntPtr timePeriod);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScaleTransition_New_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New(IntPtr view, IntPtr scale, IntPtr timePeriod);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScaleTransition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Delete(IntPtr scaleTransition);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScaleTransition_Set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr NewScaleTransitionItem(IntPtr scaleTransition);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScaleTransition_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr Assign(IntPtr destination, IntPtr source);
        }
    }
}



