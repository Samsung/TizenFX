using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
	static internal class RecorderLog
	{
		internal const string Tag = "Tizen.Multimedia.Recorder";
	}

    /// <summary>
    /// The recorder class provides methods to create audio/video recorder,
	///  to start, stop and save the recorded content. It also provides methods
	///  to get/set various attributes and capabilities of recorder.
    /// </summary>
	/// /// <privilege>
	/// http://tizen.org/privilege/recorder
	/// </privilege>
	public class Recorder : IDisposable
	{
        private IntPtr _handle;
        private bool _disposed = false;
		private RecorderAttribute _attribute = null;
		private RecorderCapability _capability = null;
		private EventHandler<RecorderStateChangedEventArgs> _recorderStateChanged;
		private Interop.Recorder.StatechangedCallback _recorderStateChangedCallback;
		private EventHandler<RecordingStatusChangedEventArgs> _recordingStatusChanged;
		private Interop.Recorder.RecordingStatusCallback _recordingStatusCallback;
		private EventHandler<RecordingLimitReachedEventArgs> _recordingLimitReached;
		private Interop.Recorder.RecordingLimitReachedCallback _recordingLimitReachedCallback;
		private EventHandler<AudioStreamDeliveredEventArgs> _audioStreamDelivered;
		private Interop.Recorder.AudioStreamCallback _audioStreamCallback;
		private EventHandler<RecorderInterruptedEventArgs> _recorderInterrupted;
		private Interop.Recorder.InterruptedCallback _interruptedCallback;
		private EventHandler<RecordingErrorOccurredEventArgs> _recordingErrorOccured;
		private Interop.Recorder.RecorderErrorCallback _recorderErrorCallback;

        /// <summary>
        /// Audio recorder constructor.
        /// </summary>
		public Recorder()
		{
			int ret = Interop.Recorder.Create (out _handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Failed to create Audio recorder");
			}

			_attribute = new RecorderAttribute (_handle);
			_capability = new RecorderCapability (_handle);
		}

        /// <summary>
        /// Video recorder constructor.
        /// </summary>
        /// <param name="camera">
        /// The camera object.
        /// </param>
        public Recorder(Camera camera)
        {
			int ret = Interop.Recorder.Create (camera, out _handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Failed to create Video recorder");
			}

			_attribute = new RecorderAttribute (_handle);
			_capability = new RecorderCapability (_handle);
        }

        /// <summary>
        /// Recorder destructor.
        /// </summary>
        ~Recorder()
        {
			Dispose (false);
        }

        /// <summary>
        /// Event that occurs when recorder is interrupted.
        /// </summary>
        public event EventHandler<RecorderInterruptedEventArgs> RecorderInterrupted
		{
			add
			{
				if (_recorderInterrupted == null)
				{
					RegisterRecorderInterruptedEvent();
				}
				_recorderInterrupted += value;
			}
			remove
			{
				_recorderInterrupted -= value;
				if (_recorderInterrupted == null)
				{
					UnregisterRecorderInterruptedEvent ();
				}
			}
		}

		/// <summary>
		/// Event that occurs when audio stream data is being delivered.
		/// </summary>
		public event EventHandler<AudioStreamDeliveredEventArgs> AudioStreamDelivered
		{
			add
			{
				if (_audioStreamDelivered == null)
				{
					RegisterAudioStreamDeliveredEvent();
				}
				_audioStreamDelivered += value;
			}
			remove
			{
				_audioStreamDelivered -= value;
				if (_audioStreamDelivered == null) 
				{
					UnregisterAudioStreamDeliveredEvent ();
				}
			}
		}

		/// <summary>
		/// This event occurs when recorder state is changed.
		/// </summary>
		public event EventHandler<RecorderStateChangedEventArgs> RecorderStateChanged
		{
			add
			{
				if (_recorderStateChanged == null)
				{
					RegisterStateChangedEvent();
				}
				_recorderStateChanged += value;
			}
			remove
			{
				_recorderStateChanged -= value;
				if (_recorderStateChanged == null) 
				{
					UnregisterStateChangedEvent ();
				}
			}
		}
			
		/// <summary>
		/// Event that occurs when recording information changes.
		/// </summary>
		public event EventHandler<RecordingStatusChangedEventArgs> RecordingStatusChanged
		{
			add
			{
				if (_recordingStatusChanged == null)
				{
					RegisterRecordingStatusChangedEvent();
				}
				_recordingStatusChanged += value;
			}
			remove
			{
				_recordingStatusChanged -= value;
				if (_recordingStatusChanged == null) 
				{
					UnregisterRecordingStatusChangedEvent ();
				}
			}
		}

		/// <summary>
		/// Event that occurs when recording limit is reached.
		/// </summary>
		public event EventHandler<RecordingLimitReachedEventArgs> RecordingLimitReached
		{
			add
			{
				if (_recordingLimitReached == null)
				{
					RegisterRecordingLimitReachedEvent();
				}
				_recordingLimitReached += value;
			}
			remove
			{
				_recordingLimitReached -= value;
				if (_recordingLimitReached == null) 
				{
					UnregisterRecordingLimitReachedEvent ();
				}
			}
		}

		/// <summary>
		/// Event that occurs when an error occurs during recorder operation.
		/// </summary>
		public event EventHandler<RecordingErrorOccurredEventArgs> RecordingErrorOccurred
		{
			add
			{
				if (_recordingErrorOccured == null)
				{
					RegisterRecordingErrorOccuredEvent();
				}
				_recordingErrorOccured += value;
			}
			remove
			{
				_recordingErrorOccured -= value;
				if (_recordingErrorOccured == null) 
				{
					UnregisterRecordingErrorOccuredEvent ();
				}
			}
		}

        /// <summary>
        /// The file path to record.
        /// </summary>
        /// <remarks>
        /// If the same file already exists in the file system, then old file
        /// will be overwritten.
        /// </remarks>
        public string FilePath
        {
            get
            {
				IntPtr val;
				int ret = Interop.Recorder.GetFileName (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get filepath, " + (RecorderError)ret);
				}
				string result = Marshal.PtrToStringAuto (val);
				Interop.Libc.Free (val);
				return result;
            }
            set
            {
				int ret = Interop.Recorder.SetFileName (_handle, value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set filepath, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret, "Failed to set filepath");
				}
            }
        }

        /// <summary>
        /// Get the peak audio input level in dB
        /// </summary>
        /// <remarks>
        /// 0dB indicates maximum input level, -300dB indicates minimum input level.
        /// </remarks>
        public double AudioLevel
        {
            get
            {
				double level = 0;

				int ret = Interop.Recorder.GetAudioLevel (_handle, out level);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get Audio level, " + (RecorderError)ret);
				}
				return level;
            }
        }

        /// <summary>
        /// The current state of the recorder.
        /// </summary>
        public RecorderState State
        {
            get
            {
				int val = 0;

				int ret = Interop.Recorder.GetState (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get recorder state, " + (RecorderError)ret);
				}
				return (RecorderState)val;
            }
        }

        /// <summary>
        /// The file format for recording media stream.
        /// </summary>
        public RecorderFileFormat FileFormat
        {
            get
            {
				int val = 0;

				int ret = Interop.Recorder.GetFileFormat (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get file format, " + (RecorderError)ret);
				}
				return (RecorderFileFormat)val;
            }
            set
            {
				int ret = Interop.Recorder.SetFileFormat (_handle, (int)value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set file format, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret);
				}
            }
        }

        /// <summary>
        /// The audio codec for encoding an audio stream.
        /// </summary>
        public RecorderAudioCodec AudioCodec
        {
            get
            {
				int val = 0;

				int ret = Interop.Recorder.GetAudioEncoder (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to get audio codec, " + (RecorderError)ret);
				}
				return (RecorderAudioCodec)val;
            }
            set
            {
				int ret = Interop.Recorder.SetAudioEncoder (_handle, (int)value);
				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error (RecorderLog.Tag, "Failed to set audio codec, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException (ret);
				}
            }
        }

        /// <summary>
        /// The video codec for encoding video stream.
        /// </summary>
        public RecorderVideoCodec VideoCodec
        {
            get
            {
				int val = 0;

				int ret = Interop.Recorder.GetVideoEncoder (_handle, out val);
				if ((RecorderError)ret != RecorderError.None)
				{
						Log.Error( RecorderLog.Tag, "Failed to get video codec, " + (RecorderError)ret);
				}
				return (RecorderVideoCodec)val;
            }
            set
            {
				int ret = Interop.Recorder.SetVideoEncoder (_handle, (int)value);

				if ((RecorderError)ret != RecorderError.None)
				{
					Log.Error(RecorderLog.Tag, "Failed to set video codec, " + (RecorderError)ret);
					RecorderErrorFactory.ThrowException(ret);
				}
            }
        }

        /// <summary>
        /// The various attributes of audio recorder.
        /// </summary>
        public RecorderAttribute Attribute
        {
            get
            {
				return _attribute;
            }
        }

        /// <summary>
        /// The various capabilites of recorder.
        /// </summary>
        public RecorderCapability Capability
        {
            get
            {
				return _capability;
            }
        }

        /// <summary>
        /// Video resolution of the video recording.
        /// </summary>
        public VideoResolution Resolution
        {
            get
            {
                return null;
            }
        }

		/// <summary>
		/// Prepare the media recorder for recording.
		/// </summary>
		/// <remarks>
		/// Before calling the function, it is required to set AudioEncoder,
		/// videoencoder and fileformat properties of recorder.
		/// </remarks>
		/// <privilege>
		/// http://tizen.org/privilege/recorder
		/// </privilege>
		public void Prepare()
		{
			int ret = Interop.Recorder.Prepare (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Failed to prepare media recorder for recording");
			}
		}

		/// <summary>
		/// Resets the media recorder.
		/// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/recorder
		/// </privilege>
		public void Unprepare()
		{
			int ret = Interop.Recorder.Unprepare (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Failed to reset the media recorder");
			}
		}

		/// <summary>
		/// Starts the recording.
		/// </summary>
		/// <remarks>
		/// If file path has been set to an existing file, this file is removed automatically and updated by new one.
		/// In the video recorder, some preview format does not support record mode. It will return InvalidOperation error.
		///	You should use default preview format or CameraPixelFormatNv12 in the record mode.
		///	The filename should be set before this function is invoked.
		/// </remarks>
		/// <privilege>
		/// http://tizen.org/privilege/recorder
		/// </privilege>
		public void Start()
		{
			int ret = Interop.Recorder.Start (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Failed to start the media recorder");
			}
		}

		/// <summary>
		/// Pause the recording.
		/// </summary>
		/// <remarks>
		/// Recording can be resumed with Start().
		/// </remarks>
		/// <privilege>
		/// http://tizen.org/privilege/recorder
		/// </privilege>
		public void Pause()
		{
			int ret = Interop.Recorder.Pause (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Failed to pause the media recorder");
			}
		}

		/// <summary>
		/// Stops recording and saves the result.
		/// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/recorder
		/// </privilege>
		public void Commit()
		{
			int ret = Interop.Recorder.Commit (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Failed to save the recorded content");
			}
		}

		/// <summary>
		/// Cancels the recording.
		/// The recording data is discarded and not written in the recording file.
		/// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/recorder
		/// </privilege>
		public void Cancel()
		{
			int ret = Interop.Recorder.Cancel (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Failed to cancel the recording");
			}
		}

		/// <summary>
		/// Sets the audio stream policy.
		/// </summary>
		/// <param name="policy">Policy.</param>
		public void SetAudioStreamPolicy(AudioStreamPolicy policy)
		{
			int ret = Interop.Recorder.SetAudioStreamPolicy (_handle, policy.Handle);

			if (ret != (int)RecorderError.None) 
			{
				RecorderErrorFactory.ThrowException (ret, "Failed to set audio stream policy");
			}
     	}
			
		/// <summary>
		/// Release any unmanaged resources used by this object.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		/// <summary>
		/// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
		/// </summary>
		/// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
                    // to be used if there are any other disposable objects
				}
				if (_handle != IntPtr.Zero)
				{
					Interop.Recorder.Destroy (_handle);
					_handle = IntPtr.Zero;
				}
				_disposed = true;
			}
		}

		private void RegisterRecorderInterruptedEvent()
		{
			_interruptedCallback = (RecorderPolicy policy, RecorderState previous, RecorderState current, IntPtr userData) =>
			{
				RecorderInterruptedEventArgs eventArgs = new RecorderInterruptedEventArgs(policy, previous, current);
				_recorderInterrupted?.Invoke(this, eventArgs);
			};
			int ret = Interop.Recorder.SetInterruptedCallback (_handle, _interruptedCallback, IntPtr.Zero);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Setting Interrupted callback failed");
			}
		}

		private void UnregisterRecorderInterruptedEvent()
		{
			int ret = Interop.Recorder.UnsetInterruptedCallback (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Unsetting Interrupted callback failed");
			}
		}

		private void RegisterAudioStreamDeliveredEvent()
		{
			_audioStreamCallback = (IntPtr stream, int size, AudioSampleType type, int channel, uint recordingTime, IntPtr userData) =>
			{
				byte[] streamArray = new byte[size];
				Marshal.Copy(stream, streamArray, 0, size);
				AudioStreamDeliveredEventArgs eventArgs = new AudioStreamDeliveredEventArgs(streamArray, type, channel, recordingTime);
				_audioStreamDelivered?.Invoke(this, eventArgs);
			};
			int ret = Interop.Recorder.SetAudioStreamCallback (_handle, _audioStreamCallback, IntPtr.Zero);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Setting audiostream callback failed");
			}
		}

		private void UnregisterAudioStreamDeliveredEvent()
		{
			int ret = Interop.Recorder.UnsetAudioStreamCallback (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Unsetting audiostream callback failed");
			}
		}

		private void RegisterStateChangedEvent()
		{
			_recorderStateChangedCallback = (RecorderState previous, RecorderState current, bool byPolicy, IntPtr userData) =>
			{
				RecorderStateChangedEventArgs eventArgs = new RecorderStateChangedEventArgs(previous, current, byPolicy);
				_recorderStateChanged?.Invoke(this, eventArgs);
			};
			int ret = Interop.Recorder.SetStateChangedCallback (_handle, _recorderStateChangedCallback , IntPtr.Zero);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Setting state changed callback failed");
			}
		}

		private void UnregisterStateChangedEvent()
		{
			int ret = Interop.Recorder.UnsetStateChangedCallback (_handle);	
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Unsetting state changed callback failed");
			}
		}

		private void RegisterRecordingStatusChangedEvent()
		{
			_recordingStatusCallback = (ulong elapsedTime, ulong fileSize, IntPtr userData) =>
			{
				RecordingStatusChangedEventArgs eventArgs = new RecordingStatusChangedEventArgs(elapsedTime, fileSize);
				_recordingStatusChanged?.Invoke(this, eventArgs);
			};
			int ret = Interop.Recorder.SetStatusChangedCallback (_handle, _recordingStatusCallback, IntPtr.Zero);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Setting status changed callback failed");
			}
		}

		private void UnregisterRecordingStatusChangedEvent()
		{
			int ret = Interop.Recorder.UnsetStatusChangedCallback (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Unsetting status changed callback failed");
			}
		}

		private void RegisterRecordingLimitReachedEvent()
		{
			_recordingLimitReachedCallback = (RecordingLimitType type, IntPtr userData) =>
			{
				RecordingLimitReachedEventArgs eventArgs = new RecordingLimitReachedEventArgs(type);
				_recordingLimitReached?.Invoke(this, eventArgs);
			};
			int ret = Interop.Recorder.SetLimitReachedCallback (_handle, _recordingLimitReachedCallback, IntPtr.Zero);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Setting limit reached callback failed");
			}
		}

		private void UnregisterRecordingLimitReachedEvent()
		{
			int ret = Interop.Recorder.UnsetLimitReachedCallback (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException(ret, "Unsetting limit reached callback failed");
			}
		}

		private void RegisterRecordingErrorOccuredEvent()
		{
			_recorderErrorCallback = (RecorderErrorCode error, RecorderState current, IntPtr userData) =>
			{
				RecordingErrorOccurredEventArgs eventArgs = new RecordingErrorOccurredEventArgs(error, current);
				_recordingErrorOccured?.Invoke(this, eventArgs);
			};
			int ret = Interop.Recorder.SetErrorCallback (_handle, _recorderErrorCallback, IntPtr.Zero);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Setting Error callback failed");
			}
		}

		private void UnregisterRecordingErrorOccuredEvent()
		{
			int ret = Interop.Recorder.UnsetErrorCallback (_handle);
			if (ret != (int)RecorderError.None)
			{
				RecorderErrorFactory.ThrowException (ret, "Unsetting Error callback failed");
			}
		}
	}
}

