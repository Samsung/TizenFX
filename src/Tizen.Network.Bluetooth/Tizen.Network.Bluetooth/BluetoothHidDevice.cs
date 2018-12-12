/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// A class which is used to provide the HID Device role.
    /// </summary>
    /// <remarks>
    /// In HID profile, there are two roles Host and Device.
    /// The Host(BluetoothHid) is a device that uses or requests the service of a HID.
    /// The Device(BluetoothHidDevice) is a device that provides the service of human data input/output to/from the host.
    /// </remarks>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BluetoothHidDevice : BluetoothProfile
    {
        private TaskCompletionSource<BluetoothError> _taskForConnection;
        private TaskCompletionSource<BluetoothError> _taskForDisconnection;

        internal BluetoothHidDevice()
        {
            BluetoothHidDeviceImpl.Instance.ConnectionStateChanged += (s, e) =>
            {
                if (e.Address == RemoteAddress)
                {
                    if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
                    {
                        _taskForConnection.SetResult((BluetoothError)e.Result);
                    }

                    if (_taskForDisconnection != null && _taskForDisconnection.Task.IsCompleted)
                    {
                        _taskForDisconnection.SetResult((BluetoothError)e.Result);
                    }

                    if (e.Result == (int)BluetoothError.None)
                    {
                        /* User does not need 'Result' in HidDeviceConnectionStateChangedEventArgs */
                        ConnectionStateChanged?.Invoke(null, new HidDeviceConnectionStateChangedEventArgs(e.IsConnected, e.Address));
                    }
                }
            };

            BluetoothHidDeviceImpl.Instance.DataReceived += (s, e) =>
            {
                if (e.ReceivedData.Address == RemoteAddress)
                {
                    DataReceived?.Invoke(this, e);
                }
            };
        }

        /// <summary>
        /// The ConnectionStateChanged event is called when the HID device connection state is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<HidDeviceConnectionStateChangedEventArgs> ConnectionStateChanged;

        /// <summary>
        /// Connects to the remote device asynchronously.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns> A task indicating whether the method is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.bluetooth.hid_device</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        public Task<BluetoothError> ConnectAsync()
        {
            _taskForConnection = new TaskCompletionSource<BluetoothError>();
            if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }

            int ret = BluetoothHidDeviceImpl.Instance.ConnectHidDevice(RemoteAddress);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect to the remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return _taskForConnection.Task;
        }

        /// <summary>
        /// Disconnects to the remote device asynchronously.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns> A task indicating whether the method is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.bluetooth.hid_device</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        public Task<BluetoothError> DisconnectAsync()
        {
            _taskForDisconnection = new TaskCompletionSource<BluetoothError>();
            if (_taskForDisconnection != null && !_taskForDisconnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }

            int ret = BluetoothHidDeviceImpl.Instance.DisconnectHidDevice(RemoteAddress);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect to the remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return _taskForDisconnection.Task;
        }

        /// <summary>
        /// Sends the mouse event data to the remote device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="mouseData">The mouse data to be passed to the remote device.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.bluetooth.hid_device</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        public void SendMouseEvent(BluetoothHidMouseData mouseData)
        {
            BluetoothHidDeviceImpl.Instance.SendHidDeviceMouseEvent(RemoteAddress, mouseData);
        }

        /// <summary>
        /// Sends the key event data to the remote device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="keyData">The key data to be passed to the remote device.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.bluetooth.hid_device</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        public void SendKeyEvent(BluetoothHidKeyData keyData)
        {
            BluetoothHidDeviceImpl.Instance.SendHidDeviceKeyEvent(RemoteAddress, keyData);
        }

        /// <summary>
        /// The DataReceived event is called when the device receives data from the HID Host.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.bluetooth.hid_device</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        public event EventHandler<HidDeviceDataReceivedEventArgs> DataReceived;

        /// <summary>
        /// Replies to reports from the HID Host.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="headerType">The header type to be there in response.</param>
        /// <param name="paramType">The Parameter type to be there in response.</param>
        /// <param name="data">Data to be present in data payload of response.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.bluetooth.hid_device</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        public void ReplyToReport(BluetoothHidHeaderType headerType, BluetoothHidParamType paramType, byte[] data)
        {
            BluetoothHidDeviceImpl.Instance.ReplyToReportHidDevice(RemoteAddress, headerType, paramType, data);
        }
    }
}

