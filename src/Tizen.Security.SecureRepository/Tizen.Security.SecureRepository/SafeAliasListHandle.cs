/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Security.SecureRepository
{
    internal class SafeAliasListHandle : SafeHandle
    {
        public SafeAliasListHandle(IntPtr ptrAliases, bool ownsHandle = true) : base(IntPtr.Zero, ownsHandle)
        {
            base.SetHandle(ptrAliases);

            List<string> aliases = new List<string>();
            while (ptrAliases != IntPtr.Zero)
            {
                CkmcAliasList ckmcAliasList = Marshal.PtrToStructure<CkmcAliasList>(ptrAliases);
                aliases.Add(Marshal.PtrToStringAnsi(ckmcAliasList.alias));
                ptrAliases = ckmcAliasList.next;
            }

            this.Aliases = aliases;
        }

        public List<string> Aliases
        {
            get; set;
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            Interop.CkmcTypes.AliasListAllFree(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
