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
    /// Place Review information, used in Place Discovery and Search requests
    /// </summary>
    public class PlaceReview
    {
        private DateTime _date;
        private string _title;
        private double _rating;
        private string _description;
        private string _language;
        private PlaceMedia _media;
        private PlaceLink _userLink;

        internal PlaceReview(IntPtr nativeHandle)
        {
            var handle = new Interop.PlaceReviewHandle(nativeHandle);

            string date;
            var err = Interop.PlaceReview.GetDate(handle, out date);
            if (err.IsSuccess())
            {
                if (DateTime.TryParse(date, out _date) == false)
                {
                    Interop.ErrorCode.InvalidParameter.WarnIfFailed(string.Format("Wrong date format: {0}", date));
                }
            }

            Interop.PlaceReview.GetTitle(handle, out _title);
            Interop.PlaceReview.GetRating(handle, out _rating);
            Interop.PlaceReview.GetDescription(handle, out _description);
            Interop.PlaceReview.GetLanguage(handle, out _language);

            IntPtr mediaHandle;
            err = Interop.PlaceReview.GetMedia(handle, out mediaHandle);
            if (err.IsSuccess())
                _media = new PlaceMedia(mediaHandle);

            IntPtr userHandle;
            err = Interop.PlaceReview.GetUserLink(handle, out userHandle);
            if (err.IsSuccess())
                _userLink = new PlaceLink(userHandle);
        }

        /// <summary>
        /// Time of this review
        /// </summary>
        public DateTime Date { get { return _date; } }

        /// <summary>
        /// Title of this review
        /// </summary>
        public string Title { get { return _title; } }

        /// <summary>
        /// Rating of this review
        /// </summary>
        public double Rating { get { return _rating; } }

        /// <summary>
        /// Description of this review
        /// </summary>
        public string Description { get { return _description; } }

        /// <summary>
        /// Language of this review
        /// </summary>
        public string Language { get { return _language; } }

        /// <summary>
        /// Media attached with this review
        /// </summary>
        public PlaceMedia ReviewMedia { get { return _media; } }

        /// <summary>
        /// User link of this review
        /// </summary>
        public PlaceLink UserLink { get { return _userLink; } }
    }
}
