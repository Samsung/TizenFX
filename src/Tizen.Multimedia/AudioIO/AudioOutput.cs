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

namespace Tizen.Multimedia
{
    /// <summary>
    /// The Audio Output class provides a set of functions to directly manage the system audio output devices. 
    /// </summary>
    public class AudioOutput : BaseAudio
    {
        /// <summary>
        /// Gets the sample rate of the audio output data stream. 
        /// </summary>
        public override int SampleRate
        {
            get
            {
                int sampleRate;
                AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.GetSampleRate(_handle, out sampleRate));
                return sampleRate;
            }
        }
        /// <summary>
        /// Gets the channel type of the audio output data stream. 
        /// The audio channel type defines whether the audio is mono or stereo.
        /// </summary>
        public override AudioChannel Channel
        {
            get
            {
                int channel;
                AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.GetChannel(_handle, out channel));
                return (AudioChannel)channel;
            }
        }
        /// <summary>
        /// Gets the sample audio format (8-bit or 16-bit) of the audio output data stream. 
        /// </summary>
        public override AudioSampleType SampleType
        {
            get
            {
                int type;
                AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.GetSampleType(_handle, out type));
                return (AudioSampleType)type;
            }
        }
        /// <summary>
        /// Gets the size to be allocated for the audio output buffer. 
        /// </summary>
        public override int BufferSize
        {
            get
            {
                int size = 0;
                AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.GetBufferSize(_handle, out size));
                return size;
            }
        }
        /// <summary>
        /// Gets the sound type supported by the audio output device. 
        /// </summary>
        public AudioStreamType SoundStreamType
        {
            get
            {
                int audioType = 0;
                AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.GetSoundType(_handle, out audioType));
                return (AudioStreamType)audioType;
            }
        }

        /// <summary>
        /// Drains buffered audio data from the output stream. 
        /// This function waits until drains stream buffer completely. (e.g end of playback)
        /// </summary>
        public void Drain()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.Drain(_handle));
        }
        object _lock = new object();
        /// <summary>
        /// Starts writing the audio data to the device. 
        /// </summary>
        /// <param name="buffer"></param>
        public void Write(byte[] buffer)
        {
            if (buffer.Length <= 0)
            {
                throw new IndexOutOfRangeException("Bed File Length");
            }
            IntPtr ptrByteArray = Marshal.AllocHGlobal(buffer.Length);
            try
            {
                Marshal.Copy(buffer, 0, ptrByteArray, buffer.Length);
                AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.Write(_handle, ptrByteArray, (uint)buffer.Length));
            }
            finally
            {
                if (ptrByteArray != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(ptrByteArray);
                    ptrByteArray = IntPtr.Zero;
                }
            }
        }
        /// <summary>
        /// Sets an asynchronous(event) callback function to handle playing PCM (pulse-code modulation) data. 
        /// </summary>
        protected override void RegisterAudioStreamLengthChanged()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.SetAudioOutputStreamChangedCallback(_handle, OnStream, IntPtr.Zero));
        }
        /// <summary>
        /// Unregisters the callback function. 
        /// </summary>
        protected override void UnregisterAudioStreamLengthChanged()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.UnsetAudioOutputStreamChangedCallback(_handle));
        }
        /// <summary>
        /// Sets the state changed callback function to the audio output handle. 
        /// </summary>
        protected override void RegisterAudioStateChangedCallback()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.SetAudioOutputStateChangedCallback(_handle, OnStateChanged, IntPtr.Zero));
        }
        /// <summary>
        /// Unregisters the state changed callback function of the audio output handle. 
        /// </summary>
        protected override void UnregisterAudioStateChangedmCallback()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.UnsetAudioOutputStateChangedCallback(_handle));
        }
        /// <summary>
        /// Releases the audio output handle, along with all its resources. 
        /// </summary>
        protected override void Destroy()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.Destroy(_handle));
        }
        /// <summary>
        /// Prepares the audio output for playback, this must be called before audio_out_write(). 
        /// </summary>
        public override void Prepare()
        {
            if (_bReady == false)
            {
                AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.Prepare(_handle));
                _bReady = true;
            }
        }
        /// <summary>
        /// Unprepares the audio output. 
        /// </summary>
        public override void Unprepare()
        {
            if (_bReady)
            {
                AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.Unprepare(_handle));
                _bReady = false;
            }
        }
        /// <summary>
        /// Pauses feeding of audio data to the device. 
        /// </summary>
        public override void Pause()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.Pause(_handle));

        }
        /// <summary>
        /// Resumes feeding of audio data to the device. 
        /// </summary>
        public override void Resume()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.Resume(_handle));
        }
        /// <summary>
        /// Flushes and discards buffered audio data from the output stream. 
        /// </summary>
        public override void Flush()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.Flush(_handle));
        }
        /// <summary>
        /// Sets the sound stream information to the audio output. 
        /// </summary>
        /// <param name="stream_info"></param>
        /// <returns></returns>
        public override void SetStreamInfo(AudioStreamPolicy streamPolicy)
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.SetStreamInfo(_handle, streamPolicy.Handle));
        }
        /// <summary>
        /// Initializes the instance of the AudioOutput class with the SafeAudioInputHandle.
        /// </summary>
        /// <param name="_sample_rate"></param>
        /// <param name="_channel"></param>
        /// <param name="_type"></param>
        public AudioOutput(int sample_rate, AudioChannel channel, AudioSampleType type)
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioOutput.Create(sample_rate, (int)channel, (int)type, out _handle));
        }
        private AudioOutput() { }
    }
}
