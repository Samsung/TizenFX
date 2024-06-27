/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Tizen.NUI.WindowSystem.Interop.InputGesture;

namespace Tizen.NUI.WindowSystem
{
    /// <summary>
    /// Represents a wrapper class for a unmanaged gesture handle.
    /// </summary>
    public sealed class SafeGestureHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the SafeGestureHandle class.
        /// </summary>
        public SafeGestureHandle(IntPtr handle)
            : base(IntPtr.Zero, true)
        {
            SetHandle(handle);
        }
        /// <summary>
        /// Initializes a new instance of the SafeGestureHandle class.
        /// </summary>
        public SafeGestureHandle()
            : base(IntPtr.Zero, true)
        {
        }
        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }
        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
    /// <summary>
    /// Represents a wrapper class for a unmanaged gesture data handle.
    /// </summary>
    public sealed class SafeGestureDataHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the SafeGestureHandle class.
        /// </summary>
        public SafeGestureDataHandle(IntPtr handle)
            : base(IntPtr.Zero, true)
        {
            SetHandle(handle);
        }
        /// <summary>
        /// Initializes a new instance of the SafeGestureHandle class.
        /// </summary>
        public SafeGestureDataHandle()
            : base(IntPtr.Zero, true)
        {
        }
        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }
        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}