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


namespace Tizen.Multimedia.MediaController
{
    /// <summary>
    /// Specifies states that a <see cref="ServerInformation"/> can have.
    /// </summary>
    public enum MediaControllerServerState
    {
        /// <summary>
        /// Server state is unknown
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None,

        /// <summary>
        /// Server is activated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Activated,

        /// <summary>
        /// Server is deactivated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Deactivated,
    }

    /// <summary>
    /// Enumeration for playback state
    /// </summary>
    public enum MediaControllerPlaybackState
    {
        /// <summary>
        /// Playback state is unknown
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None,

        /// <summary>
        /// Playback is playing
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Play,

        /// <summary>
        /// Playback is paused
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Pause,

        /// <summary>
        /// Playback is next
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Next,

        /// <summary>
        /// Playback is prev
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Prev,

        /// <summary>
        /// Playback is fastforward
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FastForward,

        /// <summary>
        /// Playback is rewind
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Rewind,
    }

    /// <summary>
    /// Enumeration for shuffle mode
    /// </summary>
    public enum MediaControllerShuffleMode
    {
        /// <summary>
        /// Shuffle mode is On
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        On,

        /// <summary>
        /// Shuffle mode is Off
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Off,
    }

    /// <summary>
    /// Enumeration for repeat mode
    /// </summary>
    public enum MediaControllerRepeatMode
    {
        /// <summary>
        /// Repeat mode is On
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        On,

        /// <summary>
        /// Repeat mode is Off
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Off,
    }

    /// <summary>
    /// Enumeration for repeat mode
    /// </summary>
    public enum MediaControllerSubscriptionType
    {
        /// <summary>
        /// The type of subscription is the state of server
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ServerState,

        /// <summary>
        /// The type of subscription is the playback
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Playback,

        /// <summary>
        /// The type of subscription is the metadata
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Metadata,

        /// <summary>
        /// The type of subscription is the shuffle mode
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ShuffleMode,

        /// <summary>
        /// The type of subscription is the repeat mode
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RepeatMode,
    }

    /// <summary>
    /// Enumeration for metadata attributes
    /// </summary>
    internal enum MediaControllerAttributes
    {
        /// <summary>
        /// Attribute is title
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Title,

        /// <summary>
        /// Attribute is artist
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Artist,

        /// <summary>
        /// Attribute is album
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Album,

        /// <summary>
        /// Attribute is author
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Author,

        /// <summary>
        /// Attribute is genre
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Genre,

        /// <summary>
        /// Attribute is duration
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Duration,

        /// <summary>
        /// Attribute is date
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Date,

        /// <summary>
        /// Attribute is copyright
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Copyright,

        /// <summary>
        /// Attribute is description
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Description,

        /// <summary>
        /// Attribute is track number
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TrackNumber,

        /// <summary>
        /// Attribute is picture
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Picture,
    }
}

