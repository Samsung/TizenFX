/// Media Uri source
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
    /// Represents a media source with a uri.
    /// </summary>
    /// <remarks>
    /// The internet privilege(http://tizen.org/privilege/internet) must be added if any URLs are used to play from network.
    /// The mediastorage privilege(http://tizen.org/privilege/mediastorage) must be added if any video/audio files are used to play located in the internal storage.
    /// The externalstorage privilege(http://tizen.org/privilege/externalstorage) must be added if any video/audio files are used to play located in the external storage.
    /// </remarks>
    /// <seealso cref="Player.SetSource(MediaSource)"/>
    public sealed class MediaUriSource : MediaSource
    {
        /// <summary>
        /// Initialize a new instance of the MediaUriSource class with the specified uri.</summary>
        /// <param name="uri">The uri string.</param>
        /// <remarks>For HTTP or RSTP, uri should start with "http://" or "rtsp://".
        /// The default protocol is "file://".
        /// If you provide an invalid uri, you won't receive an error until <see cref="Player.Start"/> is called.</remarks>
        public MediaUriSource(string uri)
        {
            if (uri == null)
            {
                Log.Error(PlayerLog.Tag, "uri is null");
                throw new ArgumentNullException(nameof(uri));
            }
            Uri = uri;
        }

        /// <summary>
        /// Gets the uri.
        /// </summary>
        public string Uri { get; }

        internal override void OnAttached(Player player)
        {
            PlayerErrorConverter.ThrowIfError(Interop.Player.SetUri(player.GetHandle(), Uri),
                "Failed to set the source with specified uri");
        }
    }
}

