/// This File contains SubtitleUpdatedEventArgs class
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
    /// SubtitleUpdated event arguments
    /// </summary>
    /// <remarks>
    /// SubtitleUpdated event arguments
    /// </remarks>
    public class SubtitleUpdatedEventArgs : EventArgs
    {
		internal ulong _duration;
		internal string _text;

		/// <summary>
		/// Constructor.
		/// </summary>
		public SubtitleUpdatedEventArgs(ulong duration, string text)
		{
			_duration = duration;
			_text = text;
		}

        /// <summary>
        /// The duration of the updated subtitle .
        /// </summary>
        /// <value> ulong duration</value>
        public ulong Duration 
        {
            get
            {
                return _duration;
            }
        }

        /// <summary>
        /// The text of the updated subtitle .
        /// </summary>
        /// <value> string </value>
        public string Text 
        {
            get
            {
                return _text;
            }
        }

    }
}