﻿/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.Applications.Cion
{
    internal sealed class SecuritySafeHandle : SafeHandle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SecuritySafeHandle() : base(IntPtr.Zero, true)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsInvalid
        {
            get { return this.DangerousGetHandle() == IntPtr.Zero; }
        }

        protected override bool ReleaseHandle()
        {
            Interop.CionSecurity.CionSecurityDestroy(this.handle);
            SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
