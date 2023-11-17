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
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// ModelNode is a class for representing the Node of Model in Scene3D.
    /// </summary>
    ///
    /// <remarks>
    /// ModelNode contains multiple ModelPrimitives and allows easy access and
    /// modification of Material information that ModelPrimitive has. If a 3D
    /// format file is loaded by Model, ModelNode is created internally to
    /// construct the model. In addition, you can create a Custom ModelNode
    /// using ModelPrimitive and Material directly and add it to Model.
    ///
    /// <code>
    /// ModelNode modelNode = new ModelNode();
    /// ModelPrimitive modelPrimitive = new ModelPrimitive();
    /// modelNode.AddModelPrimitive(modelPrimitive);
    ///
    /// Material material = new Material;
    /// modelPrimitive.Material = material;
    /// </code>
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ModelNode : View
    {
        internal ModelNode(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal ModelNode(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, true, cRegister)
        {
        }

        /// <summary>
        /// Create an initialized ModelNode.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelNode() : this(Interop.ModelNode.ModelNodeNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.PositionUsesPivotPoint = true;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="modelNode">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelNode(ModelNode modelNode) : this(Interop.ModelNode.NewModelNode(ModelNode.getCPtr(modelNode)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="modelNode">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal ModelNode Assign(ModelNode modelNode)
        {
            ModelNode ret = new ModelNode(Interop.ModelNode.ModelNodeAssign(SwigCPtr, ModelNode.getCPtr(modelNode)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            ret.PositionUsesPivotPoint = modelNode.PositionUsesPivotPoint;
            return ret;
        }

        /// <summary>
        /// Get the number of ModelPrimitive of this ModelNode.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ModelPrimitiveCount
        {
            get
            {
                return GetModelPrimitiveCount();
            }
        }

        /// <summary>
        /// Adds a ModelPrimitive object to the ModelNode object.
        /// </summary>
        /// <param name="modelPrimitive">The ModelPrimitive object to add.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddModelPrimitive(ModelPrimitive modelPrimitive)
        {
            Interop.ModelNode.AddModelPrimitive(SwigCPtr, ModelPrimitive.getCPtr(modelPrimitive));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a ModelPrimitive object from the ModelNode object.
        /// </summary>
        /// <param name="modelPrimitive">The ModelPrimitive object to remove.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveModelPrimitive(ModelPrimitive modelPrimitive)
        {
            Interop.ModelNode.RemoveModelPrimitive(SwigCPtr, ModelPrimitive.getCPtr(modelPrimitive));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a ModelPrimitive object from the ModelNode object at the specified index.
        /// </summary>
        /// <param name="index">The index of the ModelPrimitive object to remove.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveModelPrimitive(uint index)
        {
            Interop.ModelNode.RemoveModelPrimitive(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the ModelPrimitive object at the specified index.
        /// </summary>
        /// <param name="index">The index of the ModelPrimitive object to get.</param>
        /// <returns>The ModelPrimitive object at the specified index.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelPrimitive GetModelPrimitive(uint index)
        {
            global::System.IntPtr cPtr = Interop.ModelNode.GetModelPrimitive(SwigCPtr, index);
            ModelPrimitive ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ModelPrimitive;
            if (ret == null)
            {
                // Register new animatable into Registry.
                ret = new ModelPrimitive(cPtr, true);
            }
            else
            {
                // We found matched NUI animatable. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.BaseHandle.DeleteBaseHandle(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns a child ModelNode object with a name that matches nodeName.
        /// </summary>
        /// <param name="nodeName">The name of the child ModelNode object you want to find.</param>
        /// <returns>Child ModelNode that has nodeName as name.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelNode FindChildModelNodeByName(string nodeName)
        {
            global::System.IntPtr cPtr = Interop.Model.FindChildModelNodeByName(SwigCPtr, nodeName);
            ModelNode ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ModelNode;
            if (ret == null)
            {
                // Store the value of PositionUsesAnchorPoint from dali object (Since View object automatically change PositionUsesPivotPoint value as false, we need to keep value.)
                HandleRef handle = new HandleRef(this, cPtr);

                // Use original value as 'true' if we got invalid ModelNode.
                bool originalPositionUsesAnchorPoint = (cPtr == global::System.IntPtr.Zero || !Tizen.NUI.Interop.BaseHandle.HasBody(handle)) || Object.InternalGetPropertyBool(handle, View.Property.PositionUsesAnchorPoint);
                handle = new HandleRef(null, IntPtr.Zero);

                // Register new animatable into Registry.
                ret = new ModelNode(cPtr, true);
                if (ret != null)
                {
                    ret.PositionUsesPivotPoint = originalPositionUsesAnchorPoint;
                }
            }
            else
            {
                // We found matched NUI animatable. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.BaseHandle.DeleteBaseHandle(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the number of ModelPrimitive objects in the ModelNode object.
        /// </summary>
        /// <returns>The number of ModelPrimitive objects in the ModelNode object.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private uint GetModelPrimitiveCount()
        {
            uint ret = Interop.ModelNode.GetModelPrimitiveCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Build C# ModelNode Tree
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void Build()
        {
            List<ModelNode> childModelNodes = new List<ModelNode>();
            uint childModelNodeCount = GetChildModelNodeCount();
            for (uint i = 0; i < childModelNodeCount; ++i)
            {
                ModelNode modelNode = GetChildModelNodeAt(i);
                if (modelNode != null)
                {
                    childModelNodes.Add(modelNode);
                    modelNode.Build();
                }
            }

            foreach (ModelNode node in childModelNodes)
            {
                this.Add(node);
            }
        }

        /// <summary>
        /// Gets the number of child objects in the ModelNode object.
        /// </summary>
        /// <returns>The number of childchild objects in the ModelNode object.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private uint GetChildModelNodeCount()
        {
            uint ret = Interop.ModelNode.GetChildModelNodeCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns a child ModelNode object at the index.
        /// </summary>
        /// <param name="index">The index of child ModelNode object you want to find.</param>
        /// <returns>Child ModelNode</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private ModelNode GetChildModelNodeAt(uint index)
        {
            global::System.IntPtr cPtr = Interop.ModelNode.GetChildModelNodeAt(SwigCPtr, index);
            ModelNode ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ModelNode;
            if (ret == null)
            {
                // Store the value of PositionUsesAnchorPoint from dali object (Since View object automatically change PositionUsesPivotPoint value as false, we need to keep value.)
                HandleRef handle = new HandleRef(this, cPtr);

                // Use original value as 'true' if we got invalid ModelNode.
                bool originalPositionUsesAnchorPoint = (cPtr == global::System.IntPtr.Zero || !Tizen.NUI.Interop.BaseHandle.HasBody(handle)) || Object.InternalGetPropertyBool(handle, View.Property.PositionUsesAnchorPoint);
                handle = new HandleRef(null, IntPtr.Zero);

                // Register new animatable into Registry.
                ret = new ModelNode(cPtr, true);
                if (ret != null)
                {
                    ret.PositionUsesPivotPoint = originalPositionUsesAnchorPoint;
                }
            }
            else
            {
                // We found matched NUI animatable. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.BaseHandle.DeleteBaseHandle(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ModelNode.DeleteModelNode(swigCPtr);
        }
    }
}
