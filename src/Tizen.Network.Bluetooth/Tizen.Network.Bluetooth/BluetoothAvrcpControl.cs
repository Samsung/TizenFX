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
using System.ComponentModel;
using System.Threading.Tasks;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// This class is used to send commands from the control device (For example, headset) to the target device (For example, media player).
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
    /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
    /// <remarks>
    /// This class can be obtained from BluetoothDevice.GetProfile method.
    /// </remarks>
    public class BluetoothAvrcpControl : BluetoothProfile
    {
        private TaskCompletionSource<bool> _taskForConnection;
        private TaskCompletionSource<bool> _taskForDisconnection;
        private bool disposed = false;
        private bool _isConnected = false;

        internal BluetoothAvrcpControl()
        {
            BluetoothAvrcpControlImpl.Instance.ConnectionChanged += OnConnectionChanged;
            BluetoothAvrcpControlImpl.Instance.PositionChanged += OnPositionChanged;
            BluetoothAvrcpControlImpl.Instance.PlayStateChanged += OnPlayStateChanged;
            BluetoothAvrcpControlImpl.Instance.TrackInfoChanged += OnTrackInfoChanged;
        }

        private void OnConnectionChanged(object s, AvrcpControlConnectionChangedEventArgs e)
        {
            if (e.RemoteAddress != RemoteAddress)
            {
                return;
            }

            _isConnected = e.IsConnected;

            if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
            {
                if (e.IsConnected == true)
                {
                    _taskForConnection.SetResult(true);
                    ConnectionStateChanged?.Invoke(this, e);
                }
                else
                {
                    _taskForConnection.SetException(BluetoothErrorFactory.CreateBluetoothException((int)BluetoothError.OperationFailed));
                }
                _taskForConnection = null;
                return;
            }
            if (_taskForDisconnection != null && !_taskForDisconnection.Task.IsCompleted)
            {
                if (e.IsConnected == false)
                {
                    _taskForDisconnection.SetResult(true);
                    ConnectionStateChanged?.Invoke(this, e);
                }
                else
                {
                    _taskForDisconnection.SetException(BluetoothErrorFactory.CreateBluetoothException((int)BluetoothError.OperationFailed));
                }
                _taskForDisconnection = null;
            }
        }

        private void OnPositionChanged(object s, PositionChangedEventArgs e)
        {
            PositionChanged?.Invoke(this, e);
        }

        private void OnPlayStateChanged(object s, PlayStateChangedEventArgs e)
        {
            PlayStateChanged?.Invoke(this, e);
        }

        private void OnTrackInfoChanged(object s, TrackInfoChangedEventArgs e)
        {
            TrackInfoChanged?.Invoke(this, e);
        }

        /// <summary>
        /// The AvrcpControlConnectionChangedEventArgs event is invoked when the connection status of device is changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<AvrcpControlConnectionChangedEventArgs> ConnectionStateChanged;

        /// <summary>
        /// The PositionChangedEventArgs event is invoked when the play position of a track is changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<PositionChangedEventArgs> PositionChanged;

        /// <summary>
        /// The PlayStateChangedEventArgs event is invoked when the play state of a track gets changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<PlayStateChangedEventArgs> PlayStateChanged;

        /// <summary>
        /// The TrackInfoChangedEventArgs event is invoked when info of a track gets changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<TrackInfoChangedEventArgs> TrackInfoChanged;

        /// <summary>
        /// Asynchronously connects the remote device
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails</exception>
        public Task ConnectAsync()
        {
            if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }

            _taskForConnection = new TaskCompletionSource<bool>();
            BluetoothAvrcpControlImpl.Instance.Connect(RemoteAddress);
            return _taskForConnection.Task;
        }

        /// <summary>
        /// Asynchronously disconnects the remote device
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails</exception>
        public Task DisconnectAsync()
        {
            if (_taskForDisconnection != null && !_taskForDisconnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }
            _taskForDisconnection = new TaskCompletionSource<bool>();
            BluetoothAvrcpControlImpl.Instance.Disconnect(RemoteAddress);
            return _taskForDisconnection.Task;
        }

        /// <summary>
        /// A property for the equalizer mode of target device.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the equalizer state to the remote device fails.
        /// </exception>
        public EqualizerState EqualizerState
        {
            get
            {
                if (_isConnected == true)
                {
                    return BluetoothAvrcpControlImpl.Instance.GetEqualizerState();
                }
                else
                {
                    return EqualizerState.Off;
                }
            }
            set
            {
                if (_isConnected == true)
                {
                    BluetoothAvrcpControlImpl.Instance.SetEqualizerState(value);
                }
            }
        }

        /// <summary>
        /// A property for the repeat mode of target device.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the repeat mode state to the remote device fails.
        /// </exception>
        public RepeatMode RepeatMode
        {
            get
            {
                if (_isConnected == true)
                {
                    return BluetoothAvrcpControlImpl.Instance.GetRepeatMode();
                }
                else
                {
                    return RepeatMode.Off;
                }
            }
            set
            {
                if (_isConnected == true)
                {
                    BluetoothAvrcpControlImpl.Instance.SetRepeatMode(value);
                }
            }
        }

        /// <summary>
        /// A property for the suffle mode of target device.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if retrieving shuffle mode of the remote device fails.
        /// </exception>
        public ShuffleMode ShuffleMode
        {
            get
            {
                if (_isConnected == true)
                {
                    return BluetoothAvrcpControlImpl.Instance.GetShuffleMode();
                }
                else
                {
                    return ShuffleMode.Off;
                }
            }
            set
            {
                if (_isConnected == true)
                {
                    BluetoothAvrcpControlImpl.Instance.SetShuffleMode(value);
                }
            }
        }

        /// <summary>
        /// A property for the scan mode of target device.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if retrieving scan mode of the remote device fails.
        /// </exception>
        public ScanMode ScanMode
        {
            get
            {
                if (_isConnected == true)
                {
                    return BluetoothAvrcpControlImpl.Instance.GetScanMode();
                }
                else
                {
                    return ScanMode.Off;
                }
            }
            set
            {
                if (_isConnected == true)
                {
                    BluetoothAvrcpControlImpl.Instance.SetScanMode(value);
                }
            }
        }

        /// <summary>
        /// Gets position of the track being played on the target device.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <returns> Play position of the track being played on the target device </returns>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if there is an error retrieving the position of the track that is currently being played.
        /// </exception>
        public uint GetPosition()
        {
            if (_isConnected == true)
            {
                return BluetoothAvrcpControlImpl.Instance.GetPosition();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.RemoteDeviceNotConnected);
                return 0;
            }
        }

        /// <summary>
        /// Gets player state of the target device.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <returns> Play status of the target device </returns>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if there happens to be an error while retrieving the player state of the target device.
        /// </exception>
        public PlayerState GetPlayStatus()
        {
            if (_isConnected == true)
            {
                return BluetoothAvrcpControlImpl.Instance.GetPlayStatus();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.RemoteDeviceNotConnected);
                return PlayerState.Stopped;
            }
        }

        /// <summary>
        /// Gets info of the track being played on the target device.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <returns> Info of the track being played on the target device </returns>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if there happens to be an error while retrieving info of the track being played on the target.
        /// </exception>
        public Track GetTrackInfo()
        {
            if (_isConnected == true)
            {
                return BluetoothAvrcpControlImpl.Instance.GetTrackInfo();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.RemoteDeviceNotConnected);
                return null;
            }
        }

        /// <summary>
        /// Sends a particular play command to the target device
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="command">Command to be sent</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when sending command to the target device fails.
        /// </exception>
        public void SendPlayerCommand(PlayerCommand command)
        {
            if (_isConnected == true)
            {
                BluetoothAvrcpControlImpl.Instance.SendPlayerCommand(command);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.RemoteDeviceNotConnected);
            }
        }

        /// <summary>
        /// Sends a play command to a particular target device
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="command">Command to be sent</param>
        /// <param name="remoteAddress">Address of the device to send command</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when sending command to the target device fails.
        /// </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendPlayerCommandTo(PlayerCommand command, string remoteAddress)
        {
            if (_isConnected == true)
            {
                BluetoothAvrcpControlImpl.Instance.SendPlayerCommandTo(command, remoteAddress);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.RemoteDeviceNotConnected);
            }
        }

        /// <summary>
        /// Sets absolute volume of target device
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected
        /// </remarks>
        /// <param name="volume">The volume level to be set</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when setting absolute volume of the target device fails
        /// </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAbsoluteVolume(uint volume)
        {
            if (_isConnected == true)
            {
                BluetoothAvrcpControlImpl.Instance.SetAbsoluteVolume(volume);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.RemoteDeviceNotConnected);
            }
        }

        /// <summary>
        /// Increases volume of target device
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when increasing volume of the target device fails
        /// </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void IncreaseVolume()
        {
            if (_isConnected == true)
            {
                BluetoothAvrcpControlImpl.Instance.IncreaseVolume();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.RemoteDeviceNotConnected);
            }
        }

        /// <summary>
        /// Decreases volume of target device
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when decreasing volume of the target device fails
        /// </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DecreaseVolume()
        {
            if (_isConnected == true)
            {
                BluetoothAvrcpControlImpl.Instance.DecreaseVolume();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.RemoteDeviceNotConnected);
            }
        }

        /// <summary>
        /// Sends delay report to the target device
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.bluetooth.audio.controller</feature>
        /// <remarks>
        /// The remote device must be connected
        /// </remarks>
        /// <param name="delay">Delay to be sent to target</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when sending delay to the target device fails
        /// </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendDelayReport(uint delay)
        {
            if (_isConnected == true)
            {
                BluetoothAvrcpControlImpl.Instance.SendDelayReport(delay);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.RemoteDeviceNotConnected);
            }
        }

        /// <summary>
        /// Finalizes an instance of the BluetoothAvrcpControl class.
        /// </summary>
        ~BluetoothAvrcpControl()
        {
            Dispose(false);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
                BluetoothAvrcpControlImpl.Instance.ConnectionChanged -= OnConnectionChanged;
                BluetoothAvrcpControlImpl.Instance.PositionChanged -= OnPositionChanged;
                BluetoothAvrcpControlImpl.Instance.PlayStateChanged -= OnPlayStateChanged;
                BluetoothAvrcpControlImpl.Instance.TrackInfoChanged -= OnTrackInfoChanged;
            }
            //Free unmanaged objects.
            disposed = true;
        }
    }
}
