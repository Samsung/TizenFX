/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// This should be internal, please do not use.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated in API6, Will be removed in API9, " +
        "Please do not use!" +
        "IntPtr(native integer pointer) is supposed to be not used in Application!")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SWIGTYPE_p_bundle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal SWIGTYPE_p_bundle(global::System.IntPtr cPtr)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// The Constructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected SWIGTYPE_p_bundle()
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }
    }
}
