/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace ElmSharp
{
    [Flags]
    public enum DisplayRotation
    {
        Degree_0 = 1,
        Degree_90 = 2,
        Degree_180 = 4,
        Degree_270 = 8
    };

    /// <summary>
    /// Enum indicator opacity
    /// </summary>
    public enum StatusBarMode
    {
        /// <summary>
        /// Opacifies the status bar
        /// </summary>
        Opaque = 1,

        /// <summary>
        /// Be translucent the status bar
        /// </summary>
        /// <remarks>
        /// Not supported.
        /// </remarks>
        Translucent = 2,

        /// <summary>
        /// Transparentizes the status bar
        /// </summary>
        Transparent = 3,
    }

    /// <summary>
    /// The Window is container that contain the graphical user interface of a program.
    /// </summary>
    public class Window : Widget
    {
        SmartEvent _deleteRequest;
        SmartEvent _rotationChanged;
        HashSet<EvasObject> _referenceHolder = new HashSet<EvasObject>();

        /// <summary>
        /// Creates and initializes a new instance of the Window class.
        /// </summary>
        /// <param name="name">Window name.</param>
        public Window(string name) : this(null, name)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the Window class.
        /// </summary>
        /// <param name="parent">
        /// Parent widget which this widow created on.
        /// </param>
        /// <param name="name">
        /// Window name.
        /// </param>
        /// <remarks>
        /// Window constructor.show window indicator,set callback
        /// When closing the window in any way outside the program control,
        /// and set callback when window rotation changed.
        /// </remarks>
        public Window(Window parent, string name)
        {
            Name = name;
            Realize(parent);
            Interop.Elementary.elm_win_indicator_mode_set(Handle, 2 /* ELM_WIN_INDICATOR_SHOW */);

            _deleteRequest = new SmartEvent(this, "delete,request");
            _rotationChanged = new SmartEvent(this, "wm,rotation,changed");
            _deleteRequest.On += (s, e) => CloseRequested?.Invoke(this, EventArgs.Empty);
            _rotationChanged.On += (s, e) => RotationChanged?.Invoke(this, EventArgs.Empty);
        }

        protected Window()
        {
        }

        /// <summary>
        /// CloseRequested will be triggered when Window close.
        /// </summary>
        public event EventHandler CloseRequested;

        /// <summary>
        /// RotationChanged will be triggered when Window do rotation.
        /// </summary>
        public event EventHandler RotationChanged;

        /// <summary>
        /// Sets or gets Window name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets Window size with Size value(w,h)
        /// </summary>
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
        /// Gets the screen dpi for the screen that a Window is on.
        /// </summary>
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
        /// Gets the rotation of the Window.The rotation of the window in degrees (0-360).
        /// </summary>
        public int Rotation
        {
            get
            {
                return Interop.Elementary.elm_win_rotation_get(Handle);
            }
        }

        /// <summary>
        /// Sets or gets value whether rotation is supported.
        /// </summary>
        public bool IsRotationSupported
        {
            get
            {
                return Interop.Elementary.elm_win_wm_rotation_supported_get(Handle);
            }
        }

        [Obsolete("Sorry, it's error typo of AvailableRotations, please use AvailableRotations")]
        public DisplayRotation AavailableRotations { get; set; }


        /// <summary>
        /// Sets or gets available rotation degree.
        /// </summary>
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
        /// Sets or gets whether auto deletion function is enable.
        /// </summary>
        /// <remarks>
        /// If you enable auto deletion, the window is automatically destroyed after the signal is emitted.
        /// If auto deletion is disabled, the window is not destroyed and the program has to handle it.
        /// </remarks>
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
        /// This function sends a request to the Windows Manager to activate the Window.
        /// If honored by the WM, the window receives the keyboard focus.
        /// </summary>
        /// <remarks>
        /// This is just a request that a Window Manager may ignore, so calling this function does not ensure
        /// in any way that the window is going to be the active one after it.
        /// </remarks>
        public void Active()
        {
            Interop.Elementary.elm_win_activate(Handle);
        }

        /// <summary>
        /// Adds obj as a resize object of the Window.
        /// </summary>
        /// <remarks>
        /// Setting an object as a resize object of the window means that the obj child's size and
        /// position is controlled by the window directly. That is, the obj is resized to match the window size
        /// and should never be moved or resized manually by the developer.In addition,
        /// resize objects of the window control the minimum size of it as well as whether it can or cannot be resized by the user.
        /// </remarks>
        /// <param name="obj">
        /// Resize object.
        /// </param>
        public void AddResizeObject(EvasObject obj)
        {
            Interop.Elementary.elm_win_resize_object_add(Handle, obj);
        }


        public void KeyGrabEx(string keyname)
        {
            Interop.Elementary.eext_win_keygrab_set(RealHandle, keyname);
        }

        public void KeyUngrabEx(string keyname)
        {
            Interop.Elementary.eext_win_keygrab_unset(RealHandle, keyname);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            Interop.Elementary.elm_config_accel_preference_set("3d");
            return Interop.Elementary.elm_win_add(parent != null ? parent.Handle : IntPtr.Zero, Name, 1);
        }

        internal void AddChild(EvasObject obj)
        {
            _referenceHolder.Add(obj);
        }

        internal void RemoveChild(EvasObject obj)
        {
            _referenceHolder.Remove(obj);
        }

        /// </return>
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

    }
}
