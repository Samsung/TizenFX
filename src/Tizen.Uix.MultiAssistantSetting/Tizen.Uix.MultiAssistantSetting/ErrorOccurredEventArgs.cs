/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.MultiAssistantSetting;

namespace Tizen.Uix.MultiAssistantSetting
{
    /// <summary>
    /// This class contains the data related to the ErrorOccurred event.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public class ErrorOccurredEventArgs
    {
        internal ErrorOccurredEventArgs(ErrorCode error)
        {
            switch (error)
            {
                case ErrorCode.None:
                    {
                        ErrorValue = Error.None;
                        break;
                    }

                case ErrorCode.InvalidParameter:
                    {
                        ErrorValue = Error.InvalidParameter;
                        break;
                    }

                case ErrorCode.PermissionDenied:
                    {
                        ErrorValue = Error.PermissionDenied;
                        break;
                    }

                case ErrorCode.NotSupported:
                    {
                        ErrorValue = Error.NotSupported;
                        break;
                    }

                case ErrorCode.OperationFailed:
                    {
                        ErrorValue = Error.OperationFailed;
                        break;
                    }
            }
        }

        /// <summary>
        /// The error value.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public Error ErrorValue
        {
            get;
            internal set;
        }
    }
}
