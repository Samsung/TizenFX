/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
 */

using System;
using Tizen.Applications;

namespace Tizen.NUI
{
    /// <summary>
    /// Represents the Frame Data.
    /// </summary>
    internal class FrameData
    {
        private const string logTag = "NUI";
        private readonly IntPtr frame;
        private int fd = -1;
        private uint size = 0;

        internal FrameData(IntPtr frame)
        {
            this.frame = frame;
        }

        /// <summary>
        /// Checks whether the direction of the frame is forward or not.
        /// </summary>
        internal bool DirectionForward
        {
            get
            {
                Interop.FrameBroker.FrameDirection direction = Interop.FrameBroker.FrameDirection.Backward + 1;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetDirection(frame, out direction);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get direction");
                }
                return (direction == Interop.FrameBroker.FrameDirection.Forward);
            }
        }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        internal Bundle Extra
        {
            get
            {
                SafeBundleHandle safeBundle;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetExtraData(frame, out safeBundle);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get extra data");
                    return null;
                }
                return new Bundle(safeBundle);
            }
        }

        /// <summary>
        /// Enumeration for the frame type.
        /// </summary>
        internal enum FrameType
        {
            /// <summary>
            /// The tbm surface of the remote surface.
            /// </summary>
            RemoteSurfaceTbmSurface,

            /// <summary>
            /// The image file of the remote surface.
            /// </summary>
            RemoteSurfaceImageFile,

            /// <summary>
            /// The image of the splash screen.
            /// </summary>
            SplashScreenImage,

            /// <summary>
            /// The edje of the splash screen.
            /// </summary>
            SPlashScreenEdje,
        }

        /// <summary>
        /// Enumeration for the direction of the frame.
        /// </summary>
        internal enum FrameDirection
        {
            /// <summary>
            /// The direction that is from the caller to the other application.
            /// </summary>
            Forward,

            /// <summary>
            /// The direction that is from the other application to the caller.
            /// </summary>
            Backward,
        }

        /// <summary>
        /// Gets the tbm surface of the remote surface.
        /// </summary>
        /// <value>
        /// The TbmSurface type is tbm_surface_h.
        /// </value>
        internal IntPtr TbmSurface
        {
            get
            {
                IntPtr tbmSurface = IntPtr.Zero;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetTbmSurface(frame, out tbmSurface);

                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get tbm surface");
                }
                return tbmSurface;
            }
        }

        /// <summary>
        /// Gets the file descriptor of the image file of the remote surface.
        /// </summary>
        internal int Fd
        {
            get
            {
                if (fd != -1)
                    return fd;

                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetImageFile(frame, out fd, out size);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get fd of image file");
                }
                return fd;
            }
        }

        /// <summary>
        /// Gets the size of the image file of the remote surface.
        /// </summary>
        internal uint Size
        {
            get
            {
                if (size != 0)
                    return size;

                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetImageFile(frame, out fd, out size);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get size of image file");
                }
                return size;
            }
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        internal string FilePath
        {
            get
            {
                string filePath = string.Empty;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetFilePath(frame, out filePath);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get file path");
                }
                return filePath;
            }
        }

        /// <summary>
        /// Gets the file group.
        /// </summary>
        internal string FileGroup
        {
            get
            {
                string fileGroup = string.Empty;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetFileGroup(frame, out fileGroup);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get file group");
                }
                return fileGroup;
            }
        }

        /// <summary>
        /// Gets the type of the frame.
        /// </summary>
        internal FrameType Type
        {
            get
            {
                Interop.FrameBroker.FrameType type = Interop.FrameBroker.FrameType.SplashScreenImage + 1;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetType(frame, out type);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get frame type");
                }
                return (FrameType)type;
            }
        }

        /// <summary>
        /// Gets the position X.
        /// </summary>
        internal int PositionX
        {
            get
            {
                int x = -1;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetPositionX(frame, out x);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get position X");
                }
                return x;
            }
        }

        /// <summary>
        /// Gets the position Y.
        /// </summary>
        internal int PositionY
        {
            get
            {
                int y = -1;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetPositionY(frame, out y);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(logTag, "Failed to get position Y");
                }
                return y;
            }
        }
    }
}
