// Copyright (c) 2019 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI
{
    /// <summary>
    /// This specifies all the scroll mode type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ScrollModeType
    {
        /// <summary>
        /// Whether the content can be scrolled along the X axis or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        XAxisScrollEnabled,
        /// <summary>
        /// When set, causes scroll view to snap to multiples of the
        /// value of the interval while flicking along the X axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        XAxisSnapToInterval,
        /// <summary>
        /// When set, the scroll view is unable to scroll beyond the
        /// value of the boundary along the X axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        XAxisScrollBoundary,
        /// <summary>
        /// Whether the content can be scrolled along the Y axis or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        YAxisScrollEnabled,
        /// <summary>
        /// When set, causes scroll view to snap to multiples of the
        /// value of the interval while flicking along the Y axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        YAxisSnapToInterval,
        /// <summary>
        /// When set, the scroll view is unable to scroll beyond the
        /// value of the boundary along the Y axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        YAxisScrollBoundary
    }

    /// <summary>
    /// This specifies whether the actor uses its own color or inherits.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ColorMode
    {
        /// <summary>
        /// Actor will use its own color.
        /// </summary>
        UseOwnColor,
        /// <summary>
        /// Actor will use its parent color.
        /// </summary>
        UseParentColor,
        /// <summary>
        /// Actor will blend its color with its parents color.
        /// </summary>
        UseOwnMultiplyParentColor,
        /// <summary>
        /// Actor will blend its alpha with its parents alpha. This means when the parent fades in or out, the child does as well. This is the default.
        /// </summary>
        UseOwnMultiplyParentAlpha
    }

    /// <summary>
    /// This specifies the dimension of the width or the height for size negotiation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DimensionType
    {
        /// <summary>
        /// Width dimension.
        /// </summary>
        Width = 0x1,
        /// <summary>
        /// Height dimension.
        /// </summary>
        Height = 0x2,
        /// <summary>
        /// Mask to cover all flags.
        /// </summary>
        AllDimensions = 0x3
    }

    /// <summary>
    /// Enumeration for the instance of how the actor and it's children will be drawn.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DrawModeType
    {
        /// <summary>
        /// The default draw-mode.
        /// </summary>
        [Description("NORMAL")]
        Normal = 0,
        /// <summary>
        /// Draw the actor and its children as an overlay.
        /// </summary>
        [Description("OVERLAY_2D")]
        Overlay2D = 1,

        /// <summary>
        /// Will be replaced by separate ClippingMode enum. Draw the actor and its children into the stencil buffer.
        /// </summary>
        /// <remarks>
        /// Deprecated.(API Level 6) Not used.
        /// </remarks>
        [Obsolete("Please do not use this DrawModeType.Stencil(Deprecated). This is replaced by ClippingModeType")]
        [Description("STENCIL")]
        Stencil = 3
    }

    /// <summary>
    /// Enumeration for size negotiation resize policies.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ResizePolicyType
    {
        /// <summary>
        /// Size is fixed as set by SetSize.
        /// </summary>
        [Description("FIXED")]
        Fixed,
        /// <summary>
        /// Size is to use the actor's natural size.
        /// </summary>
        /// <see cref="ViewImpl.GetNaturalSize"/>
        [Description("USE_NATURAL_SIZE")]
        UseNaturalSize,
        /// <summary>
        /// Size is to fill up to the actor's parent's bounds. Aspect ratio is not maintained.
        /// </summary>
        [Description("FILL_TO_PARENT")]
        FillToParent,
        /// <summary>
        /// The actors size will be ( ParentSize * SizeRelativeToParentFactor ).
        /// </summary>
        [Description("SIZE_RELATIVE_TO_PARENT")]
        SizeRelativeToParent,
        /// <summary>
        /// The actors size will be ( ParentSize + SizeRelativeToParentFactor ).
        /// </summary>
        [Description("SIZE_FIXED_OFFSET_FROM_PARENT")]
        SizeFixedOffsetFromParent,
        /// <summary>
        /// The size will adjust to wrap around all children.
        /// </summary>
        [Description("FIT_TO_CHILDREN")]
        FitToChildren,
        /// <summary>
        /// One dimension is dependent on the other.
        /// </summary>
        [Description("DIMENSION_DEPENDENCY")]
        DimensionDependency,
        /// <summary>
        /// The size will be assigned to the actor.
        /// </summary>
        [Description("USE_ASSIGNED_SIZE")]
        UseAssignedSize
    }

    /// <summary>
    /// Enumeration for policies to determine how an actor should resize itself when having its size set in size negotiation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SizeScalePolicyType
    {
        /// <summary>
        /// Use the size that was set.
        /// </summary>
        [Description("USE_SIZE_SET")]
        UseSizeSet,
        /// <summary>
        /// Fit within the size set maintaining natural size aspect ratio.
        /// </summary>
        [Description("FIT_WITH_ASPECT_RATIO")]
        FitWithAspectRatio,
        /// <summary>
        /// Fit within the size set maintaining natural size aspect ratio.
        /// </summary>
        [Description("FILL_WITH_ASPECT_RATIO")]
        FillWithAspectRatio
    }

    /// <summary>
    /// Enumeration for the ClippingMode describing how this actor's children will be clipped against it.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ClippingModeType
    {
        /// <summary>
        /// This actor will not clip its children.
        /// </summary>
        Disabled,
        /// <summary>
        /// This actor will clip all children to within its boundaries (the actor will also be visible itself).
        /// </summary>
        ClipChildren,
        /// <summary>
        /// This Actor will clip all children within a screen-aligned rectangle encompassing its boundaries (the actor will also be visible itself).
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ClipToBoundingBox
    }

    /// <summary>
    /// Enumeration for type determination of how the camera operates.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraType
    {
        /// <summary>
        /// Camera orientation is taken from the CameraActor.
        /// </summary>
        FreeLook,
        /// <summary>
        /// Camera is oriented to always look at a target.
        /// </summary>
        LookAtTarget
    }

    /// <summary>
    /// Enumeration for the projection modes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProjectionMode
    {
        /// <summary>
        /// Distance causes foreshortening; objects further from the camera appear smaller.
        /// </summary>
        PerspectiveProjection,
        /// <summary>
        /// Relative distance from the camera does not affect the size of objects.
        /// </summary>
        OrthographicProjection
    }

    /// <summary>
    /// This specifies customView behavior types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CustomViewBehaviour
    {
        /// <summary>
        /// Use to provide default behavior (size negotiation is on, event callbacks are not called).
        /// </summary>
        ViewBehaviourDefault = 0,
        /// <summary>
        /// True if the control does not need size negotiation, i.e., it can be skipped in the algorithm.
        /// </summary>
        DisableSizeNegotiation = 1 << 0,
        /// <summary>
        /// True if OnTouch() callback is required.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        RequiresTouchEventsSupport = 1 << 1,
        /// <summary>
        /// True if OnHover() callback is required.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        RequiresHoverEventsSupport = 1 << 2,
        /// <summary>
        /// True if OnWheel() callback is required.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        RequiresWheelEventsSupport = 1 << 3,
        /// <summary>
        /// Use to provide key navigation support.
        /// </summary>
        RequiresKeyboardNavigationSupport = 1 << 5,
        /// <summary>
        /// Use to make style change event disabled.
        /// </summary>
        DisableStyleChangeSignals = 1 << 6,
        /// <summary>
        /// Please do not use! This will be deprecated!
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        LastViewBehaviourFlag
    }

    /// <summary>
    /// An enum of Device Class types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// Can't fix because it's already used by other GBM.
    [SuppressMessage("Microsoft.Naming", "CA1720: Identifiers should not contain type names")]
    public enum DeviceClassType
    {
        /// <summary>
        /// Not a device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None,
        /// <summary>
        /// The user/seat (the user themselves).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Seat,
        /// <summary>
        /// A regular keyboard, numberpad or attached buttons.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Keyboard,
        /// <summary>
        /// A mouse, trackball or touchpad relative motion device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Mouse,
        /// <summary>
        /// A touchscreen with fingers or stylus.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Touch,
        /// <summary>
        /// A special pen device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Pen,
        /// <summary>
        ///  A pointing device based on laser, infrared or similar technology.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Pointer,
        /// <summary>
        /// A gamepad controller or joystick.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Gamepad
    }

    /// <summary>
    /// An enum of Device Subclass types.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum DeviceSubClassType
    {
        /// <summary>
        /// Not a device
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        None,
        /// <summary>
        /// The normal flat of your finger
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Finger,
        /// <summary>
        /// A fingernail
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Fingernail,
        /// <summary>
        /// A Knuckle
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Knuckle,
        /// <summary>
        /// The palm of a users hand
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Palm,
        /// <summary>
        /// The side of your hand
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        HandSide,
        /// <summary>
        /// The flat of your hand
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        HandFlat,
        /// <summary>
        /// The tip of a pen
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        PenTip,
        /// <summary>
        /// A trackpad style mouse
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Trackpad,
        /// <summary>
        /// A trackpoint style mouse
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Trackpoint,
        /// <summary>
        /// A trackball style mouse
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Trackball,
        /// <summary>
        /// A remote controller
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Remocon,
        /// <summary>
        /// A virtual keyboard
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        VirtualKeyboard
    }

    /// <summary>
    /// This specifies all the property types.<br />
    /// Enumeration for the property types supported.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// Can't fix because it's already used by other GBM.
    [SuppressMessage("Microsoft.Naming", "CA1720: Identifiers should not contain type names")]
    public enum PropertyType
    {
        /// <summary>
        /// No type.
        /// </summary>
        None,
        /// <summary>
        /// A boolean type.
        /// </summary>
        Boolean,
        /// <summary>
        /// A float type.
        /// </summary>
        Float,
        /// <summary>
        /// An integer type.
        /// </summary>
        Integer,
        /// <summary>
        /// A vector array of size=2 with float precision.
        /// </summary>
        Vector2,
        /// <summary>
        /// A vector array of size=3 with float precision.
        /// </summary>
        Vector3,
        /// <summary>
        /// A vector array of size=4 with float precision.
        /// </summary>
        Vector4,
        /// <summary>
        /// A 3x3 matrix.
        /// </summary>
        Matrix3,
        /// <summary>
        /// A 4x4 matrix.
        /// </summary>
        Matrix,
        /// <summary>
        /// An integer array of size=4.
        /// </summary>
        Rectangle,
        /// <summary>
        /// Either a quaternion or an axis angle rotation.
        /// </summary>
        Rotation,
        /// <summary>
        /// A string type.
        /// </summary>
        String,
        /// <summary>
        /// An array of PropertyValue.
        /// </summary>
        Array,
        /// <summary>
        /// A string key to PropertyValue mapping.
        /// </summary>
        Map,
        /// <summary>
        /// An extents type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Extents
    }

    /// <summary>
    /// This specifies the property access mode types.<br />
    /// Enumeration for the access mode for custom properties.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PropertyAccessMode
    {
        /// <summary>
        /// If the property is read-only.
        /// </summary>
        ReadOnly,
        /// <summary>
        /// If the property is read or writeable.
        /// </summary>
        ReadWrite,
        /// <summary>
        /// If the property can be animated or constrained.
        /// </summary>
        Animatable,
        /// <summary>
        /// The number of access modes.
        /// </summary>
        AccessModeCount
    }

    /// <summary>
    /// Types of style change. Enumeration for the StyleChange type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated in API9, Will be removed in API11.")]
    public enum StyleChangeType
    {
        /// <summary>
        /// Denotes that the default font has changed.
        /// </summary>
        [Obsolete("Deprecated in API9, Will be removed in API11.")]
        DefaultFontChange,
        /// <summary>
        /// Denotes that the default font size has changed.
        /// </summary>
        [Obsolete("Deprecated in API9, Will be removed in API11.")]
        DefaultFontSizeChange,
        /// <summary>
        /// Denotes that the theme has changed.
        /// </summary>
        [Obsolete("Deprecated in API9, Will be removed in API11.")]
        ThemeChange
    }

    /// <summary>
    /// Enumeration for horizontal alignment types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum HorizontalAlignmentType
    {
        /// <summary>
        /// Align horizontally left.
        /// </summary>
        [Description("left")]
        Left,
        /// <summary>
        /// Align horizontally center.
        /// </summary>
        [Description("center")]
        Center,
        /// <summary>
        /// Align horizontally right.
        /// </summary>
        [Description("right")]
        Right
    }

    /// <summary>
    /// Enumeration for vertical alignment types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum VerticalAlignmentType
    {
        /// <summary>
        /// Align vertically top.
        /// </summary>
        [Description("top")]
        Top,
        /// <summary>
        /// Align vertically center.
        /// </summary>
        [Description("center")]
        Center,
        /// <summary>
        /// Align vertically bottom.
        /// </summary>
        [Description("bottom")]
        Bottom
    }

    /// <summary>
    /// Enumeration for point state type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PointStateType
    {
        /// <summary>
        /// Touch or hover started.
        /// </summary>
        Started,
        /// <summary>
        /// Touch or hover finished.
        /// </summary>
        Finished,
        /// <summary>
        /// Screen touched.
        /// </summary>
        Down = Started,
        /// <summary>
        /// Touch stopped.
        /// </summary>
        Up = Finished,
        /// <summary>
        /// Finger dragged or hovered.
        /// </summary>
        Motion,
        /// <summary>
        /// Leave the boundary of an actor.
        /// </summary>
        Leave,
        /// <summary>
        /// No change from last event. <br />
        /// Useful when a multi-point event occurs where all points are sent, but indicates that this particular point has not changed since the last time.
        /// </summary>
        Stationary,
        /// <summary>
        /// A system event has occurred which has interrupted the touch or hover event sequence.
        /// </summary>
        Interrupted
    }

    /// <summary>
    /// The type for HiddenInput mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum HiddenInputModeType
    {
        /// <summary>
        /// Don't hide text.
        /// </summary>
        HideNone,
        /// <summary>
        /// Hide all the input text.
        /// </summary>
        HideAll,
        /// <summary>
        /// Hide n characters from start.
        /// </summary>
        HideCount,
        /// <summary>
        /// Show n characters from start.
        /// </summary>
        ShowCount,
        /// <summary>
        /// Show last character for the duration(use ShowLastCharacterDuration property to modify duration).
        /// </summary>
        ShowLastCharacter
    }

    /// <summary>
    /// Auto scrolling stop behavior.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AutoScrollStopMode
    {
        /// <summary>
        /// Stop animation after current loop finished.
        /// </summary>
        [Description("FINISH_LOOP")]
        FinishLoop,
        /// <summary>
        /// Stop animation immediately and reset position.
        /// </summary>
        [Description("IMMEDIATE")]
        Immediate
    }

    /// <summary>
    /// An enum of screen mode.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ScreenOffMode
    {
        /// <summary>
        /// The mode which turns the screen off after a timeout.
        /// </summary>
        Timout,
        /// <summary>
        /// The mode which keeps the screen turned on.
        /// </summary>
        Never
    }

    /// <summary>
    /// An enum of notification window's priority level.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NotificationLevel
    {
        /// <summary>
        /// No notification level.<br />
        /// Default level.<br />
        /// This value makes the notification window place in the layer of the normal window.
        /// </summary>
        None = -1,
        /// <summary>
        /// The base notification level.
        /// </summary>
        Base = 10,
        /// <summary>
        /// The medium notification level than base.
        /// </summary>
        Medium = 20,
        /// <summary>
        /// The higher notification level than medium.
        /// </summary>
        High = 30,
        /// <summary>
        /// The highest notification level.
        /// </summary>
        Top = 40
    }

    /// <summary>
    /// An enum of window types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WindowType
    {
        /// <summary>
        /// A default window type.<br />
        /// Indicates a normal or top-level window.
        /// Almost every window will be created with this type.
        /// </summary>
        Normal,
        /// <summary>
        /// A notification window, like a warning about battery life or a new email received.
        /// </summary>
        Notification,
        /// <summary>
        /// A persistent utility window, like a toolbox or a palette.
        /// </summary>
        Utility,
        /// <summary>
        /// Used for simple dialog windows.
        /// </summary>
        Dialog
    }

    /// <since_tizen> 3 </since_tizen>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
    public enum DisposeTypes
    {
        /// <summary>
        /// Called By User
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Explicit,
        /// <summary>
        /// Called by DisposeQueue
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Implicit,
    }

    /// <summary>
    /// An enum of the scroll state of the text editor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ScrollState
    {
        /// <summary>
        /// Scrolling is started.
        /// </summary>
        Started,

        /// <summary>
        /// Scrolling is finished.
        /// </summary>
        Finished
    }

    /// <summary>
    /// An enum of the line wrap mode of text controls.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum LineWrapMode
    {
        /// <summary>
        /// The word mode will move a word to the next line.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Word,

        /// <summary>
        /// character will move character by character to the next line.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Character
    }

    /// <summary>
    /// An enum of text directions.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum TextDirection
    {
        /// <summary>
        /// Text direction is from left to right.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        LeftToRight,

        /// <summary>
        /// Text direction is from right to left.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        RightToLeft
    }

    /// <summary>
    /// An enum of vertical line alignments.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum VerticalLineAlignment
    {
        /// <summary>
        /// vertical line alignment is from top.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Top,

        /// <summary>
        /// vertical line alignment is from center.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Center,

        /// <summary>
        /// vertical line alignment is from bottom.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Bottom
    }

    /// <summary>
    /// Enumeration type for the font's slant.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum FontSlantType
    {
        /// <summary>
        /// None.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        None,
        /// <summary>
        /// Normal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Normal,
        /// <summary>
        /// Roman.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Roman = Normal,
        /// <summary>
        /// Italic.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Italic,
        /// <summary>
        /// Oblique.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Oblique
    }

    /// <summary>
    /// Enumeration type for the font's weight.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum FontWeightType
    {
        /// <summary>
        /// None.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        None,
        /// <summary>
        /// Thin.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Thin,
        /// <summary>
        /// UltraLight.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        UltraLight,
        /// <summary>
        /// ExtraLight.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraLight = UltraLight,
        /// <summary>
        /// Light.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Light,
        /// <summary>
        /// DemiLight.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DemiLight,
        /// <summary>
        /// SemiLight.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        SemiLight = DemiLight,
        /// <summary>
        /// Book.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Book,
        /// <summary>
        /// Normal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Normal,
        /// <summary>
        /// Regular.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Regular = Normal,
        /// <summary>
        /// Medium.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Medium,
        /// <summary>
        /// DemiBold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DemiBold,
        /// <summary>
        /// SemiBold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        SemiBold = DemiBold,
        /// <summary>
        /// Bold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Bold,
        /// <summary>
        /// UltraBold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        UltraBold,
        /// <summary>
        /// ExtraBold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraBold = UltraBold,
        /// <summary>
        /// Black.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Black,
        /// <summary>
        /// Heavy.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Heavy = Black,
        /// <summary>
        /// ExtraBlack.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraBlack = Black
    }

    /// <summary>
    /// Enumeration type for the font's width.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum FontWidthType
    {
        /// <summary>
        /// None.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        None,
        /// <summary>
        /// UltraCondensed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        UltraCondensed,
        /// <summary>
        /// ExtraCondensed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraCondensed,
        /// <summary>
        /// Condensed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Condensed,
        /// <summary>
        /// SemiCondensed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        SemiCondensed,
        /// <summary>
        /// Normal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Normal,
        /// <summary>
        /// SemiExpanded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        SemiExpanded,
        /// <summary>
        /// Expanded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Expanded,
        /// <summary>
        /// ExtraExpanded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraExpanded,
        /// <summary>
        /// UltraExpanded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        UltraExpanded
    }

    /// <summary>
    /// Enumeration type for the glyph type.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum GlyphType
    {
        /// <summary>
        /// Glyph stored as pixels.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        BitmapGlyph,
        /// <summary>
        /// Glyph stored as vectors (scalable). This feature requires highp shader support and is not available on all platforms.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        VectorGlyph
    }

    /// <summary>
    /// Enumeration for Setting the rendering behavior of a Window.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum RenderingBehaviorType
    {
        /// <summary>
        /// Default. Only renders if required.
        /// </summary>
        IfRequired,
        /// <summary>
        /// Renders continuously.
        /// </summary>
        Continuously
    }

    /// <summary>
    /// The HiddenInput property.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct HiddenInputProperty
    {
        /// <summary>
        /// The mode for input text display.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Mode = NDalicManualPINVOKE.HiddeninputPropertyModeGet();
        /// <summary>
        /// All input characters are substituted by this character.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SubstituteCharacter = NDalicManualPINVOKE.HiddeninputPropertySubstituteCharacterGet();
        /// <summary>
        /// Length of text to show or hide, available when HIDE_COUNT/SHOW_COUNT mode is used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SubstituteCount = NDalicManualPINVOKE.HiddeninputPropertySubstituteCountGet();
        /// <summary>
        /// Hide last character after this duration, available when SHOW_LAST_CHARACTER mode.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int ShowLastCharacterDuration = NDalicManualPINVOKE.HiddeninputPropertyShowLastCharacterDurationGet();
    }

    /// <summary>
    /// ParentOrigin constants.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct ParentOrigin
    {
        /// <summary>
        /// Top
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Top
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginTopGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Bottom
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Bottom
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginBottomGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Left
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Left
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginLeftGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Right
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Right
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginRightGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Middle
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Middle
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginMiddleGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// TopLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// TopCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// TopRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// CenterLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Center
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Center
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// CenterRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// BottomLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// BottomCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// BottomRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
    }

    /// <summary>
    /// PivotPoint constants.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct PivotPoint
    {
        /// <summary>
        /// Top
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Top
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointTopGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// Bottom
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Bottom
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointBottomGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// Left
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Left
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointLeftGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// Right
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Right
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointRightGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// Middle
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Middle
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointMiddleGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// TopLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// TopCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// TopRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// CenterLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// Center
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Center
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// CenterRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// BottomLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// BottomCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// BottomRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
    }
    /// <summary>
    /// PositionAxis constants.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct PositionAxis
    {
        /// <summary>
        /// The X axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position X
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.XaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// The Y axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Y
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.YaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// The Z axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Z
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.ZaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// The Negative X axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position NegativeX
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.NegativeXaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// The Negative Y axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position NegativeY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.NegativeYaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// The Negative Z axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position NegativeZ
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.NegativeZaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
    }

    /// <summary>
    /// [Obsolete("Please do not use! this will be deprecated")]
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Please do not use! This will be deprecated! Please use PivotPoint instead!")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct AnchorPoint
    {
        /// <summary>
        /// Top
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Top
        {
            get
            {
                return PivotPoint.Top;
            }
        }
        /// <summary>
        /// Bottom
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Bottom
        {
            get
            {
                return PivotPoint.Bottom;
            }
        }
        /// <summary>
        /// Left
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Left
        {
            get
            {
                return PivotPoint.Left;
            }
        }
        /// <summary>
        /// Right
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Right
        {
            get
            {
                return PivotPoint.Right;
            }
        }
        /// <summary>
        /// Middle
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Middle
        {
            get
            {
                return PivotPoint.Middle;
            }
        }
        /// <summary>
        /// TopLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopLeft
        {
            get
            {
                return PivotPoint.TopLeft;
            }
        }
        /// <summary>
        /// TopCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopCenter
        {
            get
            {
                return PivotPoint.TopCenter;
            }
        }
        /// <summary>
        /// TopRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopRight
        {
            get
            {
                return PivotPoint.TopRight;
            }
        }
        /// <summary>
        /// CenterLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterLeft
        {
            get
            {
                return PivotPoint.CenterLeft;
            }
        }
        /// <summary>
        /// Center
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Center
        {
            get
            {
                return PivotPoint.Center;
            }
        }
        /// <summary>
        /// CenterRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterRight
        {
            get
            {
                return PivotPoint.CenterRight;
            }
        }
        /// <summary>
        /// BottomLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomLeft
        {
            get
            {
                return PivotPoint.BottomLeft;
            }
        }
        /// <summary>
        /// BottomCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomCenter
        {
            get
            {
                return PivotPoint.BottomCenter;
            }
        }
        /// <summary>
        /// BottomRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomRight
        {
            get
            {
                return PivotPoint.BottomRight;
            }
        }
    }

    /// <summary>
    /// Enumeration for setting cache model of a WebView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CacheModel
    {
        /// <summary>
        /// Use the smallest cache capacity.
        /// </summary>
        DocumentViewer,
        /// <summary>
        /// Use the bigger cache capacity than DocumentBrowser.
        /// </summary>
        DocumentBrowser,
        /// <summary>
        /// Use the biggest cache capacity.
        /// </summary>
        PrimaryWebBrowser
    }

    /// <summary>
    /// Enumeration for setting cache model of a WebView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CookieAcceptPolicy
    {
        /// <summary>
        /// Accepts every cookie sent from any page.
        /// </summary>
        Always,
        /// <summary>
        /// Rejects all the cookies.
        /// </summary>
        Never,
        /// <summary>
        /// Accepts only cookies set by the main document that is loaded.
        /// </summary>
        NoThirdParty
    }

    /// <summary>
    /// FontSizeScale constant.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public struct FontSizeScale
    {
        /// <summary>
        /// UseSystemSetting
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public const float UseSystemSetting = -1.0f;
    }

    /// <summary>
    /// Offset has left, right, bottom, top value.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Offset
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="left">left offset</param>
        /// <param name="right">right offset</param>
        /// <param name="bottom">bottom offset</param>
        /// <param name="top">top offset</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Offset(int left, int right, int bottom, int top)
        {
            Left = left;
            Right = right;
            Bottom = bottom;
            Top = top;
        }

        /// <summary>
        /// Left
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Left {get; set;}

        /// <summary>
        /// Right
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Right {get; set;}

        /// <summary>
        /// Bottom
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Bottom {get; set;}

        /// <summary>
        /// Top
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Top {get; set;}

    }

    /// <summary>
    /// TODO This is to get TizenFX resource path. It needs to be fixed to use application framework API in the future.
    /// Internal use only. Do not open this API.
    /// </summary>
    internal struct FrameworkInformation
    {
        public readonly static string ResourcePath = "/usr/share/dotnet.tizen/framework/res/";
    }
}
