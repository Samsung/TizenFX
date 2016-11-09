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
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
	static internal class MetadataExtractorLog
	{
		internal const string LogTag = "Tizen.Multimedia.MetadataExtractor";
	}
	/// <summary>
	/// The Metadata extractor class provides a set of functions to get the metadata of the input media file
	/// </summary>
	public class MetadataExtractor : IDisposable
	{
		private bool _disposed = false;
		internal IntPtr _handle = IntPtr.Zero;
		/// <summary>
		/// Metadata extractor constructor
		/// </summary>
		/// <param name="path"> the path to extract metadata </param>
		public MetadataExtractor(string path)
		{
			int ret;

			if (path == null)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Path is NULL");
				MetadataExtractorErrorFactory.ThrowException((int)MetadataExtractorError.InvalidParameter, "Path is NULL");
			}
			else
			{
				ret = Interop.MetadataExtractor.Create(out _handle);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to create metadata" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to create metadata");
				}
				ret = Interop.MetadataExtractor.SetPath(_handle, path);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to set path" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to set path");
				}
			}
		}
		/// <summary>
		/// Metadata extractor constructor
		/// </summary>
		/// <param name="buffer"> the buffer to extract metadata </param>
		public MetadataExtractor(byte[] buffer)
		{
			int ret;

			if (buffer == null || buffer.Length == 0)
			{
				Log.Error(MetadataExtractorLog.LogTag, "buffer is null");
				MetadataExtractorErrorFactory.ThrowException((int)MetadataExtractorError.InvalidParameter, "buffer is null");
			}
			else
            {
                int size = buffer.Length;
                IntPtr buf = Marshal.AllocHGlobal(size);
                Marshal.Copy(buffer, 0, buf, size);

				ret = Interop.MetadataExtractor.Create(out _handle);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to create metadata" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to create metadata");
				}

				ret = Interop.MetadataExtractor.SetBuffer(_handle, buf, size);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to set buffer" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to set buffer");
				}
			}
			
		}
		/// <summary>
		/// Gets metadata
		/// </summary>
		/// <value> Metadata object </value>
		/// <exception cref="InvalidOperationException"> When internal process error is occured</exception>
		public Metadata GetMetadata()
		{
			int ret;
			Metadata _metadata;
			MetadataBundle _metaBundle = new MetadataBundle();

			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_DURATION, out _metaBundle.Duration);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_HAS_VIDEO, out _metaBundle.Videostreamcount);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			if (_metaBundle.Videostreamcount == null || (_metaBundle.Videostreamcount != null && !_metaBundle.Videostreamcount.Equals("0")))
			{
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_VIDEO_BITRATE, out _metaBundle.VideoBitrate);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_VIDEO_FPS, out _metaBundle.VideoFPS);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_VIDEO_WIDTH, out _metaBundle.VideoWidth);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_VIDEO_HEIGHT, out _metaBundle.VideoHeight);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_VIDEO_CODEC, out _metaBundle.VideoCodec);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
			}

			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_HAS_AUDIO, out _metaBundle.Audiostreamcount);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			if (_metaBundle.Audiostreamcount == null || (_metaBundle.Audiostreamcount != null && !_metaBundle.Audiostreamcount.Equals("0")))
			{
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_AUDIO_BITRATE, out _metaBundle.AudioBitrate);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_AUDIO_CHANNELS, out _metaBundle.AudioChannels);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_AUDIO_SAMPLERATE, out _metaBundle.AudioSamplerate);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_AUDIO_BITPERSAMPLE, out _metaBundle.Audiobitpersample);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
				ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_AUDIO_CODEC, out _metaBundle.AudioCodec);
				if (ret != (int)MetadataExtractorError.None)
				{
					Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
					MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
				}
			}

			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_ARTIST, out _metaBundle.Artist);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_TITLE, out _metaBundle.Title);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_ALBUM, out _metaBundle.Album);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_ALBUM_ARTIST, out _metaBundle.AlbumArtist);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_GENRE, out _metaBundle.Genre);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_AUTHOR, out _metaBundle.Author);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_COPYRIGHT, out _metaBundle.Copyright);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_DATE, out _metaBundle.Date);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_DESCRIPTION, out _metaBundle.Description);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_COMMENT, out _metaBundle.Comment);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_TRACK_NUM, out _metaBundle.Tracknumber);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_CLASSIFICATION, out _metaBundle.Classification);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_RATING, out _metaBundle.Rating);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_LONGITUDE, out _metaBundle.Longitude);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_LATITUDE, out _metaBundle.Latitude);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_ALTITUDE, out _metaBundle.Altitude);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_CONDUCTOR, out _metaBundle.Conductor);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_UNSYNCLYRICS, out _metaBundle.Unsynclyric);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_SYNCLYRICS_NUM, out _metaBundle.SyncLyricNumber);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_RECDATE, out _metaBundle.Recordingdate);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_ROTATE, out _metaBundle.Rotate);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}
			ret = Interop.MetadataExtractor.GetMetadata(_handle, (int)MetadataExtractorAttr.METADATA_360, out _metaBundle.content360);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}

			_metadata = new Metadata(_metaBundle);

			return _metadata;
		}
		/// <summary>
		/// Gets the artwork image in a media file
		/// </summary>
		/// <value> Artwork object </value>
		/// <exception cref="InvalidOperationException"> When internal process error is occured</exception>
		public Artwork GetArtwork()
		{
			int ret;
			Artwork _artwork;
			IntPtr getArtworkData;
			int getSize;
			byte[] tmpBuf;
			string getMimeType;

			ret = Interop.MetadataExtractor.GetArtwork(_handle, out getArtworkData, out getSize, out getMimeType);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}

			if (getSize > 0)
			{
				tmpBuf = new byte[getSize];
				Marshal.Copy(getArtworkData, tmpBuf, 0, getSize);

				_artwork = new Artwork(tmpBuf, getMimeType);
			}
			else
			{
				_artwork = new Artwork(null, null);
			}

			return _artwork;
		}
		/// <summary>
		/// Gets the synclyrics of a media file
		/// </summary>
		/// <param name="index"> The index of time/lyrics to set </param>
		/// <value> Synclyrics object </value>
		/// <exception cref="ArgumentException"> When the invalid parameter value is set.</exception>
		/// <exception cref="InvalidOperationException"> When internal process error is occured</exception>
		public Synclyrics GetSynclyrics(int index)
		{
			int ret;
			Synclyrics _lyrics;
			uint getTimestamp;
			string getLyrics;

			ret = Interop.MetadataExtractor.GetSynclyrics(_handle, index, out getTimestamp, out getLyrics);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}

			_lyrics = new Synclyrics(getLyrics, getTimestamp);

			return _lyrics;
		}
		/// <summary>
		/// Gets the frame of a video media file
		/// </summary>
		/// <value> Frame object </value>
		/// <exception cref="InvalidOperationException"> When internal process error is occured</exception>
		public Frame GetFrame()
		{
			int ret;
			Frame _frame;
			IntPtr getFameData;
			int getSize;
			byte[] tmpBuf;

			ret = Interop.MetadataExtractor.GetFrame(_handle, out getFameData, out getSize);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}

			tmpBuf = new byte[getSize];
			Marshal.Copy(getFameData, tmpBuf, 0, getSize);

			_frame = new Frame(tmpBuf);

			return _frame;
		}
		/// <summary>
		/// Gets the frame of a video media
		/// </summary>
		/// <param name="timeStamp"> The timestamp in milliseconds </param>
		/// <param name="accurate"> If @c true the user can get an accurate frame for the given timestamp,\n
		///						 otherwise @c false if the user can only get the nearest i-frame of the video rapidly </param>
		/// <value> Frame object </value>
		/// <exception cref="ArgumentException"> When the invalid parameter value is set.</exception>
		/// <exception cref="InvalidOperationException"> When internal process error is occured</exception>
		public Frame GetFrameAtTime(uint timeStamp, bool accurate)
		{
			int ret;
			Frame _frame;
			IntPtr getFameData;
			int getSize;
			byte[] tmpBuf;

			ret = Interop.MetadataExtractor.GetFrameAtTime(_handle, timeStamp, accurate, out getFameData, out getSize);
			if (ret != (int)MetadataExtractorError.None)
			{
				Log.Error(MetadataExtractorLog.LogTag, "Failed to get value" + (MetadataExtractorError)ret);
				MetadataExtractorErrorFactory.ThrowException(ret, "Failed to get value");
			}

			tmpBuf = new byte[getSize];
			Marshal.Copy(getFameData, tmpBuf, 0, getSize);

			_frame = new Frame(tmpBuf);

			return _frame;
		}
		
		/// <summary>
		/// Metadata Extractor destructor
		/// </summary>
		~MetadataExtractor()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					// To be used if there are any other disposable objects
				}
				if (_handle != IntPtr.Zero)
				{
					Interop.MetadataExtractor.Destroy(_handle);
					_handle = IntPtr.Zero;
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
