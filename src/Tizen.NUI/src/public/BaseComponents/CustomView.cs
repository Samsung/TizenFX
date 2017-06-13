/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// CustomView provides some common functionality required by all views.
    /// </summary>
    public class CustomView : ViewWrapper
    {
        public CustomView(string typeName, CustomViewBehaviour behaviour) : base(typeName, new ViewWrapperImpl(behaviour))
        {
            // Registering CustomView virtual functions to viewWrapperImpl delegates.
            viewWrapperImpl.OnStageConnection = new ViewWrapperImpl.OnStageConnectionDelegate(OnStageConnection);
            viewWrapperImpl.OnStageDisconnection = new ViewWrapperImpl.OnStageDisconnectionDelegate(OnStageDisconnection);
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
            viewWrapperImpl.OnControlChildAdd = new ViewWrapperImpl.OnControlChildAddDelegate(OnControlChildAdd);
            viewWrapperImpl.OnControlChildRemove = new ViewWrapperImpl.OnControlChildRemoveDelegate(OnControlChildRemove);
            viewWrapperImpl.OnStyleChange = new ViewWrapperImpl.OnStyleChangeDelegate(OnStyleChange);
            viewWrapperImpl.OnAccessibilityActivated = new ViewWrapperImpl.OnAccessibilityActivatedDelegate(OnAccessibilityActivated);
            viewWrapperImpl.OnAccessibilityPan = new ViewWrapperImpl.OnAccessibilityPanDelegate(OnAccessibilityPan);
            viewWrapperImpl.OnAccessibilityTouch = new ViewWrapperImpl.OnAccessibilityTouchDelegate(OnAccessibilityTouch);
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

            // By default, we do not want the position to use the anchor point
            this.PositionUsesAnchorPoint = false;

            // Make sure CustomView is initialized.
            OnInitialize();

            // Set the StyleName the name of the View
            // We have to do this because the StyleManager on Native side can't workout it out
            // This will also ensure that the style of views/visuals initialized above are applied by the style manager.
            SetStyleName(this.GetType().Name);
        }

        /// <summary>
        /// Set the background with a property map.
        /// </summary>
        /// <param name="map">The background property map</param>
        public void SetBackground(Tizen.NUI.PropertyMap map)
        {
            viewWrapperImpl.SetBackground(map);
        }

        /// <summary>
        /// Allows deriving classes to enable any of the gesture detectors that are available.<br>
        /// Gesture detection can be enabled one at a time or in bitwise format.<br>
        /// </summary>
        /// <param name="type">The gesture type(s) to enable</param>
        public void EnableGestureDetection(Gesture.GestureType type)
        {
            viewWrapperImpl.EnableGestureDetection(type);
        }

        /// <summary>
        /// Allows deriving classes to disable any of the gesture detectors.<br>
        /// Like EnableGestureDetection, this can also be called using bitwise or one at a time.<br>
        /// </summary>
        /// <param name="type">The gesture type(s) to disable</param>
        internal void DisableGestureDetection(Gesture.GestureType type)
        {
            viewWrapperImpl.DisableGestureDetection(type);
        }

        /// <summary>
        /// Sets whether this control supports two dimensional keyboard navigation
        /// (i.e. whether it knows how to handle the keyboard focus movement between its child views).<br>
        /// The control doesn't support it by default.<br>
        /// </summary>
        /// <param name="isSupported">Whether this control supports two dimensional keyboard navigation.</param>
        public bool FocusNavigationSupport
        {
            get
            {
                return IsKeyboardNavigationSupported();
            }
            set
            {
                SetKeyboardNavigationSupport(value);
            }
        }

        internal void SetKeyboardNavigationSupport(bool isSupported)
        {
            viewWrapperImpl.SetKeyboardNavigationSupport(isSupported);
        }

        /// <summary>
        /// Gets whether this control supports two dimensional keyboard navigation.
        /// </summary>
        /// <returns>true if this control supports two dimensional keyboard navigation</returns>
        internal bool IsKeyboardNavigationSupported()
        {
            return viewWrapperImpl.IsKeyboardNavigationSupported();
        }


        /// <summary>
        /// Sets or Gets whether this control is a focus group for keyboard navigation.
        /// </summary>
        /// <returns>true if this control is set as a focus group for keyboard navigation</returns>
        public bool FocusGroup
        {
            get
            {
                return IsKeyboardFocusGroup();
            }
            set
            {
                SetAsKeyboardFocusGroup(value);
            }
        }

        /// <summary>
        /// Sets whether this control is a focus group for keyboard navigation.
        /// (i.e. the scope of keyboard focus movement can be limitied to its child views). The control is not a focus group by default.
        /// </summary>
        /// <param name="isFocusGroup">Whether this control is set as a focus group for keyboard navigation</param>
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
        /// Called by the AccessibilityManager to activate the Control.
        /// </summary>
        internal void AccessibilityActivate()
        {
            viewWrapperImpl.AccessibilityActivate();
        }

        /// <summary>
        /// Called by the KeyboardFocusManager.
        /// </summary>
        internal void KeyboardEnter()
        {
            viewWrapperImpl.KeyboardEnter();
        }

        /// <summary>
        /// Called by the KeyInputFocusManager to emit key event signals.
        /// </summary>
        /// <param name="key">The key event</param>
        /// <returns>True if the event was consumed</returns>
        internal bool EmitKeyEventSignal(Key key)
        {
            return viewWrapperImpl.EmitKeyEventSignal(key);
        }

        /// <summary>
        /// Request a relayout, which means performing a size negotiation on this view, its parent and children (and potentially whole scene).<br>
        /// This method can also be called from a derived class every time it needs a different size.<br>
        /// At the end of event processing, the relayout process starts and all controls which requested Relayout will have their sizes (re)negotiated.<br>
        /// It can be called multiple times; the size negotiation is still only performed once, i.e. there is no need to keep track of this in the calling side.<br>
        /// <summary>
        protected void RelayoutRequest()
        {
            viewWrapperImpl.RelayoutRequest();
        }

        /// <summary>
        /// Provides the View implementation of GetHeightForWidth.
        /// <summary>
        /// <param name="width">Width to use</param>
        /// <returns>The height based on the width</returns>
        protected float GetHeightForWidthBase(float width)
        {
            return viewWrapperImpl.GetHeightForWidthBase(width);
        }

        /// <summary>
        /// Provides the View implementation of GetWidthForHeight.
        /// </summary>
        /// <param name="height">Height to use</param>
        /// <returns>The width based on the height</returns>
        protected float GetWidthForHeightBase(float height)
        {
            return viewWrapperImpl.GetWidthForHeightBase(height);
        }

        /// <summary>
        /// Calculate the size for a child using the base view object.
        /// </summary>
        /// <param name="child">The child view to calculate the size for</param>
        /// <param name="dimension">The dimension to calculate the size for. E.g. width or height</param>
        /// <returns>Return the calculated size for the given dimension. If more than one dimension is requested, just return the first one found</returns>
        protected float CalculateChildSizeBase(View child, DimensionType dimension)
        {
            return viewWrapperImpl.CalculateChildSizeBase(child, dimension);
        }

        /// <summary>
        /// Determine if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <param name="dimension">The dimension(s) to check for</param>
        /// <returns>Return if the view is dependent on it's children</returns>
        protected bool RelayoutDependentOnChildrenBase(DimensionType dimension)
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase(dimension);
        }

        /// <summary>
        /// Determine if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <returns>Return if the view is dependent on it's children</returns>
        protected bool RelayoutDependentOnChildrenBase()
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase();
        }

        /// <summary>
        /// Register a visual by Property Index, linking an View to visual when required.<br>
        /// In the case of the visual being an view or control deeming visual not required then visual should be an empty handle.<br>
        /// No parenting is done during registration, this should be done by derived class.<br>
        /// </summary>
        /// <param name="index">The Property index of the visual, used to reference visual</param>
        /// <param name="visual">The visual to register</param>
        protected void RegisterVisual(int index, VisualBase visual)
        {
            viewWrapperImpl.RegisterVisual(index, visual);
        }

        /// <summary>
        /// Register a visual by Property Index, linking an View to visual when required.<br>
        /// In the case of the visual being an view or control deeming visual not required then visual should be an empty handle.<br>
        /// If enabled is false then the visual is not set on stage until enabled by the derived class.<br>
        /// </summary>
        /// <param name="index">The Property index of the visual, used to reference visual</param>
        /// <param name="visual">The visual to register</param>
        /// <param name="enabled">false if derived class wants to control when visual is set on stage</param>
        protected void RegisterVisual(int index, VisualBase visual, bool enabled)
        {
            viewWrapperImpl.RegisterVisual(index, visual, enabled);
        }

        /// <summary>
        /// Erase the entry matching the given index from the list of registered visuals.
        /// </summary>
        /// <param name="index">The Property index of the visual, used to reference visual</param>
        protected void UnregisterVisual(int index)
        {
            viewWrapperImpl.UnregisterVisual(index);
        }

        /// <summary>
        /// Retrieve the visual associated with the given property index.<br>
        /// For managing object life-cycle, do not store the returned visual as a member which increments its reference count.<br>
        /// </summary>
        /// <param name="index">The Property index of the visual, used to reference visual</param>
        /// <returns>The registered visual if exist, otherwise empty handle</returns>
        protected VisualBase GetVisual(int index)
        {
            return viewWrapperImpl.GetVisual(index);
        }

        /// <summary>
        /// Sets the given visual to be displayed or not when parent staged.<br>
        /// For managing object life-cycle, do not store the returned visual as a member which increments its reference count.<br>
        /// </summary>
        /// <param name="index">The Property index of the visual, used to reference visual</param>
        /// <param name="enable">flag to set enabled or disabled</param>
        protected void EnableVisual(int index, bool enable)
        {
            viewWrapperImpl.EnableVisual(index, enable);
        }

        /// <summary>
        /// Queries if the given visual is to be displayed when parent staged.<br>
        /// For managing object life-cycle, do not store the returned visual as a member which increments its reference count.<br>
        /// </summary>
        /// <param name="index">The Property index of the visual</param>
        /// <returns>Whether visual is enabled or not</returns>
        protected bool IsVisualEnabled(int index)
        {
            return viewWrapperImpl.IsVisualEnabled(index);
        }

        /// <summary>
        /// Create a transition effect on the control.
        /// </summary>
        /// <param name="transitionData">transitionData The transition data describing the effect to create</param>
        /// <returns>A handle to an animation defined with the given effect, or an empty handle if no properties match </returns>
        protected Animation CreateTransition(TransitionData transitionData)
        {
            return viewWrapperImpl.CreateTransition(transitionData);
        }

        /// <summary>
        /// Emits KeyInputFocusGained signal if true else emits KeyInputFocusLost signal.<br>
        /// Should be called last by the control after it acts on the Input Focus change.<br>
        /// </summary>
        /// <param name="focusGained">focusGained True if gained, False if lost</param>
        protected void EmitFocusSignal(bool focusGained)
        {
            viewWrapperImpl.EmitFocusSignal(focusGained);
        }

        /// <summary>
        /// This method is called after the Control has been initialized.<br>
        /// Derived classes should do any second phase initialization by overriding this method.<br>
        /// </summary>
        public virtual void OnInitialize()
        {
        }

        /// <summary>
        /// Called after the view has been connected to the stage.<br>
        /// When an view is connected, it will be directly or indirectly parented to the root View.<br>
        /// The root View is provided automatically by Tizen.NUI.Stage, and is always considered to be connected.<br>
        /// When the parent of a set of views is connected to the stage, then all of the children will received this callback.<br>
        /// </summary>
        /// <param name="depth">The depth in the hierarchy for the view</param>
        public virtual void OnStageConnection(int depth)
        {
        }

        /// <summary>
        /// Called after the view has been disconnected from Stage.<br>
        /// If an view is disconnected it either has no parent, or is parented to a disconnected view.<br>
        /// When the parent of a set of views is disconnected to the stage, then all of the children will received this callback, starting with the leaf views.<br>
        /// </summary>
        public virtual void OnStageDisconnection()
        {
        }

        /// <summary>
        /// Called after a child has been added to the owning view.
        /// </summary>
        /// <param name="view">The child which has been added</param>
        public virtual void OnChildAdd(View view)
        {
        }

        /// <summary>
        /// Called after the owning view has attempted to remove a child( regardless of whether it succeeded or not ).
        /// </summary>
        /// <param name="view">The child being removed</param>
        public virtual void OnChildRemove(View view)
        {
        }

        /// <summary>
        /// Called when the owning view property is set.
        /// </summary>
        /// <param name="index">The Property index that was set</param>
        /// <param name="propertyValue">The value to set</param>
        public virtual void OnPropertySet(int index, Tizen.NUI.PropertyValue propertyValue)
        {
        }

        /// <summary>
        /// Called when the owning view's size is set e.g. using View.SetSize().
        /// </summary>
        /// <param name="targetSize">The target size</param>
        public virtual void OnSizeSet(Vector3 targetSize)
        {
        }

        /// <summary>
        /// Called when the owning view's size is animated e.g. using Animation::AnimateTo( Property( view, View::Property::SIZE ), ... ).
        /// </summary>
        /// <param name="animation">The object which is animating the owning view</param>
        /// <param name="targetSize">The target size</param>
        public virtual void OnSizeAnimation(Animation animation, Vector3 targetSize)
        {
        }

        /// <summary>
        /// Called after a touch-event is received by the owning view.<br>
        /// CustomViewBehaviour.REQUIRES_TOUCH_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br>
        /// </summary>
        /// <param name="touch">The touch event</param>
        /// <returns>True if the event should be consumed</returns>
        public virtual bool OnTouch(Touch touch)
        {
            return false; // Do not consume
        }

        /// <summary>
        /// Called after a hover-event is received by the owning view.<br>
        /// CustomViewBehaviour.REQUIRES_HOVER_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br>
        /// </summary>
        /// <param name="hover">The hover event</param>
        /// <returns>True if the hover event should be consumed</returns>
        public virtual bool OnHover(Hover hover)
        {
            return false; // Do not consume
        }

        /// <summary>
        /// Called after a key-event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event</param>
        /// <returns>True if the key event should be consumed</returns>
        public virtual bool OnKey(Key key)
        {
            return false; // Do not consume
        }

        /// <summary>
        /// Called after a wheel-event is received by the owning view.<br>
        /// CustomViewBehaviour.REQUIRES_WHEEL_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br>
        /// </summary>
        /// <param name="wheel">The wheel event</param>
        /// <returns>True if the wheel event should be consumed</returns>
        public virtual bool OnWheel(Wheel wheel)
        {
            return false; // Do not consume
        }

        /// <summary>
        /// Called after the size negotiation has been finished for this control.<br>
        /// The control is expected to assign this given size to itself/its children.<br>
        /// Should be overridden by derived classes if they need to layout views differently after certain operations like add or remove views, resize or after changing specific properties.<br>
        /// As this function is called from inside the size negotiation algorithm, you cannot call RequestRelayout (the call would just be ignored).<br>
        /// </summary>
        /// <param name="size">The allocated size</param>
        /// <param name="container">The control should add views to this container that it is not able to allocate a size for</param>
        public virtual void OnRelayout(Vector2 size, RelayoutContainer container)
        {
        }

        /// <summary>
        /// Notification for deriving classes.
        /// </summary>
        /// <param name="policy">policy The policy being set</param>
        /// <param name="dimension">dimension The dimension the policy is being set for</param>
        public virtual void OnSetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
        }

        /// <summary>
        /// Return the natural size of the view.
        /// </summary>
        /// <returns>The view's natural size</returns>
        public virtual Size2D GetNaturalSize()
        {
            return new Size2D(0, 0);
        }

        /// <summary>
        /// Calculate the size for a child.
        /// </summary>
        /// <param name="child">The child view to calculate the size for</param>
        /// <param name="dimension">The dimension to calculate the size for. E.g. width or height</param>
        /// <returns>Return the calculated size for the given dimension. If more than one dimension is requested, just return the first one found.</returns>
        public virtual float CalculateChildSize(View child, DimensionType dimension)
        {
            return viewWrapperImpl.CalculateChildSizeBase(child, dimension);
        }

        /// <summary>
        /// This method is called during size negotiation when a height is required for a given width.<br>
        /// Derived classes should override this if they wish to customize the height returned.<br>
        /// </summary>
        /// <param name="width">Width to use</param>
        /// <returns>The height based on the width</returns>
        public virtual float GetHeightForWidth(float width)
        {
            return viewWrapperImpl.GetHeightForWidthBase(width);
        }

        /// <summary>
        /// This method is called during size negotiation when a width is required for a given height.<br>
        /// Derived classes should override this if they wish to customize the width returned.<br>
        /// </summary>
        /// <param name="height">Height to use</param>
        /// <returns>The width based on the width</returns>
        public virtual float GetWidthForHeight(float height)
        {
            return viewWrapperImpl.GetWidthForHeightBase(height);
        }

        /// <summary>
        /// Determine if this view is dependent on it's children for relayout.
        /// </summary>
        /// <param name="dimension">The dimension(s) to check for</param>
        /// <returns>Return if the view is dependent on it's children</returns>
        public virtual bool RelayoutDependentOnChildren(DimensionType dimension)
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase(dimension);
        }

        /// <summary>
        /// Determine if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <returns>Return true if the view is dependent on it's children</returns>
        public virtual bool RelayoutDependentOnChildren()
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase();
        }

        /// <summary>
        /// Virtual method to notify deriving classes that relayout dependencies have been
        /// met and the size for this object is about to be calculated for the given dimension.
        /// </summary>
        /// <param name="dimension">The dimension that is about to be calculated</param>
        public virtual void OnCalculateRelayoutSize(DimensionType dimension)
        {
        }

        /// <summary>
        /// Virtual method to notify deriving classes that the size for a dimension has just been negotiated.
        /// </summary>
        /// <param name="size">The new size for the given dimension</param>
        /// <param name="dimension">The dimension that was just negotiated</param>
        public virtual void OnLayoutNegotiated(float size, DimensionType dimension)
        {
        }

        /// <summary>
        /// This method should be overridden by deriving classes requiring notifications when the style changes.
        /// </summary>
        /// <param name="styleManager">The StyleManager object</param>
        /// <param name="change">Information denoting what has changed</param>
        public virtual void OnStyleChange(StyleManager styleManager, StyleChangeType change)
        {
        }

        /// <summary>
        /// This method is called when the control is accessibility activated.<br>
        /// Derived classes should override this to perform custom accessibility activation.<br>
        /// </summary>
        /// <returns>true if this control can perform accessibility activation</returns>
        internal virtual bool OnAccessibilityActivated()
        {
            return false;
        }

        /// <summary>
        /// This method should be overridden by deriving classes when they wish to respond the accessibility.
        /// </summary>
        /// <param name="gestures">The pan gesture</param>
        /// <returns>true if the pan gesture has been consumed by this control</returns>
        internal virtual bool OnAccessibilityPan(PanGesture gestures)
        {
            return false;
        }

        /// <summary>
        /// This method should be overridden by deriving classes when they wish to respond the accessibility
        /// </summary>
        /// <param name="touch">The touch gesture</param>
        /// <returns>true if the touch event has been consumed by this control</returns>
        internal virtual bool OnAccessibilityTouch(Touch touch)
        {
            return false;
        }

        /// <summary>
        /// This method should be overridden by deriving classes when they wish to respond the accessibility up and down action (i.e. value change of slider control).
        /// </summary>
        /// <param name="isIncrease">isIncrease Whether the value should be increased or decreased</param>
        /// <returns>true if the value changed action has been consumed by this control</returns>
        internal virtual bool OnAccessibilityValueChange(bool isIncrease)
        {
            return false;
        }

        /// <summary>
        /// This method should be overridden by deriving classes when they wish to respond the accessibility zoom action.
        /// </summary>
        /// <returns>true if the zoom action has been consumed by this control</returns>
        internal virtual bool OnAccessibilityZoom()
        {
            return false;
        }

        /// <summary>
        /// Called when the control gain key input focus. Should be overridden by derived classes if they need to customize what happens when focus is gained.
        /// </summary>
        public virtual void OnFocusGained()
        {
        }

        /// <summary>
        /// Called when the control loses key input focus. Should be overridden by derived classes if they need to customize what happens when focus is lost.
        /// </summary>
        public virtual void OnFocusLost()
        {
        }

        /// <summary>
        /// Gets the next keyboard focusable view in this control towards the given direction.<br>
        /// A control needs to override this function in order to support two dimensional keyboard navigation.<br>
        /// </summary>
        /// <param name="currentFocusedView">The current focused view</param>
        /// <param name="direction">The direction to move the focus towards</param>
        /// <param name="loopEnabled">Whether the focus movement should be looped within the control</param>
        /// <returns>the next keyboard focusable view in this control or an empty handle if no view can be focused</returns>
        public virtual View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            return new View();
        }

        /// <summary>
        /// Informs this control that its chosen focusable view will be focused.<br>
        /// This allows the application to preform any actions if wishes before the focus is actually moved to the chosen view.<br>
        /// </summary>
        /// <param name="commitedFocusableView">The commited focused view</param>
        public virtual void OnFocusChangeCommitted(View commitedFocusableView)
        {
        }

        /// <summary>
        /// This method is called when the control has enter pressed on it.<br>
        /// Derived classes should override this to perform custom actions.<br>
        /// </summary>
        /// <returns>true if this control supported this action</returns>
        public virtual bool OnKeyboardEnter()
        {
            return false;
        }

        /// <summary>
        /// Called whenever a pinch gesture is detected on this control.<br>
        /// This can be overridden by deriving classes when pinch detection is enabled. The default behaviour is to scale the control by the pinch scale.<br>
        /// If overridden, then the default behaviour will not occur.<br>
        /// Pinch detection should be enabled via EnableGestureDetection().<br>
        /// </summary>
        /// <param name="pinch">pinch tap gesture</param>
        internal virtual void OnPinch(PinchGesture pinch)
        {
        }

        /// <summary>
        /// Called whenever a pan gesture is detected on this control.<br>
        /// This should be overridden by deriving classes when pan detection is enabled.<br>
        /// There is no default behaviour with panning.<br>
        /// Pan detection should be enabled via EnableGestureDetection().<br>
        /// </summary>
        /// <param name="pan">The pan gesture</param>
        public virtual void OnPan(PanGesture pan)
        {
        }

        /// <summary>
        /// Called whenever a tap gesture is detected on this control.<br>
        /// This should be overridden by deriving classes when tap detection is enabled.<br>
        /// There is no default behaviour with a tap.<br>
        /// Tap detection should be enabled via EnableGestureDetection().<br>
        /// </summary>
        /// <param name="tap">The tap gesture</param>
        public virtual void OnTap(TapGesture tap)
        {
        }

        /// <summary>
        /// Called whenever a long press gesture is detected on this control.<br>
        /// This should be overridden by deriving classes when long press detection is enabled.<br>
        /// There is no default behaviour associated with a long press.<br>
        /// Long press detection should be enabled via EnableGestureDetection().<br>
        /// </summary>
        /// <param name="longPress">The long press gesture</param>
        internal virtual void OnLongPress(LongPressGesture longPress)
        {
        }

        private void OnControlChildAdd(View child)
        {
        }

        private void OnControlChildRemove(View child)
        {
        }
    }
}
