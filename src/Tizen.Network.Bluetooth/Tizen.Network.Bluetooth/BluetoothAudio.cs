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
    /// This class is used to handle the connection with other Bluetooth audio devices
    /// like headset, hands-free, and headphone.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    public class BluetoothAudio : BluetoothProfile
    {
        internal BluetoothAudio()
        {
        }

        /// <summary>
        /// The AudioConnectionStateChanged event is called when the audio connection state is changed.
        /// </summary>
        public event EventHandler<AudioConnectionStateChangedEventArgs> AudioConnectionStateChanged
        {
            add
            {
                BluetoothAudioImpl.Instance.AudioConnectionStateChanged += value;
            }
            remove
            {
                BluetoothAudioImpl.Instance.AudioConnectionStateChanged -= value;
            }
        }

        /// <summary>
        /// Connects the remote device with the given audio profile.
        /// </summary>
        /// <remarks>
        /// The device must be bonded with the remote device by CreateBond(). If connection request succeeds, the AudioConnectionStateChanged event will be invoked.
        /// If audio profile type is All and this request succeeds, then the AudioConnectionStateChanged event will be called twice when HspHfp <br>
        /// and AdvancedAudioDistribution is connected.
        /// </remarks>
        /// <param name="profileType">The type of the audio profile.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the connection attempt fails.</exception>
        public void Connect(BluetoothAudioProfileType profileType)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothAudioImpl.Instance.Connect(RemoteAddress, profileType);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Connect - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Disconnects the remote device with the given audio profile.
        /// </summary>
        /// <remarks>
        /// The device must be connected by Connect(). If the disconnection request succeeds, the AudioConnectionStateChanged event will be invoked.
        /// If audio profile type is All and this request succeeds, then the AudioConnectionStateChanged event will be called twice when HspHfp <br>
        /// and AdvancedAudioDistribution is disconnected.
        /// </remarks>
        /// <param name="type">The type of the audio profile.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when Disconnection attempt fails.</exception>
        public void Disconnect(BluetoothAudioProfileType type)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothAudioImpl.Instance.Disconnect(RemoteAddress, type);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Disconnect - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
    }
}
