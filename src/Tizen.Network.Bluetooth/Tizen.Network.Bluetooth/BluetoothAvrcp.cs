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
    /// <summary>
    /// This class is used to notify changes of the target device (For example, media player) to the control device (For example, headset).
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    public class BluetoothAvrcp : BluetoothProfile
    {
        internal BluetoothAvrcp()
        {
        }

        /// <summary>
        /// The TargetConnectionStateChanged event is invoked when the connection state is changed.
        /// </summary>
        public event EventHandler<TargetConnectionStateChangedEventArgs> TargetConnectionStateChanged
        {
            add
            {
                BluetoothAvrcpImpl.Instance.TargetConnectionStateChanged += value;
            }
            remove
            {
                BluetoothAvrcpImpl.Instance.TargetConnectionStateChanged -= value;
            }
        }

        /// <summary>
        /// The EqualizerStateChanged event is invoked when the equalizer state is changed by the remote control device.
        /// </summary>
        public event EventHandler<EqualizerStateChangedEventArgs> EqualizerStateChanged
        {
            add
            {
                BluetoothAvrcpImpl.Instance.EqualizerStateChanged += value;
            }
            remove
            {
                BluetoothAvrcpImpl.Instance.EqualizerStateChanged -= value;
            }
        }

        /// <summary>
        /// The RepeatModeChanged event is invoked when the repeat mode is changed by the remote control device.
        /// </summary>
        public event EventHandler<RepeatModeChangedEventArgs> RepeatModeChanged
        {
            add
            {
                BluetoothAvrcpImpl.Instance.RepeatModeChanged += value;
            }
            remove
            {
                BluetoothAvrcpImpl.Instance.RepeatModeChanged -= value;
            }
        }

        /// <summary>
        /// The ShuffleModeChanged event is invoked when the shuffle mode is changed by the remote control device.
        /// </summary>
        public event EventHandler<ShuffleModeChangedeventArgs> ShuffleModeChanged
        {
            add
            {
                BluetoothAvrcpImpl.Instance.ShuffleModeChanged += value;
            }
            remove
            {
                BluetoothAvrcpImpl.Instance.ShuffleModeChanged -= value;
            }
        }

        /// <summary>
        /// The ScanModeChanged event is invoked when the scan mode is changed by the remote control device.
        /// </summary>
        public event EventHandler<ScanModeChangedEventArgs> ScanModeChanged
        {
            add
            {
                BluetoothAvrcpImpl.Instance.ScanModeChanged += value;
            }
            remove
            {
                BluetoothAvrcpImpl.Instance.ScanModeChanged -= value;
            }
        }

        /// <summary>
        /// Notifies the equalize state to the remote device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="state">The equalizer state.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the equalizer state to the remote device fails.</exception>
        public void NotifyEqualizerState(EqualizerState state)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpImpl.Instance.NotifyEqualizeState(state);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Notifies the repeat mode to the remote device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="mode">The repeat mode.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the repeat mode state to the remote device fails.</exception>
        /// </exception>
        public void NotifyRepeatMode(RepeatMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpImpl.Instance.NotifyRepeatMode(mode);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Notifies the shuffle mode to the remote device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="mode">The shuffle mode.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the shuffle mode state to the remote device fails.</exception>
        public void NotifyShuffleMode(ShuffleMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpImpl.Instance.NotifyShuffleMode(mode);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Notifies the scan mode to the remote device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="mode">The scan mode.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the scan mode state to the remote device fails.</exception>
        public void NotifyScanMode(ScanMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpImpl.Instance.NotifyScanMode(mode);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Notifies the player state to the remote device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="state">The player state.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the player state to the remote device fails.</exception>
        public void NotifyPlayerState(PlayerState state)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpImpl.Instance.NotifyPlayerState(state);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Notifies the current position of the song to the remote device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="position">The current position in milliseconds.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the current position state to the remote device fails.</exception>
        public void NotifyCurrentPosition(uint position)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpImpl.Instance.NotifyCurrentPosition(position);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Notifies the track to the remote device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="trackData">The data of the track.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when notifying the shuffle track state to the remote device fails.</exception>
        public void NotifyTrack(Track trackData)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpImpl.Instance.NotifyTrack(trackData);
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
    }
}

