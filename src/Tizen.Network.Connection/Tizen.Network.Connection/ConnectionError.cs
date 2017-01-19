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
    internal class ConnectionErrorFactory
    {
        static public void ThrowConnectionException(int errno)
        {
            ConnectionError error = (ConnectionError)errno;
            Log.Debug(Globals.LogTag, "ThrowConnectionException " + error);
            if (error == ConnectionError.AddressFamilyNotSupported)
            {
                throw new InvalidOperationException("Address Family Not Supported");
            }
            else if (error == ConnectionError.AlreadyExists)
            {
                throw new InvalidOperationException("Already Exists");
            }
            else if (error == ConnectionError.DhcpFailed)
            {
                throw new InvalidOperationException("DHCP Failed");
            }
            else if (error == ConnectionError.EndOfIteration)
            {
                throw new InvalidOperationException("End Of Iteration");
            }
            else if (error == ConnectionError.InvalidKey)
            {
                throw new InvalidOperationException("Invalid Key");
            }
            else if (error == ConnectionError.InvalidOperation)
            {
                throw new InvalidOperationException("Invalid Operation");
            }
            else if (error == ConnectionError.InvalidParameter)
            {
                throw new InvalidOperationException("Invalid Parameter");
            }
            else if (error == ConnectionError.NoConnection)
            {
                throw new InvalidOperationException("No Connection");
            }
            else if (error == ConnectionError.NoReply)
            {
                throw new InvalidOperationException("No Reply");
            }
            else if (error == ConnectionError.NotSupported)
            {
                throw new NotSupportedException("Not Supported");
            }
            else if (error == ConnectionError.NowInProgress)
            {
                throw new InvalidOperationException("Now In Progress");
            }
            else if (error == ConnectionError.OperationAborted)
            {
                throw new InvalidOperationException("Operation Aborted");
            }
            else if (error == ConnectionError.OperationFailed)
            {
                throw new InvalidOperationException("Operation Failed");
            }
            else if (error == ConnectionError.OutOfMemoryError)
            {
                throw new InvalidOperationException("Out Of Memory Error");
            }
            else if (error == ConnectionError.PermissionDenied)
            {
                throw new InvalidOperationException("Permission Denied");
            }
        }
    }
}
