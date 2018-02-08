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
using Native = Interop.CameraDisplay;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The CameraDisplay class allows you to manage display for the camera.
    /// It allows to set and get various display properties, such as
    /// rotation, display visibility, and display mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CameraDisplaySettings
    {
        internal readonly Camera _camera;

        internal CameraDisplaySettings(Camera camera)
        {
            _camera = camera;
        }

        /// <summary>
        /// The display mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// This property is meaningful only in overlay or EVAS surface display type.
        /// </remarks>
        /// <value>A <see cref="CameraDisplayMode"/> that specifies the display mode.</value>
        /// <exception cref="InvalidOperationException">Display type is incorrect.</exception>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed of.</exception>
        public CameraDisplayMode Mode
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetMode(_camera.GetHandle(), out var val),
                    "Failed to get camera display mode");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraDisplayMode), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetMode(_camera.GetHandle(), value),
                    "Failed to set camera display mode.");
            }
        }

        /// <summary>
        /// The display visibility.
        /// </summary>
        /// <value>true if camera display is visible, otherwise false.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// This property is meaningful only in overlay or EVAS surface display type.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Display type is incorrect.</exception>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed of.</exception>
        public bool Visible
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetVisible(_camera.GetHandle(), out bool val),
                    "Failed to get visible value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetVisible(_camera.GetHandle(), value),
                    "Failed to set display visible.");
            }
        }

        /// <summary>
        /// The display rotation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// This property is meaningful only in overlay or EVAS surface display type.
        /// </remarks>
        /// <value>A <see cref="Rotation"/> that specifies the rotation of the camera device.</value>
        /// <exception cref="InvalidOperationException">Display type is incorrect.</exception>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed of.</exception>
        public Rotation Rotation
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetRotation(_camera.GetHandle(), out var val),
                    "Failed to get display rotation");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(Rotation), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetRotation(_camera.GetHandle(), value),
                    "Failed to set display rotation.");
            }
        }

        /// <summary>
        /// The display flip.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// This property is meaningful only in overlay or EVAS surface display type.
        /// </remarks>
        /// <value>A <see cref="Flips"/> that specifies the camera flip type.</value>
        /// <exception cref="InvalidOperationException">Display type is incorrect.</exception>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed of.</exception>
        public Flips Flip
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetFlip(_camera.GetHandle(), out var val),
                    "Failed to get display flip");

                return val;
            }

            set
            {
                ValidationUtil.ValidateFlagsEnum(value, Flips.Horizontal | Flips.Vertical, nameof(Flips));

                CameraErrorFactory.ThrowIfError(Native.SetFlip(_camera.GetHandle(), value),
                    "Failed to set display flip.");
            }
        }

        /// <summary>
        /// the ROI(Region Of Interest) area of display.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// This property is meaningful only in overlay or EVAS surface display type.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Display type is incorrect.</exception>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed of.</exception>
        public Rectangle RoiArea
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetRoiArea(_camera.GetHandle(),
                    out int x, out int y, out int width, out int height), "Failed to get display roi area");

                return new Rectangle(x, y, width, height);
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetRoiArea(_camera.GetHandle(),
                    value.X, value.Y, value.Width, value.Height), "Failed to set display roi area.");
            }
        }
    }
}
