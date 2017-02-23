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

internal static partial class Interop
{
    internal enum RadioState
    {
        Ready, // RADIO_STATE_READY
        Playing, // RADIO_STATE_PLAYING
        Scanning, // RADIO_STATE_SCANNING
    }

    internal enum RadioInterruptedReason
    {
        Completed, // RADIO_INTERRUPTED_COMPLETED
        Media, // RADIO_INTERRUPTED_BY_MEDIA
        Call, // RADIO_INTERRUPTED_BY_CALL
        EarjackUnplug, // RADIO_INTERRUPTED_BY_EARJACK_UNPLUG
        ResourceConflict, // RADIO_INTERRUPTED_BY_RESOURCE_CONFLICT
        Alarm, // RADIO_INTERRUPTED_BY_ALARM
        Emergency, // RADIO_INTERRUPTED_BY_EMERGENCY
        ResumableMedia, // RADIO_INTERRUPTED_BY_RESUMABLE_MEDIA
        Notification, // RADIO_INTERRUPTED_BY_NOTIFICATION
    }

    [DllImport(Libraries.Radio, EntryPoint = "radio_get_state")]
    internal static extern ErrorCode GetState(this RadioHandle /* radio_h */ radio, out RadioState /* radio_state_e */ state);

    [DllImport(Libraries.Radio, EntryPoint = "radio_start")]
    internal static extern ErrorCode Start(this RadioHandle /* radio_h */ radio);

    [DllImport(Libraries.Radio, EntryPoint = "radio_stop")]
    internal static extern ErrorCode Stop(this RadioHandle /* radio_h */ radio);

