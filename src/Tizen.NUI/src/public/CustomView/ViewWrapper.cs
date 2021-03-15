/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// ViewWrapper.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ViewWrapper : View
    {
        internal ViewWrapperImpl viewWrapperImpl;

        internal ViewWrapper(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal ViewWrapper(string typeName, ViewWrapperImpl implementation) : this(Interop.ViewWrapper.New(typeName, ViewWrapperImpl.getCPtr(implementation)), true)
        {
            viewWrapperImpl = implementation;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ViewWrapper.DeleteViewWrapper(swigCPtr);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (viewWrapperImpl != null)
                {
                    viewWrapperImpl.OnSceneConnection = null;
                    viewWrapperImpl.OnSceneDisconnection = null;
                    viewWrapperImpl.OnStageConnection = null;
                    viewWrapperImpl.OnStageDisconnection = null;
                    viewWrapperImpl.OnChildAdd = null;
                    viewWrapperImpl.OnChildRemove = null;
                    viewWrapperImpl.OnPropertySet = null;
                    viewWrapperImpl.OnSizeSet = null;
                    viewWrapperImpl.OnSizeAnimation = null;
                    viewWrapperImpl.OnTouch = null;
                    viewWrapperImpl.OnHover = null;
                    viewWrapperImpl.OnKey = null;
                    viewWrapperImpl.OnWheel = null;
                    viewWrapperImpl.OnRelayout = null;
                    viewWrapperImpl.OnSetResizePolicy = null;
                    viewWrapperImpl.GetNaturalSize = null;
                    viewWrapperImpl.CalculateChildSize = null;
                    viewWrapperImpl.GetHeightForWidth = null;
                    viewWrapperImpl.GetWidthForHeight = null;
                    viewWrapperImpl.RelayoutDependentOnChildrenDimension = null;
                    viewWrapperImpl.RelayoutDependentOnChildren = null;
                    viewWrapperImpl.OnCalculateRelayoutSize = null;
                    viewWrapperImpl.OnLayoutNegotiated = null;
                    viewWrapperImpl.OnStyleChange = null;
                    viewWrapperImpl.OnAccessibilityActivated = null;
                    viewWrapperImpl.OnAccessibilityPan = null;
                    viewWrapperImpl.OnAccessibilityValueChange = null;
                    viewWrapperImpl.OnAccessibilityZoom = null;
                    viewWrapperImpl.OnFocusGained = null;
                    viewWrapperImpl.OnFocusLost = null;
                    viewWrapperImpl.GetNextFocusableView = null;
                    viewWrapperImpl.OnFocusChangeCommitted = null;
                    viewWrapperImpl.OnKeyboardEnter = null;
                    viewWrapperImpl.OnPinch = null;
                    viewWrapperImpl.OnPan = null;
                    viewWrapperImpl.OnTap = null;
                    viewWrapperImpl.OnLongPress = null;

                    viewWrapperImpl.Dispose();
                    viewWrapperImpl = null;
                }
            }

            base.Dispose(type);
        }
    }
}
