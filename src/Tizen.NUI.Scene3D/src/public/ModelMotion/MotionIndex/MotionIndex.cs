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
using System.Collections.Generic;
using Tizen.NUI;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Index of motion value. It will be used to specify the target of motion applied.
    /// There are three kinds of MotionIndex : <see cref="MotionPropertyIndex"/>, <see cref="MotionTransformIndex"/> and <see cref="BlendShapeIndex"/>.
    /// MotionPropertyIndex will be used for control all kind of properties.
    /// The <see cref="MotionData"/> loaded from files / buffer will have this kind of MotionIndex.
    /// MotionTransformIndex will be used for control the <see cref="ModelNode"/>'s Position / Orientation / Scale, or each components.
    /// BlendShapeIndex will be used for control some blend shape animation.
    /// </summary>
    /// <remarks>
    /// We can use below cases.
    /// <table>
    ///  <tr><td>ModelNodeId KeyType</td><td>MotionIndex class                                 </td><td>Description                             </td></tr>
    ///  <tr><td>KeyType.String     </td><td>MotionTransformIndex                              </td><td>Target is ModelNode's transform property</td></tr>
    ///  <tr><td>KeyType.String     </td><td>BlendShapeIndex (with BlendShapeId KeyType.Index) </td><td>Target is ModelNode's BlendShape        </td></tr>
    ///  <tr><td>KeyType.String     </td><td>BlendShapeIndex (with BlendShapeId KeyType.String)</td><td>Target is ModelNode's BlendShape        </td></tr>
    ///  <tr><td>(null)             </td><td>BlendShapeIndex (with BlendShapeId KeyType.String)</td><td>Target is all ModelNode's BlendShape    </td></tr>
    /// </table>
    /// All other cases are invalid.
    /// </remarks>
    /// <since_tizen> 11 </since_tizen>
    public class MotionIndex : BaseHandle
    {
        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="motionIndex">Source object to copy.</param>
        /// <since_tizen> 11 </since_tizen>
        public MotionIndex(MotionIndex motionIndex) : this(Interop.MotionIndex.NewMotionIndex(MotionIndex.getCPtr(motionIndex)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="motionIndex">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal MotionIndex Assign(MotionIndex motionIndex)
        {
            MotionIndex ret = new MotionIndex(Interop.MotionIndex.MotionIndexAssign(SwigCPtr, MotionIndex.getCPtr(motionIndex)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal MotionIndex(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The ID of ModelNode. If you want to apply to all ModelNodes who has BlendShape string, assign null.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public PropertyKey ModelNodeId
        {
            get
            {
                return GetModelNodeId();
            }
            set
            {
                SetModelNodeId(value);
            }
        }

        internal void SetModelNodeId(PropertyKey modelNodeId)
        {
            Interop.MotionIndex.SetModelNodeId(SwigCPtr, Property.getCPtr(modelNodeId));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyKey GetModelNodeId()
        {
            IntPtr cPtr = Interop.MotionIndex.GetModelNodeId(SwigCPtr);
            PropertyKey ret = new PropertyKey(cPtr, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.MotionIndex.DeleteMotionIndex(swigCPtr);
        }
    }
}
