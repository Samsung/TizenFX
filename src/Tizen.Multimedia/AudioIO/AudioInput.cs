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
    /// The Audio Input class provides a set of functions to directly manage the system audio input devices.
    /// </summary>
    public class AudioInput : BaseAudio
    {
        /// <summary>
        /// Gets the sample rate of the audio input data stream. 
        /// </summary>
        public override int SampleRate
        {
            get
            {
                int sampleRate;
                AudioErrorHelper.Try(Interop.AudioIO.AudioInput.GetSampleRate(_handle, out sampleRate));
                return sampleRate;
            }
        }

        /// <summary>
        /// Gets the channel type of the audio input data stream. 
        /// The audio channel type defines whether the audio is mono or stereo.
        /// </summary>
        public override AudioChannel Channel
        {
            get
            {
                int channel;
                AudioErrorHelper.Try(Interop.AudioIO.AudioInput.GetChannel(_handle, out channel));
                return (AudioChannel)channel;
            }
        }
        /// <summary>
        /// Gets the sample audio format (8-bit or 16-bit) of the audio input data stream.
        /// </summary>
        public override AudioSampleType SampleType
        {
            get
            {
                int type;
                AudioErrorHelper.Try(Interop.AudioIO.AudioInput.GetSampleType(_handle, out type));
                return (AudioSampleType)type;
            }
        }

        /// <summary>
        /// Gets the size to be allocated for the audio input buffer. 
        /// </summary>
        public override int BufferSize
        {
            get
            {
                int size;
                AudioErrorHelper.Try(Interop.AudioIO.AudioInput.GetBufferSize(_handle, out size));
                return size;
            }
        }
        /// <summary>
        /// Reads audio data from the audio input buffer. 
        /// </summary>
        /// <param name="length"></param>
        /// <returns>The buffer of audio data receiving an input</returns>
        public byte[] Read(int length)
        {
            byte[] dataArray = new byte[length];

            if (dataArray.Length <= 0)
                throw new IndexOutOfRangeException("Bed Buffer Length");

            IntPtr ptrByteArray = Marshal.AllocHGlobal(length);
            try
            {
                AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Read(_handle, ptrByteArray, length));
                Marshal.Copy(ptrByteArray, dataArray, 0, dataArray.Length);
            }
            catch (Exception e)
            {
                Log.Info("Audio", "Read Exception : " + e.ToString());
                Console.WriteLine("read error" + e.ToString());
            }
            finally
            {
                if (ptrByteArray != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(ptrByteArray);
                    ptrByteArray = IntPtr.Zero;
                }
            }
            return dataArray;
        }
        /// <summary>
        /// peek from audio in buffer 
        /// This function works correctly only with read, write callback.Otherwise it won't operate as intended.
        /// </summary>
        /// <param name="length"></param>
        /// <returns> The allocated buffer - byte[] </returns>
        public byte[] Peek(uint length)
        {
            IntPtr ptrByteArray = IntPtr.Zero;
            uint nBytes = 0;
            try
            {
                AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Peek(_handle, out ptrByteArray, out nBytes));
                byte[] dataArray = new byte[nBytes];
                Marshal.Copy(ptrByteArray, dataArray, 0, (int)nBytes);

                return dataArray;
            }
            finally
            {
                if (ptrByteArray != IntPtr.Zero)
                {
                    ptrByteArray = IntPtr.Zero;
                }
            }
        }
        /// <summary>
        /// drop peeked audio buffer. 
        /// This function works correctly only with read, write callback.Otherwise it won't operate as intended.
        /// </summary>
        public void Drop()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Drop(_handle));
        }
        /// <summary>
        /// Releases the audio input handle and all its resources associated with an audio stream.
        /// </summary>
        protected override void Destroy()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Destroy(_handle));
        }
        /// <summary>
        /// Sets an asynchronous(event) callback function to handle recording PCM (pulse-code modulation) data. 
        /// </summary>
        protected override void RegisterAudioStreamLengthChanged()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.SetAudioInputStreamChangedCallback(_handle, OnStream, IntPtr.Zero));
        }
        /// <summary>
        /// Unregisters the callback function. 
        /// </summary>
        protected override void UnregisterAudioStreamLengthChanged()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.UnsetAudioInputStreamChangedCallback(_handle));
        }
        /// <summary>
        /// Sets the state changed callback function to the audio input handle. 
        /// </summary>
        protected override void RegisterAudioStateChangedCallback()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.SetAudioInputStateChangedCallback(_handle, OnStateChanged, IntPtr.Zero));
        }
        /// <summary>
        /// Unregisters the state changed callback function of the audio input handle. 
        /// </summary>
        protected override void UnregisterAudioStateChangedmCallback()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.UnsetAudioInputStateChangedCallback(_handle));
        }
        /// <summary>
        /// Prepares the audio input for reading audio data by starting buffering of audio data from the device. 
        /// </summary>
        public override void Prepare()
        {
            if(_bReady == false)
            {
                AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Prepare(_handle));
                _bReady = true;
            }
        }
        /// <summary>
        /// Unprepares the audio input. 
        /// </summary>
        public override void Unprepare()
        {
            if (_bReady)
            {
                AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Unprepare(_handle));
                _bReady = false;
            }
        }
        /// <summary>
        /// Pauses buffering of audio data from the device. 
        /// </summary>
        public override void Pause()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Pause(_handle));
        }
        /// <summary>
        /// Resumes buffering audio data from the device. 
        /// </summary>
        public override void Resume()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Resume(_handle));
        }
        /// <summary>
        /// Flushes and discards buffered audio data from the input stream. 
        /// </summary>
        public override void Flush()
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Flush(_handle));
        }
        /// <summary>
        /// Sets the sound stream information to the audio input. 
        /// </summary>
        /// <param name="stream_info"></param>
        /// <returns></returns>
        public override void SetStreamInfo(AudioStreamPolicy streamPolicy)
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.SetStreamInfo(_handle, streamPolicy.Handle));
        }
        /// <summary>
        /// Initializes the instance of the AudioInput class with the SafeAudioInputHandle.
        /// </summary>
        /// <param name="_sample_rate"></param>
        /// <param name="_channel"></param>
        /// <param name="_type"></param>
        public AudioInput(int sample_rate, AudioChannel channel, AudioSampleType type)
        {
            AudioErrorHelper.Try(Interop.AudioIO.AudioInput.Create(sample_rate, (int)channel, (int)type, out _handle));
        }
        private AudioInput() { }
    }
}
