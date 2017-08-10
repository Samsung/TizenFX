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
    /// The class helps you create and show ToastMessage which is a view quick message for the user
    /// </summary>
    public sealed class ToastMessage
    {

        /// <summary>
        /// Gets and sets message to post ToastMessage
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Posts a message on a toast popup
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when Message is null</exception>
        /// <example>
        /// <code>
        /// ToastMessage toast = new ToastMessage
        /// {
        ///     Message = "Hello TIzen"
        /// };
        /// toast.Post();
        /// </code>
        /// </example>
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
