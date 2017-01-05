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

namespace Tizen.Maps
{
    /// <summary>
    /// Place Image information, used in Place Discovery and Search requests
    /// </summary>
    public class PlaceImage
    {
        private string _id;
        private string _url;
        private int _width;
        private int _height;
        private PlaceLink _userLink;
        private PlaceMedia _media;

        internal PlaceImage(IntPtr nativeHandle)
        {
            var handle = new Interop.PlaceImageHandle(nativeHandle);

            Interop.PlaceImage.GetId(handle, out _id);
            Interop.PlaceImage.GetUrl(handle, out _url);
            Interop.PlaceImage.GetWidth(handle, out _width);
            Interop.PlaceImage.GetHeight(handle, out _height);

            IntPtr userHandle;
            var err = Interop.PlaceImage.GetUserLink(handle, out userHandle);
            if (err.IsSuccess())
                _userLink = new PlaceLink(userHandle);

            IntPtr mediaHandle;
            err = Interop.PlaceImage.GetMedia(handle, out mediaHandle);
            if (err.IsSuccess())
                _media = new PlaceMedia(mediaHandle);
        }

        /// <summary>
        /// Place image Id
        /// </summary>
        public string Id { get { return _id; } }

        /// <summary>
        /// Place image URL
        /// </summary>
        public string Url { get { return _url; } }

        /// <summary>
        /// Place image width
        /// </summary>
        public int Width { get { return _width; } }

        /// <summary>
        /// Place image height
        /// </summary>
        public int Height { get { return _height; } }

        /// <summary>
        /// Place image user link
        /// </summary>
        public PlaceLink UserLink { get { return _userLink; } }

        /// <summary>
        /// Place image media
        /// </summary>
        public PlaceMedia ImageMedia { get { return _media; } }
    }
}
