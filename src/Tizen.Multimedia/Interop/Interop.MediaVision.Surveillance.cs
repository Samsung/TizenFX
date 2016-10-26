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

/// <summary>
/// Interop APIs
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Interop for media vision APIs
    /// </summary>
    internal static partial class MediaVision
    {
        /// <summary>
        /// Interop for surveillance APIs
        /// </summary>
        internal static partial class Surveillance
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_event_trigger_create")]
            internal static extern int EventTriggerCreate(string eventType, out IntPtr /* mv_surveillance_event_trigger_h */ trigger);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_event_trigger_destroy")]
            internal static extern int EventTriggerDestroy(IntPtr /* mv_surveillance_event_trigger_h */ trigger);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_get_event_trigger_type")]
            internal static extern int GetEventTriggerType(IntPtr /* mv_surveillance_event_trigger_h */ trigger, out string eventType);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_set_event_trigger_roi")]
            internal static extern int SetEventTriggerRoi(IntPtr /* mv_surveillance_event_trigger_h */ trigger, int numberOfPoints, IntPtr roi);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_get_event_trigger_roi")]
            internal static extern int GetEventTriggerRoi(IntPtr /* mv_surveillance_event_trigger_h */ trigger, out int numberOfPoints, out IntPtr roi);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_subscribe_event_trigger")]
            internal static extern int SubscribeEventTrigger(IntPtr /* mv_surveillance_event_trigger_h */ trigger, int videoStreamId, IntPtr /* mv_engine_config_h */ engineCfg, MvSurveillanceEventOccurredCallback callback, IntPtr /* void */ userData);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_unsubscribe_event_trigger")]
            internal static extern int UnsubscribeEventTrigger(IntPtr /* mv_surveillance_event_trigger_h */ trigger, int videoStreamId);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_push_source")]
            internal static extern int PushSource(IntPtr /* mv_source_h */ source, int videoStreamId);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_foreach_supported_event_type")]
            internal static extern int ForeachSupportedEventType(MvSurveillanceEventTypeCallback callback, IntPtr /* void */ userData);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_foreach_event_result_name")]
            internal static extern int ForeachEventResultName(string eventType, MvSurveillanceEventResultNameCallback callback, IntPtr /* void */ userData);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_get_result_value")]
            internal static extern int GetResultCount(IntPtr /* mv_surveillance_result_h */ result, string name, out int /* void */ value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_surveillance_get_result_value")]
            internal static extern int GetResultValue(IntPtr /* mv_surveillance_result_h */ result, string name, IntPtr /* void */ value);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void MvSurveillanceEventOccurredCallback(IntPtr /* mv_surveillance_event_trigger_h */ trigger, IntPtr /* mv_source_h */ source, int videoStreamId, IntPtr /* mv_surveillance_result_h */ eventResult, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate bool MvSurveillanceEventTypeCallback(string eventType, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate bool MvSurveillanceEventResultNameCallback(string name, IntPtr /* void */ userData);
        }
    }
}
