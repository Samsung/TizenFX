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
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Flags]
    public enum AccessibilityReadingInfoTypes : int
    {
        None = 0,
        Name = 1,
        Role = 2,
        Description = 4,
        State = 8
    };

    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityGesture
    {
        OneFingerHover = 0,
        TwoFingerHover,
        ThreeFingerHover,
        OneFingerFlickLeft,
        OneFingerFlickRight,
        OneFingerFlickUp,
        OneFingerFlickDown,
        TwoFingersFlickLeft,
        TwoFingersFlickRight,
        TwoFingersFlickUp,
        TwoFingersFlickDown,
        ThreeFingersFlickLeft,
        ThreeFingersFlickRight,
        ThreeFingersFlickUp,
        ThreeFingersFlickDown,
        OneFingerSingleTap,
        OneFingerDoubleTap,
        OneFingerTripleTap,
        TwoFingersSingleTap,
        TwoFingersDoubleTap,
        TwoFingersTripleTap,
        ThreeFingersSingleTap,
        ThreeFingersDoubleTap,
        ThreeFingersTripleTap,
        OneFingerFlickLeftReturn,
        OneFingerFlickRightReturn,
        OneFingerFlickUpReturn,
        OneFingerFlickDownReturn,
        TwoFingersFlickLeftReturn,
        TwoFingersFlickRightReturn,
        TwoFingersFlickUpReturn,
        TwoFingersFlickDownReturn,
        ThreeFingersFlickLeftReturn,
        ThreeFingersFlickRightReturn,
        ThreeFingersFlickUpReturn,
        ThreeFingersFlickDownReturn,
        OneFingerDoubleTapNHold,
        TwoFingersDoubleTapNHold,
        ThreeFingersDoubleTapNHold,
        MaxCount
    };

    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityGestureState
    {
        Begin = 0,
        Ongoing,
        Ended,
        Aborted
    };


    [EditorBrowsable(EditorBrowsableState.Never)]
    [Flags]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32", Justification = "System.Int32 type wouldn't have sufficient capacity")]
    public enum AccessibilityStates : ulong
    {
        Invalid                = (1UL << 0),
        Active                 = (1UL << 1),
        Armed                  = (1UL << 2),
        Busy                   = (1UL << 3),
        Checked                = (1UL << 4),
        Collapsed              = (1UL << 5),
        Defunct                = (1UL << 6),
        Editable               = (1UL << 7),
        Enabled                = (1UL << 8),
        Expandable             = (1UL << 9),
        Expanded               = (1UL << 10),
        Focusable              = (1UL << 11),
        Focused                = (1UL << 12),
        HasTooltip             = (1UL << 13),
        Horizontal             = (1UL << 14),
        Iconified              = (1UL << 15),
        Modal                  = (1UL << 16),
        MultiLine              = (1UL << 17),
        MultiSelectable        = (1UL << 18),
        Opaque                 = (1UL << 19),
        Pressed                = (1UL << 20),
        Resizeable             = (1UL << 21),
        Selectable             = (1UL << 22),
        Selected               = (1UL << 23),
        Sensitive              = (1UL << 24),
        Showing                = (1UL << 25),
        SingleLine             = (1UL << 26),
        Stale                  = (1UL << 27),
        Transient              = (1UL << 28),
        Vertical               = (1UL << 29),
        Visible                = (1UL << 30),
        ManagesDescendants     = (1UL << 31),
        Indeterminate          = (1UL << 32),
        Required               = (1UL << 33),
        Truncated              = (1UL << 34),
        Animated               = (1UL << 35),
        InvalidEntry           = (1UL << 36),
        SupportsAutocompletion = (1UL << 37),
        SelectableText         = (1UL << 38),
        IsDefault              = (1UL << 39),
        Visited                = (1UL << 40),
        Checkable              = (1UL << 41),
        HasPopup               = (1UL << 42),
        ReadOnly               = (1UL << 43),
        Highlighted            = (1UL << 44),
        Highlightable          = (1UL << 45),
    };

    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum RelationType
        {
            NullOf = 0,
            LabelFor,
            LabelledBy,
            ControllerFor,
            ControlledBy,
            MemberOf,
            TooltipFor,
            NodeChildOf,
            NodeParentOf,
            Extended,
            FlowsTo,
            FlowsFrom,
            SubwindowOf,
            Embeds,
            EmbeddedBy,
            PopupFor,
            ParentWindowOf,
            DescriptionFor,
            DescribedBy,
            Details,
            DetailsFor,
            ErrorMessage,
            ErrorFor,
            MaxCount
        };

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum Role
        {
            Invalid,
            AcceleratorLabel,
            Alert,
            Animation,
            Arrow,
            Calendar,
            Canvas,
            CheckBox,
            CheckMenuItem,
            ColorChooser,
            ColumnHeader,
            ComboBox,
            DateEditor,
            DesktopIcon,
            DesktopFrame,
            Dial,
            Dialog,
            DirectoryPane,
            DrawingArea,
            FileChooser,
            Filler,
            FocusTraversable,
            FontChooser,
            Frame,
            GlassPane,
            HtmlContainer,
            Icon,
            Image,
            InternalFrame,
            Label,
            LayeredPane,
            List,
            ListItem,
            Menu,
            MenuBar,
            MenuItem,
            OptionPane,
            PageTab,
            PageTabList,
            Panel,
            PasswordText,
            PopupMenu,
            ProgressBar,
            PushButton,
            RadioButton,
            RadioMenuItem,
            RootPane,
            RowHeader,
            ScrollBar,
            ScrollPane,
            Separator,
            Slider,
            SpinButton,
            SplitPane,
            StatusBar,
            Table,
            TableCell,
            TableColumnHeader,
            TableRowHeader,
            TearoffMenuItem,
            Terminal,
            Text,
            ToggleButton,
            ToolBar,
            ToolTip,
            Tree,
            TreeTable,
            Unknown,
            Viewport,
            Window,
            Extended,
            Header,
            Footer,
            Paragraph,
            Ruler,
            Application,
            Autocomplete,
            Editbar,
            Embedded,
            Entry,
            Chart,
            Caption,
            DocumentFrame,
            Heading,
            Page,
            Section,
            RedundantObject,
            Form,
            Link,
            InputMethodWindow,
            TableRow,
            TreeItem,
            DocumentSpreadsheet,
            DocumentPresentation,
            DocumentText,
            DocumentWeb,
            DocumentEmail,
            Comment,
            ListBox,
            Grouping,
            ImageMap,
            Notification,
            InfoBar,
            LevelBar,
            TitleBar,
            BlockQuote,
            Audio,
            Video,
            Definition,
            Article,
            Landmark,
            Log,
            Marquee,
            Math,
            Rating,
            Timer,
            Static,
            MathFraction,
            MathRoot,
            Subscript,
            Superscript,
            MaxCount
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ObjectPropertyChangeEvent
        {
            Name,
            Description,
            Value,
            Role,
            Parent
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum TextBoundary
        {
            Character,
            Word,
            Sentence,
            Line,
            Paragraph,
        }
    }
}
