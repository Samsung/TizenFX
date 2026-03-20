/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.CoreBackend
{
    public abstract class TeamCoreBackend : DefaultCoreBackend
    {
        protected IntPtr _memberHandle = IntPtr.Zero;
        protected IntPtr _loadObjId = IntPtr.Zero;
        protected IntPtr _argHandle = IntPtr.Zero;
        internal abstract IntPtr MemberHandle { get; }
        internal abstract IntPtr LoadObjId { get; }
        internal abstract IntPtr ArgHandle { get; }
    }
}
