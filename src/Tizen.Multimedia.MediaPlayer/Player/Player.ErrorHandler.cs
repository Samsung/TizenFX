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
using System.ComponentModel;

namespace Tizen.Multimedia
{
    public partial class Player
    {
        private Action<int, string> _errorHandler;

        internal void NotifyError(int errorCode, string message)
        {
            _errorHandler?.Invoke(errorCode, message);
        }

        /// <summary>
        /// This method supports the product infrastructure and is not intended to be used directly from application code.
        /// </summary>
        /// <param name="errorCode">The error code according to the exception.</param>
        /// <param name="message">The error message to show user.</param>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static Exception GetException(int errorCode, string message) =>
            ((PlayerErrorCode)errorCode).GetException(message);
    }
}