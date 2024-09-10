/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Panel is a control to show 2D UI on 3D Scene.
    /// 2D UI contents set on this Panel are rendered on a screen panel that is placed on 3D scene.
    /// Each Panel has a single plane with defined resolution.
    /// The plane is always placed at center to fit within the boundaries of the panel while maintaining the aspect ratio of the resolution.
    /// </summary>
    ///
    /// <remarks>
    /// 2D UI Content can be added on Panel, but the result that another 3D SceneView is added on Panel is not guaranteed.
    /// </remarks>
    ///
    /// <example>
    /// <code>
    /// View contentRoot = CreateUIContent();   // Create 2D UI Scene
    /// Panel panel = new Panel()
    /// {
    ///     Size = new Size(width, height),
    /// };
    /// panel.PanelResolution = new Vector2(resolutionWidth, resolutionHeight));
    /// panel.Content = contentRoot;
    /// </code>
    /// </example>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class Panel : View
    {
        internal Panel(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal Panel(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, true, cRegister)
        {
        }

        /// <summary>
        /// Create an initialized Panel.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Panel() : this(Interop.Panel.PanelNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.PositionUsesPivotPoint = true;
        }

        /// <summary>
        /// Resolution of the Panel.
        /// The resolution is independent from the Panel size property.
        /// The resolution defines a plane that the 2D UI scene will be rendered.
        /// And the shape of the panel plane is defined by aspect ratio of the input resolution.
        /// The plane is cleared by white color.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 PanelResolution
        {
            get
            {
                return GetPanelResolution();
            }
            set
            {
                SetPanelResolution(value);
            }
        }

        /// <summary>
        /// Root View of 2D UI content.
        /// The content is rendered on the plane of the Panel by using off screen rendering.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Content
        {
            get
            {
                return GetContent();
            }
            set
            {
                SetContent(value);
            }
        }

        /// <summary>
        /// Whether Transparent background is used or not. Default value is false
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Transparent
        {
            get
            {
                bool transparent = false;
                using var pValue = GetProperty(Interop.Panel.PropertyTransparentIndexGet());
                pValue?.Get(out transparent);
                pValue?.Dispose();
                return transparent;
            }
            set
            {
                using var transparent = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Panel.PropertyTransparentIndexGet(), transparent);
                transparent.Dispose();
            }
        }

        /// <summary>
        /// Whether the content is rendered as double sided or not.
        /// Default value is false.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DoubleSided
        {
            get
            {
                bool doubleSided = false;
                using var pValue = GetProperty(Interop.Panel.PropertyDoubleSidedIndexGet());
                pValue?.Get(out doubleSided);
                pValue?.Dispose();
                return doubleSided;
            }
            set
            {
                using var doubleSided = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Panel.PropertyDoubleSidedIndexGet(), doubleSided);
                doubleSided.Dispose();
            }
        }

        /// <summary>
        /// Whether to use back face plane or not.
        /// If this property is true, an opaque plane will be displayed when viewed from behind the Panel.
        /// Default value is true.
        /// Default back face plane color is white.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UsingBackFacePlane
        {
            get
            {
                bool isUsingBackFacePlane = true;
                using var pValue = GetProperty(Interop.Panel.PropertyUseBackFacePlaneIndexGet());
                pValue?.Get(out isUsingBackFacePlane);
                pValue?.Dispose();
                return isUsingBackFacePlane;
            }
            set
            {
                using var isUsingBackFacePlane = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Panel.PropertyUseBackFacePlaneIndexGet(), isUsingBackFacePlane);
                isUsingBackFacePlane.Dispose();
            }
        }

        /// <summary>
        /// Color of back face plane.
        /// Default color is white.
        /// </summary>
        /// <remarks>
        /// Because back face plane is always opaque, alpha channel is ignored.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color BackFacePlaneColor
        {
            get
            {
                Vector3 backFacePlaneColorVector3 = new Vector3(1.0f, 1.0f, 1.0f);
                using var pValue = GetProperty(Interop.Panel.PropertyBackFacePlaneColorIndexGet());
                pValue?.Get(backFacePlaneColorVector3);
                pValue?.Dispose();
                Color backFacePlaneColor = new Vector4(backFacePlaneColorVector3);
                backFacePlaneColor.A = 1.0f;
                return backFacePlaneColor;
            }
            set
            {
                Vector3 backFacePlaneColorVector3 = new Vector3(value.R, value.G, value.B);
                using var backFacePlaneColor = new Tizen.NUI.PropertyValue(backFacePlaneColorVector3);
                SetProperty(Interop.Panel.PropertyBackFacePlaneColorIndexGet(), backFacePlaneColor);
                backFacePlaneColor.Dispose();
            }
        }

        /// <summary>
        /// Whether this Panel casts shadow or not by directional light.
        /// If it is true, this panel is drawn on Shadow Map.
        /// Default value is true.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShadowCast
        {
            get
            {
                return IsShadowCasting();
            }
            set
            {
                CastShadow(value);
            }
        }

        /// <summary>
        /// Whether this Panel receives shadow or not by directional light.
        /// If it is true, shadows are drawn on this panel.
        /// Default value is true.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShadowReceive
        {
            get
            {
                return IsShadowReceiving();
            }
            set
            {
                ReceiveShadow(value);
            }
        }

        /// <summary>
        /// Sets whether this Panel casts shadow or not.
        /// If it is true, this panels is drawn on Shadow Map.
        /// </summary>
        /// <param name="castShadow">Whether this Panel casts shadow or not.</param>
        private void CastShadow(bool castShadow)
        {
            Interop.Panel.CastShadow(SwigCPtr, castShadow);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves whether the Panel casts shadow or not for Light.
        /// Note: IBL does not cast any shadow.
        /// </summary>
        /// <returns>True if this model casts shadow.</returns>
        private bool IsShadowCasting()
        {
            var isShadowCasting = Interop.Panel.IsShadowCasting(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return isShadowCasting;
        }

        /// <summary>
        /// Sets whether this Panel receives shadow or not.
        /// If it is true, shadows are drawn on this panel.
        /// </summary>
        /// <param name="receiveShadow">Whether this Panel receives shadow or not.</param>
        private void ReceiveShadow(bool receiveShadow)
        {
            Interop.Panel.ReceiveShadow(SwigCPtr, receiveShadow);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves whether the Panel receives shadow or not for Light
        /// If it is true, this model is drawn on Shadow Map.
        /// </summary>
        /// <returns>True if this model receives shadow.</returns>
        private bool IsShadowReceiving()
        {
            var isShadowReceiving = Interop.Panel.IsShadowReceiving(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return isShadowReceiving;
        }

        /// <summary>
        /// Sets defined resolution to the Panel.
        /// The resolution is independent from the Panel size property.
        /// The resolution defines a plane that the 2D UI scene will be rendered.
        /// And the shape of the panel plane is defined by aspect ratio of the input resolution.
        /// </summary>
        /// <param name="resolution">The resolution defines panel plane.</param>
        /// <returns>True if this model receives shadow.</returns>
        private void SetPanelResolution(Vector2 resolution)
        {
            Interop.Panel.SetPanelResolution(SwigCPtr, Vector2.getCPtr(resolution));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves panel resolution.
        /// </summary>
        /// <returns>Resolution of the panel plane.</returns>
        private Vector2 GetPanelResolution()
        {
            Vector2 resolution = new Vector2(Interop.Panel.GetPanelResolution(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return resolution;
        }

        /// <summary>
        /// Sets root Actor of 2D UI content.
        /// The content is rendered on the plane of the Panel by using off screen rendering.
        /// </summary>
        /// <param name="content">Root View of 2D UI content.</param>
        private void SetContent(View content)
        {
            Interop.Panel.SetContent(SwigCPtr, content.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves root View of 2D UI content.
        /// </summary>
        /// <returns>Root View of 2D UI content.</returns>
        private View GetContent()
        {
            IntPtr cPtr = Interop.Panel.GetContent(SwigCPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as View;
            if (ret != null)
            {
                NUI.Interop.BaseHandle.DeleteBaseHandle(new HandleRef(this, cPtr));
            }
            else
            {
                ret = new View(cPtr, true);
            }
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// To make transitionSet instance be disposed.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }
            base.Dispose(type);
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Panel.DeletePanel(swigCPtr);
        }
    }
}
