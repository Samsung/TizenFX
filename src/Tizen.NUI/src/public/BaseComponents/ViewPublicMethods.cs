/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Reflection;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        /// <summary>
        /// Perform an action on a visual registered to this view. <br />
        /// Visuals will have actions. This API is used to perform one of these actions with the given attributes.
        /// </summary>
        /// <param name="propertyIndexOfVisual">The Property index of the visual.</param>
        /// <param name="propertyIndexOfActionId">The action to perform. See Visual to find the supported actions.</param>
        /// <param name="attributes">Optional attributes for the action.</param>
        /// <since_tizen> 5 </since_tizen>
        public void DoAction(int propertyIndexOfVisual, int propertyIndexOfActionId, PropertyValue attributes)
        {
            Interop.View.DoAction(SwigCPtr, propertyIndexOfVisual, propertyIndexOfActionId, PropertyValue.getCPtr(attributes));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an animation to animate the background color visual. If there is no
        /// background visual, creates one with transparent black as it's mixColor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animation AnimateBackgroundColor(object destinationValue,
                                                 int startTime,
                                                 int endTime,
                                                 AlphaFunction.BuiltinFunctions? alphaFunction = null,
                                                 object initialValue = null)
        {
            if (IsBackgroundEmpty())
            {
                // If there is no background yet, ensure there is a transparent
                // color visual
                BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            }
            return AnimateColor("background", destinationValue, startTime, endTime, alphaFunction, initialValue);
        }

        /// <summary>
        /// Creates an animation to animate the mixColor of the named visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animation AnimateColor(string targetVisual, object destinationColor, int startTime, int endTime, AlphaFunction.BuiltinFunctions? alphaFunction = null, object initialColor = null)
        {
            Animation animation = null;
            using (PropertyMap animator = new PropertyMap())
            using (PropertyMap timePeriod = new PropertyMap())
            using (PropertyValue pvDuration = new PropertyValue((endTime - startTime) / 1000.0f))
            using (PropertyValue pvDelay = new PropertyValue(startTime / 1000.0f))
            using (PropertyMap transition = new PropertyMap())
            using (PropertyValue pvTarget = new PropertyValue(targetVisual))
            using (PropertyValue pvProperty = new PropertyValue("mixColor"))
            using (PropertyValue destValue = PropertyValue.CreateFromObject(destinationColor))
            {
                if (alphaFunction != null)
                {
                    using (PropertyValue pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(alphaFunction)))
                    {
                        animator.Add("alphaFunction", pvAlpha);
                    }
                }

                timePeriod.Add("duration", pvDuration);
                timePeriod.Add("delay", pvDelay);
                using (PropertyValue pvTimePeriod = new PropertyValue(timePeriod))
                {
                    animator.Add("timePeriod", pvTimePeriod);
                }
                using (PropertyValue pvAnimator = new PropertyValue(animator))
                {
                    transition.Add("animator", pvAnimator);
                }
                transition.Add("target", pvTarget);
                transition.Add("property", pvProperty);

                if (initialColor != null)
                {
                    using (PropertyValue initValue = PropertyValue.CreateFromObject(initialColor))
                    {
                        transition.Add("initialValue", initValue);
                    }
                }

                transition.Add("targetValue", destValue);
                using (TransitionData transitionData = new TransitionData(transition))
                {
                    animation = new Animation(Interop.View.CreateTransition(SwigCPtr, TransitionData.getCPtr(transitionData)), true);
                }
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return animation;
        }

        // From Container Base class
        /// <summary>
        /// Adds a child view to this view.
        /// </summary>
        /// <seealso cref="Container.Add" />
        /// <since_tizen> 4 </since_tizen>
        public override void Add(View child)
        {
            bool hasLayout = (layout != null);

            if (null == child)
            {
                Tizen.Log.Fatal("NUI", "Child is null");
                return;
            }

            Container oldParent = child.GetParent();
            if (oldParent != this)
            {
                // If child already has a parent then re-parent child
                if (oldParent != null)
                {
                    if (child.Layout != null)
                    {
                        child.Layout.SetReplaceFlag();
                    }
                    oldParent.Remove(child);
                }
                child.InternalParent = this;
                LayoutCount += child.LayoutCount;

                Interop.Actor.Add(SwigCPtr, View.getCPtr(child));

                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                Children.Add(child);
                OnChildAdded(child);

                if (ChildAdded != null)
                {
                    ChildAddedEventArgs e = new ChildAddedEventArgs
                    {
                        Added = child
                    };
                    ChildAdded(this, e);
                }
            }
        }

        /// <summary>
        /// Removes a child view from this View. If the view was not a child of this view, this is a no-op.
        /// </summary>
        /// <seealso cref="Container.Remove" />
        /// <since_tizen> 4 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when deleting a view that is not a child of this view</exception>
        public override void Remove(View child)
        {
            if (child == null || child.GetParent() == null) // Early out if child null.
                return;

            if (child.GetParent() != this)
            {
                //throw new System.InvalidOperationException("You have deleted a view that is not a child of this view.");
                Tizen.Log.Error("NUI", "You have deleted a view that is not a child of this view.");
                return;
            }

            bool hasLayout = (layout != null);

            // If View has a layout then do a deferred child removal
            // Actual child removal is performed by the layouting system so
            // transitions can be completed.
            if (hasLayout)
            {
                (layout as LayoutGroup)?.RemoveChildFromLayoutGroup(child);
            }

            RemoveChild(child);
        }

        /// <summary>
        /// Retrieves a child view by index.
        /// </summary>
        /// <seealso cref="Container.GetChildAt" />
        /// <since_tizen> 4 </since_tizen>
        public override View GetChildAt(uint index)
        {
            if (index < Children.Count)
            {
                return Children[Convert.ToInt32(index)];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves a child view as Animatable by index.
        /// </summary>
        /// <param name="index">The index of the Animatable to find.</param>
        /// <returns>A handle to the view as Animatable if found, or an empty handle if not.</returns>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Animatable GetChildAnimatableAt(uint index)
        {
            if (index < Children.Count)
            {
                return Children[Convert.ToInt32(index)] as Animatable;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the number of children held by the view.
        /// </summary>
        /// <seealso cref="Container.GetChildCount" />
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ChildCount property instead.")]
        public override uint GetChildCount()
        {
            return Convert.ToUInt32(Children.Count);
        }

        /// <summary>
        /// Gets the views parent.
        /// </summary>
        /// <seealso cref="Container.GetParent()" />
        /// <since_tizen> 4 </since_tizen>
        public override Container GetParent()
        {
            return InternalParent as Container;
        }

        /// <summary>
        /// Queries whether the view has a focus.
        /// </summary>
        /// <returns>True if this view has a focus.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool HasFocus()
        {
            bool ret = false;
            if (SwigCPtr.Handle != global::System.IntPtr.Zero)
            {
                ret = Interop.View.HasKeyInputFocus(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            else
            {
                Tizen.Log.Error("NUI", "swigCPtr of view is already disposed.");
            }
            return ret;
        }

        /// <summary>
        /// Sets the name of the style to be applied to the view.
        /// </summary>
        /// <param name="styleName">A string matching a style described in a stylesheet.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use StyleName property instead.")]
        public void SetStyleName(string styleName)
        {
            Interop.View.SetStyleName(SwigCPtr, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the name of the style to be applied to the view (if any).
        /// </summary>
        /// <returns>A string matching a style, or an empty string.</returns>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use StyleName property instead.")]
        public string GetStyleName()
        {
            string ret = Interop.View.GetStyleName(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears the background.
        /// This method removes any background properties set on the view, such as color or image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void ClearBackground()
        {
            Interop.View.ClearBackground(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets render effect to the view. The effect is applied to at most one view.
        /// </summary>
        /// <param name="effect">A render effect to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRenderEffect(RenderEffect effect)
        {
            Interop.View.SetRenderEffect(SwigCPtr, RenderEffect.getCPtr(effect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears render effect.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearRenderEffect()
        {
            Interop.View.ClearRenderEffect(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <remarks>
        /// This is an asynchronous method.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Show()
        {
            SetVisible(true);

            if (GetAccessibilityStates()[AccessibilityState.Modal])
            {
                RegisterDefaultLabel();

                if (Accessibility.Accessibility.IsEnabled)
                {
                    EmitAccessibilityStateChangedEvent(AccessibilityState.Showing, true);
                }
            }
        }

        /// <summary>
        /// Hides the view.
        /// </summary>
        /// <remarks>
        /// This is an asynchronous method.
        /// If the view is hidden, then the view and its children will not be rendered.
        /// This is regardless of the individual visibility of the children, i.e., the view will only be rendered if all of its parents are shown.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Hide()
        {
            SetVisible(false);

            if (GetAccessibilityStates()[AccessibilityState.Modal])
            {
                UnregisterDefaultLabel();

                if (Accessibility.Accessibility.IsEnabled)
                {
                    EmitAccessibilityStateChangedEvent(AccessibilityState.Showing, false);
                }
            }
        }

        /// <summary>
        /// Raises the view above all other views.
        /// </summary>
        /// <remarks>
        /// Sibling order of views within the parent will be updated automatically.
        /// Once a raise or lower API is used, that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void RaiseToTop()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                parentChildren.Remove(this);
                parentChildren.Add(this);

                LayoutGroup layout = Layout as LayoutGroup;
                layout?.ChangeLayoutSiblingOrder(parentChildren.Count - 1);

                Interop.NDalic.RaiseToTop(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

        }

        /// <summary>
        /// Lowers the view to the bottom of all views.
        /// </summary>
        /// <remarks>
        /// The sibling order of views within the parent will be updated automatically.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void LowerToBottom()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                parentChildren.Remove(this);
                parentChildren.Insert(0, this);

                LayoutGroup layout = Layout as LayoutGroup;
                layout?.ChangeLayoutSiblingOrder(0);

                Interop.NDalic.LowerToBottom(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Queries if all resources required by a view are loaded and ready.
        /// </summary>
        /// <remarks>Most resources are only loaded when the control is placed on the stage.
        /// </remarks>
        /// <returns>True if all resources are ready, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsResourceReady()
        {
            bool ret = Interop.View.IsResourceReady(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the parent layer of this view.If a view has no parent, this method does not do anything.
        /// </summary>
        /// <pre>The view has been initialized. </pre>
        /// <returns>The parent layer of view </returns>
        /// <since_tizen> 5 </since_tizen>
        public Layer GetLayer()
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.GetLayer(SwigCPtr);
            Layer ret = this.GetInstanceSafely<Layer>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes a view from its parent view or layer. If a view has no parent, this method does nothing.
        /// </summary>
        /// <pre>The (child) view has been initialized. </pre>
        /// <since_tizen> 4 </since_tizen>
        public void Unparent()
        {
            GetParent()?.Remove(this);
        }

        /// <summary>
        /// Search through this view's hierarchy for a view with the given name.
        /// The view itself is also considered in the search.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="viewName">The name of the view to find.</param>
        /// <returns>A handle to the view if found, or an empty handle if not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View FindChildByName(string viewName)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.FindChildByName(SwigCPtr, viewName);
            View ret = this.GetInstanceSafely<View>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Search through this view's hierarchy for a view as Animatable with the given name.
        /// The view itself is also considered in the search.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="childName">The name of the Animatable to find.</param>
        /// <returns>A handle to the view as Animatable if found, or an empty handle if not.</returns>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Animatable FindChildAnimatableByName(string childName)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.FindChildByName(SwigCPtr, childName);
            Animatable ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Animatable;
            if(ret == null)
            {
                // Register new camera into Registry.
                ret = new Animatable(cPtr, true);
            }
            else
            {
                // We found matched NUI camera. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Interop.Actor.DeleteActor(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Converts screen coordinates into the view's coordinate system using the default camera.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <remarks>The view coordinates are relative to the top-left(0.0, 0.0, 0.5).</remarks>
        /// <param name="localX">On return, the X-coordinate relative to the view.</param>
        /// <param name="localY">On return, the Y-coordinate relative to the view.</param>
        /// <param name="screenX">The screen X-coordinate.</param>
        /// <param name="screenY">The screen Y-coordinate.</param>
        /// <returns>True if the conversion succeeded.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool ScreenToLocal(out float localX, out float localY, float screenX, float screenY)
        {
            bool ret = Interop.Actor.ScreenToLocal(SwigCPtr, out localX, out localY, screenX, screenY);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the relative to parent size factor of the view.<br />
        /// This factor is only used when ResizePolicy is set to either:
        /// ResizePolicy::SIZE_RELATIVE_TO_PARENT or ResizePolicy::SIZE_FIXED_OFFSET_FROM_PARENT.<br />
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicy.<br />
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="factor">A Vector3 representing the relative factor to be applied to each axis.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetSizeModeFactor(Vector3 factor)
        {
            Interop.Actor.SetSizeModeFactor(SwigCPtr, Vector3.getCPtr(factor));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        /// <summary>
        /// Calculates the height of the view given a width.<br />
        /// The natural size is used for default calculation.<br />
        /// Size 0 is treated as aspect ratio 1:1.<br />
        /// </summary>
        /// <param name="width">The width to use.</param>
        /// <returns>The height based on the width.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetHeightForWidth(float width)
        {
            float ret = Interop.Actor.GetHeightForWidth(SwigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Calculates the width of the view given a height.<br />
        /// The natural size is used for default calculation.<br />
        /// Size 0 is treated as aspect ratio 1:1.<br />
        /// </summary>
        /// <param name="height">The height to use.</param>
        /// <returns>The width based on the height.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetWidthForHeight(float height)
        {
            float ret = Interop.Actor.GetWidthForHeight(SwigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Return the amount of size allocated for relayout.
        /// </summary>
        /// <param name="dimension">The dimension to retrieve.</param>
        /// <returns>Return the size.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetRelayoutSize(DimensionType dimension)
        {
            float ret = Interop.Actor.GetRelayoutSize(SwigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Set the padding for the view.
        /// </summary>
        /// <param name="padding">Padding for the view.</param>
        /// <since_tizen> 3 </since_tizen>
        // [Obsolete("This has been deprecated in API9 and will be removed in API11. Use Padding property instead.")]
        public void SetPadding(PaddingType padding)
        {
            Interop.Actor.SetPadding(SwigCPtr, PaddingType.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Return the value of padding for the view.
        /// </summary>
        /// <param name="paddingOut">the value of padding for the view</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use Padding property instead.")]
        public void GetPadding(PaddingType paddingOut)
        {
            Interop.Actor.GetPadding(SwigCPtr, PaddingType.getCPtr(paddingOut));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds a renderer to the view.
        /// </summary>
        /// <param name="renderer">The renderer to add.</param>
        /// <returns>The index of the Renderer that was added to the view.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint AddRenderer(Renderer renderer)
        {
            uint ret = Interop.Actor.AddRenderer(SwigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the renderer at the specified index.
        /// </summary>
        /// <param name="index">The index of the renderer to retrieve.</param>
        /// <returns>A Renderer object at the specified index.</returns>
        /// <remarks>
        /// The index must be between 0 and GetRendererCount()-1
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Renderer GetRendererAt(uint index)
        {
            IntPtr cPtr = Interop.Actor.GetRendererAt(SwigCPtr, index);
            Renderer ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Renderer;
            if (ret != null)
            {
                Interop.BaseHandle.DeleteBaseHandle(new HandleRef(this, cPtr));
            }
            else
            {
                ret = new Renderer(cPtr, true);
            }
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// Removes the specified renderer from the view.
        /// </summary>
        /// <param name="renderer">The renderer to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(Renderer renderer)
        {
            Interop.Actor.RemoveRenderer(SwigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a renderer at the specified index from the view.
        /// </summary>
        /// <param name="index">The index of the renderer to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(uint index)
        {
            Interop.Actor.RemoveRenderer(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RotateBy(Degree angle, Vector3 axis)
        {
            Interop.ActorInternal.RotateByDegree(SwigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RotateBy(Radian angle, Vector3 axis)
        {
            Interop.ActorInternal.RotateByRadian(SwigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RotateBy(Rotation relativeRotation)
        {
            Interop.ActorInternal.RotateByQuaternion(SwigCPtr, Rotation.getCPtr(relativeRotation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScaleBy(Vector3 relativeScale)
        {
            Interop.ActorInternal.ScaleBy(SwigCPtr, Vector3.getCPtr(relativeScale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Rotate the view look at specific position.
        /// It will change the view's orientation property.
        /// </summary>
        /// <remark>Target position should be setup by world coordinates.</remark>
        /// <param name="target">The target world position to look at.</param>
        /// <param name="up">The up vector after target look at. If it is null, up vector become +Y axis</param>
        /// <param name="localForward">The forward vector of view when it's orientation is not applied. If it is null, localForward vector become +Z axis</param>
        /// <param name="localUp">The up vector of view when it's orientation is not applied. If it is null, localUp vector become +Y axis</param>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LookAt(Vector3 target, Vector3 up = null, Vector3 localForward = null, Vector3 localUp = null)
        {
            Interop.ActorInternal.LookAt(SwigCPtr, Vector3.getCPtr(target), Vector3.getCPtr(up), Vector3.getCPtr(localForward), Vector3.getCPtr(localUp));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetColorMode(ColorMode colorMode)
        {
            Interop.ActorInternal.SetColorMode(SwigCPtr, (int)colorMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ObjectDump()
        {
            if (0 == Children.Count)
            {
                Type type = this.GetType();
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var property in properties)
                {
                    if (null != property && property.CanRead)
                    {
                        Tizen.Log.Fatal("NUI", $"{type.Name} {property.Name} ({property.PropertyType.Name}): {property.GetValueString(this, property.PropertyType)}");
                    }
                }
                return;
            }

            foreach (View view in Children)
            {
                view.ObjectDump();
            }
        }

        /// <summary>
        /// Search through this View's hierarchy for a View with the given unique ID.
        /// The View itself is also considered in the search.
        /// </summary>
        /// <param name="id">The ID of the View to find</param>
        /// <returns>A View if found or a null if not</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This will be removed at API11. Use FindDescendantByID(uint id) instead.")]
        public View FindChildByID(uint id)
        {
            IntPtr cPtr = Interop.Actor.FindChildById(SwigCPtr, id);
            View ret = this.GetInstanceSafely<View>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Search through this View's hierarchy for a View with the given unique ID.
        /// </summary>
        /// <param name="id">The ID of the View to find.</param>
        /// <returns>A handle to the View if found, or an empty handle if not.</returns>
        /// <since_tizen> 9 </since_tizen>
        public View FindDescendantByID(uint id)
        {
            return FindChildById(id);
        }

        /// <summary>
        /// Raise view above the next sibling view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Raise()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);

                // If the view is not already the last item in the list.
                if (currentIndex >= 0 && currentIndex < parentChildren.Count - 1)
                {
                    View temp = parentChildren[currentIndex + 1];
                    parentChildren[currentIndex + 1] = this;
                    parentChildren[currentIndex] = temp;

                    Interop.NDalic.Raise(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        /// <summary>
        /// Lower the view below the previous sibling view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Lower()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);

                // If the view is not already the first item in the list.
                if (currentIndex > 0 && currentIndex < parentChildren.Count)
                {
                    View temp = parentChildren[currentIndex - 1];
                    parentChildren[currentIndex - 1] = this;
                    parentChildren[currentIndex] = temp;

                    Interop.NDalic.Lower(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        /// <summary>
        /// Raises the view to above the target view.
        /// </summary>
        /// <remarks>The sibling order of views within the parent will be updated automatically.
        /// Views on the level above the target view will still be shown above this view.
        /// Once a raise or lower API is used then that view will have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <param name="target">Will be raised above this view.</param>
        /// <since_tizen> 9 </since_tizen>
        public void RaiseAbove(View target)
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);

                if (currentIndex < 0 || targetIndex < 0 ||
                    currentIndex >= parentChildren.Count || targetIndex >= parentChildren.Count)
                {
                    NUILog.Error("index should be bigger than 0 and less than children of layer count");
                    return;
                }
                // If the currentIndex is less than the target index and the target has the same parent.
                if (currentIndex < targetIndex)
                {
                    parentChildren.Remove(this);
                    parentChildren.Insert(targetIndex, this);

                    Interop.NDalic.RaiseAbove(SwigCPtr, View.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }

        }

        /// <summary>
        /// Lowers the view to below the target view.
        /// </summary>
        /// <remarks>The sibling order of views within the parent will be updated automatically.
        /// Once a raise or lower API is used then that view will have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <param name="target">Will be lowered below this view.</param>
        /// <since_tizen> 9 </since_tizen>
        public void LowerBelow(View target)
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);
                if (currentIndex < 0 || targetIndex < 0 ||
                   currentIndex >= parentChildren.Count || targetIndex >= parentChildren.Count)
                {
                    NUILog.Error("index should be bigger than 0 and less than children of layer count");
                    return;
                }

                // If the currentIndex is not already the 0th index and the target has the same parent.
                if ((currentIndex != 0) && (targetIndex != -1) &&
                    (currentIndex > targetIndex))
                {
                    parentChildren.Remove(this);
                    parentChildren.Insert(targetIndex, this);

                    Interop.NDalic.LowerBelow(SwigCPtr, View.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }

        }

        /// <summary>
        /// Sets the position of the View.
        /// The coordinates are relative to the View's parent.
        /// The View's z position will be set to 0.0f.
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
        /// <remarks>
        /// This is a hidden API(inhouse API) only for internal purpose.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPosition(float x, float y)
        {
            Interop.ActorInternal.SetPosition(SwigCPtr, x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the position of the View.
        /// The coordinates are relative to the View's parent.
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
        /// <param name="z">The new z position</param>
        /// <remarks>
        /// This is a hidden API(inhouse API) only for internal purpose.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPosition(float x, float y, float z)
        {
            Interop.ActorInternal.SetPosition(SwigCPtr, x, y, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the position of the View.
        /// The coordinates are relative to the View's parent.
        /// </summary>
        /// <param name="position">The new position</param>
        /// <remarks>
        /// This is a hidden API(inhouse API) only for internal purpose.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPosition(Vector3 position)
        {
            Interop.ActorInternal.SetPosition(SwigCPtr, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Register custom HitTest function for this view.
        /// </summary>
        /// <seealso cref="View.HitTest" />
        /// <remarks>
        /// This is a hidden API(inhouse API) only for internal purpose.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void RegisterHitTestCallback()
        {
            if (hitTestResultDataCallback == null)
            {
                hitTestResultDataCallback = OnHitTestResult;
                Interop.ActorSignal.HitTestResultConnect(SwigCPtr, hitTestResultDataCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
            }
        }

        /// <summary>
        /// Unregister custom HitTest function.
        /// </summary>
        /// <remarks>
        /// This is a hidden API(inhouse API) only for internal purpose.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UnregisterHitTestCallback()
        {
            if (hitTestResultDataCallback != null)
            {
                Interop.ActorSignal.HitTestResultDisconnect(SwigCPtr, hitTestResultDataCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                hitTestResultDataCallback = null;
            }
        }

        /// <summary>
        /// Calculate the screen position of the view.<br />
        /// </summary>
        /// <remarks>
        /// This is a hidden API(inhouse API) only for internal purpose.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 CalculateScreenPosition()
        {
            Vector2 ret = new Vector2(Interop.Actor.CalculateScreenPosition(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Calculate the screen position and size of the view.<br />
        /// </summary>
        /// <remarks>
        /// The float type Rectangle class is not ready yet.
        /// Therefore, it transmits data in Vector4 class.
        /// This type should later be changed to the appropriate data type.
        /// </remarks>
        /// <remarks>
        /// This is a hidden API(inhouse API) only for internal purpose.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 CalculateScreenPositionSize()
        {
            Vector4 ret = new Vector4(Interop.Actor.CalculateScreenExtents(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
