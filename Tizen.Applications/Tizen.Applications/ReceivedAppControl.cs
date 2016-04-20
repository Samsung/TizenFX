// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
    public class ReceivedAppControl : AppControl
    {
        private const string LogTag = "Tizen.Applications";

        internal ReceivedAppControl(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Gets the application ID of the caller from the launch request.
        /// </summary>
        /// <value>
        /// The application ID of the caller
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
        public string CallerApplicationId
        {
            get
            {
                string value = String.Empty;
                Interop.AppControl.ErrorCode err = Interop.AppControl.GetCaller(_handle, out value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the caller appId from the appcontrol. Err = " + err);
                }
                return value;
            }
        }

        /// <summary>
        /// Checks whether the caller is requesting a reply from the launch request.
        /// </summary>
        /// <value>
        /// If true this ReceivedAppControl is requested by the caller, otherwise false
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
        public bool IsReplyRequest
        {
            get
            {
                bool value = false;
                Interop.AppControl.ErrorCode err = Interop.AppControl.IsReplyRequested(_handle, out value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to check the replyRequested of the appcontrol. Err = " + err);
                }
                return value;
            }
        }

        /// <summary>
        /// Replies to the launch request sent by the caller.
        /// If the caller application sent the launch request to receive the result, the callee application can return the result back to the caller.
        /// </summary>
        /// <param name="replyRequest">The AppControl in which the results of the callee are contained</param>
        /// <param name="result">The result code of the launch request</param>
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
        public void ReplyToLaunchRequest(AppControl replyRequest, AppControlReplyResult result)
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.ReplyToLaunchRequest(replyRequest._handle, this._handle, (int)result);
            if (err == Interop.AppControl.ErrorCode.InvalidParameter)
                throw new ArgumentException("Invalid parameter of ReplyToLaunchRequest()");
        }
    }
}
