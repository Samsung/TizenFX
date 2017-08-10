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

internal static partial class Interop
{
    internal static partial class PhonenumberUtils
    {
        [DllImport(Libraries.PhonenumberUtils, EntryPoint = "phone_number_connect")]
        internal static extern int Connect();

        [DllImport(Libraries.PhonenumberUtils, EntryPoint = "phone_number_disconnect")]
        internal static extern int Disconnect();

        [DllImport(Libraries.PhonenumberUtils, EntryPoint = "phone_number_get_location_from_number")]
        internal static extern int GetLocationFromNumber(string number, int region, int language, out string location);

        [DllImport(Libraries.PhonenumberUtils, EntryPoint = "phone_number_get_formatted_number")]
        internal static extern int GetFormmatedNumber(string number, int region, out string normalizedNumber);

        [DllImport(Libraries.PhonenumberUtils, EntryPoint = "phone_number_get_normalized_number")]
        internal static extern int GetNormailizedNumber(string number, out string normalizedNumber);
    }
}
