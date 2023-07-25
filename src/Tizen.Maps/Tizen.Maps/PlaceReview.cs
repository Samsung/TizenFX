﻿/*
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
    /// Place review information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets an instance of <see cref="DateTime"/> object representing the time of this review.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public DateTime Date { get { return _date; } }

        /// <summary>
        /// Gets a string representing the title of this review.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Title { get { return _title; } }

        /// <summary>
        /// Gets a value representing the rating of this review.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Rating { get { return _rating; } }

        /// <summary>
        /// Gets a string representing the description of this review.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Description { get { return _description; } }

        /// <summary>
        /// Gets a string representing the language of this review.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Language { get { return _language; } }

        /// <summary>
        /// Gets an instance of <see cref="PlaceMedia"/> object representing the review media of this review.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public PlaceMedia ReviewMedia { get { return _media; } }

        /// <summary>
        /// Gets an instance of <see cref="PlaceLink"/> object representing the user link of this review.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public PlaceLink UserLink { get { return _userLink; } }
    }
}
