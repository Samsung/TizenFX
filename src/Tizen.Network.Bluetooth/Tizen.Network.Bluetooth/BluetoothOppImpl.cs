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
        private static readonly Lazy<BluetoothOppServerImpl> _instance = new Lazy<BluetoothOppServerImpl>(() =>
        {
            return new BluetoothOppServerImpl();
        });

        internal event EventHandler<ConnectionRequestedEventArgs> ConnectionRequested;
        private Interop.Bluetooth.ConnectionRequestedCallback _ConnectionRequestedCallback;

        internal event EventHandler<TransferProgressEventArgs> TransferProgress;
        private Interop.Bluetooth.TransferProgressCallback _TransferProgressCallback;

        internal event EventHandler<TransferFinishedEventArgs> TransferFinished;
        private Interop.Bluetooth.TransferFinishedCallback _TransferFinishedCallback;

        internal int StartServer(string filePath)
        {
            _ConnectionRequestedCallback = (string devAddress, IntPtr userData) =>
            {
                ConnectionRequested?.Invoke(this, new ConnectionRequestedEventArgs(devAddress));
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
                    TransferProgress?.Invoke(this, new TransferProgressEventArgs(file, size, percent));
                };

                _TransferFinishedCallback = (int result, string file, long size, IntPtr userData) =>
                {
                    TransferFinished?.Invoke(this, new TransferFinishedEventArgs(result, file, size));
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
                return _instance.Value;
            }
        }
    }

    internal class BluetoothOppClientImpl
    {
        private static readonly Lazy<BluetoothOppClientImpl> _instance = new Lazy<BluetoothOppClientImpl>(() =>
        {
            return new BluetoothOppClientImpl();
        });

        internal event EventHandler<PushRespondedEventArgs> PushResponded;
        private Interop.Bluetooth.PushRespondedCallback _PushRespondedCallback;

        internal event EventHandler<PushProgressEventArgs> PushProgress;
        private Interop.Bluetooth.PushProgressCallback _PushProgressCallback;

        internal event EventHandler<PushFinishedEventArgs> PushFinished;
        private Interop.Bluetooth.PushFinishedCallback _PushFinishedCallback;

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
                    PushResponded?.Invoke(this, new PushRespondedEventArgs(result, address));
                };

                _PushProgressCallback = (string file, long size, int percent, IntPtr userData) =>
                {
                    PushProgress?.Invoke(this, new PushProgressEventArgs(file, size, percent));
                };

                _PushFinishedCallback = (int result, string address, IntPtr userData) =>
                {
                    PushFinished?.Invoke(this, new PushFinishedEventArgs(result, address));
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
                return _instance.Value;
            }
        }
    }
}

