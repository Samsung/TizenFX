// Copyright (c) 2024 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Tizen.NUI.Visuals
{
    /// <summary>
    /// VisualObjectsContainer is a container for visual objects.
    /// For each VisualObjectContainer, there is a corresponding view.
    /// Each view can have only one VisualObjectsContainer per rangeType.
    /// </summary>
    /// <remarks>
    /// To avoid the collision between Dali toolkit logic and NUI specific policy,
    /// this container has an internal limitation of the number of visual objects.
    /// If user try to add visual object over the limitation, it will be ignored.
    /// </remarks>
    internal class VisualObjectsContainer : BaseHandle
    {
        private List<Tizen.NUI.Visuals.VisualBase> visuals = new List<Tizen.NUI.Visuals.VisualBase>(); // Keep visual object reference.

        /// <summary>
        /// Creates an empty visual object handle.
        /// </summary>
        public VisualObjectsContainer() : this(Interop.VisualObjectsContainer.NewVisualObjectsContainer(), true, false)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Creates an visual object with VisualObjectsContainer.
        /// </summary>
        public VisualObjectsContainer(Tizen.NUI.BaseComponents.View view, int rangeType) : this(Interop.VisualObjectsContainer.VisualObjectsContainerNew(Tizen.NUI.BaseComponents.View.getCPtr(view), rangeType), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal VisualObjectsContainer(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal VisualObjectsContainer(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        public Tizen.NUI.BaseComponents.View GetView()
        {
            global::System.IntPtr cPtr = Interop.VisualObjectsContainer.GetOwner(SwigCPtr);

            if (Interop.RefObject.GetRefObjectPtr(cPtr) == global::System.IntPtr.Zero)
            {
                // Visual container don't have owner. Return null.
                Interop.BaseHandle.DeleteBaseHandle(new global::System.Runtime.InteropServices.HandleRef(this, cPtr));
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            else
            {
                Tizen.NUI.BaseComponents.View ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Tizen.NUI.BaseComponents.View;
                if (ret != null)
                {
                    Interop.BaseHandle.DeleteBaseHandle(new global::System.Runtime.InteropServices.HandleRef(this, cPtr));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    return ret;
                }
                else
                {
                    ret = new Tizen.NUI.BaseComponents.View(cPtr, true);
                    return ret;
                }
            }
            return null;
        }

        public int GetContainerRangeType()
        {
            return Interop.VisualObjectsContainer.GetContainerRangeType(SwigCPtr);
        }

        public Tizen.NUI.Visuals.VisualBase this[uint index]
        {
            get
            {
                return GetVisualObjectAt(index);
            }
        }

        public uint GetVisualObjectsCount()
        {
            uint ret = Interop.VisualObjectsContainer.GetVisualObjectsCount(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        public bool AddVisualObject(Tizen.NUI.Visuals.VisualBase visualObject)
        {
            // Detach from previous container first.
            var previousContainer = visualObject.GetVisualContainer();
            if (previousContainer != null)
            {
                if (previousContainer == this)
                {
                    // Already added to this container.
                    return false;
                }
                visualObject.Detach();
            }

            visuals.Add(visualObject);

            bool ret = Interop.VisualObjectsContainer.AddVisualObject(SwigCPtr, Tizen.NUI.Visuals.VisualBase.getCPtr(visualObject));
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        public void RemoveVisualObject(Tizen.NUI.Visuals.VisualBase visualObject)
        {
            visuals.Remove(visualObject);

            Interop.VisualObjectsContainer.RemoveVisualObject(SwigCPtr, Tizen.NUI.Visuals.VisualBase.getCPtr(visualObject));
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        public Tizen.NUI.Visuals.VisualBase FindVisualObjectByName(string name)
        {
            Tizen.NUI.Visuals.VisualBase ret = null;
            if(!string.IsNullOrEmpty(name))
            {
                foreach (var visual in visuals)
                {
                    if (visual?.Name == name)
                    {
                        return visual;
                    }
                }
            }
            return ret;
        }

        private Tizen.NUI.Visuals.VisualBase GetVisualObjectAt(uint index)
        {
            global::System.IntPtr cPtr = Interop.VisualObjectsContainer.GetVisualObjectAt(SwigCPtr, index);
            Visuals.VisualBase ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Visuals.VisualBase;
            if (ret != null)
            {
                Interop.BaseHandle.DeleteBaseHandle(new global::System.Runtime.InteropServices.HandleRef(this, cPtr));
            }
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// Dispose for VisualObjectsContainer
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            base.Dispose(type);
        }
    }
}