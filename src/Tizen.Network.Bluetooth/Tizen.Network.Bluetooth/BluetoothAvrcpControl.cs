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
        }

        private void OnConnectionChanged(object s, AvrcpControlConnChangedEventArgs e)
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
                    ConnStateChanged?.Invoke(this, e);
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
                    ConnStateChanged?.Invoke(this, e);
                }
                else
                {
                    _taskForDisconnection.SetException(BluetoothErrorFactory.CreateBluetoothException((int)BluetoothError.OperationFailed));
                }
                _taskForDisconnection = null;
            }
        }

        /// <summary>
        /// The AvrcpControlConnChangedEventArgs event is invoked when the connection status of device is changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<AvrcpControlConnChangedEventArgs> ConnStateChanged;

        /// <summary>
        /// The PositionChangedEventArgs event is invoked when the play position of a track is changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<PositionChangedEventArgs> PositionChanged
        {
            add
            {
                BluetoothAvrcpControlImpl.Instance.PositionChanged += value;
            }
            remove
            {
                BluetoothAvrcpControlImpl.Instance.PositionChanged -= value;
            }
        }

        /// <summary>
        /// The PlayStateChangedEventArgs event is invoked when the play state of a track gets changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<PlayStateChangedEventArgs> PlayStateChanged
        {
            add
            {
                BluetoothAvrcpControlImpl.Instance.PlayStateChanged += value;
            }
            remove
            {
                BluetoothAvrcpControlImpl.Instance.PlayStateChanged -= value;
            }
        }

        /// <summary>
        /// The TrackInfoChangedEventArgs event is invoked when info of a track gets changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<TrackInfoChangedEventArgs> TrackInfoChanged
        {
            add
            {
                BluetoothAvrcpControlImpl.Instance.TrackInfoChanged += value;
            }
            remove
            {
                BluetoothAvrcpControlImpl.Instance.TrackInfoChanged -= value;
            }
        }

        /// <summary>
        /// Asynchronously connects the remote device
        /// </summary>
        /// <param name="remote_address">Address of device to be connected</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails</exception>
        /// <since_tizen> 8 </since_tizen>
        public Task ConnectAsync(string remote_address)
        {
            if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }

            _taskForConnection = new TaskCompletionSource<bool>();
            _remoteAddress = remote_address;
            BluetoothAvrcpControlImpl.Instance.Connect(remote_address);
            return _taskForConnection.Task;
        }

        /// <summary>
        /// Asynchronously disconnects the remote device
        /// </summary>
        /// <param name="remote_address">Address of device to be disconnected</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails</exception>
        /// <since_tizen> 8 </since_tizen>
        public Task DisconnectAsync(string remote_address)
        {
            if (_taskForDisconnection != null && !_taskForDisconnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }
            _taskForDisconnection = new TaskCompletionSource<bool>();
            _remoteAddress = remote_address;
            BluetoothAvrcpControlImpl.Instance.Disconnect(remote_address);
            return _taskForDisconnection.Task;
        }

        /// <summary>
        /// Sets equalizer state of the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="state">The equalizer state.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when setting the equalizer state of the target device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public void SetEqualizerState(EqualizerState state)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SetEqualizerState(state);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Gets equalizer state of the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="state">The equalizer state.</param>
        /// <returns> Equalizer state of the target device </returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when retrieving the equalizer state of the target device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public EqualizerState GetEqualizerState()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetEqualizerState();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
                return EqualizerState.Off;
            }
        }

        /// <summary>
        /// Sets repeat mode of the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="mode">The equalizer state.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the repeat mode state to the remote device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public void SetRepeatMode(RepeatMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SetRepeatMode(mode);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Gets repeat mode of the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <returns> Repeat mode of the target device </returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the repeat mode state to the remote device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public RepeatMode GetRepeatMode()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetRepeatMode();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return RepeatMode.Off;
        }

        /// <summary>
        /// Sets shuffle mode of the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="mode">Shuffle mode to be set</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when setting shuffle mode of the target device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public void SetShuffleMode(ShuffleMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SetShuffleMode(mode);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Gets shuffle mode of the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <returns> Shuffle mode of the target device </returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if retrieving shuffle mode of the target device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public ShuffleMode GetShuffleMode()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetShuffleMode();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return ShuffleMode.Off;
        }

        /// <summary>
        /// Sets scan mode of the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="mode">The scan mode.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when setting the scan mode of the target device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public void SetScanMode(ScanMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SetScanMode(mode);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Gets scan mode of the target device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <returns> Scan mode of the target device </returns>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or if retrieving scan mode of the remote device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public ScanMode GetScanMode()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetScanMode();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return ScanMode.Off;
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
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetPosition();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return 0;
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
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetPlayStatus();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return PlayerState.Stopped;
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
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetTrackInfo();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return null;
        }
        public void FreeTrackInfo(Track trackData) //needs special testing
        {

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
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SendPlayerCommand(command);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Sends a play command to a particular target device
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="command">Command to be sent</param>
        /// <param name="remote_address">Address of the device to send command</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when sending command to the target device fails.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public void SendPlayerCommandTo(PlayerCommand command, string remote_address)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SendPlayerCommandTo(command, remote_address);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
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
        public void SetAbsoluteVolume(uint volume)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                Interop.Bluetooth.SetAbsoluteVolume(volume);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
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
        public void IncreaseVolume()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                Interop.Bluetooth.IncreaseVolume();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
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
        public void DecreaseVolume()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                Interop.Bluetooth.DecreaseVolume();
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
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
        public void SendDelayReport(uint delay)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                Interop.Bluetooth.SendDelayReport(delay);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
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
                ConnStateChanged -= OnConnectionChanged;
            }
            //Free unmanaged objects.
            disposed = true;
        }
    }
}
