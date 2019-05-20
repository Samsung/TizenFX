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
using System.Runtime.InteropServices;
using Tizen.Sensor;

internal static partial class Interop
{
    internal static class SensorRecoder
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SensorRecorderDataCb(int type, int data, int remains, int error, Int64 userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_create_option")]
        internal static extern int RecorderCreateOption(out IntPtr option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_create_query")]
        internal static extern int RecorderCreateQuery(out IntPtr query);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_data_get_double")]
        internal static extern int RecorderDataGetDouble(int data, int key, out double value);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_data_get_time")]
        internal static extern int RecorderDataGetTime(int data, out long start_time, out long end_time);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_destroy_option")]
        internal static extern int RecorderDestroyOption(IntPtr option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_destroy_query")]
        internal static extern int RecorderDestroyQuery(IntPtr query);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_is_supported")]
        internal static extern int RecorderIsSupported(int type, out bool isSupported);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_option_set_int")]
        internal static extern int RecorderOptionSetInt(IntPtr option, int attribute, int value);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_query_set_int")]
        internal static extern int RecorderQuerySetInt(IntPtr query, int attribute, int value);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_query_set_time")]
        internal static extern int RecorderQuerySetTime(IntPtr query, int attribute, int time);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_read")]
        internal static extern int RecorderReadAsync(int type, IntPtr query, SensorRecorderDataCb cb, IntPtr user_data);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_read_sync")]
        internal static extern int RecorderRead(int type, IntPtr query, SensorRecorderDataCb cb, IntPtr user_data);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_start")]
        internal static extern int RecorderStart(int type, IntPtr option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_stop")]
        internal static extern int RecorderStop(int type);

    }
}