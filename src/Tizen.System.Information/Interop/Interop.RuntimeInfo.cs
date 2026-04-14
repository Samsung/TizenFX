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
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.Internals;
using Tizen.System;

internal static partial class Interop
{
    internal static partial class RuntimeInfo
    {
        public delegate void RuntimeInformationChangedCallback(RuntimeInfoKey key, IntPtr userData);

        [NativeStruct("runtime_memory_info_s", Include="runtime_info.h", PkgConfig="capi-system-runtime-info")]
        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryInfo
        {
            public readonly int Total;
            public readonly int Used;
            public readonly int Free;
            public readonly int Cache;
            public readonly int Swap;
        }

        [NativeStruct("process_memory_info_s", Include="runtime_info.h", PkgConfig="capi-system-runtime-info")]
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

        [NativeStruct("runtime_cpu_usage_s", Include="runtime_info.h", PkgConfig="capi-system-runtime-info")]
        [StructLayout(LayoutKind.Sequential)]
        public struct CpuUsage
        {
            public readonly double User;
            public readonly double System;
            public readonly double Nice;
            public readonly double IoWait;
        }

        [NativeStruct("process_cpu_usage_s", Include="runtime_info.h", PkgConfig="capi-system-runtime-info")]
        [StructLayout(LayoutKind.Sequential)]
        public struct ProcessCpuUsage
        {
            public readonly uint UTime;
            public readonly uint STime;
        }

        /// <summary>
        /// Enumeration for the process memory information key.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ProcessMemoryInfoKey
        {
            /// <summary>
            /// Virtual memory size (KiB)
            /// </summary>
            Vsz = 100,
            /// <summary>
            /// Resident set size (KiB)
            /// </summary>
            Rss = 200,
            /// <summary>
            /// Proportional set size (KiB)
            /// </summary>
            Pss = 300,
            /// <summary>
            /// Not modified and mapped by other processes (KiB)
            /// </summary>
            SharedClean = 400,
            /// <summary>
            /// Modified and mapped by other processes (KiB)
            /// </summary>
            SharedDirty = 500,
            /// <summary>
            /// Not modified and available only to that process (KiB)
            /// </summary>
            PrivateClean = 600,
            /// <summary>
            /// Modified and available only to that process (KiB)
            /// </summary>
            PrivateDirty = 700,
            /// <summary>
            /// SWAP memory size (KiB)
            /// </summary>
            Swap = 800,
            /// <summary>
            /// GPU memory size (KiB)
            /// </summary>
            Gpu = 900,
            /// <summary>
            /// Resident set size in graphic execution manager (KiB)
            /// </summary>
            GemRss = 1000
        }

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_value_int")]
        public static extern InformationError GetValue(RuntimeInfoKey key, out int status);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_value_bool")]
        public static extern InformationError GetValue(RuntimeInfoKey key, out bool status);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_value_double")]
        public static extern InformationError GetValue(RuntimeInfoKey key, out double status);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_value_string")]
        public static extern InformationError GetValue(RuntimeInfoKey key, out string status);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_system_memory_info")]
        public static extern InformationError GetSystemMemoryInfo(out MemoryInfo memoryInfo);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_process_memory_info")]
        public static extern InformationError GetProcessMemoryInfo(int[] pid, int size, ref IntPtr array);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_cpu_usage")]
        public static extern InformationError GetCpuUsage(out CpuUsage cpuUsage);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_process_cpu_usage")]
        public static extern InformationError GetProcessCpuUsage(int[] pid, int size, ref IntPtr array);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_processor_count")]
        public static extern InformationError GetProcessorCount(out int processorCount);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_processor_current_frequency")]
        public static extern InformationError GetProcessorCurrentFrequency(int coreId, out int cpuFreq);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_processor_max_frequency")]
        public static extern InformationError GetProcessorMaxFrequency(int coreId, out int cpuFreq);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_set_changed_cb")]
        public static extern InformationError SetRuntimeInfoChangedCallback(RuntimeInfoKey runtimeInfoKey, RuntimeInformationChangedCallback cb, IntPtr userData);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_unset_changed_cb")]
        public static extern InformationError UnsetRuntimeInfoChangedCallback(RuntimeInfoKey runtimeInfoKey);

        [DllImport(Libraries.RuntimeInfo, EntryPoint = "runtime_info_get_process_memory_value_int")]
        public static extern InformationError GetProcessMemoryValueInt(int[] pid, int size, ProcessMemoryInfoKey memoryInfoKey, out IntPtr array);
    }
}
