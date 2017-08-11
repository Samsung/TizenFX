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
using static Interop.InputMethodManager;

namespace Tizen.Uix.InputMethodManager
{
    internal static class InputMethodManagerExceptionFactory
    {
        internal static Exception CreateException(ErrorCode err)
        {
            Tizen.Log.Error(LogTag, "Error " + err);
            Exception exp;
            switch (err)
            {

                case ErrorCode.InvalidParameter:
                {
                    exp = new ArgumentException("Invalid Parameters Provided");
                    break;
                }


                case ErrorCode.PermissionDenied:
                {
                    exp = new InvalidOperationException("Permission Denied");
                    break;
                }


                case ErrorCode.OperationFailed:
                {
                    exp = new InvalidOperationException("Operation Failed");
                    break;
                }

                default:
                {
                    exp = new Exception("");
                    break;
                }

            }

            return exp;

        }
    }
}
