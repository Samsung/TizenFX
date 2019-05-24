/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Xaml.Forms.BaseComponents;
using System.ComponentModel;
using Tizen.NUI;

namespace Tizen.NUI.Xaml.Forms
{
    /// <summary>
    /// Layers provide a mechanism for overlaying groups of actors on top of each other.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Layer : Container
    {
        private Tizen.NUI.Layer _layer;
        private Tizen.NUI.Layer layer
        {
            get
            {
                if (null == _layer)
                {
                    _layer = handleInstance as Tizen.NUI.Layer;
                }

                return _layer;
            }
        }

        /// <summary>
        /// Creates a Xaml Layer object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Layer() : this(new Tizen.NUI.Layer())
        {
        }

        internal Layer(Tizen.NUI.Layer nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// <summary>
        /// Layer behavior, type String (Layer.LayerBehavior).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.Layer.LayerBehavior Behavior
        {
            get
            {
                return layer.Behavior;
            }
            set
            {
                layer.Behavior = value;
            }
        }

        /// <summary>
        /// Sets the viewport (in window coordinates), type rectangle.
        /// The contents of the layer will not be visible outside this box, when ViewportEnabled is true.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Rectangle Viewport
        {
            get
            {
                return layer.Viewport;
            }
            set
            {
                layer.Viewport = value;
            }
        }

        /// <summary>
        /// Retrieves and sets the layer's opacity.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Opacity
        {
            get
            {
                return layer.Opacity;
            }
            set
            {
                layer.Opacity = value;
            }
        }

        /// <summary>
        /// Retrieves and sets the layer's visibility.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Visibility
        {
            get
            {
                return layer.Visibility;
            }
            set
            {
                layer.Visibility = value;
            }
        }

        /// <summary>
        /// Get the number of children held by the layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new uint ChildCount
        {
            get
            {
                return Convert.ToUInt32(layer.Children.Count);
            }
        }

        /// <summary>
        /// Gets or sets the layer's name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            get
            {
                return layer.Name;
            }
            set
            {
                layer.Name = value;
            }
        }

        /// <summary>
        /// Queries the depth of the layer.<br />
        /// 0 is the bottommost layer, higher number is on the top.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Depth
        {
            get
            {
                return layer.Depth;
            }
        }

        /// From the Container base class.

        /// <summary>
        /// Adds a child view to this layer.
        /// </summary>
        /// <seealso cref="Container.Add">
        /// </seealso>
        /// <since_tizen> 4 </since_tizen>
        public override void Add(View child)
        {
            layer.Add(child.view);
        }

        /// <summary>
        /// Removes a child view from this layer. If the view was not a child of this layer, this is a no-op.
        /// </summary>
        /// <seealso cref="Container.Remove">
        /// </seealso>
        /// <since_tizen> 4 </since_tizen>
        public override void Remove(View child)
        {
            layer.Remove(child.view);
        }

        /// <summary>
        /// Retrieves a child view by the index.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <returns>The view for the given index or empty handle if children not initialized.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override View GetChildAt(uint index)
        {
            Tizen.NUI.BaseComponents.View ret = layer.GetChildAt(index);
            return BaseHandle.GetHandle(ret) as View;
        }

        /// <summary>
        /// Get parent of the layer.
        /// </summary>
        /// <returns>The view's container</returns>
        /// <since_tizen> 4 </since_tizen>
        public override Container GetParent()
        {
            return null;
        }

        /// <summary>
        /// Get the child count of the layer.
        /// </summary>
        /// <returns>The child count of the layer.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override uint GetChildCount()
        {
            return Convert.ToUInt32(layer.Children.Count);
        }

        /// <summary>
        /// Downcasts a handle to layer handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// Please do not use! this will be deprecated!
        /// Instead please use as keyword.
        [Obsolete("Please do not use! This will be deprecated! Please use as keyword instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Layer DownCast(BaseHandle handle)
        {
            Tizen.NUI.Layer ret = Tizen.NUI.Layer.DownCast(handle.handleInstance);
            return BaseHandle.GetHandle(ret) as Layer;
        }

        /// <summary>
        /// Search through this layer's hierarchy for a view with the given unique ID.
        /// </summary>
        /// <pre>This layer (the parent) has been initialized.</pre>
        /// <remarks>The actor itself is also considered in the search.</remarks>
        /// <param name="id">The id of the child to find</param>
        /// <returns> A handle to the view if found, or an empty handle if not. </returns>
        /// <since_tizen> 3 </since_tizen>
        public View FindChildById(uint id)
        {
            Tizen.NUI.BaseComponents.View ret = layer.FindChildById(id);
            return BaseHandle.GetHandle(ret) as View;
        }

        /// <summary>
        /// Increments the depth of the layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Raise()
        {
            layer.Raise();
        }

        /// <summary>
        /// Decrements the depth of the layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Lower()
        {
            layer.Lower();
        }

        /// <summary>
        /// Raises the layer to the top.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void RaiseToTop()
        {
            layer.RaiseToTop();
        }

        /// <summary>
        /// Lowers the layer to the bottom.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void LowerToBottom()
        {
            layer.LowerToBottom();
        }

        /// <summary>
        /// Moves the layer directly above the given layer.<br />
        /// After the call, this layer's depth will be immediately above target.<br />
        /// </summary>
        /// <param name="target">The layer to get on top of.</param>
        /// <since_tizen> 3 </since_tizen>
        public void MoveAbove(Layer target)
        {
            layer.MoveAbove(target.layer);
        }

        /// <summary>
        /// Moves the layer directly below the given layer.<br />
        /// After the call, this layer's depth will be immediately below target.<br />
        /// </summary>
        /// <param name="target">The layer to get below of.</param>
        /// <since_tizen> 3 </since_tizen>
        public void MoveBelow(Layer target)
        {
            layer.MoveBelow(target.layer);
        }
    }
}