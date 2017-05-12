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

namespace Tizen.Tapi
{
    /// <summary>
    /// A class containing information about call idle status notification data.
    /// </summary>
    public class CallIdleStatusNotificationData
    {
        internal uint Id;
        internal CallEndCause Cause;

        internal CallIdleStatusNotificationData()
        {
        }

        /// <summary>
        /// Notification id.
        /// </summary>
        /// <value>Notificatio id in unsigned integer format.</value>
        public uint NotiId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// End cause for the call indicates whether the call is released normally or due to some other cause.
        /// </summary>
        /// <value>En cause enum value.</value>
        public CallEndCause EndCause
        {
            get
            {
                return Cause;
            }
        }
    }

    /// <summary>
    /// A class which contains calling name information.
    /// </summary>
    public class CallerNameInfo
    {
        internal CallNameMode Mode;
        internal string NameData;

        internal CallerNameInfo()
        {
        }

        /// <summary>
        /// Display mode of the name.
        /// </summary>
        /// <value>Enum value for call name mode</value>
        public CallNameMode NameMode
        {
            get
            {
                return Mode;
            }
        }

        /// <summary>
        /// Calling party name string.
        /// </summary>
        /// <value>String value representing calling party name.</value>
        public string Name
        {
            get
            {
                return NameData;
            }
        }
    }

    /// <summary>
    /// A class which contains details about call information.
    /// </summary>
    public class CallIncomingInfo
    {
        internal uint Handle;
        internal CallType Type;
        internal string Number;
        internal CallerNameInfo Name;
        internal CallCliMode Cli;
        internal CallNoCliCause Cause;
        internal bool IsFwded;
        internal CallActiveLine Line;

        internal CallIncomingInfo()
        {
        }

        /// <summary>
        /// Call handle indicates the handle of the call for the application.
        /// </summary>
        /// <value>Call handle represented in unsigned integer format.</value>
        public uint CallHandle
        {
            get
            {
                return Handle;
            }
        }

        /// <summary>
        /// Call type.
        /// </summary>
        /// <value>Call type indicating whether the requested call is a voice or video call.</value>
        public CallType CallType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Caller number, null terminated ASCII.
        /// </summary>
        /// <value>A string representing calling party number.</value>
        public string CallerNumber
        {
            get
            {
                return Number;
            }
        }

        /// <summary>
        /// Call name info. If there is no information from the network, this information will be null.
        /// </summary>
        /// <value>A CallerNameInfo which contains information about the calling party name.</value>
        public CallerNameInfo NameInfo
        {
            get
            {
                return Name;
            }
        }

        /// <summary>
        /// CLI mode.
        /// </summary>
        /// <value>Enum value representing CLI mode.</value>
        public CallCliMode CliMode
        {
            get
            {
                return Cli;
            }
        }

        /// <summary>
        /// No CLI cause.
        /// </summary>
        /// <value>Enum value representing the cause for no CLI.</value>
        public CallNoCliCause CliCause
        {
            get
            {
                return Cause;
            }
        }

        /// <summary>
        /// Checks whether the incoming call is a forwarded call or not.
        /// </summary>
        /// <value>True or false. If the incoming call is a forwarded call, then true else false.</value>
        public bool IsForwarded
        {
            get
            {
                return IsFwded;
            }
        }

        /// <summary>
        /// Current Active Line.
        /// </summary>
        /// <value>Enum value representing call active line.</value>
        public CallActiveLine ActiveLine
        {
            get
            {
                return Line;
            }
        }
    }

    /// <summary>
    /// A class which contains information about call line control.
    /// </summary>
    public class CallRecordLineControl
    {
        internal byte PolarityInc;
        internal byte Toggle;
        internal byte ReversePol;
        internal byte PowerTime;

        internal CallRecordLineControl()
        {
        }

        /// <summary>
        /// Polarity included.
        /// </summary>
        /// <value>Polarity value represented in byte format.</value>
        public byte PolarityIncluded
        {
            get
            {
                return PolarityInc;
            }
        }

        /// <summary>
        /// Toggle mode.
        /// </summary>
        /// <value>Toggle mode represented in byte format.</value>
        public byte ToggleMode
        {
            get
            {
                return Toggle;
            }
        }

        /// <summary>
        /// Reverse polarity.
        /// </summary>
        /// <value>Reverse polarity value represented in byte format.</value>
        public byte ReversePolarity
        {
            get
            {
                return ReversePol;
            }
        }

