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
    internal class BluetoothOppServerImpl
    {
        private event EventHandler<ConnectionRequestedEventArgs> _ConnectionRequested;
        private Interop.Bluetooth.ConnectionRequestedCallback _ConnectionRequestedCallback;

        private event EventHandler<TransferProgressEventArgs> _TransferProgress;
        private Interop.Bluetooth.TransferProgressCallback _TransferProgressCallback;

        private event EventHandler<TransferFinishedEventArgs> _TransferFinished;
        private Interop.Bluetooth.TransferFinishedCallback _TransferFinishedCallback;

        private static readonly BluetoothOppServerImpl _instance = new BluetoothOppServerImpl();

        internal event EventHandler<ConnectionRequestedEventArgs> ConnectionRequested
        {
            add
            {
                _ConnectionRequested += value;
            }
            remove
            {
                _ConnectionRequested -= value;
            }
        }

        internal event EventHandler<TransferProgressEventArgs> TransferProgress
        {
            add
            {
                _TransferProgress += value;
            }
            remove
            {
                _TransferProgress -= value;
            }
        }

        internal event EventHandler<TransferFinishedEventArgs> TransferFinished
        {
            add
            {
                _TransferFinished += value;
            }
            remove
            {
                _TransferFinished -= value;
            }
        }

        internal int StartServer(string filePath)
        {
            _ConnectionRequestedCallback = (string devAddress, IntPtr userData) =>
            {
                _ConnectionRequested?.Invoke(null, new ConnectionRequestedEventArgs(devAddress));
            };

            int ret = Interop.Bluetooth.InitializeOppServerCustom(filePath, _ConnectionRequestedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to start bluetooth opp server, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            else
            {
                Globals.IsOppServerInitialized = true;
            }
            return ret;
        }

        internal int StopServer()
        {
            if (Globals.IsOppServerInitialized)
            {
                int ret = Interop.Bluetooth.DinitializeOppServer();
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to stop bluetooth opp server, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal int AcceptPush(string name, out int _transferId)
        {
            _transferId = -1;
            if (Globals.IsOppServerInitialized)
            {
                _TransferProgressCallback = (string file, long size, int percent, IntPtr userData) =>
                {
                    _TransferProgress?.Invoke(null, new TransferProgressEventArgs(file, size, percent));
                };

                _TransferFinishedCallback = (int result, string file, long size, IntPtr userData) =>
                {
                    _TransferFinished?.Invoke(null, new TransferFinishedEventArgs(result, file, size));
                };

                int ret = Interop.Bluetooth.OppServerAcceptPush(_TransferProgressCallback, _TransferFinishedCallback, name, IntPtr.Zero, out _transferId);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to accept the push request, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal int RejectPush()
        {
            if (Globals.IsOppServerInitialized)
            {
                int ret = Interop.Bluetooth.OppServerRejectPush();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to reject the push request, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal int CancelTransferId(int TransferId)
        {
            if (Globals.IsOppServerInitialized)
            {
                int ret = Interop.Bluetooth.OppServerCancelTransfer(TransferId);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to cancel the transferid " + TransferId + " Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal int SetDestinationPath(string path)
        {
            if (Globals.IsOppServerInitialized)
            {
                int ret = Interop.Bluetooth.OppServerSetDestinationPath(path);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Set the desitination path " + path + " Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal static BluetoothOppServerImpl Instance
        {
            get
            {
                return _instance;
            }
        }
    }

    internal class BluetoothOppClientImpl
    {
        private event EventHandler<PushRespondedEventArgs> _PushResponded;
        private Interop.Bluetooth.PushRespondedCallback _PushRespondedCallback;

        private event EventHandler<PushProgressEventArgs> _PushProgress;
        private Interop.Bluetooth.PushProgressCallback _PushProgressCallback;

        private event EventHandler<PushFinishedEventArgs> _PushFinished;
        private Interop.Bluetooth.PushFinishedCallback _PushFinishedCallback;

        private static readonly BluetoothOppClientImpl _instance = new BluetoothOppClientImpl();

        internal event EventHandler<PushRespondedEventArgs> PushResponded
        {
            add
            {
                _PushResponded += value;
            }
            remove
            {
                _PushResponded -= value;
            }
        }

        internal event EventHandler<PushProgressEventArgs> PushProgress
        {
            add
            {
                _PushProgress += value;
            }
            remove
            {
                _PushProgress -= value;
            }
        }

        internal event EventHandler<PushFinishedEventArgs> PushFinished
        {
            add
            {
                _PushFinished += value;
            }
            remove
            {
                _PushFinished -= value;
            }
        }

        private BluetoothOppClientImpl()
        {
            Log.Info(Globals.LogTag, "Initializing OppClient");
            Initialize();
        }

        ~BluetoothOppClientImpl()
        {
            Deinitialize();
        }

        internal int AddFile(string filePath)
        {

            if (Globals.IsOppClientInitialized)
            {
                int ret = Interop.Bluetooth.OppClientAddFile(filePath);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Add File, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal int ClearFile()
        {

            if (Globals.IsOppClientInitialized)
            {
                int ret = Interop.Bluetooth.OppClientClearFiles();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Clear Files, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal int CancelPush()
        {

            if (Globals.IsOppClientInitialized)
            {
                int ret = Interop.Bluetooth.OppClientCancelPush();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to Clear Files, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal int PushFile(string Destination)
        {

            if (Globals.IsOppClientInitialized)
            {
                _PushRespondedCallback = (int result, string address, IntPtr userData) =>
                {
                    _PushResponded?.Invoke(null, new PushRespondedEventArgs(result, address));
                };

                _PushProgressCallback = (string file, long size, int percent, IntPtr userData) =>
                {
                    _PushProgress?.Invoke(null, new PushProgressEventArgs(file, size, percent));
                };

                _PushFinishedCallback = (int result, string address, IntPtr userData) =>
                {
                    _PushFinished?.Invoke(null, new PushFinishedEventArgs(result, address));
                };

                int ret = Interop.Bluetooth.OppClientPushFile(Destination, _PushRespondedCallback, _PushProgressCallback, _PushFinishedCallback, IntPtr.Zero);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to push File, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        private void Initialize()
        {
            if (Globals.IsInitialize)
            {

                int ret = Interop.Bluetooth.InitializeOppClient();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to initialize bluetooth Opp Client, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
                else
                {
                    Globals.IsOppClientInitialized = true;
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Failed to initialize Opp Client, BT not initialized");
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotInitialized);
            }
        }

        private void Deinitialize()
        {
            if (Globals.IsOppClientInitialized)
            {
                int ret = Interop.Bluetooth.DeinitializeOppClient();
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to deinitialize Opp Client, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
                else
                {
                    Globals.IsOppClientInitialized = false;
                }
            }
        }

        internal static BluetoothOppClientImpl Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}

