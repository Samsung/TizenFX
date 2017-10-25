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
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static class Radio
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SeekCompletedCallback(int frequency, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ScanUpdatedCallback(int frequency, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ScanStoppedCallback(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ScanCompletedCallback(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InterruptedCallback(RadioInterruptedReason reason, IntPtr userData);


        [DllImport(Libraries.Radio, EntryPoint = "radio_create")]
        internal static extern RadioError Create(out RadioHandle radio);

        [DllImport(Libraries.Radio, EntryPoint = "radio_destroy")]
        internal static extern RadioError Destroy(IntPtr radio);

        [DllImport(Libraries.Radio, EntryPoint = "radio_get_state")]
        internal static extern RadioError GetState(RadioHandle radio, out RadioState state);

        [DllImport(Libraries.Radio, EntryPoint = "radio_start")]
        internal static extern RadioError Start(RadioHandle radio);

        [DllImport(Libraries.Radio, EntryPoint = "radio_stop")]
        internal static extern RadioError Stop(RadioHandle radio);

        [DllImport(Libraries.Radio, EntryPoint = "radio_seek_up")]
        internal static extern RadioError SeekUp(RadioHandle radio, SeekCompletedCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Radio, EntryPoint = "radio_seek_down")]
        internal static extern RadioError SeekDown(RadioHandle radio, SeekCompletedCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Radio, EntryPoint = "radio_set_frequency")]
        internal static extern RadioError SetFrequency(RadioHandle radio, int frequency);

        [DllImport(Libraries.Radio, EntryPoint = "radio_get_frequency")]
        internal static extern RadioError GetFrequency(RadioHandle radio, out int frequency);

        [DllImport(Libraries.Radio, EntryPoint = "radio_get_signal_strength")]
        internal static extern RadioError GetSignalStrength(RadioHandle radio, out int strength);

        [DllImport(Libraries.Radio, EntryPoint = "radio_scan_start")]
        internal static extern RadioError ScanStart(RadioHandle radio, ScanUpdatedCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Radio, EntryPoint = "radio_scan_stop")]
        internal static extern RadioError ScanStop(RadioHandle radio, ScanStoppedCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Radio, EntryPoint = "radio_set_mute")]
        internal static extern RadioError SetMute(RadioHandle radio, bool muted);

        [DllImport(Libraries.Radio, EntryPoint = "radio_is_muted")]
        internal static extern RadioError GetMuted(RadioHandle radio, out bool muted);

        [DllImport(Libraries.Radio, EntryPoint = "radio_set_scan_completed_cb")]
        internal static extern RadioError SetScanCompletedCb(RadioHandle radio,
            ScanCompletedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Radio, EntryPoint = "radio_unset_scan_completed_cb")]
        internal static extern RadioError UnsetScanCompletedCb(RadioHandle radio);

        [DllImport(Libraries.Radio, EntryPoint = "radio_set_interrupted_cb")]
        internal static extern RadioError SetInterruptedCb(RadioHandle radio,
            InterruptedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Radio, EntryPoint = "radio_unset_interrupted_cb")]
        internal static extern RadioError UnsetInterruptedCb(RadioHandle radio);

        [DllImport(Libraries.Radio, EntryPoint = "radio_get_frequency_range")]
        internal static extern RadioError GetFrequencyRange(RadioHandle radio, out int minFreq, out int maxFreq);

        [DllImport(Libraries.Radio, EntryPoint = "radio_get_channel_spacing")]
        internal static extern RadioError GetChannelSpacing(RadioHandle radio, out int channelSpacing);

        [DllImport(Libraries.Radio, EntryPoint = "radio_set_volume")]
        internal static extern RadioError SetVolume(RadioHandle radio, float volume);

        [DllImport(Libraries.Radio, EntryPoint = "radio_get_volume")]
        internal static extern RadioError GetVolume(RadioHandle radio, out float volume);
    }

    internal class RadioHandle : SafeHandle
    {
        protected RadioHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            var ret = Radio.Destroy(handle);
            if (ret != RadioError.None)
            {
                Tizen.Log.Debug(GetType().FullName, $"Failed to release native handle.");
                return false;
            }

            return true;
        }
    }
}
