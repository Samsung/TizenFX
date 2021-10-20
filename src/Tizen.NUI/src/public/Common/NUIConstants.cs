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
        UseAssignedSize,

        /// <summary>
        /// The size always equal with parent even parent has size animation.
        /// Note : This Property only working without layout. If layout is setup, Undefined Behavior
        /// </summary>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        KeepSizeFollowingParent
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
    /// <remarks>
    /// Most of window type can be set, except for IME type.<br />
    /// IME type can only be used in one of NUIApplication's constrcutors.<br />
    /// </remarks>
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
        Dialog,
        /// <summary>
        /// Used for IME window that is used for keyboard window.
        /// It should be set in NUIApplication constructor.
        /// It does not work with Window.Type, because IME window type can not change in runtime.
        /// </summary>
        /// <remarks>
        /// See <see cref="NUIApplication" /> for this type. <br />
        /// </remarks>
        Ime
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
        Character,

        /// <summary>
        /// Hyphenation mode will move part of the word (at possible hyphen locations)
        /// to the next line and draw a hyphen at the end of the line.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Hyphenation,

        /// <summary>
        /// Mixed mode will try word wrap, if failed, it will try hyphenation wrap.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Mixed
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
    /// An enum of ellipsis position.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public enum EllipsisPosition
    {
        /// <summary>
        /// ellipsis position at end.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        End,

        /// <summary>
        /// ellipsis position at start.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Start,

        /// <summary>
        /// ellipsis position in the middle.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Middle
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

    /// <summary>
    /// This Enumeration is used the GLES version for EGL configuration.<br />
    /// If the device can not support GLES version 3.0 over, the version will be chosen with GLES version 2.0.<br />
    /// It is for GLWindow and GLView.<br />
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GLESVersion
    {
      /// <summary>
      /// GLES version 2.0
      /// </summary>
      Version20 = 0,

      /// <summary>
      /// GLES version 3.0
      /// </summary>
      Version30
    }

    /// <summary>
    /// Enumeration for rendering mode
    /// This Enumeration is used to choose the rendering mode.
    /// It is for GLWindow and GLView.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GLRenderingMode
    {
      /// <summary>
      /// The render frame delegate is invoked continuously.
      /// </summary>
      Continuous = 0,

      /// <summary>
      /// The render frame delegate is invoked by user.
      /// </summary>
      OnDemand = 1
    }

    /// <summary>
    /// Enumeration for the type of InputFilter. <br />
    /// </summary>
    /// <remarks>
    /// The type of InputFilter that is stored in the <see cref="Tizen.NUI.BaseComponents.InputFilteredEventArgs"/> when the input is filtered. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum InputFilterType
    {
        /// <summary>
        /// The type of InputFilter is Accept.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Accept,

        /// <summary>
        /// The type of InputFilter is Reject.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Reject
    }

    /// <summary>
    /// Enumeration for the size type of font. <br />
    /// </summary>
    /// <remarks>
    /// The size type of font used as a property of <see cref="Tizen.NUI.Text.TextFit"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum FontSizeType
    {
        /// <summary>
        /// The PointSize.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PointSize,

        /// <summary>
        /// The PixelSize.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PixelSize
    }

    namespace Text
    {
        /// <summary>
        /// A struct to pass data of InputFilter PropertyMap. <br />
        /// </summary>
        /// <remarks>
        /// InputFilter filters input based on regular expressions. <br />
        /// Users can set the Accepted or Rejected regular expression set, or both. <br />
        /// If both are used, Rejected has higher priority. <br />
        /// The character set must follow the regular expression rules. <br />
        /// Behaviour can not be guaranteed for incorrect grammars. <br />
        /// Refer the link below for detailed rules. <br />
        /// The functions in std::regex library use the ECMAScript grammar: <br />
        /// http://cplusplus.com/reference/regex/ECMAScript/ <br />
        /// The InputFilter struct is used as an argument to SetInputFilter and GetInputFilter methods. <br />
        /// See <see cref="Tizen.NUI.BaseComponents.TextField.SetInputFilter"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetInputFilter"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetInputFilter"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetInputFilter"/>. <br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct InputFilter
        {
            /// <summary>
            /// A regular expression in the set of characters to be accepted by the inputFilter.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Accepted { get; set; }

            /// <summary>
            /// A regular expression in the set of characters to be rejected by the inputFilter.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Rejected { get; set; }
        }

        /// <summary>
        /// A struct to pass data of FontStyle PropertyMap. <br />
        /// </summary>
        /// <remarks>
        /// The FontStyle struct is used as an argument to SetFontStyle and GetFontStyle methods. <br />
        /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetFontStyle"/>, <see cref="Tizen.NUI.BaseComponents.TextLabel.GetFontStyle"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetFontStyle"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetFontStyle"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetFontStyle"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetFontStyle"/>. <br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct FontStyle
        {
            /// <summary>
            /// The Width defines occupied by each glyph.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public FontWidthType Width { get; set; }

            /// <summary>
            /// The Weight defines the thickness or darkness of the glyphs.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public FontWeightType Weight { get; set; }

            /// <summary>
            /// The Slant defines whether to use italics.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public FontSlantType Slant { get; set; }
        }

        /// <summary>
        /// A struct to pass data of Underline PropertyMap. <br />
        /// </summary>
        /// <remarks>
        /// The Underline struct is used as an argument to SetUnderline and GetUnderline methods. <br />
        /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetUnderline"/>, <see cref="Tizen.NUI.BaseComponents.TextLabel.GetUnderline"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetUnderline"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetUnderline"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetUnderline"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetUnderline"/>. <br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct Underline
        {
            /// <summary>
            /// Whether the underline is enabled (the default value is false).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Enable { get; set; }

            /// <summary>
            /// The color of the underline (if not provided then the color of the text is used).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color Color { get; set; }

            /// <summary>
            /// The height in pixels of the underline (if null, the default value is 1.0f).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? Height { get; set; }
        }

        /// <summary>
        /// A struct to pass data of Shadow PropertyMap. <br />
        /// </summary>
        /// <remarks>
        /// The Shadow struct is used as an argument to SetShadow and GetShadow methods. <br />
        /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetShadow"/>, <see cref="Tizen.NUI.BaseComponents.TextLabel.GetShadow"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetShadow"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetShadow"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetShadow"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetShadow"/>. <br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct Shadow
        {
            /// <summary>
            /// The color of the shadow (the default color is Color.Black).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color Color { get; set; }

            /// <summary>
            /// The offset in pixels of the shadow (if null, the default value is 0, 0). <br />
            /// If not provided then the shadow is not enabled. <br />
            ///
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Vector2 Offset { get; set; }

            /// <summary>
            /// The radius of the Gaussian blur for the soft shadow (if null, the default value is 0.0f). <br />
            /// If not provided then the soft shadow is not enabled. <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? BlurRadius { get; set; }
        }

        /// <summary>
        /// A struct to pass data of Outline PropertyMap. <br />
        /// </summary>
        /// <remarks>
        /// The Outline struct is used as an argument to SetOutline and GetOutline methods. <br />
        /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetOutline"/>, <see cref="Tizen.NUI.BaseComponents.TextLabel.GetOutline"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetOutline"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetOutline"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetOutline"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetOutline"/>. <br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct Outline
        {
            /// <summary>
            /// The color of the outline (the default color is Color.White).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color Color { get; set; }

            /// <summary>
            /// The width in pixels of the outline (if null, the default value is 0.0f). <br />
            /// If not provided then the outline is not enabled. <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? Width { get; set; }
        }

        /// <summary>
        /// A struct to pass data of TextFit PropertyMap. <br />
        /// </summary>
        /// <remarks>
        /// The TextFit struct is used as an argument to SetTextFit and GetTextFit methods. <br />
        /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetTextFit"/> and <see cref="Tizen.NUI.BaseComponents.TextLabel.GetTextFit"/>. <br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct TextFit
        {
            /// <summary>
            /// True to enable the text fit or false to disable (the default value is false).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Enable { get; set; }

            /// <summary>
            /// Minimum Size for text fit (if null, the default value is 10.0f).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? MinSize { get; set; }

            /// <summary>
            /// Maximum Size for text fit (if null, the default value is 100.0f).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? MaxSize { get; set; }

            /// <summary>
            /// Step Size for font increase (if null, the default value is 1.0f).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? StepSize { get; set; }

            /// <summary>
            /// The size type of font, PointSize or PixelSize (the default value is PointSize).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public FontSizeType FontSizeType { get; set; }

            /// <summary>
            /// Font Size for text fit
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? FontSize { get; set; }
        }

        /// <summary>
        /// A struct to pass data of Placeholder PropertyMap. <br />
        /// </summary>
        /// <remarks>
        /// The Placeholder struct is used as an argument to SetPlaceholder and GetPlaceholder methods. <br />
        /// See <see cref="Tizen.NUI.BaseComponents.TextField.SetPlaceholder"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetPlaceholder"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetPlaceholder"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.SetPlaceholder"/>. <br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct Placeholder
        {
            /// <summary>
            /// The text to display when the TextField is empty and inactive.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Text { get; set; }

            /// <summary>
            /// The text to display when the placeholder has focus.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string TextFocused { get; set; }

            /// <summary>
            /// The color of the placeholder text.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color Color { get; set; }

            /// <summary>
            /// The FontFamily of the placeholder text.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string FontFamily { get; set; }

            /// <summary>
            /// The FontStyle of the placeholder text (if null, the text control FontStyle is used).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public FontStyle? FontStyle { get; set; }

            /// <summary>
            /// The PointSize of the placeholder text. <br />
            /// Not required if PixelSize provided. <br />
            /// If both provided or neither provided then the text control point size is used. <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? PointSize { get; set; }

            /// <summary>
            /// The PiexSize of the placeholder text.
            /// Not required if PointSize provided. <br />
            /// If both provided or neither provided then the text control point size is used. <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float? PixelSize { get; set; }

            /// <summary>
            /// The ellipsis of the placeholder text (the default value is false).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Ellipsis { get; set; }
        }

        /// <summary>
        /// A struct to pass data of HiddenInputSettings PropertyMap. <br />
        /// </summary>
        /// <remarks>
        /// The HiddenInput struct is used as an argument to SetHiddenInput and GetHiddenInput methods. <br />
        /// See <see cref="Tizen.NUI.BaseComponents.TextField.SetHiddenInput"/> and <see cref="Tizen.NUI.BaseComponents.TextField.GetHiddenInput"/>. <br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct HiddenInput
        {
            /// <summary>
            /// The mode for input text display. <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public HiddenInputModeType Mode { get; set; }

            /// <summary>
            /// All input characters are substituted by this character (if null, the default value is '*'). <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public char? SubstituteCharacter { get; set; }

            /// <summary>
            /// Length of text to show or hide, available when HideCount/ShowCount mode is used (if null, the default value is 0). <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int? SubstituteCount { get; set; }

            /// <summary>
            /// Hide last character after this duration, available when ShowLastCharacter mode (if null, the default value is 1000). <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int? ShowLastCharacterDuration { get; set; }
        }

        /// <summary>
        /// A struct to pass data of SelectionHandleImageLeft, SelectionHandleImageRight, SelectionHandlePressedImageLeft, SelectionHandlePressedImageRight, SelectionHandleMarkerImageLeft and SelectionHandleMarkerImageRight PropertyMap. <br />
        /// </summary>
        /// <remarks>
        /// The SelectionHandleImage struct is used as an argument to SetSelectionHandleImage, GetSelectionHandleImage methods, SetSelectionHandlePressedImage, GetSelectionHandlePressedImage, SetSelectionHandleMarkerImage and GetSelectionHandleMarkerImage. <br />
        /// See <see cref="Tizen.NUI.BaseComponents.TextField.SetSelectionHandleImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetSelectionHandleImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetSelectionHandlePressedImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetSelectionHandlePressedImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetSelectionHandleMarkerImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetSelectionHandleMarkerImage"/>, <br />
        /// <see cref="Tizen.NUI.BaseComponents.TextEditor.SetSelectionHandleImage"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.GetSelectionHandleImage"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetSelectionHandlePressedImage"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.GetSelectionHandlePressedImage"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetSelectionHandleMarkerImage"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetSelectionHandleMarkerImage"/>. <br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct SelectionHandleImage
        {
            /// <summary>
            /// The image path to display for the left selection handle. <br />
            /// It means the handle in the bottom-left. <br />
            /// If the handle needs to be displayed in the top-left, this image will be vertically flipped. <br />
            /// If null or empty string, it doesn't change the property. <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string LeftImageUrl { get; set; }

            /// <summary>
            /// The image path to display for the right selection handle. <br />
            /// It means the handle in the bottom-right. <br />
            /// If the handle needs to be displayed in the top-right, this image will be vertically flipped. <br />
            /// If null or empty string, it doesn't change the property. <br />
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string RightImageUrl { get; set; }
        }
    }


    /// <summary>
    /// Pre-defined SlideTransition Direction
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct SlideTransitionDirection
    {
        /// <summary>
        /// Top
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector2 Top
        {
            get
            {
                global::System.IntPtr cPtr = Interop.SlideTransitionDirection.SlideTransitionDirectionTopGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
        /// <summary>
        /// Bottom
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector2 Bottom
        {
            get
            {
                global::System.IntPtr cPtr = Interop.SlideTransitionDirection.SlideTransitionDirectionBottomGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Right
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector2 Right
        {
            get
            {
                global::System.IntPtr cPtr = Interop.SlideTransitionDirection.SlideTransitionDirectionRightGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Left
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector2 Left
        {
            get
            {
                global::System.IntPtr cPtr = Interop.SlideTransitionDirection.SlideTransitionDirectionLeftGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
    }
}
