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
    /// Specialized <see cref="MotionIndex"/> to control transform.
    /// It will be used when app developer doesn't care about Property index list,
    /// but want to change the transform properties anyway fast enough.
    /// </summary>
    /// <remarks>
    /// Each TransformTypes has their own matched <see cref="MotionValue"/> type.
    /// </remarks>
    /// <example>
    /// <code>
    /// MotionTransformIndex position = new MotionTransformIndex(new PropertyKey("nodeName"), MotionTransformIndex.TransformTypes.Position);
    ///
    /// // We can change the property later.
    /// MotionTransformIndex orientation = new MotionTransformIndex();
    /// orientation.ModelNodeId = new PropertyKey("nodeName");
    /// orientation.TransformType = MotionTransformIndex.TransformTypes.Orientation;
    /// </code>
    /// </example>
    /// <since_tizen> 11 </since_tizen>
    public class MotionTransformIndex : MotionIndex
    {
        /// <summary>
        /// The list of transform property types what this MotionTransformIndex can control.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public enum TransformTypes
        {
            /// <summary>
            /// Invalid type.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            Invalid = -1,

            /// <summary>
            /// The position of ModelNode. MotionValue should be Vector3.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            Position = 0,

            /// <summary>
            /// The x position of ModelNode. MotionValue should be float.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            PositionX,

            /// <summary>
            /// The y position of ModelNode. MotionValue should be float.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            PositionY,

            /// <summary>
            /// The z position of ModelNode. MotionValue should be float.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            PositionZ,

            /// <summary>
            /// The orientation of ModelNode. MotionValue should be Rotation.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            Orientation,

            /// <summary>
            /// The scale of ModelNode. MotionValue should be Vector3.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            Scale,

            /// <summary>
            /// The x scale of ModelNode. MotionValue should be float.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            ScaleX,

            /// <summary>
            /// The y scale of ModelNode. MotionValue should be float.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            ScaleY,

            /// <summary>
            /// The z scale of ModelNode. MotionValue should be float.
            /// </summary>
            /// <since_tizen> 11 </since_tizen>
            ScaleZ,
        }

        /// <summary>
        /// Create an initialized motion transform index.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public MotionTransformIndex() : this(Interop.MotionIndex.MotionTransformIndexNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized motion transform index with given node ID and transform type.
        /// </summary>
        /// <param name="modelNodeId">Node ID for this motion index</param>
        /// <param name="transformType">Transform property type for this motion index</param>
        /// <since_tizen> 11 </since_tizen>
        public MotionTransformIndex(PropertyKey modelNodeId, TransformTypes transformType) : this(Interop.MotionIndex.MotionTransformIndexNew(PropertyKey.getCPtr(modelNodeId), (int)transformType), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized motion transform index with given node string ID, and transform type.
        /// </summary>
        /// <param name="modelNodeName">Node string ID for this motion index</param>
        /// <param name="transformType">Transform property type for this motion index</param>
        /// <since_tizen> 11 </since_tizen>
        public MotionTransformIndex(string modelNodeName, TransformTypes transformType) : this(Interop.MotionIndex.MotionTransformIndexNew(PropertyKey.getCPtr(new PropertyKey(modelNodeName)), (int)transformType), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="motionTransformIndex">Source object to copy.</param>
        /// <since_tizen> 11 </since_tizen>
        public MotionTransformIndex(MotionTransformIndex motionTransformIndex) : this(Interop.MotionIndex.NewMotionTransformIndex(MotionTransformIndex.getCPtr(motionTransformIndex)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="motionTransformIndex">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal MotionTransformIndex Assign(MotionTransformIndex motionTransformIndex)
        {
            MotionTransformIndex ret = new MotionTransformIndex(Interop.MotionIndex.MotionTransformIndexAssign(SwigCPtr, MotionTransformIndex.getCPtr(motionTransformIndex)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal MotionTransformIndex(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal MotionTransformIndex(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        /// <summary>
        /// DownCast operator by raw pointer.
        /// </summary>
        /// <param name="sourceBaseHandleCPtr">Source object's cPtr to downcast.</param>
        /// <returns>DownCast object with memory ownership. Or null if failed</returns>
        internal static MotionTransformIndex DownCastCPtr(IntPtr sourceBaseHandleCPtr)
        {
            if (sourceBaseHandleCPtr == IntPtr.Zero)
            {
                return null;
            }

            var dummyObject = new object();
            var tempSourceSwigCPtr = new global::System.Runtime.InteropServices.HandleRef(dummyObject, sourceBaseHandleCPtr);
            IntPtr cPtr = Interop.MotionIndex.MotionTransformIndexDownCast(tempSourceSwigCPtr);
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
            MotionTransformIndex ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as MotionTransformIndex;
            if (ret == null)
            {
                // Register new MotionTransformIndex into Registry.
                ret = new MotionTransformIndex(cPtr, true);
            }
            else
            {
                // We found matched NUI MotionTransformIndex. Reduce cPtr reference count.
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
        /// The transform property type what this MotionIndex want to control.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public TransformTypes TransformType
        {
            get
            {
                return GetTransformType();
            }
            set
            {
                SetTransformType(value);
            }
        }

        internal void SetTransformType(TransformTypes transformType)
        {
            Interop.MotionIndex.SetTransformType(SwigCPtr, (int)transformType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TransformTypes GetTransformType()
        {
            int ret = Interop.MotionIndex.GetTransformType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return (TransformTypes)ret;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.MotionIndex.DeleteMotionTransformIndex(swigCPtr);
        }
    }
}
