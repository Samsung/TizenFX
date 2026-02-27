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
        internal static partial class TimePeriod
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TimePeriod__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTimePeriod(float jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TimePeriod__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTimePeriod(float jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TimePeriod", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTimePeriod(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_delaySeconds_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DelaySecondsSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_delaySeconds_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float DelaySecondsGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_durationSeconds_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DurationSecondsSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_durationSeconds_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float DurationSecondsGet(IntPtr jarg1);
        }
    }
}





