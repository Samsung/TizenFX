using System;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// A class which is used to handle the connection to Bluetooth HID like keyboards and mouse.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    public class BluetoothHid : BluetoothProfile
    {
        internal BluetoothHid()
        {
        }

        /// <summary>
        /// (event) HidConnectionStateChanged is called when hid host connection state is changed.
        /// </summary>
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
        /// Connect the remote device with the Hid service.
        /// </summary>
        /// <remarks>
        /// The device must be bonded with remote device by CreateBond().
        /// If connection request succeeds, HidConnectionStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or when connection attempt to remote device fails.</exception>
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
        /// Disconnects the remote device with the Hid service.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bluetooth is not Enabled
        /// or when disconnection attempt to remote device fails.</exception>
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
    }
}

