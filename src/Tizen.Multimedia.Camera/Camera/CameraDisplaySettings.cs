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

using Native = Interop.CameraDisplay;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The CameraDisplay class allows you to manage display for the camera.
    /// It allows to set and get various display properties such as
    /// rotation, display visibility and display mode.
    /// </summary>
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
        /// <value>A <see cref="CameraDisplayMode"/> that specifies the display mode.</value>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed.</exception>
        public CameraDisplayMode Mode
        {
            get
            {
                CameraDisplayMode val = CameraDisplayMode.LetterBox;

                CameraErrorFactory.ThrowIfError(Native.GetMode(_camera.GetHandle(), out val),
                    "Failed to get camera display mode");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetMode(_camera.GetHandle(), value),
                    "Failed to set camera display mode.");
            }
        }

        /// <summary>
        /// The display visibility.
        /// True if camera display visible, otherwise false.
        /// </summary>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed.</exception>
        public bool Visible
        {
            get
            {
                bool val = false;

                CameraErrorFactory.ThrowIfError(Native.GetVisible(_camera.GetHandle(), out val),
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
        /// <value>A <see cref="CameraRotation"/> that specifies the rotation of camera device.</value>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed.</exception>
        public CameraRotation Rotation
        {
            get
            {
                CameraRotation val = CameraRotation.None;

                CameraErrorFactory.ThrowIfError(Native.GetRotation(_camera.GetHandle(), out val),
                    "Failed to get display rotation");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetRotation(_camera.GetHandle(), value),
                    "Failed to set display rotation.");
            }
        }

        /// <summary>
        /// The display flip.
        /// </summary>
        /// <value>A <see cref="CameraFlip"/> that specifies camera flip type.</value>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed.</exception>
        public CameraFlip Flip
        {
            get
            {
                CameraFlip val = CameraFlip.None;

                CameraErrorFactory.ThrowIfError(Native.GetFlip(_camera.GetHandle(), out val),
                    "Failed to get display flip");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetFlip(_camera.GetHandle(), value),
                    "Failed to set display flip.");
            }
        }

        /// <summary>
        /// the ROI(Region Of Interest) area of display.
        /// </summary>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed.</exception>
        public Rectangle RoiArea
        {
            get
            {
                int x = 0;
                int y = 0;
                int width = 0;
                int height = 0;

                CameraErrorFactory.ThrowIfError(Native.GetRoiArea(_camera.GetHandle(), out x, out y, out width, out height),
                    "Failed to get display roi area");

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

