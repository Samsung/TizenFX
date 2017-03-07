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
using System.Runtime.InteropServices;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// The Media Face Information API provides functions to manage the face information in the image files.
    /// </summary>
    public class MediaFace : IDisposable
    {
        private IntPtr _faceHandle = IntPtr.Zero;
        private bool _disposedValue = false;
        internal IntPtr Handle
        {
            get
            {
                return _faceHandle;
            }
            set
            {
                _faceHandle = value;
            }
        }


        internal MediaFace(IntPtr handle)
        {
            _faceHandle = handle;
        }
        /// <summary>
        /// Create Face for Given Image
        /// </summary>
        /// <param name="image">
        ///image item through which FaceRect has to be tagged.
        ///</param>
        internal MediaFace(MediaInformation image, FaceRect rect)
        {
            MediaContentValidator.ThrowIfError(
                Interop.Face.Create(image.MediaId, out _faceHandle), "Failed to create MediaFace");

            try
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Face.SetFaceRect(_faceHandle, rect.X, rect.Y, rect.Width, rect.Height), "Failed to set Rect to MediaFace");
            }
            catch (Exception)
            {
                Interop.Face.Destroy(_faceHandle);
                throw;
            }
        }

        ~MediaFace()
        {
            Dispose(false);
        }

        /// <summary>
        /// The Media Face Information API provides functions to manage the face information in the image files.
        /// </summary>
        public FaceRect Rect
        {
            get
            {
                int x;
                int y;
                int width;
                int height;
                MediaContentValidator.ThrowIfError(
                    Interop.Face.GetFaceRect(_faceHandle, out x, out y, out width, out height), "Failed to get Rect for the Face");

                return new FaceRect(x, y, width, height);
            }
            set
            {
                FaceRect rect = (FaceRect)value;
                MediaContentValidator.ThrowIfError(
                    Interop.Face.SetFaceRect(_faceHandle, rect.X, rect.Y, rect.Width, rect.Height), "Failed to set Rect for the Face");
            }
        }

        /// <summary>
        /// Face id.
        /// </summary>
        public string Id
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Face.GetFaceId(_faceHandle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// Media uuid from the face
        /// </summary>
        public string MediaInformationId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Face.GetMediaId(_faceHandle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }
        /// <summary>
        /// Tag name for the MediaFace.
        /// </summary>
        public string Tag
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Face.GetTag(_faceHandle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Face.SetTag(_faceHandle, value), "Failed to set value");
            }
        }

        /// <summary>
        /// Orientation Value for the face
        /// </summary>
        public MediaContentOrientation Orientation
        {
            get
            {
                int orientation;
                MediaContentValidator.ThrowIfError(
                    Interop.Face.GetOrientation(_faceHandle, out orientation), "Failed to value");

                return (MediaContentOrientation)orientation;
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Face.SetOrientation(_faceHandle, (int)value), "Failed to set value");
            }
        }

        /// <summary>
        /// Dispose API for closing the internal resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (_faceHandle != IntPtr.Zero)
                {
                    Interop.Face.Destroy(_faceHandle);
                    _faceHandle = IntPtr.Zero;
                }
                _disposedValue = true;
            }
        }
    }
}
