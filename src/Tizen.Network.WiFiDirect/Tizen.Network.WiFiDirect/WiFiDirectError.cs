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

namespace Tizen.Network.WiFiDirect
{
    internal static class WiFiDirectErrorFactory
    {
        internal static void ThrowWiFiDirectException(int exception)
        {
            WiFiDirectError _error = (WiFiDirectError)exception;
            switch (_error)
            {
            case WiFiDirectError.InvalidParameter:
                throw new InvalidOperationException("Invalid parameter");
            case WiFiDirectError.AlreadyInitialized:
                throw new InvalidOperationException("Already initialized");
            case WiFiDirectError.AuthFailed:
                throw new InvalidOperationException("Authentication failed");
            case WiFiDirectError.CommunicationFailed:
                throw new InvalidOperationException("Communication failed");
            case WiFiDirectError.ConnectionCancelled:
                throw new InvalidOperationException("Connection cancelled");
            case WiFiDirectError.ConnectionFailed:
                throw new InvalidOperationException("Connection failed");
            case WiFiDirectError.ConnectionTimeOut:
                throw new InvalidOperationException("Connection timed out");
            case WiFiDirectError.MobileApUsed:
                throw new InvalidOperationException("Mobile Ap is being used");
            case WiFiDirectError.NotInitialized:
                throw new InvalidOperationException("Not initialized");
            case WiFiDirectError.NotPermitted:
                throw new InvalidOperationException("Not permitted");
            case WiFiDirectError.NotSupported:
                throw new NotSupportedException("Not supported");
            case WiFiDirectError.OperationFailed:
                throw new InvalidOperationException("Operation failed");
            case WiFiDirectError.OutOfMemory:
                throw new InvalidOperationException("Out of memory");
            case WiFiDirectError.PermissionDenied:
                throw new InvalidOperationException("Permission denied");
            case WiFiDirectError.ResourceBusy:
                throw new InvalidOperationException("Resource is busy");
            case WiFiDirectError.TooManyClient:
                throw new InvalidOperationException("Too many client");
            case WiFiDirectError.WiFiUsed:
                throw new InvalidOperationException("Wi-fi is being used");
            }
        }
    }
}
