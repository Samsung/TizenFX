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
    /// A class which defines the list of phone book availability of the current SIM.
    /// </summary>
    public class SimPhonebookList
    {
        internal int PbFdn;
        internal int PbAdn;
        internal int PbSdn;
        internal int PbUsim;
        internal int PbAas;
        internal int PbGas;

        internal SimPhonebookList()
        {
        }

        /// <summary>
        /// Fixed Dialing Number.
        /// </summary>
        /// <value>Fdn represented in integer format.</value>
        public int Fdn
        {
            get
            {
                return PbFdn;
            }
        }

        /// <summary>
        /// SIM - ADN(2G phonebook, Under DF phonebook).
        /// </summary>
        /// <value>Adn represented in integer format.</value>
        public int Adn
        {
            get
            {
                return PbAdn;
            }
        }

        /// <summary>
        /// Service Dialing Number.
        /// </summary>
        /// <value>Sdn represented in integer format.</value>
        public int Sdn
        {
            get
            {
                return PbSdn;
            }
        }

        /// <summary>
        /// USIM - 3G phonebook.
        /// </summary>
        /// <value>Usim represented in integer format.</value>
        public int Usim
        {
            get
            {
                return PbUsim;
            }
        }

        /// <summary>
        /// Additional number Alpha String phonebook.
        /// </summary>
        /// <value>Aas represented in integer format.</value>
        public int Aas
        {
            get
            {
                return PbAas;
            }
        }

        /// <summary>
        /// Grouping information Alpha String phonebook.
        /// </summary>
        /// <value>Gas represented in integer format.</value>
        public int Gas
        {
            get
            {
                return PbGas;
            }
        }
    }

    /// <summary>
    /// A class which defines phone book status of the current SIM.
    /// </summary>
    public class SimPhonebookStatus
    {
        internal bool InitStatus;
        internal SimPhonebookList List;

        internal SimPhonebookStatus()
        {
        }

        /// <summary>
        /// Init completed or not.
        /// </summary>
        /// <value>Boolean value to check the status of Init.</value>
        public bool IsInitCompleted
        {
            get
            {
                return InitStatus;
            }
        }

        /// <summary>
        /// List of phonebook.
        /// </summary>
        /// <value>An instance of SimPhonebookList containing the list of available phone book.</value>
        public SimPhonebookList PbList
        {
            get
            {
                return List;
            }
        }
    }

    /// <summary>
    /// A class which defines phonebook contact change information.
    /// </summary>
    public class PhonebookContactChangeInfo
    {
        internal PhonebookType PbType;
        internal ushort ChangedIndex;
        internal PhonebookOperationType OpType;

        internal PhonebookContactChangeInfo()
        {
        }

        /// <summary>
        /// Storage file type.
        /// </summary>
        /// <value>Type of phonebook storage represented as PhonebookType enum.</value>
        public PhonebookType Type
        {
            get
            {
                return PbType;
            }
        }

        /// <summary>
        /// Changed index.
        /// </summary>
        /// <value>Index value represented in unsigned short.</value>
        public ushort Index
        {
            get
            {
                return ChangedIndex;
            }
        }

        /// <summary>
        /// Phonebook operation.
        /// </summary>
        /// <value>Operation indicating the action on phonebook contact.</value>
        public PhonebookOperationType Operation
        {
            get
            {
                return OpType;
            }
        }
    }
}
