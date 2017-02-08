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
using Tizen.System;

internal static partial class Interop
{
    internal static partial class RuntimeInfo
    {
        public delegate void RuntimeInformationChangedCallback(RuntimeInformationKey key, IntPtr userData);

        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryInfo
        {
            public readonly int Total;
            public readonly int Used;
            public readonly int Free;
            public readonly int Cache;
            public readonly int Swap;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ProcessMemoryInfo
        {
            public readonly int Vsz;
            public readonly int Rss;
            public readonly int Pss;
            public readonly int SharedClean;
            public readonly int SharedDirty;
            public readonly int PrivateClean;
            public readonly int PrivateDirty;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CpuUsage
        {
            public readonly double User;
            public readonly double System;
            public readonly double Nice;
            public readonly double IoWait;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ProcessCpuUsage
        {
            public readonly uint UTime;
            public readonly uint STime;
        }

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_value_int")]
        public static extern int GetValue(RuntimeInformationKey key, out int status);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_value_bool")]
        public static extern int GetValue(RuntimeInformationKey key, out bool status);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_value_double")]
        public static extern int GetValue(RuntimeInformationKey key, out double status);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_value_string")]
        public static extern int GetValue(RuntimeInformationKey key, out string status);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_system_memory_info")]
        public static extern int GetSystemMemoryInfo(out MemoryInfo memoryInfo);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_process_memory_info")]
        public static extern int GetProcessMemoryInfo(int[] pid, int size, out ProcessMemoryInfo[] array);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_cpu_usage")]
        public static extern int GetCpuUsage(out CpuUsage cpuUsage);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_process_cpu_usage")]
        public static extern int GetProcessCpuUsage(int[] pid, int size, out ProcessCpuUsage[] array);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_processor_count")]
        public static extern int GetProcessorCount(out int processorCount);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_processor_current_frequency")]
        public static extern int GetProcessorCurrentFrequency(int coreId, out int cpuFreq);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_processor_max_frequency")]
        public static extern int GetProcessorMaxFrequency(int coreId, out int cpuFreq);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_set_changed_cb")]
        public static extern int SetRuntimeInfoChangedCallback(RuntimeInformationKey runtimeInfoKey, RuntimeInformationChangedCallback cb, IntPtr userData);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_unset_changed_cb")]
        public static extern int UnsetRuntimeInfoChangedCallback(RuntimeInformationKey runtimeInfoKey);
    }
}
