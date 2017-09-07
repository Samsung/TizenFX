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

using System;
using System.Diagnostics;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a buffer that is dependent on the owner object.
    /// </summary>
    internal class DependentMediaBuffer : MediaBufferBase
    {
        private readonly IBufferOwner _owner;

        internal DependentMediaBuffer(IBufferOwner owner, IntPtr dataHandle, int size)
            : base(dataHandle, size)
        {
            Debug.Assert(owner != null, "Owner is null!");
            Debug.Assert(!owner.IsDisposed, "Owner has been already disposed!");

            _owner = owner;
        }

        internal override void ValidateBufferReadable()
        {
            _owner.ValidateBufferReadable(this);
        }

        internal override void ValidateBufferWritable()
        {
            _owner.ValidateBufferWritable(this);
        }
    }
}
