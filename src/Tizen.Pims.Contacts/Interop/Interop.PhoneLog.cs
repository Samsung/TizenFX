﻿/*
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

/// <summary>
/// The Partial Interop class.
/// </summary>
internal static partial class Interop
{
    internal static class PhoneLog
    {
        [DllImport(Libraries.Contacts, EntryPoint = "contacts_phone_log_reset_statistics")]
        internal static extern int resetStatistics();

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_phone_log_reset_statistics_by_sim")]
        internal static extern int resetStatisticsBySim(int simSlotNo);
    }
}
