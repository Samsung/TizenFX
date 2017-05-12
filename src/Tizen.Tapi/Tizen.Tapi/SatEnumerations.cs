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
}
