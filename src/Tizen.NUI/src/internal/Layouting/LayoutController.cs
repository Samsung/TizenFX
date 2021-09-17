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

using Tizen.NUI.BaseComponents;
using System.ComponentModel;
using System;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] The class that initiates the Measuring and Layouting of the tree,
    ///         It sets a callback that becomes the entry point into the C# Layouting.
    /// </summary>
    internal class LayoutController : Disposable
    {
        private static int layoutControllerID = 1;

        private int id;
        private Window window;
        private float windowWidth;
        private float windowHeight;
        private LayoutTransitionManager transitionManager;

        private bool subscribed;

        /// <summary>
        /// Constructs a LayoutController which controls the measuring and layouting.<br />
        /// <param name="window">Window attach this LayoutController to.</param>
        /// </summary>
        public LayoutController(Window window)
        {
            transitionManager = new LayoutTransitionManager();
            id = layoutControllerID++;

            SetBaseWindowAndSize(window);
        }

        /// <summary>
        /// Dispose Explicit or Implicit
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (subscribed)
            {
                ProcessorController.Instance.LayoutProcessorEvent -= Process;
                subscribed = false;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (SwigCPtr.Handle != global::System.IntPtr.Zero)
            {
                SwigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            transitionManager.Dispose();

            base.Dispose(type);
        }

        /// <summary>
        /// Set or Get Layouting core animation override property.
        /// Gives explicit control over the Layouting animation playback if set to True.
        /// Reset to False if explicit control no longer required.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OverrideCoreAnimation
        {
            get
            {
                return transitionManager.OverrideCoreAnimation;
            }
            set
            {
                transitionManager.OverrideCoreAnimation = value;
            }
        }

        /// <summary>
        /// Get the unique id of the LayoutController
        /// </summary>
        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// Request relayout of a LayoutItem and it's parent tree.
        /// </summary>
        /// <param name="layoutItem">LayoutItem that is required to be laid out again.</param>
        public void RequestLayout(LayoutItem layoutItem)
        {
            // Go up the tree and mark all parents to relayout
            ILayoutParent layoutParent = layoutItem.GetParent();
            if (layoutParent != null)
            {
                LayoutGroup layoutGroup = layoutParent as LayoutGroup;
                if (layoutGroup != null && !layoutGroup.LayoutRequested)
                {
                    layoutGroup.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Entry point into the C# Layouting that starts the Processing
        /// </summary>
        public void Process(object source, EventArgs e)
        {
            window.LayersChildren?.ForEach(layer =>
            {
                layer?.Children?.ForEach(view =>
                {
                    if (view != null)
                    {
                        FindRootLayouts(view, windowWidth, windowHeight);
                    }
                });
            });

            transitionManager.SetupCoreAndPlayAnimation();
        }

        /// <summary>
        /// Get the Layouting animation object that transitions layouts and content.
        /// Use OverrideCoreAnimation to explicitly control Playback.
        /// </summary>
        /// <returns> The layouting core Animation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Animation GetCoreAnimation()
        {
            return transitionManager.CoreAnimation;
        }

        /// <summary>
        /// Create and set process callback
        /// </summary>
        internal void CreateProcessCallback()
        {
            if (!subscribed)
            {
                ProcessorController.Instance.LayoutProcessorEvent += Process;
                subscribed = true;
            }
        }

        /// <summary>
        /// Add transition data for a LayoutItem to the transition stack.
        /// </summary>
        /// <param name="transitionDataEntry">Transition data for a LayoutItem.</param>
        internal void AddTransitionDataEntry(LayoutData transitionDataEntry)
        {
            transitionManager.AddTransitionDataEntry(transitionDataEntry);
        }

        /// <summary>
        /// Add LayoutItem to a removal stack for removal after transitions finish.
        /// </summary>
        /// <param name="itemToRemove">LayoutItem to remove.</param>
        internal void AddToRemovalStack(LayoutItem itemToRemove)
        {
            transitionManager.AddToRemovalStack(itemToRemove);
        }

        // Traverse the tree looking for a root node that is a layout.
        // Once found, it's children can be assigned Layouts and the Measure process started.
        private void FindRootLayouts(View rootNode, float parentWidth, float parentHeight)
        {
            if (rootNode.Layout != null)
            {
                NUILog.Debug("LayoutController Root found:" + rootNode.Name);
                // rootNode has a layout, start measuring and layouting from here.
                MeasureAndLayout(rootNode, parentWidth, parentHeight);
            }
            else
            {
                float rootWidth = rootNode.SizeWidth;
                float rootHeight = rootNode.SizeHeight;
                // Search children of supplied node for a layout.
                for (uint i = 0; i < rootNode.ChildCount; i++)
                {
                    FindRootLayouts(rootNode.GetChildAt(i), rootWidth, rootHeight);
                }
            }
        }

        // Starts of the actual measuring and layouting from the given root node.
        // Can be called from multiple starting roots but in series.
        // Get parent View's Size.  If using Legacy size negotiation then should have been set already.
        // Parent not a View so assume it's a Layer which is the size of the window.
        private void MeasureAndLayout(View root, float parentWidth, float parentHeight)
        {
            if (root.Layout != null)
            {
                // Determine measure specification for root.
                // The root layout policy could be an exact size, be match parent or wrap children.
                // If wrap children then at most it can be the root parent size.
                // If match parent then should be root parent size.
                // If exact then should be that size limited by the root parent size.
                float widthSize = GetLengthSize(parentWidth, root.WidthSpecification);
                float heightSize = GetLengthSize(parentHeight, root.HeightSpecification);
                var widthMode = GetMode(root.WidthSpecification);
                var heightMode = GetMode(root.HeightSpecification);

                if (root.Layout.NeedsLayout(widthSize, heightSize, widthMode, heightMode))
                {
                    var widthSpec = CreateMeasureSpecification(widthSize, widthMode);
                    var heightSpec = CreateMeasureSpecification(heightSize, heightMode);

                    // Start at root with it's parent's widthSpecification and heightSpecification
                    MeasureHierarchy(root, widthSpec, heightSpec);
                }

                float positionX = root.PositionX;
                float positionY = root.PositionY;
                // Start at root which was just measured.
                PerformLayout(root, new LayoutLength(positionX),
                                     new LayoutLength(positionY),
                                     new LayoutLength(positionX) + root.Layout.MeasuredWidth.Size,
                                     new LayoutLength(positionY) + root.Layout.MeasuredHeight.Size);
            }
        }

        private float GetLengthSize(float size, int specification)
        {
            // exact size provided so match width exactly
            return (specification >= 0) ? specification : size;
        }

        private MeasureSpecification.ModeType GetMode(int specification)
        {
            if (specification >= 0 || specification == LayoutParamPolicies.MatchParent)
            {
                return MeasureSpecification.ModeType.Exactly;
            }
            return MeasureSpecification.ModeType.Unspecified;
        }

        private MeasureSpecification CreateMeasureSpecification(float size, MeasureSpecification.ModeType mode)
        {
            return new MeasureSpecification(new LayoutLength(size), mode);
        }

        /// <summary>
        /// Starts measuring the tree, starting from the root layout.
        /// </summary>
        private void MeasureHierarchy(View root, MeasureSpecification widthSpec, MeasureSpecification heightSpec)
        {
            // Does this View have a layout?
            // Yes - measure the layout. It will call this method again for each of it's children.
            // No -  reached leaf or no layouts set
            //
            // If in a leaf View with no layout, it's natural size is bubbled back up.
            root.Layout?.Measure(widthSpec, heightSpec);
        }

        /// <summary>
        /// Performs the layouting positioning
        /// </summary>
        private void PerformLayout(View root, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            root.Layout?.Layout(left, top, right, bottom);
        }

        private void SetBaseWindowAndSize(Window window)
        {
            this.window = window;
            this.window.Resized += OnWindowResized;

            var windowSize = window.GetSize();
            windowWidth = windowSize.Width;
            windowHeight = windowSize.Height;
            windowSize.Dispose();
            windowSize = null;
        }

        private void OnWindowResized(object sender, Window.ResizedEventArgs e)
        {
            windowWidth = e.WindowSize.Width;
            windowHeight = e.WindowSize.Height;
        }
    } // class LayoutController
} // namespace Tizen.NUI
