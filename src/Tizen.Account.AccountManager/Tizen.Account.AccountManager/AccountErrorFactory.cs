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
using Tizen;

namespace Tizen.Account.AccountManager
{
    /// <summary>
    /// Enum to give the type of error occured, if any.
    /// </summary>
    public enum AccountError
    {
        //TIZEN_ERROR_ACCOUNT = -0x01000000
        /// <summary>
        /// Successful.
        /// </summary>
        None = Tizen.Internals.Errors.ErrorCode.None,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        /// <summary>
        /// Same user name exists in your application
        /// </summary>
        Duplcated = -0x01000000 | 0x01,
        /// <summary>
        /// Empty Data
        /// </summary>
        NoData = Tizen.Internals.Errors.ErrorCode.NoData,
        /// <summary>
        /// elated record does not exist
        /// </summary>
        RecordNotFound = -0x01000000 | 0x03,
        /// <summary>
        /// Invalid Operation.
        /// </summary>
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
        /// <summary>
        /// DB operation failed.
        /// </summary>
        DBFailed = -0x01000000 | 0x04,
        /// <summary>
        ///  DB is not connected.
        /// </summary>
        DBNotOpened = -0x01000000 | 0x05,
        /// <summary>
        /// DB query syntax error
        /// </summary>
        QuerySyntaxError = -0x01000000 | 0x06,
        /// <summary>
        /// Iterator has reached the end
        /// </summary>
        IteratorEnd = -0x01000000 | 0x07,
        /// <summary>
        /// Notification failed
        /// </summary>
        NotificationFailed = -0x01000000 | 0x08,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        /// <summary>
        /// XML parse failed
        /// </summary>
        XMLParseFailed = -0x01000000 | 0x0a,
        /// <summary>
        /// XML File not found
        /// </summary>
        XMLFileNotFound = -0x01000000 | 0x0b,
        /// <summary>
        /// Subscription failed
        /// </summary>
        EventSubscriptionFailed = -0x01000000 | 0x0c,
        /// <summary>
        /// Account provider is not registered
        /// </summary>
        ProviderNotRegistered = -0x01000000 | 0x0d,
        /// <summary>
        /// Multiple accounts are not supported.
        /// </summary>
        MultipleNotAllowed = -0x01000000 | 0x0e,
        /// <summary>
        /// SQLite busy handler expired
        /// </summary>
        DBBusy = -0x01000000 | 0x10
    };

    internal class AccountErrorFactory
    {
        internal const string LogTag = "Tizen.Account.AccountManager";

        internal static Exception CreateException(AccountError err, string msg)
        {
            Log.Info(LogTag, "Got Error " + err + " throwing Exception with msg " + msg);
            Exception exp;
            switch (err)
            {
                case AccountError.InvalidParameter:
                    {
                        exp = new ArgumentException(msg + " Invalid Parameters Provided");
                        break;
                    }

                case AccountError.OutOfMemory:
                    {
                        exp = new OutOfMemoryException(msg + " Out Of Memory");
                        break;
                    }

                case AccountError.InvalidOperation:
                    {
                        exp = new InvalidOperationException(msg + " Inavlid operation");
                        break;
                    }

                case AccountError.NoData:
                    {
                        exp = new InvalidOperationException(msg + " Empty Data");
                        break;
                    }

                case AccountError.PermissionDenied:
                    {
                        exp = new UnauthorizedAccessException(msg + " Permission Denied");
                        break;
                    }

                case AccountError.DBFailed:
                    {
                        exp = new InvalidOperationException(msg + " DataBase Failed");
                        break;
                    }

                case AccountError.DBBusy:
                    {
                        exp = new InvalidOperationException(msg + " DataBase Busy");
                        break;
                    }

                case AccountError.QuerySyntaxError:
                    {
                        exp = new InvalidOperationException(msg + " Network Error");
                        break;
                    }
                case AccountError.XMLFileNotFound:
                    {
                        exp = new System.IO.FileNotFoundException(msg + " XML File not found");
                        break;
                    }
                case AccountError.XMLParseFailed:
                    {
                        exp = new System.IO.InvalidDataException(msg + " XML parse error");
                        break;
                    }

                default:
                    {
                        exp = new InvalidOperationException(err + " " + msg);
                        break;
                    }
            }

            return exp;
        }
    }
}
