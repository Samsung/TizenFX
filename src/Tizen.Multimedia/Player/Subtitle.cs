/// Subtitle
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

 
using System;
using System.Collections.Generic;

namespace Tizen.Multimedia
{
	/// <summary>
    /// Subtitle
    /// </summary>
    /// <remarks>
    /// This class provides properties and events that are required for subtitle
    /// during playback.
    /// </remarks>
    public class Subtitle
    {
        /// <summary>
        /// Subtitle event is raised when the subtitle is updated
        /// </summary>
        public event EventHandler<SubtitleUpdatedEventArgs> Updated;


        /// <summary>
        /// Set position offset.
        /// </summary>
        /// <value> position in milli seconds </value>
        public int Position 
		{ 
			set
			{
				if (Interop.PlayerInterop.SetSubtitlePositionOffset (_playerHandle, value) != 0) {
					// throw Exception
				}
			}
		}


        /// <summary>
        /// Get/Set Text track.
        /// </summary>
        /// <value> Text track list </value>
        public IList<SubtitleTrack>  TextTrack 
		{
			get
			{
				string langCode;
				foreach (SubtitleTrack t in _textTrack) {
					if (Interop.PlayerInterop.GetTrackLanguageCode (_playerHandle, (int)StreamType.Text, _textTrack.IndexOf (t), out langCode) != 0) {
						// throw Exception
					}
					t.LanguageCode = langCode;
				}
				return _textTrack;
			}
			set
			{
				_textTrack = value;
			}
		}

        /// <summary>
        /// Get/Set Text track.
        /// </summary>
        /// <value> Audio track list </value>
        public IList<SubtitleTrack> AudioTrack 
		{
			get
			{
				string langCode;
				foreach (SubtitleTrack t in _audioTrack) {
					if (Interop.PlayerInterop.GetTrackLanguageCode (_playerHandle, (int)StreamType.Audio, _audioTrack.IndexOf (t), out langCode) != 0) {
						// throw Exception
					}
					t.LanguageCode = langCode;
				}
				return _audioTrack;
			}
			set
			{
				_audioTrack = value;
			}
		}

        /// <summary>
        /// Get/Set video track.
        /// </summary>
        /// <value> video track list </value>
        public IList<SubtitleTrack> VideoTrack 
		{
			get
			{
				string langCode;
				foreach (SubtitleTrack t in _videoTrack) {
					if (Interop.PlayerInterop.GetTrackLanguageCode (_playerHandle, (int)StreamType.Video, _videoTrack.IndexOf (t), out langCode) != 0) {
						// throw Exception
					}
					t.LanguageCode = langCode;
				}
				return _videoTrack;
			}
			set
			{
				_videoTrack = value;
			}
		}

		/// <summary>
		/// Set path.
		/// </summary>
		/// <value> path string </value>
		public string path
		{
			set
			{
				if (Interop.PlayerInterop.SetSubtitlePath (_playerHandle, value) != 0) {
					// throw Exception
				}
			}
		}

		IList<SubtitleTrack>  _textTrack;
		IList<SubtitleTrack>  _audioTrack;
		IList<SubtitleTrack>  _videoTrack;

		internal IntPtr _playerHandle;
    }
}