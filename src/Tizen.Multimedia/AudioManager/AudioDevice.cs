/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents an audio device in the system, providing functionality to query and manipulate its properties.
    /// The <see cref="AudioDevice"/> class allows developers to interact with audio devices by retrieving
    /// detailed information such as the device's ID, name, type, I/O direction, and its current running state.
    /// Furthermore, it provides methods for getting and setting sample formats and rates, managing resampling options,
    /// and restricting stream types to media-only, facilitating optimized audio handling for diverse applications.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AudioDevice
    {
        private readonly int _id;
        private readonly AudioDeviceType _type;
        private readonly AudioDeviceIoDirection _ioDirection;
        private const string Tag = "Tizen.Multimedia.AudioDevice";

        internal AudioDevice(IntPtr deviceHandle)
        {
            int ret = Interop.AudioDevice.GetDeviceId(deviceHandle, out _id);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.AudioDevice.GetDeviceName(deviceHandle, out var name);
            MultimediaDebug.AssertNoError(ret);

            Name = Marshal.PtrToStringAnsi(name);

            ret = Interop.AudioDevice.GetDeviceType(deviceHandle, out _type);
            MultimediaDebug.AssertNoError(ret);

            ret = Interop.AudioDevice.GetDeviceIoDirection(deviceHandle, out _ioDirection);
            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Gets the unique identifier of the audio device.
        /// This ID serves as a reference to identify the device within the system and
        /// is crucial for performing operations on specific devices.
        /// </summary>
        /// <value>The id of the device.</value>
        /// <since_tizen> 3 </since_tizen>
        public int Id => _id;

        /// <summary>
        /// Gets the name of the audio device.
        /// This property provides a human-readable identifier for the device,
        /// which can be used in user interfaces or logs to display information
        /// about the current audio output/input device.
        /// </summary>
        /// <value>The name of the device.</value>
        /// <since_tizen> 3 </since_tizen>
        public string Name { get; }

        /// <summary>
        /// Gets the type of the audio device.
        /// This property returns an enumerated value of type <see cref="AudioDeviceType"/>
        /// that indicates the specific category of the device, such as speakers, microphones,
        /// or headphones, which helps in distinguishing between different device functionalities.
        /// </summary>
        /// <value>The <see cref="AudioDeviceType"/> of the device.</value>
        /// <since_tizen> 3 </since_tizen>
        public AudioDeviceType Type => _type;

        /// <summary>
        /// Gets the input/output (I/O) direction of the audio device.
        /// This property indicates whether the device is designed for input (recording) or output (playback),
        /// allowing developers to manage device usage appropriately in their applications.
        /// </summary>
        /// <value>The IO direction of the device.</value>
        /// <since_tizen> 3 </since_tizen>
        public AudioDeviceIoDirection IoDirection => _ioDirection;

        /// <summary>
        /// Gets a value indicating whether the audio device is currently running.
        /// This property checks the operational state of the device and returns <c>true</c>
        /// if the device is active and processing audio, or <c>false</c> if it is idle or inactive.
        /// </summary>
        /// <value>true if the audio stream of device is running actually; otherwise, false.</value>
        /// <since_tizen> 5 </since_tizen>
        public bool IsRunning
        {
            get
            {
                Interop.AudioDevice.IsDeviceRunning(_id, out bool isRunning).
                    ThrowIfError("Failed to get the running state of the device");

                return isRunning;
            }
        }

        /// <summary>
        /// Retrieves a collection of audio sample formats supported by the device.
        /// This method returns an enumerable list of <see cref="AudioSampleFormat"/> values
        /// indicating the different audio formats the device can handle, enabling applications
        /// to select a compatible format for audio processing.
        /// </summary>
        /// <returns>An IEnumerable&lt;AudioSampleFormat&gt; that contains supported sample formats.</returns>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public IEnumerable<AudioSampleFormat> GetSupportedSampleFormats()
        {
            Interop.AudioDevice.GetSupportedSampleFormats(_id, out IntPtr formats, out uint numberOfElements).
                ThrowIfError("Failed to get supported sample formats");

            return RetrieveFormats();

            IEnumerable<AudioSampleFormat> RetrieveFormats()
            {
                int[] formatsResult = new int[numberOfElements];

                Marshal.Copy(formats, formatsResult, 0, (int)numberOfElements);
                Marshal.FreeHGlobal(formats);

                foreach (int f in formatsResult)
                {
                    Log.Debug(Tag, $"supported sample format:{f}");
                }

                return formatsResult.Cast<AudioSampleFormat>();
            }
        }

        /// <summary>
        /// Sets the sample format for the audio device.
        /// This method allows developers to specify a desired <see cref="AudioSampleFormat"/> for
        /// audio playback or recording.
        /// </summary>
        /// <param name="format">The <see cref="AudioSampleFormat"/> to set to the device.</param>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public void SetSampleFormat(AudioSampleFormat format)
        {
            Interop.AudioDevice.SetSampleFormat(_id, format).
                    ThrowIfError("Failed to set sample format of the device");
        }

        /// <summary>
        /// Gets the current sample format used by the audio device.
        /// This method retrieves the current <see cref="AudioSampleFormat"/> the device is operating with,
        /// allowing applications to verify or adjust to the active format being utilized for audio streams.
        /// </summary>
        /// <returns>The <see cref="AudioSampleFormat"/> of the device.</returns>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public AudioSampleFormat GetSampleFormat()
        {
            Interop.AudioDevice.GetSampleFormat(_id, out AudioSampleFormat format).
                ThrowIfError("Failed to get sample format of the device");

            return format;
        }

        private uint ConvertCoreRateValToUint(int value)
        {
            switch (value)
            {
                case 0: return 8000;
                case 1: return 16000;
                case 2: return 22050;
                case 3: return 44100;
                case 4: return 48000;
                case 5: return 88200;
                case 6: return 96000;
                case 7: return 192000;
                default:
                    Log.Error(Tag, $"unknown value from core:{value}");
                    return 0;
            }
        }

        private uint ConvertRateToCoreValue(uint rate)
        {
            switch (rate)
            {
                case 8000: return 0;
                case 16000: return 1;
                case 22050: return 2;
                case 44100: return 3;
                case 48000: return 4;
                case 88200: return 5;
                case 96000: return 6;
                case 192000: return 7;
                default:
                    Log.Error(Tag, $"not supported rate:{rate}");
                    return 0;
            }
        }

        /// <summary>
        /// Retrieves the sample rates that the audio device supports.
        /// This method returns an enumerable list of supported sample rates, allowing developers
        /// to select an appropriate rate for audio processing based on the capabilities of the device.
        /// </summary>
        /// <returns>An IEnumerable&lt;uint&gt; that contains supported sample rates.</returns>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public IEnumerable<uint> GetSupportedSampleRates()
        {
            Interop.AudioDevice.GetSupportedSampleRates(_id, out IntPtr rates, out uint numberOfElements).
                ThrowIfError("Failed to get supported sample formats");

            return RetrieveRates();

            IEnumerable<uint> RetrieveRates()
            {
                int[] ratesResult = new int[numberOfElements];
                uint[] convertedRates = new uint[numberOfElements];

                Marshal.Copy(rates, ratesResult, 0, (int)numberOfElements);
                Marshal.FreeHGlobal(rates);

                for (int i = 0; i < ratesResult.Length; i++)
                {
                    convertedRates[i] = ConvertCoreRateValToUint(ratesResult[i]);
                    Log.Debug(Tag, $"supported sample rate:{convertedRates[i]}");
                }

                return convertedRates;
            }
        }

        /// <summary>
        /// Sets the sample rate for the audio device.
        /// This method allows you to specify a desired sample rate (in Hz) for audio playback or recording.
        /// Choosing an appropriate sample rate is important for maintaining audio quality and ensuring compatibility
        /// with audio data formats.
        /// </summary>
        /// <param name="rate">The sample rate to set to the device.</param>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public void SetSampleRate(uint rate)
        {
            Interop.AudioDevice.SetSampleRate(_id, ConvertRateToCoreValue(rate)).
                ThrowIfError("Failed to set sample rate of the device");
        }

        /// <summary>
        /// Gets the current sample rate of the audio device.
        /// This method retrieves the sample rate currently in use for audio processing, allowing
        /// applications to ensure they are operating with the correct audio quality settings.
        /// </summary>
        /// <returns>The sample rate of the device.</returns>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public uint GetSampleRate()
        {
            Interop.AudioDevice.GetSampleRate(_id, out uint rate).
                ThrowIfError("Failed to get sample rate of the device");

            return ConvertCoreRateValToUint((int)rate);
        }

        /// <summary>
        /// Sets the 'avoid resampling' property for the audio device.
        /// This property controls whether the device should avoid resampling audio data during playback.
        /// Enabling this feature can help preserve audio quality by preventing alterations to audio that
        /// may happen during playback.
        /// </summary>
        /// <param name="enable">The 'avoid resampling' value to set to the device.</param>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        /// This property is not enabled as default. With this enabled, this device will use the first stream's original sample format
        /// and rate without resampling if supported.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public void SetAvoidResampling(bool enable)
        {
            Interop.AudioDevice.SetAvoidResampling(_id, enable).
                ThrowIfError("Failed to set avoid-resampling property of the device");

        }

        /// <summary>
        /// Gets the current state of the 'avoid resampling' property for the audio device.
        /// This method returns whether the device is currently configured to avoid resampling audio data,
        /// allowing developers to assess the current settings related to audio processing quality.
        /// </summary>
        /// <returns>The 'avoid resampling' property of the device.</returns>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        /// This property is not enabled as default. With this enabled, this device will use the first stream's original sample format
        /// and rate without resampling if supported.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public bool GetAvoidResampling()
        {
            Interop.AudioDevice.GetAvoidResampling(_id, out bool enabled).
                ThrowIfError("Failed to get avoid-resampling property of the device");

            return enabled;
        }

        /// <summary>
        /// Sets a restriction on the audio device to allow only media streams.
        /// This method configures the device to accept only audio streams of type
        /// <see cref="AudioStreamType.Media"/>. When enabled, the device will reject
        /// any other stream types, ensuring that it is exclusively used for media playback.
        /// </summary>
        /// <param name="enable">The 'media stream only' value to set to the device.</param>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        ///	This property is not enabled as default. With this enabled, no other stream types except <see cref="AudioStreamType.Media"/>
        ///	are not allowed to this device.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public void SetMediaStreamOnly(bool enable)
        {
            Interop.AudioDevice.SetMediaStreamOnly(_id, enable).
                ThrowIfError("Failed to set media-stream-only property of the device");
        }

        /// <summary>
        /// Retrieves the current restriction status of the audio device regarding media streams.
        /// This method checks whether the device is currently configured to accept only media streams,
        /// returning a boolean value that indicates the state of the restriction.
        /// </summary>
        /// <returns>The 'media stream only' property of the device.</returns>
        /// <remarks>
        /// This device should be <see cref="AudioDeviceType.UsbAudio"/> type and <see cref="AudioDeviceIoDirection.Output"/> direction.
        ///	This property is not enabled as default. With this enabled, no other stream types except <see cref="AudioStreamType.Media"/>
        ///	are not allowed to this device.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This device is not valid or is disconnected.</exception>
        /// <since_tizen> 5 </since_tizen>
        public bool GetMediaStreamOnly()
        {
            Interop.AudioDevice.GetMediaStreamOnly(_id, out bool enabled).
                ThrowIfError("Failed to get media-stream-only property of the device");

            return enabled;
        }

        /// <summary>
        /// Returns a string representation of the current instance.
        /// This method provides a formatted string that includes key properties of the audio device,
        /// such as its unique identifier, name, type, I/O direction, and running state.
        /// This representation can be useful for logging, debugging, or displaying device information
        /// in user interfaces.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override string ToString() =>
            $"Id={Id}, Name={Name}, Type={Type}, IoDirection={IoDirection}, IsRunning={IsRunning}";

        /// <summary>
        /// Compares the current instance of <see cref="AudioDevice"/> with another object for equality.
        /// This method checks if the specified object is an instance of <see cref="AudioDevice"/>
        /// and compares their unique identifiers to determine if they represent the same audio device.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the two devices are equal; otherwise, false.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override bool Equals(object obj)
        {
            var rhs = obj as AudioDevice;
            if (rhs == null)
            {
                return false;
            }

            return Id == rhs.Id;
        }

        /// <summary>
        /// Retrieves the hash code for the current instance of <see cref="AudioDevice"/>.
        /// This method generates a hash code based on the unique identifier of the audio device,
        /// which can be useful for storing instances in hash-based collections such as dictionaries
        /// or hash sets.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="AudioDevice"/>.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
