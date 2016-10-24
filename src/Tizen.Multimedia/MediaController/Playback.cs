/// Playback
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Multimedia.MediaController
{
    /// <summary>
	/// Playback represents a playback state and playback position.
	/// </summary>
	public class Playback
	{
		public Playback(PlaybackState state, ulong position) {
			State = state;
			Position = position;
		}

		internal Playback(IntPtr _playbackHandle) {
			MediaControllerError res = MediaControllerError.None;
			int _state = 0;
			ulong _position = 0L;

			res = (MediaControllerError)Interop.MediaControllerClient.GetPlaybackState(_playbackHandle, out _state);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Playback state failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Playback state failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetPlaybackPosition(_playbackHandle, out _position);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Playback position failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Playback position failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.DestroyPlayback(_playbackHandle);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Destroy Playback handle failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Destroy Playback handle failed");
			}
			State = (PlaybackState)_state;
			Position = _position;
		}

       /// <summary>
       /// The state of playback of media application
       /// </summary>
		public PlaybackState State;

		/// <summary>
		/// The position of playback of media application
		/// </summary>
		public ulong Position;
	}
}

