/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A set of key frames for a property that can be animated using DALi animation.<br />
    /// This allows the generation of key frame objects from individual Property::Values.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class KeyFrames : BaseHandle
    {
        /// <summary>
        /// Creates an initialized KeyFrames handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public KeyFrames() : this(Interop.KeyFrames.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal KeyFrames(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Adds a key frame.
        /// </summary>
        /// <param name="progress">A progress value between 0.0 and 1.0.</param>
        /// <param name="value">A value.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Add(float progress, object value)
        {
            PropertyValue val = PropertyValue.CreateFromObject(value);
            Add(progress, val);
            val.Dispose();
        }

        /// <summary>
        /// Adds a key frame.
        /// </summary>
        /// <param name="progress">A progress value between 0.0 and 1.0.</param>
        /// <param name="value">A value</param>
        /// <param name="alpha">The alpha function used to blend to the next keyframe.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Add(float progress, object value, AlphaFunction alpha)
        {
            PropertyValue val = PropertyValue.CreateFromObject(value);
            Add(progress, val, alpha);
            val.Dispose();
        }

        /// <summary>
        /// Gets the type of the key frame.
        /// </summary>
        /// <returns>The key frame property type</returns>
        /// <since_tizen> 3 </since_tizen>
        public new PropertyType GetType()
        {
            PropertyType ret = (PropertyType)Interop.KeyFrames.GetType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds a key frame.
        /// </summary>
        /// <param name="progress">A progress value between 0.0 and 1.0.</param>
        /// <param name="value">A value.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Add(float progress, PropertyValue value)
        {
            Interop.KeyFrames.Add(SwigCPtr, progress, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds a key frame.
        /// </summary>
        /// <param name="progress">A progress value between 0.0 and 1.0.</param>
        /// <param name="value">A value.</param>
        /// <param name="alpha">The alpha function used to blend to the next keyframe.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Add(float progress, PropertyValue value, AlphaFunction alpha)
        {
            Interop.KeyFrames.Add(SwigCPtr, progress, PropertyValue.getCPtr(value), AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(KeyFrames obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.KeyFrames.DeleteKeyFrames(swigCPtr);
        }
    }
}
