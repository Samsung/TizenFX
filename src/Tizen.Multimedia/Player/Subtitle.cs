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
	/// 
	/// Note: Newly created subtitle has to be set to the 'Subtitle' property of the player object.
	/// Else, operations on subtitle object do not work.
    /// </remarks>
    public class Subtitle
    {

		private EventHandler<SubtitleUpdatedEventArgs> _subtitleUpdated;
		private Interop.Player.SubtitleUpdatedCallback _subtitleUpdatedCallback;

        /// <summary>
        /// Subtitle event is raised when the subtitle is updated
        /// </summary>
        public event EventHandler<SubtitleUpdatedEventArgs> Updated
		{
			add
			{
				if(_subtitleUpdated == null) {
					RegisterSubtitleUpdatedEvent();
				}
				_subtitleUpdated += value;
			}
			remove
			{
				_subtitleUpdated -= value;
				if(_subtitleUpdated == null) {
					UnregisterSubtitleUpdatedEvent();
				}
			}
		}

		private void RegisterSubtitleUpdatedEvent()
		{
			_subtitleUpdatedCallback = (ulong duration, string text, IntPtr userData) =>
			{
				SubtitleUpdatedEventArgs eventArgs = new SubtitleUpdatedEventArgs(duration, text);
				_subtitleUpdated.Invoke(this, eventArgs);
			};
			int ret = Interop.Player.SetSubtitleUpdatedCb(_playerHandle, _subtitleUpdatedCallback, IntPtr.Zero);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Setting subtitle updated callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Setting subtitle updated callback failed"); 
			}

		}

		private void UnregisterSubtitleUpdatedEvent()
		{
			int ret = Interop.Player.UnsetSubtitleUpdatedCb(_playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Unsetting subtitle updated callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Unsetting subtitle updated callback failed"); 
			}
		}


        /// <summary>
        /// Set position offset.
        /// </summary>
        /// <value> position in milli seconds </value>
        public int Position 
		{ 
			set
			{
				int ret = Interop.Player.SetSubtitlePositionOffset(_playerHandle, value);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Setting position offset failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Setting position offset failed"); 
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
				int ret;
				foreach(SubtitleTrack t in _textTrack) 
				{
					ret = Interop.Player.GetTrackLanguageCode(_playerHandle, (int)StreamType.Text, _textTrack.IndexOf(t), out langCode);
					if(ret != (int)PlayerError.None) 
					{
						Log.Error(PlayerLog.LogTag, "Getting text track language code failed" + (PlayerError)ret);
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
				foreach(SubtitleTrack t in _audioTrack) 
				{
					int ret = Interop.Player.GetTrackLanguageCode(_playerHandle, (int)StreamType.Audio, _audioTrack.IndexOf(t), out langCode);
					if(ret != (int)PlayerError.None) 
					{
						Log.Error(PlayerLog.LogTag, "Getting audio track language code failed" + (PlayerError)ret);
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
				int ret;
				foreach(SubtitleTrack t in _videoTrack) 
				{
					ret = Interop.Player.GetTrackLanguageCode(_playerHandle, (int)StreamType.Video, _videoTrack.IndexOf(t), out langCode);
					if(ret != (int)PlayerError.None) 
					{
						Log.Error(PlayerLog.LogTag, "Getting video track language code failed" + (PlayerError)ret);
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
		public string Path
		{
			set
			{
				int ret = Interop.Player.SetSubtitlePath(_playerHandle, value);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Setting subtitle path failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Setting subtitle path failed"); 
				}
			}
		}

		/// <summary>
		/// Subtitle Constructor.
		/// Note: Newly created subtitle has to be set to the 'Subtitle' property of the player object.
		/// Else, operations on subtitle object do not work.  </summary>
		/// <param name="path"> subtitle path </param>
		public Subtitle(string path)
		{
			_path = path;
		}

		IList<SubtitleTrack>  _textTrack;
		IList<SubtitleTrack>  _audioTrack;
		IList<SubtitleTrack>  _videoTrack;

		internal IntPtr _playerHandle;
		internal string _path;
    }
}