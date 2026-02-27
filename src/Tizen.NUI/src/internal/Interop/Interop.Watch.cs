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
        internal static partial class Watch
        {
            //for watch
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WatchTime", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewWatchTime();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WatchTime", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWatchTime(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetHour", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WatchTimeGetHour(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetHour24", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WatchTimeGetHour24(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetMinute", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WatchTimeGetMinute(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetSecond", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WatchTimeGetSecond(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetMillisecond", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WatchTimeGetMillisecond(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetYear", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WatchTimeGetYear(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetMonth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WatchTimeGetMonth(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetDay", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WatchTimeGetDay(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetDayOfWeek", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WatchTimeGetDayOfWeek(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetTimeZone", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string WatchTimeGetTimeZone(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTime_GetDaylightSavingTimeStatus", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WatchTimeGetDaylightSavingTimeStatus(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WatchApplicationNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WatchApplicationNew(int jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WatchApplicationNew(int jarg1, string jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WatchApplication__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewWatchApplication(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WatchApplication", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWatchApplication(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchApplication_TimeTickSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WatchApplicationTimeTickSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchApplication_AmbientTickSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WatchApplicationAmbientTickSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchApplication_AmbientChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WatchApplicationAmbientChangedSignal(IntPtr jarg1);

            //for watch signal
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTimeSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WatchTimeSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTimeSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint WatchTimeSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTimeSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WatchTimeSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTimeSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WatchTimeSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchTimeSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WatchTimeSignalEmit(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WatchTimeSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewWatchTimeSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WatchTimeSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWatchTimeSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchBoolSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WatchBoolSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchBoolSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint WatchBoolSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchBoolSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WatchBoolSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchBoolSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WatchBoolSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchBoolSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WatchBoolSignalEmit(IntPtr jarg1, IntPtr jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WatchBoolSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewWatchBoolSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WatchBoolSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWatchBoolSignal(IntPtr jarg1);
        }
    }
}





