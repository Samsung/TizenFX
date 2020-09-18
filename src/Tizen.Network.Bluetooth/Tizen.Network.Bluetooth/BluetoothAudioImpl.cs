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
    internal class BluetoothAudioImpl : IDisposable
    {
        private event EventHandler<AudioConnectionStateChangedEventArgs> _audioConnectionChanged;
        private Interop.Bluetooth.AudioConnectionStateChangedCallback _audioConnectionChangedCallback;

        private event EventHandler<AgScoStateChangedEventArgs> _agScoStateChanged;
        private Interop.Bluetooth.AgScoStateChangedCallback _agScoStateChangedCallback;

        private static readonly Lazy<BluetoothAudioImpl> _instance = new Lazy<BluetoothAudioImpl>(() =>
        {
            return new BluetoothAudioImpl();
        });
        private bool disposed = false;

        internal event EventHandler<AudioConnectionStateChangedEventArgs> AudioConnectionStateChanged
        {
            add
            {
                if (_audioConnectionChanged == null)
                {
                    RegisterAudioConnectionChangedEvent();
                }
                _audioConnectionChanged += value;
            }
            remove
            {
                _audioConnectionChanged -= value;
                if (_audioConnectionChanged == null)
                {
                    UnregisterAudioConnectionChangedEvent();
                }
            }
        }

        private void RegisterAudioConnectionChangedEvent()
        {
            _audioConnectionChangedCallback = (int result, bool connected, string deviceAddress, int profileType, IntPtr userData) =>
            {
                _audioConnectionChanged?.Invoke(this, new AudioConnectionStateChangedEventArgs(result, connected, deviceAddress, (BluetoothAudioProfileType)profileType));
            };
            int ret = Interop.Bluetooth.SetAudioConnectionStateChangedCallback(_audioConnectionChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set audio connection changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterAudioConnectionChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetAudioConnectionStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset audio connection changed callback, Error - " + (BluetoothError)ret);
            }
        }

        internal int Connect(string deviceAddress, BluetoothAudioProfileType type)
        {
            int ret = Interop.Bluetooth.Connect(deviceAddress, (int)type);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect device with the given profile type, Error - " + (BluetoothError)ret);
            }
            return ret;
        }

        internal int Disconnect(string deviceAddress, BluetoothAudioProfileType type)
        {
            int ret = Interop.Bluetooth.Disconnect(deviceAddress, (int)type);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect device with the given profile type, Error - " + (BluetoothError)ret);
            }
            return ret;
        }

        internal void OpenAgSco()
        {
            if (Globals.IsAudioInitialize)
            {
                int ret = Interop.Bluetooth.OpenAgSco();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to open ag sco to remote device, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotInitialized);
            }   
        }

        internal void CloseAgSco()
        {
            if (Globals.IsAudioInitialize)
            {
                int ret = Interop.Bluetooth.CloseAgSco();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to close ag sco to remote device, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotInitialized);
            }
        }

        internal bool IsAgScoOpened
        {
            get
            {
                bool isOpened;
                int ret = Interop.Bluetooth.IsAgScoOpened(out isOpened);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to check whether an opened SCO exists or not., Error - " + (BluetoothError)ret);
                }
                return isOpened;
            }
        }

        internal event EventHandler<AgScoStateChangedEventArgs> AgScoStateChanged
        {
            add
            {
                if (_agScoStateChanged == null)
                {
                    RegisterAgScoStateChangedEvent();
                }
                _agScoStateChanged += value;
            }
            remove
            {
                _agScoStateChanged -= value;
                if (_agScoStateChanged == null)
                {
                    UnregisterAgScoStateChangedEvent();
                }
            }
        }

        private void RegisterAgScoStateChangedEvent()
        {
            _agScoStateChangedCallback = (int result, bool opened, IntPtr userData) =>
            {
                _agScoStateChanged?.Invoke(null, new AgScoStateChangedEventArgs(opened));
            };

            int ret = Interop.Bluetooth.SetAgScoStateChangedCallback(_agScoStateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set ag sco state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterAgScoStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetAgScoStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset ag sco state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        internal void NotifyAgVoiceRecognitionState(bool enable)
        {
            if (Globals.IsAudioInitialize)
            {
                int ret = Interop.Bluetooth.NotifyAgVoiceRecognitionState(enable);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to notify sco voice recognition state, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotInitialized);
            }
        }

        internal static BluetoothAudioImpl Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private BluetoothAudioImpl ()
        {
            Log.Info(Globals.LogTag, "Initializing audio");
            initialize();
        }

        ~BluetoothAudioImpl()
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
            deinitialize();
            RemoveAllRegisteredEvent();
            disposed = true;
        }

        private void initialize()
        {
            if (Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.InitializeAudio ();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to initialize bluetoothaudio, Error - " + (BluetoothError)ret);
                    Globals.IsAudioInitialize = false;
                    BluetoothErrorFactory.ThrowBluetoothException (ret);
                }
                else
                {
                    Globals.IsAudioInitialize = true;
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotInitialized);
            }
        }

        private void deinitialize()
        {
            if (Globals.IsAudioInitialize) {
                int ret = Interop.Bluetooth.DeinitializeAudio ();
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to deinitialize bluetoothaudio, Error - " + (BluetoothError)ret);
                }
            }
        }

        private void RemoveAllRegisteredEvent()
        {
            if (_audioConnectionChanged != null)
            {
                UnregisterAudioConnectionChangedEvent();
            }
        }
    }
}
