/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.CallManager
{
    /// <summary>
    /// An extended EventArgs class which contains information about DTMF indication.
    /// </summary>
    public class DtmfIndicationEventArgs : EventArgs
    {
        private DtmfIndication _indication;
        private string _dtmfNumber;

        internal DtmfIndicationEventArgs(DtmfIndication indication, string dtmfNumber)
        {
            _indication = indication;
            _dtmfNumber = dtmfNumber;
        }

        /// <summary>
        /// DTMF indication.
        /// </summary>
        public DtmfIndication Indication
        {
            get
            {
                return _indication;
            }
        }

        /// <summary>
        /// DTMF number.
        /// </summary>
        public string DtmfNumber
        {
            get
            {
                return _dtmfNumber;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed audio status.
    /// </summary>
    public class AudioStatusChangedEventArgs : EventArgs
    {
        private AudioState _state;

        internal AudioStatusChangedEventArgs(AudioState state)
        {
            _state = state;
        }

        /// <summary>
        /// Audio state.
        /// </summary>
        public AudioState State
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed voice record status.
    /// </summary>
    public class VoiceRecordStatusEventArgs : EventArgs
    {
        private VrStatus _status;
        private VrStatusExtraType _extraType;

        internal VoiceRecordStatusEventArgs(VrStatus status, VrStatusExtraType extraType)
        {
            _status = status;
            _extraType = extraType;
        }

        /// <summary>
        /// Voice record status.
        /// </summary>
        public VrStatus Status
        {
            get
            {
                return _status;
            }
        }

        /// <summary>
        /// Voice record status extra type.
        /// </summary>
        public VrStatusExtraType ExtraType
        {
            get
            {
                return _extraType;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed call mute status.
    /// </summary>
    public class CallMuteStatusChangedEventArgs : EventArgs
    {
        private CallMuteStatus _Status;

        internal CallMuteStatusChangedEventArgs(CallMuteStatus status)
        {
            _Status = status;
        }

        /// <summary>
        /// Call mute status.
        /// </summary>
        public CallMuteStatus Status
        {
            get
            {
                return _Status;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed call status.
    /// </summary>
    public class CallStatusChangedEventArgs : EventArgs
    {
        private CallStatus _status;
        private string _callNumber;

        internal CallStatusChangedEventArgs(CallStatus status, string number)
        {
            _status = status;
            _callNumber = number;
        }

        /// <summary>
        /// Call status.
        /// </summary>
        public CallStatus Status
        {
            get
            {
                return _status;
            }
        }

        /// <summary>
        /// Call number.
        /// </summary>
        public string CallNumber
        {
            get
            {
                return _callNumber;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed dial status.
    /// </summary>
    public class DialStatusEventArgs : EventArgs
    {
        private DialStatus _status;

        internal DialStatusEventArgs(DialStatus status)
        {
            _status = status;
        }

        /// <summary>
        /// Dial status.
        /// </summary>
        public DialStatus Status
        {
            get
            {
                return _status;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed call event.
    /// </summary>
    public class CallEventEventArgs : EventArgs
    {
        private CallEvent _event;
        private CallEventData _eventData;

        internal CallEventEventArgs(CallEvent callEvent, CallEventData data)
        {
            _event = callEvent;
            _eventData = data;
        }

        /// <summary>
        /// Call event.
        /// </summary>
        public CallEvent Event
        {
            get
            {
                return _event;
            }
        }

        /// <summary>
        /// Call event data.
        /// </summary>
        public CallEventData EventData
        {
            get
            {
                return _eventData;
            }
        }
    }
}
