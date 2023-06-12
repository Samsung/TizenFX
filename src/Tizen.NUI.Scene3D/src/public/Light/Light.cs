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
    /// This class is to define 3D Light source.
    /// Currently this Light class supports Directional Light that lights every position from the same direction. (e.g, Sun light)
    /// If a Light object is added on SceneView, the 3D objects in the SceneView are shined the Light.
    /// NUI Scene3D limits the maximum enabled light count per each SceneView.
    /// Currently the maximum number is set to 5, and it can be retrieved by using <see cref="MaximumActivatedLightCount"/>.
    /// If more than 5 enabled Light objects are added on SceneView, SceneView turns on only 5 lights in the order the lights were added.
    /// This Light can be added to SceneView directly but also it can be added on other View.
    /// When a parent actor is added to a SceneView, its Light behaves in the SceneView the same as if it were added directly to the SceneView.
    /// </summary>
    /// <remarks>
    /// Light inherits View, so Light color and direction can be controlled by setting View's <see cref="View.Color"/> and <see cref="View.Orientation"/> Property.
    /// <see cref="View.LookAt(Vector3, Vector3, Vector3, Vector3)"/> method can be used to set light direction easily.
    /// </remarks>
    /// <remarks>
    /// Default light direction is to Z-axis
    /// </remarks>
    /// <example>
    /// <code>
    /// SceneView sceneView = new SceneView();
    /// Light light = new Light();
    /// light.Color = Color.Brown;
    /// light.LookAt(new Vector3(1.0f, 1.0f, 1.0f));
    /// sceneView.Add(light);
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Light : View
    {
        internal Light(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized Light.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Light() : this(Interop.Light.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="light">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Light(Light light) : this(Interop.Light.NewLight(Light.getCPtr(light)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Maximum Activated Light Count.
        /// It is possible to add more Lights to the SceneView than the Maximum Activated Light Count,
        /// but only up to the Maximum Activated Light Count Lights will work.
        /// </summary>
        /// <remarks>
        /// This property is read only.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MaximumActivatedLightCount
        {
            get
            {
                return Interop.Light.GetMaximumEnabledLightCount();
            }
        }

        /// <summary>
        /// The Light is turned on when the Light object is added on SceneView and enabled.
        /// And checks whether this light is enabled or not.
        /// </summary>
        /// <remarks>
        /// SceneView can turn on only up to maximum enabled light count that can be retrieved by GetMaximumEnabledLightCount().
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsLightEnabled
        {
            get
            {

                bool isEnabled = Interop.Light.IsEnabled(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return isEnabled;
            }
            set
            {
                Interop.Light.Enable(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
    }
}
