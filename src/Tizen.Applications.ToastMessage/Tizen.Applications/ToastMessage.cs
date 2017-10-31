/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// The class helps you to create and show the ToastMessage which is a view quick message for the user.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public sealed class ToastMessage
    {

        /// <summary>
        /// Gets and sets a message to post the ToastMessage.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Message { get; set; }

        /// <summary>
        /// Posts a message on a toast pop-up.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the message is null.</exception>
        /// <example>
        /// <code>
        /// ToastMessage toast = new ToastMessage
        /// {
        ///     Message = "Hello TIzen"
        /// };
        /// toast.Post();
        /// </code>
        /// </example>
        /// <since_tizen> 4 </since_tizen>
        public void Post()
        {
            int ret = Interop.ToastMessage.ToastMessagePost(Message);
            if (ret != (int)ToastMessageError.None)
            {
                throw ToastMessageErrorFactory.GetException((ToastMessageError)ret, "post toast message failed");
            }
        }
    }

}
