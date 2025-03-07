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
        [Obsolete("Do not use this DrawModeType.Stencil(Deprecated). This is replaced by ClippingModeType")]
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
    [Obsolete("This has been deprecated in API10 and will be removed in API12. Do not use this.")]
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
        /// Do not use! This will be deprecated!
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Do not use! This will be deprecated!")]
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
        Ime,
        /// <summary>
        /// Used for desktop windows.
        /// This is a desktop type. No other windows can be placed below this type of window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Desktop
    }

    /// <summary>
    /// An enum of window layout types.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum WindowLayoutType
    {
        /// <summary>
        /// Window is placed on the left half of the screen
        /// </summary>
        LeftHalf,
        /// <summary>
        /// Window is placed on the right half of the screen
        /// </summary>
        RightHalf,
        /// <summary>
        /// Window is placed on the top half of the screen
        /// </summary>
        TopHalf,
        /// <summary>
        /// Window is placed on the bottom half of the screen
        /// </summary>
        BottomHalf,
        /// <summary>
        /// Window is placed on the upper-left quarter of the screen
        /// </summary>
        UpperLeftQuarter,
        /// <summary>
        /// Window is placed on the upper-right quarter of the screen
        /// </summary>
        UpperRightQuarter,
        /// <summary>
        /// Window is placed on the lower-left quarter of the screen
        /// </summary>
        LowerLeftQuarter,
        /// <summary>
        /// Window is placed on the lower-right quarter of the screen
        /// </summary>
        LowerRightQuarter,
        /// <summary>
        /// Window is placed on the left third of the screen horizontally
        /// </summary>
        LeftThird,
        /// <summary>
        /// Window is placed on the center third of the screen horizontally
        /// </summary>
        CenterThird,
        /// <summary>
        /// Window is placed on the right third of the screen horizontally
        /// </summary>
        RightThird,
        /// <summary>
        /// Window is placed on the top third of the screen vertically
        /// </summary>
        TopThird,
        /// <summary>
        /// Window is placed on the middle third of the screen vertically
        /// </summary>
        MiddleThird,
        /// <summary>
        /// Window is placed on the bottom third of the screen vertically
        /// </summary>
        BottomThird,
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
        /// The word mode moves a word to the next line.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Word,

        /// <summary>
        /// character moves character by character to the next line.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Character,

        /// <summary>
        /// Hyphenation mode moves part of the word (at possible hyphen locations)
        /// to the next line and draw a hyphen at the end of the line.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Hyphenation,

        /// <summary>
        /// Mixed mode tries word wrap, if failed, it tries hyphenation wrap.
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
    /// Enumeration for the ellipsis mode of text.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum EllipsisMode
    {
        /// <summary>
        /// When the text is long, it will be truncated with ellipsis.
        /// </summary>
        Truncate,

        /// <summary>
        /// When the text is long, it will automatically scroll with animation.
        /// </summary>
        AutoScroll
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
    /// The SelectionPopupStyle property.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct SelectionPopupStyleProperty
    {
        /// <summary>
        /// The maximum size the Popup can be.
        /// </summary>
        public static readonly int MaxSize = NDalicManualPINVOKE.TextSelectionPopupPropertyPopupMaxSizeGet();

        /// <summary>
        /// TThe size of the divider between popup buttons.
        /// </summary>
        public static readonly int DividerSize = NDalicManualPINVOKE.TextSelectionPopupPropertyOptionDividerSizeGet();

        /// <summary>
        /// The padding of the divider between popup buttons.
        /// </summary>
        public static readonly int DividerPadding = NDalicManualPINVOKE.TextSelectionPopupPropertyOptionDividerPaddingGet();

        /// <summary>
        /// The color of the divider between popup buttons.
        /// </summary>
        public static readonly int DividerColor = NDalicManualPINVOKE.TextSelectionPopupPropertyPopupDividerColorGet();

        /// <summary>
        /// The color of the button when pressed.
        /// </summary>
        public static readonly int PressedColor = NDalicManualPINVOKE.TextSelectionPopupPropertyPopupPressedColorGet();

        /// <summary>
        /// The corner radius of the button when pressed.
        /// </summary>
        public static readonly int PressedCornerRadius = NDalicManualPINVOKE.TextSelectionPopupPropertyPopupPressedCornerRadiusGet();

        /// <summary>
        /// The duration of the fade-in animation.
        /// </summary>
        public static readonly int FadeInDuration = NDalicManualPINVOKE.TextSelectionPopupPropertyPopupFadeInDurationGet();

        /// <summary>
        /// The duration of the fade-out animation.
        /// </summary>
        public static readonly int FadeOutDuration = NDalicManualPINVOKE.TextSelectionPopupPropertyPopupFadeOutDurationGet();

        /// <summary>
        /// The popup background.
        /// </summary>
        public static readonly int Background = NDalicManualPINVOKE.TextSelectionPopupPropertyPopupBackgroundGet();

        /// <summary>
        /// The popup background can have a separate border with a different color.
        /// </summary>
        public static readonly int BackgroundBorder = NDalicManualPINVOKE.TextSelectionPopupPropertyPopupBackgroundBorderGet();

        /// <summary>
        /// The minimum size of popup label.
        /// </summary>
        public static readonly int LabelMinimumSize = NDalicManualPINVOKE.TextSelectionPopupPropertyLabelMinimumSizeGet();

        /// <summary>
        /// The padding of popup label.
        /// </summary>
        public static readonly int LabelPadding = NDalicManualPINVOKE.TextSelectionPopupPropertyLabelPaddingGet();

        /// <summary>
        /// The text visual map of popup label.
        /// </summary>
        public static readonly int LabelTextVisual = NDalicManualPINVOKE.TextSelectionPopupPropertyLabelTextVisualGet();

        /// <summary>
        /// Whether the scroll-bar is enabled.
        /// </summary>
        public static readonly int EnableScrollBar = NDalicManualPINVOKE.TextSelectionPopupPropertyEnableScrollBarGet();
    };

    /// <summary>
    /// ParentOrigin constants.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct ParentOrigin
    {
        private static readonly Position topLeft = new Position(Left, Top, Middle);
        private static readonly Position topCenter = new Position(Middle, Top, Middle);
        private static readonly Position topRight = new Position(Right, Top, Middle);
        private static readonly Position centerLeft = new Position(Left, Middle, Middle);
        private static readonly Position center = new Position(Middle, Middle, Middle);
        private static readonly Position centerRight = new Position(Right, Middle, Middle);
        private static readonly Position bottomLeft = new Position(Left, Bottom, Middle);
        private static readonly Position bottomCenter = new Position(Middle, Bottom, Middle);
        private static readonly Position bottomRight = new Position(Right, Bottom, Middle);

        internal static void Preload()
        {
            // Do nothing. Just call for load static values.
        }

        /// <summary>
        /// Top
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Top => 0.0f;

        /// <summary>
        /// Bottom
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Bottom => 1.0f;

        /// <summary>
        /// Left
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Left => 0.0f;

        /// <summary>
        /// Right
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Right => 1.0f;

        /// <summary>
        /// Middle
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Middle => 0.5f;

        /// <summary>
        /// TopLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopLeft => topLeft;

        /// <summary>
        /// TopCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopCenter => topCenter;

        /// <summary>
        /// TopRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopRight => topRight;

        /// <summary>
        /// CenterLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterLeft => centerLeft;

        /// <summary>
        /// Center
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Center => center;

        /// <summary>
        /// CenterRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterRight => centerRight;

        /// <summary>
        /// BottomLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomLeft => bottomLeft;

        /// <summary>
        /// BottomCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomCenter => bottomCenter;

        /// <summary>
        /// BottomRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomRight => bottomRight;
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
        public static float Top => ParentOrigin.Top;

        /// <summary>
        /// Bottom
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Bottom => ParentOrigin.Bottom;

        /// <summary>
        /// Left
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Left => ParentOrigin.Left;

        /// <summary>
        /// Right
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Right => ParentOrigin.Right;

        /// <summary>
        /// Middle
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Middle => ParentOrigin.Middle;

        /// <summary>
        /// TopLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopLeft => ParentOrigin.TopLeft;

        /// <summary>
        /// TopCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopCenter => ParentOrigin.TopCenter;

        /// <summary>
        /// TopRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopRight => ParentOrigin.TopRight;

        /// <summary>
        /// CenterLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterLeft => ParentOrigin.CenterLeft;

        /// <summary>
        /// Center
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Center => ParentOrigin.Center;

        /// <summary>
        /// CenterRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterRight => ParentOrigin.CenterRight;

        /// <summary>
        /// BottomLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomLeft => ParentOrigin.BottomLeft;

        /// <summary>
        /// BottomCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomCenter => ParentOrigin.BottomCenter;

        /// <summary>
        /// BottomRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomRight => ParentOrigin.BottomRight;
    }

    /// <summary>
    /// PositionAxis constants.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct PositionAxis
    {
        private static readonly Position xaxis = new Position(1.0f, 0.0f, 0.0f);
        private static readonly Position yaxis = new Position(0.0f, 1.0f, 0.0f);
        private static readonly Position zaxis = new Position(0.0f, 0.0f, 1.0f);
        private static readonly Position negativeXaxis = new Position(-1.0f, 0.0f, 0.0f);
        private static readonly Position negativeYaxis = new Position(0.0f, -1.0f, 0.0f);
        private static readonly Position negativeZaxis = new Position(0.0f, 0.0f, -1.0f);

        internal static void Preload()
        {
            // Do nothing. Jsut call for load static values.
        }

        /// <summary>
        /// The X axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position X => xaxis;

        /// <summary>
        /// The Y axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Y => yaxis;

        /// <summary>
        /// The Z axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Z => zaxis;

        /// <summary>
        /// The Negative X axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position NegativeX => negativeXaxis;

        /// <summary>
        /// The Negative Y axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position NegativeY => negativeYaxis;

        /// <summary>
        /// The Negative Z axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position NegativeZ => negativeZaxis;
    }

    /// <summary>
    /// [Obsolete("Do not use this, that will be deprecated.")]
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Do not use this, that will be deprecated. Use as PivotPoint instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct AnchorPoint
    {
        /// <summary>
        /// Top
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Top => ParentOrigin.Top;

        /// <summary>
        /// Bottom
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Bottom => ParentOrigin.Bottom;

        /// <summary>
        /// Left
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Left => ParentOrigin.Left;

        /// <summary>
        /// Right
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Right => ParentOrigin.Right;

        /// <summary>
        /// Middle
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Middle => ParentOrigin.Middle;

        /// <summary>
        /// TopLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopLeft => ParentOrigin.TopLeft;

        /// <summary>
        /// TopCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopCenter => ParentOrigin.TopCenter;

        /// <summary>
        /// TopRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopRight => ParentOrigin.TopRight;

        /// <summary>
        /// CenterLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterLeft => ParentOrigin.CenterLeft;

        /// <summary>
        /// Center
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Center => ParentOrigin.Center;

        /// <summary>
        /// CenterRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterRight => ParentOrigin.CenterRight;

        /// <summary>
        /// BottomLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomLeft => ParentOrigin.BottomLeft;

        /// <summary>
        /// BottomCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomCenter => ParentOrigin.BottomCenter;

        /// <summary>
        /// BottomRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomRight => ParentOrigin.BottomRight;
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
    /// FontFamily constant.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct FontFamily
    {
        /// <summary>
        /// UseSystemSetting
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly string UseSystemSetting = string.Empty;
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
    /// This Enumeration is used the GLES version for EGL configuration.
    /// It is for GLWindow and GLView.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
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
    /// <since_tizen> 10 </since_tizen>
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
    /// Enumeration for the type of InputFilter.
    /// </summary>
    /// <remarks>
    /// The type of InputFilter that is stored in the <see cref="Tizen.NUI.BaseComponents.InputFilteredEventArgs"/> when the input is filtered.
    /// </remarks>
    /// <since_tizen> 9 </since_tizen>
    public enum InputFilterType
    {
        /// <summary>
        /// The type of InputFilter is Accept.
        /// </summary>
        Accept,

        /// <summary>
        /// The type of InputFilter is Reject.
        /// </summary>
        Reject
    }

    /// <summary>
    /// Enumeration for the type of Underline.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum UnderlineType
    {
        /// <summary>
        /// The default underline type.
        /// </summary>
        Solid,

        /// <summary>
        /// The dashed underline type.
        /// </summary>
        Dashed,

        /// <summary>
        /// The double underline type.
        /// </summary>
        Double
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

    /// <summary>
    /// Enumeration for the render mode of text.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum TextRenderMode
    {
        /// <summary>
        /// default, synchronous text loading.
        /// </summary>
        Sync,

        /// <summary>
        /// automatically requests an asynchronous text load in OnRelayout.
        /// </summary>
        AsyncAuto,

        /// <summary>
        /// users should manually request rendering using the async text method.
        /// </summary>
        AsyncManual
    }

    /// <summary>
    /// Pre-defined SlideTransition Direction
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct SlideTransitionDirection
    {
        private static readonly Vector2 top = new Vector2(0, -1);
        private static readonly Vector2 bottom = new Vector2(0, 1);
        private static readonly Vector2 left = new Vector2(-1, 0);
        private static readonly Vector2 right = new Vector2(1, 0);

        internal static void Preload()
        {
            // Do nothing. Just call for load static values.
        }

        /// <summary>
        /// Top
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector2 Top => top;

        /// <summary>
        /// Bottom
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector2 Bottom => bottom;

        /// <summary>
        /// Right
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector2 Right => right;

        /// <summary>
        /// Left
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector2 Left => left;
    }

    /// <summary>
    /// Enumeration of window blur type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum WindowBlurType
    {
        /// <summary>
        /// None type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        None = 0,
        /// <summary>
        /// background blur for the window.
        /// It has a blur effect ot th background area of the window, making it appear blurred.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Background = 1,
        /// <summary>
        /// behind blur for the window.
        /// It has a blur effect ot th beind area of except the window background.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Behind = 2,        
    }

    internal struct NUIConstants
    {
        internal static void Preload()
        {
            ParentOrigin.Preload();
            SlideTransitionDirection.Preload();
            PositionAxis.Preload();
            Position.Preload();
            Vector2.Preload();
            Vector3.Preload();
            Vector4.Preload();
        }
    }
}
