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
    /// Specialized <see cref="MotionIndex"/> to control blend shape.
    /// We can control the blend shape by index (when we set BlendShapeId as IndexKey),
    /// or by name (when we set BlendShapeId as StringKey).
    /// </summary>
    /// <remarks>
    /// <see cref="MotionValue"/> should be float type.
    /// </remarks>
    /// <example>
    /// <code>
    /// BlendShapeIndex blendShapeIndex0 = new BlendShapeIndex(new PropertyKey("nodeName"), new PropertyKey(0u));
    /// BlendShapeIndex blendShapeIndex1 = new BlendShapeIndex(new PropertyKey("nodeName"), new PropertyKey("Target_1"));
    ///
    /// // We can change the property later.
    /// BlendShapeIndex blendShapeIndex2 = new BlendShapeIndex;
    /// blendShapeIndex2.ModelNodeId = new PropertyKey("nodeName");
    /// blendShapeIndex2.BlendShapeId = new PropertyKey("Target_2");
    /// </code>
    /// </example>
    /// <example>
    /// Specially, if ModelNodeId is invalid and BlendShapeId is StringKey,
    /// It will control all ModelNode that has the inputed blend shape name.
    ///
    /// <code>
    /// // If "node0" and "node1" has same BlendShape named "Smile",
    /// // blendShapeIndexAll will control both nodes.
    /// BlendShapeIndex blendShapeIndexAll = new BlendShapeIndex(new PropertyKey("Smile"));
    ///
    /// BlendShapeIndex blendShapeIndex0 = new BlendShapeIndex(new PropertyKey("node0"), new PropertyKey("Smile"));
    /// BlendShapeIndex blendShapeIndex1 = new BlendShapeIndex(new PropertyKey("node1"), new PropertyKey("Smile"));
    /// </code>
    /// </example>
    /// <since_tizen> 11 </since_tizen>
    public class BlendShapeIndex : MotionIndex
    {
        /// <summary>
        /// Create an initialized blend shape index.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public BlendShapeIndex() : this(Interop.MotionIndex.BlendShapeIndexNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized blend shape index with invalid node ID, and given blend shape ID.
        /// </summary>
        /// <param name="blendShapeId">Blend shape ID for this motion index</param>
        /// <since_tizen> 11 </since_tizen>
        public BlendShapeIndex(PropertyKey blendShapeId) : this(Interop.MotionIndex.BlendShapeIndexNew(PropertyKey.getCPtr(blendShapeId)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized blend shape index with given node ID and blend shape ID.
        /// </summary>
        /// <param name="modelNodeId">Node ID for this motion index</param>
        /// <param name="blendShapeId">Blend shape ID for this motion index</param>
        /// <since_tizen> 11 </since_tizen>
        public BlendShapeIndex(PropertyKey modelNodeId, PropertyKey blendShapeId) : this(Interop.MotionIndex.BlendShapeIndexNew(PropertyKey.getCPtr(modelNodeId), PropertyKey.getCPtr(blendShapeId)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized blend shape index with invalid node ID, and given blend shape string ID.
        /// </summary>
        /// <param name="blendShapeName">Blend shape string ID for this motion index</param>
        /// <since_tizen> 11 </since_tizen>
        public BlendShapeIndex(string blendShapeName) : this(Interop.MotionIndex.BlendShapeIndexNew(PropertyKey.getCPtr(new PropertyKey(blendShapeName))), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized blend shape index with given node string ID and blend shape string ID.
        /// </summary>
        /// <param name="modelNodeName">Node string ID for this motion index</param>
        /// <param name="blendShapeName">Blend shape string ID for this motion index</param>
        /// <since_tizen> 11 </since_tizen>
        public BlendShapeIndex(string modelNodeName, string blendShapeName) : this(Interop.MotionIndex.BlendShapeIndexNew(PropertyKey.getCPtr(new PropertyKey(modelNodeName)), PropertyKey.getCPtr(new PropertyKey(blendShapeName))), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="blendShapeIndex">Source object to copy.</param>
        /// <since_tizen> 11 </since_tizen>
        public BlendShapeIndex(BlendShapeIndex blendShapeIndex) : this(Interop.MotionIndex.NewBlendShapeIndex(BlendShapeIndex.getCPtr(blendShapeIndex)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="blendShapeIndex">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal BlendShapeIndex Assign(BlendShapeIndex blendShapeIndex)
        {
            BlendShapeIndex ret = new BlendShapeIndex(Interop.MotionIndex.BlendShapeIndexAssign(SwigCPtr, BlendShapeIndex.getCPtr(blendShapeIndex)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal BlendShapeIndex(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal BlendShapeIndex(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        /// <summary>
        /// DownCast operator by raw pointer.
        /// </summary>
        /// <param name="sourceBaseHandleCPtr">Source object's cPtr to downcast.</param>
        /// <returns>DownCast object with memory ownership. Or null if failed</returns>
        internal static BlendShapeIndex DownCastCPtr(IntPtr sourceBaseHandleCPtr)
        {
            if (sourceBaseHandleCPtr == IntPtr.Zero)
            {
                return null;
            }

            var dummyObject = new object();
            var tempSourceSwigCPtr = new global::System.Runtime.InteropServices.HandleRef(dummyObject, sourceBaseHandleCPtr);
            IntPtr cPtr = Interop.MotionIndex.BlendShapeIndexDownCast(tempSourceSwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
            if (cPtr == IntPtr.Zero)
            {
                return null;
            }

            // Check whether it has body
            var tempSwigCPtr = new global::System.Runtime.InteropServices.HandleRef(dummyObject, cPtr);
            if (!Tizen.NUI.Interop.BaseHandle.HasBody(tempSwigCPtr))
            {
                Tizen.NUI.Interop.BaseHandle.DeleteBaseHandle(cPtr);
                return null;
            }

            // Check whether it is already registered
            BlendShapeIndex ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as BlendShapeIndex;
            if (ret == null)
            {
                // Register new BlendShapeIndex into Registry.
                ret = new BlendShapeIndex(cPtr, true);
            }
            else
            {
                // We found matched NUI BlendShapeIndex. Reduce cPtr reference count.
                Tizen.NUI.Interop.BaseHandle.DeleteBaseHandle(cPtr);
            }
            NDalicPINVOKE.ThrowExceptionIfExists();

            if (!ret.HasBody())
            {
                ret.Dispose();
                ret = null;
            }
            return ret;
        }

        /// <summary>
        /// The key of blend shape.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public PropertyKey BlendShapeId
        {
            get
            {
                return GetBlendShapeId();
            }
            set
            {
                SetBlendShapeId(value);
            }
        }

        internal void SetBlendShapeId(PropertyKey blendShapeId)
        {
            Interop.MotionIndex.SetBlendShapeId(SwigCPtr, Property.getCPtr(blendShapeId));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyKey GetBlendShapeId()
        {
            IntPtr cPtr = Interop.MotionIndex.GetBlendShapeId(SwigCPtr);
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
            Interop.MotionIndex.DeleteBlendShapeIndex(swigCPtr);
        }
    }
}
