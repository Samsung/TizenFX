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
using Tizen.Multimedia.Vision;

/// <summary>
/// Interop APIs.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Interop for Media Vision APIs.
    /// </summary>
    internal static partial class MediaVision
    {
        /// <summary>
        /// Interop for Surveillance APIs.
        /// </summary>
        internal static partial class Surveillance
        {
            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_event_trigger_create")]
            internal static extern MediaVisionError EventTriggerCreate(string eventType, out IntPtr trigger);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_event_trigger_destroy")]
            internal static extern int EventTriggerDestroy(IntPtr trigger);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_get_event_trigger_type")]
            internal static extern int GetEventTriggerType(IntPtr trigger, out string eventType);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_set_event_trigger_roi")]
            internal static extern MediaVisionError SetEventTriggerRoi(IntPtr trigger, int numberOfPoints, Point[] roi);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_get_event_trigger_roi")]
            internal static extern MediaVisionError GetEventTriggerRoi(IntPtr trigger, out int numberOfPoints, out IntPtr roi);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_subscribe_event_trigger")]
            internal static extern MediaVisionError SubscribeEventTrigger(IntPtr trigger, int videoStreamId,
                IntPtr engineCfg, EventOccurredCallback callback, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_unsubscribe_event_trigger")]
            internal static extern MediaVisionError UnsubscribeEventTrigger(IntPtr trigger, int videoStreamId);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_push_source")]
            internal static extern MediaVisionError PushSource(IntPtr source, int videoStreamId);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_foreach_supported_event_type")]
            internal static extern int ForeachSupportedEventType(EventTypeCallback callback, IntPtr userData);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_foreach_event_result_name")]
            internal static extern int ForeachEventResultName(string eventType, EventResultNameCallback callback,
                IntPtr userData);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_get_result_value")]
            internal static extern MediaVisionError GetResultValue(IntPtr result, string name, out int value);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_get_result_value")]
            internal static extern MediaVisionError GetResultValue(IntPtr result, string name, [Out] int[] value);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_get_result_value")]
            internal static extern MediaVisionError GetResultValue(IntPtr result, string name, [Out] double[] value);

            [DllImport(Libraries.MediaVisionSurveillance, EntryPoint = "mv_surveillance_get_result_value")]
            internal static extern MediaVisionError GetResultValue(IntPtr result, string name, [Out] Rectangle[] value);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EventOccurredCallback(IntPtr trigger, IntPtr source,
                int videoStreamId, IntPtr eventResult, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool EventTypeCallback(string eventType, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool EventResultNameCallback(string name, IntPtr userData);
        }
    }
}
