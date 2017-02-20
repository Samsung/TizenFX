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
using System.Threading.Tasks;

namespace Tizen.Messaging.Email
{
    /// <summary>
    /// The class to send email messages.
    /// </summary>
    public static class EmailSender
    {
        /// <summary>
        /// Sends the email message.
        /// </summary>
        /// <param name="email">The email message</param>
        /// <param name="saveToSentBox">true to save the message in the sentbox</param>
        /// <returns> Failure if email sending failed otherwise Success</returns>
        public static async Task<EmailSendResult> SendAsync(EmailMessage email)
        {
            var task = new TaskCompletionSource<EmailSendResult>();
            int ret = (int)EmailError.None;
            bool saveToSentBox = false;

            email.FillHandle();
            email.Save();

            Interop.Email.EmailSentCallback _emailSendingCallback = (IntPtr handle, int result, IntPtr userData) =>
            {
                task.SetResult((EmailSendResult)result);
            };

            ret = Interop.Email.SetCb(email._emailHandle, _emailSendingCallback, IntPtr.Zero);
            if (ret != (int)EmailError.None)
            {
                Log.Error(EmailErrorFactory.LogTag, "Failed to set email incoming callback, Error code: " + (EmailError)ret);
                throw EmailErrorFactory.GetException(ret);
            }

            ret = Interop.Email.SendEmail(email._emailHandle, saveToSentBox);
            if (ret != (int)EmailError.None)
            {
                Log.Error(EmailErrorFactory.LogTag, "Failed to send email, Error code: " + (EmailError)ret);
                throw EmailErrorFactory.GetException(ret);
            }

            var sendResult = await task.Task;

            ret = Interop.Email.UnsetCb(email._emailHandle);
            if (ret != (int)EmailError.None)
            {
                Log.Error(EmailErrorFactory.LogTag, "Failed to set email incoming callback, Error code: " + (EmailError)ret);
                throw EmailErrorFactory.GetException(ret);
            }

            return sendResult;
        }
    }
}
