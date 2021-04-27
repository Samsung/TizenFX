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
    public enum AccessibilityState
    {
        Invalid = 0,
        Active,
        Armed,
        Busy,
        Checked,
        Collapsed,
        Defunct,
        Editable,
        Enabled,
        Expandable,
        Expanded,
        Focusable,
        Focused,
        HasTooltip,
        Horizontal,
        Iconified,
        Modal,
        MultiLine,
        MultiSelectable,
        Opaque,
        Pressed,
        Resizeable,
        Selectable,
        Selected,
        Sensitive,
        Showing,
        SingleLine,
        Stale,
        Transient,
        Vertical,
        Visible,
        ManagesDescendants,
        Indeterminate,
        Required,
        Truncated,
        Animated,
        InvalidEntry,
        SupportsAutocompletion,
        SelectableText,
        IsDefault,
        Visited,
        Checkable,
        HasPopup,
        ReadOnly,
        Highlighted,
        Highlightable,
        MaxCount,
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
