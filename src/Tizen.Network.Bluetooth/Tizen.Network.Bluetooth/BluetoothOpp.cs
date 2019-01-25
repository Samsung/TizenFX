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
    /// A class which is used to handle the connection and send and receive the object over Opp profile.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    /// <since_tizen> 4 </since_tizen>
    public class BluetoothOppServer
    {
        private static BluetoothOppServerImpl _impl;
        private static BluetoothOppServer _instance;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public BluetoothOppServer()
        {
            _impl = BluetoothOppServerImpl.Instance;
        }

        /// <summary>
        /// (event) ConnectionRequested is called when OPP client requests for connection.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<ConnectionRequestedEventArgs> ConnectionRequested
        {
            add
            {
                _impl.ConnectionRequested += value;
            }
            remove
            {
                _impl.ConnectionRequested -= value;
            }
        }

        /// <summary>
        /// (event) TransferProgress is called when the file transfer state is changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<TransferProgressEventArgs> TransferProgress
        {
            add
            {
                _impl.TransferProgress += value;
            }
            remove
            {
                _impl.TransferProgress -= value;
            }
        }

        /// <summary>
        /// (event) TransferFinished is called when the file tranfser is completed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<TransferFinishedEventArgs> TransferFinished
        {
            add
            {
                _impl.TransferFinished += value;
            }
            remove
            {
                _impl.TransferFinished -= value;
            }
        }
        /// <summary>
        /// Register the Opp Server with the Opp service.
        /// </summary>
        /// <remarks>
        /// The device must be bonded with remote device by CreateBond().
        /// If connection request is received from OPP Client, ConnectionRequested event will be invoked.
        /// </remarks>
        /// <returns>The BluetoothOppServer instance.</returns>
        /// <param name="FilePath"> Path to store the files.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static BluetoothOppServer StartServer(string FilePath)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                if (_instance == null)
                {
                    BluetoothOppServer server = new BluetoothOppServer();
                    if (server != null)
                        _instance = server;
                }
                int ret = _impl.StartServer(FilePath);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Opp Start Server - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
                return _instance;
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return null;
        }

        /// <summary>
        /// Stops the Opp Server.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void StopServer()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = _impl.StopServer();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Stop the Opp Server - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
                else
                {
                    if (_instance != null)
                        _instance = null;
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Accept File Push request.
        /// </summary>
        /// <returns>The id of transfer.</returns>
        /// <param name="FileName"> File name to accept.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int AcceptPush(string FileName)
        {
            int _transitionId = -1;
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = _impl.AcceptPush(FileName, out _transitionId);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Accept Push - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return _transitionId;
        }

        /// <summary>
        /// Reject File Push request.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void RejectPush()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = _impl.RejectPush();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Reject Push - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Cancel the ongoing transfer session.
        /// </summary>
        /// <param name="TransferId"> tranfer ID.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void CancelTransfer(int TransferId)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = _impl.CancelTransferId(TransferId);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Cancel Transfer - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Cancel the ongoing transfer session.
        /// </summary>
        /// <param name="FilePath"> Path to store the files.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void SetDestinationPath(string FilePath)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = _impl.SetDestinationPath(FilePath);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Set Destination Path - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
    }

    /// <summary>
    /// A class which is used to handle the connection and send and receive the object over Opp profile.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    /// <since_tizen> 4 </since_tizen>
    public class BluetoothOppClient : BluetoothProfile
    {
        internal BluetoothOppClient()
        {
        }

        /// <summary>
        /// (event) PushResponded is called when remote OPP Server responds to a File push request.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<PushRespondedEventArgs> PushResponded
        {
            add
            {
                BluetoothOppClientImpl.Instance.PushResponded += value;
            }
            remove
            {
                BluetoothOppClientImpl.Instance.PushResponded -= value;
            }
        }

        /// <summary>
        /// (event) PushProgress is called when the file transfer state is changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<PushProgressEventArgs> PushProgress
        {
            add
            {
                BluetoothOppClientImpl.Instance.PushProgress += value;
            }
            remove
            {
                BluetoothOppClientImpl.Instance.PushProgress -= value;
            }
        }

        /// <summary>
        /// (event) PushFinished is called when the file tranfser is completed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<PushFinishedEventArgs> PushFinished
        {
            add
            {
                BluetoothOppClientImpl.Instance.PushFinished += value;
            }
            remove
            {
                BluetoothOppClientImpl.Instance.PushFinished -= value;
            }
        }

        /// <summary>
        /// Add File path to be pushed.
        /// </summary>
        /// <param name="FilePath"> file for sending.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void AddFile(string FilePath)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothOppClientImpl.Instance.AddFile(FilePath);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Set File Path - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Clears all the File paths.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void ClearFiles()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothOppClientImpl.Instance.ClearFile();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Clear the Files - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Cancels the ongoing push session.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void CancelPush()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothOppClientImpl.Instance.CancelPush();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Cancel Push Operation - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        /// <summary>
        /// Pushes the file set through AddFile.
        /// </summary>
        /// <param name="Destination"> destination device address.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth.opp</feature>
        /// <exception cref="NotSupportedException">Thrown when the required feature is not Supported.</exception>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not Supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not Enabled or Other Bluetooth Errors.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void PushFile(string Destination)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                int ret = BluetoothOppClientImpl.Instance.PushFile(Destination);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Cancel Push Operation - " + (BluetoothError)ret);
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

