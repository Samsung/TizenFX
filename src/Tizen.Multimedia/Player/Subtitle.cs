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
		internal IntPtr _playerHandle;
		internal string _path;
		private EventHandler<SubtitleUpdatedEventArgs> _subtitleUpdated;
		private Interop.Player.SubtitleUpdatedCallback _subtitleUpdatedCallback;

		/// <summary>
		/// Subtitle Constructor.
		/// Note: Newly created subtitle has to be set to the 'Subtitle' property of the player object.
		/// Else, operations on subtitle object do not work.  </summary>
		/// <param name="path"> subtitle path </param>
		public Subtitle(string path)
		{
			_path = path;
		}

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
		public IEnumerable<SubtitleTrack>  TextTrack 
		{
			get
			{
				string langCode;
				int curTrack;
				int ret;
				int tracks = 0;
				List<SubtitleTrack> textTrack = new List<SubtitleTrack>();

				ret = Interop.Player.GetTrackCount(_playerHandle, (int)StreamType.Text, out tracks);
				if(ret == (int)PlayerError.None)
				{
					ret = Interop.Player.GetCurrentTrack(_playerHandle, (int)StreamType.Text, out curTrack);
					if(ret == (int)PlayerError.None && tracks > 0)
					{
						for(int idx = 0; idx < tracks; idx++)
						{
							bool activated = (curTrack == idx ? true : false);
							ret = Interop.Player.GetTrackLanguageCode(_playerHandle, (int)StreamType.Text, idx, out langCode);
							if(ret == (int)PlayerError.None) 
							{
								SubtitleTrack st = new SubtitleTrack(langCode, activated);
								textTrack.Add(st);
							}
							else
							{
								Log.Error(PlayerLog.LogTag, "Getting text track language code failed" + (PlayerError)ret);
							}
						}
					}
					else
					{
						Log.Error(PlayerLog.LogTag, "Getting current track index failed" + (PlayerError)ret);
					}
				}
				else
				{
					Log.Error(PlayerLog.LogTag, "Getting track count failed" + (PlayerError)ret);
				}

				return textTrack;
			}
		}

        /// <summary>
        /// Get/Set Audio track.
        /// </summary>
        /// <value> Audio track list </value>
		public IEnumerable<SubtitleTrack> AudioTrack 
		{
			get
			{
				string langCode;
				int curTrack;
				int ret;
				int tracks = 0;
				List<SubtitleTrack> audioTrack = new List<SubtitleTrack>();

				ret = Interop.Player.GetTrackCount(_playerHandle, (int)StreamType.Audio, out tracks);
				if(ret == (int)PlayerError.None)
				{
					ret = Interop.Player.GetCurrentTrack(_playerHandle, (int)StreamType.Audio, out curTrack);
					if(ret == (int)PlayerError.None && tracks > 0)
					{
						for(int idx = 0; idx < tracks; idx++)
						{
							bool activated = (curTrack == idx ? true : false);
							ret = Interop.Player.GetTrackLanguageCode(_playerHandle, (int)StreamType.Audio, idx, out langCode);
							if(ret == (int)PlayerError.None) 
							{
								SubtitleTrack st = new SubtitleTrack(langCode, activated);
								audioTrack.Add(st);
							}
							else
							{
								Log.Error(PlayerLog.LogTag, "Getting audio track language code failed" + (PlayerError)ret);
							}
						}
					}
					else
					{
						Log.Error(PlayerLog.LogTag, "Getting audio track index failed" + (PlayerError)ret);
					}
				}
				else
				{
					Log.Error(PlayerLog.LogTag, "Getting audio track count failed" + (PlayerError)ret);
				}

				return audioTrack;
			}
		}

        /// <summary>
        /// Get/Set video track.
        /// </summary>
        /// <value> video track list </value>
		public IEnumerable<SubtitleTrack> VideoTrack 
		{
			get
			{
				string langCode;
				int curTrack;
				int ret;
				int tracks = 0;
				List<SubtitleTrack> videoTrack = new List<SubtitleTrack>();

				ret = Interop.Player.GetTrackCount(_playerHandle, (int)StreamType.Video, out tracks);
				if(ret == (int)PlayerError.None)
				{
					ret = Interop.Player.GetCurrentTrack(_playerHandle, (int)StreamType.Video, out curTrack);
					if(ret == (int)PlayerError.None && tracks > 0)
					{
						for(int idx = 0; idx < tracks; idx++)
						{
							bool activated = (curTrack == idx ? true : false);
							ret = Interop.Player.GetTrackLanguageCode(_playerHandle, (int)StreamType.Video, idx, out langCode);
							if(ret == (int)PlayerError.None) 
							{
								SubtitleTrack st = new SubtitleTrack(langCode, activated);
								videoTrack.Add(st);
							}
							else
							{
								Log.Error(PlayerLog.LogTag, "Getting video track language code failed" + (PlayerError)ret);
							}
						}
					}
					else
					{
						Log.Error(PlayerLog.LogTag, "Getting video track index failed" + (PlayerError)ret);
					}
				}
				else
				{
					Log.Error(PlayerLog.LogTag, "Getting video track count failed" + (PlayerError)ret);
				}

				return videoTrack;
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


		private void RegisterSubtitleUpdatedEvent()
		{
			_subtitleUpdatedCallback = (uint duration, string text, IntPtr userData) =>
			{
				SubtitleUpdatedEventArgs eventArgs = new SubtitleUpdatedEventArgs(duration, text);
				_subtitleUpdated?.Invoke(this, eventArgs);
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
    }
}