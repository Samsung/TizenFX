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

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A set of key frames for a property that can be animated using DALi animation.<br />
    /// This allows the generation of key frame objects from individual Property::Values.<br />
    /// </summary>
    /// <example><code>
    /// View view = new View()
    /// {
    ///     Size2D = new Size2D(100, 100),
    ///     Position2D = new Position2D(100, 100),
    ///     BackgroundColor = Color.Red,
    /// };
    ///
    /// Window.Default.Add(view);
    /// Animation animation = new Animation(5000); // 5s duration.
    /// KeyFrames keyFrames = new KeyFrames();
    /// keyFrames.Add(0.0f, new Rotation(new Radian(new Degree(-32.0f)), Vector3.ZAxis));
    /// keyFrames.Add(0.3f, new Rotation(new Radian(new Degree(133.0f)), Vector3.ZAxis));
    /// keyFrames.Add(0.75f, new Rotation(new Radian(new Degree(-12.0f)), Vector3.ZAxis));
    /// keyFrames.Add(1.0f, new Rotation(new Radian(new Degree(135.0f)), Vector3.ZAxis));
    /// animation.AnimateBetween(view, "Orientation", keyFrames);
    /// animation.Play();
    /// </code></example>
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
        [Obsolete("Deprecated in API13, will be removed in API15. Use AnimateBetween() alpha function instead.")]
        public void Add(float progress, object value, AlphaFunction alpha)
        {
            PropertyValue val = PropertyValue.CreateFromObject(value);
            Add(progress, val, alpha);
            val.Dispose();
        }

        /// <summary>
        /// Gets the type of the key frame.<br/>
        /// An empty key frame will return PropertyType.None, wheras an initialised<br/>
        /// key frame object will return the type of it's first element.
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
        [Obsolete("Deprecated in API13, will be removed in API15. Use AnimateBetween() alpha function instead.")]
        public void Add(float progress, PropertyValue value, AlphaFunction alpha)
        {
            Interop.KeyFrames.Add(SwigCPtr, progress, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the number of added key frame.
        /// </summary>
        /// <returns>The number of key frames currently added to the KeyFrames object.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetKeyFrameCount()
        {
            uint ret = Interop.KeyFrames.GetKeyFrameCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get the progress and value from specific key frame.<br/>
        /// If index is greater or equal than total key frame count, progress and value is not changed.
        /// </summary>
        /// <param name="index">The index of keyframe.</param>
        /// <param name="progress">A progress value between 0.0 and 1.0.</param>
        /// <param name="value">A value.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetKeyFrame(uint index, out float progress, PropertyValue value)
        {
            Interop.KeyFrames.GetKeyFrame(SwigCPtr, index, out progress, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set the value to specific key frame.<br/>
        /// If index is greater or equal than total key frame count or value's PropertyType is not matched, Nothing happened.
        /// </summary>
        /// <param name="index">The index of keyframe.</param>
        /// <param name="value">A value.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetKeyFrameValue(uint index, PropertyValue value)
        {
            Interop.KeyFrames.SetKeyFrameValue(SwigCPtr, index, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.KeyFrames.DeleteKeyFrames(swigCPtr);
        }
    }
}
