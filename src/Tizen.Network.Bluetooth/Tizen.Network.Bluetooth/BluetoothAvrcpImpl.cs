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

namespace Tizen.Network.Bluetooth
{
    internal class BluetoothAvrcpImpl : IDisposable
    {
        private event EventHandler<TargetConnectionStateChangedEventArgs> _targetConnectionChanged;
        private event EventHandler<EqualizerStateChangedEventArgs> _equalizerStateChanged;
        private event EventHandler<RepeatModeChangedEventArgs> _repeatModeChanged;
        private event EventHandler<ScanModeChangedEventArgs> _scanModeChanged;
        private event EventHandler<ShuffleModeChangedeventArgs> _shuffleModeChanged;

        private Interop.Bluetooth.TargetConnectionStateChangedCallback _targetConnectionChangedCallback;
        private Interop.Bluetooth.EqualizerStateChangedCallback _equalizerStateChangedCallback;
        private Interop.Bluetooth.RepeatModeChangedCallback _repeatModeChangedCallback;
        private Interop.Bluetooth.ShuffleModeChangedCallback _shuffleModeChangedCallback;
        private Interop.Bluetooth.ScanModeChangedCallback _scanModeChangedCallback;

        private static Lazy<BluetoothAvrcpImpl> _instance = new Lazy<BluetoothAvrcpImpl>(() =>
        {
            return new BluetoothAvrcpImpl();
        });
        private bool disposed = false;

        internal event EventHandler<TargetConnectionStateChangedEventArgs> TargetConnectionStateChanged
        {
            add
            {
                _targetConnectionChanged += value;
            }
            remove
            {
                _targetConnectionChanged -= value;
            }
        }

        internal event EventHandler<EqualizerStateChangedEventArgs> EqualizerStateChanged
        {
            add
            {
                if (_equalizerStateChanged == null)
                {
                    RegisterEqualizerStateChangedEvent();
                }
                _equalizerStateChanged += value;
            }
            remove
            {
                _equalizerStateChanged -= value;
                if (_equalizerStateChanged == null)
                {
                    UnregisterEqualizerStateChangedEvent();
                }
            }
        }

        internal event EventHandler<RepeatModeChangedEventArgs> RepeatModeChanged
        {
            add
            {
                if (_repeatModeChanged == null)
                {
                    RegisterRepeatModeChangedEvent();
                }
                _repeatModeChanged += value;
            }
            remove
            {
                _repeatModeChanged -= value;
                if (_repeatModeChanged == null)
                {
                    UnregisterRepeatModeChangedEvent();
                }
            }
        }

        internal event EventHandler<ShuffleModeChangedeventArgs> ShuffleModeChanged
        {
            add
            {
                if (_shuffleModeChanged == null)
                {
                    RegisterShuffleModeChangedEvent();
                }
                _shuffleModeChanged += value;
            }
            remove
            {
                _shuffleModeChanged -= value;
                if (_shuffleModeChanged == null)
                {
                    UnregisterShuffleModeChangedEvent();
                }
            }
        }

        internal event EventHandler<ScanModeChangedEventArgs> ScanModeChanged
        {
            add
            {
                if (_scanModeChanged == null)
                {
                    RegisterScanModeChangedEvent();
                }
                _scanModeChanged += value;
            }
            remove
            {
                _scanModeChanged -= value;
                if (_scanModeChanged == null)
                {
                    UnregisterScanModeChangedEvent();
                }
            }
        }

