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
        /// <value> string tag ID</value>
        public override string MediaId
        {
            get
            {
                string mediaId = "";
                int result = Interop.ImageInformation.GetMediaId(_handle, out mediaId);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return mediaId;
            }
        }

        /// <summary>
        ///  Gets the image width in pixels.
        /// </summary>
        /// <value> int image width value</value>
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
        /// <value> int image height value</value>
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
        /// <value> MediaContentOrientation image orientation value</value>
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
        /// Gets the image creation time.
        /// </summary>
        /// <value> string </value>
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
                return takenDate;
            }
        }

        /// <summary>
        /// Gets the burst shot ID.
        /// </summary>
        /// <value> string </value>
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
                return burstId;
            }
        }

        /// <summary>
        /// Gets the exposure time from exif.
        /// </summary>
        /// <value> string </value>
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
                return exposureTime;
            }
        }

        /// <summary>
        /// Gets the fnumber from exif.
        /// </summary>
        /// <value> double </value>
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
        /// <value> int </value>
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
        /// <value> string </value>
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
                Tizen.Log.Info(Globals.LogTag, "Received model:" + model);
                return model;
            }
        }

        /// <summary>
        /// Checks whether the media is a burst shot image.
        /// </summary>
        /// <value> bool </value>
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
        /// Iterates through the media files with optional media_id in the given face face from the media database.
        /// </summary>
        /// <returns>
        /// Task to get all the MediaFaces </returns>
        /// <param name="filter"> filter for the Tags</param>
        public Task<IEnumerable<MediaFace>> GetMediaFacesAsync(ContentFilter filter)
        {
            var task = new TaskCompletionSource<IEnumerable<MediaFace>>();
            Collection<MediaFace> coll = new Collection<MediaFace>();
            Interop.MediaInformation.MediaFaceCallback faceCallback = (IntPtr facehandle, IntPtr userData) =>
            {
                MediaFace face = new MediaFace(facehandle);
                coll.Add(face);
                return true;
            };
            int result = Interop.MediaInformation.GetAllFaces(MediaId, filter.Handle, faceCallback, IntPtr.Zero);
            if ((MediaContentError)result != MediaContentError.None)
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
            if ((MediaContentError)result != MediaContentError.None)
            {
                Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
            }
            return count;
        }


        /// <summary>
        /// Inserts a MediaFace item to the media database
        /// </summary>
        /// <param name="face">The MediaFace item to be inserted</param>
        public MediaFace AddFace(ImageInformation image, FaceRect rect)
        {
            MediaFace face = new MediaFace(image, rect);
            ContentManager.Database.Insert(face);
            return face;
        }

        /// <summary>
        /// Deletes a MediaFace from the media database.
        /// For other types Unsupported exception is thrown.
        /// </summary>
        /// <param name="face">The face instance to be deleted</param>
        public void DeleteFace(MediaFace face)
        {
            ContentManager.Database.Delete(face);
        }

        /// <summary>
        /// Updates a media face instance in the media database
        /// </summary>
        /// <param name="mediaInfo">The MediaFace object to be updated</param>
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
