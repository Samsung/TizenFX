/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Diagnostics;

namespace Tizen.NUI
{
    //This version should be updated and synced for every Dali native release
    internal static class Version
    {
        //from dali_1.3.23 : NUI internal API version 501
        //from dali_1.3.28 : NUI internal API version 502
        //from dali_1.3.34 : NUI internal API version 503
        //from dali_1.3.41 : NUI internal API version 504
        //from dali_1.3.48 : NUI internal API version 505
        public const int nuiAPIVer = 505;
        public const int reservedVer1 = 0;
        public const int reservedVer2 = 0;

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeVersionCheck")]
        public static extern bool NativeVersionCheck(ref int ver1, ref int ver2, ref int ver3);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_NUI_InternalAPIVersionCheck")]
        public static extern bool InternalAPIVersionCheck(ref int ver1, ref int ver2, ref int ver3);

        static internal bool DaliVersionMatchWithNUI()
        {
            int ver1 = -1;
            int ver2 = -1;
            int ver3 = -1;

            try
            {
                if (InternalAPIVersionCheck(ref ver1, ref ver2, ref ver3) == true)
                {
                    if (ver1 != nuiAPIVer)
                    {
                        NUILog.Error($"NUI API version mismatch error! NUI API Version: ({nuiAPIVer}) but read version from native: ({ver1}.{ver2}.{ver3})");
                        throw new System.InvalidOperationException($"NUI API version mismatch error! NUI API version should be ({nuiAPIVer}) but read version from native: ({ver1}.{ver2}.{ver3})");
                    }
                }
                else
                {
                    NUILog.Error($"NUI API version mismatch error! NUI API Version: ({nuiAPIVer}) but read version from native: ({ver1}.{ver2}.{ver3})");
                    throw new System.InvalidOperationException($"NUI API version mismatch error! NUI API version should be ({nuiAPIVer}) but read version from native: ({ver1}.{ver2}.{ver3})");
                }
            }
            catch (Exception)
            {
                NUILog.Error($"NUI API version mismatch error! NUI API Version: ({nuiAPIVer}) but read version from native: ({ver1}.{ver2}.{ver3})");
                throw new System.InvalidOperationException($"NUI API version mismatch error! NUI API version should be ({nuiAPIVer}) but read version from native: ({ver1}.{ver2}.{ver3})");
            }

            PrintDaliNativeVersion();
            return true;
        }

        //[Conditional("DEBUG_ON")]
        static internal void PrintDaliNativeVersion()
        {
            int ver1 = -1;
            int ver2 = -1;
            int ver3 = -1;

            NativeVersionCheck(ref ver1, ref ver2, ref ver3);
            //NUILog.Debug($"DALi Version: ({ver1}.{ver2}.{ver3}), NUI API Version: ({nuiAPIVer})");
            NUILog.Error($"NOT Error! Just Showing DALi Version: ({ver1}.{ver2}.{ver3}), NUI API Version: ({nuiAPIVer})");
        }
    }
}
