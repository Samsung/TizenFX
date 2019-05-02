/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using System;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] The class that initiates the Measuring and Layouting of the tree,
    ///         It sets a callback that becomes the entry point into the C# Layouting.
    /// </summary>
    internal class LayoutController : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef unmanagedLayoutController;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate void Callback(int id);

        event Callback mInstance;

        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        private Window _window;
        /// <summary>
        /// Constructs a LayoutController which controls the measuring and layouting.<br />
        /// <param name="window">Window attach this LayoutController to.</param>
        /// </summary>
        public LayoutController(Window window)
        {
            global::System.IntPtr cPtr = Interop.LayoutController.LayoutController_New();
            _window = window;
            // Wrap cPtr in a managed handle.
            unmanagedLayoutController = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            mInstance = new Callback(Process);
            Interop.LayoutController.LayoutController_SetCallback(unmanagedLayoutController, mInstance);
        }

        /// <summary>
        /// Get the unique id of the LayoutController
        /// </summary>
        public int GetId()
        {
            return Interop.LayoutController.LayoutController_GetId(unmanagedLayoutController);
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
                 LayoutGroup layoutGroup =  layoutParent as LayoutGroup;
                 if(! layoutGroup.LayoutRequested)
                 {
                    layoutGroup.RequestLayout();
                 }
            }
        }

        /// <summary>
        /// Destructor which adds LayoutController to the Dispose queue.
        /// </summary>
        ~LayoutController()
        {
            Dispose(DisposeTypes.Explicit);
        }

        /// <summary>
        /// Explict Dispose.
        /// </summary>
        public void Dispose()
        {
           Dispose(DisposeTypes.Explicit);
           System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose Explict or Implicit
        /// </summary>
        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User code
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (unmanagedLayoutController.Handle != global::System.IntPtr.Zero)
            {
                Interop.LayoutController.delete_LayoutController(unmanagedLayoutController);
                unmanagedLayoutController = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }

        // Traverse through children from the provided root.
        // If a child has no layout but is a pure View then assign a default layout and continue traversal.
        // If child has no layout and not a pure View then assign a LayoutItem that terminates the layouting (leaf),
        private void AutomaticallyAssignLayouts(View rootNode)
        {
            for (uint i = 0; i < rootNode.ChildCount; i++)
            {
                View view = rootNode.GetChildAt(i);
                if (rootNode.Layout == null )
                {
                    if (rootNode.GetType() == typeof(View))
                    {
                        Log.Info("NUI", "Creating LayoutGroup for " + rootNode.Name  + "\n");
                        rootNode.Layout = new LayoutGroup();
                        AutomaticallyAssignLayouts(rootNode);
                    }
                    else
                    {
                        Log.Info("NUI", "Creating LayoutItem for " + rootNode.Name  + "\n");
                        rootNode.Layout = new LayoutItem();
                    }
                }
            }
        }

        // Traverse the tree looking for a root node that is a layout.
        // Once found, it's children can be assigned Layouts and the Measure process started.
        private void FindRootLayouts(View rootNode)
        {
            if (rootNode.Layout != null)
            {
                Log.Info("NUI", "Found root:" + rootNode.Name + "\n");
                // rootNode has a layout, ensure all children have default layouts or layout items.
                AutomaticallyAssignLayouts(rootNode);
                // rootNode has a layout, start measuring and layouting from here.
                MeasureAndLayout(rootNode);
            }
            else
            {
                // Search children of supplied node for a layout.
                for (uint i = 0; i < rootNode.ChildCount; i++)
                {
                    View view = rootNode.GetChildAt(i);
                    FindRootLayouts(view);
                }
            }
        }

        // Starts of the actual measuring and layouting from the given root node.
        // Can be called from multiple starting roots but in series.
        void MeasureAndLayout(View root)
        {
            if (root !=null)
            {
                // Get parent MeasureSpecification, this could be the Window or View with an exact size.
                Container parentNode = root.GetParent();
                Size2D rootSize;
                Position2D rootPosition = root.Position2D;
                View parentView = parentNode as View;
                if (parentView)
                {
                    // Get parent View's Size.  If using Legacy size negotiation then should have been set already.
                    rootSize = new Size2D(parentView.Size2D.Width, parentView.Size2D.Height);
                }
                else
                {
                    // Parent not a View so assume it's a Layer which is the size of the window.
                    rootSize = new Size2D(_window.Size.Width, _window.Size.Height);
                }

                Log.Info("NUI", "Root parent size(" + rootSize.Width + "," + rootSize.Height + ")\n");

                // Determine measure specification for root.
                // The root layout policy could be an exact size, be match parent or wrap children.
                // If wrap children then at most it can be the root parent size.
                // If match parent then should be root parent size.
                // If exact then should be that size limited by the root parent size.

                LayoutLength width = new LayoutLength(rootSize.Width);
                LayoutLength height = new LayoutLength(rootSize.Height);
                MeasureSpecification.ModeType widthMode = MeasureSpecification.ModeType.AtMost;
                MeasureSpecification.ModeType heightMode = MeasureSpecification.ModeType.AtMost;

                if (root.WidthSpecification >= 0 )
                {
                    // exact size provided so match width exactly
                    width = new LayoutLength(root.WidthSpecification);
                    widthMode = MeasureSpecification.ModeType.Exactly;
                }
                else if (root.WidthSpecification == LayoutParamPolicies.MatchParent)
                {
                    widthMode = MeasureSpecification.ModeType.Exactly;
                }

                if (root.HeightSpecification >= 0 )
                {
                    // exact size provided so match height exactly
                    height = new LayoutLength(root.HeightSpecification);
                    heightMode = MeasureSpecification.ModeType.Exactly;
                }
                else if (root.HeightSpecification == LayoutParamPolicies.MatchParent)
                {
                    heightMode = MeasureSpecification.ModeType.Exactly;
                }

                MeasureSpecification parentWidthSpecification =
                    new MeasureSpecification( width, widthMode);

                MeasureSpecification parentHeightSpecification =
                    new MeasureSpecification( height, heightMode);

                // Start at root with it's parent's widthSpecification and heightSpecification
                MeasureHierarchy(root, parentWidthSpecification, parentHeightSpecification);

                // Start at root which was just measured.
                PerformLayout( root, new LayoutLength(rootPosition.X),
                                     new LayoutLength(rootPosition.Y),
                                     new LayoutLength(rootPosition.X) + root.Layout.MeasuredWidth.Size,
                                     new LayoutLength(rootPosition.Y) + root.Layout.MeasuredHeight.Size );
            }
        }

        /// <summary>
        /// Entry point into the C# Layouting that starts the Processing
        /// </summary>
        private void Process(int id)
        {
            Log.Info("NUI", "LayoutController Process id:" + id + "\n");

            Layer defaultLayer = _window.GetDefaultLayer();
            for (uint i = 0; i < defaultLayer.ChildCount; i++)
            {
                View view = defaultLayer.GetChildAt(i);
                FindRootLayouts(view);
            }
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

            if (root.Layout != null)
            {
                root.Layout.Measure(widthSpec, heightSpec);
            }
        }

        /// <summary>
        /// Performs the layouting positioning
        /// </summary>
        private void PerformLayout(View root, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            if(root.Layout != null)
            {
                root.Layout.Layout(left, top, right, bottom);
            }
        }
    } // class LayoutController

} // namespace Tizen.NUI