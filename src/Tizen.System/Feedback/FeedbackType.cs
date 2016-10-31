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

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for feedback device types.
    /// </summary>
    public enum FeedbackType
    {
        /// <summary>
        ///  Sound and Vibration
        /// </summary>
        All = 0,
        /// <summary>
        /// Sound feedback
        /// </summary>
        Sound = Interop.Feedback.FeedbackType.Sound,
        /// <summary>
        /// Vibration
        /// /// </summary>
        Vibration = Interop.Feedback.FeedbackType.Vibration,
    }
}
