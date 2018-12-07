using System;

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
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    /// <privilege> http://tizen.org/privilege/bluetooth.hid_device </privilege>
    /// <since_tizen> 6 </since_tizen>
    public class BluetoothHidDevice : BluetoothProfile
    {
        private event EventHandler<HidDeviceConnectionStateChangedEventArgs> _hidDeviceConnectionStateChanged;
        private event EventHandler<HidDeviceDataReceivedEventArgs> _hidDeviceDataReceived;

        internal BluetoothHidDevice()
        {
        }

        /// <summary>
        /// The ConnectionStateChanged event is called when the HID device connection state is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<HidDeviceConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                _hidDeviceConnectionStateChanged += value;
            }
            remove
            {
                _hidDeviceConnectionStateChanged -= value;
            }
        }

        /// <summary>
        /// Activates the Bluetooth HID Device role.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.
        /// or when the connection attempt to the remote device fails.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Activate()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                Interop.Bluetooth.HidDeviceConnectionStateChangedCallback _hidDeviceConnectionStateChangedCallback = (int result, bool isConnected, string address, IntPtr userData) =>
                {
                    _hidDeviceConnectionStateChanged?.Invoke(null, new HidDeviceConnectionStateChangedEventArgs(result, isConnected, address));
                };

                int ret = Interop.Bluetooth.ActivateHidDevice(_hidDeviceConnectionStateChangedCallback, IntPtr.Zero);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to activate to the remote device, Error - " + (BluetoothError)ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Deactivates the Bluetooth HID Device role.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.
        /// or when the connection attempt to the remote device fails.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Deactivate()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.DeactivateHidDevice();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to deactivate to the remote device, Error - " + (BluetoothError)ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Connects to the remote device.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.
        /// or when the connection attempt to the remote device fails.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Connect()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.ConnectHidDevice(RemoteAddress);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to connect to the remote device, Error - " + (BluetoothError)ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Disconnects to the remote device.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.
        /// or when the connection attempt to the remote device fails.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Disconnect()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.DisconnectHidDevice(RemoteAddress);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to disconnect to the remote device, Error - " + (BluetoothError)ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Sends the mouse event data to the remote device.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.
        /// or when the connection attempt to the remote device fails.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SendMouseEvent(BluetoothHidMouseData mouseData)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.SendHidDeviceMouseEvent(RemoteAddress, mouseData);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to send mouse event to the remote device, Error - " + (BluetoothError)ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Sends the key event data to the remote device.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.
        /// or when the connection attempt to the remote device fails.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SendKeyEvent(BluetoothHidKeyData keyData)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.SendHidDeviceKeyEvent(RemoteAddress, keyData);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to send key event to the remote device, Error - " + (BluetoothError)ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// The DataReceived event is called when the device receives data from the HID Host.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<HidDeviceDataReceivedEventArgs> DataReceived
        {
            add
            {
                if (_hidDeviceDataReceived == null)
                {
                    RegisterHidDataReceivedEvent();
                }
                _hidDeviceDataReceived += value;
            }
            remove
            {
                _hidDeviceDataReceived -= value;
                if (_hidDeviceDataReceived == null)
                {
                    UnregisterHidDataReceivedEvent();
                }
            }
        }

        private void RegisterHidDataReceivedEvent()
        {
            Interop.Bluetooth.HidDeviceDataReceivedCallback _hidDeviceDataReceivedCallback = (ref BluetoothHidDeviceReceivedDataStruct receivedData, IntPtr userData) =>
            {
                _hidDeviceDataReceived?.Invoke(null, new HidDeviceDataReceivedEventArgs(BluetoothUtils.ConvertStructToBluetoothHidDeviceReceivedData(receivedData)));
            };

            int ret = Interop.Bluetooth.SetHidDeviceDataReceivedCallback(_hidDeviceDataReceivedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set data received callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterHidDataReceivedEvent()
        {
            int ret = Interop.Bluetooth.UnsetHidDeviceDataReceivedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset data received callback, Error - " + (BluetoothError)ret);
            }
        }

        /// <summary>
        /// Replies to reports from the HID Host.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.
        /// <since_tizen> 6 </since_tizen>
        /// or when the connection attempt to the remote device fails.</exception>
        public void ReplyToReport(BluetoothHidHeaderType headerType, BluetoothHidParamType paramType, byte[] data)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = Interop.Bluetooth.ReplyToReportHidDevice(RemoteAddress, headerType, paramType, data, data.Length, IntPtr.Zero);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to reply to report from hid host, Error - " + (BluetoothError)ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
    }
}

