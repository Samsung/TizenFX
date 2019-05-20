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
    internal static class SensorProvider
    {
        internal const int MAX_VALUE_SIZE = 16;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorProviderStartCb(IntPtr provider, Int64 userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorProviderStopCb(IntPtr provider, Int64 userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorProviderIntervalChangedCb(IntPtr provider, uint IntervalMs, Int64 userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_create_provider")]
        internal static extern int CreateProvider(String uri, out IntPtr provider);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_add_provider")]
        internal static extern int AddProvider(IntPtr provider);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_remove_provider")]
        internal static extern int RemoveProvider(IntPtr provider);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_destroy_provider")]
        internal static extern int DestroyProvider(IntPtr provider);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_set_name")]
        internal static extern int ProviderSetName(IntPtr provider, String name);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_set_vendor")]
        internal static extern int ProviderSetVendor(IntPtr provider, String vendor);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_set_range")]
        internal static extern int ProviderSetRange(IntPtr provider, float minRange, float maxRange);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_set_resolution")]
        internal static extern int ProviderSetResolution(IntPtr provider, float resolution);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_set_start_cb")]
        internal static extern int SetProviderStartCb(IntPtr provider, SensorProviderStartCb startCb, IntPtr userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_set_stop_cb")]
        internal static extern int SetProviderStopCb(IntPtr provider, SensorProviderStopCb stopCb, IntPtr userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_set_interval_changed_cb")]
        internal static extern int SetProviderIntervalChangedCb(IntPtr provider, SensorProviderIntervalChangedCb intervalCb, IntPtr userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_publish")]
        internal static extern int ProviderPublish(IntPtr provider, SensorEventStruct _event);
    }

}