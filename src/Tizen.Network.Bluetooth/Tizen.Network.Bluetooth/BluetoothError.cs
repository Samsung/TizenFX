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
    /// A class which is used to Throw the Bluetooth Error exceptions.
    /// </summary>
    static internal class BluetoothErrorFactory
    {
        /// <summary>
        /// Exceptions for Bluetooth Errors.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth Error happens.</exception>
        static internal void ThrowBluetoothException(int exception)
        {
            BluetoothError error = (BluetoothError)exception;
            switch (error)
            {
            case BluetoothError.InvalidParameter:
                throw new InvalidOperationException("Invalid parameter");

            case BluetoothError.Cancelled:
                throw new InvalidOperationException("Operation cancelled");

            case BluetoothError.AlreadyDone:
                throw new InvalidOperationException("Operation already done");

            case BluetoothError.TimedOut:
                throw new InvalidOperationException("Timeout error");

            case BluetoothError.AuthFailed:
                throw new InvalidOperationException("Authentication failed");

            case BluetoothError.AuthRejected:
                throw new InvalidOperationException("Authentication rejected");

            case BluetoothError.NoData:
                throw new InvalidOperationException("No data available");

            case BluetoothError.NotEnabled:
                throw new InvalidOperationException("Local adapter not enabled");

            case BluetoothError.NotInitialized:
                throw new InvalidOperationException("Local adapter not initialized");

            case BluetoothError.NowInProgress:
                throw new InvalidOperationException("Operation now in progress");

            case BluetoothError.NotInProgress:
                throw new InvalidOperationException("Operation not in progress");

            case BluetoothError.NotSupported:
                throw new NotSupportedException("Bluetooth is not supported");

            case BluetoothError.OperationFailed:
                throw new InvalidOperationException("Operation failed");

            case BluetoothError.OutOfMemory:
                throw new InvalidOperationException("Out of memory");

            case BluetoothError.PermissionDenied:
                throw new InvalidOperationException("Permission denied");

            case BluetoothError.QuotaExceeded:
                throw new InvalidOperationException("Quota exceeded");

            case BluetoothError.RemoteDeviceNotBonded:
                throw new InvalidOperationException("Remote device not bonded");

            case BluetoothError.RemoteDeviceNotConnected:
                throw new InvalidOperationException("Remote device not connected");

            case BluetoothError.RemoteDeviceNotFound:
                throw new InvalidOperationException("Remote device not found");

            case BluetoothError.ResourceBusy:
                throw new InvalidOperationException("Device or resource busy");

            case BluetoothError.ResourceUnavailable:
                throw new InvalidOperationException("Resource temporarily unavailable");

            case BluetoothError.ServiceNotFound:
                throw new InvalidOperationException("Service Not Found");

            case BluetoothError.ServiceSearchFailed:
                throw new InvalidOperationException("Service search failed");

            default:
                throw new InvalidOperationException("Unknown exception");
            }
        }

        /// <summary>
        /// Creates Bluetooth Exception.
        /// </summary>
        internal static Exception CreateBluetoothException(int exception)
        {
            BluetoothError error = (BluetoothError)exception;
            switch (error)
            {
                case BluetoothError.InvalidParameter:
                    return new InvalidOperationException("Invalid parameter");

                case BluetoothError.Cancelled:
                    return new InvalidOperationException("Operation cancelled");

                case BluetoothError.AlreadyDone:
                    return new InvalidOperationException("Operation already done");

                case BluetoothError.TimedOut:
                    return new InvalidOperationException("Timeout error");

                case BluetoothError.AuthFailed:
                    return new InvalidOperationException("Authentication failed");

                case BluetoothError.AuthRejected:
                    return new InvalidOperationException("Authentication rejected");

                case BluetoothError.NoData:
                    return new InvalidOperationException("No data available");

                case BluetoothError.NotEnabled:
                    return new InvalidOperationException("Local adapter not enabled");

                case BluetoothError.NotInitialized:
                    return new InvalidOperationException("Local adapter not initialized");

                case BluetoothError.NowInProgress:
                    return new InvalidOperationException("Operation now in progress");

                case BluetoothError.NotInProgress:
                    return new InvalidOperationException("Operation not in progress");

                case BluetoothError.NotSupported:
                    return new NotSupportedException("Bluetooth is not supported");

                case BluetoothError.OperationFailed:
                    return new InvalidOperationException("Operation failed");

                case BluetoothError.OutOfMemory:
                    return new InvalidOperationException("Out of memory");

                case BluetoothError.PermissionDenied:
                    return new InvalidOperationException("Permission denied");

                case BluetoothError.QuotaExceeded:
                    return new InvalidOperationException("Quota exceeded");

                case BluetoothError.RemoteDeviceNotBonded:
                    return new InvalidOperationException("Remote device not bonded");

                case BluetoothError.RemoteDeviceNotConnected:
                    return new InvalidOperationException("Remote device not connected");

                case BluetoothError.RemoteDeviceNotFound:
                    return new InvalidOperationException("Remote device not found");

                case BluetoothError.ResourceBusy:
                    return new InvalidOperationException("Device or resource busy");

                case BluetoothError.ResourceUnavailable:
                    return new InvalidOperationException("Resource temporarily unavailable");

                case BluetoothError.ServiceNotFound:
                    return new InvalidOperationException("Service Not Found");

                case BluetoothError.ServiceSearchFailed:
                    return new InvalidOperationException("Service search failed");

                default:
                    return new InvalidOperationException("Unknown exception");
            }
        }
    }
}

