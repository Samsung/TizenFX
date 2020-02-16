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
    internal class SafeAliasContainerHandle<T> where T : ICollection<string>, new() 
    {
        public SafeAliasContainerHandle(IntPtr ptr)
        {
            var cur = ptr;
            var aliases = new T();
            while (cur != IntPtr.Zero)
            {
                var ckmcAliasList = Marshal.PtrToStructure<Interop.CkmcAliasList>(cur);
                aliases.Add(Marshal.PtrToStringAnsi(ckmcAliasList.alias));
                cur = ckmcAliasList.next;
            }

            this.Aliases = aliases;
        }

        public T Aliases
        {
            get; set;
        }
    }
    internal class SafeAliasListHandle : SafeAliasContainerHandle<List<string>>
    {
        public SafeAliasListHandle(IntPtr ptr) : base(ptr)
        {
        }
    }
}
