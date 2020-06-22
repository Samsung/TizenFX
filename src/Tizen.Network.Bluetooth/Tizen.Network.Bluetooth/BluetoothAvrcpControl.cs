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
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    /// <since_tizen> 8 </since_tizen>
    public class BluetoothAvrcpControl : BluetoothProfile
    {
        private string _remoteAddress;
        private TaskCompletionSource<bool> _taskForConnection;
        private TaskCompletionSource<bool> _taskForDisconnection;
        private bool disposed = false;

        internal BluetoothAvrcpControl()
        {
            BluetoothAvrcpControlImpl.Instance.ConnectionChanged += OnConnectionChanged;
            BluetoothAvrcpControlImpl.Instance.PositionChanged += (s, e) => PositionChanged?.Invoke(this, e);
            BluetoothAvrcpControlImpl.Instance.PlayStateChanged += (s, e) => PlayStateChanged?.Invoke(this, e);
            BluetoothAvrcpControlImpl.Instance.TrackInfoChanged += (s, e) => TrackInfoChanged?.Invoke(this, e);
        }

        private void OnConnectionChanged(object s, AvrcpControlConnectionChangedEventArgs e)
        {
            if (e.RemoteAddress != _remoteAddress)
            {
                return;
            }
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
        /// <param name="remoteAddress">Address of device to be connected</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails</exception>
        /// <since_tizen> 8 </since_tizen>
        public Task ConnectAsync(string remoteAddress)
        {
            if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }

            _taskForConnection = new TaskCompletionSource<bool>();
            _remoteAddress = remoteAddress;
            BluetoothAvrcpControlImpl.Instance.Connect(remoteAddress);
            return _taskForConnection.Task;
        }

        /// <summary>
        /// Asynchronously disconnects the remote device
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails</exception>
        /// <since_tizen> 8 </since_tizen>
        public Task DisconnectAsync()
        {
            if (_taskForDisconnection != null && !_taskForDisconnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }
            _taskForDisconnection = new TaskCompletionSource<bool>();
            BluetoothAvrcpControlImpl.Instance.Disconnect(_remoteAddress);
            return _taskForDisconnection.Task;
        }

        /// <summary>
        /// A property for the equalizer mode of target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the repeat mode state to the remote device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public EqualizerState EqualizerState
        {
            get
            {
                return BluetoothAvrcpControlImpl.Instance.GetEqualizerState();
            }
            set
            {
                BluetoothAvrcpControlImpl.Instance.SetEqualizerState(value);
            }
        }

        /// <summary>
        /// A property for the repeat mode of target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the repeat mode state to the remote device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public RepeatMode RepeatMode
        {
            get
            {
                return BluetoothAvrcpControlImpl.Instance.GetRepeatMode();
            }
            set
            {
                BluetoothAvrcpControlImpl.Instance.SetRepeatMode(value);
            }
        }

        /// <summary>
        /// A property for the suffle mode of target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if retrieving scan mode of the remote device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public ShuffleMode ShuffleMode
        {
            get
            {
                return BluetoothAvrcpControlImpl.Instance.GetShuffleMode();
            }
            set
            {
                BluetoothAvrcpControlImpl.Instance.SetShuffleMode(value);
            }
        }

        /// <summary>
        /// A property for the scan mode of target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if retrieving scan mode of the remote device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public ScanMode ScanMode
        {
            get
            {
                return BluetoothAvrcpControlImpl.Instance.GetScanMode();
            }
            set
            {
                BluetoothAvrcpControlImpl.Instance.SetScanMode(value);
            }
        }

        /// <summary>
        /// Gets position of the track being played on the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <returns> Play position of the track being played on the target device </returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if there is an error retrieving the position of the track that is currently being played.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public uint GetPosition()
        {
            return BluetoothAvrcpControlImpl.Instance.GetPosition();
        }

        /// <summary>
        /// Gets player state of the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <returns> Play status of the target device </returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if there happens to be an error while retrieving the player state of the target device.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public PlayerState GetPlayStatus()
        {
            return BluetoothAvrcpControlImpl.Instance.GetPlayStatus();
        }

        /// <summary>
        /// Gets info of the track being played on the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <returns> Info of the track being played on the target device </returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if there happens to be an error while retrieving info of the track being played on the target.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public Track GetTrackInfo()
        {
            return BluetoothAvrcpControlImpl.Instance.GetTrackInfo();
        }

        /// <summary>
        /// Sends a particular play command to the target device
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="command">Command to be sent</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when sending command to the target device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public void SendPlayerCommand(PlayerCommand command)
        {
            BluetoothAvrcpControlImpl.Instance.SendPlayerCommand(command);
        }

        /// <summary>
        /// Sends a play command to a particular target device
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="command">Command to be sent</param>
        /// <param name="remoteAddress">Address of the device to send command</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when sending command to the target device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendPlayerCommandTo(PlayerCommand command, string remoteAddress)
        {
            BluetoothAvrcpControlImpl.Instance.SendPlayerCommandTo(command, remoteAddress);
        }

        /// <summary>
        /// Sets absolute volume of target device
        /// </summary>
        /// <remarks>
        /// The remote device must be connected
        /// </remarks>
        /// <param name="volume">The volume level to be set</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when setting absolute volume of the target device fails
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAbsoluteVolume(uint volume)
        {
            BluetoothAvrcpControlImpl.Instance.SetAbsoluteVolume(volume);
        }

        /// <summary>
        /// Increases volume of target device
        /// </summary>
        /// <remarks>
        /// The remote device must be connected
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when increasing volume of the target device fails
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void IncreaseVolume()
        {
            BluetoothAvrcpControlImpl.Instance.IncreaseVolume();
        }

        /// <summary>
        /// Decreases volume of target device
        /// </summary>
        /// <remarks>
        /// The remote device must be connected
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when decreasing volume of the target device fails
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DecreaseVolume()
        {
            BluetoothAvrcpControlImpl.Instance.DecreaseVolume();
        }

        /// <summary>
        /// Sends delay report to the target device
        /// </summary>
        /// <remarks>
        /// The remote device must be connected
        /// </remarks>
        /// <param name="delay">Delay to be sent to target</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when sending delay to the target device fails
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendDelayReport(uint delay)
        {
            BluetoothAvrcpControlImpl.Instance.SendDelayReport(delay);
        }

        ~BluetoothAvrcpControl()
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
                ConnectionStateChanged -= OnConnectionChanged;
            }
            //Free unmanaged objects.
            disposed = true;
        }
    }
}
