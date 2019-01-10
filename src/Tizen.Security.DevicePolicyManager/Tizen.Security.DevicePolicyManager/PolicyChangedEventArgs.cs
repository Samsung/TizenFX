﻿/*
 *  Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;

namespace Tizen.Security.DevicePolicyManager
{
    /// <summary>
    /// An extended EventArgs class contains the changed dpm policy state.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class PolicyChangedEventArgs : EventArgs
    {
        internal PolicyChangedEventArgs(string name, string state)
        {
            PolicyName = name;
            IsAllowed = state.Equals("allowed");
        }

        /// <summary>
        /// Gets the name of the changed policy.
        /// </summary>
        /// <remarks>Each policy that can raise event has the name. The policy name value is in each policy class.</remarks>
        public string PolicyName { get; }

        /// <summary>
        /// Gets the current state of the policy.
        /// </summary>
        public bool IsAllowed { get; }
    }
}
