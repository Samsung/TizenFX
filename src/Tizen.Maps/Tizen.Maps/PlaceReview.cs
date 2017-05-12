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

        internal PlaceReview(Interop.PlaceReviewHandle handle)
        {
            string date = handle.Date;
            if (DateTime.TryParse(date, out _date) == false)
            {
                Interop.ErrorCode.InvalidParameter.WarnIfFailed($"Wrong date format: {date}");
            }

            _title = handle.Title;
            _rating = handle.Rating;
            _description = handle.Description;
            _language = handle.Language;
            _media = new PlaceMedia(handle.Media);
            _userLink = new PlaceLink(handle.User);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> object which representing time of this review.
        /// </summary>
        public DateTime Date { get { return _date; } }

        /// <summary>
        /// Gets a string which representing title of this review.
        /// </summary>
        public string Title { get { return _title; } }

        /// <summary>
        /// Gets a value which representing rating of this review.
        /// </summary>
        public double Rating { get { return _rating; } }

        /// <summary>
        /// Gets a string which representing description of this review.
        /// </summary>
        public string Description { get { return _description; } }

        /// <summary>
        /// Gets a string which representing language of this review.
        /// </summary>
        public string Language { get { return _language; } }

        /// <summary>
        /// Gets an instance of <see cref="PlaceMedia"/> object which representing review media of this review.
        /// </summary>
        public PlaceMedia ReviewMedia { get { return _media; } }

        /// <summary>
        /// Gets an instance of <see cref="PlaceLink"/> object which representing user link of this review.
        /// </summary>
        public PlaceLink UserLink { get { return _userLink; } }
    }
}
