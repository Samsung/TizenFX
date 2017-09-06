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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a scoped buffer which lives shortly such as a callback.
    /// </summary>
    internal class ScopedMediaBuffer : MediaBufferBase, IDisposable
    {
        internal ScopedMediaBuffer(IntPtr dataHandle, int size, bool isReadOnly)
            : base(dataHandle, size, isReadOnly)
        {
        }

        internal ScopedMediaBuffer(IntPtr dataHandle, int size)
            : this(dataHandle, size, false)
        {
        }

        internal override void ValidateBufferReadable()
        {
            if (_disposed)
            {
                throw new InvalidOperationException("The buffer has already been invalidated.");
            }
        }

        internal override void ValidateBufferWritable() => ValidateBufferReadable();

        #region IDisposable Support
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed == false)
            {
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
