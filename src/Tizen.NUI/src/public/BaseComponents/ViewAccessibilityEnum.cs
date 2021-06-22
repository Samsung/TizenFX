/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Accessibility interface.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityInterface
    {
        /// <summary>
        /// Common accessibility interface
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        None = 0,
        /// <summary>
        /// Accessibility interface which can store numeric value
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Value = 1,
        /// <summary>
        /// Accessibility interface which can store editable texts
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EditableText = 2,
        /// <summary>
        /// Accessibility interface which can store a set of selected items
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Selection = 3,
    }

    /// <summary>
    /// Accessibility reading information types.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Flags]
    public enum AccessibilityReadingInfoTypes : int
    {
        /// <summary>
        /// None.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        None = 0,
        /// <summary>
        /// Name trait for reading information.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Name = 1,
        /// <summary>
        /// Role trait for reading information.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Role = 2,
        /// <summary>
        /// Description trait for reading information.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Description = 4,
        /// <summary>
        /// State trait for reading information.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        State = 8
    };

    /// <summary>
    /// Accessibility gesture types.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityGesture
    {
        /// <summary>
        /// One finger hover gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerHover = 0,
        /// <summary>
        /// Two fingers hover gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingerHover,
        /// <summary>
        /// Three fingers hover gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingerHover,
        /// <summary>
        /// One finger flick left gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerFlickLeft,
        /// <summary>
        /// One finger flick right gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerFlickRight,
        /// <summary>
        /// One finger flick up gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerFlickUp,
        /// <summary>
        /// One finger flick down gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerFlickDown,
        /// <summary>
        /// Two fingers flick left gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersFlickLeft,
        /// <summary>
        /// Two fingers flick right gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersFlickRight,
        /// <summary>
        /// Two fingers flick up gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersFlickUp,
        /// <summary>
        /// Two fingers flick down gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersFlickDown,
        /// <summary>
        /// Three fingers flick left gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersFlickLeft,
        /// <summary>
        /// Three fingers flick right gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersFlickRight,
        /// <summary>
        /// Three fingers flick up gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersFlickUp,
        /// <summary>
        /// Three fingers flick down gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersFlickDown,
        /// <summary>
        /// One finger single tap gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerSingleTap,
        /// <summary>
        /// One finger double tap gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerDoubleTap,
        /// <summary>
        /// One finger triple tap gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerTripleTap,
        /// <summary>
        /// Two fingers single tap gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersSingleTap,
        /// <summary>
        /// Two fingers double tap gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersDoubleTap,
        /// <summary>
        /// Two fingers triple tap gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersTripleTap,
        /// <summary>
        /// Three fingers single tap gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersSingleTap,
        /// <summary>
        /// Three fingers double tap gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersDoubleTap,
        /// <summary>
        /// Three fingers triple tap gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersTripleTap,
        /// <summary>
        /// One finger flick left return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerFlickLeftReturn,
        /// <summary>
        /// One finger flick right return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerFlickRightReturn,
        /// <summary>
        /// One finger flick up return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerFlickUpReturn,
        /// <summary>
        /// One finger flick down return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerFlickDownReturn,
        /// <summary>
        /// Two fingers flick left return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersFlickLeftReturn,
        /// <summary>
        /// Two fingers flick right return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersFlickRightReturn,
        /// <summary>
        /// Two fingers flick up return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersFlickUpReturn,
        /// <summary>
        /// Two fingers flick down return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersFlickDownReturn,
        /// <summary>
        /// Three fingers flick left return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersFlickLeftReturn,
        /// <summary>
        /// Three fingers flick right return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersFlickRightReturn,
        /// <summary>
        /// Three fingers flick up return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersFlickUpReturn,
        /// <summary>
        /// Three fingers flick down return gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersFlickDownReturn,
        /// <summary>
        /// One finger double tap and hold gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneFingerDoubleTapNHold,
        /// <summary>
        /// Two fingers double tap and hold gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TwoFingersDoubleTapNHold,
        /// <summary>
        /// Three fingers double tap and hold gesture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ThreeFingersDoubleTapNHold,
        /// <summary>
        /// Max count.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MaxCount
    };

    /// <summary>
    /// The current state of gesture.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityGestureState
    {
        /// <summary>
        /// The gesture is started.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Begin = 0,
        /// <summary>
        /// The gesture is ongoing.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Ongoing,
        /// <summary>
        /// The gesture is ended.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Ended,
        /// <summary>
        /// The gesture is aborted.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Aborted
    };

    /// <summary>
    /// The states of accessibility object.
    /// </summary>
    /// <remarks>
    /// Object can be in many states at the same time.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Flags]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32", Justification = "System.Int32 type wouldn't have sufficient capacity")]
    public enum AccessibilityStates : ulong
    {
        /// <summary>
        /// Invalid state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Invalid                = (1UL << 0),
        /// <summary>
        /// Active state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Active                 = (1UL << 1),
        /// <summary>
        /// Armed state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Armed                  = (1UL << 2),
        /// <summary>
        /// Busy state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Busy                   = (1UL << 3),
        /// <summary>
        /// Checked state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Checked                = (1UL << 4),
        /// <summary>
        /// Collapsed state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Collapsed              = (1UL << 5),
        /// <summary>
        /// Defunct state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Defunct                = (1UL << 6),
        /// <summary>
        /// Editable state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Editable               = (1UL << 7),
        /// <summary>
        /// Enabled state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Enabled                = (1UL << 8),
        /// <summary>
        /// Expandable state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Expandable             = (1UL << 9),
        /// <summary>
        /// Expanded state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Expanded               = (1UL << 10),
        /// <summary>
        /// Focusable state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Focusable              = (1UL << 11),
        /// <summary>
        /// Focused state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Focused                = (1UL << 12),
        /// <summary>
        /// Had tooltip state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        HasTooltip             = (1UL << 13),
        /// <summary>
        /// Horizontal state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Horizontal             = (1UL << 14),
        /// <summary>
        /// Iconified state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Iconified              = (1UL << 15),
        /// <summary>
        /// Modal state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Modal                  = (1UL << 16),
        /// <summary>
        /// Multi-line state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MultiLine              = (1UL << 17),
        /// <summary>
        /// Multi-selectable state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MultiSelectable        = (1UL << 18),
        /// <summary>
        /// Opaque state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Opaque                 = (1UL << 19),
        /// <summary>
        /// Pressed state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Pressed                = (1UL << 20),
        /// <summary>
        /// Resizeable state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Resizeable             = (1UL << 21),
        /// <summary>
        /// Selectable state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Selectable             = (1UL << 22),
        /// <summary>
        /// Selected state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Selected               = (1UL << 23),
        /// <summary>
        /// Sensitive state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Sensitive              = (1UL << 24),
        /// <summary>
        /// Showing state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Showing                = (1UL << 25),
        /// <summary>
        /// Single line state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SingleLine             = (1UL << 26),
        /// <summary>
        /// Stale state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Stale                  = (1UL << 27),
        /// <summary>
        /// Transient state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Transient              = (1UL << 28),
        /// <summary>
        /// Vertical state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Vertical               = (1UL << 29),
        /// <summary>
        /// Visible state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Visible                = (1UL << 30),
        /// <summary>
        /// Managed descendants state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ManagesDescendants     = (1UL << 31),
        /// <summary>
        /// Indeterminate state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Indeterminate          = (1UL << 32),
        /// <summary>
        /// Required state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Required               = (1UL << 33),
        /// <summary>
        /// Truncated state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Truncated              = (1UL << 34),
        /// <summary>
        /// Animated state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Animated               = (1UL << 35),
        /// <summary>
        /// Invalid entry state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        InvalidEntry           = (1UL << 36),
        /// <summary>
        /// Supported auto completion state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SupportsAutocompletion = (1UL << 37),
        /// <summary>
        /// Selectable text state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SelectableText         = (1UL << 38),
        /// <summary>
        /// Default state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IsDefault              = (1UL << 39),
        /// <summary>
        /// Visited state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Visited                = (1UL << 40),
        /// <summary>
        /// Checkable state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Checkable              = (1UL << 41),
        /// <summary>
        /// Had popup state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        HasPopup               = (1UL << 42),
        /// <summary>
        /// Read only state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ReadOnly               = (1UL << 43),
        /// <summary>
        /// Highlighted state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Highlighted            = (1UL << 44),
        /// <summary>
        /// Highlightable state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Highlightable          = (1UL << 45),
    };

    /// <summary>
    /// The relation between accessible objects.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityRelationType
    {
        /// <summary>
        /// Null relation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        NullOf = 0,
        /// <summary>
        /// Label for.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LabelFor,
        /// <summary>
        /// Labelled by.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LabelledBy,
        /// <summary>
        /// Controller for.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ControllerFor,
        /// <summary>
        /// Controlled by.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ControlledBy,
        /// <summary>
        /// Member of.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MemberOf,
        /// <summary>
        /// Tooltip for.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TooltipFor,
        /// <summary>
        /// Node child of.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        NodeChildOf,
        /// <summary>
        /// Node parent of.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        NodeParentOf,
        /// <summary>
        /// Extended.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Extended,
        /// <summary>
        /// Flows to.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FlowsTo,
        /// <summary>
        /// Flows from.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FlowsFrom,
        /// <summary>
        /// Subwindow of.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SubwindowOf,
        /// <summary>
        /// Embeds.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Embeds,
        /// <summary>
        /// Embedded by.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EmbeddedBy,
        /// <summary>
        /// Popup for.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PopupFor,
        /// <summary>
        /// Parent window of.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ParentWindowOf,
        /// <summary>
        /// Description for.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DescriptionFor,
        /// <summary>
        /// Described by.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DescribedBy,
        /// <summary>
        /// Details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Details,
        /// <summary>
        /// Details for.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DetailsFor,
        /// <summary>
        /// Error message.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ErrorMessage,
        /// <summary>
        /// Error for.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ErrorFor,
        /// <summary>
        /// Max count.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MaxCount
    };

    /// <summary>
    /// The accessibility role.
    /// </summary>
    /// <remarks>
    /// For more information about AT-SPI2 role definition, please refer to
    /// https://developer.gnome.org/libatspi/stable/libatspi-atspi-constants.html#AtspiRole
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum Role
    {
        /// <summary>
        /// Invalid.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Invalid,
        /// <summary>
        /// Accelerator label.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        AcceleratorLabel,
        /// <summary>
        /// Alert.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Alert,
        /// <summary>
        /// Animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Animation,
        /// <summary>
        /// Arrow.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Arrow,
        /// <summary>
        /// Calendar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Calendar,
        /// <summary>
        /// Canvas.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Canvas,
        /// <summary>
        /// Checkbox.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        CheckBox,
        /// <summary>
        /// Check menu item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        CheckMenuItem,
        /// <summary>
        /// Color chooser.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ColorChooser,
        /// <summary>
        /// Column header.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ColumnHeader,
        /// <summary>
        /// Combo box.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ComboBox,
        /// <summary>
        /// Date editor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DateEditor,
        /// <summary>
        /// Desktop icon.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DesktopIcon,
        /// <summary>
        /// Desktop frame.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DesktopFrame,
        /// <summary>
        /// Dial.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Dial,
        /// <summary>
        /// Dialog.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Dialog,
        /// <summary>
        /// Directory pane.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DirectoryPane,
        /// <summary>
        /// Drawing area.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DrawingArea,
        /// <summary>
        /// File chooser.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FileChooser,
        /// <summary>
        /// Filler.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Filler,
        /// <summary>
        /// Focus traversable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FocusTraversable,
        /// <summary>
        /// Font chooser.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FontChooser,
        /// <summary>
        /// Frame.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Frame,
        /// <summary>
        /// Glass pane.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        GlassPane,
        /// <summary>
        /// Html container.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        HtmlContainer,
        /// <summary>
        /// Icon.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Icon,
        /// <summary>
        /// Image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Image,
        /// <summary>
        /// Internal frame.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        InternalFrame,
        /// <summary>
        /// Label.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Label,
        /// <summary>
        /// Layered pane.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LayeredPane,
        /// <summary>
        /// List.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        List,
        /// <summary>
        /// List item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ListItem,
        /// <summary>
        /// Menu.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Menu,
        /// <summary>
        /// Menu bar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MenuBar,
        /// <summary>
        /// Menu item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MenuItem,
        /// <summary>
        /// Option pane.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OptionPane,
        /// <summary>
        /// Page tab.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PageTab,
        /// <summary>
        /// Page tab list.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PageTabList,
        /// <summary>
        /// Panel.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Panel,
        /// <summary>
        /// Password text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PasswordText,
        /// <summary>
        /// Popup menu.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PopupMenu,
        /// <summary>
        /// Progress bar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ProgressBar,
        /// <summary>
        /// Push button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PushButton,
        /// <summary>
        /// Radio button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        RadioButton,
        /// <summary>
        /// Radio menu item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        RadioMenuItem,
        /// <summary>
        /// Root pane.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        RootPane,
        /// <summary>
        /// Row header.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        RowHeader,
        /// <summary>
        /// Scrollbar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ScrollBar,
        /// <summary>
        /// Scroll pane.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ScrollPane,
        /// <summary>
        /// Separator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Separator,
        /// <summary>
        /// Slider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Slider,
        /// <summary>
        /// Spin button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SpinButton,
        /// <summary>
        /// Split pane.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SplitPane,
        /// <summary>
        /// Status bar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        StatusBar,
        /// <summary>
        /// Table.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Table,
        /// <summary>
        /// Table cell.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TableCell,
        /// <summary>
        /// Table coulmn header.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TableColumnHeader,
        /// <summary>
        /// Table row header.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TableRowHeader,
        /// <summary>
        /// Tear-off menu  item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TearoffMenuItem,
        /// <summary>
        /// Terminal.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Terminal,
        /// <summary>
        /// Text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Text,
        /// <summary>
        /// Toggle button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ToggleButton,
        /// <summary>
        /// Toolbar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ToolBar,
        /// <summary>
        /// Tooltip.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ToolTip,
        /// <summary>
        /// Tree.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Tree,
        /// <summary>
        /// Tree table.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TreeTable,
        /// <summary>
        /// Unknown.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Unknown,
        /// <summary>
        /// Viewport.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Viewport,
        /// <summary>
        /// Window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Window,
        /// <summary>
        /// Extended.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Extended,
        /// <summary>
        /// Header.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Header,
        /// <summary>
        /// Footer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Footer,
        /// <summary>
        /// Paragraph.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Paragraph,
        /// <summary>
        /// Ruler.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Ruler,
        /// <summary>
        /// Application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Application,
        /// <summary>
        /// Autocomplete.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Autocomplete,
        /// <summary>
        /// Editbar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Editbar,
        /// <summary>
        /// Embedded.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Embedded,
        /// <summary>
        /// Entry.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Entry,
        /// <summary>
        /// Chart.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Chart,
        /// <summary>
        /// Caption.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Caption,
        /// <summary>
        /// Document frame.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DocumentFrame,
        /// <summary>
        /// Heading.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Heading,
        /// <summary>
        /// Page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Page,
        /// <summary>
        /// Section.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Section,
        /// <summary>
        /// Redundant object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        RedundantObject,
        /// <summary>
        /// Form.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Form,
        /// <summary>
        /// Link.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Link,
        /// <summary>
        /// Input method window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        InputMethodWindow,
        /// <summary>
        /// Table row.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TableRow,
        /// <summary>
        /// Tree item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TreeItem,
        /// <summary>
        /// Document spreadsheet.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DocumentSpreadsheet,
        /// <summary>
        /// Document presentation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DocumentPresentation,
        /// <summary>
        /// Document text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DocumentText,
        /// <summary>
        /// Document web.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DocumentWeb,
        /// <summary>
        /// Document email.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DocumentEmail,
        /// <summary>
        /// Comment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Comment,
        /// <summary>
        /// List box.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ListBox,
        /// <summary>
        /// Grouping.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Grouping,
        /// <summary>
        /// Image map.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ImageMap,
        /// <summary>
        /// Notification.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Notification,
        /// <summary>
        /// Information bar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        InfoBar,
        /// <summary>
        /// Level bar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LevelBar,
        /// <summary>
        /// Title bar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TitleBar,
        /// <summary>
        /// Block quotation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        BlockQuote,
        /// <summary>
        /// Audio.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Audio,
        /// <summary>
        /// Video.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Video,
        /// <summary>
        /// Definition.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Definition,
        /// <summary>
        /// Article.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Article,
        /// <summary>
        /// Landmark.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Landmark,
        /// <summary>
        /// Log.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Log,
        /// <summary>
        /// Marquee.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Marquee,
        /// <summary>
        /// Math.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Math,
        /// <summary>
        /// Rating.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Rating,
        /// <summary>
        /// Timer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Timer,
        /// <summary>
        /// Static.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Static,
        /// <summary>
        /// Math fraction.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MathFraction,
        /// <summary>
        /// Math root.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MathRoot,
        /// <summary>
        /// Subscript.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Subscript,
        /// <summary>
        /// Superscript.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Superscript,
        /// <summary>
        /// Max count.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MaxCount
    }

    /// <summary>
    /// Accessibility changed property.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityPropertyChangeEvent
    {
        /// <summary>
        /// Accessibility name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Name,
        /// <summary>
        /// Accessibility description.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Description,
        /// <summary>
        /// Accessibility value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Value,
        /// <summary>
        /// Accessibility role.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Role,
        /// <summary>
        /// Accessibility parent.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Parent
    }

    /// <summary>
    /// Accessibility text boundary is used in text controls.
    /// </summary>
    /// <seealso cref="View.AccessibilityGetTextAtOffset" />
    /// <remarks>
    /// Currently, only AccessibilityTextBoundary.Character is supported.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityTextBoundary
    {
        /// <summary>
        /// One character is acquired.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Character,
        /// <summary>
        /// Text word.
        /// </summary>
        /// <remarks>
        /// Not supported yet.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Word,
        /// <summary>
        /// Text sentence.
        /// </summary>
        /// <remarks>
        /// Not supported yet.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Sentence,
        /// <summary>
        /// Text Line.
        /// </summary>
        /// <remarks>
        /// Not supported yet.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Line,
        /// <summary>
        /// Text paragraph.
        /// </summary>
        /// <remarks>
        /// Not supported yet.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Paragraph,
    }
}
