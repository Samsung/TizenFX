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

using System.Runtime.InteropServices;

namespace Tizen.Tapi
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct PhonebookRecordStruct
    {
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

        internal static PhonebookContactChangeInfo ConvertPhonebookContactChangeStruct(PhonebookContactChangeInfoStruct infoStruct)
        {
            PhonebookContactChangeInfo info = new PhonebookContactChangeInfo();
            info.PbType = infoStruct.Type;
            info.ChangedIndex = infoStruct.Index;
            info.OpType = infoStruct.Operation;
            return info;
        }
    }
}
