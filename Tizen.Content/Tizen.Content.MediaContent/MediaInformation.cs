/// This File contains the Api's related to the MediaContent class
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// MediaContent class API gives the information related to the media stored in the device</summary>
    /// <remarks>
    /// The API's provide the functionlity to insert, clone, delete, get the number and content of files from DB.
    /// You can get and set properties and parameters such as storage type, provider, and category of media info,
    /// handling with thumbnail and updating media info to DB.</remarks>
    public class MediaInformation
    {
        private readonly Interop.MediaInformation.SafeMediaInformationHandle _handle;

        /// <summary>
        /// Gets the count of media tags for the passed filter in the given mediaId from the media database.
        /// </summary>
        /// <returns>
        /// int count</returns>
        /// <param name="filter">The Filter for matching Tags</param>
        public int GetTagCount(ContentFilter filter)
        {
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            int result = Interop.MediaInformation.GetTagCount(MediaId, handle, out count);
            if ((MediaContentError)result != MediaContentError.None)
            {
                Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
            }
            return count;
        }

        /// <summary>
        /// Moves the media info to the given destination path in the media database.
        /// </summary>
        /// <returns>
        /// void </returns>
        /// <param name="destination">The Destination path</param>
        public void Move(string destination)
        {
            int result = Interop.MediaInformation.MoveToDB(_handle, destination);
            if ((MediaContentError)result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to move");
            }
        }

        /// <summary>
        /// Refreshes the media metadata to the media database.
        /// </summary>
        /// <returns>
        /// void </returns>
        public void Refresh()
        {
            int result = Interop.MediaInformation.RefreshMetadataToDB(MediaId);
            if ((MediaContentError)result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to move");
            }
        }

        /// <summary>
        /// Creates a thumbnail image for the given media, asynchronously
        /// If a thumbnail already exists for the given media, then the path of thumbnail will be returned.
        /// </summary>
        /// <returns>
        /// Task for creation of Thumbnail </returns>
        public async Task<string> CreateThumbnailAsync()
        {
            var task = new TaskCompletionSource<string>();
            Interop.MediaInformation.MediaThumbnailCompletedCallback thumbnailResult = (MediaContentError createResult, string path, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Thumbnail Callback Received ");
                if (createResult == MediaContentError.None)
                {
                    Log.Info(Globals.LogTag, "Thumbnail Callback Received with path " + path);
                    task.SetResult(path);
                }
                else
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)createResult);
                    task.SetException(MediaContentErrorFactory.CreateException((MediaContentError)createResult, "Failed to create Thumbnail"));
                }
            };
            int result = Interop.MediaInformation.CreateThumbnail(_handle, thumbnailResult, IntPtr.Zero);
            if ((MediaContentError)result != MediaContentError.None)
            {
                Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
            }
            return await task.Task;
        }

        /// <summary>
        /// Creates a thumbnail image for the given media, asynchronously
        /// which can be cancelled
        /// If a thumbnail already exists for the given media, then the path of thumbnail will be returned.
        /// </summary>
        /// <returns>
        /// Task for creation of Thumbnail </returns>
        public async Task<string> CreateThumbnailAsync(CancellationToken cancellationToken)
        {
            var task = new TaskCompletionSource<string>();
            cancellationToken.Register(() => {
                Log.Info(Globals.LogTag, "Cancel thumbnail Called");
                int resultCancel = Interop.MediaInformation.CancelThumbnail(_handle);
                Log.Info(Globals.LogTag, "After CAPI CancelThumbnail");
                if ((MediaContentError)resultCancel != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Cancel thumbnail failed with error code: " + (MediaContentError)resultCancel);
                }
                else
                {
                    task.SetCanceled();
                }
            });
            Interop.MediaInformation.MediaThumbnailCompletedCallback thumbnailResult = (MediaContentError createResult, string path, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Thumbnail Callback Received");
                if (createResult == MediaContentError.None)
                {
                    task.SetResult(path);
                }
                else
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)createResult);
                    task.SetException(MediaContentErrorFactory.CreateException((MediaContentError)createResult, "Failed to create Thumbnail"));
                }
            };
            int result = Interop.MediaInformation.CreateThumbnail(_handle, thumbnailResult, IntPtr.Zero);
            if ((MediaContentError)result != MediaContentError.None)
            {
                Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                task.SetException(MediaContentErrorFactory.CreateException((MediaContentError)result, "Creating Thumbnail Fail"));
            }
            return await task.Task;
        }

        /// <summary>
        /// Iterates through the media tag in the given media info from the media database.
        /// </summary>
        /// <returns>
        /// Task to get all the Tags </returns>
        /// <param name="filter"> The filter for the Tags</param>
        public Task<IEnumerable<Tag>> GetTagsAsync(ContentFilter filter)
        {
            var task = new TaskCompletionSource<IEnumerable<Tag>>();
            Collection<Tag> coll = new Collection<Tag>();
            MediaContentError result;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.MediaInformation.MediaTagCallback tagsCallback = (IntPtr tagHandle, IntPtr userData) =>
            {
                IntPtr newHandle;
                result = (MediaContentError)Interop.Tag.Clone(out newHandle, tagHandle);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to clone Tag");
                }
                Tag tag = new Tag(newHandle);
                coll.Add(tag);
                return true;
            };
            result = (MediaContentError)Interop.MediaInformation.GetAllTags(MediaId, handle, tagsCallback, IntPtr.Zero);
            if (result != MediaContentError.None)
            {
                Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
            }
            task.SetResult(coll);
            return task.Task;
        }

        /// <summary>
        ///  Gets the tag ID for the media.
        /// </summary>
        public virtual string MediaId
        {
            get
            {
                string mediaId = "";
                int result = Interop.MediaInformation.GetMediaId(_handle, out mediaId);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                    //Log.Error()
                }
                if (mediaId == null)
                {
                    mediaId = "";
                }
                return mediaId;
            }
        }

        /// <summary>
        ///  Gets the path to the media.
        /// </summary>
        public string FilePath
        {
            get
            {
                string path = "";
                int result = Interop.MediaInformation.GetFilePath(_handle, out path);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (path == null)
                {
                    path = "";
                }
                return path;
            }
        }

        /// <summary>
        ///  Name of the media.
        /// </summary>
        public string DisplayName
        {
            get
            {
                string displayname = "";
                int result = Interop.MediaInformation.GetDisplayName(_handle, out displayname);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (displayname == null)
                {
                    displayname = "";
                }
                return displayname;
            }
            set
            {
                int result = Interop.MediaInformation.SetDisplayName(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set displayname");
                }
            }
        }

        /// <summary>
        ///  Gets the content type of the media.
        /// </summary>
        public MediaContentType MediaType
        {
            get
            {
                MediaContentType contentType = MediaContentType.Others;
                int result = Interop.MediaInformation.GetMediaType(_handle, out contentType);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return contentType;
            }
        }

        /// <summary>
        ///  Gets the MIME type from the media.
        /// </summary>
        public string MimeType
        {
            get
            {
                string mimeType = "";
                int result = Interop.MediaInformation.GetMimeType(_handle, out mimeType);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (mimeType == null)
                {
                    mimeType = "";
                }
                return mimeType;
            }
        }

        /// <summary>
        ///  Gets the media file size in Bytes.
        /// </summary>
        public long Size
        {
            get
            {
                long size;
                int result = Interop.MediaInformation.GetSize(_handle, out size);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return size;
            }
        }

        /// <summary>
        ///  Addition time of the media.
        /// </summary>
        public DateTime AddedAt
        {
            get
            {
                DateTime addedAt;
                int time;
                int result = Interop.MediaInformation.GetAddedTime(_handle, out time);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                DateTime utc;
                if (time != 0)
                {
                    Tizen.Log.Info(Globals.LogTag, "Ticks received: " + time);
                    utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);
                    addedAt = utc.ToLocalTime();
                }
                else
                {
                    Tizen.Log.Info(Globals.LogTag, "No Date received");
                    addedAt = DateTime.Now;
                }
                return addedAt;
            }

            set
            {
                int result = Interop.MediaInformation.SetAddedTime(_handle, (int)value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set time");
                }
            }
        }

        /// <summary>
        ///  Gets the date of modification of media.
        /// </summary>
        public DateTime ModifiedAt
        {
            get
            {
                DateTime modifiedAt;
                int time;
                int result = Interop.MediaInformation.GetModifiedTime(_handle, out time);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                DateTime utc;
                if (time != 0)
                {
                    Tizen.Log.Info(Globals.LogTag, "Ticks received: " + time);
                    utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);
                    modifiedAt = utc.ToLocalTime();
                }
                else
                {
                    Tizen.Log.Info(Globals.LogTag, "No Date received");
                    modifiedAt = DateTime.Now;
                }
                return modifiedAt;
            }
        }

        /// <summary>
        ///  Gets the timeline of media.
        /// </summary>
        public DateTime TimeLine
        {
            get
            {
                DateTime timeline;
                int time;
                int result = Interop.MediaInformation.GetTimeline(_handle, out time);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                DateTime utc;
                if (time != 0)
                {
                    Tizen.Log.Info(Globals.LogTag, "Ticks received: " + time);
                    utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);
                    timeline = utc.ToLocalTime();
                }
                else
                {
                    Tizen.Log.Info(Globals.LogTag, "No Date received");
                    timeline = DateTime.Now;
                }
                return timeline;
            }
        }

        /// <summary>
        ///  Gets the thumbnail of media.
        /// </summary>
        public string ThumbnailPath
        {
            get
            {
                string thumbnailPath = "";
                int result = Interop.MediaInformation.GetThumbnailPath(_handle, out thumbnailPath);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (thumbnailPath == null)
                {
                    thumbnailPath = "";
                }
                return thumbnailPath;
            }
        }

        /// <summary>
        ///  Description of media.
        ///  If the media info has no description, the method returns empty string.
        /// </summary>
        public string Description
        {
            get
            {
                string description = "";
                int result = Interop.MediaInformation.GetDescription(_handle, out description);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (description == null)
                {
                    description = "";
                }
                return description;
            }
            set
            {
                int result = Interop.MediaInformation.SetDescription(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set description");
                }
            }
        }

        /// <summary>
        /// Longitude of media.
        /// Default Value is 0.0.
        /// </summary>
        public double Longitude
        {
            get
            {
                double longitude = 0.0;
                int result = Interop.MediaInformation.GetLongitude(_handle, out longitude);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return longitude;
            }
            set
            {
                int result = Interop.MediaInformation.SetLongitude(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set langitude");
                }
            }
        }

        /// <summary>
        /// Latitude of media.
        /// Default Value is 0.0.
        /// </summary>
        public double Latitude
        {
            get
            {
                double latitude = 0.0;
                int result = Interop.MediaInformation.GetLatitude(_handle, out latitude);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return latitude;
            }
            set
            {
                int result = Interop.MediaInformation.SetLatitude(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set latitude");
                }
            }
        }

        /// <summary>
        /// Altitude of media.
        /// Default Value is 0.0.
        /// </summary>
        public double Altitude
        {
            get
            {
                double altitude = 0.0;
                int result = Interop.MediaInformation.GetAltitude(_handle, out altitude);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return altitude;
            }
            set
            {
                int result = Interop.MediaInformation.SetAltitude(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set altitude");
                }
            }
        }

        /// <summary>
        /// Weather of media.
        /// Dafault is empty string.
        /// </summary>
        public string Weather
        {
            get
            {
                string weather = "";
                int result = Interop.MediaInformation.GetWeather(_handle, out weather);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (weather == null)
                {
                    weather = "";
                }
                return weather;
            }
            set
            {
                int result = Interop.MediaInformation.SetWeather(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set weather");
                }
            }
        }

        /// <summary>
        /// Rating of media.
        /// </summary>
        public int Rating
        {
            get
            {
                int rating = 0;
                int result = Interop.MediaInformation.GetRating(_handle, out rating);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return rating;
            }
            set
            {
                int result = Interop.MediaInformation.SetRating(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set rating");
                }
            }
        }

        /// <summary>
        /// Favorite status of media.
        /// true if media info is set as favorite, otherwise false if media info is not set as favorite.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                bool isFavourtite = false;
                int result = Interop.MediaInformation.GetFavorite(_handle, out isFavourtite);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return isFavourtite;
            }
            set
            {
                int result = Interop.MediaInformation.SetFavorite(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set favorite");
                }
            }
        }

        /// <summary>
        /// Author of media.
        /// </summary>
        public string Author
        {
            get
            {
                string author = "";
                int result = Interop.MediaInformation.GetAuthor(_handle, out author);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if(author == null)
                {
                    author = "";
                }
                return author;
            }
            set
            {
                int result = Interop.MediaInformation.SetAuthor(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set author");
                }
            }
        }

        /// <summary>
        /// Provider of media.
        /// </summary>
        public string Provider
        {
            get
            {
                string provider = "";
                int result = Interop.MediaInformation.GetProvider(_handle, out provider);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (provider == null)
                {
                    provider = "";
                }
                return provider;
            }
            set
            {
                int result = Interop.MediaInformation.SetProvider(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set provider");
                }
            }
        }

        /// <summary>
        /// Content name of media.
        /// </summary>
        public string ContentName
        {
            get
            {
                string contentName = "";
                int result = Interop.MediaInformation.GetContentName(_handle, out contentName);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (contentName == null)
                {
                    contentName = "";
                }
                return contentName;
            }
            set
            {
                int result = Interop.MediaInformation.SetContentName(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set content name");
                }
            }
        }

        /// <summary>
        /// Gets the title of media.
        /// </summary>
        public string Title
        {
            get
            {
                string title = "";
                int result = Interop.MediaInformation.GetTitle(_handle, out title);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (title == null)
                {
                    title = "";
                }
                return title;
            }
        }

        /// <summary>
        /// Category of media.
        /// </summary>
        public string Category
        {
            get
            {
                string category = "";
                int result = Interop.MediaInformation.GetCategory(_handle, out category);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (category == null)
                {
                    category = "";
                }
                return category;
            }
            set
            {
                int result = Interop.MediaInformation.SetCategory(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set category");
                }
            }
        }

        /// <summary>
        /// location tag of media.
        /// </summary>
        public string LocationTag
        {
            get
            {
                string loationTag = "";
                int result = Interop.MediaInformation.GetLocationTag(_handle, out loationTag);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (loationTag == null)
                {
                    loationTag = "";
                }
                return loationTag;
            }
            set
            {
                int result = Interop.MediaInformation.SetLocationTag(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set location tag");
                }
            }
        }

        /// <summary>
        /// Age Rating of media.
        /// </summary>
        public string AgeRating
        {
            get
            {
                string ageRating = "";
                int result = Interop.MediaInformation.GetAgeRating(_handle, out ageRating);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (ageRating == null)
                {
                    ageRating = "";
                }
                return ageRating;
            }
            set
            {
                int result = Interop.MediaInformation.SetAgeRating(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set age rating");
                }
            }
        }

        /// <summary>
        /// Keyword of media.
        /// </summary>
        public string Keyword
        {
            get
            {
                string keyword = "";
                int result = Interop.MediaInformation.GetKeyword(_handle, out keyword);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (keyword == null)
                {
                    keyword = "";
                }
                return keyword;
            }
            set
            {
                int result = Interop.MediaInformation.SetKeyword(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set keyword");
                }
            }
        }

        /// <summary>
        /// Gets the storage id of media.
        /// </summary>
        public string StorageId
        {
            get
            {
                string storageId = "";
                int result = Interop.MediaInformation.GetStorageId(_handle, out storageId);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                if (storageId == null)
                {
                    storageId = "";
                }
                return storageId;
            }
        }

        /// <summary>
        /// Checks whether the media is protected via DRM.
        /// </summary>
        public bool IsDrm
        {
            get
            {
                bool isDRM = false;
                int result = Interop.MediaInformation.IsDrm(_handle, out isDRM);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return isDRM;
            }
        }

        /// <summary>
        /// Gets the storage type of media.
        /// </summary>
        public ContentStorageType StorageType
        {
            get
            {
                ContentStorageType storageType = ContentStorageType.Internal;
                int result = Interop.MediaInformation.GetStorageType(_handle, out storageType);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return storageType;
            }
        }

        /// <summary>
        /// Number which represents how many times given content has been played.
        /// While Setting the played count, it will only be incremented by 1, the value provided will be ignored.
        /// </summary>
        public int PlayedCount
        {
            get
            {
                int playedCount = 0;
                int result = Interop.MediaInformation.GetPlayedCount(_handle, out playedCount);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return playedCount;
            }
            set
            {
                int result = Interop.MediaInformation.IncreasePlayedCount(_handle);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set increase played count");
                }
            }
        }

        /// <summary>
        ///  Content's latest played(opened) time of the media file.
        ///  for set the current time is automatically taken from the system, the value provided will be ignored.
        /// </summary>
        public DateTime PlayedAt
        {
            get
            {
                DateTime addedAt;
                int time;
                int result = Interop.MediaInformation.GetPlayedAt(_handle, out time);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                DateTime utc;
                if (time != 0)
                {
                    Tizen.Log.Info(Globals.LogTag, "Ticks received: " + time);
                    utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);
                    addedAt = utc.ToLocalTime();
                }
                else
                {
                    Tizen.Log.Info(Globals.LogTag, "No Date received");
                    addedAt = DateTime.Now;
                }
                return addedAt;
            }
            set
            {
                int result = Interop.MediaInformation.SetPlayedAt(_handle);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set played time");
                }
            }
        }

        internal IntPtr MediaHandle
        {
            get
            {
                return _handle.DangerousGetHandle();
            }
        }

        internal MediaInformation(Interop.MediaInformation.SafeMediaInformationHandle handle)
        {
            _handle = handle;
        }
    }
}
