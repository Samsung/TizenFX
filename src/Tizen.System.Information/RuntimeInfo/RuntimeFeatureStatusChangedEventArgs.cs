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

namespace Tizen.System
{
    /// <summary>
    /// RuntimeFeatureStatusChangedEventArgs is an extended EventArgs class. This class contains event arguments for runtime event listeners.
    /// </summary>
    public class RuntimeFeatureStatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The key indicating the runtime system preference which was changed.
        /// It includes the prefix "http://" though you don't use for registering callback.
        /// </summary>
        public String Key { get; internal set; }
    }
}
