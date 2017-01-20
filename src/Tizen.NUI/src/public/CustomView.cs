/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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

namespace NUI
{
    public class CustomView : ViewWrapper
    {
        public CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour) : base(new ViewWrapperImpl(behaviour))
        {
            // Registering CustomView virtual functions to viewWrapperImpl delegates.
            viewWrapperImpl.OnStageConnection = new ViewWrapperImpl.OnStageConnectionDelegate(OnStageConnection);
            viewWrapperImpl.OnStageDisconnection = new ViewWrapperImpl.OnStageDisconnectionDelegate(OnStageDisconnection);
            viewWrapperImpl.OnChildAdd = new ViewWrapperImpl.OnChildAddDelegate(OnChildAdd);
            viewWrapperImpl.OnChildRemove = new ViewWrapperImpl.OnChildRemoveDelegate(OnChildRemove);
            viewWrapperImpl.OnPropertySet = new ViewWrapperImpl.OnPropertySetDelegate(OnPropertySet);
            viewWrapperImpl.OnSizeSet = new ViewWrapperImpl.OnSizeSetDelegate(OnSizeSet);
            viewWrapperImpl.OnSizeAnimation = new ViewWrapperImpl.OnSizeAnimationDelegate(OnSizeAnimation);
            viewWrapperImpl.OnTouchEvent = new ViewWrapperImpl.OnTouchEventDelegate(OnTouchEvent);
            viewWrapperImpl.OnHoverEvent = new ViewWrapperImpl.OnHoverEventDelegate(OnHoverEvent);
            viewWrapperImpl.OnKeyEvent = new ViewWrapperImpl.OnKeyEventDelegate(OnKeyEvent);
            viewWrapperImpl.OnWheelEvent = new ViewWrapperImpl.OnWheelEventDelegate(OnWheelEvent);
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
            viewWrapperImpl.OnKeyInputFocusGained = new ViewWrapperImpl.OnKeyInputFocusGainedDelegate(OnKeyInputFocusGained);
            viewWrapperImpl.OnKeyInputFocusLost = new ViewWrapperImpl.OnKeyInputFocusLostDelegate(OnKeyInputFocusLost);
            viewWrapperImpl.GetNextKeyboardFocusableActor = new ViewWrapperImpl.GetNextKeyboardFocusableActorDelegate(GetNextKeyboardFocusableActor);
            viewWrapperImpl.OnKeyboardFocusChangeCommitted = new ViewWrapperImpl.OnKeyboardFocusChangeCommittedDelegate(OnKeyboardFocusChangeCommitted);
            viewWrapperImpl.OnKeyboardEnter = new ViewWrapperImpl.OnKeyboardEnterDelegate(OnKeyboardEnter);
            viewWrapperImpl.OnPinch = new ViewWrapperImpl.OnPinchDelegate(OnPinch);
            viewWrapperImpl.OnPan = new ViewWrapperImpl.OnPanDelegate(OnPan);
            viewWrapperImpl.OnTap = new ViewWrapperImpl.OnTapDelegate(OnTap);
            viewWrapperImpl.OnLongPress = new ViewWrapperImpl.OnLongPressDelegate(OnLongPress);
            viewWrapperImpl.SignalConnected = new ViewWrapperImpl.SignalConnectedDelegate(SignalConnected);
            viewWrapperImpl.SignalDisconnected = new ViewWrapperImpl.SignalDisconnectedDelegate(SignalDisconnected);

            // Make sure CustomView is initialized.
            OnInitialize();

            // Make sure the style of actors/visuals initialized above are applied by the style manager.
            viewWrapperImpl.ApplyThemeStyle();
        }

        /**
         * @brief Set the background with a property map.
         *
         * @param[in] map The background property map.
         */
        public void SetBackground(NUI.Property.Map map)
        {
            viewWrapperImpl.SetBackground(map);
        }

        /**
         * @brief Allows deriving classes to enable any of the gesture detectors that are available.
         *
         * Gesture detection can be enabled one at a time or in bitwise format as shown:
         * @code
         * EnableGestureDetection(Gesture.Type.Pinch | Gesture.Type.Tap | Gesture.Type.Pan));
         * @endcode
         * @param[in]  type  The gesture type(s) to enable.
         */
        public void EnableGestureDetection(Gesture.Type type)
        {
            viewWrapperImpl.EnableGestureDetection(type);
        }

