/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for the display rotation of window.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Flags]
    public enum DisplayRotation
    {
        /// <summary>
        /// Rotation value of the window is 0 degree.
        /// </summary>
        Degree_0 = 1,

        /// <summary>
        /// Rotation value of the window is 90 degrees.
        /// </summary>
        Degree_90 = 2,

        /// <summary>
        /// Rotation value of the window is 180 degrees.
        /// </summary>
        Degree_180 = 4,

        /// <summary>
        /// Rotation value of the window is 270 degrees.
        /// </summary>
        Degree_270 = 8
    };

    /// <summary>
    /// Enumeration for the indicator opacity.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum StatusBarMode
    {
        /// <summary>
        /// Opacifies the status bar.
        /// </summary>
        Opaque = 1,

        /// <summary>
        /// Be translucent the status bar.
        /// </summary>
        /// <remarks>
        /// Not supported.
        /// </remarks>
        Translucent = 2,

        /// <summary>
        /// Transparentizes the status bar.
        /// </summary>
        Transparent = 3,
    }

    /// <summary>
    /// Enumeration for the keygrab modes of the window.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum KeyGrabMode
    {
        /// <summary>
        /// Unknown keygrab mode.
        /// </summary>
        Shared = 256,

        /// <summary>
        /// Getting the grabbed-key together with the other client windows.
        /// </summary>
        Topmost = 512,

        /// <summary>
        /// Getting the grabbed-key only when the window is top of the stack.
        /// </summary>
        Exclusive = 1024,

        /// <summary>
        /// Getting the grabbed-key exclusively regardless of the window's position.
        /// </summary>
        OverrideExclusive = 2048,
    }

    /// <summary>
    /// Enumeration for the indicator mode.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum IndicatorMode
    {
        /// <summary>
        /// Unknown indicator state.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Hides the indicator.
        /// </summary>
        Hide,

        /// <summary>
        /// Shows the indicator.
        /// </summary>
        Show,
    };

    /// <summary>
    /// Enumeration for the keyboard mode.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum KeyboardMode
    {
        /// <summary>
        /// Unknown keyboard state.
        /// </summary>
        Unknown,

        /// <summary>
        /// Request to deactivate the keyboard.
        /// </summary>
        Off,

        /// <summary>
        /// Enable keyboard with default layout.
        /// </summary>
        On,

        /// <summary>
        /// Alpha (a-z) keyboard layout.
        /// </summary>
        Alpha,

        /// <summary>
        /// Numeric keyboard layout.
        /// </summary>
        Numeric,

        /// <summary>
        /// Pin keyboard layout.
        /// </summary>
        Pin,

        /// <summary>
        /// Phone keyboard layout.
        /// </summary>
        PhoneNumber,

        /// <summary>
        /// Hexadecimal numeric keyboard layout.
        /// </summary>
        Hex,

        /// <summary>
        /// Full (QWERTY) keyboard layout.
        /// </summary>
        QWERTY,

        /// <summary>
        /// Password keyboard layout.
        /// </summary>
        Password,

        /// <summary>
        /// IP keyboard layout.
        /// </summary>
        IP,

        /// <summary>
        /// Host keyboard layout.
        /// </summary>
        Host,

        /// <summary>
        /// File keyboard layout.
        /// </summary>
        File,

        /// <summary>
        /// URL keyboard layout.
        /// </summary>
        URL,

        /// <summary>
        /// Keypad layout.
        /// </summary>
        Keypad,

        /// <summary>
        /// J2ME keyboard layout.
        /// </summary>
        J2ME,
    };

    /// <summary>
    /// Enumeration for the window type.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum WindowType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// A normal window. Indicates a normal, top-level window. Almost every window will be created with this type.
        /// </summary>
        Basic,

        /// <summary>
        /// Used for simple dialog windows.
        /// </summary>
        Dialog,

        /// <summary>
        /// For special desktop windows, like a background window holding desktop icons.
        /// </summary>
        Desktop,

        /// <summary>
        /// The window is used as a dock or panel. Usually would be kept on top of any other window by the Window Manager.
        /// </summary>
        Dock,

        /// <summary>
        /// The window is used to hold a floating toolbar, or similar.
        /// </summary>
        Toolbar,

        /// <summary>
        /// Similar to Toolbar.
        /// </summary>
        Menu,

        /// <summary>
        /// A persistent utility window, like a toolbox or palette.
        /// </summary>
        Utility,

        /// <summary>
        /// Splash window for a starting up application.
        /// </summary>
        Splash,

        /// <summary>
        /// The window is a dropdown menu, as when an entry in a menubar is clicked.
        /// </summary>
        DropdownMenu,

        /// <summary>
        /// Like DropdownMenu, but for the menu triggered by right-clicking an object.
        /// </summary>
        PopupMenu,

        /// <summary>
        /// The window is a tooltip. A short piece of explanatory text that typically appears after the mouse cursor hovers over an object for a while.
        /// </summary>
        Tooltip,

        /// <summary>
        /// A notification window, like a warning about battery life or a new e-mail received.
        /// </summary>
        Notification,

        /// <summary>
        /// A window holding the contents of a combo box.
        /// </summary>
        Combo,

        /// <summary>
        /// Used to indicate the window as a representation of an object being dragged across different windows, or even applications.
        /// </summary>
        DragAndDrop,

        /// <summary>
        /// The window is rendered onto an image buffer. No actual window is created for this type, instead the window and all of its contents will be rendered to an image buffer.
        /// This allows to have children windows inside a parent one just like any other object would be, and do other things like applying Evas_Map effects to it.
        /// </summary>
        InlinedImage,

        /// <summary>
        /// The window is rendered onto an image buffer and can be shown other process's plug image object.
        /// No actual window is created for this type, instead the window and all of its contents will be rendered to an image buffer and can be shown other process's plug image object.
        /// </summary>
        SocketImage,

        /// <summary>
        /// This window was created using a pre-existing canvas. The window widget can be deleted, but the canvas must be managed externally.
        /// </summary>
        Fake,
    };

    /// <summary>
    /// Enumeration of notification window's priority level.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum NotificationLevel
    {
        /// <summary>
        /// No (reset) notification level. This value makes the window place in normal layer.
        /// </summary>
        None = -1,

        /// <summary>
        /// Default notification level.
        /// </summary>
        Default = 10,

        /// <summary>
        /// Higher notification level than default.
        /// </summary>
        Medium = 20,

        /// <summary>
        /// Higher notification level than medium.
        /// </summary>
        High = 30,

        /// <summary>
        /// The highest notification level.
        /// </summary>
        Top = 40,
    };

    /// <summary>
    /// Enumeration of screen mode.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ScreenMode
    {
        /// <summary>
        /// The mode which turns the screen off after a timeout.
        /// </summary>
        Default,

        /// <summary>
        /// The mode which keeps the screen turned on.
        /// </summary>
        AlwaysOn,
    }

    /// <summary>
    /// The Window is a container that contains the graphical user interface of a program.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Window : Widget
    {
        SmartEvent _deleteRequest;
        SmartEvent _rotationChanged;
        HashSet<EvasObject> _referenceHolder = new HashSet<EvasObject>();

        /// <summary>
        /// Creates and initializes a new instance of the Window class.
        /// </summary>
        /// <param name="name">Window name.</param>
        /// <since_tizen> preview </since_tizen>
        public Window(string name) : this(null, name)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the Window class.
        /// </summary>
        /// <param name="parent">
        /// Parent widget which this window is created on.
        /// </param>
        /// <param name="name">
        /// Window name.
        /// </param>
        /// <remarks>
        /// Window constructor.show window indicator, set callback
        /// when closing the window in any way outside the program control,
        /// and set callback when window rotation is changed.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public Window(Window parent, string name) : this(parent, name, WindowType.Basic)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the Window class.
        /// </summary>
        /// <param name="parent">
        /// Parent widget which this window is created on.
        /// </param>
        /// <param name="name">
        /// Window name.
        /// </param>
        /// <param name="type">
        /// Window type.
        /// </param>
        /// <remarks>
        /// Window constructor.show window indicator, set callback
        /// when closing the window in any way outside the program control,
        /// and set callback when window rotation is changed.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public Window(Window parent, string name, WindowType type)
        {
            Name = name;
            Type = type;
            Realize(parent);
            IndicatorMode = IndicatorMode.Show;

            _deleteRequest = new SmartEvent(this, "delete,request");
            _rotationChanged = new SmartEvent(this, "wm,rotation,changed");
            _deleteRequest.On += (s, e) => CloseRequested?.Invoke(this, EventArgs.Empty);
            _rotationChanged.On += (s, e) => RotationChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Creates and initializes a new instance of the Window class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected Window()
        {
        }

        /// <summary>
        /// CloseRequested will be triggered when window is closed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler CloseRequested;

        /// <summary>
        /// RotationChanged will be triggered when window is rotated.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler RotationChanged;

        /// <summary>
        /// Sets or gets the window name.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Name { get; set; }

        /// <summary>
        /// Gets the window type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public WindowType Type { get; } = WindowType.Basic;

        /// <summary>
        /// Gets the window size with Size value(w,h)
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size ScreenSize
        {
            get
            {
                int x, y, w, h;
                Interop.Elementary.elm_win_screen_size_get(Handle, out x, out y, out w, out h);
                return new Size(w, h);
            }
        }

        /// <summary>
        /// Gets the screen dpi for the screen that the window is on.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Point ScreenDpi
        {
            get
            {
                Point point = default(Point);
                Interop.Elementary.elm_win_screen_dpi_get(Handle, out point.X, out point.Y);
                return point;
            }
        }

        /// <summary>
        /// Gets the rotation of the window. The rotation of the window in degrees (0-360).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Rotation
        {
            get
            {
                return Interop.Elementary.elm_win_rotation_get(Handle);
            }
        }

        /// <summary>
        /// Gets whether the window manager supports window rotation or not.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsRotationSupported
        {
            get
            {
                return Interop.Elementary.elm_win_wm_rotation_supported_get(Handle);
            }
        }

        /// <summary>
        /// Sets or gets the available rotation degree.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("Sorry, it's error typo of AvailableRotations, please use AvailableRotations")]
        public DisplayRotation AavailableRotations { get; set; }

        /// <summary>
        /// Sets or gets the available rotation degree.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public DisplayRotation AvailableRotations
        {
            get
            {
                int[] rotations;
                Interop.Elementary.elm_win_wm_rotation_available_rotations_get(Handle, out rotations);
                if (rotations == null)
                {
                    return 0;
                }
                return ConvertToDisplayRotation(rotations);
            }
            set
            {
                Interop.Elementary.elm_win_wm_rotation_available_rotations_set(Handle, ConvertDegreeArray(value));
            }
        }

        /// <summary>
        /// Sets or gets whether the auto deletion function is enabled.
        /// </summary>
        /// <remarks>
        /// If you enable auto deletion, the window is automatically destroyed after the signal is emitted.
        /// If auto deletion is disabled, the window is not destroyed and the program has to handle it.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool AutoDeletion
        {
            get
            {
                return Interop.Elementary.elm_win_autodel_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_win_autodel_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the alpha channel state of the window.
        /// </summary>
        /// <remarks>
        /// true if the window alpha channel is enabled, false otherwise.
        /// If alpha is true, the alpha channel of the canvas will be enabled possibly making parts of the window completely or partially transparent.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool Alpha
        {
            get
            {
                return Interop.Elementary.elm_win_alpha_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_win_alpha_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the role of the window.
        /// </summary>
        /// <remarks>
        /// The Role will be invalid if a new role is set or if the window is destroyed.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public string Role
        {
            get
            {
                return Interop.Elementary.elm_win_role_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_win_role_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the mode of the status bar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public StatusBarMode StatusBarMode
        {
            get
            {
                return (StatusBarMode)Interop.Elementary.elm_win_indicator_opacity_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_win_indicator_opacity_set(Handle, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets the iconified state of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Iconified
        {
            get
            {
                return Interop.Elementary.elm_win_iconified_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_iconified_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the window's indicator mode.
        /// </summary>
        /// <value>The indicator mode.</value>
        /// <since_tizen> preview </since_tizen>
        public IndicatorMode IndicatorMode
        {
            get
            {
                return Interop.Elementary.elm_win_indicator_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_indicator_mode_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the aspect ratio of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Aspect
        {
            get
            {
                return Interop.Elementary.elm_win_aspect_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_aspect_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Window's autohide state.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool AutoHide
        {
            get
            {
                return Interop.Elementary.elm_win_autohide_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_autohide_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets the borderless state of the window.
        /// This function requests the Window Manager to not draw any decoration around the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool Borderless
        {
            get
            {
                return Interop.Elementary.elm_win_borderless_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_borderless_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the demand attention state of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool DemandAttention
        {
            get
            {
                return Interop.Elementary.elm_win_demand_attention_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_demand_attention_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the floating mode of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool FloatingMode
        {
            get
            {
                return Interop.Elementary.elm_win_floating_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_floating_mode_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the animate status for the focus highlight for this window.
        /// This function will enable or disable the animation of focus highlight only for the given window, regardless of the global setting for it.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool FocusHighlightAnimation
        {
            get
            {
                return Interop.Elementary.elm_win_focus_highlight_animate_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_focus_highlight_animate_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the enabled status for the focus highlight in the window.
        /// This function will enable or disable the focus highlight only for the given window, regardless of the global setting for it.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool FocusHighlightEnabled
        {
            get
            {
                return Interop.Elementary.elm_win_focus_highlight_enabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_focus_highlight_enabled_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the style for the focus highlight on this window.
        /// Sets the style to use for theming the highlight of focused objects on the given window. If style is NULL, the default will be used.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string FocusHighlightStyle
        {
            get
            {
                return Interop.Elementary.elm_win_focus_highlight_style_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_focus_highlight_style_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets the keyboard mode of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public KeyboardMode KeyboardMode
        {
            get
            {
                return (KeyboardMode)Interop.Elementary.elm_win_keyboard_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_keyboard_mode_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the layer of the window.
        /// What this means exactly will depend on the underlying engine used.
        /// In the case of X11 backed engines, the value in layer has the following meanings:
        /// less than 3 means that the window will be placed below all others,
        /// more than 5 means that the window will be placed above all others,
        /// and anything else means that the window will be placed in the default layer.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override int Layer
        {
            get
            {
                return Interop.Elementary.elm_win_layer_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_layer_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the modal state of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool Modal
        {
            get
            {
                return Interop.Elementary.elm_win_modal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_modal_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the noblank property of the window.
        /// This is a way to request the display on which the window is shown is not blank, screensave, or otherwise hidden or obscure. It is intended for use such as media playback on a television where a user may not want to be interrupted by an idle screen.
        /// The noblank property may have no effect if the window is iconified/minimized or hidden.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool NoBlank
        {
            get
            {
                return Interop.Elementary.elm_win_noblank_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_noblank_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets the profile of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Profile
        {
            get
            {
                return Interop.Elementary.elm_win_profile_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_profile_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets the constraints on the maximum width and height of the window relative to the width and height of its screen.
        /// When this function returns true, object will never resize larger than the screen.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool ScreenConstrain
        {
            get
            {
                return Interop.Elementary.elm_win_screen_constrain_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_win_screen_constrain_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the base size of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size BaseSize
        {
            get
            {
                int w, h;
                Interop.Elementary.elm_win_size_base_get(RealHandle, out w, out h);
                return new Size(w, h);
            }
            set
            {
                Interop.Elementary.elm_win_size_base_set(RealHandle, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Gets or sets the step size of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size StepSize
        {
            get
            {
                int w, h;
                Interop.Elementary.elm_win_size_step_get(RealHandle, out w, out h);
                return new Size(w, h);
            }
            set
            {
                Interop.Elementary.elm_win_size_step_set(RealHandle, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Gets the screen position X of a window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int ScreenPositionX
        {
            get
            {
                int x, y;
                Interop.Elementary.elm_win_screen_position_get(Handle, out x, out y);
                return x;
            }
        }

        /// <summary>
        /// Gets the screen position Y of a window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int ScreenPositionY
        {
            get
            {
                int x, y;
                Interop.Elementary.elm_win_screen_position_get(Handle, out x, out y);
                return y;
            }
        }

        /// <summary>
        /// Gets or sets the title of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Title
        {
            get
            {
                return Interop.Elementary.elm_win_title_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_win_title_set(Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the urgent state of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool Urgent
        {
            get
            {
                return Interop.Elementary.elm_win_urgent_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_win_urgent_set(Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the withdrawn state of the window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool Withdrawn
        {
            get
            {
                return Interop.Elementary.elm_win_withdrawn_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_win_withdrawn_set(Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the priority level for the specified notification window.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/window.priority.set
        /// </privilege>
        /// /// <remarks>
        /// This can be used for a notification type window only.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public NotificationLevel NotificationLevel
        {
            get
            {
                int level;
                Interop.Eutil.efl_util_get_notification_window_level(Handle, out level);
                return (NotificationLevel)level;
            }
            set
            {
                Interop.Eutil.efl_util_set_notification_window_level(Handle, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the window's screen mode.
        /// This API is useful when the application need to keep the display turned on.
        /// If the application set the mode to ScreenMode.AlwaysOn to its window and the window is shown wholly or partially,
        /// the window manager requests the display system to keep the display on as long as the window is shown.
        /// If the window is no longer shown, then the window manger request the display system to go back to normal operation.
        /// Default screen mode of window is ScreenMode.Default.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/display
        /// </privilege>
        /// <remarks>
        /// This needs the privilege. If the application which is not get the privilege use this API, the window manager generates the permission deny error.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public ScreenMode ScreenMode
        {
            get
            {
                int mode;
                Interop.Eutil.efl_util_get_window_screen_mode(Handle, out mode);
                return (ScreenMode)mode;
            }
            set
            {
                Interop.Eutil.efl_util_set_window_screen_mode(Handle, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the user's preferred brightness of the specified window.
        /// This is useful when the application need to change the brightness of the screen when it is appeared on the screen.
        /// If the application sets the brightness 0 to 100 to its window and the application window is shown wholly or partially,
        /// the window manager requests the display system to change the brightness of the screen using user's preferred brightness.
        /// If the window is no longer shown, then the window manger request the display system to go back to default brightness.
        /// If the brightness is less than 0, this means to use the default screen brightness.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/display
        /// </privilege>
        /// <remarks>
        /// This needs the privilege. If the application which is not get the privilege use this API, the window manager generates the permission deny error.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public int Brightness
        {
            get
            {
                int brightness;
                Interop.Eutil.efl_util_get_window_brightness(Handle, out brightness);
                return brightness;
            }
            set
            {
                Interop.Eutil.efl_util_set_window_brightness(Handle, value);
            }
        }

        internal static bool IsPreloaded { get; private set; }

        /// <summary>
        /// Creates a socket to provide the service for the Plug widget.
        /// </summary>
        /// <param name="name">A service name.</param>
        /// <param name="number">A number (any value, 0 being the common default) to differentiate multiple instances of services with the same name.</param>
        /// <param name="systemWide">A boolean that if true, specifies to create a system-wide service all users can connect to, otherwise the service is private to the user ID that created the service.</param>
        /// <returns>If true creates successful, otherwise false.</returns>
        /// <since_tizen> preview </since_tizen>
        public bool CreateServiceSocket(string name, int number, bool systemWide)
        {
            return Interop.Elementary.elm_win_socket_listen(RealHandle, name, number, systemWide);
        }

        /// <summary>
        /// Sets the rotation of the window.
        /// </summary>
        /// <param name="degree">The rotation of the window, in degrees (0-360), counter-clockwise.</param>
        /// <param name="resize">Resizes the window's contents so that they fit inside the current window geometry.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetRotation(int degree, bool resize)
        {
            if (resize)
                Interop.Elementary.elm_win_rotation_with_resize_set(RealHandle, degree);
            else
                Interop.Elementary.elm_win_rotation_set(RealHandle, degree);
        }

        /// <summary>
        /// Sets the alpha window's visual state to opaque state.
        /// This sets the alpha window's visual state to opaque state.
        /// If the alpha window sets the visual state to the opaque,
        /// then the window manager could handle it as the opaque window while calculating visibility.
        /// This will have no effect when used by a non-alpha window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void SetOpaqueState()
        {
            Interop.Eutil.efl_util_set_window_opaque_state(RealHandle, 1);
        }

        /// <summary>
        /// Unsets the alpha window's visual state to opaque state.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void UnsetOpaqueState()
        {
            Interop.Eutil.efl_util_set_window_opaque_state(RealHandle, 0);
        }

        /// <summary>
        /// Sets the window to be skipped by focus.
        /// This sets the window to be skipped by normal input.
        /// This means the Windows Manager will be asked to not focus this window as well as omit it from things like the taskbar, pager etc.
        /// Call this and enable it on the window BEFORE you show it for the first time, otherwise it may have no effect.
        /// Use this for windows that have only output information or might only be interacted with by the mouse or fingers, and never for typing input.
        /// Be careful that this may have side-effects like making the window non-accessible in some cases unless the window is specially handled. Use this with care.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void FocusSkip(bool skip)
        {
            Interop.Elementary.elm_win_prop_focus_skip_set(Handle, skip);
        }

        /// <summary>
        /// Pulls up the window object.
        /// Places the window pointed by object at the top of the stack, so that it's not covered by any other window.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void PullUp()
        {
            Interop.Elementary.elm_win_raise(Handle);
        }

        /// <summary>
        /// Brings down the window object.
        /// Places the window pointed by object at the bottom of the stack, so that no other window is covered by it.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void BringDown()
        {
            Interop.Elementary.elm_win_lower(Handle);
        }

        /// <summary>
        /// This function sends a request to the Windows Manager to activate the window.
        /// If honored by the Windows Manager, the window receives the keyboard focus.
        /// </summary>
        /// <remarks>
        /// This is just a request that the Windows Manager may ignore, so calling this function does not ensure
        /// in any way that the window is going to be the active one after it.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public void Active()
        {
            Interop.Elementary.elm_win_activate(Handle);
        }

        /// <summary>
        /// Deletes the subobj as a resize object of the window object.
        /// This function removes the object subobj from the resize objects of the window object.
        /// It will not delete the object itself, which will be left unmanaged and should be deleted by the developer, manually handled, or set as child of some other container.
        /// </summary>
        /// <param name="obj">Resize object.</param>
        /// <since_tizen> preview </since_tizen>
        public void DeleteResizeObject(EvasObject obj)
        {
            Interop.Elementary.elm_win_resize_object_del(Handle, obj);
        }

        /// <summary>
        /// Adds an object as a resize object of the window.
        /// </summary>
        /// <remarks>
        /// Setting an object as a resize object of the window means that the object child's size and
        /// position is controlled by the window directly. That is, the object is resized to match the window size
        /// and should never be moved or resized manually by the developer. In addition,
        /// resize objects of the window control the minimum size of it as well as whether it can or cannot be resized by the user.
        /// </remarks>
        /// <param name="obj">
        /// Resize object.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        public void AddResizeObject(EvasObject obj)
        {
            Interop.Elementary.elm_win_resize_object_add(Handle, obj);
        }

        /// <summary>
        /// Sets the keygrab value of the window.
        /// This function grabs the key of the window using grab_mode.
        /// </summary>
        /// <param name="keyname">The keyname to grab.</param>
        /// <param name="mode">According to the grabmode, it can grab key differently.</param>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WinKeyGrab(string keyname, KeyGrabMode mode)
        {
            Interop.Elementary.elm_win_keygrab_set(RealHandle, keyname, 0, 0, 0, mode);
        }

        /// <summary>
        /// Unsets the keygrab value of the window.
        /// This function unsets keygrab value. Ungrab key of the window.
        /// </summary>
        /// <param name="keyname">The keyname to grab.</param>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WinKeyUngrab(string keyname)
        {
            Interop.Elementary.elm_win_keygrab_unset(RealHandle, keyname, 0, 0);
        }

        /// <summary>
        /// Sets the keygrab of the window.
        /// </summary>
        /// <param name="keyname">The keyname string to set keygrab.</param>
        /// <since_tizen> preview </since_tizen>
        public void KeyGrabEx(string keyname)
        {
            Interop.Elementary.eext_win_keygrab_set(RealHandle, keyname);
        }

        /// <summary>
        /// Unsets the keygrab of the window.
        /// </summary>
        /// <param name="keyname">The keyname string to unset keygrab.</param>
        /// <since_tizen> preview </since_tizen>
        public void KeyUngrabEx(string keyname)
        {
            Interop.Elementary.eext_win_keygrab_unset(RealHandle, keyname);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            Interop.Elementary.elm_config_accel_preference_set("3d");
            return Interop.Elementary.elm_win_add(parent != null ? parent.Handle : IntPtr.Zero, Name, (int)Type);
        }

        internal void AddChild(EvasObject obj)
        {
            _referenceHolder.Add(obj);
        }

        internal void RemoveChild(EvasObject obj)
        {
            _referenceHolder.Remove(obj);
        }

        static int[] ConvertDegreeArray(DisplayRotation value)
        {
            List<int> rotations = new List<int>();
            if (value.HasFlag(DisplayRotation.Degree_0))
                rotations.Add(0);
            if (value.HasFlag(DisplayRotation.Degree_90))
                rotations.Add(90);
            if (value.HasFlag(DisplayRotation.Degree_180))
                rotations.Add(180);
            if (value.HasFlag(DisplayRotation.Degree_270))
                rotations.Add(270);
            return rotations.ToArray();
        }

        static DisplayRotation ConvertToDisplayRotation(int[] values)
        {
            int orientation = 0;
            foreach (int v in values)
            {
                orientation |= (1 << (v / 90));
            }
            return (DisplayRotation)orientation;
        }

        static void Preload()
        {
            Elementary.Initialize();
            Elementary.ThemeOverlay();
            _ = new PreloadedWindow();
            IsPreloaded = true;
        }

        /// <summary>
        /// For internal use only
        /// </summary>
        internal static Window CreateWindow(string name) => PreloadedWindow.GetInstance() ?? new Window(name);
    }
}
