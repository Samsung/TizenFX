/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;

namespace Tizen.Applications
{
    public class ReceivedAppControl : AppControl
    {
        private const string LogTag = "Tizen.Applications";

        internal ReceivedAppControl(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// 
        /// </summary>
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
        /// 
        /// </summary>
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
        /// 
        /// </summary>
        /// <param name="replyRequest"></param>
        /// <param name="launchRequest"></param>
        /// <param name="result"></param>
        public void ReplyToLaunchRequest(AppControl replyRequest, AppControlReplyResult result)
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.ReplyToLaunchRequest(replyRequest._handle, this._handle, (int)result);
            if (err == Interop.AppControl.ErrorCode.InvalidParameter)
                throw new ArgumentException("Invalid parameter of ReplyToLaunchRequest()");
        }
    }
}
