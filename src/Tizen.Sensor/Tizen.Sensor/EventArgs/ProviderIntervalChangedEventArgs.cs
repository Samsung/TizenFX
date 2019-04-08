/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd. All Rights Reserved
*
* PROPRIETARY/CONFIDENTIAL
*
* This software is the confidential and proprietary information of
* Samsung Electronics Co., Ltd. ("Confidential Information").
* You shall not disclose such Confidential Information and shall
* use it only in accordance with the terms of the license agreement
* you entered into with Samsung Electronics Co., Ltd. ("SAMSUNG").
*
* SAMSUNG MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE SUITABILITY
* OF THE SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT
* LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR
* A PARTICULAR PURPOSE, OR NON-INFRINGEMENT.SAMSUNG SHALL NOT BE
* LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING,
* MODIFYING OR DISTRIBUTING THIS SOFTWARE OR ITS DERIVATIVES.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor
{
    /// <summary>
    /// Indicates Provider Interval Changed callback.
    /// </summary>
    public class ProviderIntervalChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Indicates Provider Interval Changed callback.
        /// </summary>
        internal ProviderIntervalChangedEventArgs(Int64 _userData, uint intervalMs) {
            IntervalMs = intervalMs;
            UserData = _userData;
        }

        /// <summary>
        /// Interval
        /// </summary>
        public uint IntervalMs { get; private set; }
        /// <summary>
        /// Indicates userdata sent by provider Interval changed callback
        /// </summary>
        public Int64 UserData { get; private set; }
    }
}
