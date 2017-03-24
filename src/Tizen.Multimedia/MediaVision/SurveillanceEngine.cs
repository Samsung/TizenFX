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
using static Tizen.Multimedia.Interop.MediaVision.Surveillance;

namespace Tizen.Multimedia
{
    /// <summary>
    /// SurveillanceEngine is a base class for surveillance event triggers.
    /// Media Vision Surveillance provides functionality can be utilized for creation of video surveillance systems.
    /// </summary>
    /// <seealso cref="MovementDetector"/>
    /// <seealso cref="PersonAppearanceDetector"/>
    /// <seealso cref="PersonRecognizer"/>
    public abstract class SurveillanceEngine : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveillanceEngine"/> class.
        /// </summary>
        /// <param name="eventType">The type of the event trigger</param>
        internal SurveillanceEngine(string eventType)
        {
            EventTriggerCreate(eventType, out _handle).Validate("Failed to create surveillance event trigger.");
        }

        ~SurveillanceEngine()
        {
            Dispose(false);
        }

        internal IntPtr Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(GetType().Name);
                }
                return _handle;
            }
        }

        /// <summary>
        /// Sets and gets ROI (Region Of Interest) to the event trigger
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="SurveillanceEngine"/> has already been disposed of.</exception>
        public Point[] Roi
        {
            get
            {
                IntPtr roiPtr = IntPtr.Zero;
                try
                {
                    int count = 0;
                    GetEventTriggerRoi(Handle, out count, out roiPtr).Validate("Failed to get roi");

                    Point[] points = new Point[count];
                    IntPtr iterPtr = roiPtr;

                    for (int i = 0; i < count; i++)
                    {
                        points[i] = Marshal.PtrToStructure<Interop.MediaVision.Point>(roiPtr).ToApiStruct();
                        iterPtr = IntPtr.Add(iterPtr, Marshal.SizeOf<Interop.MediaVision.Point>());
                    }

                    return points;
                }
                finally
                {
                    Interop.Libc.Free(roiPtr);
                }
            }
            set
            {
                int length = value == null ? 0 : value.Length;

                var points = value == null ? null : Interop.ToMarshalable(value);

                SetEventTriggerRoi(Handle, length, points).Validate("Failed to set roi");
            }
        }

        internal abstract void OnEventDetected(IntPtr trigger, IntPtr source,
            int streamId, IntPtr eventResult, IntPtr userData);

        /// <summary>
        /// Subscribes trigger to process sources pushed from video identified by @a videoStreamId.
        /// </summary>
        internal void InvokeAddSource(SurveillanceSource source, SurveillanceEngineConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            SubscribeEventTrigger(Handle, source.StreamId, EngineConfiguration.GetHandle(config),
                OnEventDetected).Validate("Failed to subscribe trigger");
        }

        /// <summary>
        /// Removes the source from <see cref="SurveillanceEngine"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="SurveillanceEngine"/> has already been disposed of.</exception>
        /// <exception cref="ArgumentException"><paramref name="source"/> has not been added.</exception>
        public void RemoveSource(SurveillanceSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            UnsubscribeEventTrigger(Handle, source.StreamId).Validate("Failed to unsubscribe event trigger");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            EventTriggerDestroy(_handle);
            _disposed = true;
        }
    }
}
