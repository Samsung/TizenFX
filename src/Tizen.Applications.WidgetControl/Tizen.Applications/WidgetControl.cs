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
using Tizen.Applications;

namespace Tizen.Applications
{
    /// <summary>
    /// Class for receiving widget events and sending data to widget.
    /// </summary>
    public class WidgetControl : IDisposable
    {
        /// <summary>
        /// Class for widget instance.
        /// </summary>
        public class Instance
        {
            private string _widgetId;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="widgetId">Widget ID</param>
            public Instance(string widgetId)
            {
                _widgetId = widgetId;
            }

            /// <summary>
            /// Widget ID.
            /// </summary>
            public string Id { get; internal set; }

            /// <summary>
            /// Gets widget content.
            /// </summary>
            /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
            public Bundle GetContent()
            {
                IntPtr h;

                Interop.WidgetService.ErrorCode err = Interop.WidgetService.GetContent(_widgetId, Id, out h);

                switch (err)
                {
                    case Interop.WidgetService.ErrorCode.InvalidParameter:
                        throw new InvalidOperationException("Invalid parameter at unmanaged code");

                    case Interop.WidgetService.ErrorCode.IoError:
                        throw new InvalidOperationException("Failed to access DB");
                }

                return new Bundle(new SafeBundleHandle(h, true));
            }

            /// <summary>
            /// Changes the content for the widget instance.
            /// </summary>
            /// <param name="content">Content to be changed</param>
            /// <param name="force"> True if you want to update your widget even if the provider is paused otherwise false.</param>
            /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
            /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
            /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
            public void ChangeContent(Bundle content, bool force)
            {
                Interop.WidgetService.ErrorCode err = Interop.WidgetService.UpdateContent(_widgetId, Id, content.SafeBundleHandle, force ? 1 : 0);

                switch (err)
                {
                    case Interop.WidgetService.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid parameter");

                    case Interop.WidgetService.ErrorCode.Canceled:
                        throw new InvalidOperationException("Provider is paused, so this update request is canceld");

                    case Interop.WidgetService.ErrorCode.OutOfMemory:
                        throw new InvalidOperationException("Out-of-memory at unmanaged code");

                    case Interop.WidgetService.ErrorCode.Fault:
                        throw new InvalidOperationException("Failed to create a request packet");

                    case Interop.WidgetService.ErrorCode.PermissionDenied:
                        throw new UnauthorizedAccessException();
                }
            }

            /// <summary>
            /// Changes the update period for the widget instance.
            /// </summary>
            /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
            /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
            /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
            public void ChangePeriod(double period)
            {
                Interop.WidgetService.ErrorCode err = Interop.WidgetService.ChangePeriod(_widgetId, Id, period);

                switch (err)
                {
                    case Interop.WidgetService.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid parameter");

                    case Interop.WidgetService.ErrorCode.OutOfMemory:
                        throw new InvalidOperationException("Out-of-memory at unmanaged code");

                    case Interop.WidgetService.ErrorCode.Fault:
                        throw new InvalidOperationException("Failed to create a request packet");

                    case Interop.WidgetService.ErrorCode.PermissionDenied:
                        throw new UnauthorizedAccessException();
                }
            }
        }

        /// <summary>
        /// Class for widget size information.
        /// </summary>
        public class Scale
        {
            /// <summary>
            /// Enumeration for types of widget size
            /// </summary>
            public enum SizeType : int
            {
                /// <summary>
                /// 175x175 based on 720x1280 resolution.
                /// </summary>
                Basic1x1 = 0x0001,

                /// <summary>
                /// 354x175 based on 720x1280 resolution.
                /// </summary>
                Basic2x1 = 0x0002,

                /// <summary>
                /// 354x354 based on 720x1280 resolution.
                /// </summary>
                Basic2x2 = 0x0004,

                /// <summary>
                /// 712x175 based on 720x1280 resolution.
                /// </summary>
                Basic4x1 = 0x0008,

                /// <summary>
                /// 712x354 based on 720x1280 resolution.
                /// </summary>
                Basic4x2 = 0x0010,

                /// <summary>
                /// 712x533 based on 720x1280 resolution.
                /// </summary>
                Basic4x3 = 0x0020,

