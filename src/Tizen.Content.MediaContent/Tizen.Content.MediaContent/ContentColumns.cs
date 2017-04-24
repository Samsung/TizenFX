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



namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// A ContentColumns class defines the keyword used for filter condition or sorting.
    /// </summary>
    public static class ContentColumns
    {
        /// <summary>
        /// Media column set. \n
        /// You can use this define to set the condition of media filter and order keyword.
        /// </summary>
        public class Media
        {
            /// <summary>
            /// Media UUID
            /// </summary>
            public static string Id
            {
                get
                {
                    return "MEDIA_ID";
                }
            }

            /// <summary>
            /// Media path
            /// </summary>
            public static string Path
            {
                get
                {
                    return "MEDIA_PATH";
                }
            }

            /// <summary>
            /// Display name
            /// </summary>
            public static string DisplayName
            {
                get
                {
                    return "MEDIA_DISPLAY_NAME";
                }
            }

            /// <summary>
            /// The type of media (0-image, 1-video, 2-sound, 3-music, 4-other)
            /// </summary>
            public static string MediaType
            {
                get
                {
                    return "MEDIA_TYPE";
                }
            }

            /// <summary>
            /// Mime type
            /// </summary>
            public static string MimeType
            {
                get
                {
                    return "MEDIA_MIME_TYPE";
                }
            }


            /// <summary>
            /// File size
            /// </summary>
            public static string Size
            {
                get
                {
                    return "MEDIA_SIZE";
                }
            }

            /// <summary>
            /// Added time
            /// </summary>
            public static string AddedTime
            {
                get
                {
                    return "MEDIA_ADDED_TIME";
                }
            }

            /// <summary>
            /// Modified time
            /// </summary>
            public static string ModifiedTime
            {
                get
                {
                    return "MEDIA_MODIFIED_TIME";
                }
            }

            /// <summary>
            /// Timeline. Normally, creation date of media
            /// </summary>
            public static string Timeline
            {
                get
                {
                    return "MEDIA_TIMELINE";
                }
            }

            /// <summary>
            /// The path of thumbnail
            /// </summary>
            public static string ThumbnailPath
            {
                get
                {
                    return "MEDIA_THUMBNAIL_PATH";
                }
            }

            /// <summary>
            /// Title
            /// </summary>
            public static string Title
            {
                get
                {
                    return "MEDIA_TITLE";
                }
            }

            /// <summary>
            /// Album name
            /// </summary>
            public static string Album
            {
                get
                {
                    return "MEDIA_ALBUM";
                }
            }

            /// <summary>
            /// Artist
            /// </summary>
            public static string Artist
            {
                get
                {
                    return "MEDIA_ARTIST";
                }
            }

            /// <summary>
            /// Album artist
            /// </summary>
            public static string AlbumArtist
            {
                get
                {
                    return "MEDIA_ALBUM_ARTIST";
                }
            }

            /// <summary>
            /// Genre
            /// </summary>
            public static string Genre
            {
                get
                {
                    return "MEDIA_GENRE";
                }
            }

            /// <summary>
            /// Composer
            /// </summary>
            public static string Composer
            {
                get
                {
                    return "MEDIA_COMPOSER";
                }
            }

            /// <summary>
            /// Release year
            /// </summary>
            public static string Year
            {
                get
                {
                    return "MEDIA_YEAR";
                }
            }

            /// <summary>
            /// Recorded date
            /// </summary>
            public static string RecordedDate
            {
                get
                {
                    return "MEDIA_RECORDED_DATE";
                }
            }

            /// <summary>
            /// Copyright
            /// </summary>
            public static string Copyright
            {
                get
                {
                    return "MEDIA_COPYRIGHT";
                }
            }

            /// <summary>
            /// Track Number
            /// </summary>
            public static string TrackNumber
            {
                get
                {
                    return "MEDIA_TRACK_NUM";
                }
            }

            /// <summary>
            /// Description
            /// </summary>
            public static string Description
            {
                get
                {
                    return "MEDIA_DESCRIPTION";
                }
            }

            /// <summary>
            /// Bitrate
            /// </summary>
            public static string Bitrate
            {
                get
                {
                    return "MEDIA_BITRATE";
                }
            }

            /// <summary>
            /// Bit per sample
            /// </summary>
            public static string BitPerSample
            {
                get
                {
                    return "MEDIA_BITPERSAMPLE";
                }
            }

            /// <summary>
            /// Samplerate
            /// </summary>
            public static string Samplerate
            {
                get
                {
                    return "MEDIA_SAMPLERATE";
                }
            }

            /// <summary>
            /// Channel
            /// </summary>
            public static string Channel
            {
                get
                {
                    return "MEDIA_CHANNEL";
                }
            }

            /// <summary>
            /// Duration
            /// </summary>
            public static string Duration
            {
                get
                {
                    return "MEDIA_DURATION";
                }
            }

            /// <summary>
            /// Longitude
            /// </summary>
            public static string Longitude
            {
                get
                {
                    return "MEDIA_LONGITUDE";
                }
            }

            /// <summary>
            /// Latitude
            /// </summary>
            public static string Latitude
            {
                get
                {
                    return "MEDIA_LATITUDE";
                }
            }

            /// <summary>
            /// Altitude
            /// </summary>
            public static string Altitude
            {
                get
                {
                    return "MEDIA_ALTITUDE";
                }
            }
            /// <summary>
            /// Width
            /// </summary>
            public static string Width
            {
                get
                {
                    return "MEDIA_WIDTH";
                }
            }

            /// <summary>
            /// Height
            /// </summary>
            public static string Height
            {
                get
                {
                    return "MEDIA_HEIGHT";
                }
            }

            /// <summary>
            /// Datetaken
            /// </summary>
            public static string Datetaken
            {
                get
                {
                    return "MEDIA_DATETAKEN";
                }
            }

            /// <summary>
            /// Orientation
            /// </summary>
            public static string Orientation
            {
                get
                {
                    return "MEDIA_ORIENTATION";
                }
            }

            /// <summary>
            /// Burst shot ID
            /// </summary>
            public static string BurstId
            {
                get
                {
                    return "BURST_ID";
                }
            }

            /// <summary>
            /// Played count
            /// </summary>
            public static string PlayedCount
            {
                get
                {
                    return "MEDIA_PLAYED_COUNT";
                }
            }

            /// <summary>
            /// Last played time
            /// </summary>
            public static string PlayedTime
            {
                get
                {
                    return "MEDIA_LAST_PLAYED_TIME";
                }
            }

            /// <summary>
            /// Last played position
            /// </summary>
            public static string PlayedPosition
            {
                get
                {
                    return "MEDIA_LAST_PLAYED_POSITION";
                }
            }

            /// <summary>
            /// Rating
            /// </summary>
            public static string Rating
            {
                get
                {
                    return "MEDIA_RATING";
                }
            }

            /// <summary>
            /// Favourite
            /// </summary>
            public static string Favourite
            {
                get
                {
                    return "MEDIA_FAVOURITE";
                }
            }

            /// <summary>
            /// Author
            /// </summary>
            public static string Author
            {
                get
                {
                    return "MEDIA_AUTHOR";
                }
            }

            /// <summary>
            /// Provider
            /// </summary>
            public static string Provider
            {
                get
                {
                    return "MEDIA_PROVIDER";
                }
            }
            /// <summary>
            /// Content name
            /// </summary>
            public static string ContentName
            {
                get
                {
                    return "MEDIA_CONTENT_NAME";
                }
            }

            /// <summary>
            /// Category
            /// </summary>
            public static string Category
            {
                get
                {
                    return "MEDIA_CATEGORY";
                }
            }
            /// <summary>
            /// Location tag
            /// </summary>
            public static string LocationTag
            {
                get
                {
                    return "MEDIA_LOCATION_TAG";
                }
            }

            /// <summary>
            /// Age rating
            /// </summary>
            public static string AgeRating
            {
                get
                {
                    return "MEDIA_AGE_RATING";
                }
            }

            /// <summary>
            /// Keyword
            /// </summary>
            public static string Keyword
            {
                get
                {
                    return "MEDIA_KEYWORD";
                }
            }

            /// <summary>
            /// Weather
            /// </summary>
            public static string Weather
            {
                get
                {
                    return "MEDIA_WEATHER";
                }
            }

            /// <summary>
            /// Whether DRM(1) or not(0)
            /// </summary>
            public static string IsDRM
            {
                get
                {
                    return "MEDIA_IS_DRM";
                }
            }

            /// <summary>
            /// Storage type
            /// </summary>
            public static string StorageType
            {
                get
                {
                    return "MEDIA_STORAGE_TYPE";
                }
            }

            /// <summary>
            /// Exposure time
            /// </summary>
            public static string ExposureTime
            {
                get
                {
                    return "MEDIA_EXPOSURE_TIME";
                }
            }

            /// <summary>
            /// f-number
            /// </summary>
            public static string FNumber
            {
                get
                {
                    return "MEDIA_FNUMBER";
                }
            }

            /// <summary>
            /// ISO
            /// </summary>
            public static string Iso
            {
                get
                {
                    return "MEDIA_ISO";
                }
            }

            /// <summary>
            /// Model
            /// </summary>
            public static string Model
            {
                get
                {
                    return "MEDIA_MODEL";
                }
            }

            /// <summary>
            /// 360 content
            /// </summary>
            public static string Media360
            {
                get
                {
                    return "MEDIA_360";
                }
            }

            /// <summary>
            /// Keyword for pinyin
            /// </summary>
            public class Pinyin
            {
                /// <summary>
                /// File name (pinyin)
                /// </summary>
                public static string FileName
                {
                    get
                    {
                        return "MEDIA_FILE_NAME_PINYIN";
                    }
                }

                /// <summary>
                /// Title (pinyin)
                /// </summary>
                public static string Title
                {
                    get
                    {
                        return "MEDIA_TITLE_PINYIN";
                    }
                }

                /// <summary>
                /// Album (pinyin)
                /// </summary>
                public static string Album
                {
                    get
                    {
                        return "MEDIA_ALBUM_PINYIN";
                    }
                }

                /// <summary>
                /// Artist (pinyin)
                /// </summary>
                public static string Artist
                {
                    get
                    {
                        return "MEDIA_ARTIST_PINYIN";
                    }
                }

                /// <summary>
                /// Album artist (pinyin)
                /// </summary>
                public static string AlbumArtist
                {
                    get
                    {
                        return "MEDIA_ALBUM_ARTIST_PINYIN";
                    }
                }

                /// <summary>
                /// Genre (pinyin)
                /// </summary>
                public static string Genre
                {
                    get
                    {
                        return "MEDIA_GENRE_PINYIN";
                    }
                }

                /// <summary>
                /// Composer (pinyin)
                /// </summary>
                public static string Composer
                {
                    get
                    {
                        return "MEDIA_COMPOSER_PINYIN";
                    }
                }

                /// <summary>
                /// Copyright (pinyin)
                /// </summary>
                public static string Copyright
                {
                    get
                    {
                        return "MEDIA_COPYRIGHT_PINYIN";
                    }
                }

                /// <summary>
                /// Description (pinyin)
                /// </summary>
                public static string Description
                {
                    get
                    {
                        return "MEDIA_DESCRIPTION_PINYIN";
                    }
                }

                /// <summary>
                /// Author (pinyin)
                /// </summary>
                public static string Author
                {
                    get
                    {
                        return "MEDIA_AUTHOR_PINYIN";
                    }
                }

                /// <summary>
                /// Provider (pinyin)
                /// </summary>
                public static string Provider
                {
                    get
                    {
                        return "MEDIA_PROVIDER_PINYIN";
                    }
                }

                /// <summary>
                /// Content name (pinyin)
                /// </summary>
                public static string ContentName
                {
                    get
                    {
                        return "MEDIA_CONTENT_NAME_PINYIN";
                    }
                }

                /// <summary>
                /// Category (pinyin)
                /// </summary>
                public static string Category
                {
                    get
                    {
                        return "MEDIA_CATEGORY_PINYIN";
                    }
                }

                /// <summary>
                /// Location tag (pinyin)
                /// </summary>
                public static string LocationTag
                {
                    get
                    {
                        return "MEDIA_LOCATION_TAG_PINYIN";
                    }
                }

                /// <summary>
                /// Age rating (pinyin)
                /// </summary>
                public static string AgeRating
                {
                    get
                    {
                        return "MEDIA_AGE_RATING_PINYIN";
                    }
                }

                /// <summary>
                /// Keyword (pinyin)
                /// </summary>
                public static string Keyword
                {
                    get
                    {
                        return "MEDIA_KEYWORD_PINYIN";
                    }
                }
            }
        }

        /// <summary>
        /// Folder column set. \n
        /// You can use this define to set the condition of folder filter and order keyword.
        /// </summary>
        public class Folder
        {

            /// <summary>
            ///Folder UUID
            /// </summary>
            public static string Id
            {
                get
                {
                    return "FOLDER_ID";
                }
            }

            /// <summary>
            /// Folder path
            /// </summary>
            public static string Path
            {
                get
                {
                    return "FOLDER_PATH";
                }
            }

            /// <summary>
            /// Folder name
            /// </summary>
            public static string Name
            {
                get
                {
                    return "FOLDER_NAME";
                }
            }

            /// <summary>
            /// Folder modified time
            /// </summary>
            public static string ModifiedTime
            {
                get
                {
                    return "FOLDER_MODIFIED_TIME";
                }
            }

            /// <summary>
            /// Folder storage type
            /// </summary>
            public static string StorageType
            {
                get
                {
                    return "FOLDER_STORAGE_TYPE";
                }
            }

            /// <summary>
            /// Keyword for pinyin
            /// </summary>
            public class Pinyin
            {
                /// <summary>
                /// Folder name (pinyin)
                /// </summary>
                public static string Name
                {
                    get
                    {
                        return "FOLDER_NAME_PINYIN";
                    }
                }

            }

            /// <summary>
            /// Folder order. Default is 0
            /// </summary>
            public static string Order
            {
                get
                {
                    return "FOLDER_ORDER";
                }
            }

            /// <summary>
            /// Parent folder UUID
            /// </summary>
            public static string ParentId
            {
                get
                {
                    return "FOLDER_PARENT_FOLDER_ID";
                }
            }
        }

        /// <summary>
        /// Playlist column set. \n
        /// You can use this define to set the condition of playlist filter and order keyword.
        /// </summary>
        public class Playlist
        {
            /// <summary>
            /// Playlist name
            /// </summary>
            public static string Name
            {
                get
                {
                    return "PLAYLIST_NAME";
                }
            }
            /// <summary>
            /// Playlist member's play order
            /// </summary>
            public static string Order
            {
                get
                {
                    return "PLAYLIST_MEMBER_ORDER";
                }
            }

            /// <summary>
            /// Count of media in the playlist
            /// </summary>
            public static string Count
            {
                get
                {
                    return "PLAYLIST_MEDIA_COUNT";
                }
            }
        }

        /// <summary>
        /// Tag column set. \n
        /// You can use this define to set the condition of tag filter and order keyword.
        /// </summary>
        public class Tag
        {
            /// <summary>
            /// Tag name
            /// </summary>
            public static string Name
            {
                get
                {
                    return "TAG_NAME";
                }
            }

            /// <summary>
            /// Count of media in the tag
            /// </summary>
            public static string Count
            {
                get
                {
                    return "TAG_MEDIA_COUNT";
                }
            }
        }

        /// <summary>
        /// Bookmark column set. \n
        /// You can use this define to set the condition of bookmark filter and order keyword.
        /// </summary
        public class Bookmark
        {
            /// <summary>
            /// Bookmarked offset
            /// </summary>
            public static string Offset
            {
                get
                {
                    return "BOOKMARK_MARKED_TIME";
                }
            }
        }

        /// <summary>
        /// Storage column set. \n
        /// You can use this define to set the condition of storage filter and order keyword.
        /// </summary
        public class Storage
        {
            /// <summary>
            /// Storage UUID
            /// </summary>
            public static string Id
            {
                get
                {
                    return "STORAGE_ID";
                }
            }

            /// <summary>
            /// Storage path
            /// </summary>
            public static string Path
            {
                get
                {
                    return "STORAGE_PATH";
                }
            }
        }

        /// <summary>
        /// Face column set. \n
        /// You can use this define to set the condition of face filter and order keyword.
        /// </summary
        public class Face
        {
            /// <summary>
            /// face tag
            /// </summary>
            public static string Tag
            {
                get
                {
                    return "MEDIA_FACE_TAG";
                }
            }
        }
    }
}