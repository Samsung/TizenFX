/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal static class Sensor
    {
        //Sensor Hardware CAPI
        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_name")]
        internal static extern int GetName(IntPtr sensorhandle, out String name);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_vendor")]
        internal static extern int GetVendor(IntPtr sensorHandle, out String vendor);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_type")]
        internal static extern int GetType(IntPtr sensorHandle, out SensorType type);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_min_range")]
        internal static extern int GetMinRange(IntPtr sensorHandle, out float minRange);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_max_range")]
        internal static extern int GetMaxRange(IntPtr sensorHandle, out float maxRange);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_resolution")]
        internal static extern int GetResolution(IntPtr sensorHandle, out float resolution);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_min_interval")]
        internal static extern int GetMinInterval(IntPtr sensorHandle, out int minInterval);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_fifo_count")]
        internal static extern int GetFifoCount(IntPtr sensorHandle, out int fifoCount);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_max_batch_count")]
        internal static extern int GetMaxBatchCount(IntPtr sensorHandle, out int maxBatchCount);
    }
    internal static class SensorListener
    {
        //Sensor Listener CAPI
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorEventCallback(IntPtr sensorHandle, IntPtr eventData, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorAccuracyCallback(IntPtr sensorHandle, ulong timestamp, SensorDataAccuracy accuracy, IntPtr data);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_create_listener")]
        internal static extern int CreateListener(IntPtr sensorHandle, out IntPtr listenerHandle);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_destroy_listener")]
        internal static extern int DestroyListener(IntPtr listenerHandle);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_start")]
        internal static extern int StartListener(IntPtr listenerHandle);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_stop")]
        internal static extern int StopListener(IntPtr listenerHandle);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_set_event_cb")]
        internal static extern int SetEventCallback(IntPtr listenerHandle, uint intervalMs, SensorEventCallback callback, IntPtr data);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_unset_event_cb")]
        internal static extern int UnsetEventCallback(IntPtr listernerHandle);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_set_accuracy_cb")]
        internal static extern int SetAccuracyCallback(IntPtr listenerHandle, SensorAccuracyCallback callback, IntPtr data);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_unset_accuracy_cb")]
        internal static extern int UnsetAccuracyCallback(IntPtr listernerHandle);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_set_interval")]
        internal static extern int SetInterval(IntPtr listenerHandle, uint intervalMs);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_set_max_batch_latency")]
        internal static extern int SetMaxBatchLatency(IntPtr listenerHandle, uint maxBatchLatency);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_set_attribute_int")]
        internal static extern int SetAttribute(IntPtr listenerHandle, SensorAttribute sensorAttribute, int option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_listener_read_data")]
        internal static extern int ReadData(IntPtr listenerHandle, out SensorEventStruct data);
    }

    internal static class SensorManager
    {
        //Sensor Manager CAPI
        [DllImport(Libraries.Sensor, EntryPoint = "sensor_is_supported")]
        internal static extern int SensorIsSupported(SensorType type, out bool supported);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_default_sensor")]
        internal static extern int GetDefaultSensor(SensorType type, out IntPtr sensor);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_sensor_list")]
        internal static extern int GetSensorList(SensorType type, out IntPtr list, out int sensor_count);
    }

    internal static partial class Libc
    {
        [DllImport(Libraries.Libc, EntryPoint = "free", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Free(IntPtr ptr);
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct SensorEventStruct
    {
        internal SensorDataAccuracy accuracy;
        internal UInt64 timestamp;
        internal int value_count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        internal float[] values;
    }

    internal static IntPtr[] IntPtrToIntPtrArray(IntPtr unmanagedArray, int size)
    {
        IntPtr[] managedArray = new IntPtr[size];
        Marshal.Copy(unmanagedArray, managedArray, 0, size);
        return managedArray;
    }

    internal static SensorEventStruct IntPtrToEventStruct(IntPtr unmanagedVariable)
    {
        SensorEventStruct outStruct = (SensorEventStruct)Marshal.PtrToStructure<SensorEventStruct>(unmanagedVariable);
        return outStruct;
    }
}
