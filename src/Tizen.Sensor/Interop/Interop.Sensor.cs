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

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_uri")]
        internal static extern int GetUri(IntPtr sensorhandle, out String uri);

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
    }

    internal static class SensorManager
    {
        //Sensor Manager CAPI
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorAddedCb(String uri, Int64 userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorRemovedCb(String uri, Int64 userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_is_supported")]
        internal static extern int SensorIsSupported(SensorType type, out bool supported);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_default_sensor")]
        internal static extern int GetDefaultSensor(SensorType type, out IntPtr sensor);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_sensor_list")]
        internal static extern int GetSensorList(SensorType type, out IntPtr list, out int sensor_count);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_default_sensor_by_uri")]
        internal static extern int GetDefaultSensorByUri(String uri , out IntPtr sensor);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_get_sensor_list_by_uri")]
        internal static extern int GetSensorListByUri(String uri, out IntPtr list, out int sensor_count);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_add_sensor_added_cb")]
        internal static extern int AddSensorAddedCB(SensorAddedCb callback, IntPtr userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_add_sensor_removed_cb")]
        internal static extern int AddSensorRemovedCB(SensorRemovedCb callback, IntPtr userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_remove_sensor_added_cb")]
        internal static extern int RemoveSensorAddedCB(SensorAddedCb callback);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_remove_sensor_removed_cb")]
        internal static extern int RemoveSensorRemovedCB(SensorRemovedCb callback);
    }

    internal static class SensorRecoder {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SensorRecorderDataCb(Enum type, Int64 data, int remains, Enum error, Int64 userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_create_option")]
        internal static extern int RecorderCreateOption( out IntPtr option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_create_query")]
        internal static extern int RecorderCreateQuery( out IntPtr query);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_data_get_double")]
        internal static extern int RecorderDataGetDouble(IntPtr data, int key, out IntPtr value);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_data_get_time")]
        internal static extern int RecorderDataGetTime(IntPtr data, out IntPtr start_time, out IntPtr end_time);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_destroy_option")]
        internal static extern int RecorderDestroyOption(IntPtr option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_destroy_query")]
        internal static extern int RecorderDestroyQuery( IntPtr query);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_is_supported")]
        internal static extern int RecorderIsSupported(Enum type, out IntPtr isSupported);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_option_set_int")]
        internal static extern int RecorderOptionSetInt(IntPtr option, Enum attribute , int value);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_query_set_int")]
        internal static extern int RecorderQuerySetInt(IntPtr query, Enum attribute, int value);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_query_set_time")]
        internal static extern int RecorderQuerySetTime(IntPtr query, Enum attribute, int time);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_read")]
        internal static extern int RecorderRead(Enum type, IntPtr query, SensorRecorderDataCb cb , IntPtr user_data );

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_start")]
        internal static extern int RecorderStart(Enum type, IntPtr option);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_recorder_stop")]
        internal static extern int RecorderStop(Enum type);

    }

    internal static class SensorProvider{
        internal const int MAX_VALUE_SIZE = 16;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorProviderStartCb(IntPtr provider, Int64 userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorProviderStopCb(IntPtr provider, Int64 userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SensorProviderIntervalChangedCb(IntPtr provider, uint IntervalMs, Int64 userData);

       
        [StructLayout(LayoutKind.Sequential)]
        internal struct SensorEventS
        {
            internal int accuracy;
            internal UInt64 timeStamp;
            internal int valueCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_VALUE_SIZE)]
            internal float[] values;
        }

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_create_provider")]
        internal static extern int CreateProvider(String uri, out  IntPtr provider);

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
        internal static extern int ProviderSetStartCb(IntPtr provider, SensorProviderStartCb startCb, IntPtr userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_set_stop_cb")]
        internal static extern int ProviderSetStopCb(IntPtr provider, SensorProviderStopCb stopCb, IntPtr userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_set_interval_changed_cb")]
        internal static extern int ProviderSetIntervalChangedCb(IntPtr provider, SensorProviderIntervalChangedCb intervalCb, IntPtr userData);

        [DllImport(Libraries.Sensor, EntryPoint = "sensor_provider_publish")]
        internal static extern int ProviderPublish(IntPtr provider,  SensorEventS _event);

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
    internal static SensorStressMonitorData IntPtrToStressMonitorData(IntPtr unmanagedVariable)
    {
        SensorStressMonitorData outStruct = (SensorStressMonitorData)Marshal.PtrToStructure<SensorStressMonitorData>(unmanagedVariable);
        return outStruct;
    }

}
