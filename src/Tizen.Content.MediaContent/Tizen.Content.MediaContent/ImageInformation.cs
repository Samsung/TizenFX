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
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// ImageContent class API gives the information related to the image media stored in the device</summary>
    public class ImageInformation : MediaInformation
    {
        private readonly Interop.ImageInformation.SafeImageInformationHandle _handle;

        /// <summary>
        ///  Gets the id of the media.
        /// </summary>
        public string MediaId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.ImageInformation.GetMediaId(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the image width in pixels.
        /// </summary>
        public int Width
        {
            get
            {
                int width = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.ImageInformation.GetWidth(_handle, out width), "Failed to get value");

                return width;
            }
        }

        /// <summary>
        ///  Gets the image height in pixels.
        /// </summary>
        public int Height
        {
            get
            {
                int height = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.ImageInformation.GetHeight(_handle, out height), "Failed to get value");

                return height;
            }
        }

        /// <summary>
        ///  Image orientation.
        /// </summary>
        public MediaContentOrientation Orientation
        {
            get
            {
                MediaContentOrientation orientation = MediaContentOrientation.NotAvailable;
                MediaContentValidator.ThrowIfError(
                    Interop.ImageInformation.GetOrientation(_handle, out orientation), "Failed to get value");

                return orientation;
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.ImageInformation.SetOrientation(_handle, value), "Failed to set value");
            }
        }

        /// <summary>
        /// Gets the image creation time in seconds, since the Epoch.
        /// </summary>
        public string TakenDate
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.ImageInformation.GetDateTaken(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// Gets the burst shot ID.
        /// If BurstId is null, this is not a burst shot
        /// </summary>
        public string BurstId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.ImageInformation.GetBurstId(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// Gets the exposure time from exif.
        /// </summary>
        public string ExposureTime
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.ImageInformation.GetExposureTime(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// Gets the fnumber from exif.
        /// </summary>
        public double FNumber
        {
            get
            {
                double fNumber = 0.0;
                MediaContentValidator.ThrowIfError(
                    Interop.ImageInformation.GetFNumber(_handle, out fNumber), "Failed to get value");

                return fNumber;
            }
        }

        /// <summary>
        /// Gets the iso from exif.
        /// </summary>
        public int Iso
        {
            get
            {
                int iso = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.ImageInformation.GetISO(_handle, out iso), "Failed to get value");

                return iso;
            }
        }

        /// <summary>
        /// Gets the model from exif.
        /// </summary>
        public string Model
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.ImageInformation.GetModel(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// Checks whether the media is a burst shot image.
        /// The value is true if the media is a burst shot image,
        /// otherwise false if the media is not a burst shot image.
        /// </summary>
        public bool IsBurstShot
        {
            get
            {
                bool isBurst = false;
                MediaContentValidator.ThrowIfError(
                    Interop.ImageInformation.IsBurstShot(_handle, out isBurst), "Failed to get value");

                return isBurst;
            }
        }

        /// <summary>
        /// Iterates through the media faces with filter in the given media file from the media database.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <returns>
        /// Task to get all the MediaFaces </returns>
        /// <param name="filter"> filter for the Tags</param>
        public Task<IEnumerable<MediaFace>> GetMediaFacesAsync(ContentFilter filter)
        {
            var task = new TaskCompletionSource<IEnumerable<MediaFace>>();
            Collection<MediaFace> coll = new Collection<MediaFace>();

            Interop.MediaInformation.MediaFaceCallback callback = (IntPtr faceHandle, IntPtr userData) =>
            {
                IntPtr newHandle = IntPtr.Zero;
                MediaContentValidator.ThrowIfError(
                    Interop.Face.Clone(out newHandle, faceHandle), "Failed to clone Tag");

                coll.Add(new MediaFace(newHandle));
                return true;
            };
            IntPtr filterHandle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.GetAllFaces(MediaId, filterHandle, callback, IntPtr.Zero), "Failed to get value");
            task.SetResult(coll);
            return task.Task;
        }

        /// <summary>
        /// Gets the number of faces for the passed filter in the given media ID from the media database.
        /// </summary>
        /// <returns>
        /// int count</returns>
        /// <param name="filter">The Filter for matching Face</param>
        public int GetMediaFaceCount(ContentFilter filter)
        {
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.GetFaceCount(MediaId, handle, out count), "Failed to get value");

            return count;
        }


        /// <summary>
        /// Inserts a MediaFace item to the media database
        /// </summary>
        /// <param name="image">The image on which face is to be added</param>
        /// <param name="rect">The dimensions of the face</param>
        /// <returns>The MediaFace instance</returns>
        public MediaFace AddFace(ImageInformation image, FaceRect rect)
        {
            MediaFace face = new MediaFace(image, rect);
            ContentManager.Database.Insert(face);
            return face;
        }

        /// <summary>
        /// Deletes the MediaFace from the media database.
        /// </summary>
        /// <param name="face">The face instance to be deleted</param>
        public void DeleteFace(MediaFace face)
        {
            ContentManager.Database.Delete(face);
        }

        /// <summary>
        /// Updates the MediaFace in the media database
        /// </summary>
        /// <param name="face">The MediaFace object to be updated</param>
        public void UpdateFace(MediaFace face)
        {
            ContentManager.Database.Update(face);
        }

        internal IntPtr ImageHandle
        {
            get
            {
                return _handle.DangerousGetHandle();
            }
        }

        internal ImageInformation(Interop.ImageInformation.SafeImageInformationHandle handle, Interop.MediaInformation.SafeMediaInformationHandle mediaInformationHandle)
            : base(mediaInformationHandle)
        {
            _handle = handle;
        }
    }
}
