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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Native = Interop.ScreenMirroring;
using System.Collections.Generic;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="ScreenMirroring.StateChanged"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ScreenMirroringStateChangedEventArgs : EventArgs
    {
        internal ScreenMirroringStateChangedEventArgs(ScreenMirroringState state)
        {
            State = state;
        }

        /// <summary>
        /// Gets the current state of the screen mirroring.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ScreenMirroringState State { get; }
    }

    /// <summary>
    /// Provides data for the <see cref="ScreenMirroring.ErrorOccurred"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ScreenMirroringErrorOccurredEventArgs : EventArgs
    {
        internal ScreenMirroringErrorOccurredEventArgs(ScreenMirroringError error)
        {
            Error = error;
        }

        /// <summary>
        /// Gets the error that occurred.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ScreenMirroringError Error { get; }
    }

    /// <summary>
    /// Provides data for the <see cref="ScreenMirroring.DisplayOrientationChanged"/> event.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScreenMirroringDisplayOrientationChangedEventArgs : EventArgs
    {
        internal ScreenMirroringDisplayOrientationChangedEventArgs(ScreenMirroringDisplayOrientation orientation)
        {
            Orientation = orientation;
        }

        /// <summary>
        /// Gets the display orientation of source.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScreenMirroringDisplayOrientation Orientation { get; }
    }

    /// <summary>
    /// Provides data for the <see cref="ScreenMirroring.UibcInfoReceived"/> event.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScreenMirroringUibcInfoReceivedEventArgs : EventArgs
    {
        internal ScreenMirroringUibcInfoReceivedEventArgs(ScreenMirroringError error, IntPtr uibcInfo)
        {
            var unmanagedStruct = Marshal.PtrToStructure<Native.UibcInfo>(uibcInfo);

            Error = error;
            Ip = unmanagedStruct.Ip;
            Port = unmanagedStruct.Port;
            GenCapability = unmanagedStruct.GenCapability;
            Size = new Size(unmanagedStruct.Width, unmanagedStruct.Height);
            HidcCapabilities = GetUibcInputs(unmanagedStruct.hidcCapsList, unmanagedStruct.hidcCapsSize);
        }

        private ReadOnlyCollection<UibcInputs> GetUibcInputs(IntPtr unmanagedIntPtr, uint hidcCapsSize)
        {
            var size = Marshal.SizeOf(typeof(Native.UibcInput));
            var unmanagedStruct = new Native.UibcInput[hidcCapsSize];
            IntPtr unmanagedUibcInput;

            for (int i = 0; i < hidcCapsSize; i++)
            {
                if (IntPtr.Size == 4)
                {
                    unmanagedUibcInput = new IntPtr(unmanagedIntPtr.ToInt32() + i * size);
                }
                else
                {
                    unmanagedUibcInput = new IntPtr(unmanagedIntPtr.ToInt64() + i * size);
                }

                unmanagedStruct[i] = Marshal.PtrToStructure<Native.UibcInput>(unmanagedUibcInput);
            }

            var hidcList = new List<UibcInputs>();
            for (int i = 0; i < hidcCapsSize; i++)
            {
                hidcList.Add(new UibcInputs(unmanagedStruct[i].type, unmanagedStruct[i].path));
            }

            return new ReadOnlyCollection<UibcInputs>(hidcList);
        }

        /// <summary>
        /// Gets the error that occurred.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScreenMirroringError Error { get; }

        /// <summary>
        /// Gets the IP address
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Ip { get; }

        /// <summary>
        /// Gets the port number
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Port { get; }

        /// <summary>
        /// Gets the gen capability
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GenCapability { get; }

        /// <summary>
        /// Gets the size
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size Size { get; }

        /// <summary>
        /// Gets the HIDC(Human Interface Device Command) capabilities
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyCollection<UibcInputs> HidcCapabilities { get; }
    }
}
