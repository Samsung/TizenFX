using System;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// A class which is used to handle the connection to Bluetooth HID like keyboards and mouse.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothHid : BluetoothProfile
    {
        internal BluetoothHid()
        {
        }

        /// <summary>
        /// The HidConnectionStateChanged event is called when the HID host connection state is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<HidConnectionStateChangedEventArgs> HidConnectionStateChanged
        {
            add
            {
                BluetoothHidImpl.Instance.HidConnectionStateChanged += value;
            }
            remove
            {
                BluetoothHidImpl.Instance.HidConnectionStateChanged -= value;
            }
        }

        /// <summary>
        /// Connects the remote device with the HID service.
        /// </summary>
        /// <remarks>
        /// The device must be bonded with the remote device by CreateBond().
        /// If connection request succeeds, the HidConnectionStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the connection attempt to the remote device fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Connect()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothHidImpl.Instance.Connect(RemoteAddress);
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
        /// Disconnects the remote device with the HID service.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the disconnection attempt to the remote device fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Disconnect()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothHidImpl.Instance.Disconnect(RemoteAddress);
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
        /// The HidDeviceConnectionStateChanged event is called when the HID device connection state is changed.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<HidDeviceConnectionStateChangedEventArgs> HidDeviceConnectionStateChanged
        {
            add
            {
                BluetoothHidImpl.Instance.HidDeviceConnectionStateChanged += value;
            }
            remove
            {
                BluetoothHidImpl.Instance.HidDeviceConnectionStateChanged -= value;
            }
        }

        /// <summary>
        /// Activates the Bluetooth HID Device role.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void ActivateDevice()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothHidImpl.Instance.ActivateDevice();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to ActivateDevice - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
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
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void DeactivateDevice()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothHidImpl.Instance.DeactivateDevice();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to DeactivateDevice - " + (BluetoothError)ret);
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

