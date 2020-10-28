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

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the received AppControl.
    /// </summary>
    /// <example>
    /// <code>
    /// public class ReceivedAppControlExample : UIApplication
    /// {
    ///     // ...
    ///     protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
    ///     {
    ///         ReceivedAppControl control = e.ReceivedAppControl;
    ///         if (control.Operation == AppControlOperations.Pick)
    ///         {
    ///             Log.Debug(LogTag, "Received AppControl is Pick");
    ///         }
    ///         if (control.IsReplyRequest)
    ///         {
    ///             AppControl replyRequest = new AppControl();
    ///             replyRequest.ExtraData.Add("myKey", "I'm replying");
    ///             control.ReplyToLaunchRequest(replyRequest, AppControlReplyResult.Succeeded);
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <since_tizen> 3 </since_tizen>
    public class ReceivedAppControl : AppControl
    {
        private const string LogTag = "Tizen.Applications";

        /// <summary>
        /// Initializes a ReceivedAppControl class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ReceivedAppControl(SafeAppControlHandle handle) : base(handle)
        {
        }

        /// <summary>
        /// Gets the application ID of the caller from the launch request.
        /// </summary>
        /// <value>
        /// The application ID of the caller.
        /// </value>
        /// <example>
        /// <code>
        ///     protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        ///     {
        ///         ReceivedAppControl control = e.ReceivedAppControl;
        ///         string caller = control.CallerApplicationId;
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public string CallerApplicationId
        {
            get
            {
                string value = String.Empty;
                Interop.AppControl.ErrorCode err = Interop.AppControl.GetCaller(SafeAppControlHandle, out value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the caller application id from the AppControl. Err = " + err);
                }
                return value;
            }
        }

        /// <summary>
        /// Checks whether the caller is requesting a reply from the launch request.
        /// </summary>
        /// <value>
        /// If true, this ReceivedAppControl is requested by the caller, otherwise false
        /// </value>
        /// <example>
        /// <code>
        ///     protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        ///     {
        ///         ReceivedAppControl control = e.ReceivedAppControl;
        ///         bool isReply = control.IsReplyRequest;
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public bool IsReplyRequest
        {
            get
            {
                bool value = false;
                Interop.AppControl.ErrorCode err = Interop.AppControl.IsReplyRequested(SafeAppControlHandle, out value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to check the reply  of the AppControl is requested. Err = " + err);
                }
                return value;
            }
        }

        /// <summary>
        /// Replies to the launch request sent by the caller.
        /// If the caller application sends the launch request to receive the result, the callee application can return the result back to the caller.
        /// </summary>
        /// <param name="replyRequest">The AppControl in which the results of the callee are contained.</param>
        /// <param name="result">The result code of the launch request.</param>
        /// <example>
        /// <code>
        ///     protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        ///     {
        ///         ReceivedAppControl control = e.ReceivedAppControl;
        ///         if (control.IsReplyRequest)
        ///         {
        ///             AppControl replyRequest = new AppControl();
        ///             replyRequest.ExtraData.Add("myKey", "I'm replying");
        ///             control.ReplyToLaunchRequest(replyRequest, AppControlReplyResult.Succeeded);
        ///         }
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public void ReplyToLaunchRequest(AppControl replyRequest, AppControlReplyResult result)
        {
            if (replyRequest == null)
            {
                throw new ArgumentNullException("replyRequest");
            }
            Interop.AppControl.ErrorCode err = Interop.AppControl.ReplyToLaunchRequest(replyRequest.SafeAppControlHandle, this.SafeAppControlHandle, (int)result);
            if (err != Interop.AppControl.ErrorCode.None)
                throw new InvalidOperationException("Failed to reply. Err = " + err);
        }
    }
}
