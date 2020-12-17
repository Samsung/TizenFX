/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Network.Bluetooth
{
    internal class BluetoothAvrcpControlImpl :IDisposable
    {
        private event EventHandler<PositionChangedEventArgs> _positionChanged;
        private event EventHandler<PlayStateChangedEventArgs> _playStateChanged;
        private event EventHandler<TrackInfoChangedEventArgs> _trackInfoChanged;

        private Interop.Bluetooth.PositionChangedCallback _positionChangedCallback;
        private Interop.Bluetooth.PlayStatusChangedCallback _playStateChangedCallback;
        private Interop.Bluetooth.TrackInfoChangedCallback _trackInfoChangedCallback;
        private Interop.Bluetooth.AvrcpControlConnectionChangedCallback _connStateChangedCallback;

        private static readonly Lazy<BluetoothAvrcpControlImpl> _instance = new Lazy<BluetoothAvrcpControlImpl>(() =>
        {
            return new BluetoothAvrcpControlImpl();
        });
        private bool disposed = false;

        internal event EventHandler<AvrcpControlConnectionChangedEventArgs> ConnectionChanged;

        internal event EventHandler<PositionChangedEventArgs> PositionChanged
        {
            add
            {
                if (_positionChanged == null)
                {
                    RegisterPositionChangedEvent();
                }
                _positionChanged += value;
            }
            remove
            {
                _positionChanged -= value;
                if (_positionChanged == null)
                {
                    UnregisterPositionChangedEvent();
                }
            }
        }

        internal event EventHandler<PlayStateChangedEventArgs> PlayStateChanged
        {
            add
            {
                if (_playStateChanged == null)
                {
                    RegisterPlayStateChangedEvent();
                }
                _playStateChanged += value;
            }
            remove
            {
                _playStateChanged -= value;
                if (_playStateChanged == null)
                {
                    UnregisterPlayStateChangedEvent();
                }
            }
        }

        internal event EventHandler<TrackInfoChangedEventArgs> TrackInfoChanged
        {
            add
            {
                if (_trackInfoChanged == null)
                {
                    RegisterTrackInfoChangedEvent();
                }
                _trackInfoChanged += value;
            }
            remove
            {
                _trackInfoChanged -= value;
                if (_trackInfoChanged == null)
                {
                    UnregisterTrackInfoChangedEvent();
                }
            }
        }

        private void RegisterPositionChangedEvent()
        {
            _positionChangedCallback = (uint position, IntPtr userData) =>
            {
                _positionChanged?.Invoke(null, new PositionChangedEventArgs(position));
            };
            int ret = Interop.Bluetooth.SetPositionChangedCallback(_positionChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set position changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterPositionChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetPositionChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset position changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterPlayStateChangedEvent()
        {
            _playStateChangedCallback = (int state, IntPtr userdata) =>
            {
                _playStateChanged?.Invoke(null, new PlayStateChangedEventArgs((PlayerState)state));
            };
            int ret = Interop.Bluetooth.SetPlayStatusChangedCallback(_playStateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set play status changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterPlayStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetPlayStatusChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset play status changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterTrackInfoChangedEvent()
        {
            _trackInfoChangedCallback = (ref TrackInfoStruct track_info, IntPtr userdata) =>
            {
                Track track = new Track();
                track.Album = Marshal.PtrToStringAnsi(track_info.Album);
                track.Artist = Marshal.PtrToStringAnsi(track_info.Artist);
                track.Genre = Marshal.PtrToStringAnsi(track_info.Genre);
                track.Title = Marshal.PtrToStringAnsi(track_info.Title);
                track.TotalTracks = track_info.total_tracks;
                track.TrackNum = track_info.number;
                track.Duration = track_info.duration;

                Log.Debug(Globals.LogTag, "Album: " + track.Album
                    + ", Artist: " + track.Artist
                    + ", Genre: " + track.Genre
                    + ", Title: " + track.Title
                    + ", TotalTracks: " + track.TotalTracks
                    + ", TrackNum: " + track.TrackNum
                    + ", Duration: " + track.Duration);

                _trackInfoChanged?.Invoke(null, new TrackInfoChangedEventArgs(track));
            };
            int ret = Interop.Bluetooth.SetTrackInfoChangedCallback(_trackInfoChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set track info changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterTrackInfoChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetTrackInfoChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset track info changed callback, Error - " + (BluetoothError)ret);
            }
        }

        internal void Connect(string address)
        {
            int ret = Interop.Bluetooth.AvrcpControlConnect(address);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void Disconnect(string address)
        {
            int ret = Interop.Bluetooth.AvrcpControlDisconnect(address);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal EqualizerState GetEqualizerState()
        {
            EqualizerState state;
            int ret = Interop.Bluetooth.GetEqualizerState(out state);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get equalizer state " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return state;
        }

        internal void SetEqualizerState(EqualizerState state)
        {
            int ret = Interop.Bluetooth.SetEqualizerState(state);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set equalizer state to " + state + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal RepeatMode GetRepeatMode()
        {
            RepeatMode mode;
            int ret = Interop.Bluetooth.GetRepeatMode(out mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get repeat mode" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return mode;
        }

        internal void SetRepeatMode(RepeatMode mode)
        {
            int ret = Interop.Bluetooth.SetRepeatMode(mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set repeat mode to " + mode + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal ShuffleMode GetShuffleMode()
        {
            ShuffleMode mode;
            int ret = Interop.Bluetooth.GetShuffleMode(out mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get shuffle mode" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return mode;
        }

        internal void SetShuffleMode(ShuffleMode mode)
        {
            int ret = Interop.Bluetooth.SetShuffleMode(mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set shuffle mode to " + mode + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal ScanMode GetScanMode()
        {
            ScanMode mode;
            int ret = Interop.Bluetooth.GetScanMode(out mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get scan mode" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return mode;
        }

        internal void SetScanMode(ScanMode mode)
        {
            int ret = Interop.Bluetooth.SetScanMode(mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set scan mode to " + mode + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal uint GetPosition()
        {
            uint position;
            int ret = Interop.Bluetooth.GetPosition(out position);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get play position" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return position;
        }

        internal PlayerState GetPlayStatus()
        {
            PlayerState state;
            int ret = Interop.Bluetooth.GetPlayStatus(out state);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get play status" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return state;
        }

        internal Track GetTrackInfo()
        {
            Track track = new Track();
            TrackInfoStruct track_info;
            IntPtr infoptr;

            int ret = Interop.Bluetooth.GetTrackInfo(out infoptr);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get track data" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            track_info = (TrackInfoStruct)Marshal.PtrToStructure(infoptr, typeof(TrackInfoStruct));
            track.Album = Marshal.PtrToStringAnsi(track_info.Album);
            track.Artist = Marshal.PtrToStringAnsi(track_info.Artist);
            track.Genre = Marshal.PtrToStringAnsi(track_info.Genre);
            track.Title = Marshal.PtrToStringAnsi(track_info.Title);
            track.TotalTracks = track_info.total_tracks;
            track.TrackNum = track_info.number;
            track.Duration = track_info.duration;

            Log.Debug(Globals.LogTag, "Album: " + track.Album
                + ", Artist: " + track.Artist
                + ", Genre: " + track.Genre
                + ", Title: " + track.Title
                + ", TotalTracks: " + track.TotalTracks
                + ", TrackNum: " + track.TrackNum
                + ", Duration: " + track.Duration);

            ret = Interop.Bluetooth.FreeTrackInfo(infoptr);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to free track data" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }

            return track;
        }

        internal void SendPlayerCommand(PlayerCommand command)
        {
            int ret = Interop.Bluetooth.SendPlayerCommand(command);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to send player command " + command + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }
        internal void SendPlayerCommandTo(PlayerCommand command, string remoteAddress)
        {
            int ret = Interop.Bluetooth.SendPlayerCommandTo(command, remoteAddress);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to send player command " + command + " to remote address " + remoteAddress + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void SetAbsoluteVolume(uint volume)
        {
            int ret = Interop.Bluetooth.SetAbsoluteVolume(volume);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set absolute volume to level " + volume + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void IncreaseVolume()
        {
            int ret = Interop.Bluetooth.IncreaseVolume();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to increase volume" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void DecreaseVolume()
        {
            int ret = Interop.Bluetooth.DecreaseVolume();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to decrease volume" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void SendDelayReport(uint delay)
        {
            int ret = Interop.Bluetooth.SendDelayReport(delay);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to send delay report" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal static BluetoothAvrcpControlImpl Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private BluetoothAvrcpControlImpl ()
        {
            ControlInitialize();
        }

        private void ControlInitialize()
        {
            _connStateChangedCallback = (bool connected, string remoteAddress, IntPtr userData) =>
            {
                ConnectionChanged?.Invoke(null, new AvrcpControlConnectionChangedEventArgs(connected, remoteAddress));
            };
            int ret = Interop.Bluetooth.AvrcpControlInitialize(_connStateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to initialize AVRCP Control, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        private void ControlDeinitialize()
        {
            int ret = Interop.Bluetooth.AvrcpControlDeinitialize();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deinitialize AVRCP Control, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterAllEvents()
        {
            if (_playStateChanged == null)
            {
                UnregisterPlayStateChangedEvent();
            }
            if (_positionChanged == null)
            {
                UnregisterPositionChangedEvent();
            }
            if (_trackInfoChanged == null)
            {
                UnregisterTrackInfoChangedEvent();
            }
        }

        ~BluetoothAvrcpControlImpl()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }
            //Free unmanaged objects
            ControlDeinitialize();
            UnregisterAllEvents();
            disposed = true;
        }
    }
}