        /**
         * @brief Allows deriving classes to disable any of the gesture detectors.
         *
         * Like EnableGestureDetection, this can also be called using bitwise or.
         * @param[in]  type  The gesture type(s) to disable.
         * @see EnableGetureDetection
         */
        public void DisableGestureDetection(Gesture.Type type)
        {
            viewWrapperImpl.DisableGestureDetection(type);
        }

        /**
         * @brief Sets whether this control supports two dimensional
         * keyboard navigation (i.e. whether it knows how to handle the
         * keyboard focus movement between its child actors).
         *
         * The control doesn't support it by default.
         * @param[in] isSupported Whether this control supports two dimensional keyboard navigation.
         */
        public void SetKeyboardNavigationSupport(bool isSupported)
        {
            viewWrapperImpl.SetKeyboardNavigationSupport(isSupported);
        }

        /**
         * @brief Gets whether this control supports two dimensional keyboard navigation.
         *
         * @return true if this control supports two dimensional keyboard navigation.
         */
        public bool IsKeyboardNavigationSupported()
        {
            return viewWrapperImpl.IsKeyboardNavigationSupported();
        }

        /**
         * @brief Sets whether this control is a focus group for keyboard navigation.
         *
         * (i.e. the scope of keyboard focus movement
         * can be limitied to its child actors). The control is not a focus group by default.
         * @param[in] isFocusGroup Whether this control is set as a focus group for keyboard navigation.
         */
        public void SetAsKeyboardFocusGroup(bool isFocusGroup)
        {
            viewWrapperImpl.SetAsKeyboardFocusGroup(isFocusGroup);
        }

        /**
         * @brief Gets whether this control is a focus group for keyboard navigation.
         *
         * @return true if this control is set as a focus group for keyboard navigation.
         */
        public bool IsKeyboardFocusGroup()
        {
            return viewWrapperImpl.IsKeyboardFocusGroup();
        }

        /**
         * @brief Called by the AccessibilityManager to activate the Control.
         * @SINCE_1_0.0
         */
        public void AccessibilityActivate()
        {
            viewWrapperImpl.AccessibilityActivate();
        }

        /**
         * @brief Called by the KeyboardFocusManager.
         */
        public void KeyboardEnter()
        {
            viewWrapperImpl.KeyboardEnter();
        }

        /**
         * @brief Called by the KeyInputFocusManager to emit key event signals.
         *
         * @param[in] keyEvent The key event.
         * @return True if the event was consumed.
         */
        public bool EmitKeyEventSignal(KeyEvent keyEvent)
        {
            return viewWrapperImpl.EmitKeyEventSignal(keyEvent);
        }

        /**
         * @brief Request a relayout, which means performing a size negotiation on this actor, its parent and children (and potentially whole scene).
         *
         * This method can also be called from a derived class every time it needs a different size.
         * At the end of event processing, the relayout process starts and
         * all controls which requested Relayout will have their sizes (re)negotiated.
         *
         * @note RelayoutRequest() can be called multiple times; the size negotiation is still
         * only performed once, i.e. there is no need to keep track of this in the calling side.
         */
        protected void RelayoutRequest()
        {
            viewWrapperImpl.RelayoutRequest();
        }

        /**
         * @brief Provides the Actor implementation of GetHeightForWidth.
         * @param width Width to use.
         * @return The height based on the width.
         */
        protected float GetHeightForWidthBase(float width)
        {
            return viewWrapperImpl.GetHeightForWidthBase( width );
        }

        /**
         * @brief Provides the Actor implementation of GetWidthForHeight.
         * @param height Height to use.
         * @return The width based on the height.
         */
        protected float GetWidthForHeightBase(float height)
        {
            return viewWrapperImpl.GetWidthForHeightBase( height );
        }

        /**
         * @brief Calculate the size for a child using the base actor object.
         *
         * @param[in] child The child actor to calculate the size for
         * @param[in] dimension The dimension to calculate the size for. E.g. width or height
         * @return Return the calculated size for the given dimension. If more than one dimension is requested, just return the first one found.
         */
        protected float CalculateChildSizeBase(Actor child, DimensionType dimension)
        {
            return viewWrapperImpl.CalculateChildSizeBase( child, dimension );
        }

