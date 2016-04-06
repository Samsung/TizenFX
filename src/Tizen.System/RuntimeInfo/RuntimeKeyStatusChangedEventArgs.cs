/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.System
{
    /// <summary>
    /// RuntimeInfoChangedEventArgs is an extended EventArgs class. This class contains event arguments for runtime event listeners
    /// </summary>
    public class RuntimeKeyStatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The key indicating the runtime system preference which was changed.
        /// </summary>
        public RuntimeInformationKey Key { get; internal set; }
    }
}
