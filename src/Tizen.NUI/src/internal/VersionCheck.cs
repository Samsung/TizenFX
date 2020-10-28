/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    //This version should be updated and synced for every Dali native release
    internal static class Version
    {
        public const int daliVer1 = 1;
        public const int daliVer2 = 2;
        public const int daliVer3 = 83;
        public const int nuiVer1 = 1;
        public const int nuiVer2 = 2;
        public const int nuiVer3 = 83;
        public const string nuiRelease = "";


        static internal bool DaliVersionMatchWithNUI()
        {
            int ver1 = -1;
            int ver2 = -1;
            int ver3 = -1;

            try
            {
                if (NDalicManualPINVOKE.NativeVersionCheck(ref ver1, ref ver2, ref ver3))
                {
                    if (ver1 != daliVer1 || ver2 != daliVer2 || ver3 != daliVer3)
                    {
                        NUILog.Error($"Dali native version mismatch error! nui={ nuiVer1}.{ nuiVer2}.{ nuiVer3} but dali= { ver1 }.{ ver2}.{ ver3}");
                        throw new System.InvalidOperationException($"Dali native version mismatch error! nui={ nuiVer1}.{ nuiVer2}.{ nuiVer3} but dali={ ver1 }.{ ver2}.{ ver3}");
                    }
                }
                else
                {
                    NUILog.Error($"Dali native version mismatch error! nui={ nuiVer1}.{ nuiVer2}.{ nuiVer3} but dali= { ver1 }.{ ver2}.{ ver3}");
                    throw new System.InvalidOperationException($"Dali native version mismatch error! nui={ nuiVer1}.{ nuiVer2}.{ nuiVer3} but dali={ ver1 }.{ ver2}.{ ver3}");
                }
            }
            catch (Exception)
            {
                NUILog.Error($"Dali native version mismatch error! nui={ nuiVer1}.{ nuiVer2}.{ nuiVer3} but dali= { ver1 }.{ ver2}.{ ver3}");
                throw new System.InvalidOperationException($"Dali native version mismatch error! nui={ nuiVer1}.{ nuiVer2}.{ nuiVer3} but dali={ ver1 }.{ ver2}.{ ver3}");
            }
            NUILog.Debug($"version info: nui={ nuiVer1}.{ nuiVer2}.{ nuiVer3}, dali= { ver1 }.{ ver2}.{ ver3}");
            return true;
        }
    }
}
