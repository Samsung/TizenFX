/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;

using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    public class ReceivedAppControl : AppControl
    {
        private const string LogTag = "Tizen.Applications";

        internal ReceivedAppControl(IntPtr handle)
        {
            ErrorCode err = Interop.AppControl.DangerousClone(out _handle, handle);
            if (err != ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to create the appcontrol handle. Err = " + err);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CallerApplicationId
        {
            get
            {
                string value = String.Empty;
                ErrorCode err = Interop.AppControl.GetCaller(_handle, out value);
                if (err != ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the caller appId from the appcontrol. Err = " + err);
                }
                return value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReplyRequested
        {
            get
            {
                bool value = false;
                ErrorCode err = Interop.AppControl.IsReplyRequested(_handle, out value);
                if (err != ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to check the replyRequested of the appcontrol. Err = " + err);
                }
                return value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reply"></param>
        public void Reply(AppControl reply)
        {
            throw new NotImplementedException();
        }

    }
}
