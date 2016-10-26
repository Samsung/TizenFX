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
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents an abstract Surveillance Event Trigger.
    /// Media Vision Surveillance provides functionality can be utilized for creation of video surveillance systems.
    /// The main idea underlying surveillance is event subscription model. These events can be added to the concrete
    /// surveillance vent trigger classes.
    /// </summary>
    public abstract class SurveillanceEventTrigger : IDisposable
    {
        internal const string MovementDetectedType = "MV_SURVEILLANCE_EVENT_MOVEMENT_DETECTED";
        internal const string PersonAppearanceChangedType = "MV_SURVEILLANCE_EVENT_PERSON_APPEARED_DISAPEARED";
        internal const string PersonRecognizedType = "MV_SURVEILLANCE_EVENT_PERSON_RECOGNIZED";

        private const string _movementNumberOfRegionsKey = "NUMBER_OF_MOVEMENT_REGIONS";
        private const string _movementRegionsKey = "MOVEMENT_REGIONS";

        private const string _personsRecognizedNumberKey = "NUMBER_OF_PERSONS";
        private const string _personsRecognizedLocationsKey = "PERSONS_LOCATIONS";
        private const string _personsRecognizedLabelsKey = "PERSONS_LABELS";
        private const string _personsRecognizedConfidencesKey = "PERSONS_CONFIDENCES";

        private const string _personsAppearedNumber = "NUMBER_OF_APPEARED_PERSONS";
        private const string _personsDisappearedNumber = "NUMBER_OF_DISAPPEARED_PERSONS";
        private const string _personsTrackedNumber = "NUMBER_OF_TRACKED_PERSONS";
        private const string _personsAppearedLocations = "APPEARED_PERSONS_LOCATIONS";
        private const string _personsDisappearedLocations = "DISAPPEARED_PERSONS_LOCATIONS";
        private const string _personsTrackedLocations = "TRACKED_PERSONS_LOCATIONS";

        internal IntPtr _eventTriggerHandle = IntPtr.Zero;
        private string _eventTriggerType;
        private bool _disposed = false;

        internal event EventHandler<PersonRecognizedEventArgs> PersonRecognizedEvent;
        internal event EventHandler<PersonAppearanceChangedEventArgs> PersonAppearanceChangedEvent;
        internal event EventHandler<MovementDetectedEventArgs> MovementDetectedEvent;

        /// <summary>
        /// Constructor of the SurveillanceEventTrigger class.
        /// </summary>
        /// <param name="eventType">The type of the event trigger</param>
        internal SurveillanceEventTrigger(string eventType)
        {
            _eventTriggerType = eventType;
            int ret = Interop.MediaVision.Surveillance.EventTriggerCreate(eventType, out _eventTriggerHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to create surveillance event trigger.");
        }

        /// <summary>
        /// Destructor of the SurveillanceEventTrigger class.
        /// </summary>
        ~SurveillanceEventTrigger()
        {
            Dispose(false);
        }

        /// <summary>
        /// Sets and gets ROI (Region Of Interest) to the event trigger
        /// </summary>
        public List<Point> Roi
        {
            get
            {
                int count;
                IntPtr roiPtr;
                int ret = Interop.MediaVision.Surveillance.GetEventTriggerRoi(_eventTriggerHandle, out count, out roiPtr);
                if (ret != 0)
                {
                    Tizen.Log.Error(MediaVisionLog.Tag, "Failed to get roi");
                    return null;
                }

                IntPtr[] pointsPtr = new IntPtr[count];
                Marshal.Copy(roiPtr, pointsPtr, 0, count);

                List<Point> points = new List<Point>();
                for (int i = 0; i < count; i++)
                {
                    Interop.MediaVision.Point roi = (Interop.MediaVision.Point)Marshal.PtrToStructure(pointsPtr[i], typeof(Interop.MediaVision.Point));
                    points.Add(new Point()
                    {
                        X = roi.x,
                        Y = roi.y
                    });
                }

                return points;
            }

            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("Invalid array");
                }

                IntPtr[] ptrArray = new IntPtr[value.Count];
                for (int i = 0; i < value.Count; i++)
                {
                    if (value[i] == null)
                    {
                        throw new ArgumentException("Invalid parameter");
                    }

                    Interop.MediaVision.Point point = new Interop.MediaVision.Point()
                    {
                        x = value[i].X,
                        y = value[i].Y
                    };

                    IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(point));
                    Marshal.StructureToPtr(point, ptr, false);
                    ptrArray[i] = ptr;
                }

                int size = Marshal.SizeOf(typeof(IntPtr)) * ptrArray.Length;
                IntPtr roiPtr = Marshal.AllocHGlobal(size);
                Marshal.Copy(ptrArray, 0, roiPtr, ptrArray.Length);

                int ret = Interop.MediaVision.Surveillance.SetEventTriggerRoi(_eventTriggerHandle, value.Count, roiPtr);
                MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to set roi");
            }
        }

        /// <summary>
        /// Subscribes trigger to process sources pushed from video identified by @a videoStreamId.
        /// </summary>
        /// <param name="videoStreamId">The identifier of the video stream for which event trigger activation will be checked</param>
        /// <param name="config">The engine configuration of the event</param>
        /// <code>
        ///
        /// </code>
        public void Subscribe(int videoStreamId, SurveillanceEngineConfiguration config = null)
        {
            Interop.MediaVision.Surveillance.MvSurveillanceEventOccurredCallback eventOccurredCb = (IntPtr trigger, IntPtr source, int streamId, IntPtr eventResult, IntPtr userData) =>
            {
                Tizen.Log.Info(MediaVisionLog.Tag, string.Format("Surveillance event occurred, video stream id : {0}", streamId));
                if (eventResult != null)
                {
                    if (string.Equals(_eventTriggerType, MovementDetectedType))
                    {
                        MovementDetectedEventArgs e = GetMovementDetectedEventArgs(eventResult, streamId);
                        MovementDetectedEvent?.Invoke(null, e);
                    }
                    else if (string.Equals(_eventTriggerType, PersonRecognizedType))
                    {
                        PersonRecognizedEventArgs e = GetPersonRecognizedEventArgs(eventResult, streamId);
                        PersonRecognizedEvent?.Invoke(null, e);
                    }
                    else if (string.Equals(_eventTriggerType, PersonAppearanceChangedType))
                    {
                        PersonAppearanceChangedEventArgs e = GetPersonAppearanceChangedEventArgs(eventResult, streamId);
                        PersonAppearanceChangedEvent?.Invoke(null, e);
                    }
                }
            };

            int ret = Interop.MediaVision.Surveillance.SubscribeEventTrigger(_eventTriggerHandle, videoStreamId, (config != null) ? config._engineHandle : IntPtr.Zero, eventOccurredCb, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to subscribe trigger");
        }

        /// <summary>
        /// Unsubscribes trigger from the event
        /// </summary>
        /// <param name="videoStreamId">The identifier of the video source for which subscription will be stopped</param>
        /// <code>
        ///
        /// </code>
        public void Unsubscribe(int videoStreamId)
        {
            int ret = Interop.MediaVision.Surveillance.UnsubscribeEventTrigger(_eventTriggerHandle, videoStreamId);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to unsubscribe event trigger");
        }

        /// <summary>
        /// Pushes source to the surveillance system to detect events.
        /// </summary>
        /// <param name="source">The media source</param>
        /// <param name="videoStreamId">The identifier of video stream from which @a source is coming</param>
        /// <code>
        ///
        /// </code>
        public void PushSource(MediaVisionSource source, int videoStreamId)
        {
            if (source == null)
            {
                throw new ArgumentException("Invalid source");
            }

            int ret = Interop.MediaVision.Surveillance.PushSource(source._sourceHandle, videoStreamId);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to push source");
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
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
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free managed objects
            }

            Interop.MediaVision.Surveillance.EventTriggerDestroy(_eventTriggerHandle);
            _disposed = true;
        }

        private MovementDetectedEventArgs GetMovementDetectedEventArgs(IntPtr handle, int videoStreamId)
        {
            int count;
            IntPtr resultPtr = IntPtr.Zero;
            List<Rectangle> regions = new List<Rectangle>();

            int ret = Interop.MediaVision.Surveillance.GetResultCount(handle, _movementNumberOfRegionsKey, out count);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get result count");

            resultPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)) * count);
            ret = Interop.MediaVision.Surveillance.GetResultValue(handle, _movementRegionsKey, resultPtr);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get result");

            for (int i = 0; i < count; i++)
            {
                Interop.MediaVision.Rectangle rect = (Interop.MediaVision.Rectangle)Marshal.PtrToStructure(resultPtr, typeof(Interop.MediaVision.Rectangle));
                regions.Add(new Rectangle()
                {
                    Point = new Point()
                    {
                        X = rect.x,
                        Y = rect.y
                    },
                    Width = rect.width,
                    Height = rect.height
                });
                resultPtr = IntPtr.Add(resultPtr, Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)));
            }

            MovementDetectedEventArgs e = new MovementDetectedEventArgs()
            {
                VideoStreamId = videoStreamId,
                Regions = regions
            };

            return e;
        }

        private PersonRecognizedEventArgs GetPersonRecognizedEventArgs(IntPtr handle, int videoStreamId)
        {
            int count;
            List<PersonRecognitionResult> result = new List<PersonRecognitionResult>();

            int ret = Interop.MediaVision.Surveillance.GetResultCount(handle, _personsRecognizedNumberKey, out count);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get result count");

            IntPtr locationPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)) * count);
            ret = Interop.MediaVision.Surveillance.GetResultValue(handle, _personsRecognizedLocationsKey, locationPtr);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get location");

            IntPtr labelPtr = Marshal.AllocHGlobal(sizeof(int) * count);
            ret = Interop.MediaVision.Surveillance.GetResultValue(handle, _personsRecognizedLabelsKey, labelPtr);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get label");
            int[] labelsArray = new int[count];
            Marshal.Copy(labelPtr, labelsArray, 0, count);

            IntPtr confidencePtr = Marshal.AllocHGlobal(sizeof(double) * count);
            ret = Interop.MediaVision.Surveillance.GetResultValue(handle, _personsRecognizedConfidencesKey, confidencePtr);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get confidence");
            double[] confidencesArray = new double[count];
            Marshal.Copy(confidencePtr, confidencesArray, 0, count);

            for (int i = 0; i < count; i++)
            {
                Interop.MediaVision.Rectangle rect = (Interop.MediaVision.Rectangle)Marshal.PtrToStructure(locationPtr, typeof(Interop.MediaVision.Rectangle));
                Rectangle location = new Rectangle()
                {
                    Point = new Point()
                    {
                        X = rect.x,
                        Y = rect.y
                    },
                    Width = rect.width,
                    Height = rect.height
                };

                result.Add(new PersonRecognitionResult()
                {
                    Location = location,
                    Label = labelsArray[i],
                    Confidence = confidencesArray[i]
                });

                locationPtr = IntPtr.Add(locationPtr, Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)));
            }

            PersonRecognizedEventArgs e = new PersonRecognizedEventArgs()
            {
                VideoStreamId = videoStreamId,
                Result = result
            };

            return e;
        }

        private PersonAppearanceChangedEventArgs GetPersonAppearanceChangedEventArgs(IntPtr handle, int videoStreamId)
        {
            int numOfAppearedPersons, numOfDisappearedPersons, numOfTrackedPersons;

            List<Rectangle> appearedLocations = new List<Rectangle>();
            List<Rectangle> disappearedLocations = new List<Rectangle>();
            List<Rectangle> trackedLocations = new List<Rectangle>();

            int ret = Interop.MediaVision.Surveillance.GetResultCount(handle, _personsAppearedNumber, out numOfAppearedPersons);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get result");

            IntPtr appearedLocationPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)) * numOfAppearedPersons);
            ret = Interop.MediaVision.Surveillance.GetResultValue(handle, _personsAppearedLocations, appearedLocationPtr);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get result");

            for (int i = 0; i < numOfAppearedPersons; i++)
            {
                Interop.MediaVision.Rectangle rect = (Interop.MediaVision.Rectangle)Marshal.PtrToStructure(appearedLocationPtr, typeof(Interop.MediaVision.Rectangle));
                appearedLocations.Add(new Rectangle()
                {
                    Point = new Point()
                    {
                        X = rect.x,
                        Y = rect.y
                    },
                    Width = rect.width,
                    Height = rect.height
                });

                appearedLocationPtr = IntPtr.Add(appearedLocationPtr, Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)));
            }

            ret = Interop.MediaVision.Surveillance.GetResultCount(handle, _personsDisappearedNumber, out numOfDisappearedPersons);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get result");

            IntPtr disAppearedLocationPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)) * numOfDisappearedPersons);
            ret = Interop.MediaVision.Surveillance.GetResultValue(handle, _personsDisappearedLocations, disAppearedLocationPtr);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get result");

            for (int i = 0; i < numOfDisappearedPersons; i++)
            {
                Interop.MediaVision.Rectangle rect = (Interop.MediaVision.Rectangle)Marshal.PtrToStructure(disAppearedLocationPtr, typeof(Interop.MediaVision.Rectangle));
                disappearedLocations.Add(new Rectangle()
                {
                    Point = new Point()
                    {
                        X = rect.x,
                        Y = rect.y
                    },
                    Width = rect.width,
                    Height = rect.height
                });

                disAppearedLocationPtr = IntPtr.Add(disAppearedLocationPtr, Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)));
            }

            ret = Interop.MediaVision.Surveillance.GetResultCount(handle, _personsTrackedNumber, out numOfTrackedPersons);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get result");

            IntPtr trackedLocationPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)) * numOfTrackedPersons);
            ret = Interop.MediaVision.Surveillance.GetResultValue(handle, _personsTrackedLocations, trackedLocationPtr);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to get result");

            for (int i = 0; i < numOfTrackedPersons; i++)
            {
                Interop.MediaVision.Rectangle rect = (Interop.MediaVision.Rectangle)Marshal.PtrToStructure(trackedLocationPtr, typeof(Interop.MediaVision.Rectangle));
                trackedLocations.Add(new Rectangle()
                {
                    Point = new Point()
                    {
                        X = rect.x,
                        Y = rect.y
                    },
                    Width = rect.width,
                    Height = rect.height
                });

                trackedLocationPtr = IntPtr.Add(trackedLocationPtr, Marshal.SizeOf(typeof(Interop.MediaVision.Rectangle)));
            }

            PersonAppearanceChangedEventArgs e = new PersonAppearanceChangedEventArgs()
            {
                VideoStreamId = videoStreamId,
                AppearedLocations = appearedLocations,
                DisappearedLocations = disappearedLocations,
                TrackedLocations = trackedLocations
            };

            return e;
        }
    }
}
