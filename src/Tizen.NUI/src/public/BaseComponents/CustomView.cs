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
using System;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// CustomView provides some common functionality required by all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CustomView : ViewWrapper
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusNavigationSupportProperty = BindableProperty.Create(nameof(FocusNavigationSupport), typeof(bool), typeof(CustomView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var customView = (CustomView)bindable;
            if (newValue != null)
            {
                customView.SetKeyboardNavigationSupport((bool)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var customView = (CustomView)bindable;
            return customView.IsKeyboardNavigationSupported();
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusGroupProperty = BindableProperty.Create(nameof(FocusGroup), typeof(bool), typeof(CustomView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var customView = (CustomView)bindable;
            if (newValue != null)
            {
                customView.SetAsKeyboardFocusGroup((bool)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var customView = (CustomView)bindable;
            return customView.IsKeyboardFocusGroup();
        });

        /// <summary>
        /// Create an instance of customView.
        /// </summary>
        /// <param name="typeName">typename</param>
        /// <param name="behaviour">CustomView Behaviour</param>
        /// <param name="viewStyle">CustomView ViewStyle</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CustomView(string typeName, CustomViewBehaviour behaviour, ViewStyle viewStyle) : this(typeName, behaviour)
        {
            InitializeStyle(viewStyle);
        }

        /// <summary>
        /// Create an instance of customView.
        /// </summary>
        /// <param name="typeName">typename</param>
        /// <param name="behaviour">CustomView Behaviour</param>
        /// <since_tizen> 3 </since_tizen>
        public CustomView(string typeName, CustomViewBehaviour behaviour) : base(typeName, new ViewWrapperImpl(behaviour))
        {
            Initialize();
        }

        /// <summary>
        /// Sets whether this control supports two dimensional keyboard navigation
        /// (i.e., whether it knows how to handle the keyboard focus movement between its child views).<br />
        /// The control doesn't support it by default.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool FocusNavigationSupport
        {
            get
            {
                return (bool)GetValue(FocusNavigationSupportProperty);
            }
            set
            {
                SetValue(FocusNavigationSupportProperty, value);
            }
        }

        /// <summary>
        /// Sets or gets whether this control is a focus group for keyboard navigation.
        /// </summary>
        /// <returns>True if this control is set as a focus group for keyboard navigation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool FocusGroup
        {
            get
            {
                return (bool)GetValue(FocusGroupProperty);
            }
            set
            {
                SetValue(FocusGroupProperty, value);
            }
        }

        /// <summary>
        /// Sets the background with a property map.
        /// </summary>
        /// <param name="map">The background property map.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetBackground(Tizen.NUI.PropertyMap map)
        {
            viewWrapperImpl.SetBackground(map);
        }

        /// <summary>
        /// Allows deriving classes to enable any of the gesture detectors that are available.<br />
        /// Gesture detection can be enabled one at a time or in a bitwise format.<br />
        /// </summary>
        /// <param name="type">The gesture type(s) to enable.</param>
        /// <since_tizen> 3 </since_tizen>
        public void EnableGestureDetection(Gesture.GestureType type)
        {
            viewWrapperImpl.EnableGestureDetection(type);
        }

        /// <summary>
        /// This method is called after the CustomView has been initialized.<br />
        /// After OnInitialize, the view will apply the style if it exists in the theme or it was given from constructor.<br />
        /// Derived classes should do any second phase initialization by overriding this method.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnInitialize()
        {
            SetAccessibilityConstructor(Role.Unknown);
            AppendAccessibilityAttribute("t", this.GetType().Name);
        }

        /// <summary>
        /// Called after the view has been connected to the stage.<br />
        /// When a view is connected, it will be directly or indirectly parented to the root view.<br />
        /// The root view is provided automatically by Tizen.NUI.Stage, and is always considered to be connected.<br />
        /// When the parent of a set of views is connected to the stage, then all of the children will receive this callback.<br />
        /// </summary>
        /// <param name="depth">The depth in the hierarchy for the view.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 8 and will be removed in API level 10. Please use OnSceneConnection instead!")]
        public virtual void OnStageConnection(int depth)
        {
        }

        /// <summary>
        /// Called after the view has been disconnected from the stage.<br />
        /// If a view is disconnected, it either has no parent, or is parented to a disconnected view.<br />
        /// When the parent of a set of views is disconnected to the stage, then all of the children will receive this callback, starting with the leaf views.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 8 and will be removed in API level 10. Please use OnSceneDisconnection instead!")]
        public virtual void OnStageDisconnection()
        {
        }

        /// <summary>
        /// Called after the view has been connected to the scene.<br />
        /// When a view is connected, it will be directly or indirectly parented to the root view.<br />
        /// The root view is provided automatically by Tizen.NUI.Window, and is always considered to be connected.<br />
        /// When the parent of a set of views is connected to the scene, then all of the children will receive this callback.<br />
        /// </summary>
        /// <param name="depth">The depth in the hierarchy for the view.</param>
        /// <since_tizen> 8 </since_tizen>
        public virtual void OnSceneConnection(int depth)
        {
        }

        /// <summary>
        /// Called after the view has been disconnected from the scene.<br />
        /// If a view is disconnected, it either has no parent, or is parented to a disconnected view.<br />
        /// When the parent of a set of views is disconnected to the scene, then all of the children will receive this callback, starting with the leaf views.<br />
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public virtual void OnSceneDisconnection()
        {
        }

        /// <summary>
        /// Called after a child has been added to the owning view.
        /// </summary>
        /// <param name="view">The child which has been added.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnChildAdd(View view)
        {
        }

        /// <summary>
        /// Called after the owning view has attempted to remove a child( regardless of whether it succeeded or not ).
        /// </summary>
        /// <param name="view">The child being removed.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnChildRemove(View view)
        {
        }

        /// <summary>
        /// Called when the owning view property is set.
        /// </summary>
        /// <param name="index">The property index that was set.</param>
        /// <param name="propertyValue">The value to set.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnPropertySet(int index, Tizen.NUI.PropertyValue propertyValue)
        {
        }

        /// <summary>
        /// Called when the owning view's size is set, for example, using View.SetSize().
        /// </summary>
        /// <param name="targetSize">The target size.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnSizeSet(Vector3 targetSize)
        {
        }

        /// <summary>
        /// Called when the owning view's size is animated, for example, using Animation::AnimateTo( Property ( view, View::Property::SIZE ), ... ).
        /// </summary>
        /// <param name="animation">The object which is animating the owning view.</param>
        /// <param name="targetSize">The target size.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnSizeAnimation(Animation animation, Vector3 targetSize)
        {
        }

        /// <summary>
        /// Called after a touch event is received by the owning view.<br />
        /// CustomViewBehaviour.REQUIRES_TOUCH_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br />
        /// </summary>
        /// <param name="touch">The touch event.</param>
        /// <returns>True if the event should be consumed.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual bool OnTouch(Touch touch)
        {
            return false; // Do not consume
        }

        /// <summary>
        /// Called after a hover event is received by the owning view.<br />
        /// CustomViewBehaviour.REQUIRES_HOVER_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br />
        /// </summary>
        /// <param name="hover">The hover event.</param>
        /// <returns>True if the hover event should be consumed.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual bool OnHover(Hover hover)
        {
            return false; // Do not consume
        }

        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual bool OnKey(Key key)
        {
            return false; // Do not consume
        }

        /// <summary>
        /// Called after a wheel event is received by the owning view.<br />
        /// CustomViewBehaviour.REQUIRES_WHEEL_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br />
        /// </summary>
        /// <param name="wheel">The wheel event.</param>
        /// <returns>True if the wheel event should be consumed.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual bool OnWheel(Wheel wheel)
        {
            return false; // Do not consume
        }

        /// <summary>
        /// Called after the size negotiation has been finished for this control.<br />
        /// The control is expected to assign this given size to itself or its children.<br />
        /// Should be overridden by derived classes if they need to layout views differently after certain operations like add or remove views, resize, or after changing specific properties.<br />
        /// As this function is called from inside the size negotiation algorithm, you cannot call RequestRelayout (the call would just be ignored).<br />
        /// </summary>
        /// <param name="size">The allocated size.</param>
        /// <param name="container">The control should add views to this container that it is not able to allocate a size for.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnRelayout(Vector2 size, RelayoutContainer container)
        {
        }

        /// <summary>
        /// Notification for deriving classes.
        /// </summary>
        /// <param name="policy">The policy being set.</param>
        /// <param name="dimension">The policy is being set for.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnSetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
        }

        /// <summary>
        /// Returns the natural size of the view.
        /// </summary>
        /// <returns>The view's natural size</returns>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1721: Property names should not match get methods")]
        public new virtual Size2D GetNaturalSize()
        {
            return (Size2D)GetValue(Size2DProperty);
        }

        /// <summary>
        /// Calculates the size for a child.
        /// </summary>
        /// <param name="child">The child view to calculate the size for.</param>
        /// <param name="dimension">The dimension to calculate the size, for example, the width or the height.</param>
        /// <returns>Return the calculated size for the given dimension. If more than one dimension is requested, just return the first one found.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual float CalculateChildSize(View child, DimensionType dimension)
        {
            return viewWrapperImpl.CalculateChildSizeBase(child, dimension);
        }

        /// <summary>
        /// This method is called during size negotiation when a height is required for a given width.<br />
        /// Derived classes should override this if they wish to customize the height returned.<br />
        /// </summary>
        /// <param name="width">Width to use</param>
        /// <returns>The height based on the width</returns>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Please use HeightForWidth property instead!")]
        public new virtual float GetHeightForWidth(float width)
        {
            return viewWrapperImpl.GetHeightForWidthBase(width);
        }

        /// <summary>
        /// This method is called during size negotiation when a width is required for a given height.<br />
        /// Derived classes should override this if they wish to customize the width returned.<br />
        /// </summary>
        /// <param name="height">Height to use</param>
        /// <returns>The width based on the width</returns>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Please use WidthForHeight property instead!")]
        public new virtual float GetWidthForHeight(float height)
        {
            return viewWrapperImpl.GetWidthForHeightBase(height);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout.
        /// </summary>
        /// <param name="dimension">The dimension(s) to check for.</param>
        /// <returns>Return if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual bool RelayoutDependentOnChildren(DimensionType dimension)
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase(dimension);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <returns>Return true if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual bool RelayoutDependentOnChildren()
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase();
        }

        /// <summary>
        /// The virtual method to notify deriving classes that relayout dependencies have been
        /// met and the size for this object is about to be calculated for the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension that is about to be calculated.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnCalculateRelayoutSize(DimensionType dimension)
        {
        }

        /// <summary>
        /// The virtual method to notify deriving classes that the size for a dimension has just been negotiated.
        /// </summary>
        /// <param name="size">The new size for the given dimension.</param>
        /// <param name="dimension">The dimension that was just negotiated.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnLayoutNegotiated(float size, DimensionType dimension)
        {
        }

        /// <summary>
        /// This method should be overridden by deriving classes requiring notifications when the style changes.
        /// </summary>
        /// <param name="styleManager">The StyleManager object.</param>
        /// <param name="change">Information denoting what has changed.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, Will be removed in API11.")]
        public virtual void OnStyleChange(StyleManager styleManager, StyleChangeType change)
        {
        }

        /// <summary>
        /// Called when the control gain key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is gained.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnFocusGained()
        {
        }

        /// <summary>
        /// Called when the control loses key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is lost.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnFocusLost()
        {
        }

        /// <summary>
        /// Gets the next keyboard focusable view in this control towards the given direction.<br />
        /// A control needs to override this function in order to support two dimensional keyboard navigation.<br />
        /// </summary>
        /// <param name="currentFocusedView">The current focused view.</param>
        /// <param name="direction">The direction to move the focus towards.</param>
        /// <param name="loopEnabled">Whether the focus movement should be looped within the control.</param>
        /// <returns>The next keyboard focusable view in this control or null if no view can be focused.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            return null;
        }

        /// <summary>
        /// Informs this control that its chosen focusable view will be focused.<br />
        /// This allows the application to preform any actions it wishes before the focus is actually moved to the chosen view.<br />
        /// </summary>
        /// <param name="commitedFocusableView">The commited focused view.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnFocusChangeCommitted(View commitedFocusableView)
        {
        }

        /// <summary>
        /// This method is called when the control has enter pressed on it.<br />
        /// Derived classes should override this to perform custom actions.<br />
        /// </summary>
        /// <returns>True if this control supported this action.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual bool OnKeyboardEnter()
        {
            return false;
        }

        /// <summary>
        /// Called whenever a pan gesture is detected on this control.<br />
        /// This should be overridden by deriving classes when pan detection is enabled.<br />
        /// There is no default behavior with panning.<br />
        /// Pan detection should be enabled via EnableGestureDetection().<br />
        /// </summary>
        /// <param name="pan">The pan gesture.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnPan(PanGesture pan)
        {
        }

        /// <summary>
        /// Called whenever a tap gesture is detected on this control.<br />
        /// This should be overridden by deriving classes when tap detection is enabled.<br />
        /// There is no default behavior with a tap.<br />
        /// Tap detection should be enabled via EnableGestureDetection().<br />
        /// </summary>
        /// <param name="tap">The tap gesture.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnTap(TapGesture tap)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool AccessibilityDoAction(string name)
        {
            if (name == AccessibilityActivateAction)
            {
                if (ActivateSignal?.Empty() == false)
                {
                    ActivateSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityActivated();
                }
            }
            else if (name == AccessibilityReadingSkippedAction)
            {
                if (ReadingSkippedSignal?.Empty() == false)
                {
                    ReadingSkippedSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingSkipped();
                }
            }
            else if (name == AccessibilityReadingCancelledAction)
            {
                if (ReadingCancelledSignal?.Empty() == false)
                {
                    ReadingCancelledSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingCancelled();
                }
            }
            else if (name == AccessibilityReadingStoppedAction)
            {
                if (ReadingStoppedSignal?.Empty() == false)
                {
                    ReadingStoppedSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingStopped();
                }
            }
            else if (name == AccessibilityReadingPausedAction)
            {
                if (ReadingPausedSignal?.Empty() == false)
                {
                    ReadingPausedSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingPaused();
                }
            }
            else if (name == AccessibilityReadingResumedAction)
            {
                if (ReadingResumedSignal?.Empty() == false)
                {
                    ReadingResumedSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingResumed();
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method is called when the control accessibility is activated.<br />
        /// Derived classes should override this to perform custom accessibility activation.<br />
        /// </summary>
        /// <returns>True if this control can perform accessibility activation.</returns>
        internal virtual bool OnAccessibilityActivated()
        {
            return false;
        }

        /// <summary>
        /// This method is called when reading is skipped.
        /// </summary>
        /// <returns>True if information was served.</returns>
        internal virtual bool OnAccessibilityReadingSkipped()
        {
            return false;
        }

        /// <summary>
        /// This method is called when reading is cancelled.
        /// </summary>
        /// <returns>True if information was served.</returns>
        internal virtual bool OnAccessibilityReadingCancelled()
        {
            return false;
        }
        /// <summary>
        /// This method is called when reading is stopped.
        /// </summary>
        /// <returns>True if information was served.</returns>
        internal virtual bool OnAccessibilityReadingStopped()
        {
            return false;
        }
        /// <summary>
        /// This method is called when reading was paused.
        /// </summary>
        /// <returns>True if information was served.</returns>
        internal virtual bool OnAccessibilityReadingPaused()
        {
            return false;
        }
        /// <summary>
        /// This method is called when reading is resumed.
        /// </summary>
        /// <returns>True if information was served.</returns>
        internal virtual bool OnAccessibilityReadingResumed()
        {
            return false;
        }

        /// <summary>
        /// This method should be overridden by deriving classes when they wish to respond the accessibility.
        /// </summary>
        /// <param name="gestures">The pan gesture.</param>
        /// <returns>True if the pan gesture has been consumed by this control.</returns>
        internal virtual bool OnAccessibilityPan(PanGesture gestures)
        {
            return false;
        }

        /// <summary>
        /// This method should be overridden by deriving classes when they wish to respond the accessibility up and down action (i.e., value change of slider control).
        /// </summary>
        /// <param name="isIncrease">Whether the value should be increased or decreased.</param>
        /// <returns>True if the value changed action has been consumed by this control.</returns>
        internal virtual bool OnAccessibilityValueChange(bool isIncrease)
        {
            return false;
        }

        /// <summary>
        /// This method should be overridden by deriving classes when they wish to respond the accessibility zoom action.
        /// </summary>
        /// <returns>True if the zoom action has been consumed by this control.</returns>
        internal virtual bool OnAccessibilityZoom()
        {
            return false;
        }

        /// <summary>
        /// Allows deriving classes to disable any of the gesture detectors.<br />
        /// Like EnableGestureDetection, this can also be called using bitwise or one at a time.<br />
        /// </summary>
        /// <param name="type">The gesture type(s) to disable.</param>
        internal void DisableGestureDetection(Gesture.GestureType type)
        {
            viewWrapperImpl.DisableGestureDetection(type);
        }

        internal void SetKeyboardNavigationSupport(bool isSupported)
        {
            viewWrapperImpl.SetKeyboardNavigationSupport(isSupported);
        }

        /// <summary>
        /// Gets whether this control supports two-dimensional keyboard navigation.
        /// </summary>
        /// <returns>True if this control supports two-dimensional keyboard navigation.</returns>
        internal bool IsKeyboardNavigationSupported()
        {
            return viewWrapperImpl.IsKeyboardNavigationSupported();
        }

        /// <summary>
        /// Sets whether this control is a focus group for keyboard navigation.
        /// (i.e., the scope of keyboard focus movement can be limitied to its child views). The control is not a focus group by default.
        /// </summary>
        /// <param name="isFocusGroup">Whether this control is set as a focus group for keyboard navigation.</param>
        internal void SetAsKeyboardFocusGroup(bool isFocusGroup)
        {
            viewWrapperImpl.SetAsFocusGroup(isFocusGroup);
        }

        /// <summary>
        /// Gets whether this control is a focus group for keyboard navigation.
        /// </summary>
        internal bool IsKeyboardFocusGroup()
        {
            return viewWrapperImpl.IsFocusGroup();
        }

        /// <summary>
        /// Called whenever a pinch gesture is detected on this control.<br />
        /// This can be overridden by deriving classes when pinch detection is enabled. The default behavior is to scale the control by the pinch scale.<br />
        /// If overridden, then the default behavior will not occur.<br />
        /// Pinch detection should be enabled via EnableGestureDetection().<br />
        /// </summary>
        /// <param name="pinch">The pinch tap gesture.</param>
        internal virtual void OnPinch(PinchGesture pinch)
        {
        }

        /// <summary>
        /// Called whenever a long press gesture is detected on this control.<br />
        /// This should be overridden by deriving classes when long press detection is enabled.<br />
        /// There is no default behavior associated with a long press.<br />
        /// Long press detection should be enabled via EnableGestureDetection().<br />
        /// </summary>
        /// <param name="longPress">The long press gesture.</param>
        internal virtual void OnLongPress(LongPressGesture longPress)
        {
        }

        /// <summary>
        /// Requests a relayout, which means performing a size negotiation on this view, its parent, and children (and potentially whole scene).<br />
        /// This method can also be called from a derived class every time it needs a different size.<br />
        /// At the end of event processing, the relayout process starts and all controls which requested relayout will have their sizes (re)negotiated.<br />
        /// It can be called multiple times; the size negotiation is still only performed once, i.e., there is no need to keep track of this in the calling side.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected void RelayoutRequest()
        {
            viewWrapperImpl.RelayoutRequest();
        }

        /// <summary>
        /// Provides the view implementation of GetHeightForWidth.
        /// </summary>
        /// <param name="width">The width to use.</param>
        /// <returns>The height based on the width.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected float GetHeightForWidthBase(float width)
        {
            return viewWrapperImpl.GetHeightForWidthBase(width);
        }

        /// <summary>
        /// Provides the view implementation of GetWidthForHeight.
        /// </summary>
        /// <param name="height">The height to use.</param>
        /// <returns>The width based on the height.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected float GetWidthForHeightBase(float height)
        {
            return viewWrapperImpl.GetWidthForHeightBase(height);
        }

        /// <summary>
        /// Calculates the size for a child using the base view object.
        /// </summary>
        /// <param name="child">The child view to calculate the size for.</param>
        /// <param name="dimension">The dimension to calculate the size, for example, the width or the height.</param>
        /// <returns>Return the calculated size for the given dimension. If more than one dimension is requested, just return the first one found.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected float CalculateChildSizeBase(View child, DimensionType dimension)
        {
            return viewWrapperImpl.CalculateChildSizeBase(child, dimension);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <param name="dimension">The dimension(s) to check for.</param>
        /// <returns>Return if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected bool RelayoutDependentOnChildrenBase(DimensionType dimension)
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase(dimension);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <returns>Return if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected bool RelayoutDependentOnChildrenBase()
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase();
        }

        /// <summary>
        /// Registers a visual by property index, linking a view to visual when required.<br />
        /// In the case of the visual being a view or control deeming visual not required, then the visual should be an empty handle.<br />
        /// No parenting is done during registration, this should be done by a derived class.<br />
        /// </summary>
        /// <param name="index">The property index of the visual used to reference visual.</param>
        /// <param name="visual">The visual to register.</param>
        /// <since_tizen> 3 </since_tizen>
        protected void RegisterVisual(int index, VisualBase visual)
        {
            viewWrapperImpl.RegisterVisual(index, visual);
        }

        /// <summary>
        /// Registers a visual by the property index, linking a view to visual when required.<br />
        /// In the case of the visual being a view or control deeming visual not required, then the visual should be an empty handle.<br />
        /// If enabled is false, then the visual is not set on the stage until enabled by the derived class.<br />
        /// </summary>
        /// <param name="index">The property index of the visual used to reference visual.</param>
        /// <param name="visual">The visual to register.</param>
        /// <param name="enabled">False if derived class wants to control when the visual is set on the stage.</param>
        /// <since_tizen> 3 </since_tizen>
        protected void RegisterVisual(int index, VisualBase visual, bool enabled)
        {
            viewWrapperImpl.RegisterVisual(index, visual, enabled);
        }

        /// <summary>
        /// Erases the entry matching the given index from the list of registered visuals.
        /// </summary>
        /// <param name="index">The property index of the visual used to reference visual.</param>
        /// <since_tizen> 3 </since_tizen>
        protected void UnregisterVisual(int index)
        {
            viewWrapperImpl.UnregisterVisual(index);
        }

        /// <summary>
        /// Retrieves the visual associated with the given property index.<br />
        /// For managing the object lifecycle, do not store the returned visual as a member which increments its reference count.<br />
        /// </summary>
        /// <param name="index">The property index of the visual used to reference visual.</param>
        /// <returns>The registered visual if exists, otherwise an empty handle.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected VisualBase GetVisual(int index)
        {
            return viewWrapperImpl.GetVisual(index);
        }

        /// <summary>
        /// Sets the given visual to be displayed or not when parent staged.<br />
        /// For managing the object lifecycle, do not store the returned visual as a member which increments its reference count.<br />
        /// </summary>
        /// <param name="index">The property index of the visual, used to reference visual.</param>
        /// <param name="enable">Flag set to enabled or disabled.</param>
        /// <since_tizen> 3 </since_tizen>
        protected void EnableVisual(int index, bool enable)
        {
            viewWrapperImpl.EnableVisual(index, enable);
        }

        /// <summary>
        /// Queries if the given visual is to be displayed when parent staged.<br />
        /// For managing the object lifecycle, do not store the returned visual as a member which increments its reference count.<br />
        /// </summary>
        /// <param name="index">The property index of the visual.</param>
        /// <returns>Whether visual is enabled or not.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected bool IsVisualEnabled(int index)
        {
            return viewWrapperImpl.IsVisualEnabled(index);
        }

        /// <summary>
        /// Creates a transition effect on the control.
        /// </summary>
        /// <param name="transitionData">The transition data describing the effect to create.</param>
        /// <returns>A handle to an animation defined with the given effect, or an empty handle if no properties match.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected Animation CreateTransition(TransitionData transitionData)
        {
            return viewWrapperImpl.CreateTransition(transitionData);
        }

        /// <summary>
        /// Emits the KeyInputFocusGained signal if true, else, emits the KeyInputFocusLost signal.<br />
        /// Should be called last by the control after it acts on the input focus change.<br />
        /// </summary>
        /// <param name="focusGained">True if gained, false if lost.</param>
        /// <since_tizen> 3 </since_tizen>
        protected void EmitFocusSignal(bool focusGained)
        {
            viewWrapperImpl.EmitFocusSignal(focusGained);
        }

        private void Initialize()
        {
            // Registering CustomView virtual functions to viewWrapperImpl delegates.
            viewWrapperImpl.OnSceneConnection = new ViewWrapperImpl.OnSceneConnectionDelegate(OnSceneConnection);
            viewWrapperImpl.OnSceneDisconnection = new ViewWrapperImpl.OnSceneDisconnectionDelegate(OnSceneDisconnection);
            viewWrapperImpl.OnStageConnection = new ViewWrapperImpl.OnSceneConnectionDelegate(OnStageConnection);
            viewWrapperImpl.OnStageDisconnection = new ViewWrapperImpl.OnSceneDisconnectionDelegate(OnStageDisconnection);
            viewWrapperImpl.OnChildAdd = new ViewWrapperImpl.OnChildAddDelegate(OnChildAdd);
            viewWrapperImpl.OnChildRemove = new ViewWrapperImpl.OnChildRemoveDelegate(OnChildRemove);
            viewWrapperImpl.OnPropertySet = new ViewWrapperImpl.OnPropertySetDelegate(OnPropertySet);
            viewWrapperImpl.OnSizeSet = new ViewWrapperImpl.OnSizeSetDelegate(OnSizeSet);
            viewWrapperImpl.OnSizeAnimation = new ViewWrapperImpl.OnSizeAnimationDelegate(OnSizeAnimation);
            viewWrapperImpl.OnTouch = new ViewWrapperImpl.OnTouchDelegate(OnTouch);
            viewWrapperImpl.OnHover = new ViewWrapperImpl.OnHoverDelegate(OnHover);
            viewWrapperImpl.OnKey = new ViewWrapperImpl.OnKeyDelegate(OnKey);
            viewWrapperImpl.OnWheel = new ViewWrapperImpl.OnWheelDelegate(OnWheel);
            viewWrapperImpl.OnRelayout = new ViewWrapperImpl.OnRelayoutDelegate(OnRelayout);
            viewWrapperImpl.OnSetResizePolicy = new ViewWrapperImpl.OnSetResizePolicyDelegate(OnSetResizePolicy);
            viewWrapperImpl.GetNaturalSize = new ViewWrapperImpl.GetNaturalSizeDelegate(GetNaturalSize);
            viewWrapperImpl.CalculateChildSize = new ViewWrapperImpl.CalculateChildSizeDelegate(CalculateChildSize);
            viewWrapperImpl.GetHeightForWidth = new ViewWrapperImpl.GetHeightForWidthDelegate(GetHeightForWidth);
            viewWrapperImpl.GetWidthForHeight = new ViewWrapperImpl.GetWidthForHeightDelegate(GetWidthForHeight);
            viewWrapperImpl.RelayoutDependentOnChildrenDimension = new ViewWrapperImpl.RelayoutDependentOnChildrenDimensionDelegate(RelayoutDependentOnChildren);
            viewWrapperImpl.RelayoutDependentOnChildren = new ViewWrapperImpl.RelayoutDependentOnChildrenDelegate(RelayoutDependentOnChildren);
            viewWrapperImpl.OnCalculateRelayoutSize = new ViewWrapperImpl.OnCalculateRelayoutSizeDelegate(OnCalculateRelayoutSize);
            viewWrapperImpl.OnLayoutNegotiated = new ViewWrapperImpl.OnLayoutNegotiatedDelegate(OnLayoutNegotiated);
            viewWrapperImpl.OnStyleChange = new ViewWrapperImpl.OnStyleChangeDelegate(OnStyleChange);
            viewWrapperImpl.OnAccessibilityActivated = new ViewWrapperImpl.OnAccessibilityActivatedDelegate(OnAccessibilityActivated);
            viewWrapperImpl.OnAccessibilityPan = new ViewWrapperImpl.OnAccessibilityPanDelegate(OnAccessibilityPan);
            viewWrapperImpl.OnAccessibilityValueChange = new ViewWrapperImpl.OnAccessibilityValueChangeDelegate(OnAccessibilityValueChange);
            viewWrapperImpl.OnAccessibilityZoom = new ViewWrapperImpl.OnAccessibilityZoomDelegate(OnAccessibilityZoom);
            viewWrapperImpl.OnFocusGained = new ViewWrapperImpl.OnFocusGainedDelegate(OnFocusGained);
            viewWrapperImpl.OnFocusLost = new ViewWrapperImpl.OnFocusLostDelegate(OnFocusLost);
            viewWrapperImpl.GetNextFocusableView = new ViewWrapperImpl.GetNextFocusableViewDelegate(GetNextFocusableView);
            viewWrapperImpl.OnFocusChangeCommitted = new ViewWrapperImpl.OnFocusChangeCommittedDelegate(OnFocusChangeCommitted);
            viewWrapperImpl.OnKeyboardEnter = new ViewWrapperImpl.OnKeyboardEnterDelegate(OnKeyboardEnter);
            viewWrapperImpl.OnPinch = new ViewWrapperImpl.OnPinchDelegate(OnPinch);
            viewWrapperImpl.OnPan = new ViewWrapperImpl.OnPanDelegate(OnPan);
            viewWrapperImpl.OnTap = new ViewWrapperImpl.OnTapDelegate(OnTap);
            viewWrapperImpl.OnLongPress = new ViewWrapperImpl.OnLongPressDelegate(OnLongPress);

            // Set the StyleName the name of the View
            // We have to do this because the StyleManager on Native side can't workout it out
            // This will also ensure that the style of views/visuals initialized above are applied by the style manager.
            SetStyleName(this.GetType().Name);

            OnInitialize();
        }
    }
}