                /// <summary>
                /// 712x712 based on 720x1280 resolution.
                /// </summary>
                Basic4x4 = 0x0040,

                /// <summary>
                /// 712x891 based on 720x1280 resolution.
                /// </summary>
                Basic4x5 = 0x0080,

                /// <summary>
                /// 712x1070 based on 720x1280 resolution.
                /// </summary>
                Basic4x6 = 0x0100,


                /// <summary>
                /// 224x215 based on 720x1280 resolution.
                /// </summary>
                Easy1x1 = 0x1000,

                /// <summary>
                /// 680x215 based on 720x1280 resolution.
                /// </summary>
                Easy1x2 = 0x2000,

                /// <summary>
                /// 680x653 based on 720x1280 resolution.
                /// </summary>
                Easy1x3 = 0x4000,

                /// <summary>
                /// 720x1280 based on 720x1280 resolution.
                /// </summary>
                Full = 0x0800,
            }

            /// <summary>
            /// Widget width.
            /// </summary>
            public int Width { get; internal set; }

            /// <summary>
            /// Widget height.
            /// </summary>
            public int Height { get; internal set; }

            /// <summary>
            /// The path for widget preview image file.
            /// </summary>
            public string PreviewImagePath { get; internal set; }

            /// <summary>
            /// The size type of the widget.
            /// </summary>
            public SizeType Type { get; internal set; }
        }

        private event EventHandler<WidgetLifecycleEventArgs> _created;
        private event EventHandler<WidgetLifecycleEventArgs> _resumed;
        private event EventHandler<WidgetLifecycleEventArgs> _paused;
        private event EventHandler<WidgetLifecycleEventArgs> _destroyed;
        private bool _disposedValue = false;
        private static IDictionary<string, int> s_lifecycleEventRefCnt = new Dictionary<string, int>();
        private static IList<WidgetControl> s_eventObjects = new List<WidgetControl>();

        /// <summary>
        /// Factory method for WidgetControl.
        /// It will create all objects of WidgetControl base on package ID.
        /// </summary>
        /// <param name="pkgId">Parkage ID</param>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        public static WidgetControl[] CreateAll(string pkgId)
        {
            List<WidgetControl> list = new List<WidgetControl>();

            Interop.WidgetService.ErrorCode err = Interop.WidgetService.GetWidgetListByPkgId(pkgId, (widgetId, isPrime, userData) =>
            {
                list.Add(new WidgetControl(widgetId));
            }, IntPtr.Zero);

            switch (err)
            {
                case Interop.WidgetService.ErrorCode.InvalidParameter:
                    throw new ArgumentException("Invalid parameter");

                case Interop.WidgetService.ErrorCode.IoError:
                    throw new InvalidOperationException("Failed to access DB");

                case Interop.WidgetService.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();
            }

            return list.ToArray();
        }

        /// <summary>
        /// Gets all widget IDs by package ID.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        public static string[] GetWidgetIds(string pkgId)
        {
            List<string> list = new List<string>();

            Interop.WidgetService.ErrorCode err = Interop.WidgetService.GetWidgetListByPkgId(pkgId, (widgetId, isPrime, userData) =>
            {
                list.Add(widgetId);
            }, IntPtr.Zero);

            switch (err)
            {
                case Interop.WidgetService.ErrorCode.InvalidParameter:
                    throw new ArgumentException("Invalid parameter");

                case Interop.WidgetService.ErrorCode.IoError:
                    throw new InvalidOperationException("Failed to access DB");

                case Interop.WidgetService.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();
            }

            return list.ToArray();
        }

