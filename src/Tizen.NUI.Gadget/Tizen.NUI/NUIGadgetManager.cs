/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Linq;
using System.IO;
using Tizen.Applications;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Tizen.NUI
{
    /// <summary>
    /// This class has the methods and events of the NUIGadgetManager.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class NUIGadgetManager
    {
        private static readonly Dictionary<string, NUIGadgetInfo> _gadgetInfos = new Dictionary<string, NUIGadgetInfo>();
        private static readonly List<NUIGadget> _gadgets = new List<NUIGadget>();

        static NUIGadgetManager()
        {
            IntPtr resPkgIds = Interop.Libc.GetEnviornmentVariable("RES_PKGIDS");
            if (resPkgIds != IntPtr.Zero)
            {
                string packages = Marshal.PtrToStringAnsi(resPkgIds);
                if (string.IsNullOrEmpty(packages))
                {
                    Log.Warn("There is no resource packages");
                }
                else
                {
                    foreach (string packageId in packages.Split(':').ToList())
                    {
                        NUIGadgetInfo info = NUIGadgetInfo.CreateNUIGadgetInfo(packageId);
                        if (info != null)
                        {
                            _gadgetInfos.Add(info.ResourceType, info);
                        }
                    }
                }
            }
            else
            {
                Log.Warn("Failed to get environment variable");
            }

            var context = (CoreApplication)CoreApplication.Current;
            context.AppControlReceived += OnAppControlReceived;
            context.LowMemory += OnLowMemory;
            context.LowBattery += OnLowBattery;
            context.LocaleChanged += OnLocaleChanged;
            context.RegionFormatChanged += OnRegionFormatChanged;
            context.DeviceOrientationChanged += OnDeviceOrientationChanged;
        }

        private static void OnAppControlReceived(object sender, AppControlReceivedEventArgs args)
        {
            HandleAppControl(args);
        }

        private static void OnLowMemory(object sender, LowMemoryEventArgs args)
        {
            HandleEvents(NUIGadgetEventType.LowMemory, args);
        }

        private static void OnLowBattery(object sender, LowBatteryEventArgs args)
        {
            HandleEvents(NUIGadgetEventType.LowBattery, args);
        }

        private static void OnLocaleChanged(object sender, LocaleChangedEventArgs args)
        {
            HandleEvents(NUIGadgetEventType.LocaleChanged, args);
        }

        private static void OnRegionFormatChanged(object sender, RegionFormatChangedEventArgs args)
        {
            HandleEvents(NUIGadgetEventType.RegionFormatChanged, args);
        }

        private static void OnDeviceOrientationChanged(object sender, DeviceOrientationEventArgs args)
        {
            HandleEvents(NUIGadgetEventType.DeviceORientationChanged, args);
        }

        /// <summary>
        /// Occurs when the lifecycle of the NUIGadget is changed.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public static event EventHandler<NUIGadgetLifecycleChangedEventArgs> NUIGadgetLifecycleChanged;

        private static void OnNUIGadgetLifecycleChanged(object sender, NUIGadgetLifecycleChangedEventArgs args)
        {
            NUIGadgetLifecycleChanged?.Invoke(sender, args);

            if (args.State == NUIGadgetLifecycleState.Destroyed)
            {
                args.Gadget.LifecycleChanged -= OnNUIGadgetLifecycleChanged;
                _gadgets.Remove(args.Gadget);
            }
        }

        private static NUIGadgetInfo Find(string resourceType)
        {
            if (!_gadgetInfos.TryGetValue(resourceType, out NUIGadgetInfo info))
            {
                throw new ArgumentException("Failed to find NUIGadgetInfo. resource type: " + resourceType);
            }

            return info;
        }

        /// <summary>
        /// Loads an assembly of the NUIGadget.
        /// </summary>
        /// <param name="resourceType">The resource type of the NUIGadget package.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void Load(string resourceType)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            NUIGadgetInfo info = Find(resourceType);
            try
            {
                Load(info);
            }
            catch (FileLoadException e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        private static void Load(NUIGadgetInfo info)
        {
            if (info == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            lock (info)
            {
                if (info.Assembly == null)
                {
                    Log.Warn("NUIGadgetAssembly.Load(): " + info.ResourcePath + info.ExecutableFile + " ++");
                    info.Assembly = Assembly.Load(File.ReadAllBytes(info.ResourcePath + info.ExecutableFile));
                    Log.Warn("NUIGadgetAssembly.Load(): " + info.ResourcePath + info.ExecutableFile + " --");
                }
            }
        }

        /// <summary>
        /// Adds a NUIGadget to the NUIGadgetManager.
        /// </summary>
        /// <param name="resourceType">The resource type of the NUIGadget package.</param>
        /// <param name="className">The class name of the NUIGadget.</param>
        /// <returns>The NUIGadget object.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 10 </since_tizen>
        public static NUIGadget Add(string resourceType, string className)
        {
            if (string.IsNullOrEmpty(resourceType) || string.IsNullOrEmpty(className))
            {
                throw new ArgumentException("Invalid argument");
            }

            NUIGadgetInfo info = Find(resourceType);
            try
            {
                Load(info);
            }
            catch (FileLoadException e)
            {
                throw new InvalidOperationException(e.Message);
            }

            NUIGadget gadget = info.Assembly.CreateInstance(className, true) as NUIGadget;
            if (gadget == null)
            {
                throw new InvalidOperationException("Failed to create instance. className: " + className);
            }

            gadget.NUIGadgetInfo = info;
            gadget.ClassName = className;
            gadget.NUIGadgetResourceManager = new NUIGadgetResourceManager(info);
            gadget.LifecycleChanged += OnNUIGadgetLifecycleChanged;
            if (!gadget.Create())
            {
                throw new InvalidOperationException("The View MUST be created");
            }

            _gadgets.Add(gadget);
            return gadget;
        }

        /// <summary>
        /// Gets the instance of the running NUIGadgets.
        /// </summary>
        /// <returns>The NUIGadget list.</returns>
        /// <since_tizen> 10 </since_tizen>
        public static IEnumerable<NUIGadget> GetGadgets()
        {
            return _gadgets;
        }

        /// <summary>
        /// Gets the information of the available NUIGadgets.
        /// </summary>
        /// <remarks>
        /// This method only returns the available gadget informations, not all installed gadget informations.
        /// The resource package of the NUIGadget can set the allowed packages using "allowed-package".
        /// When executing an application, the platform mounts the resource package into the resource path of the application.
        /// </remarks>
        /// <returns>The NUIGadgetInfo list.</returns>
        /// <since_tizen> 10 </since_tizen>
        public static IEnumerable<NUIGadgetInfo> GetGadgetInfos()
        {
            return _gadgetInfos.Values.ToList();
        }

        /// <summary>
        /// Removes the NUIGadget from a NUIGadgetManager.
        /// </summary>
        /// <param name="gadget">The NUIGadget object.</param>
        /// <since_tizen> 10 </since_tizen>
        public static void Remove(NUIGadget gadget)
        {
            if (gadget == null || !_gadgets.Contains(gadget))
            {
                return;
            }

            if (gadget.State == NUIGadgetLifecycleState.Destroyed)
            {
                return;
            }

            _gadgets.Remove(gadget);
            CoreApplication.Post(() => {
                Log.Warn("ResourceType: " + gadget.NUIGadgetInfo.ResourceType + ", State: " + gadget.State);
                gadget.Finish();
            });
        }

        /// <summary>
        /// Removes all NUIGadget from a NUIGadgetManager.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public static void RemoveAll()
        {
            for (int i = _gadgets.Count - 1;  i >= 0; i--)
            {
                Remove(_gadgets[i]);
            }
        }

        /// <summary>
        /// Resumes the running NUIGadget.
        /// </summary>
        /// <param name="gadget">The NUIGadget object.</param>
        /// <since_tizen> 10 </since_tizen>
        public static void Resume(NUIGadget gadget)
        {
            if (!_gadgets.Contains(gadget))
            {
                return;
            }

            CoreApplication.Post(() =>
            {
                Log.Warn("ResourceType: " + gadget.NUIGadgetInfo.ResourceType + ", State: " + gadget.State);
                gadget.Resume();
            });
        }

        /// <summary>
        /// Pauses the running NUIGadget.
        /// </summary>
        /// <param name="gadget">The NUIGadget object.</param>
        /// <since_tizen> 10 </since_tizen>
        public static void Pause(NUIGadget gadget)
        {
            if (!_gadgets.Contains(gadget))
            {
                return;
            }

            CoreApplication.Post(() =>
            {
                Log.Warn("ResourceType: " + gadget.NUIGadgetInfo.ResourceType + ", State: " + gadget.State);
                gadget.Pause();
            });
        }

        /// <summary>
        /// Sends the appcontrol to the running NUIGadget.
        /// </summary>
        /// <param name="gadget">The NUIGadget object.</param>
        /// <param name="appControl">The appcontrol object.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when failed because the argument is null.</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void SendAppControl(NUIGadget gadget, AppControl appControl)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            if (!_gadgets.Contains(gadget))
            {
                throw new ArgumentException("Invalid argument");
            }

            if (appControl == null)
            {
                throw new ArgumentNullException(nameof(appControl));
            }

            gadget.HandleAppControlReceivedEvent(new AppControlReceivedEventArgs(new ReceivedAppControl(appControl.SafeAppControlHandle)));
        }

        internal static bool HandleAppControl(AppControlReceivedEventArgs args)
        {
            if (!args.ReceivedAppControl.ExtraData.TryGet("__K_GADGET_RES_TYPE", out string resourceType) ||
                !args.ReceivedAppControl.ExtraData.TryGet("__K_GADGET_CLASS_NAME", out string className))
            {
                return false;
            }

            foreach (NUIGadget gadget in _gadgets)
            {
                if (gadget.NUIGadgetInfo.ResourceType == resourceType && gadget.ClassName == className)
                {
                    gadget.HandleAppControlReceivedEvent(args);
                    return true;
                }
            }

            return false;
        }

        internal static void HandleEvents(NUIGadgetEventType eventType, EventArgs args)
        {
            foreach (NUIGadget gadget in _gadgets)
            {
                gadget.HandleEvents(eventType, args);
            }
        }
    }
}