    [DllImport(Libraries.Radio, EntryPoint = "radio_seek_up")]
    internal static extern ErrorCode SeekUp(this RadioHandle /* radio_h */ radio, RadioHandle.SeekCompletedCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.Radio, EntryPoint = "radio_seek_down")]
    internal static extern ErrorCode SeekDown(this RadioHandle /* radio_h */ radio, RadioHandle.SeekCompletedCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.Radio, EntryPoint = "radio_set_frequency")]
    internal static extern ErrorCode SetFrequency(this RadioHandle /* radio_h */ radio, int frequency);

    [DllImport(Libraries.Radio, EntryPoint = "radio_get_frequency")]
    internal static extern ErrorCode GetFrequency(this RadioHandle /* radio_h */ radio, out int frequency);

    [DllImport(Libraries.Radio, EntryPoint = "radio_get_signal_strength")]
    internal static extern ErrorCode GetSignalStrength(this RadioHandle /* radio_h */ radio, out int strength);

    [DllImport(Libraries.Radio, EntryPoint = "radio_scan_start")]
    internal static extern ErrorCode ScanStart(this RadioHandle /* radio_h */ radio, RadioHandle.ScanUpdatedCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.Radio, EntryPoint = "radio_scan_stop")]
    internal static extern ErrorCode ScanStop(this RadioHandle /* radio_h */ radio, RadioHandle.ScanStoppedCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.Radio, EntryPoint = "radio_set_mute")]
    internal static extern ErrorCode SetMute(this RadioHandle /* radio_h */ radio, bool muted);

    [DllImport(Libraries.Radio, EntryPoint = "radio_is_muted")]
    internal static extern ErrorCode GetMuted(this RadioHandle /* radio_h */ radio, out bool muted);

    [DllImport(Libraries.Radio, EntryPoint = "radio_set_scan_completed_cb")]
    internal static extern ErrorCode SetScanCompletedCb(this RadioHandle /* radio_h */ radio, RadioHandle.ScanCompletedCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.Radio, EntryPoint = "radio_unset_scan_completed_cb")]
    internal static extern ErrorCode UnsetScanCompletedCb(this RadioHandle /* radio_h */ radio);

    [DllImport(Libraries.Radio, EntryPoint = "radio_set_interrupted_cb")]
    internal static extern ErrorCode SetInterruptedCb(this RadioHandle /* radio_h */ radio, RadioHandle.InterruptedCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.Radio, EntryPoint = "radio_unset_interrupted_cb")]
    internal static extern ErrorCode UnsetInterruptedCb(this RadioHandle /* radio_h */ radio);

    [DllImport(Libraries.Radio, EntryPoint = "radio_get_frequency_range")]
    internal static extern ErrorCode GetFrequencyRange(this RadioHandle /* radio_h */ radio, out int minFreq, out int maxFreq);

    [DllImport(Libraries.Radio, EntryPoint = "radio_get_channel_spacing")]
    internal static extern ErrorCode GetChannelSpacing(this RadioHandle /* radio_h */ radio, out int channelSpacing);

    [DllImport(Libraries.Radio, EntryPoint = "radio_set_volume")]
    internal static extern ErrorCode SetVolume(this RadioHandle /* radio_h */ radio, float volume);

    [DllImport(Libraries.Radio, EntryPoint = "radio_get_volume")]
    internal static extern ErrorCode GetVolume(this RadioHandle /* radio_h */ radio, out float volume);

    internal struct RadioFrequencyRange
    {
        public int minFreq;
        public int maxFreq;
    }

    internal class RadioHandle : SafeMultimediaHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SeekCompletedCallback(int frequency, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ScanUpdatedCallback(int frequency, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ScanStoppedCallback(IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ScanCompletedCallback(IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InterruptedCallback(RadioInterruptedReason /* radio_interrupted_code_e */ code, IntPtr /* void */ userData);

        [DllImport(Libraries.Radio, EntryPoint = "radio_create")]
        internal static extern ErrorCode Create(out IntPtr /* radio_h */ radio);

        [DllImport(Libraries.Radio, EntryPoint = "radio_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* radio_h */ radio);

        internal RadioHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease)
        {
        }

        internal RadioHandle() : this(CreateNativeHandle(), true)
        {
        }

        internal static IntPtr CreateNativeHandle()
        {
            IntPtr handle;
            Create(out handle).ThrowIfFailed("Failed to create native handle");
            return handle;
        }

        internal override ErrorCode DisposeNativeHandle()
        {
            ScanCompleteCb = null;
            InteruptedCb = null;
            return Destroy(handle);
        }

        internal RadioState State
        {
            get { return NativeGet<RadioState>(this.GetState); }
        }

        internal int Frequency
        {
            get { return NativeGet<int>(this.GetFrequency); }
            set { NativeSet(this.SetFrequency, value); }
        }

        internal int SignalStrength
        {
            get { return NativeGet<int>(this.GetSignalStrength); }
        }

        internal bool IsMuted
        {
            get { return NativeGet<bool>(this.GetMuted); }
            set { NativeSet(this.SetMute, value); }
        }

        internal int ChannelSpacing
        {
            get { return NativeGet<int>(this.GetChannelSpacing); }
        }

        internal float Volume
        {
            get { return NativeGet<float>(this.GetVolume); }
            set { NativeSet(this.SetVolume, value); }
        }

        internal int MinimumFrequency
        {
            get
            {
                RadioFrequencyRange range;
                this.GetFrequencyRange(out range.minFreq, out range.maxFreq);
                return range.minFreq;
            }
        }

        internal int MaximumFrequency
        {
            get
            {
                RadioFrequencyRange range;
                this.GetFrequencyRange(out range.minFreq, out range.maxFreq);
                return range.maxFreq;
            }
        }

        internal ScanCompletedCallback ScanCompleteCb
        {
            set
            {
                var err = (value != null) ? this.SetScanCompletedCb(value, IntPtr.Zero) : this.UnsetScanCompletedCb();
                err.ThrowIfFailed("Failed to set/ unset scan complete callback");
            }
        }

        internal InterruptedCallback InteruptedCb
        {
            set
            {
                var err = (value != null) ? this.SetInterruptedCb(value, IntPtr.Zero) : this.UnsetInterruptedCb();
                err.ThrowIfFailed("Failed to set/ unset interrupted callback");
            }
        }

        internal void StartPlayback()
        {
            this.Start().ThrowIfFailed("Failed to start radio");
        }

        internal void StopPlayback()
        {
            this.Stop().ThrowIfFailed("Failed to stop radio");
        }

        internal void StartScan(ScanUpdatedCallback callback)
        {
            this.ScanStart(callback, IntPtr.Zero).ThrowIfFailed("Failed to start radio");
        }

        internal void StopScan(ScanStoppedCallback callback)
        {
            this.ScanStop(callback, IntPtr.Zero).ThrowIfFailed("Failed to stop radio");
        }

        internal void SeekUp(SeekCompletedCallback callback)
        {
            this.SeekUp(callback, IntPtr.Zero).ThrowIfFailed("Failed to start radio");
        }

        internal void SeekDown(SeekCompletedCallback callback)
        {
            this.SeekDown(callback, IntPtr.Zero).ThrowIfFailed("Failed to stop radio");
        }
    }
}
