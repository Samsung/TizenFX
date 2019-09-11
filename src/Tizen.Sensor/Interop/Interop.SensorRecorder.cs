/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tizen.Sensor;

internal static partial class Interop
{
    internal static class SensorRecoder
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SensorRecorderDataCb(SensorType type, IntPtr dataHandle, int remains, int error, Int64 userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_create_option")]
        internal static extern int CreateOption(out IntPtr option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_create_query")]
        internal static extern int CreateQuery(out IntPtr query);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_data_get_double")]
        internal static extern int DataGetDouble(IntPtr dataHandle, RecorderData key, out double value);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_data_get_time")]
        internal static extern int DataGetTime(IntPtr data, out long start_time, out long end_time);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_destroy_option")]
        internal static extern int DestroyOption(IntPtr option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_destroy_query")]
        internal static extern int DestroyQuery(IntPtr query);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_is_supported")]
        internal static extern int IsSupported(int type, out bool isSupported);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_option_set_int")]
        internal static extern int OptionSetInt(IntPtr option, RecorderOption attribute, int value);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_query_set_int")]
        internal static extern int QuerySetInt(IntPtr query, RecorderQuery attribute, int value);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_query_set_time")]
        internal static extern int QuerySetTime(IntPtr query, RecorderQuery attribute, int time);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_read")]
        internal static extern int ReadAsync(int type, IntPtr query, SensorRecorderDataCb cb, IntPtr user_data);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_read_sync")]
        internal static extern int Read(int type, IntPtr query, SensorRecorderDataCb cb, IntPtr user_data);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_start")]
        internal static extern int Start(int type, IntPtr option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_stop")]
        internal static extern int Stop(int type);
    }
}
