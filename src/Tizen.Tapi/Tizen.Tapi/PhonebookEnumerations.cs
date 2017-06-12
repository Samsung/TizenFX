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
}
