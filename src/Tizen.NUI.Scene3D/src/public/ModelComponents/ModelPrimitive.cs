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
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Class for Model Primitives for 3D Geometry and Material.
    /// </summary>
    ///
    /// <remarks>
    /// This ModelPrimitive class is required to draw the mesh geometry defined by the user.
    /// Users can set Geometry and Material to ModelPrimitive.
    /// When ModelPrimitive added to ModelNode using ModelNode.AddModelPrimitive() method,
    /// the Geometry is rendered on the screen according to the Material settings.
    ///
    /// If you load resources from 3D format files such as glTF using Model class,
    /// ModelPrimitive is also created internally. In this case, blendShape morphing
    /// or skeletal animation defined in the format can be used.
    /// However, for the custom ModelPrimitive that is created by user, blendShape morphing or skeletal animation is not supported.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ModelPrimitive : BaseHandle
    {
        internal ModelPrimitive(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal ModelPrimitive(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        /// <summary>
        /// Create an initialized ModelPrimitive.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelPrimitive() : this(Interop.ModelPrimitive.ModelPrimitiveNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="modelPrimitive">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelPrimitive(ModelPrimitive modelPrimitive) : this(Interop.ModelPrimitive.NewModelPrimitive(ModelPrimitive.getCPtr(modelPrimitive)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="modelPrimitive">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal ModelPrimitive Assign(ModelPrimitive modelPrimitive)
        {
            ModelPrimitive ret = new ModelPrimitive(Interop.ModelPrimitive.ModelPrimitiveAssign(SwigCPtr, ModelPrimitive.getCPtr(modelPrimitive)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The Geometry object of the ModelNode object.
        /// </summary>
        /// <remarks>
        /// This Geometry object is for setting Geometry properties of 3D models. Also, Geometry can be shared with multiple ModelPrimitives and if the value is modified, the rendering results of all ModelPrimitives using this Geometry will be changed.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Geometry Geometry
        {
            set
            {
                SetGeometry(value);
            }
            get
            {
                return GetGeometry();
            }
        }

        /// <summary>
        /// The Material object of the ModelNode object.
        /// </summary>
        /// <remarks>
        /// This Material object is for setting Material properties of 3D models. Also, Material can be shared with multiple ModelPrimitives and if the value is modified, the rendering results of all ModelPrimitives using this Material will be changed.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Material Material
        {
            set
            {
                SetMaterial(value);
            }
            get
            {
                return GetMaterial();
            }
        }

        /// <summary>
        /// Sets the geometry of the ModelPrimitive object.
        /// </summary>
        /// <param name="geometry">The Geometry object to set.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void SetGeometry(Geometry geometry)
        {
            Interop.ModelPrimitive.SetGeometry(SwigCPtr, Geometry.getCPtr(geometry));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the geometry of the ModelPrimitive object.
        /// </summary>
        /// <returns>The Geometry object of the ModelPrimitive object.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Geometry GetGeometry()
        {
            IntPtr cPtr = Interop.ModelPrimitive.GetGeometry(SwigCPtr);
            Geometry ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Geometry;
            if (ret == null)
            {
                HandleRef handle = new HandleRef(this, cPtr);
                handle = new HandleRef(null, IntPtr.Zero);

                ret = new Geometry(cPtr, true);
            }
            else
            {
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.BaseHandle.DeleteBaseHandle(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the material of the ModelPrimitive object.
        /// </summary>
        /// <param name="material">The Material object to set.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void SetMaterial(Material material)
        {
            Interop.ModelPrimitive.SetMaterial(SwigCPtr, Material.getCPtr(material));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the material of the ModelPrimitive object.
        /// </summary>
        /// <returns>The Material object of the ModelPrimitive object.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Material GetMaterial()
        {
            global::System.IntPtr cPtr = Interop.ModelPrimitive.GetMaterial(SwigCPtr);
            Material ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Material;
            if (ret == null)
            {
                HandleRef handle = new HandleRef(this, cPtr);
                handle = new HandleRef(null, IntPtr.Zero);

                ret = new Material(cPtr, true);
            }
            else
            {
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
            Interop.ModelPrimitive.DeleteModelPrimitive(swigCPtr);
        }
    }
}