        /**
         * @brief Determine if this actor is dependent on it's children for relayout from the base class.
         *
         * @param dimension The dimension(s) to check for
         * @return Return if the actor is dependent on it's children.
         */
        protected bool RelayoutDependentOnChildrenBase(DimensionType dimension)
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase( dimension );
        }

        /**
         * @brief Determine if this actor is dependent on it's children for relayout from the base class.
         *
         * @param dimension The dimension(s) to check for
         * @return Return if the actor is dependent on it's children.
         */
        protected bool RelayoutDependentOnChildrenBase()
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase();
        }

        /**
         * @brief Register a visual by Property Index, linking an Actor to visual when required.
         * In the case of the visual being an actor or control deeming visual not required then visual should be an empty handle.
         * No parenting is done during registration, this should be done by derived class.
         *
         * @param[in] index The Property index of the visual, used to reference visual
         * @param[in] visual The visual to register
         * @note Derived class should not call visual.SetOnStage(actor). It is the responsibility of the base class to connect/disconnect registered visual to stage.
         *       Use below API with enabled set to false if derived class wishes to control when visual is staged.
         */
        protected void RegisterVisual(int index, VisualBase visual)
        {
            viewWrapperImpl.RegisterVisual( index, visual );
        }

        /**
         * @brief Register a visual by Property Index, linking an Actor to visual when required.
         * In the case of the visual being an actor or control deeming visual not required then visual should be an empty handle.
         * If enabled is false then the visual is not set on stage until enabled by the derived class.
         * @see EnableVisual
         *
         * @param[in] index The Property index of the visual, used to reference visual
         * @param[in] visual The visual to register
         * @param[in] enabled false if derived class wants to control when visual is set on stage.
         *
         */
        protected void RegisterVisual(int index, VisualBase visual, bool enabled)
        {
            viewWrapperImpl.RegisterVisual( index, visual, enabled );
        }

        /**
         * @brief Erase the entry matching the given index from the list of registered visuals
         * @param[in] index The Property index of the visual, used to reference visual
         *
         */
        protected void UnregisterVisual(int index)
        {
            viewWrapperImpl.UnregisterVisual( index );
        }

        /**
         * @brief Retrieve the visual associated with the given property index.
         *
         * @param[in] index The Property index of the visual.
         * @return The registered visual if exist, otherwise empty handle.
         * @note For managing object life-cycle, do not store the returned visual as a member which increments its reference count.
         */
        protected VisualBase GetVisual(int index)
        {
            return viewWrapperImpl.GetVisual( index );
        }

        /**
         * @brief Sets the given visual to be displayed or not when parent staged.
         *
         * @param[in] index The Property index of the visual
         * @param[in] enable flag to set enabled or disabled.
         */
        protected void EnableVisual(int index, bool enable)
        {
            viewWrapperImpl.EnableVisual( index, enable );
        }

        /**
         * @brief Queries if the given visual is to be displayed when parent staged.
         *
         * @param[in] index The Property index of the visual
         * @return bool whether visual is enabled or not
         */
        protected bool IsVisualEnabled(int index)
        {
            return viewWrapperImpl.IsVisualEnabled( index );
        }

        /**
         * @brief Create a transition effect on the control.
         *
         * @param[in] transitionData The transition data describing the effect to create
         * @return A handle to an animation defined with the given effect, or an empty
         * handle if no properties match.
         */
        protected Animation CreateTransition(TransitionData transitionData)
        {
            return viewWrapperImpl.CreateTransition( transitionData );
        }

        /**
         * @brief Emits KeyInputFocusGained signal if true else emits KeyInputFocusLost signal
         *
         * Should be called last by the control after it acts on the Input Focus change.
         *
         * @param[in] focusGained True if gained, False if lost
         */
        protected void EmitKeyInputFocusSignal(bool focusGained)
        {
            viewWrapperImpl.EmitKeyInputFocusSignal( focusGained );
        }

        /**
         * @brief This method is called after the Control has been initialized.
         *
         * Derived classes should do any second phase initialization by overriding this method.
         */
        public virtual void OnInitialize()
        {
        }

        /**
         * @brief Called after the actor has been connected to the stage.
         *
         * When an actor is connected, it will be directly or indirectly parented to the root Actor.
         * @param[in] depth The depth in the hierarchy for the actor
         *
         * @note The root Actor is provided automatically by Dali::Stage, and is always considered to be connected.
         * When the parent of a set of actors is connected to the stage, then all of the children
         * will received this callback.
         * For the following actor tree, the callback order will be A, B, D, E, C, and finally F.
         *
         * @code
         *
         *       A (parent)
         *      / \
         *     B   C
         *    / \   \
         *   D   E   F
         *
         * @endcode
         * @param[in] depth The depth in the hierarchy for the actor
         */
        public virtual void OnStageConnection(int depth)
        {
        }

        /**
         * @brief Called after the actor has been disconnected from Stage.
         *
         * If an actor is disconnected it either has no parent, or is parented to a disconnected actor.
         *
         * @note When the parent of a set of actors is disconnected to the stage, then all of the children
         * will received this callback, starting with the leaf actors.
         * For the following actor tree, the callback order will be D, E, B, F, C, and finally A.
         *
         * @code
         *
         *       A (parent)
         *      / \
         *     B   C
         *    / \   \
         *   D   E   F
         *
         * @endcode
         */
        public virtual void OnStageDisconnection()
        {
        }

        /**
         * @brief Called after a child has been added to the owning actor.
         *
         * @param[in] child The child which has been added
         */
        public virtual void OnChildAdd(Actor actor)
        {
        }

        /**
         * @brief Called after the owning actor has attempted to remove a child( regardless of whether it succeeded or not ).
         *
         * @param[in] child The child being removed
         */
        public virtual void OnChildRemove(Actor actor)
        {
        }

        /**
         * @brief Called when the owning actor property is set.
         *
         * @param[in] index The Property index that was set
         * @param[in] propertyValue The value to set
         */
        public virtual void OnPropertySet(int index, NUI.Property.Value propertyValue)
        {
        }

        /**
         * @brief Called when the owning actor's size is set e.g. using Actor::SetSize().
         *
         * @param[in] targetSize The target size. Note that this target size may not match the size returned via Actor.GetTargetSize.
         */
        public virtual void OnSizeSet(Vector3 targetSize)
        {
        }

        /**
         * @brief Called when the owning actor's size is animated e.g. using Animation::AnimateTo( Property( actor, Actor::Property::SIZE ), ... ).
         *
         * @param[in] animation The object which is animating the owning actor.
         * @param[in] targetSize The target size. Note that this target size may not match the size returned via @ref Actor.GetTargetSize.
         */
        public virtual void OnSizeAnimation(Animation animation, Vector3 targetSize)
        {
        }

        /**
         * @DEPRECATED_1_1.37 Connect to TouchSignal() instead.
         *
         * @brief Called after a touch-event is received by the owning actor.
         *
         * @param[in] event The touch event
         * @return True if the event should be consumed.
         * @note CustomViewBehaviour.REQUIRES_TOUCH_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).
         */
        public virtual bool OnTouchEvent(TouchEvent touchEvent)
        {
            return false; // Do not consume
        }

        /**
         * @brief Called after a hover-event is received by the owning actor.
         *
         * @param[in] event The hover event
         * @return True if the event should be consumed.
         * @note CustomViewBehaviour.REQUIRES_HOVER_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).
         */
        public virtual bool OnHoverEvent(HoverEvent hoverEvent)
        {
            return false; // Do not consume
        }

        /**
         * @brief Called after a key-event is received by the actor that has had its focus set.
         *
         * @param[in] event the Key Event
         * @return True if the event should be consumed.
         */
        public virtual bool OnKeyEvent(KeyEvent keyEvent)
        {
            return false; // Do not consume
        }

        /**
         * @brief Called after a wheel-event is received by the owning actor.
         *
         * @param[in] event The wheel event
         * @return True if the event should be consumed.
         * @note CustomViewBehaviour.REQUIRES_WHEEL_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).
         */
        public virtual bool OnWheelEvent(WheelEvent wheelEvent)
        {
            return false; // Do not consume
        }

        /**
         * @brief Called after the size negotiation has been finished for this control.
         *
         * The control is expected to assign this given size to itself/its children.
         *
         * Should be overridden by derived classes if they need to layout
         * actors differently after certain operations like add or remove
         * actors, resize or after changing specific properties.
         *
         * @param[in]      size       The allocated size.
         * @param[in,out]  container  The control should add actors to this container that it is not able
         *                            to allocate a size for.
         * @note  As this function is called from inside the size negotiation algorithm, you cannot
         * call RequestRelayout (the call would just be ignored).
         */
        public virtual void OnRelayout(Vector2 size, RelayoutContainer container)
        {
        }

        /**
         * @brief Notification for deriving classes
         *
         * @param[in] policy The policy being set
         * @param[in] dimension The dimension the policy is being set for
         */
        public virtual void OnSetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
        }

        /**
         * @brief Return the natural size of the actor.
         *
         * @return The actor's natural size
         */
        public virtual Vector3 GetNaturalSize()
        {
            return new Vector3(0.0f, 0.0f, 0.0f);
        }

        /**
         * @brief Calculate the size for a child.
         *
         * @param[in] child The child actor to calculate the size for
         * @param[in] dimension The dimension to calculate the size for. E.g. width or height.
         * @return Return the calculated size for the given dimension.
         */
        public virtual float CalculateChildSize(Actor child, DimensionType dimension)
        {
            return viewWrapperImpl.CalculateChildSizeBase( child, dimension );
        }

        /**
         * @brief This method is called during size negotiation when a height is required for a given width.
         *
         * Derived classes should override this if they wish to customize the height returned.
         *
         * @param width Width to use.
         * @return The height based on the width.
         */
        public virtual float GetHeightForWidth(float width)
        {
            return viewWrapperImpl.GetHeightForWidthBase( width );
        }

        /**
         * @brief This method is called during size negotiation when a width is required for a given height.
         *
         * Derived classes should override this if they wish to customize the width returned.
         *
         * @param height Height to use.
         * @return The width based on the width.
         */
        public virtual float GetWidthForHeight(float height)
        {
            return viewWrapperImpl.GetWidthForHeightBase( height );
        }

        /**
         * @brief Determine if this actor is dependent on it's children for relayout.
         *
         * @param dimension The dimension(s) to check for
         * @return Return if the actor is dependent on it's children.
         */
        public virtual bool RelayoutDependentOnChildren(DimensionType dimension)
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase( dimension );
        }

        /**
         * @brief Determine if this actor is dependent on it's children for relayout from the base class.
         *
         * @return Return if the actor is dependent on it's children.
         */
        public virtual bool RelayoutDependentOnChildren()
        {
            return viewWrapperImpl.RelayoutDependentOnChildrenBase();
        }

        /**
         * @brief Virtual method to notify deriving classes that relayout dependencies have been
         * met and the size for this object is about to be calculated for the given dimension
         *
         * @param dimension The dimension that is about to be calculated
         */
        public virtual void OnCalculateRelayoutSize(DimensionType dimension)
        {
        }

        /**
         * @brief Virtual method to notify deriving classes that the size for a dimension
         * has just been negotiated
         *
         * @param[in] size The new size for the given dimension
         * @param[in] dimension The dimension that was just negotiated
         */
        public virtual void OnLayoutNegotiated(float size, DimensionType dimension)
        {
        }

        /**
         * @brief This method should be overridden by deriving classes requiring notifications when the style changes.
         *
         * @param[in] styleManager  The StyleManager object.
         * @param[in] change  Information denoting what has changed.
         */
        public virtual void OnStyleChange(StyleManager styleManager, StyleChangeType change)
        {
        }

        /**
         * @brief This method is called when the control is accessibility activated.
         *
         * Derived classes should override this to perform custom accessibility activation.
         * @return true if this control can perform accessibility activation.
         */
        public virtual bool OnAccessibilityActivated()
        {
            return false;
        }

        /**
         * @brief This method should be overridden by deriving classes when they wish to respond the accessibility
         * pan gesture.
         *
         * @param[in] gesture The pan gesture.
         * @return true if the pan gesture has been consumed by this control
         */
        public virtual bool OnAccessibilityPan(PanGesture gestures)
        {
            return false;
        }

        /**
         * @brief This method should be overridden by deriving classes when they wish to respond the accessibility
         * touch event.
         *
         * @param[in] touchEvent The touch event.
         * @return true if the touch event has been consumed by this control
         */
        public virtual bool OnAccessibilityTouch(TouchEvent touchEvent)
        {
            return false;
        }

        /**
         * @brief This method should be overridden by deriving classes when they wish to respond
         * the accessibility up and down action (i.e. value change of slider control).
         *
         * @param[in] isIncrease Whether the value should be increased or decreased
         * @return true if the value changed action has been consumed by this control
         */
        public virtual bool OnAccessibilityValueChange(bool isIncrease)
        {
            return false;
        }

        /**
         * @brief This method should be overridden by deriving classes when they wish to respond
         * the accessibility zoom action.
         *
         * @return true if the zoom action has been consumed by this control
         */
        public virtual bool OnAccessibilityZoom()
        {
            return false;
        }

        /**
         * @brief This method should be overridden by deriving classes when they wish to respond
         * the accessibility zoom action.
         *
         * @return true if the zoom action has been consumed by this control
         */
        public virtual void OnKeyInputFocusGained()
        {
        }

        /**
         * @brief Called when the control loses key input focus.
         *
         * Should be overridden by derived classes if they need to customize what happens when focus is lost.
         */
        public virtual void OnKeyInputFocusLost()
        {
        }

        /**
         * @brief Gets the next keyboard focusable actor in this control towards the given direction.
         *
         * A control needs to override this function in order to support two dimensional keyboard navigation.
         * @param[in] currentFocusedActor The current focused actor.
         * @param[in] direction The direction to move the focus towards.
         * @param[in] loopEnabled Whether the focus movement should be looped within the control.
         * @return the next keyboard focusable actor in this control or an empty handle if no actor can be focused.
         */
        public virtual Actor GetNextKeyboardFocusableActor(Actor currentFocusedActor, View.KeyboardFocus.Direction direction, bool loopEnabled)
        {
            return new Actor();
        }

        /**
         * @brief Informs this control that its chosen focusable actor will be focused.
         *
         * This allows the application to preform any actions if wishes
         * before the focus is actually moved to the chosen actor.
         *
         * @param[in] commitedFocusableActor The commited focusable actor.
         */
        public virtual void OnKeyboardFocusChangeCommitted(Actor commitedFocusableActor)
        {
        }

        /**
         * @brief This method is called when the control has enter pressed on it.
         *
         * Derived classes should override this to perform custom actions.
         * @return true if this control supported this action.
         */
        public virtual bool OnKeyboardEnter()
        {
            return false;
        }

        /**
         * @brief Called whenever a pinch gesture is detected on this control.
         *
         * This can be overridden by deriving classes when pinch detection
         * is enabled.  The default behaviour is to scale the control by the
         * pinch scale.
         *
         * @param[in]  pinch  The pinch gesture.
         * @note If overridden, then the default behaviour will not occur.
         * @note Pinch detection should be enabled via EnableGestureDetection().
         * @see EnableGestureDetection
         */
        public virtual void OnPinch(PinchGesture pinch)
        {
        }

        /**
         * @brief Called whenever a pan gesture is detected on this control.
         *
         * This should be overridden by deriving classes when pan detection
         * is enabled.
         *
         * @param[in]  pan  The pan gesture.
         * @note There is no default behaviour with panning.
         * @note Pan detection should be enabled via EnableGestureDetection().
         * @see EnableGestureDetection
         */
        public virtual void OnPan(PanGesture pan)
        {
        }

        /**
         * @brief Called whenever a tap gesture is detected on this control.
         *
         * This should be overridden by deriving classes when tap detection
         * is enabled.
         *
         * @param[in]  tap  The tap gesture.
         * @note There is no default behaviour with a tap.
         * @note Tap detection should be enabled via EnableGestureDetection().
         * @see EnableGestureDetection
         */
        public virtual void OnTap(TapGesture tap)
        {
        }

        /**
         * @brief Called whenever a long press gesture is detected on this control.
         *
         * This should be overridden by deriving classes when long press
         * detection is enabled.
         *
         * @param[in]  longPress  The long press gesture.
         * @note There is no default behaviour associated with a long press.
         * @note Long press detection should be enabled via EnableGestureDetection().
         * @see EnableGestureDetection
         */
        public virtual void OnLongPress(LongPressGesture longPress)
        {
        }

        private void SignalConnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
        }

        private void SignalDisconnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
        }

        private void OnControlChildAdd(Actor child)
        {
        }

        private void OnControlChildRemove(Actor child)
        {
        }
    }
}
