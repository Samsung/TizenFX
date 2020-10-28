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

using System.Collections.Generic;

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

    /// <summary>
    /// A class which defines phone book storage count information.
    /// </summary>
    public class PhonebookStorageInfo
    {
        internal PhonebookType PbType;
        internal ushort PbTotalRecord;
        internal ushort PbUsedRecord;
        internal PhonebookStorageInfo()
        {
        }

        /// <summary>
        /// Storage file type.
        /// </summary>
        /// <value>Type of phone book storage file.</value>
        public PhonebookType Type
        {
            get
            {
                return PbType;
            }
        }

        /// <summary>
        /// Total record count.
        /// </summary>
        /// <value>Count of total phonebook record.</value>
        public ushort TotalRecord
        {
            get
            {
                return PbTotalRecord;
            }
        }

        /// <summary>
        /// Used record count.
        /// </summary>
        /// <value>Number of used phonebook record.</value>
        public ushort UsedRecord
        {
            get
            {
                return PbUsedRecord;
            }
        }
    }

    /// <summary>
    /// A class which defines phone book entry information.
    /// </summary>
    public class PhonebookMetaInfo
    {
        internal PhonebookType MetaType;
        internal ushort MinIdx;
        internal ushort MaxIdx;
        internal ushort NumMaxLength;
        internal ushort TextMaxLen;
        internal ushort UsedRecCount;
        internal PhonebookMetaInfo()
        {
        }

        /// <summary>
        /// Storage file type.
        /// </summary>
        /// <value>Type of phonebook storage.</value>
        public PhonebookType Type
        {
            get
            {
                return MetaType;
            }
        }

        /// <summary>
        /// Phone book minimum index.
        /// </summary>
        /// <value>Minimum index value of the phone book record.</value>
        public ushort MinIndex
        {
            get
            {
                return MinIdx;
            }
        }

        /// <summary>
        /// Phone book maximum index.
        /// </summary>
        /// <value>Maximum index value of the phone book record.</value>
        public ushort MaxIndex
        {
            get
            {
                return MaxIdx;
            }
        }

        /// <summary>
        /// Phone number's maximum length
        /// </summary>
        /// <value>Maximum length of the phone number.</value>
        public ushort NumberMaxLength
        {
            get
            {
                return NumMaxLength;
            }
        }

        /// <summary>
        /// Text's maximum length.
        /// </summary>
        /// <value>Maximum length of the text.</value>
        public ushort TextMaxLength
        {
            get
            {
                return TextMaxLen;
            }
        }

        /// <summary>
        /// Phone book used record count.
        /// </summary>
        /// <value>Number of used phone book record.</value>
        public ushort UsedCount
        {
            get
            {
                return UsedRecCount;
            }
        }
    }

    /// <summary>
    /// A class which defines 3G phone book capability information.
    /// </summary>
    public class FileTypeCapabilityInfo3G
    {
        internal PhonebookFileType3G Type;
        internal ushort MaxIdx;
        internal ushort TextMaxLen;
        internal ushort UsedRecCount;
        internal FileTypeCapabilityInfo3G()
        {
        }

        /// <summary>
        /// 3G phonebook file type.
        /// </summary>
        /// <value>File type of the 3G phonebook.</value>
        public PhonebookFileType3G FileType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Max index.
        /// </summary>
        /// <value>Maximum index value present in 3G phonebook.</value>
        public ushort MaxIndex
        {
            get
            {
                return MaxIdx;
            }
        }

        /// <summary>
        /// Max text length.
        /// </summary>
        /// <value>Maximum text length in unsigned short.</value>
        public ushort TextMaxLength
        {
            get
            {
                return TextMaxLen;
            }
        }

        /// <summary>
        /// Used record count.
        /// </summary>
        /// <value>Number of used record in 3G phonebook.</value>
        public ushort UsedCount
        {
            get
            {
                return UsedRecCount;
            }
        }
    }

    /// <summary>
    /// A class which manages Sim phonebook and its capabilities information.
    /// </summary>
    public class PhonebookMetaInfo3G
    {
        internal ushort FileCount;
        internal IEnumerable<FileTypeCapabilityInfo3G> FileInfo;
        internal PhonebookMetaInfo3G()
        {
        }

        /// <summary>
        /// Phonebook file type count.
        /// </summary>
        /// <value>Filetype count of the 3G phonebook.</value>
        public ushort FileTypeCount
        {
            get
            {
                return FileCount;
            }
        }

        /// <summary>
        /// Phonebook file type information.
        /// </summary>
        /// <value>A list of FileTypeCapabilityInfo3G instances.</value>
        public IEnumerable<FileTypeCapabilityInfo3G> FileTypeInfo
        {
            get
            {
                return FileInfo;
            }
        }
    }

    /// <summary>
    /// A class which contains information about phonebook record.
    /// </summary>
    public class PhonebookRecord
    {
        private PhonebookType _type;
        private ushort _index;
        private ushort _nextIndex;
        private string _name;
        private TextEncryptionType _dcs;
        private string _number;
        private SimTypeOfNumber _ton;
        private string _sne;
        private TextEncryptionType _sneDcs;
        private string _anr1;
        private SimTypeOfNumber _anr1Ton;
        private string _anr2;
        private SimTypeOfNumber _anr2Ton;
        private string _anr3;
        private SimTypeOfNumber _anr3Ton;
        private string _email1;
        private string _email2;
        private string _email3;
        private string _email4;
        private ushort _groupIndex;
        private ushort _pbControl;

        /// <summary>
        /// Phonebook type.
        /// </summary>
        /// <value>Type of the phonebook used.</value>
        public PhonebookType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// Index.
        /// </summary>
        /// <value>Index value represented in unsigned short.</value>
        public ushort Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }

        /// <summary>
        /// Next index (This field is not used in the add/update case).
        /// </summary>
        /// <value>Next index represented in unsigned short.</value>
        public ushort NextIndex
        {
            get
            {
                return _nextIndex;
            }

            set
            {
                _nextIndex = value;
            }
        }

        /// <summary>
        /// Name.
        /// </summary>
        /// <value>Name in phonebook record.</value>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Dcs.
        /// </summary>
        /// <value>Sim encryption type.</value>
        public TextEncryptionType Dcs
        {
            get
            {
                return _dcs;
            }

            set
            {
                _dcs = value;
            }
        }

        /// <summary>
        /// Number.
        /// </summary>
        /// <value>Number in phonebook record.</value>
        public string Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        /// <summary>
        /// Ton.
        /// </summary>
        /// <value>Sim type of number.</value>
        public SimTypeOfNumber Ton
        {
            get
            {
                return _ton;
            }

            set
            {
                _ton = value;
            }
        }

        /// <summary>
        /// SNE(Second Name Entry).
        /// </summary>
        /// <value>Second name entry in byte array.</value>
        public string Sne
        {
            get
            {
                return _sne;
            }

            set
            {
                _sne = value;
            }
        }

        /// <summary>
        /// SNE DCS.
        /// </summary>
        /// <value>SNE text encryption type.</value>
        public TextEncryptionType SneDcs
        {
            get
            {
                return _sneDcs;
            }

            set
            {
                _sneDcs = value;
            }
        }

        /// <summary>
        /// Additional Number1.
        /// </summary>
        /// <value>Additional number1 represented in byte array.</value>
        public string Anr1
        {
            get
            {
                return _anr1;
            }

            set
            {
                _anr1 = value;
            }
        }

        /// <summary>
        /// ANR1 TON.
        /// </summary>
        /// <value>Additional number1 type of number.</value>
        public SimTypeOfNumber Anr1Ton
        {
            get
            {
                return _anr1Ton;
            }

            set
            {
                _anr1Ton = value;
            }
        }

        /// <summary>
        /// Additional Number2.
        /// </summary>
        /// <value>Additional number2 represented in byte array.</value>
        public string Anr2
        {
            get
            {
                return _anr2;
            }

            set
            {
                _anr2 = value;
            }
        }

        /// <summary>
        /// ANR2 TON.
        /// </summary>
        /// <value>Additional number2 type of number.</value>
        public SimTypeOfNumber Anr2Ton
        {
            get
            {
                return _anr2Ton;
            }

            set
            {
                _anr2Ton = value;
            }
        }

        /// <summary>
        /// Additional number3.
        /// </summary>
        /// <value>Additional number3 represented in byte array.</value>
        public string Anr3
        {
            get
            {
                return _anr3;
            }

            set
            {
                _anr3 = value;
            }
        }

        /// <summary>
        /// ANR3 TON.
        /// </summary>
        /// <value>Additional number3 type of number.</value>
        public SimTypeOfNumber Anr3Ton
        {
            get
            {
                return _anr3Ton;
            }

            set
            {
                _anr3Ton = value;
            }
        }

        /// <summary>
        /// Email1.
        /// </summary>
        /// <value>Email1 represented in byte array.</value>
        public string Email1
        {
            get
            {
                return _email1;
            }

            set
            {
                _email1 = value;
            }
        }

        /// <summary>
        /// Email2.
        /// </summary>
        /// <value>Email2 represented in byte array.</value>
        public string Email2
        {
            get
            {
                return _email2;
            }

            set
            {
                _email2 = value;
            }
        }

        /// <summary>
        /// Email3.
        /// </summary>
        /// <value>Email3 represented in byte array.</value>
        public string Email3
        {
            get
            {
                return _email3;
            }

            set
            {
                _email3 = value;
            }
        }

        /// <summary>
        /// Email4.
        /// </summary>
        /// <value>Email4 reprensented in byte array.</value>
        public string Email4
        {
            get
            {
                return _email4;
            }

            set
            {
                _email4 = value;
            }
        }

        /// <summary>
        /// Group index.
        /// </summary>
        /// <value>Group index represented in unsigned short.</value>
        public ushort GroupIndex
        {
            get
            {
                return _groupIndex;
            }

            set
            {
                _groupIndex = value;
            }
        }

        /// <summary>
        /// Phonebook control.
        /// </summary>
        /// <value>Phonebook control represented in unsigned short.</value>
        public ushort PbControl
        {
            get
            {
                return _pbControl;
            }

            set
            {
                _pbControl = value;
            }
        }
    }
}
