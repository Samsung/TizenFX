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
using System.Runtime.InteropServices;
using Tizen.Applications;

namespace Tizen.Multimedia.MediaController
{

	/// <summary>
	/// The MediaControllerServer class provides APIs required for media-controller-server.
	/// </summary>
	/// <remarks>
	/// The MediaControllerServer APIs provides functions to 
	/// </remarks>
	public class MediaControllerServer : IDisposable
	{
		internal IntPtr _handle = IntPtr.Zero;

		private bool _disposed = false;
		private EventHandler<PlaybackStateCommandEventArgs> _playbackCommand;
		private Interop.MediaControllerServer.PlaybackStateCommandRecievedCallback _playbackCommandCallback;
		private EventHandler<CustomCommandEventArgs> _customCommand;
		private Interop.MediaControllerServer.CustomCommandRecievedCallback _customCommandCallback;

		public MediaControllerServer ()
		{
			MediaControllerError res = MediaControllerError.None;
			res = (MediaControllerError)Interop.MediaControllerServer.Create (out _handle);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Create server failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Create server failed");
			}
		}

		~MediaControllerServer ()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if(!_disposed)
			{
				if(disposing)
				{
					// To be used if there are any other disposable objects
				}
				if(_handle != IntPtr.Zero)
				{
					Interop.MediaControllerServer.Destroy(_handle);
					_handle = IntPtr.Zero;
				}
				_disposed = true;
			}
		}

		/// <summary>
		/// PlaybackStateCommandRecieved event is raised when client send command for playback
		/// </summary>
		public event EventHandler<PlaybackStateCommandEventArgs> PlaybackStateCommand
		{
			add
			{
				if(_playbackCommand == null)
				{
					RegisterPlaybackCmdRecvEvent();
				}
				_playbackCommand += value;

			}
			remove
			{
				_playbackCommand -= value;
				if(_playbackCommand == null)
				{
					UnregisterPlaybackCmdRecvEvent();
				}
			}
		}

		/// <summary>
		/// CustomCommandRecieved event is raised when client send customized command
		/// </summary>
		public event EventHandler<CustomCommandEventArgs> CustomCommand
		{
			add
			{
				if(_customCommand == null)
				{
					RegisterCustomCommandEvent();
				}
				_customCommand += value;

			}
			remove
			{
				_customCommand -= value;
				if(_customCommand == null)
				{
					UnregisterCustomCommandEvent();
				}
			}
		}

		/// <summary>
		/// Update playback state and playback position</summary>
		/// <param name="playback"> playback state and playback position  </param>
		public void UpdatePlayback(MediaControllerPlayback playback)
		{
			MediaControllerError res = MediaControllerError.None;
			res = (MediaControllerError)Interop.MediaControllerServer.SetPlaybackState(_handle, (int)playback.State);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Playback state failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Playback state failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.SetPlaybackPosition(_handle, playback.Position);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Playback position failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Playback position failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.UpdatePlayback(_handle);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Update Playback failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Update Playback failed");
			}
		}

		/// <summary>
		/// Update metadata information </summary>
		/// <param name="metadata"> metadata information  </param>
		public void UpdateMetadata(MediaControllerMetadata metadata)
		{
			MediaControllerError res = MediaControllerError.None;
			res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Title, metadata.Title);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Artist, metadata.Artist);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Album, metadata.Album);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Author, metadata.Author);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

            res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Genre, metadata.Genre);
            if (res != MediaControllerError.None)
            {
                Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
                MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
            }

            res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Duration, metadata.Duration);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Date, metadata.Date);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Copyright, metadata.Copyright);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Description, metadata.Description);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.TrackNumber, metadata.TrackNumber);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.SetMetadata(_handle, (int)MediaControllerAttributes.Picture, metadata.Picture);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Set Title failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Set Title failed");
			}

			res = (MediaControllerError)Interop.MediaControllerServer.UpdateMetadata(_handle);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Update Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Update Metadata failed");
			}
		}

		/// <summary>
		/// Update shuffle mode </summary>
		/// <param name="mode"> shuffle mode  </param>
		public void UpdateShuffleMode(MediaControllerShuffleMode mode)
		{
			MediaControllerError res = MediaControllerError.None;
			res = (MediaControllerError)Interop.MediaControllerServer.UpdateShuffleMode(_handle, (int)mode);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Update Shuffle Mode failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Update Shuffle Mode failed");
			}
		}

		/// <summary>
		/// Update repeat mode </summary>
		/// <param name="mode"> repeat mode  </param>
		public void UpdateRepeatMode(MediaControllerRepeatMode mode)
		{
			MediaControllerError res = MediaControllerError.None;
			res = (MediaControllerError)Interop.MediaControllerServer.UpdateRepeatMode(_handle, (int)mode);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Update Repeat Mode failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Update Repeat Mode failed");
			}
		}

		/// <summary>
		/// Send reply for command from server to client </summary>
		/// <param name="clientName"> client name to recieve reply  </param>
		/// <param name="result"> result to run command  </param>
		/// <param name="bundleData"> Bundle data  </param>
		public void SendCustomCommandReply(string clientName, int result, Bundle bundle)
		{
			MediaControllerError res = MediaControllerError.None;
			res = (MediaControllerError)Interop.MediaControllerServer.SendCommandReply (_handle, clientName, result, bundle.SafeBundleHandle);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Send reply for command failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Send reply for command failed");
			}
		}

		private void RegisterPlaybackCmdRecvEvent()
		{
			_playbackCommandCallback = (string clientName, int state, IntPtr userData) =>
			{
				PlaybackStateCommandEventArgs eventArgs = new PlaybackStateCommandEventArgs(clientName, (MediaControllerPlaybackState)state);
				_playbackCommand?.Invoke(this, eventArgs);
			};
			Interop.MediaControllerServer.SetPlaybackStateCmdRecvCb(_handle, _playbackCommandCallback, IntPtr.Zero);
		}

		private void UnregisterPlaybackCmdRecvEvent()
		{
			Interop.MediaControllerServer.UnsetPlaybackStateCmdRecvCb(_handle);
		}

		private void RegisterCustomCommandEvent()
		{
			_customCommandCallback = (string clientName, string command, IntPtr bundle, IntPtr userData) =>
			{
				SafeBundleHandle bundleHandle = new SafeBundleHandle(bundle, true);
				Applications.Bundle _bundle = new Bundle(bundleHandle);
				CustomCommandEventArgs eventArgs = new CustomCommandEventArgs(clientName, command, _bundle);
				_customCommand?.Invoke(this, eventArgs);
			};
			Interop.MediaControllerServer.SetCustomCmdRecvCb(_handle, _customCommandCallback, IntPtr.Zero);
		}

		private void UnregisterCustomCommandEvent()
		{
			Interop.MediaControllerServer.UnsetCustomCmdRecvCb(_handle);
		}
	}
}

