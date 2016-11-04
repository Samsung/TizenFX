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

namespace Tizen.Multimedia
{
    /// <summary>
    /// The CameraDisplay class allows you to manage display for the camera.
    /// It allows to set and get various display properties such as
    /// rotation, display visibility and display mode.
    /// </summary>
    public class CameraDisplay
    {
        internal readonly IntPtr _displayHandle;

        internal CameraDisplay(IntPtr handle)
        {
            _displayHandle = handle;
        }

        /// <summary>
        /// The display rotation.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera.
        /// </privilege>
        public CameraRotation Rotation
        {
            get
            {
                int val = 0;
                int ret = Interop.CameraDisplay.GetDisplayRotation(_displayHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get display rotation " + (CameraError)ret);
                }

                return (CameraRotation)val;
            }

            set
            {
                int ret = Interop.CameraDisplay.SetDisplayRotation(_displayHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set display rotation, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set display rotation.");
                }
            }
        }

        /// <summary>
        /// The display flip.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera.
        /// </privilege>
        public CameraFlip Flip
        {
            get
            {
                int val = 0;
                int ret = Interop.CameraDisplay.GetDisplayFlip(_displayHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get display flip, " + (CameraError)ret);
                }

                return (CameraFlip)val;
            }

            set
            {
                int ret = Interop.CameraDisplay.SetDisplayFlip(_displayHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set display flip, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set display flip.");
                }
            }
        }

        /// <summary>
        /// The display mode.
        /// </summary>
        public CameraDisplayMode Mode
        {
            get
            {
                int val = 0;
                int ret = Interop.CameraDisplay.GetDisplayMode(_displayHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera display mode, " + (CameraError)ret);
                }

                return (CameraDisplayMode)val;
            }

            set
            {
                int ret = Interop.CameraDisplay.SetDisplayMode(_displayHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera display mode, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera display mode.");
                }
            }
        }

        /// <summary>
        /// The display visibility.
        /// True if camera display visible, otherwise false.
        /// </summary>
        public bool Visible
        {
            get
            {
                bool val = false;
                int ret = Interop.CameraDisplay.GetDisplayVisible(_displayHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get visible value, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraDisplay.SetDisplayVisible(_displayHandle, (bool)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set display visible, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set display visible.");
                }
            }
        }
    }
}

