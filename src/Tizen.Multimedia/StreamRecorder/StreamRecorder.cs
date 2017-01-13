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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    static internal class StreamRecorderLog
    {
        internal const string Tag = "Tizen.Multimedia.StreamRecorder";
    }

    /// <summary>
    /// The stream recorder class provides methods to create stream recorder,
    /// to start, stop and save the pushed content.
    /// </summary>
    public class StreamRecorder : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed = false;
        private EventHandler<RecordingStatusChangedEventArgs> _recordingStatusChanged;
        private Interop.StreamRecorder.RecordingStatusCallback _recordingStatusCallback;
        private EventHandler<StreamRecordingLimitReachedEventArgs> _recordingLimitReached;
        private Interop.StreamRecorder.RecordingLimitReachedCallback _recordingLimitReachedCallback;
        private EventHandler<StreamRecordingBufferConsumedEventArgs> _bufferConsumed;
        private Interop.StreamRecorder.BufferConsumedCallback _bufferConsumedCallback;
        private EventHandler<StreamRecorderNotifiedEventArgs> _recorderNotified;
        private Interop.StreamRecorder.NotifiedCallback _notifiedCallback;
        private EventHandler<StreamRecordingErrorOccurredEventArgs> _recordingErrorOccurred;
        private Interop.StreamRecorder.RecorderErrorCallback _recorderErrorCallback;
        private List<StreamRecorderFileFormat> _formats;
        private List<StreamRecorderAudioCodec> _audioCodec;
        private List<StreamRecorderVideoCodec> _videoCodec;
        private List<StreamRecorderVideoResolution> _resolutions;
        StreamRecorderVideoResolution _videoResolution = null;

        /// <summary>
        /// Stream recorder constructor.
        /// </summary>
        public StreamRecorder()
        {
            int ret = Interop.StreamRecorder.Create (out _handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Failed to create stream recorder");
            }
            _formats = new List<StreamRecorderFileFormat>();
            _audioCodec = new List<StreamRecorderAudioCodec>();
            _videoCodec = new List<StreamRecorderVideoCodec> ();
            _resolutions = new List<StreamRecorderVideoResolution> ();
            _videoResolution = new StreamRecorderVideoResolution (_handle);
        }

        /// <summary>
        /// Stream recorder destructor.
        /// </summary>
        ~StreamRecorder()
        {
            Dispose (false);
        }

        /// <summary>
        /// Event that occurs when recorder is interrupted.
        /// </summary>
        public event EventHandler<StreamRecorderNotifiedEventArgs> RecorderNotified
        {
            add
            {
                if (_recorderNotified == null)
                {
                    RegisterStreamRecorderNotifiedEvent();
                }
                _recorderNotified += value;
            }
            remove
            {
                _recorderNotified -= value;
                if (_recorderNotified == null)
                {
                    UnregisterStreamRecorderNotifiedEvent ();
                }
            }
        }

        /// <summary>
        /// Event that occurs when buffer had comsumed completely.
        /// </summary>
        public event EventHandler<StreamRecordingBufferConsumedEventArgs> BufferConsumed
        {
            add
            {
                if (_bufferConsumed == null)
                {
                    RegisterBufferComsumedEvent();
                }
                _bufferConsumed += value;
            }
            remove
            {
                _bufferConsumed -= value;
                if (_bufferConsumed == null)
                {
                    UnregisterBufferComsumedEvent ();
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
        public event EventHandler<StreamRecordingLimitReachedEventArgs> RecordingLimitReached
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
        public event EventHandler<StreamRecordingErrorOccurredEventArgs> RecordingErrorOccurred
        {
            add
            {
                if (_recordingErrorOccurred == null)
                {
                    RegisterRecordingErrorOccurredEvent();
                }
                _recordingErrorOccurred += value;
            }
            remove
            {
                _recordingErrorOccurred -= value;
                if (_recordingErrorOccurred == null)
                {
                    UnregisterRecordingErrorOccurredEvent ();
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
                int ret = Interop.StreamRecorder.GetFileName (_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get filepath, " + (StreamRecorderError)ret);
                }
                string result = Marshal.PtrToStringAnsi (val);
                Interop.Libc.Free (val);
                return result;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetFileName (_handle, value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set filepath, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException (ret, "Failed to set filepath");
                }
            }
        }

        /// <summary>
        /// The current state of the stream recorder.
        /// </summary>
        public StreamRecorderState State
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetState (_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get stream recorder state, " + (StreamRecorderError)ret);
                }
                return (StreamRecorderState)val;
            }
        }

        /// <summary>
        /// The file format for recording media stream.
        /// </summary>
        public StreamRecorderFileFormat FileFormat
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetFileFormat (_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get file format, " + (StreamRecorderError)ret);
                }
                return (StreamRecorderFileFormat)val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetFileFormat (_handle, (int)value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set file format, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException (ret);
                }
            }
        }

        /// <summary>
        /// The audio codec for encoding an audio stream.
        /// </summary>
        public StreamRecorderAudioCodec AudioCodec
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetAudioEncoder (_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get audio codec, " + (StreamRecorderError)ret);
                }
                return (StreamRecorderAudioCodec)val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetAudioEncoder (_handle, (int)value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set audio codec, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException (ret);
                }
            }
        }

        /// <summary>
        /// The video codec for encoding video stream.
        /// </summary>
        public StreamRecorderVideoCodec VideoCodec
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetVideoEncoder (_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get video codec, " + (StreamRecorderError)ret);
                }
                return (StreamRecorderVideoCodec)val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetVideoEncoder (_handle, (int)value);

                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set video codec, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException(ret);
                }
            }
        }

        /// <summary>
        /// The maximum size of a recording file in KB(kilobytes). If 0, means
        /// unlimited recording size.
        /// </summary>
        /// <remarks>
        /// After reaching the limitation, the data which is being recorded will
        /// be discarded and not written to the file.
        /// The recorder state must be in 'Prepared' or 'Created' state.
        /// </remarks>
        ///
        public int SizeLimit
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetRecordingLimit (_handle, 1, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get size limit, " + (StreamRecorderError)ret);
                }
                return val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetRecordingLimit (_handle, 1, value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set sizelimit, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException (ret, "Failed to set size limit");
                }
            }
        }

        /// <summary>
        /// The time limit of a recording file in Seconds. If 0, means unlimited recording
        /// time.
        /// </summary>
        /// <remarks>
        /// After reaching the limitation, the data which is being recorded will
        /// be discarded and not written to the file.
        /// The recorder state must be in 'Prepared' or 'Created' state.
        /// </remarks>
        public int TimeLimit
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetRecordingLimit (_handle, 0, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get time limit, " + (StreamRecorderError)ret);
                }
                return val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetRecordingLimit (_handle, 0, value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set timelimit, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException (ret, "Failed to set time limit");
                }
            }
        }

        /// <summary>
        /// The sampling rate of an audio stream in hertz.
        /// </summary>
        public int AudioSampleRate
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetAudioSampleRate (_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get audio samplerate, " + (StreamRecorderError)ret);
                }
                return val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetAudioSampleRate (_handle, value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set audio samplerate, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException (ret, "Failed to set audio samplerate");
                }
            }
        }

        /// <summary>
        /// The bitrate of an audio encoder in bits per second.
        /// </summary>
        public int AudioBitRate
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetAudioEncoderBitrate (_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get audio bitrate, " + (StreamRecorderError)ret);
                }
                return val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetAudioEncoderBitrate (_handle, value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set audio bitrate, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException (ret, "Failed to set audio bitrate");
                }
            }
        }

        /// <summary>
        /// The bitrate of an video encoder in bits per second.
        /// </summary>
        public int VideoBitRate
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetVideoEncoderBitrate (_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get video bitrate, " + (StreamRecorderError)ret);
                }
                return val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetVideoEncoderBitrate (_handle, value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set video bitrate, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException (ret, "Failed to set video bitrate");
                }
            }
        }

        /// <summary>
        /// The video frame rate for recording media stream.
        /// </summary>
        public int VideoFrameRate
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetVideoFramerate(_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error(StreamRecorderLog.Tag, "Failed to get video framerate, " + (StreamRecorderError)ret);
                }
                return val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetVideoFramerate(_handle, value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error(StreamRecorderLog.Tag, "Failed to set video framerate, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException(ret);
                }
            }
        }

        /// <summary>
        /// The video frame rate for recording media stream.
        /// </summary>
        public StreamRecorderVideoSourceFormat VideoSourceFormat
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetVideoSourceFormat(_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error(StreamRecorderLog.Tag, "Failed to get video framerate, " + (StreamRecorderError)ret);
                }
                return (StreamRecorderVideoSourceFormat)val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetVideoSourceFormat(_handle, (int)value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error(StreamRecorderLog.Tag, "Failed to set video framerate, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException(ret);
                }
            }
        }

        /// <summary>
        /// The number of audio channel.
        /// </summary>
        /// <remarks>
        /// The attribute is applied only in Created state.
        /// For mono recording, set channel to 1.
        /// For stereo recording, set channel to 2.
        /// </remarks>
        public int AudioChannel
        {
            get
            {
                int val = 0;

                int ret = Interop.StreamRecorder.GetAudioChannel (_handle, out val);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to get audio channel, " + (StreamRecorderError)ret);
                }
                return val;
            }
            set
            {
                int ret = Interop.StreamRecorder.SetAudioChannel (_handle, value);
                if ((StreamRecorderError)ret != StreamRecorderError.None)
                {
                    Log.Error (StreamRecorderLog.Tag, "Failed to set audio channel, " + (StreamRecorderError)ret);
                    StreamRecorderErrorFactory.ThrowException (ret, "Failed to set audio channel");
                }
            }
        }

        /// <summary>
        /// Video resolution of the video recording.
        /// </summary>
        public StreamRecorderVideoResolution Resolution
        {
            get
            {
                return _videoResolution;
            }
        }

        /// <summary>
        /// Retrieves all the file formats supported by the stream recorder.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported file
        /// formats by Stream recorder.
        /// </returns>
        public IEnumerable<StreamRecorderFileFormat> SupportedFileFormats
        {
            get
            {
                if (_formats.Count == 0)
                {
                    Interop.StreamRecorder.FileFormatCallback callback = (StreamRecorderFileFormat format, IntPtr userData) =>
                    {
                        _formats.Add (format);
                        return true;
                    };
                    int ret = Interop.StreamRecorder.FileFormats (_handle, callback, IntPtr.Zero);
                    if (ret != (int)StreamRecorderError.None)
                    {
                        StreamRecorderErrorFactory.ThrowException (ret, "Failed to get the supported fileformats");
                    }
                }
                return _formats;
            }
        }

        /// <summary>
        /// Retrieves all the audio encoders supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported audio encoders
        /// by recorder.
        /// </returns>
        public IEnumerable<StreamRecorderAudioCodec> SupportedAudioEncodings
        {
            get
            {
                if (_audioCodec.Count == 0)
                {
                    Interop.StreamRecorder.AudioEncoderCallback callback = (StreamRecorderAudioCodec codec, IntPtr userData) =>
                    {
                        _audioCodec.Add(codec);
                        return true;
                    };
                    int ret = Interop.StreamRecorder.AudioEncoders (_handle, callback, IntPtr.Zero);
                    if (ret != (int)StreamRecorderError.None)
                    {
                        StreamRecorderErrorFactory.ThrowException (ret, "Failed to get the supported audio encoders");
                    }
                }
                return _audioCodec;
            }
        }

        /// <summary>
        /// Retrieves all the video encoders supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported video encoders
        /// by recorder.
        /// </returns>
        public IEnumerable<StreamRecorderVideoCodec> SupportedVideoEncodings
        {
            get
            {
                if (_videoCodec.Count == 0)
                {
                    Interop.StreamRecorder.VideoEncoderCallback callback = (StreamRecorderVideoCodec codec, IntPtr userData) =>
                    {
                        _videoCodec.Add(codec);
                        return true;
                    };
                    int ret = Interop.StreamRecorder.VideoEncoders (_handle, callback, IntPtr.Zero);
                    if (ret != (int)StreamRecorderError.None)
                    {
                        StreamRecorderErrorFactory.ThrowException (ret, "Failed to get the supported video encoders");
                    }
                }
                return _videoCodec;
            }
        }

        /// <summary>
        /// Retrieves all the video resolutions supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns videoresolution list containing the width and height of
        /// different resolutions supported by recorder.
        /// </returns>
        public IEnumerable<StreamRecorderVideoResolution> SupportedVideoResolutions
        {
            get
            {
                if (_resolutions.Count == 0)
                {
                    Interop.StreamRecorder.VideoResolutionCallback callback = (int width, int height, IntPtr userData) =>
                    {
                        StreamRecorderVideoResolution temp = new StreamRecorderVideoResolution(width, height);
                        _resolutions.Add(temp);
                        return true;
                    };
                    int ret = Interop.StreamRecorder.VideoResolution (_handle, callback, IntPtr.Zero);
                    if (ret != (int)StreamRecorderError.None)
                    {
                        StreamRecorderErrorFactory.ThrowException (ret, "Failed to get the supported video resolutions");
                    }
                }
                return _resolutions;
            }
        }

        /// <summary>
        /// Prepare the stream recorder.
        /// </summary>
        /// <remarks>
        /// Before calling the function, it is required to set AudioEncoder,
        /// videoencoder and fileformat properties of recorder.
        /// </remarks>
        public void Prepare()
        {
            int ret = Interop.StreamRecorder.Prepare (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Failed to prepare stream recorder");
            }
        }

        /// <summary>
        /// Resets the stream recorder.
        /// </summary>
        public void Unprepare()
        {
            int ret = Interop.StreamRecorder.Unprepare (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Failed to reset the stream recorder");
            }
        }

        /// <summary>
        /// Starts the recording.
        /// </summary>
        /// <remarks>
        /// If file path has been set to an existing file, this file is removed automatically and updated by new one.
        ///	The filename should be set before this function is invoked.
        /// </remarks>
        public void Start()
        {
            int ret = Interop.StreamRecorder.Start (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Failed to start the stream recorder");
            }
        }

        /// <summary>
        /// Pause the recording.
        /// </summary>
        /// <remarks>
        /// Recording can be resumed with Start().
        /// </remarks>
        public void Pause()
        {
            int ret = Interop.StreamRecorder.Pause (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Failed to pause the stream recorder");
            }
        }

        /// <summary>
        /// Stops recording and saves the result.
        /// </summary>
        public void Commit()
        {
            int ret = Interop.StreamRecorder.Commit (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Failed to save the recorded content");
            }
        }

        /// <summary>
        /// Cancels the recording.
        /// The recording data is discarded and not written in the recording file.
        /// </summary>
        public void Cancel()
        {
            int ret = Interop.StreamRecorder.Cancel (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Failed to cancel the recording");
            }
        }

        /// <summary>
        /// Push stream buffer as recording raw data.
        /// </summary>
        public void PushBuffer(MediaPacket packet)
        {
            IntPtr _packet_h = packet.GetHandle();

            Log.Info("Tizen.Multimedia.StreamRecorder", "PUSH stream buffer");
            int ret = Interop.StreamRecorder.PushStreamBuffer(_handle, _packet_h);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException(ret, "Failed to push buffer");
            }
            Log.Info("Tizen.Multimedia.StreamRecorder", "PUSH stream buffer END");
        }

        /// <summary>
        /// Set the source type of pushed data.
        /// </summary>
        public void EnableSourceBuffer(StreamRecorderSourceType type)
        {
            int ret = Interop.StreamRecorder.EnableSourceBuffer(_handle, (int) type);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException(ret, "Failed to set EnableSourceBuffer");
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
                    Interop.StreamRecorder.Destroy (_handle);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }

        private void RegisterStreamRecorderNotifiedEvent()
        {
            _notifiedCallback = (StreamRecorderState previous, StreamRecorderState current, StreamRecorderNotify notify, IntPtr userData) =>
            {
                StreamRecorderNotifiedEventArgs eventArgs = new StreamRecorderNotifiedEventArgs(previous, current, notify);
                _recorderNotified?.Invoke(this, eventArgs);
            };
            int ret = Interop.StreamRecorder.SetNotifiedCallback (_handle, _notifiedCallback, IntPtr.Zero);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Setting notify callback failed");
            }
        }

        private void UnregisterStreamRecorderNotifiedEvent()
        {
            int ret = Interop.StreamRecorder.UnsetNotifiedCallback (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Unsetting notify callback failed");
            }
        }

        private void RegisterBufferComsumedEvent()
        {
            _bufferConsumedCallback = (IntPtr buffer, IntPtr userData) =>
            {
                StreamRecordingBufferConsumedEventArgs eventArgs = new StreamRecordingBufferConsumedEventArgs(buffer);
                _bufferConsumed?.Invoke(this, eventArgs);
            };
            int ret = Interop.StreamRecorder.SetBufferConsumedCallback (_handle, _bufferConsumedCallback, IntPtr.Zero);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Setting buffer consumed callback failed");
            }
        }

        private void UnregisterBufferComsumedEvent()
        {
            int ret = Interop.StreamRecorder.UnsetBufferConsumedCallback (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Unsetting buffer consumed callback failed");
            }
        }

        private void RegisterRecordingStatusChangedEvent()
        {
            _recordingStatusCallback = (ulong elapsedTime, ulong fileSize, IntPtr userData) =>
            {
                RecordingStatusChangedEventArgs eventArgs = new RecordingStatusChangedEventArgs(elapsedTime, fileSize);
                _recordingStatusChanged?.Invoke(this, eventArgs);
            };
            int ret = Interop.StreamRecorder.SetStatusChangedCallback(_handle, _recordingStatusCallback, IntPtr.Zero);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Setting status changed callback failed");
            }
        }

        private void UnregisterRecordingStatusChangedEvent()
        {
            int ret = Interop.StreamRecorder.UnsetStatusChangedCallback(_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Unsetting status changed callback failed");
            }
        }

        private void RegisterRecordingLimitReachedEvent()
        {
            _recordingLimitReachedCallback = (StreamRecordingLimitType type, IntPtr userData) =>
            {
                StreamRecordingLimitReachedEventArgs eventArgs = new StreamRecordingLimitReachedEventArgs(type);
                _recordingLimitReached?.Invoke(this, eventArgs);
            };
            int ret = Interop.StreamRecorder.SetLimitReachedCallback (_handle, _recordingLimitReachedCallback, IntPtr.Zero);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Setting limit reached callback failed");
            }
        }

        private void UnregisterRecordingLimitReachedEvent()
        {
            int ret = Interop.StreamRecorder.UnsetLimitReachedCallback (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException(ret, "Unsetting limit reached callback failed");
            }
        }

        private void RegisterRecordingErrorOccurredEvent()
        {
            _recorderErrorCallback = (StreamRecorderErrorCode error, StreamRecorderState current, IntPtr userData) =>
            {
                StreamRecordingErrorOccurredEventArgs eventArgs = new StreamRecordingErrorOccurredEventArgs(error, current);
                _recordingErrorOccurred?.Invoke(this, eventArgs);
            };
            int ret = Interop.StreamRecorder.SetErrorCallback (_handle, _recorderErrorCallback, IntPtr.Zero);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Setting Error callback failed");
            }
        }

        private void UnregisterRecordingErrorOccurredEvent()
        {
            int ret = Interop.StreamRecorder.UnsetErrorCallback (_handle);
            if (ret != (int)StreamRecorderError.None)
            {
                StreamRecorderErrorFactory.ThrowException (ret, "Unsetting Error callback failed");
            }
        }
    }
}
