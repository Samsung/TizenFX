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
    /// Enumeration for the type of sms network.
    /// </summary>
    public enum SmsNetType
    {
        /// <summary>
        /// Network type is 3gpp.
        /// </summary>
        Net3GPP = 0x01,
        /// <summary>
        /// Network type is 3gpp2 (CDMA).
        /// </summary>
        Net3GPP2 = 0x02
    }

    /// <summary>
    /// Enumeration for different CB message types.
    /// </summary>
    public enum SmsCbMsgType
    {
        /// <summary>
        /// GSM Cell broadcast message.
        /// </summary>
        Gsm = 1,
        /// <summary>
        /// UMTSCell broadcast message.
        /// </summary>
        Umts,
        /// <summary>
        /// CDMA broadcast message.
        /// </summary>
        Cdma
    }

    /// <summary>
    /// Enumeration for different ETWS message types.
    /// </summary>
    public enum SmsEtwsMsgType
    {
        /// <summary>
        /// Primary ETWS message.
        /// </summary>
        Primary = 0,
        /// <summary>
        /// GSM Secondary ETWS message.
        /// </summary>
        SecondaryGsm,
        /// <summary>
        /// UMTS Secondary ETWS message.
        /// </summary>
        SecondaryUmts,
        /// <summary>
        /// CDMA Seconday ETWS message.
        /// </summary>
        SecondaryCdma
    }

    /// <summary>
    /// Enumeration for memory status type.
    /// </summary>
    public enum SmsMemoryStatus
    {
        /// <summary>
        /// PDA memory is available.
        /// </summary>
        PdaAvailable = 0x01,
        /// <summary>
        /// PDA memory is full.
        /// </summary>
        PdaFull = 0x02,
        /// <summary>
        /// Phone memory is available.
        /// </summary>
        PhoneAvailable = 0x03,
        /// <summary>
        /// Phone memory is full.
        /// </summary>
        PhoneFull = 0x04
    }

    /// <summary>
    /// Enumeration for the sms ready status type.
    /// </summary>
    public enum SmsReadyStatus
    {
        /// <summary>
        /// Non Ready Status.
        /// </summary>
        StatusNone = 0x00,
        /// <summary>
        /// SMS 3GPP Ready.
        /// </summary>
        Status3GPP = 0x01,
        /// <summary>
        /// SMS 3GPP2 Ready.
        /// </summary>
        Status3GPP2 = 0x02,
        /// <summary>
        /// SMS 3GPP and 3GPP2 Ready.
        /// </summary>
        Status3GPPAnd3GPP2 = 0x03
    }
}
