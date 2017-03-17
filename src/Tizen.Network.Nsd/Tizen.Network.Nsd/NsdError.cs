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

namespace Tizen.Network.Nsd
{
    internal static class NsdErrorFactory
    {
        internal static void ThrowDnssdException(int exception)
        {
            DnssdError _error = (DnssdError)exception;
            switch (_error)
            {
            case DnssdError.OutOfMemory:
                throw new InvalidOperationException("Out of memory");
            case DnssdError.InvalidOperation:
                throw new InvalidOperationException("Invalid operation");
            case DnssdError.InvalidParameter:
                throw new InvalidOperationException("Invalid parameter");
            case DnssdError.NotSupported:
                throw new NotSupportedException("Not supported");
            case DnssdError.NotInitialized:
                throw new InvalidOperationException("Not initialized");
            case DnssdError.AlreadyRegistered:
                throw new InvalidOperationException("Already registered");
            case DnssdError.NameConflict:
                throw new InvalidOperationException("Name conflict");
            case DnssdError.ServiceNotRunning:
                throw new InvalidOperationException("Service not running");
            case DnssdError.ServiceNotFound:
                throw new InvalidOperationException("Service not found");
            case DnssdError.OperationFailed:
                throw new InvalidOperationException("Operation failed");
            }
        }

        internal static void ThrowSsdpException(int exception)
        {
            SsdpError _error = (SsdpError)exception;
            switch (_error)
            {
                case SsdpError.OutOfMemory:
                    throw new InvalidOperationException("Out of memory");
                case SsdpError.InvalidParameter:
                    throw new InvalidOperationException("Invalid parameter");
                case SsdpError.NotSupported:
                    throw new NotSupportedException("Not supported");
                case SsdpError.NotInitialized:
                    throw new InvalidOperationException("Not initialized");
                case SsdpError.OperationFailed:
                    throw new InvalidOperationException("Operation failed");
                case SsdpError.ServiceNotFound:
                    throw new InvalidOperationException("Service not found");
                case SsdpError.ServiceAlreadyRegistered:
                    throw new InvalidOperationException("Service already registered");
            }
        }
    }
}
