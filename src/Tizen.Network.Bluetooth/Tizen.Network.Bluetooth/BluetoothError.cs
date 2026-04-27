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
        internal static void ThrowBluetoothException(int exception) =>
            throw CreateBluetoothException(exception);

        /// <summary>
        /// Creates Bluetooth Exception.
        /// </summary>
        internal static Exception CreateBluetoothException(int exception) =>
            (BluetoothError)exception switch
            {
                BluetoothError.InvalidParameter         => new InvalidOperationException("Invalid parameter"),
                BluetoothError.Cancelled                => new InvalidOperationException("Operation cancelled"),
                BluetoothError.AlreadyDone              => new InvalidOperationException("Operation already done"),
                BluetoothError.TimedOut                 => new InvalidOperationException("Timeout error"),
                BluetoothError.AuthFailed               => new InvalidOperationException("Authentication failed"),
                BluetoothError.AuthRejected             => new InvalidOperationException("Authentication rejected"),
                BluetoothError.NoData                   => new InvalidOperationException("No data available"),
                BluetoothError.NotEnabled               => new InvalidOperationException("Local adapter not enabled"),
                BluetoothError.NotInitialized           => new InvalidOperationException("Local adapter not initialized"),
                BluetoothError.NowInProgress            => new InvalidOperationException("Operation now in progress"),
                BluetoothError.NotInProgress            => new InvalidOperationException("Operation not in progress"),
                BluetoothError.NotSupported             => new NotSupportedException("Bluetooth is not supported"),
                BluetoothError.OperationFailed          => new InvalidOperationException("Operation failed"),
                BluetoothError.OutOfMemory              => new InvalidOperationException("Out of memory"),
                BluetoothError.PermissionDenied         => new InvalidOperationException("Permission denied"),
                BluetoothError.QuotaExceeded            => new InvalidOperationException("Quota exceeded"),
                BluetoothError.RemoteDeviceNotBonded    => new InvalidOperationException("Remote device not bonded"),
                BluetoothError.RemoteDeviceNotConnected => new InvalidOperationException("Remote device not connected"),
                BluetoothError.RemoteDeviceNotFound     => new InvalidOperationException("Remote device not found"),
                BluetoothError.ResourceBusy             => new InvalidOperationException("Device or resource busy"),
                BluetoothError.ResourceUnavailable      => new InvalidOperationException("Resource temporarily unavailable"),
                BluetoothError.ServiceNotFound          => new InvalidOperationException("Service Not Found"),
                BluetoothError.ServiceSearchFailed      => new InvalidOperationException("Service search failed"),
                _                                       => new InvalidOperationException("Unknown exception"),
            };
    }
}

