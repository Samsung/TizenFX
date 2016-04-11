// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="launchRequest"></param>
    /// <param name="replyRequest"></param>
    /// <param name="result"></param>
    public delegate void AppControlReplyCallback(AppControl launchRequest, AppControl replyRequest, AppControlReplyResult result);
}
