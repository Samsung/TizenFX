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
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothAudio : BluetoothProfile
    {
        internal BluetoothAudio()
        {
        }

        /// <summary>
        /// The AudioConnectionStateChanged event is called when the audio connection state is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// If audio profile type is All and this request succeeds, then the AudioConnectionStateChanged event will be called twice when HspHfp <br/>
        /// and AdvancedAudioDistribution is connected.
        /// </remarks>
        /// <param name="profileType">The type of the audio profile.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the connection attempt fails.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// If audio profile type is All and this request succeeds, then the AudioConnectionStateChanged event will be called twice when HspHfp <br/>
        /// and AdvancedAudioDistribution is disconnected.
        /// </remarks>
        /// <param name="type">The type of the audio profile.</param>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when Disconnection attempt fails.</exception>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Opens a SCO(Synchronous Connection Oriented link) to connected remote device, asynchronously.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void OpenAgSco()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothAudioImpl.Instance.OpenAgSco();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to OpenAgSco - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Closes a SCO(Synchronous Connection Oriented link) to connected remote device, asynchronously.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void CloseAgSco()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothAudioImpl.Instance.CloseAgSco();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to CloseAgSco - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// A property to check whether an opened SCO(Synchronous Connection Oriented link) exists or not.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        static public bool IsAgScoOpened
        {
            get
            {   
                return BluetoothAudioImpl.Instance.IsAgScoOpened;
            }
        }

        /// <summary>
        /// This event is called when the SCO(Synchronous Connection Oriented link) state is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<AgScoStateChangedEventArgs> AgScoStateChanged
        {
            add
            {
                BluetoothAudioImpl.Instance.AgScoStateChanged += value;
            }
            remove
            {
                BluetoothAudioImpl.Instance.AgScoStateChanged -= value;
            }
        }

        /// <summary>
        /// Notifies the state of voice recognition.
        /// </summary>
        /// <param name="state">The state of voice recognition.</param>
        /// <since_tizen> 6 </since_tizen>
        public void NotifyAgVoiceRecognitionState(bool state)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothAudioImpl.Instance.NotifyAgVoiceRecognitionState(state);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to NotifyAgVoiceRecognitionState - " + (BluetoothError)ret);
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
