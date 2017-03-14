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

    public class Window : Widget
    {
        SmartEvent _deleteRequest;
        SmartEvent _rotationChanged;
        HashSet<EvasObject> _referenceHolder = new HashSet<EvasObject>();

        public Window(string name) : this(null, name)
        {
        }

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

        public event EventHandler CloseRequested;
        public event EventHandler RotationChanged;

        public string Name { get; set; }

        public Size ScreenSize
        {
            get
            {
                int x, y, w, h;
                Interop.Elementary.elm_win_screen_size_get(Handle, out x, out y, out w, out h);
                return new Size(w, h);
            }
        }

        public Point ScreenDpi
        {
            get
            {
                Point point = default(Point);
                Interop.Elementary.elm_win_screen_dpi_get(Handle, out point.X, out point.Y);
                return point;
            }
        }

        public int Rotation
        {
            get
            {
                return Interop.Elementary.elm_win_rotation_get(Handle);
            }
        }

        public bool IsRotationSupported
        {
            get
            {
                return Interop.Elementary.elm_win_wm_rotation_supported_get(Handle);
            }
        }

        [Obsolete("Sorry, it's error typo of AvailableRotations, please use AvailableRotations")]
        public DisplayRotation AavailableRotations { get; set; }

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

        public void Active()
        {
            Interop.Elementary.elm_win_activate(Handle);
        }

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
            return Interop.Elementary.elm_win_add(parent != null ? parent.Handle : IntPtr.Zero, Name, 0);
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

    }
}
