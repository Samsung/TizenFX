/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

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
            MediaContentError res = (MediaContentError)Interop.Face.Create(image.MediaId, out _faceHandle);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to create MediaFace");
            }
            res = (MediaContentError)Interop.Face.SetFaceRect(_faceHandle, rect.X, rect.Y, rect.Width, rect.Height);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to set Rect to MediaFace");
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
                MediaContentError res = (MediaContentError)Interop.Face.GetFaceRect(_faceHandle, out x, out y, out width, out height);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Rect for the Face");
                }
                return new FaceRect(x, y, width, height);
            }
            set
            {
                FaceRect rect = (FaceRect)value;
                MediaContentError res = (MediaContentError)Interop.Face.SetFaceRect(_faceHandle, rect.X, rect.Y, rect.Width, rect.Height);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to set Rect for the Face");
                }
            }
        }

        /// <summary>
        /// Face id.
        /// </summary>
        public string Id
        {
            get
            {
                string id;
                MediaContentError res = (MediaContentError)Interop.Face.GetFaceId(_faceHandle, out id);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Id for the Face");
                }
                return id;
            }
        }

        /// <summary>
        /// Media uuid from the face
        /// </summary>
        public string MediaInformationId
        {
            get
            {
                string mediaId;
                MediaContentError res = (MediaContentError)Interop.Face.GetMediaId(_faceHandle, out mediaId);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get media Id for the Face");
                }
                return mediaId;
            }
        }
        /// <summary>
        /// Tag name for the MediaFace.
        /// </summary>
        public string Tag
        {
            get
            {
                string tag;
                MediaContentError res = (MediaContentError)Interop.Face.GetTag(_faceHandle, out tag);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Tag for the Face");
                }
                return tag;
            }
            set
            {
                MediaContentError res = (MediaContentError)Interop.Face.SetTag(_faceHandle, value);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to set Tag for the Face");
                }
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
                MediaContentError res = (MediaContentError)Interop.Face.GetOrientation(_faceHandle, out orientation);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to  GetOrientation for the Face");
                }
                return (MediaContentOrientation)orientation;
            }
            set
            {
                MediaContentError res = (MediaContentError)Interop.Face.SetOrientation(_faceHandle, (int)value);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to SetOrientation for the Face");
                }
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