        /// <summary>
        /// Widget ID.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// The flag value for "nodisplay"
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        public bool IsNoDisplay
        {
            get
            {
                if (Interop.WidgetService.GetNoDisplay(Id) != 0)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Event handler for created widget instance.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        public event EventHandler<WidgetLifecycleEventArgs> Created
        {
            add
            {
                RegisterLifecycleEvent();
                _created += value;
            }
            remove
            {
                _created -= value;
                UnregisterLifecycleEvent();
            }
        }

        /// <summary>
        /// Event handler for resumed widget instance.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        public event EventHandler<WidgetLifecycleEventArgs> Resumed
        {
            add
            {
                RegisterLifecycleEvent();
                _resumed += value;
            }
            remove
            {
                _resumed -= value;
                UnregisterLifecycleEvent();
            }
        }

        /// <summary>
        /// Event handler for paused widget instance.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        public event EventHandler<WidgetLifecycleEventArgs> Paused
        {
            add
            {
                RegisterLifecycleEvent();
                _paused += value;
            }
            remove
            {
                _paused -= value;
                UnregisterLifecycleEvent();
            }
        }

        /// <summary>
        /// Event handler for destroyed widget instance.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        public event EventHandler<WidgetLifecycleEventArgs> Destroyed
        {
            add
            {
                RegisterLifecycleEvent();
                _destroyed += value;
            }
            remove
            {
                _destroyed -= value;
                UnregisterLifecycleEvent();
            }
        }

        /// <summary>
        /// A constructor of WidgetControl object
        /// </summary>
        /// <param name="widgetId">widget id.</param>
        public WidgetControl(string widgetId)
        {
            Id = widgetId;
        }

        /// <summary>
        /// Finalizer of the WidgetControl class.
        /// </summary>
        ~WidgetControl()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets objects for widget instance information.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <exception cref="NotSupportedException">Thrown when API is not supported in this device</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        public IEnumerable<Instance> GetInstances()
        {
            IList<Instance> instances = new List<Instance>();
            Interop.WidgetService.ErrorCode err = Interop.WidgetService.GetInstances(Id, (widgetId, instanceId, userData) =>
            {
                instances.Add(new Instance(widgetId) { Id = instanceId });
            }, IntPtr.Zero);

            switch (err)
            {
                case Interop.WidgetService.ErrorCode.InvalidParameter:
                    throw new InvalidOperationException("Invalid parameter at unmanaged code");

                case Interop.WidgetService.ErrorCode.NotSupported:
                    throw new NotSupportedException();

                case Interop.WidgetService.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();
            }

            return instances;
        }

        /// <summary>
        /// Gets objects for widget scale information.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        public IEnumerable<Scale> GetScales()
        {
            int[] w = new int[100];
            int[] h = new int[100];
            int[] types = new int[100];
            int cnt1 = 100;
            int cnt2 = 100;
            IList<Scale> scales = new List<Scale>();

            Interop.WidgetService.ErrorCode err = Interop.WidgetService.GetSupportedSizes(Id, ref cnt1, out w, out h);

            switch (err)
            {
                case Interop.WidgetService.ErrorCode.InvalidParameter:
                    throw new InvalidOperationException("Invalid parameter at unmanaged code");

                case Interop.WidgetService.ErrorCode.IoError:
                    throw new InvalidOperationException("Failed to access DB");

                case Interop.WidgetService.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();
            }

            err = Interop.WidgetService.GetSupportedSizeTypes(Id, ref cnt2, out types);

            switch (err)
            {
                case Interop.WidgetService.ErrorCode.InvalidParameter:
                    throw new InvalidOperationException("Invalid parameter at unmanaged code");

                case Interop.WidgetService.ErrorCode.IoError:
                    throw new InvalidOperationException("Failed to access DB");

                case Interop.WidgetService.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();
            }

            if (cnt1 != cnt2)
                return null;

            for (int i = 0; i < cnt1; i++)
            {
                string prev = Interop.WidgetService.GetPreviewImagePath(Id, types[i]);

                scales.Add(new Scale()
                {
                    Width = w[i],
                    Height = h[i],
                    PreviewImagePath = prev,
                    Type = (Scale.SizeType)types[i]
                });
            }
            return scales;
        }

        /// <summary>
        /// Gets widget name.
        /// </summary>
        /// <param name="lang">Language</param>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
        public string GetName(string lang)
        {
            if (lang == null)
                throw new ArgumentNullException();

            return Interop.WidgetService.GetName(Id, lang);
        }

        /// <summary>
        /// Gets widget icon path.
        /// </summary>
        /// <param name="lang">Language</param>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
        public string GetIconPath(string lang)
        {
            if (lang == null)
                throw new ArgumentNullException();

            string pkgId = Interop.WidgetService.GetPkgId(Id);

            return Interop.WidgetService.GetIcon(pkgId, lang);
        }

        /// <summary>
        /// Releases all resources used by the WidgetControl class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }

                _created = null;
                _resumed = null;
                _paused = null;
                _destroyed = null;
                UnregisterLifecycleEvent();

                _disposedValue = true;
            }
        }

