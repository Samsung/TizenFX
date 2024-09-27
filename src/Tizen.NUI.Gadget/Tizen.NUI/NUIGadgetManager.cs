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
using System.Runtime.Loader;
using System.Reflection;
using System.Threading.Tasks;
using System.Security.AccessControl;

using SystemIO = System.IO;

namespace Tizen.NUI
{
    /// <summary>
    /// The NUIGadgetManager provides methods and events related to managing gadgets in the NUI.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class NUIGadgetManager
    {
        private static readonly Dictionary<string, NUIGadgetInfo> _gadgetInfos = new Dictionary<string, NUIGadgetInfo>();
        private static readonly List<NUIGadget> _gadgets = new List<NUIGadget>();

        static NUIGadgetManager()
        {
            IntPtr gadgetPkgIds = Interop.Libc.GetEnviornmentVariable("GADGET_PKGIDS");
            if (gadgetPkgIds != IntPtr.Zero)
            {
                string packages = Marshal.PtrToStringAnsi(gadgetPkgIds);
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
        /// <remarks>
        /// This event is raised when the state of the NUIGadget changes.
        /// It provides information about the current state through the NUIGadgetLifecycleChangedEventArgs argument.
        /// </remarks>
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
        /// <remarks>
        /// This method loads an assembly of the NUIGadget based on the specified resource type.
        /// It throws an ArgumentException if the argument is invalid, or an InvalidOperationException if the operation fails due to any reason.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void Load(string resourceType)
        {
            Load(resourceType, true);
        }

        /// <summary>
        /// Loads an assembly of the NUIGadget.
        /// </summary>
        /// <param name="resourceType">The resource type of the NUIGadget package.</param>
        /// <param name="useDefaultContext">Indicates whether to use a default load context or not.</param>
        /// <exception cref="ArgumentException">Thrown when failed due to an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed due to an invalid operation.</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void Load(string resourceType, bool useDefaultContext)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            NUIGadgetInfo info = Find(resourceType);
            Load(info, useDefaultContext);
        }

        /// <summary>
        /// Unloads the specified NUIGadget assembly from memory.
        /// </summary>
        /// <remarks>
        /// To use this method properly, the assembly of the gadget must be loaded using Load() with the custom context.
        /// </remarks>
        /// <param name="resourceType">The resource type of the NUIGadget package to unload.</param>
        /// <exception cref="ArgumentException">Thrown when the argument passed is not valid.</exception>
        /// <example>
        /// <code>
        /// /// Load an assembly of the NUIGadget.
        /// NUIGadgetManager.Load("org.tizen.appfw.gadget.NetworkSetting", false);
        /// /// NUIGadgetManager.Add("org.tizen.appfw.gadget.NetworkSetting", "NetworkSettingGadget", false);
        ///
        /// /// Unload the loaded assembly
        /// NUIGadgetManager.Unload("org.tizen.appfw.gadget.NetworkSetting");
        /// </code>
        /// </example>
        /// <since_tizen> 10 </since_tizen>
        public static void Unload(string resourceType)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            NUIGadgetInfo info = Find(resourceType);
            Unload(info);
        }

        private static void Unload(NUIGadgetInfo info)
        {
            if (info == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            lock (info)
            {
                if (info.NUIGadgetAssembly != null && info.NUIGadgetAssembly.IsLoaded)
                {
                    info.NUIGadgetAssembly.Unload();
                    info.NUIGadgetAssembly = null;
                }
            }
        }

        private static void Load(NUIGadgetInfo info, bool useDefaultContext)
        {
            if (info == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            try
            {
                lock (info)
                {
                    if (useDefaultContext)
                    {
                        if (info.Assembly == null)
                        {

                            Log.Warn("NUIGadget.Load(): " + info.ResourcePath + info.ExecutableFile + " ++");
                            info.Assembly = Assembly.Load(SystemIO.Path.GetFileNameWithoutExtension(info.ExecutableFile));
                            Log.Warn("NUIGadget.Load(): " + info.ResourcePath + info.ExecutableFile + " --");
                        }
                    }
                    else
                    {
                        if (info.NUIGadgetAssembly == null)
                        {
                            Log.Warn("NUIGadgetAssembly.Load(): " + info.ResourcePath + info.ExecutableFile + " ++");
                            info.NUIGadgetAssembly = new NUIGadgetAssembly(info.ResourcePath + info.ExecutableFile);
                            info.NUIGadgetAssembly.Load();
                            Log.Warn("NUIGadgetAssembly.Load(): " + info.ResourcePath + info.ExecutableFile + " --");
                        }
                    }
                }
            }
            catch (FileLoadException e)
            {
                throw new InvalidOperationException(e.Message);
            }
            catch (BadImageFormatException e)
            {
                throw new InvalidOperationException(e.Message);
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
            return Add(resourceType, className, true);
        }

        /// <summary>
        /// Adds a NUIGadget to the NUIGadgetManager.
        /// </summary>
        /// <remarks>
        /// To use Unload() method, the useDefaultContext must be'false'.
        /// </remarks>
        /// <param name="resourceType">The resource type of the NUIGadget package.</param>
        /// <param name="className">The class name of the NUIGadget.</param>
        /// <param name="useDefaultContext">The flag it true, use a default context. Otherwise, use a new load context.</param>
        /// <returns>The NUIGadget object.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 10 </since_tizen>
        public static NUIGadget Add(string resourceType, string className, bool useDefaultContext)
        {
            if (string.IsNullOrEmpty(resourceType) || string.IsNullOrEmpty(className))
            {
                throw new ArgumentException("Invalid argument");
            }

            NUIGadgetInfo info = Find(resourceType);
            Load(info, useDefaultContext);

            NUIGadget gadget = useDefaultContext ? info.Assembly.CreateInstance(className, true) as NUIGadget : info.NUIGadgetAssembly.CreateInstance(className);
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
        /// Retrieves the instances of currently running NUIGadgets.
        /// </summary>
        /// <returns>An enumerable list containing all the active NUIGadgets.</returns>
        /// <since_tizen> 10 </since_tizen>
        public static IEnumerable<NUIGadget> GetGadgets()
        {
            return _gadgets;
        }

        /// <summary>
        /// Retrieves information about available NUIGadgets.
        /// </summary>
        /// <remarks>
        /// This method provides details on gadgets that are currently accessible rather than listing all installed gadgets.
        /// A NUIGadget's resource package may specify which applications have access through the "allowed-packages" setting.
        /// During execution, the platform mounts the resource package in the application's resources directory.
        /// </remarks>
        /// <returns>An enumerable list of NUIGadgetInfo objects.</returns>
        /// <since_tizen> 10 </since_tizen>
        public static IEnumerable<NUIGadgetInfo> GetGadgetInfos()
        {
            return _gadgetInfos.Values.ToList();
        }

        /// <summary>
        /// Removes the specified NUIGadget from the NUIGadgetManager.
        /// </summary>
        /// <param name="gadget">The NUIGadget object that needs to be removed.</param>
        /// <remarks>
        /// This method allows you to remove a specific NUIGadget from the NUIGadgetManager.
        /// By passing the NUIGadget object as an argument, you can ensure that only the desired gadget is removed.
        /// It is important to note that once a gadget is removed, any references to it become invalid.
        /// Therefore, it is crucial to handle the removal process carefully to avoid any potential issues.
        /// </remarks>
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
        /// Removes all NUIGadgets from the NUIGadgetManager.
        /// </summary>
        /// <remarks>
        /// This method is called to remove all NUIGadgets that are currently registered in the NUIGadgetManager.
        /// It ensures that no more NUIGadgets exist after calling this method.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public static void RemoveAll()
        {
            for (int i = _gadgets.Count - 1;  i >= 0; i--)
            {
                Remove(_gadgets[i]);
            }
        }

        /// <summary>
        /// Resumes the execution of the specified NUIGadget.
        /// </summary>
        /// <remarks>
        /// By calling this method, you can resume the execution of the currently suspended NUIGadget.
        /// It takes the NUIGadget object as an argument which represents the target gadget that needs to be resumed.
        /// </remarks>
        /// <param name="gadget">The NUIGadget object whose execution needs to be resumed.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 'gadget' argument is null.</exception>
        /// <example>
        /// To resume the execution of a specific NUIGadget named 'MyGadget', you can call the following code snippet:
        ///
        /// <code>
        /// // Get the reference to the NUIGadget object
        /// NUIGadget MyGadget = ...;
        ///
        /// // Resume its execution
        /// GadgetResume(MyGadget);
        /// </code>
        /// </example>
        /// <since_tizen> 10 </since_tizen>
        public static void Resume(NUIGadget gadget)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

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
        /// Pauses the execution of the specified NUIGadget.
        /// </summary>
        /// <remarks>
        /// Calling this method pauses the currently executing NUIGadget. It does not affect any other gadgets that may be running simultaneously.
        /// </remarks>
        /// <param name="gadget">The NUIGadget object whose execution needs to be paused.</param>
        /// <exception cref="ArgumentNullException">Thrown if the argument 'gadget' is null.</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void Pause(NUIGadget gadget)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

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
        /// Sends the specified application control to the currently running NUIGadget.
        /// </summary>
        /// <param name="gadget">The NUIGadget object that will receive the app control.</param>
        /// <param name="appControl">The app control object containing the desired arguments and actions.</param>
        /// <exception cref="ArgumentException">Thrown if any of the arguments are invalid or missing.</exception>
        /// <exception cref="ArgumentNullException">Thrown if either 'gadget' or 'appControl' is null.</exception>
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
            var extraData = args.ReceivedAppControl?.ExtraData;
            if (extraData == null||!extraData.TryGet("__K_GADGET_RES_TYPE", out string resourceType) ||
                !extraData.TryGet("__K_GADGET_CLASS_NAME", out string className))
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
