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