        private void RegisterLifecycleEvent()
        {
            if (!s_lifecycleEventRefCnt.ContainsKey(Id))
                s_lifecycleEventRefCnt[Id] = 0;

            if (_created != null || _paused != null || _resumed != null || _destroyed != null)
                return;

            if (s_lifecycleEventRefCnt[Id] == 0)
            {
                Interop.WidgetService.ErrorCode err = Interop.WidgetService.SetLifecycleEvent(Id, OnLifecycleEvent, IntPtr.Zero);

                switch (err)
                {
                    case Interop.WidgetService.ErrorCode.InvalidParameter:
                        throw new InvalidOperationException("Invalid parameter at unmanaged code");

                    case Interop.WidgetService.ErrorCode.PermissionDenied:
                        throw new UnauthorizedAccessException();
                }
            }

            s_lifecycleEventRefCnt[Id]++;
            s_eventObjects.Add(this);
        }

        private void UnregisterLifecycleEvent()
        {
            if (!s_lifecycleEventRefCnt.ContainsKey(Id))
                return;

            if (s_lifecycleEventRefCnt[Id] <= 0)
                return;

            if (_created != null || _paused != null || _resumed != null || _destroyed != null)
                return;

            if (s_lifecycleEventRefCnt[Id] == 1)
            {
                Interop.WidgetService.ErrorCode err = Interop.WidgetService.UnsetLifecycleEvent(Id, IntPtr.Zero);

                switch (err)
                {
                    case Interop.WidgetService.ErrorCode.InvalidParameter:
                        throw new InvalidOperationException("Invalid parameter at unmanaged code");

                    case Interop.WidgetService.ErrorCode.PermissionDenied:
                        throw new UnauthorizedAccessException();

                    case Interop.WidgetService.ErrorCode.NotExist:
                        throw new InvalidOperationException("Event handler is not exist");
                }
            }

            s_eventObjects.Remove(this);
            s_lifecycleEventRefCnt[Id]--;
        }

        private static void OnLifecycleEvent(string widgetId, Interop.WidgetService.LifecycleEvent e, string instanceId, IntPtr userData)
        {
            switch (e)
            {
                case Interop.WidgetService.LifecycleEvent.Created:
                    foreach (WidgetControl c in s_eventObjects)
                    {
                        if (c.Id.CompareTo(widgetId) == 0)
                        {
                            c._created?.Invoke(null, new WidgetLifecycleEventArgs()
                            {
                                WidgetId = widgetId,
                                InstanceId = instanceId,
                                Type = WidgetLifecycleEventArgs.EventType.Created
                            });
                        }
                    }
                    break;

                case Interop.WidgetService.LifecycleEvent.Resumed:
                    foreach (WidgetControl c in s_eventObjects)
                    {
                        if (c.Id.CompareTo(widgetId) == 0)
                        {
                            c._resumed?.Invoke(null, new WidgetLifecycleEventArgs()
                            {
                                WidgetId = widgetId,
                                InstanceId = instanceId,
                                Type = WidgetLifecycleEventArgs.EventType.Resumed
                            });
                       }
                    }
                    break;

                case Interop.WidgetService.LifecycleEvent.Paused:
                    foreach (WidgetControl c in s_eventObjects)
                    {
                        if (c.Id.CompareTo(widgetId) == 0)
                        {
                            c._paused?.Invoke(null, new WidgetLifecycleEventArgs()
                            {
                                WidgetId = widgetId,
                                InstanceId = instanceId,
                                Type = WidgetLifecycleEventArgs.EventType.Paused
                            });
                        }
                    }
                    break;

                case Interop.WidgetService.LifecycleEvent.Destroyed:
                    foreach (WidgetControl c in s_eventObjects)
                    {
                        if (c.Id.CompareTo(widgetId) == 0)
                        {
                            c._destroyed?.Invoke(null, new WidgetLifecycleEventArgs()
                            {
                                WidgetId = widgetId,
                                InstanceId = instanceId,
                                Type = WidgetLifecycleEventArgs.EventType.Destroyed
                            });
                        }
                    }
                    break;
            }

        }
    }
}
