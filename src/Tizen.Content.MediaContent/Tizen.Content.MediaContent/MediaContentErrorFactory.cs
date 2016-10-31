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

namespace Tizen.Content.MediaContent
{
    internal class MediaContentErrorFactory
    {
        internal const string LogTag = "Tizen.Content.MediaContent";

        internal static Exception CreateException(MediaContentError err, string msg)
        {
            Log.Info(Globals.LogTag, "Got Error " + err + " throwing Exception with msg " + msg);
            Exception exp;
            switch (err)
            {
                case MediaContentError.InvalidParameter:
                    {
                        exp = new ArgumentException(msg + " Invalid Parameters Provided");
                        break;
                    }
                case MediaContentError.OutOfMemory:
                    {
                        exp = new InvalidOperationException(msg + " Out Of Memory");
                        break;
                    }
                case MediaContentError.InvalidOperation:
                    {
                        exp = new InvalidOperationException(msg + " Inavlid operation");
                        break;
                    }
                case MediaContentError.NoSpaceOnDevice:
                    {
                        exp = new InvalidOperationException(msg + " No Space Left on Device");
                        break;
                    }
                case MediaContentError.PermissionDenied:
                    {
                        exp = new InvalidOperationException(msg + " Permission Denied");
                        break;
                    }
                case MediaContentError.DBFailed:
                    {
                        exp = new InvalidOperationException(msg + " DataBase Failed");
                        break;
                    }
                case MediaContentError.DBBusy:
                    {
                        exp = new InvalidOperationException(msg + " DataBase Busy");
                        break;
                    }
                case MediaContentError.NetworkError:
                    {
                        exp = new InvalidOperationException(msg + " Network Error");
                        break;
                    }
                case MediaContentError.UnsupportedContent:
                    {
                        exp = new ArgumentException(msg + " Content Not Supported");
                        break;
                    }
                default:
                    {
                        exp = new InvalidOperationException(msg);
                        break;
                    }
            }
            return exp;
        }
    }
}
