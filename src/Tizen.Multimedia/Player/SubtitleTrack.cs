/// Subtitle track
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// SubtitleTrack
    /// </summary>
    /// <remarks>
    /// This class provides properties for subtitle tracks.
    /// </remarks>

    public class SubtitleTrack
    {
        /// <summary>
        /// Get/Set Language code.
        /// </summary>
        /// <value> language code string </value>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Get/Set activation status.
        /// </summary>
        /// <value> true, false </value>
        public bool Activated { get; set; }
    }
}
