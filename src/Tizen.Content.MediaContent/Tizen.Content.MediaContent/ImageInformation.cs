/// This File contains the Api's related to the ImageContent class
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// ImageContent class API gives the information related to the image media stored in the device</summary>
    public class ImageInformation : MediaInformation
    {
        private readonly Interop.ImageInformation.SafeImageInformationHandle _handle;

        /// <summary>
        ///  Gets the tag ID for the image.
        /// </summary>
        public string MediaId
        {
            get
            {
                string mediaId = "";
                int result = Interop.ImageInformation.GetMediaId(_handle, out mediaId);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (mediaId == null)
                {
                    mediaId = "";
                }
                return mediaId;
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
                int result = Interop.ImageInformation.GetWidth(_handle, out width);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.ImageInformation.GetHeight(_handle, out height);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.ImageInformation.GetOrientation(_handle, out orientation);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                Tizen.Log.Info(Globals.LogTag, "Orientation Recieved " + orientation);
                return orientation;
            }
            set
            {
                int result = Interop.ImageInformation.SetOrientation(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "Failed to Setorientation");
                }
            }
        }

        /// <summary>
        /// Gets the image creation time in seconds, since the Epoch.
        /// </summary>
        public string TakenDate
        {
            get
            {
                string takenDate = "";
                int result = Interop.ImageInformation.GetDateTaken(_handle, out takenDate);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (takenDate == null)
                {
                    takenDate = "";
                }
                return takenDate;
            }
        }

        /// <summary>
        /// Gets the burst shot ID.
        /// If burst_id is Empty, this is not burst shot
        /// </summary>
        public string BurstId
        {
            get
            {
                string burstId = "";
                int result = Interop.ImageInformation.GetBurstId(_handle, out burstId);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (burstId == null)
                {
                    burstId = "";
                }
                return burstId;
            }
        }

        /// <summary>
        /// Gets the exposure time from exif.
        /// </summary>
        public string ExposureTime
        {
            get
            {
                string exposureTime = "";
                int result = Interop.ImageInformation.GetExposureTime(_handle, out exposureTime);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (exposureTime == null)
                {
                    exposureTime = "";
                }
                return exposureTime;
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
                int result = Interop.ImageInformation.GetFNumber(_handle, out fNumber);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                Tizen.Log.Info(Globals.LogTag, "Received fnumber:" + fNumber);
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
                int result = Interop.ImageInformation.GetISO(_handle, out iso);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                Tizen.Log.Info(Globals.LogTag, "Received iso:" + iso);
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
                string model = "";
                int result = Interop.ImageInformation.GetModel(_handle, out model);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (model == null)
                {
                    model = "";
                }
                return model;
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
                int result = Interop.ImageInformation.IsBurstShot(_handle, out isBurst);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                Tizen.Log.Info(Globals.LogTag, "Received isBurst:" + isBurst);
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
            MediaContentError result;
            Interop.MediaInformation.MediaFaceCallback faceCallback = (IntPtr facehandle, IntPtr userData) =>
            {
                IntPtr newHandle;
                result = (MediaContentError)Interop.Face.Clone(out newHandle, facehandle);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to clone Tag");
                }
                MediaFace face = new MediaFace(newHandle);
                Tizen.Log.Info("TCT", "GetMediaFacesAsync: Got Media Face");
                Tizen.Log.Info("TCT", "GetMediaFacesAsync: Face.Id " + face.Id);
                Tizen.Log.Info("TCT", "GetMediaFacesAsync: Face.MediaInformationId " + face.MediaInformationId);
                Tizen.Log.Info("TCT", "GetMediaFacesAsync: Face.Orientation " + face.Orientation);
                Tizen.Log.Info("TCT", "GetMediaFacesAsync: Face.Rect " + face.Rect);
                Tizen.Log.Info("TCT", "GetMediaFacesAsync: Face.Tag " + face.Tag);
                coll.Add(face);
                return true;
            };
            IntPtr filterHandle = (filter != null) ? filter.Handle : IntPtr.Zero;
            result = (MediaContentError)Interop.MediaInformation.GetAllFaces(MediaId, filterHandle, faceCallback, IntPtr.Zero);
            if (result != MediaContentError.None)
            {
                Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
            }
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
            int result = Interop.MediaInformation.GetFaceCount(MediaId, handle, out count);
            Tizen.Log.Info("TCT", "GetMediaFaceCount: " + count);
            if ((MediaContentError)result != MediaContentError.None)
            {
                Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
            }
            return count;
        }


        /// <summary>
        /// Inserts a MediaFace item to the media database
        /// </summary>
        /// <param name="image">The image on which face is to be added</param>
        /// <param name="rect">The dimensions of the face</param>
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