        private void RegisterEqualizerStateChangedEvent()
        {
            _equalizerStateChangedCallback = (int equalizer, IntPtr userData) =>
            {
                if (_equalizerStateChanged != null)
                {
                    EqualizerState state = (EqualizerState) equalizer;
                    _equalizerStateChanged(null, new EqualizerStateChangedEventArgs(state));
                }
            };
            int ret = Interop.Bluetooth.SetEqualizerStateChangedCallback(_equalizerStateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set equalizer state changed callback, Error - " + (BluetoothError)ret);
            }
        }
        private void UnregisterEqualizerStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetEqualizerStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset equalizer state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterRepeatModeChangedEvent()
        {
            _repeatModeChangedCallback = (int repeat, IntPtr userData) =>
            {
                if (_repeatModeChanged != null)
                {
                    RepeatMode mode = (RepeatMode)repeat;
                    _repeatModeChanged(null, new RepeatModeChangedEventArgs(mode));
                }
            };
            int ret = Interop.Bluetooth.SetRepeatModeChangedCallback(_repeatModeChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set repeat mode changed callback, Error - " + (BluetoothError)ret);
            }
        }
        private void UnregisterRepeatModeChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetRepeatModeChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset repeat mode changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterShuffleModeChangedEvent()
        {
            Log.Debug (Globals.LogTag, "inside RegisterShuffleModeChangedEvent");
            _shuffleModeChangedCallback = (int shuffle, IntPtr userData) =>
            {
                Log.Debug (Globals.LogTag, "inside RegisterShuffleModeChangedEvent callback");
                if (_shuffleModeChanged != null)
                {
                    ShuffleMode mode = (ShuffleMode) shuffle;
                    _shuffleModeChanged(null, new ShuffleModeChangedeventArgs(mode));
                }
            };
            int ret = Interop.Bluetooth.SetShuffleModeChangedCallback(_shuffleModeChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Debug (Globals.LogTag, "failed inside RegisterShuffleModeChangedEvent");
                Log.Error(Globals.LogTag, "Failed to set shuffle mode changed callback, Error - " + (BluetoothError)ret);
            }
        }
        private void UnregisterShuffleModeChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetShuffleModeChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset shuffle mode changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterScanModeChangedEvent()
        {
            _scanModeChangedCallback = (int scan, IntPtr userData) =>
            {
                if (_scanModeChanged != null)
                {
                    ScanMode mode = (ScanMode) scan;
                    _scanModeChanged(null, new ScanModeChangedEventArgs(mode));
                }
            };
            int ret = Interop.Bluetooth.SetScanModeChangedCallback(_scanModeChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set scan mode changed callback, Error - " + (BluetoothError)ret);
            }
        }
        private void UnregisterScanModeChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetScanModeChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset scan mode changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void targetInitialize()
        {
            if (Globals.IsInitialize)
            {
                _targetConnectionChangedCallback = (bool connected, string deviceAddress, IntPtr userData) =>
                {
                    if (_targetConnectionChanged != null)
                    {
                        _targetConnectionChanged(null, new TargetConnectionStateChangedEventArgs(connected, deviceAddress));
                    }
                };

                int ret = Interop.Bluetooth.InitializeAvrcp(_targetConnectionChangedCallback, IntPtr.Zero);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error (Globals.LogTag, "Failed to initialize bluetooth avrcp, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
                else
                {
                    Globals.IsAudioInitialize = true;
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Failed to initialize Avrcp, BT not initialized");
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotInitialized);
            }
        }

        private void targetDeinitialize()
        {
            if (Globals.IsAudioInitialize)
            {
                int ret = Interop.Bluetooth.DeinitializeAvrcp();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error (Globals.LogTag, "Failed to deinitialize bluetooth avrcp, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
                else
                {
                    Globals.IsAudioInitialize = false;
                }
            }
        }

        internal void NotifyEqualizeState(EqualizerState state)
        {
            int ret = Interop.Bluetooth.NotifyEqualizerState((int)state);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to notify equalizer state to remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void NotifyRepeatMode(RepeatMode repeat)
        {
            int ret = Interop.Bluetooth.NotifyRepeatMode((int)repeat);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to notify repeat mode to remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void NotifyShuffleMode(ShuffleMode shuffle)
        {
            int ret = Interop.Bluetooth.NotifyShuffleMode((int)shuffle);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to notify shuffle mode to remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void NotifyScanMode(ScanMode scan)
        {
            int ret = Interop.Bluetooth.NotifyScanMode((int)scan);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to notify scan mode to remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void NotifyPlayerState(PlayerState state)
        {
            int ret = Interop.Bluetooth.NotifyPlayerState((int)state);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to notify player state to remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void NotifyCurrentPosition(uint position)
        {
            int ret = Interop.Bluetooth.NotifyCurrentPosition(position);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to notify position to remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void NotifyTrack(Track trackData)
        {
            string title = trackData.Title;
            string artist = trackData.Artist;
            string album = trackData.Album;
            string genre = trackData.Genre;
            uint trackNum = trackData.TrackNum;
            uint totalTracks = trackData.TotalTracks;
            uint duration = trackData.Duration;

            int ret = Interop.Bluetooth.NotifyTrack(title, artist, album, genre, trackNum, totalTracks, duration);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to notify track data to the remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal static BluetoothAvrcpImpl Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private BluetoothAvrcpImpl()
        {
            targetInitialize();
        }

        ~BluetoothAvrcpImpl()
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
            targetDeinitialize();
            RemoveAllRegisteredEvent();
            disposed = true;
        }

        private void RemoveAllRegisteredEvent()
        {
            //unregister all remaining events when this object is released.
            if (_equalizerStateChanged != null)
            {
                UnregisterEqualizerStateChangedEvent();
            }
            if (_repeatModeChanged != null)
            {
                UnregisterRepeatModeChangedEvent();
            }
            if (_scanModeChanged != null)
            {
                UnregisterScanModeChangedEvent();
            }
            if (_shuffleModeChanged != null)
            {
                UnregisterShuffleModeChangedEvent();
            }
        }
    }
}

