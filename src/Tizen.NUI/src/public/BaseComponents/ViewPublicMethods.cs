/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
            Interop.View.View_DoAction(swigCPtr, propertyIndexOfVisual, propertyIndexOfActionId, PropertyValue.getCPtr(attributes));
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
            Tizen.NUI.PropertyMap background = Background;

            if (background.Empty())
            {
                // If there is no background yet, ensure there is a transparent
                // color visual
                BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                background = Background;
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
            {
                PropertyMap _animator = new PropertyMap();
                if (alphaFunction != null)
                {
                    _animator.Add("alphaFunction", new PropertyValue(AlphaFunction.BuiltinToPropertyKey(alphaFunction)));
                }

                PropertyMap _timePeriod = new PropertyMap();
                _timePeriod.Add("duration", new PropertyValue((endTime - startTime) / 1000.0f));
                _timePeriod.Add("delay", new PropertyValue(startTime / 1000.0f));
                _animator.Add("timePeriod", new PropertyValue(_timePeriod));

                PropertyMap _transition = new PropertyMap();
                _transition.Add("animator", new PropertyValue(_animator));
                _transition.Add("target", new PropertyValue(targetVisual));
                _transition.Add("property", new PropertyValue("mixColor"));

                if (initialColor != null)
                {
                    PropertyValue initValue = PropertyValue.CreateFromObject(initialColor);
                    _transition.Add("initialValue", initValue);
                }

                PropertyValue destValue = PropertyValue.CreateFromObject(destinationColor);
                _transition.Add("targetValue", destValue);
                TransitionData _transitionData = new TransitionData(_transition);

                animation = new Animation(Interop.View.View_CreateTransition(swigCPtr, TransitionData.getCPtr(_transitionData)), true);
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
            bool hasLayout = (_layout != null);

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
                    if (child.Layout !=null)
                    {
                        child.Layout.SetReplaceFlag();
                    }
                    oldParent.Remove(child);
                }
                child.InternalParent = this;

                Interop.Actor.Actor_Add(swigCPtr, View.getCPtr(child));

                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                Children.Add(child);

                if (ChildAdded != null)
                {
                    ChildAddedEventArgs e = new ChildAddedEventArgs
                    {
                        Added = child
                    };
                    ChildAdded(this, e);
                }
                BindableObject.SetInheritedBindingContext(child, this?.BindingContext);
            }
        }

        /// <summary>
        /// Removes a child view from this View. If the view was not a child of this view, this is a no-op.
        /// </summary>
        /// <seealso cref="Container.Remove" />
        /// <since_tizen> 4 </since_tizen>
        public override void Remove(View child)
        {
            if (!child || child.GetParent() == null) // Early out if child null.
                return;

            bool hasLayout = (_layout != null);

            // If View has a layout then do a deferred child removal
            // Actual child removal is performed by the layouting system so
            // transitions can be completed.
            if (hasLayout)
            {
                (_layout as LayoutGroup)?.RemoveChildFromLayoutGroup(child);
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
        /// Retrieves the number of children held by the view.
        /// </summary>
        /// <seealso cref="Container.GetChildCount" />
        /// <since_tizen> 4 </since_tizen>
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
            return this.InternalParent as Container;
        }

        /// <summary>
        /// Queries whether the view has a focus.
        /// </summary>
        /// <returns>True if this view has a focus.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool HasFocus()
        {
            bool ret = false;
            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                ret = Interop.View.View_HasKeyInputFocus(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            else
            {
                Tizen.Log.Error("NUI", "swigCPtr of view is aleady disposed.");
            }
            return ret;
        }

        /// <summary>
        /// Sets the name of the style to be applied to the view.
        /// </summary>
        /// <param name="styleName">A string matching a style described in a stylesheet.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetStyleName(string styleName)
        {
            Interop.View.View_SetStyleName(swigCPtr, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the name of the style to be applied to the view (if any).
        /// </summary>
        /// <returns>A string matching a style, or an empty string.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetStyleName()
        {
            string ret = Interop.View.View_GetStyleName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears the background.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void ClearBackground()
        {
            Interop.View.View_ClearBackground(swigCPtr);
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
                layout?.ChangeLayoutSiblingOrder(parentChildren.Count-1);

                Interop.NDalic.RaiseToTop(swigCPtr);
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

                Interop.NDalic.LowerToBottom(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Queries if all resources required by a view are loaded and ready.
        /// </summary>
        /// <remarks>Most resources are only loaded when the control is placed on the stage.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool IsResourceReady()
        {
            bool ret = Interop.View.IsResourceReady(swigCPtr);
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
            IntPtr cPtr = Interop.Actor.Actor_GetLayer(swigCPtr);
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
            IntPtr cPtr = Interop.Actor.Actor_FindChildByName(swigCPtr, viewName);
            View ret = this.GetInstanceSafely<View>(cPtr);
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
            bool ret = Interop.Actor.Actor_ScreenToLocal(swigCPtr, out localX, out localY, screenX, screenY);
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
            Interop.Actor.Actor_SetSizeModeFactor(swigCPtr, Vector3.getCPtr(factor));
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
            float ret = Interop.Actor.Actor_GetHeightForWidth(swigCPtr, width);
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
            float ret = Interop.Actor.Actor_GetWidthForHeight(swigCPtr, height);
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
            float ret = Interop.Actor.Actor_GetRelayoutSize(swigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Set the padding for the view.
        /// </summary>
        /// <param name="padding">Padding for the view.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetPadding(PaddingType padding)
        {
            Interop.Actor.Actor_SetPadding(swigCPtr, PaddingType.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Return the value of padding for the view.
        /// </summary>
        /// <param name="paddingOut">the value of padding for the view</param>
        /// <since_tizen> 3 </since_tizen>
        public void GetPadding(PaddingType paddingOut)
        {
            Interop.Actor.Actor_GetPadding(swigCPtr, PaddingType.getCPtr(paddingOut));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <since_tizen> 3 </since_tizen>
        public uint AddRenderer(Renderer renderer)
        {
            uint ret = Interop.Actor.Actor_AddRenderer(swigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public Renderer GetRendererAt(uint index)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.Actor_GetRendererAt(swigCPtr, index);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            Renderer ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as Renderer;
            if (cPtr != null && ret == null)
            {
                ret = new Renderer(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            Interop.BaseHandle.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(Renderer renderer)
        {
            Interop.Actor.Actor_RemoveRenderer__SWIG_0(swigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(uint index)
        {
            Interop.Actor.Actor_RemoveRenderer__SWIG_1(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RotateBy(Degree angle, Vector3 axis)
        {
            Interop.ActorInternal.Actor_RotateBy__SWIG_0(swigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RotateBy(Radian angle, Vector3 axis)
        {
            Interop.ActorInternal.Actor_RotateBy__SWIG_1(swigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RotateBy(Rotation relativeRotation)
        {
            Interop.ActorInternal.Actor_RotateBy__SWIG_2(swigCPtr, Rotation.getCPtr(relativeRotation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScaleBy(Vector3 relativeScale)
        {
            Interop.ActorInternal.Actor_ScaleBy(swigCPtr, Vector3.getCPtr(relativeScale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetColorMode(ColorMode colorMode)
        {
            Interop.ActorInternal.Actor_SetColorMode(swigCPtr, (int)colorMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }



        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Transition GetTransition(string transitionName)
        {
            Transition trans = null;
            transDictionary.TryGetValue(transitionName, out trans);
            return trans;
        }

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ObjectDump()
        {
            if ( 0== Children.Count)
            {
                Type type = this.GetType();
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach(var property in properties)
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
        /// </summary>
        /// <param name="id">The ID of the View to find.</param>
        /// <remarks>Hidden-API</remarks>
        /// <returns>A handle to the View if found, or an empty handle if not.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View FindDescendantByID(uint id)
        {
            return FindChildById(id);
        }

    }
}
