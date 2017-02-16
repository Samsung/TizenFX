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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Network.Connection
{
    internal static class ConnectionErrorFactory
    {
        internal static void ThrowConnectionException(int errno)
        {
            ConnectionError _error = (ConnectionError)errno;
            Log.Debug(Globals.LogTag, "ThrowConnectionException " + _error);
            switch (_error)
            {
                case ConnectionError.AddressFamilyNotSupported:
                    throw new InvalidOperationException("Address Family Not Supported");
                case ConnectionError.AlreadyExists:
                    throw new InvalidOperationException("Already Exists");
                case ConnectionError.DhcpFailed:
                    throw new InvalidOperationException("DHCP Failed");
                case ConnectionError.EndOfIteration:
                    throw new InvalidOperationException("End Of Iteration");
                case ConnectionError.InvalidKey:
                    throw new InvalidOperationException("Invalid Key");
                case ConnectionError.InvalidOperation:
                    throw new InvalidOperationException("Invalid Operation");
                case ConnectionError.InvalidParameter:
                    throw new InvalidOperationException("Invalid Parameter");
                case ConnectionError.NoConnection:
                    throw new InvalidOperationException("No Connection");
                case ConnectionError.NoReply:
                    throw new InvalidOperationException("No Reply");
                case ConnectionError.NotSupported:
                    throw new NotSupportedException("Not Supported");
                case ConnectionError.NowInProgress:
                    throw new InvalidOperationException("Now In Progress");
                case ConnectionError.OperationAborted:
                    throw new InvalidOperationException("Operation Aborted");
                case ConnectionError.OperationFailed:
                    throw new InvalidOperationException("Operation Failed");
                case ConnectionError.OutOfMemoryError:
                    throw new InvalidOperationException("Out Of Memory Error");
                case ConnectionError.PermissionDenied:
                    throw new InvalidOperationException("Permission Denied");
            }
        }
    }
}