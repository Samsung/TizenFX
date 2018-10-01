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
    /// Enumeration for the UI display status.
    /// </summary>
    public enum SatUiDisplayStatus
    {
        /// <summary>
        /// Infoms about UI display success.
        /// </summary>
        Success = 0x00,
        /// <summary>
        /// Informs about UI display failure.
        /// </summary>
        Fail = 0x01
    }

    /// <summary>
    /// Enumeration for the command qualifier values of the refresh command.
    /// </summary>
    public enum SatCmdQualiRefresh
    {
        /// <summary>
        /// Command qualifier for Refresh SIM Init And Full File Change Notification.
        /// </summary>
        SimInitAndFullFcn = 0x00,
        /// <summary>
        /// Command qualifier for Refresh File Change Notification.
        /// </summary>
        Fcn = 0x01,
        /// <summary>
        /// Command qualifier for Refresh SIM Init And File Change Notification.
        /// </summary>
        SimInitAndFcn = 0x02,
        /// <summary>
        /// Command qualifier for Refresh Sim Init.
        /// </summary>
        SimInit = 0x03,
        /// <summary>
        /// Command qualifier for Refresh Sim Reset.
        /// </summary>
        SimReset = 0x04,
        /// <summary>
        /// Command qualifier for Refresh 3G Application Reset.
        /// </summary>
        ApplicationReset3G = 0x05,
        /// <summary>
        /// Command qualifier for Refresh 3G Session Reset.
        /// </summary>
        SessionReset = 0x06,
        /// <summary>
        /// Command qualifier for Refresh Reserved.
        /// </summary>
        Reserved = 0xFF
    }

    /// <summary>
    /// Enumeration for the icon qualifier.
    /// </summary>
    public enum SatIconQualifierType
    {
        /// <summary>
        /// Icon Quali Self Explanatory.
        /// </summary>
        SelfExplanatory = 0,
        /// <summary>
        /// Icon Quali Not Self Explanatory.
        /// </summary>
        NotSelfExplanatory = 1,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved = 0xFF
    }

    /// <summary>
    /// Enumeration for the SIM image coding scheme type.
    /// </summary>
    public enum SatImageCodingScheme
    {
        /// <summary>
        /// Basic coding scheme.
        /// </summary>
        Basic = 0x11,
        /// <summary>
        /// Colour coding scheme.
        /// </summary>
        Colour = 0x21,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved = 0xFF
    }

    /// <summary>
    /// Enumeration for the inkey type.
    /// </summary>
    public enum SatInKeyType
    {
        /// <summary>
        /// Command qualifier for Inkey type character set enabled.
        /// </summary>
        CharacterSetEnabled = 0,
        /// <summary>
        /// Command qualifier for Inkey type Yes No requested.
        /// </summary>
        YesNoRequested = 1
    }

    /// <summary>
    /// Enumeration for the user input type.
    /// </summary>
    public enum SatInputAlphabetType
    {
        /// <summary>
        /// SMS default.
        /// </summary>
        SmsDefault = 1,
        /// <summary>
        /// UCS2 alphabet type.
        /// </summary>
        Ucs2 = 2
    }

    /// <summary>
    /// Enumeration for the refresh application type.
    /// </summary>
    public enum SatRefreshAppType
    {
        /// <summary>
        /// Phonebook type.
        /// </summary>
        Contact = 0x00,
        /// <summary>
        /// SMS type.
        /// </summary>
        Msg,
        /// <summary>
        /// Other.
        /// </summary>
        Other,
        /// <summary>
        /// Maximum value.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the SMS TPDU type.
    /// </summary>
    public enum SatSmsTpduType
    {
        /// <summary>
        /// Deliver TPDU type.
        /// </summary>
        DeliverTpdu = 0,
        /// <summary>
        /// Deliver RPT type.
        /// </summary>
        DeliverRpt = 1,
        /// <summary>
        /// Submit TPDU type.
        /// </summary>
        SubmitTpdu = 2,
        /// <summary>
        /// Submit RPT type.
        /// </summary>
        SubmitRpt = 3,
        /// <summary>
        /// Status RPT type.
        /// </summary>
        StatusRpt = 4,
        /// <summary>
        /// TPDU CMD type.
        /// </summary>
        TpduCmd = 5
    }

    /// <summary>
    /// Enumeration for the type of command and the next action indicator.
    /// </summary>
    public enum SatCommandType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// Refresh.
        /// </summary>
        Refresh = 0x01,
        /// <summary>
        /// More time.
        /// </summary>
        MoreTime = 0x02,
        /// <summary>
        /// Setup event list.
        /// </summary>
        SetupEventList = 0x05,
        /// <summary>
        /// Setup call.
        /// </summary>
        SetupCall = 0x10,
        /// <summary>
        /// Send SS.
        /// </summary>
        SendSs = 0x11,
        /// <summary>
        /// Send USSD.
        /// </summary>
        SendUssd = 0x12,
        /// <summary>
        /// Send SMS.
        /// </summary>
        SendSms = 0x13,
        /// <summary>
        /// Send DTMF.
        /// </summary>
        SendDtmf = 0x14,
        /// <summary>
        /// Launch browser.
        /// </summary>
        LaunchBrowser = 0x15,
        /// <summary>
        /// Play tone.
        /// </summary>
        PlayTone = 0x20,
        /// <summary>
        /// Display text.
        /// </summary>
        DisplayText = 0x21,
        /// <summary>
        /// Get inkey.
        /// </summary>
        GetInKey = 0x22,
        /// <summary>
        /// Get input.
        /// </summary>
        GetInput = 0x23,
        /// <summary>
        /// Select item.
        /// </summary>
        SelectItem = 0x24,
        /// <summary>
        /// Setup menu.
        /// </summary>
        SetupMenu = 0x25,
        /// <summary>
        /// Provide local info.
        /// </summary>
        ProvideLocalInfo = 0x26,
        /// <summary>
        /// Setup idle mode text.
        /// </summary>
        SetupIdleModeText = 0x28,
        /// <summary>
        /// Language notification.
        /// </summary>
        LanguageNotification = 0x35,
        /// <summary>
        /// Open channel - class e.
        /// </summary>
        OpenChannel = 0x40,
        /// <summary>
        /// Close channel - class e.
        /// </summary>
        CloseChannel = 0x41,
        /// <summary>
        /// Receive data - class e.
        /// </summary>
        ReceiveData = 0x42,
        /// <summary>
        /// Send data.
        /// </summary>
        SendData = 0x43,
        /// <summary>
        /// Get channel status - class e.
        /// </summary>
        GetChannelStatus = 0x44,
        /// <summary>
        /// Inform to end the execution of a proactive command.
        /// </summary>
        EndOfAppExec = 0xFD,
        /// <summary>
        /// Inform end proactive session.
        /// </summary>
        EndProactiveSession = 0xFE,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved = 0xFF
    }

    /// <summary>
    /// Enumeration for the SAT call type.
    /// </summary>
    public enum SatCallType
    {
        /// <summary>
        /// MO voice.
        /// </summary>
        MoVoice = 0x00,
        /// <summary>
        /// MO SMS.
        /// </summary>
        MoSms,
        /// <summary>
        /// SS.
        /// </summary>
        Ss,
        /// <summary>
        /// USSD.
        /// </summary>
        Ussd,
        /// <summary>
        /// PDP context action.
        /// </summary>
        PdpContextAct,
        /// <summary>
        /// Max.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the result of call control by SIM.
    /// </summary>
    public enum SatCallCtrlResultType
    {
        /// <summary>
        /// Allowed with no mod.
        /// </summary>
        AllowedNoMod = 0,
        /// <summary>
        /// Not allowed.
        /// </summary>
        NotAllowed = 1,
        /// <summary>
        /// Allowed with mod.
        /// </summary>
        AllowedWithMod = 2,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved = 0xFF
    }

    /// <summary>
    /// Enumeration for the SIM ATK BC repeat indicator type.
    /// </summary>
    public enum SatBcRepeatIndicatorType
    {
        /// <summary>
        /// Alternate mode.
        /// </summary>
        AlternateMode = 0x01,
        /// <summary>
        /// Sequential mode.
        /// </summary>
        SequentialMode = 0x03,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved = 0xFF
    }

    /// <summary>
    /// Enumeration for alphabet format.
    /// </summary>
    public enum SatAlphabetFormat
    {
        /// <summary>
        /// SMS default.
        /// </summary>
        SmsDefault = 0x00,
        /// <summary>
        /// 8Bit data.
        /// </summary>
        Data8Bit = 0x01,
        /// <summary>
        /// UCS2.
        /// </summary>
        Ucs2 = 0x02,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved = 0x03
    }

    /// <summary>
    /// Enumeration for the message class.
    /// </summary>
    public enum SatMsgClassType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// Class 0.
        /// </summary>
        Class0 = 0x01,
        /// <summary>
        /// Class 1 Default meaning: ME - specific.
        /// </summary>
        Class1,
        /// <summary>
        /// Class 2 SIM specific message.
        /// </summary>
        Class2,
        /// <summary>
        /// Class 3 Default meaning : TE specific.
        /// </summary>
        Class3,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved = 0xFF
    }

    /// <summary>
    /// Enumeration for the command qualifier values of the setup call command.
    /// </summary>
    public enum SatCmdQualiSetupCall
    {
        /// <summary>
        /// Command qualifier for setup call if another call is not busy.
        /// </summary>
        AnotherCallNotBusy = 0x00,
        /// <summary>
        /// Command qualifier for setup call if another call is not busy with redial.
        /// </summary>
        AnotherCallNotBusyWithRedial = 0x01,
        /// <summary>
        /// Command qualifier for setup call putting all other calls on hold.
        /// </summary>
        PutAllOtherCallsOnHold = 0x02,
        /// <summary>
        /// Command qualifier for setup call putting all other calls on hold with redial.
        /// </summary>
        PutAllOtherCallsOnHoldWithRedial = 0x03,
        /// <summary>
        /// Command qualifier for setup call disconnecting all other calls.
        /// </summary>
        DisconnectAllOtherCalls = 0x04,
        /// <summary>
        /// Command qualifier for setup call disconnecting all other calls with redial.
        /// </summary>
        DisconnectAllOtherCallsWithRedial = 0x05,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved = 0xFF
    }
}
