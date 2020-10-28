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

using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace Tizen.Tapi
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct PhonebookRecordStruct
    {
        internal PhonebookType Type;
        internal ushort Index;
        internal ushort NextIndex;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Name;
        internal TextEncryptionType Dcs;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Number;
        internal SimTypeOfNumber Ton;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Sne;
        internal TextEncryptionType SneDcs;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Anr1;
        internal SimTypeOfNumber Anr1Ton;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Anr2;
        internal SimTypeOfNumber Anr2Ton;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Anr3;
        internal SimTypeOfNumber Anr3Ton;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Email1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Email2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Email3;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Email4;
        internal ushort GroupIndex;
        internal ushort PbControl;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimPhonebookListStruct
    {
        internal int Fdn;
        internal int Adn;
        internal int Sdn;
        internal int Usim;
        internal int Aas;
        internal int Gas;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimPhonebookStatusStruct
    {
        internal int IsInitCompleted;
        internal SimPhonebookListStruct PbList;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PhonebookContactChangeInfoStruct
    {
        internal PhonebookType Type;
        internal ushort Index;
        internal PhonebookOperationType Operation;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PhonebookStorageInfoStruct
    {
        internal PhonebookType Type;
        internal ushort TotalRecord;
        internal ushort UsedRecord;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PhonebookMetaInfoStruct
    {
        internal PhonebookType Type;
        internal ushort MinIndex;
        internal ushort MaxIndex;
        internal ushort NumMaxLength;
        internal ushort TextMaxLength;
        internal ushort UsedCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FileTypeCapabilityInfo3GStruct
    {
        internal PhonebookFileType3G FileType;
        internal ushort MaxIndex;
        internal ushort MaxTextLen;
        internal ushort UsedCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PhonebookMetaInfo3GStruct
    {
        internal ushort FileTypeCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13, ArraySubType = UnmanagedType.LPStruct)]
        internal FileTypeCapabilityInfo3GStruct[] FileTypeInfo;
    }

    internal static class PhonebookStructConversions
    {
        internal static SimPhonebookList ConvertSimPhonebookListStruct(SimPhonebookListStruct listStruct)
        {
            SimPhonebookList list = new SimPhonebookList();
            list.PbFdn = listStruct.Fdn;
            list.PbAdn = listStruct.Adn;
            list.PbSdn = listStruct.Sdn;
            list.PbUsim = listStruct.Usim;
            list.PbAas = listStruct.Aas;
            list.PbGas = listStruct.Gas;
            return list;
        }

        internal static SimPhonebookStatus ConvertSimPhonebookStatusStruct(SimPhonebookStatusStruct statusStruct)
        {
            SimPhonebookStatus status = new SimPhonebookStatus();
            if (statusStruct.IsInitCompleted == 1)
            {
                status.InitStatus = true;
            }

            else if (statusStruct.IsInitCompleted == 0)
            {
                status.InitStatus = false;
            }

            status.List = ConvertSimPhonebookListStruct(statusStruct.PbList);
            return status;
        }

        internal static PhonebookStorageInfo ConvertPhonebookStorageStruct(PhonebookStorageInfoStruct storageStruct)
        {
            PhonebookStorageInfo storageInfo = new PhonebookStorageInfo();
            storageInfo.PbType = storageStruct.Type;
            storageInfo.PbTotalRecord = storageStruct.TotalRecord;
            storageInfo.PbUsedRecord = storageStruct.UsedRecord;
            return storageInfo;
        }

        internal static PhonebookMetaInfo ConvertPhonebookMetaInfoStruct(PhonebookMetaInfoStruct metaStruct)
        {
            PhonebookMetaInfo info = new PhonebookMetaInfo();
            info.MetaType = metaStruct.Type;
            info.MinIdx = metaStruct.MinIndex;
            info.MaxIdx = metaStruct.MaxIndex;
            info.NumMaxLength = metaStruct.NumMaxLength;
            info.TextMaxLen = metaStruct.TextMaxLength;
            info.UsedRecCount = metaStruct.UsedCount;
            return info;
        }

        internal static FileTypeCapabilityInfo3G ConvertFileTypeCapabilityInfo3GStruct(FileTypeCapabilityInfo3GStruct infoStruct)
        {
            FileTypeCapabilityInfo3G info = new FileTypeCapabilityInfo3G();
            info.Type = infoStruct.FileType;
            info.MaxIdx = infoStruct.MaxIndex;
            info.TextMaxLen = infoStruct.MaxTextLen;
            info.UsedRecCount = infoStruct.UsedCount;
            return info;
        }

        internal static PhonebookMetaInfo3G ConvertPhonebookMetaInfo3GStruct(PhonebookMetaInfo3GStruct infoStruct)
        {
            PhonebookMetaInfo3G info = new PhonebookMetaInfo3G();
            info.FileCount = infoStruct.FileTypeCount;
            List<FileTypeCapabilityInfo3G> capabilityList = new List<FileTypeCapabilityInfo3G>();
            foreach (FileTypeCapabilityInfo3GStruct capabilityInfo in infoStruct.FileTypeInfo)
            {
                capabilityList.Add(ConvertFileTypeCapabilityInfo3GStruct(capabilityInfo));
            }

            info.FileInfo = capabilityList;
            return info;
        }

        internal static PhonebookContactChangeInfo ConvertPhonebookContactChangeStruct(PhonebookContactChangeInfoStruct infoStruct)
        {
            PhonebookContactChangeInfo info = new PhonebookContactChangeInfo();
            info.PbType = infoStruct.Type;
            info.ChangedIndex = infoStruct.Index;
            info.OpType = infoStruct.Operation;
            return info;
        }

        internal static PhonebookRecord ConvertPhonebookRecordStruct(PhonebookRecordStruct recordStruct)
        {
            PhonebookRecord record = new PhonebookRecord();
            record.Type = recordStruct.Type;
            record.Index = recordStruct.Index;
            record.NextIndex = recordStruct.NextIndex;
            record.Name = recordStruct.Name;
            record.Dcs = recordStruct.Dcs;
            record.Number = recordStruct.Number;
            record.Ton = recordStruct.Ton;
            record.Sne = recordStruct.Sne;
            record.SneDcs = recordStruct.SneDcs;
            record.Anr1 = recordStruct.Anr1;
            record.Anr1Ton = recordStruct.Anr1Ton;
            record.Anr2 = recordStruct.Anr2;
            record.Anr2Ton = recordStruct.Anr2Ton;
            record.Anr3 = recordStruct.Anr3;
            record.Anr3Ton = recordStruct.Anr3Ton;
            record.Email1 = recordStruct.Email1;
            record.Email2 = recordStruct.Email2;
            record.Email3 = recordStruct.Email3;
            record.Email4 = recordStruct.Email4;
            record.GroupIndex = recordStruct.GroupIndex;
            record.PbControl = recordStruct.PbControl;
            return record;
        }
    }

    internal static class PhonebookClassConversions
    {
        internal static PhonebookRecordStruct ConvertPhonebookrecord(PhonebookRecord record)
        {
            PhonebookRecordStruct recordStruct = new PhonebookRecordStruct();
            recordStruct.Type = record.Type;
            recordStruct.Index = record.Index;
            recordStruct.NextIndex = record.NextIndex;
            recordStruct.Name = record.Name;
            recordStruct.Dcs = record.Dcs;
            recordStruct.Number = record.Number;
            recordStruct.Ton = record.Ton;
            recordStruct.Sne = record.Sne;
            recordStruct.SneDcs = record.SneDcs;
            recordStruct.Anr1 = record.Anr1;
            recordStruct.Anr1Ton = record.Anr1Ton;
            recordStruct.Anr2 = record.Anr2;
            recordStruct.Anr2Ton = record.Anr2Ton;
            recordStruct.Anr3 = record.Anr3;
            recordStruct.Anr3Ton = record.Anr3Ton;
            recordStruct.Email1 = record.Email1;
            recordStruct.Email2 = record.Email2;
            recordStruct.Email3 = record.Email3;
            recordStruct.Email4 = record.Email4;
            recordStruct.GroupIndex = record.GroupIndex;
            recordStruct.PbControl = record.PbControl;
            return recordStruct;
        }
    }
}
