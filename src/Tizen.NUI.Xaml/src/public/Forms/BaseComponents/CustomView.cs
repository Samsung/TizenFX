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
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{
    internal class InternalCustomeView : Tizen.NUI.BaseComponents.CustomView
    {
        public InternalCustomeView(string typeName, CustomViewBehaviour behaviour) : base(typeName, behaviour)
        {

        }
        /// <summary>
        /// Requests a relayout, which means performing a size negotiation on this view, its parent, and children (and potentially whole scene).<br />
        /// This method can also be called from a derived class every time it needs a different size.<br />
        /// At the end of event processing, the relayout process starts and all controls which requested relayout will have their sizes (re)negotiated.<br />
        /// It can be called multiple times; the size negotiation is still only performed once, i.e., there is no need to keep track of this in the calling side.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new void RelayoutRequest()
        {
            base.RelayoutRequest();
        }

        /// <summary>
        /// Provides the view implementation of GetHeightForWidth.
        /// </summary>
        /// <param name="width">The width to use.</param>
        /// <returns>The height based on the width.</returns>
        /// <since_tizen> 3 </since_tizen>
        public new float GetHeightForWidthBase(float width)
        {
            return base.GetHeightForWidthBase(width);
        }

        /// <summary>
        /// Provides the view implementation of GetWidthForHeight.
        /// </summary>
        /// <param name="height">The height to use.</param>
        /// <returns>The width based on the height.</returns>
        /// <since_tizen> 3 </since_tizen>
        public new float GetWidthForHeightBase(float height)
        {
            return base.GetWidthForHeightBase(height);
        }

        /// <summary>
        /// Calculates the size for a child using the base view object.
        /// </summary>
        /// <param name="child">The child view to calculate the size for.</param>
        /// <param name="dimension">The dimension to calculate the size, for example, the width or the height.</param>
        /// <returns>Return the calculated size for the given dimension. If more than one dimension is requested, just return the first one found.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float CalculateChildSizeBase(View child, DimensionType dimension)
        {
            return base.CalculateChildSizeBase(child.ViewInstance, dimension);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <param name="dimension">The dimension(s) to check for.</param>
        /// <returns>Return if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        public new bool RelayoutDependentOnChildrenBase(DimensionType dimension)
        {
            return base.RelayoutDependentOnChildrenBase(dimension);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <returns>Return if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        public new bool RelayoutDependentOnChildrenBase()
        {
            return base.RelayoutDependentOnChildrenBase();
        }

        /// <summary>
        /// Registers a visual by property index, linking a view to visual when required.<br />
        /// In the case of the visual being a view or control deeming visual not required, then the visual should be an empty handle.<br />
        /// No parenting is done during registration, this should be done by a derived class.<br />
        /// </summary>
        /// <param name="index">The property index of the visual used to reference visual.</param>
        /// <param name="visual">The visual to register.</param>
        /// <since_tizen> 3 </since_tizen>
        public new void RegisterVisual(int index, VisualBase visual)
        {
            base.RegisterVisual(index, visual);
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
        public new void RegisterVisual(int index, VisualBase visual, bool enabled)
        {
            base.RegisterVisual(index, visual, enabled);
        }

        /// <summary>
        /// Erases the entry matching the given index from the list of registered visuals.
        /// </summary>
        /// <param name="index">The property index of the visual used to reference visual.</param>
        /// <since_tizen> 3 </since_tizen>
        public new void UnregisterVisual(int index)
        {
            base.UnregisterVisual(index);
        }

        /// <summary>
        /// Retrieves the visual associated with the given property index.<br />
        /// For managing the object lifecycle, do not store the returned visual as a member which increments its reference count.<br />
        /// </summary>
        /// <param name="index">The property index of the visual used to reference visual.</param>
        /// <returns>The registered visual if exists, otherwise an empty handle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public new VisualBase GetVisual(int index)
        {
            return base.GetVisual(index);
        }

        /// <summary>
        /// Sets the given visual to be displayed or not when parent staged.<br />
        /// For managing the object lifecycle, do not store the returned visual as a member which increments its reference count.<br />
        /// </summary>
        /// <param name="index">The property index of the visual, used to reference visual.</param>
        /// <param name="enable">Flag set to enabled or disabled.</param>
        /// <since_tizen> 3 </since_tizen>
        public new void EnableVisual(int index, bool enable)
        {
            base.EnableVisual(index, enable);
        }

        /// <summary>
        /// Queries if the given visual is to be displayed when parent staged.<br />
        /// For managing the object lifecycle, do not store the returned visual as a member which increments its reference count.<br />
        /// </summary>
        /// <param name="index">The property index of the visual.</param>
        /// <returns>Whether visual is enabled or not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public new bool IsVisualEnabled(int index)
        {
            return base.IsVisualEnabled(index);
        }

        /// <summary>
        /// Creates a transition effect on the control.
        /// </summary>
        /// <param name="transitionData">The transition data describing the effect to create.</param>
        /// <returns>A handle to an animation defined with the given effect, or an empty handle if no properties match.</returns>
        /// <since_tizen> 3 </since_tizen>
        public new Animation CreateTransition(TransitionData transitionData)
        {
            return base.CreateTransition(transitionData);
        }

        /// <summary>
        /// Emits the KeyInputFocusGained signal if true, else, emits the KeyInputFocusLost signal.<br />
        /// Should be called last by the control after it acts on the input focus change.<br />
        /// </summary>
        /// <param name="focusGained">True if gained, false if lost.</param>
        /// <since_tizen> 3 </since_tizen>
        public new void EmitFocusSignal(bool focusGained)
        {
            base.EmitFocusSignal(focusGained);
        }
    }

    /// <summary>
    /// CustomView provides some common functionality required by all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CustomView : View
    {
        private InternalCustomeView _customView;
        internal InternalCustomeView customView
        {
            get
            {
                if (null == _customView)
                {
                    _customView = handleInstance as InternalCustomeView;
                }

                return _customView;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public CustomView(string typeName, CustomViewBehaviour behaviour) : this(new Tizen.NUI.BaseComponents.CustomView(typeName, behaviour))
        {
        }

        internal CustomView(Tizen.NUI.BaseComponents.CustomView nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FocusNavigationSupportProperty = Binding.BindableProperty.Create("FocusNavigationSupport", typeof(bool), typeof(CustomView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var customView = ((CustomView)bindable).customView;
            customView.FocusNavigationSupport = (bool)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var customView = ((CustomView)bindable).customView;
            return customView.FocusNavigationSupport;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FocusGroupProperty = Binding.BindableProperty.Create("FocusGroup", typeof(bool), typeof(CustomView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var customView = ((CustomView)bindable).customView;
            customView.FocusGroup = (bool)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var customView = ((CustomView)bindable).customView;
            return customView.FocusGroup;
        });

        /// <summary>
        /// Sets the background with a property map.
        /// </summary>
        /// <param name="map">The background property map.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetBackground(PropertyMap map)
        {
            customView.SetBackground(map);
        }

        /// <summary>
        /// Allows deriving classes to enable any of the gesture detectors that are available.<br />
        /// Gesture detection can be enabled one at a time or in a bitwise format.<br />
        /// </summary>
        /// <param name="type">The gesture type(s) to enable.</param>
        /// <since_tizen> 3 </since_tizen>
        public void EnableGestureDetection(Gesture.GestureType type)
        {
            customView.EnableGestureDetection(type);
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
        /// This method is called after the control has been initialized.<br />
        /// Derived classes should do any second phase initialization by overriding this method.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnInitialize()
        {
        }

        /// <summary>
        /// Called after the view has been connected to the stage.<br />
        /// When a view is connected, it will be directly or indirectly parented to the root view.<br />
        /// The root view is provided automatically by Tizen.NUI.Stage, and is always considered to be connected.<br />
        /// When the parent of a set of views is connected to the stage, then all of the children will receive this callback.<br />
        /// </summary>
        /// <param name="depth">The depth in the hierarchy for the view.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnStageConnection(int depth)
        {
        }

        /// <summary>
        /// Called after the view has been disconnected from the stage.<br />
        /// If a view is disconnected, it either has no parent, or is parented to a disconnected view.<br />
        /// When the parent of a set of views is disconnected to the stage, then all of the children will receive this callback, starting with the leaf views.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnStageDisconnection()
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
        public virtual void OnPropertySet(int index, PropertyValue propertyValue)
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
        public virtual Size2D GetNaturalSize()
        {
            return new Size2D(0, 0);
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
            return customView.CalculateChildSize(child.view, dimension);
        }

        /// <summary>
        /// This method is called during size negotiation when a height is required for a given width.<br />
        /// Derived classes should override this if they wish to customize the height returned.<br />
        /// </summary>
        /// <param name="width">Width to use</param>
        /// <returns>The height based on the width</returns>
        /// <since_tizen> 3 </since_tizen>
        public new virtual float GetHeightForWidth(float width)
        {
            return customView.GetHeightForWidth(width);
        }

        /// <summary>
        /// This method is called during size negotiation when a width is required for a given height.<br />
        /// Derived classes should override this if they wish to customize the width returned.<br />
        /// </summary>
        /// <param name="height">Height to use</param>
        /// <returns>The width based on the width</returns>
        /// <since_tizen> 3 </since_tizen>
        public new virtual float GetWidthForHeight(float height)
        {
            return customView.GetWidthForHeight(height);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout.
        /// </summary>
        /// <param name="dimension">The dimension(s) to check for.</param>
        /// <returns>Return if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual bool RelayoutDependentOnChildren(DimensionType dimension)
        {
            return customView.RelayoutDependentOnChildren(dimension);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <returns>Return true if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual bool RelayoutDependentOnChildren()
        {
            return customView.RelayoutDependentOnChildren();
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
        /// <returns>The next keyboard focusable view in this control or an empty handle if no view can be focused.</returns>
        /// <since_tizen> 3 </since_tizen>
        public virtual View GetNextFocusableView(View currentFocusedView, Tizen.NUI.BaseComponents.View.FocusDirection direction, bool loopEnabled)
        {
            return new View();
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

        /// <summary>
        /// Requests a relayout, which means performing a size negotiation on this view, its parent, and children (and potentially whole scene).<br />
        /// This method can also be called from a derived class every time it needs a different size.<br />
        /// At the end of event processing, the relayout process starts and all controls which requested relayout will have their sizes (re)negotiated.<br />
        /// It can be called multiple times; the size negotiation is still only performed once, i.e., there is no need to keep track of this in the calling side.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected void RelayoutRequest()
        {
            customView.RelayoutRequest();
        }

        /// <summary>
        /// Provides the view implementation of GetHeightForWidth.
        /// </summary>
        /// <param name="width">The width to use.</param>
        /// <returns>The height based on the width.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected float GetHeightForWidthBase(float width)
        {
            return customView.GetHeightForWidthBase(width);
        }

        /// <summary>
        /// Provides the view implementation of GetWidthForHeight.
        /// </summary>
        /// <param name="height">The height to use.</param>
        /// <returns>The width based on the height.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected float GetWidthForHeightBase(float height)
        {
            return customView.GetWidthForHeightBase(height);
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
            return customView.CalculateChildSizeBase(child, dimension);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <param name="dimension">The dimension(s) to check for.</param>
        /// <returns>Return if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected bool RelayoutDependentOnChildrenBase(DimensionType dimension)
        {
            return customView.RelayoutDependentOnChildrenBase(dimension);
        }

        /// <summary>
        /// Determines if this view is dependent on it's children for relayout from the base class.
        /// </summary>
        /// <returns>Return if the view is dependent on it's children.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected bool RelayoutDependentOnChildrenBase()
        {
            return customView.RelayoutDependentOnChildrenBase();
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
            customView.RegisterVisual(index, visual);
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
            customView.RegisterVisual(index, visual, enabled);
        }

        /// <summary>
        /// Erases the entry matching the given index from the list of registered visuals.
        /// </summary>
        /// <param name="index">The property index of the visual used to reference visual.</param>
        /// <since_tizen> 3 </since_tizen>
        protected void UnregisterVisual(int index)
        {
            customView.UnregisterVisual(index);
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
            return customView.GetVisual(index);
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
            customView.EnableVisual(index, enable);
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
            return customView.IsVisualEnabled(index);
        }

        /// <summary>
        /// Creates a transition effect on the control.
        /// </summary>
        /// <param name="transitionData">The transition data describing the effect to create.</param>
        /// <returns>A handle to an animation defined with the given effect, or an empty handle if no properties match.</returns>
        /// <since_tizen> 3 </since_tizen>
        protected Animation CreateTransition(TransitionData transitionData)
        {
            return customView.CreateTransition(transitionData);
        }

        /// <summary>
        /// Emits the KeyInputFocusGained signal if true, else, emits the KeyInputFocusLost signal.<br />
        /// Should be called last by the control after it acts on the input focus change.<br />
        /// </summary>
        /// <param name="focusGained">True if gained, false if lost.</param>
        /// <since_tizen> 3 </since_tizen>
        protected void EmitFocusSignal(bool focusGained)
        {
            customView.EmitFocusSignal(focusGained);
        }
    }
}