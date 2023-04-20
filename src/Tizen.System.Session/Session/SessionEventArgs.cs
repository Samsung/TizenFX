/*
* Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.System
{
    /// <summary>
    /// A generic subession event argument type.
    /// </summary>
    /// <remarks>
    /// Use this as an argument type for generic subession event handlers.
    /// You can check the event type that was invoked by checking a type of event arguments
    /// during runtime - they all derive from this base class.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class SubsessionEventArgs : EventArgs
    {
        /// <summary>
        /// Session UID of the session invoking the event
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SessionUID { get; internal set; }

        internal SubsessionEventInfoNative SessionInfo { get; set; }

        internal SubsessionEventArgs(SubsessionEventInfoNative infoNative)
        {
            SessionUID = infoNative.sessionUID;
            SessionInfo = infoNative;
        }
    }

    /// <summary>
    /// An event arguemnt type for AddUserWait event type
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AddUserEventArgs : SubsessionEventArgs
    {
        /// <summary>
        /// Added subsession user ID
        /// </summary> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UserName { get; internal set; }

        internal AddUserEventArgs(SubsessionEventInfoNative infoNative)
            : base(infoNative)
        {
            UserName = infoNative.addUser.userName;
        }
    }

    /// <summary>
    /// An event arguemnt type for RemoveUserWait event type
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RemoveUserEventArgs : SubsessionEventArgs
    {
        /// <summary>
        /// Removed subsession user ID
        /// </summary> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UserName { get; internal set; }

        internal RemoveUserEventArgs(SubsessionEventInfoNative infoNative)
            : base(infoNative)
        {
            UserName = infoNative.removeUser.userName;
        }
    }

    /// <summary>
    /// A generic base class for Switch event types
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class SwitchUserEventArgs : SubsessionEventArgs
    {
        /// <summary>
        /// ID of this switch operation
        /// </summary> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long SwitchID { get; internal set; }

        /// <summary>
        /// Active subsession user ID before this switch operation
        /// </summary> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UserNamePrev { get; internal set; }

        /// <summary>
        /// Active subsession ID after this switch operation
        /// </summary> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UserNameNext { get; internal set; }

        internal SwitchUserEventArgs(SubsessionEventInfoNative infoNative)
            : base(infoNative)
        {
            SwitchID = infoNative.switchUser.switchID;
            UserNamePrev = infoNative.switchUser.userNamePrev;
            UserNameNext = infoNative.switchUser.userNameNext;
        }
    }

    /// <summary>
    /// An event arguemnt type for SwitchUserWait event type
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SwitchUserWaitEventArgs : SwitchUserEventArgs
    {
        internal SwitchUserWaitEventArgs(SubsessionEventInfoNative infoNative) : base(infoNative) { }
    }

    /// <summary>
    /// An event arguemnt type for SwitchUserCompletion event type
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SwitchUserCompletionEventArgs : SwitchUserEventArgs
    {
        internal SwitchUserCompletionEventArgs(SubsessionEventInfoNative infoNative) : base(infoNative) { }
    }
}