        /// <summary>
        /// Power denial time.
        /// </summary>
        /// <value>Time value in byte which represents power denial time.</value>
        public byte PowerDenialTime
        {
            get
            {
                return PowerTime;
            }
        }
    }

    /// <summary>
    /// A class which contains information about call record.
    /// </summary>
    public class CallRecord
    {
        internal uint Id;
        internal CallRecordType Type;
        internal string Name;
        internal string Number;
        internal CallRecordLineControl LineCtrl;

        internal CallRecord()
        {
        }

        /// <summary>
        /// Call id
        /// </summary>
        /// <value>Call id which is represented in unsigned integer format.</value>
        public uint CallId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Call record type.
        /// </summary>
        /// <value>An enum value representing the call record type.</value>
        public CallRecordType CallRecordType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Name record.
        /// </summary>
        /// <remarks>
        /// This value will be filled only if CallRecordType is Name, otherwise it is null.
        /// </remarks>
        /// <value>Name record represented in string.</value>
        public string NameRecord
        {
            get
            {
                return Name;
            }
        }

        /// <summary>
        /// Number record.
        /// </summary>
        /// <remarks>
        /// This value will be filled only if CallRecordType is Record, otherwise it is null.
        /// </remarks>
        /// <value>Number record reprensented in string.</value>
        public string NumberRecord
        {
            get
            {
                return Number;
            }
        }

        /// <summary>
        /// Gets the line control info.
        /// </summary>
        /// <remarks>
        /// This value will be filled only if CallRecordType is LineControl, otherwise it is null.
        /// </remarks>
        /// <value>An instance of CallRecordLineControl class.</value>
        public CallRecordLineControl LineControlInfo
        {
            get
            {
                return LineCtrl;
            }
        }
    }

    /// <summary>
    /// A class which contains information about call signal notification.
    /// </summary>
    public class CallSignalNotification
    {
        internal CallAlertSignal Signal;
        internal CallAlertPitch Pitch;
        internal CallToneSignal Tone;
        internal CallIsdnAlertSignal Isdn;
        internal CallIs54bAlertSignal Is54b;

        internal CallSignalNotification()
        {
        }

        /// <summary>
        /// Gets the call signal type.
        /// </summary>
        /// <value>Signal type of the call represented as CallAlertSignal enum.</value>
        public CallAlertSignal SignalType
        {
            get
            {
                return Signal;
            }
        }

        /// <summary>
        /// Gets the call pitch type.
        /// </summary>
        /// <value>Pitch type of the call represented as CallAlertPitch enum.</value>
        public CallAlertPitch PitchType
        {
            get
            {
                return Pitch;
            }
        }

        /// <summary>
        /// Gets the call signal tone type.
        /// </summary>
        /// <remarks>
        /// This value will be filled only if SignalType is Tone.
        /// </remarks>
        /// <value>Signal tone type of the call represented in CallToneSignal enum.</value>
        public CallToneSignal ToneType
        {
            get
            {
                return Tone;
            }
        }

        /// <summary>
        /// Gets the signal ISDN Alert type.
        /// </summary>
        /// <remarks>
        /// This value will be filled only if SignalType is IsdnAlert.
        /// </remarks>
        /// <value>Signal ISDN alert type of the call represented in CallIsdnAlertSignal enum.</value>
        public CallIsdnAlertSignal IsdnAlertType
        {
            get
            {
                return Isdn;
            }
        }

        /// <summary>
        /// Gets the signal IS54B alert type.
        /// </summary>
        /// <remarks>
        /// This value will be filled only if SignalType is Is54bAlert.
        /// </remarks>
        /// <value>Signal IS54B alerty type of the call represented in CallIs54bAlertSignal enum.</value>
        public CallIs54bAlertSignal Is54bAlertType
        {
            get
            {
                return Is54b;
            }
        }
    }

    /// <summary>
    /// A class which contains information about call upgrade/downgrade request of VoLTE call.
    /// </summary>
    public class CallUpgradeDowngradeRequestNoti
    {
        internal int Handle;
        internal CallConfigType Type;

        internal CallUpgradeDowngradeRequestNoti()
        {
        }

        /// <summary>
        /// Gets the call handle.
        /// </summary>
        /// <value>Call handle value represented in integer format.</value>
        public int CallHandle
        {
            get
            {
                return Handle;
            }
        }

        /// <summary>
        /// Gets the call upgrade/downgrade config type.
        /// </summary>
        /// <value>Call upgrade/downgrade type represented in CallConfigType enum.</value>
        public CallConfigType UpgradeType
        {
            get
            {
                return Type;
            }
        }
    }
}
