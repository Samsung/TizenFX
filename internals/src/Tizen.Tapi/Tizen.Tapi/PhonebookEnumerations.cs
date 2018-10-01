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
    /// Enumeration for the storage types to be selected in the SIM or USIM.
    /// </summary>
    public enum PhonebookType
    {
        /// <summary>
        /// Fixed Dialing Number.
        /// </summary>
        Fdn,
        /// <summary>
        /// Sim - ADN.
        /// </summary>
        Adn,
        /// <summary>
        /// Service Dialing Number.
        /// </summary>
        Sdn,
        /// <summary>
        /// USIM - 3G phone book.
        /// </summary>
        Usim,
        /// <summary>
        /// Additional number Alpha String.
        /// </summary>
        Aas,
        /// <summary>
        /// Grouping identifier Alpha String.
        /// </summary>
        Gas,
        /// <summary>
        /// Unknown file type.
        /// </summary>
        Unknown = 0xFF
    }

    /// <summary>
    /// Enumeration for the phonebook operation types.
    /// </summary>
    public enum PhonebookOperationType
    {
        /// <summary>
        /// Contact added or updated.
        /// </summary>
        Update,
        /// <summary>
        /// Existing contact deleted.
        /// </summary>
        Delete,
        /// <summary>
        /// Max value.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the storage field types in the 3G Phone book.
    /// </summary>
    public enum PhonebookFileType3G
    {
        /// <summary>
        /// Name.
        /// </summary>
        Name = 0x01,
        /// <summary>
        /// Number.
        /// </summary>
        Number,
        /// <summary>
        /// First Another number.
        /// </summary>
        Anr1,
        /// <summary>
        /// Second Another number.
        /// </summary>
        Anr2,
        /// <summary>
        /// Third Another number.
        /// </summary>
        Anr3,
        /// <summary>
        /// First Email.
        /// </summary>
        Email1,
        /// <summary>
        /// Second Email.
        /// </summary>
        Email2,
        /// <summary>
        /// Third Email.
        /// </summary>
        Email3,
        /// <summary>
        /// Fourth Email.
        /// </summary>
        Email4,
        /// <summary>
        /// Second name entry of the main name.
        /// </summary>
        Sne,
        /// <summary>
        /// Group.
        /// </summary>
        Group,
        /// <summary>
        /// 1 byte control info and 1 byte hidden info.
        /// </summary>
        Pbc
    }

    /// <summary>
    /// Enumeration for the text encryption type.
    /// </summary>
    public enum TextEncryptionType
    {
        /// <summary>
        /// ASCII Encoding.
        /// </summary>
        Ascii,
        /// <summary>
        /// GSM 7 Bit Encoding.
        /// </summary>
        Gsm7Bit,
        /// <summary>
        /// UCS2 Encoding.
        /// </summary>
        Ucs2,
        /// <summary>
        /// HEX Encoding.
        /// </summary>
        Hex
    }

    /// <summary>
    /// Enumeration for the phonebook access result.
    /// </summary>
    public enum PhonebookAccessResult
    {
        /// <summary>
        /// SIM phonebook operation successful.
        /// </summary>
        Success,
        /// <summary>
        /// SIM phonebook operation failure.
        /// </summary>
        Fail,
        /// <summary>
        /// The index passed is not a valid index.
        /// </summary>
        InvalidIndex,
        /// <summary>
        /// The number length exceeds the max length allowed (or 0).
        /// </summary>
        InvalidNumberLength,
        /// <summary>
        /// The name length exceeds the max length allowed (or 0).
        /// </summary>
        InvalidNameLength,
        /// <summary>
        /// Access condition for PB file is not satisfied.
        /// </summary>
        AccessConditionNotSatisfied
    }
}
