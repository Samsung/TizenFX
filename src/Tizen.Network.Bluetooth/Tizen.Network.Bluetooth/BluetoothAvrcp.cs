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
    /// A class which is used to notify changes of the target device(e.g.media player) to the control device(e.g.headset).
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    public class BluetoothAvrcp : BluetoothProfile
    {
        internal BluetoothAvrcp()
        {
        }

        /// <summary>
        /// (event) TargetConnectionStateChanged is invoked when the connection state is changed.
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
        /// (event) EqualizerStateChanged is invoked when the equalizer state is changed by the remote control device.
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
        /// (event) RepeatModeChanged is invoked when the repeat mode is changed by the remote control device.
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
        /// (event) ShuffleModeChanged is invoked when the shuffle mode is changed by the remote control device.
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
        /// (event) ScanModeChanged is invoked when the scan mode is changed by the remote control device.
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
        /// <param name="state">Equalizer state.</param>
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
        /// <param name="mode">Repeat mode.</param>
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
        /// <param name="mode">Shuffle mode.</param>
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
        /// <param name="mode">Scan mode.</param>
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
        /// <param name="state">Player state.</param>
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
        /// Notifies the current position of song to the remote device.
        /// </summary>
        /// <remarks>
        /// The remote device must be connected.
        /// </remarks>
        /// <param name="position">Current position in milliseconds.</param>
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
        /// <param name="trackData">Data of the track.</param>
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

