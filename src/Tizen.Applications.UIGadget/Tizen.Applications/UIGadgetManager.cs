/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Reflection;
using System.ComponentModel;

using SystemIO = System.IO;

namespace Tizen.Applications
{
    /// <summary>
    /// The UIGadgetManager provides methods and events related to managing UIGadgets in the NUI.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class UIGadgetManager
    {
        private static readonly ConcurrentDictionary<string, UIGadgetInfo> _gadgetInfos = new ConcurrentDictionary<string, UIGadgetInfo>(StringComparer.Ordinal);
        private static readonly ConcurrentDictionary<IUIGadget, byte> _gadgets = new ConcurrentDictionary<IUIGadget, byte>();

        static UIGadgetManager()
        {
            var ptr = Interop.Libc.GetEnvironmentVariable("GADGET_PKGIDS");
            if (ptr != IntPtr.Zero)
            {
                var packages = Marshal.PtrToStringAnsi(ptr);
                if (!string.IsNullOrWhiteSpace(packages))
                {
                    foreach (var pkg in packages.Split(':'))
                    {
                        var info = UIGadgetInfo.CreateUIGadgetInfo(pkg);
                        if (info != null)
                        {
                            try
                            {
                                _gadgetInfos.TryAdd(info.ResourceType, info);
                            }
                            catch (Exception e) when (e is ArgumentNullException || e is OverflowException)
                            {
                                Log.Error("Exception occurs. " + e.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                Log.Warn("Failed to get environment variable");
            }

            var app = (CoreApplication)CoreApplication.Current;
            app.AppControlReceived += (s, e) => HandleAppControl(e);
            app.LowMemory += (s, e) => HandleLowMemoryEvent(e);
            app.LowBattery += (s, e) => HandleLowBatteryEvent(e);
            app.LocaleChanged += (s, e) => HandleLocaleChangedEvent(e);
            app.RegionFormatChanged += (s, e) => HandleRegionFormatChangedEvent(e);
            app.DeviceOrientationChanged += (s, e) => HandleDeviceOrientationChangedEvent(e);

            UIGadgetLifecycleEventBroker.LifecycleChanged += OnUIGadgetLifecycleChanged;
        }

        /// <summary>
        /// Occurs when the lifecycle of the UIGadget is changed.
        /// </summary>
        /// <remarks>
        /// This event is raised when the state of the UIGadget changes.
        /// It provides information about the current state through the UIGadgetLifecycleChangedEventArgs argument.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public static event EventHandler<UIGadgetLifecycleChangedEventArgs> UIGadgetLifecycleChanged;

        private static void OnUIGadgetLifecycleChanged(object sender, UIGadgetLifecycleChangedEventArgs args)
        {
            UIGadgetLifecycleChanged?.Invoke(sender, args);

            if (args.State == UIGadgetLifecycleState.Destroyed)
            {
                _gadgets.TryRemove(args.UIGadget, out _);
            }
        }

        private static UIGadgetInfo Find(string resourceType)
        {
            if (!_gadgetInfos.TryGetValue(resourceType, out var info))
            {
                throw new ArgumentException("Failed to find UIGadgetInfo. resource type: " + resourceType);
            }

            return info;
        }

        /// <summary>
        /// Loads an assembly of the UIGadget.
        /// </summary>
        /// <param name="resourceType">The resource type of the UIGadget package.</param>
        /// <remarks>
        /// This method loads an assembly of the UIGadget based on the specified resource type.
        /// It throws an ArgumentException if the argument is invalid, or an InvalidOperationException if the operation fails due to any reason.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Load(string resourceType) => Load(resourceType, true);

        /// <summary>
        /// Loads an assembly of the UIGadget.
        /// </summary>
        /// <param name="resourceType">The resource type of the UIGadget package.</param>
        /// <param name="useDefaultContext">Indicates whether to use a default load context or not.</param>
        /// <exception cref="ArgumentException">Thrown when failed due to an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed due to an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Load(string resourceType, bool useDefaultContext)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            UIGadgetInfo info = Find(resourceType);
            LoadInternal(info, useDefaultContext);
        }

        private static void LoadInternal(UIGadgetInfo info, bool useDefaultContext)
        {
            if (info == null)
            {
                throw new ArgumentException("Invalid argument", nameof(info));
            }

            try
            {
                lock (info)
                {
                    if (useDefaultContext)
                    {
                        if (info.Assembly == null)
                        {

                            Log.Warn("UIGadget.Load(): " + info.ResourcePath + info.ExecutableFile + " ++");
                            info.Assembly = Assembly.Load(SystemIO.Path.GetFileNameWithoutExtension(info.ExecutableFile));
                            Log.Warn("UIGadget.Load(): " + info.ResourcePath + info.ExecutableFile + " --");
                        }
                    }
                    else
                    {
                        if (info.UIGadgetAssembly == null || !info.UIGadgetAssembly.IsLoaded)
                        {
                            Log.Warn("UIGadgetAssembly.Load(): " + info.UIGadgetResourcePath + info.ExecutableFile + " ++");
                            info.UIGadgetAssembly = new UIGadgetAssembly(info.UIGadgetResourcePath + info.ExecutableFile);
                            info.UIGadgetAssembly.Load();
                            Log.Warn("UIGadgetAssembly.Load(): " + info.UIGadgetResourcePath + info.ExecutableFile + " --");
                        }
                    }
                }
            }
            catch (Exception e) when (e is FileLoadException || e is BadImageFormatException)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }

        /// <summary>
        /// Unloads the specified UIGadget assembly from memory.
        /// </summary>
        /// <remarks>
        /// To use this method properly, the assembly of the UIGadget must be loaded using Load() with the custom context.
        /// </remarks>
        /// <param name="resourceType">The resource type of the UIGadget package to unload.</param>
        /// <exception cref="ArgumentException">Thrown when the argument passed is not valid.</exception>
        /// <example>
        /// <code>
        /// /// Load an assembly of the UIGadget.
        /// UIGadgetManager.Load("org.tizen.appfw.UIGadget.NetworkSetting", false);
        /// /// UIGadgetManager.Add("org.tizen.appfw.UIGadget.NetworkSetting", "NetworkSettingUIGadget", false);
        ///
        /// /// Unload the loaded assembly
        /// UIGadgetManager.Unload("org.tizen.appfw.UIGadget.NetworkSetting");
        /// </code>
        /// </example>
        /// <since_tizen> 13 </since_tizen>
        public static void Unload(string resourceType)
        {
            if (string.IsNullOrWhiteSpace(resourceType))
            {
                throw new ArgumentException("Invalid argument", nameof(resourceType));
            }

            UIGadgetInfo info = Find(resourceType);
            if (info == null)
            {
                throw new ArgumentException("Invalid argument", nameof(resourceType));
            }

            lock (info)
            {
                if (info.UIGadgetAssembly?.IsLoaded == true)
                {
                    info.UIGadgetAssembly.Unload();
                }
            }
        }

        /// <summary>
        /// Adds a UIGadget to the UIGadgetManager.
        /// </summary>
        /// <param name="resourceType">The resource type of the UIGadget package.</param>
        /// <param name="className">The class name of the UIGadget.</param>
        /// <returns>The UIGadget object.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static IUIGadget Add(string resourceType, string className) => Add(resourceType, className, true);

        /// <summary>
        /// Adds a UIGadget to the UIGadgetManager.
        /// </summary>
        /// <remarks>
        /// To use Unload() method, the useDefaultContext must be'false'.
        /// </remarks>
        /// <param name="resourceType">The resource type of the UIGadget package.</param>
        /// <param name="className">The class name of the UIGadget.</param>
        /// <param name="useDefaultContext">The flag it true, use a default context. Otherwise, use a new load context.</param>
        /// <returns>The UIGadget object.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static IUIGadget Add(string resourceType, string className, bool useDefaultContext)
        {
            var gadget = CreateInstance(resourceType, className, useDefaultContext);
            if (gadget != null)
            {
                PreCreate(gadget);
                Create(gadget);
            }
            return gadget;
        }

        /// <summary>
        /// Retrieves the instances of currently running UIGadgets.
        /// </summary>
        /// <returns>An enumerable list containing all the active UIGadgets.</returns>
        /// <since_tizen> 13 </since_tizen>
        public static IEnumerable<IUIGadget> GetUIGadgets() => _gadgets.Keys;

        /// <summary>
        /// Retrieves information about available UIGadgets.
        /// </summary>
        /// <remarks>
        /// This method provides details on UIGadgets that are currently accessible rather than listing all installed UIGadgets.
        /// A UIGadget's resource package may specify which applications have access through the "allowed-packages" setting.
        /// During execution, the platform mounts the resource package in the application's resources directory.
        /// </remarks>
        /// <returns>An enumerable list of UIGadgetInfo objects.</returns>
        /// <since_tizen> 13 </since_tizen>
        public static IEnumerable<UIGadgetInfo> GetUIGadgetInfos() => _gadgetInfos.Values;


        /// <summary>
        /// Creates a new UIGadget instance.
        /// </summary>
        /// <remarks>
        /// To use Unload() method, the useDefaultContext must be'false'.
        /// </remarks>
        /// <param name="resourceType">The resource type of the UIGadget package.</param>
        /// <param name="className">The class name of the UIGadget.</param>
        /// <param name="useDefaultContext">The flag it true, use a default context. Otherwise, use a new load context.</param>
        /// <returns>The UIGadget object.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static IUIGadget CreateInstance(string resourceType, string className, bool useDefaultContext)
        {
            if (string.IsNullOrWhiteSpace(resourceType) || string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Invalid argument");
            }

            UIGadgetInfo info = Find(resourceType);
            LoadInternal(info, useDefaultContext);

            IUIGadget gadget = useDefaultContext ? info.Assembly.CreateInstance(className, true) as IUIGadget : info.UIGadgetAssembly.CreateInstance(className) as IUIGadget;
            if (gadget == null)
            {
                throw new InvalidOperationException("Failed to create instance. className: " + className);
            }

            gadget.UIGadgetInfo = info;
            gadget.ClassName = className;
            gadget.UIGadgetResourceManager = new UIGadgetResourceManager(info);
            Log.Info("Gadget is created. ResourceType=" + resourceType);
            return gadget;
        }

        /// <summary>
        /// Executes the pre-creation process of the UIGadget.
        /// </summary>
        /// <param name="gadget">The UIGadget object to perform the pre-creation process.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 'UIGadget' argument is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void PreCreate(IUIGadget gadget)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            Log.Warn("ResourceType: " + gadget.UIGadgetInfo.ResourceType + ", State: " + gadget.State);
            if (gadget.State == UIGadgetLifecycleState.Initialized)
            {
                gadget.OnPreCreate();
            }
        }

        /// <summary>
        /// Executes the creation process of the UIGadget.
        /// </summary>
        /// <param name="gadget">The UIGadget object to perform the creation process.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 'UIGadget' argument is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Create(IUIGadget gadget)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            if (_gadgets.ContainsKey(gadget))
            {
                Log.Error("Already exists. ResourceType:" + gadget.UIGadgetInfo.ResourceType);
                return;
            }

            Log.Warn("ResourceType: " + gadget.UIGadgetInfo.ResourceType + ", State: " + gadget.State);
            if (gadget.State != UIGadgetLifecycleState.PreCreated)
            {
                gadget.MainView = gadget.OnCreate();
                if (gadget.MainView == null)
                {
                    throw new InvalidOperationException("The View MUST be created");
                }

                _gadgets.TryAdd(gadget, 0);
            }
        }

        /// <summary>
        /// Removes the specified UIGadget from the UIGadgetManager.
        /// </summary>
        /// <param name="gadget">The UIGadget object that needs to be removed.</param>
        /// <remarks>
        /// This method allows you to remove a specific UIGadget from the UIGadgetManager.
        /// By passing the UIGadget object as an argument, you can ensure that only the desired UIGadget is removed.
        /// It is important to note that once a UIGadget is removed, any references to it become invalid.
        /// Therefore, it is crucial to handle the removal process carefully to avoid any potential issues.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public static void Remove(IUIGadget gadget)
        {
            if (gadget == null || !_gadgets.ContainsKey(gadget) || gadget.State == UIGadgetLifecycleState.Destroyed)
            {
                return;
            }

            _gadgets.TryRemove(gadget, out _);
            CoreApplication.Post(() =>
            {
                Log.Warn("ResourceType: " + gadget.UIGadgetInfo.ResourceType + ", State: " + gadget.State);
                gadget.Finish();
            });
        }

        /// <summary>
        /// Removes all UIGadgets from the UIGadgetManager.
        /// </summary>
        /// <remarks>
        /// This method is called to remove all UIGadgets that are currently registered in the UIGadgetManager.
        /// It ensures that no more UIGadgets exist after calling this method.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public static void RemoveAll()
        {
            foreach (var gadget in _gadgets.Keys.ToList())
            {
                Remove(gadget);
            }
        }

        /// <summary>
        /// Resumes the execution of the specified UIGadget.
        /// </summary>
        /// <remarks>
        /// By calling this method, you can resume the execution of the currently suspended UIGadget.
        /// It takes the UIGadget object as an argument which represents the target UIGadget that needs to be resumed.
        /// </remarks>
        /// <param name="gadget">The UIGadget object whose execution needs to be resumed.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 'UIGadget' argument is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Resume(IUIGadget gadget)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            if (!_gadgets.ContainsKey(gadget))
            {
                return;
            }

            CoreApplication.Post(() =>
            {
                Log.Warn("ResourceType: " + gadget.UIGadgetInfo.ResourceType + ", State: " + gadget.State);
                if (gadget.State == UIGadgetLifecycleState.Created || gadget.State == UIGadgetLifecycleState.Paused)
            {
                    gadget.OnResume();
                }
            });
        }

        /// <summary>
        /// Pauses the execution of the specified UIGadget.
        /// </summary>
        /// <remarks>
        /// Calling this method pauses the currently executing UIGadget. It does not affect any other UIGadgets that may be running simultaneously.
        /// </remarks>
        /// <param name="gadget">The UIGadget object whose execution needs to be paused.</param>
        /// <exception cref="ArgumentNullException">Thrown if the argument 'UIGadget' is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Pause(IUIGadget gadget)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            if (!_gadgets.ContainsKey(gadget))
            {
                return;
            }

            CoreApplication.Post(() =>
            {
                Log.Warn("ResourceType: " + gadget.UIGadgetInfo.ResourceType + ", State: " + gadget.State);
                if (gadget.State == UIGadgetLifecycleState.Resumed)
                {
                    gadget.OnPause();
                }
            });
        }

        /// <summary>
        /// Sends the specified application control to the currently running UIGadget.
        /// </summary>
        /// <param name="gadget">The UIGadget object that will receive the app control.</param>
        /// <param name="appControl">The app control object containing the desired arguments and actions.</param>
        /// <exception cref="ArgumentException">Thrown if any of the arguments are invalid or missing.</exception>
        /// <exception cref="ArgumentNullException">Thrown if either 'UIGadget' or 'appControl' is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void SendAppControl(IUIGadget gadget, AppControl appControl)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            if (!_gadgets.ContainsKey(gadget))
            {
                throw new ArgumentException("Invalid argument", nameof(gadget));
            }

            if (appControl == null)
            {
                throw new ArgumentNullException(nameof(appControl));
            }

            gadget.OnAppControlReceived(new AppControlReceivedEventArgs(new ReceivedAppControl(appControl.SafeAppControlHandle)));
        }

        internal static bool HandleAppControl(AppControlReceivedEventArgs args)
        {
            var extraData = args.ReceivedAppControl?.ExtraData;
            if (extraData == null || !extraData.TryGet("__K_UIGadget_RES_TYPE", out string resourceType) ||
                !extraData.TryGet("__K_UIGadget_CLASS_NAME", out string className))
            {
                return false;
            }

            foreach (var gadget in _gadgets.Keys)
            {
                if (gadget.UIGadgetInfo.ResourceType == resourceType && gadget.ClassName == className)
                {
                    gadget.OnAppControlReceived(args);
                    return true;
                }
            }

            return false;
        }

        private static void HandleLocaleChangedEvent(LocaleChangedEventArgs args)
        {
            foreach (var gadget in _gadgets.Keys)
            {
                gadget.OnLocaleChanged(args);
            }
        }

        private static void HandleLowBatteryEvent(LowBatteryEventArgs args)
        {
            foreach (var gadget in _gadgets.Keys)
            {
                gadget.OnLowBattery(args);
            }
        }

        private static void HandleLowMemoryEvent(LowMemoryEventArgs args)
        {
            foreach (var gadget in _gadgets.Keys)
            {
                gadget.OnLowMemory(args);
            }
        }

        private static void HandleRegionFormatChangedEvent(RegionFormatChangedEventArgs args)
        {
            foreach (var gadget in _gadgets.Keys)
            {
                gadget.OnRegionFormatChanged(args);
            }
        }

        private static void HandleDeviceOrientationChangedEvent(DeviceOrientationEventArgs args)
        {
            foreach (var gadget in _gadgets.Keys)
            {
                gadget.OnDeviceOrientationChanged(args);
            }
        }

        /// <summary>
        /// Occurs when the message is received.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public static event EventHandler<UIGadgetMessageReceivedEventArgs> UIGadgetMessageReceived;

        /// <summary>
        /// Sends the message to the UIGadgetManager.
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ArgumentNullException">Thrown if either 'envelope' is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void SendMessage(Bundle message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            CoreApplication.Post(() => UIGadgetMessageReceived?.Invoke(null, new UIGadgetMessageReceivedEventArgs(message)));
        }

        /// <summary>
        /// Refresh gadget mount and update information in NUIGadgetManager.
        /// </summary>
        /// <remarks>
        /// To use this method properly, All the gadgets should be unloaded in advance.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown if any of gadgets is still loaded.</exception>
        /// <exception cref="IOException">Thrown if internal request fail.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Refresh()
        {
            foreach (var info in _gadgetInfos)
            {
                if (info.Value.UIGadgetAssembly is not null)
                {
                    if (info.Value.UIGadgetAssembly.IsLoaded == true)
                    {
                        Log.Error("Gadget still loaded: " + info.Key);
                        throw new InvalidOperationException("Gadget still loaded");
                    }
                }
            }

            foreach (var info in _gadgetInfos)
            {
                if (info.Value.UIGadgetAssembly is not null)
                {
                    for (int i = 0; info.Value.UIGadgetAssembly.IsAlive && i < 10; i++)
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
            }

            string pkgList = string.Empty;
            var ret = Interop.ApplicationManager.AppRemountGadgetPath(out pkgList);
            if (ret != Interop.ApplicationManager.ErrorCode.None)
            {
                Log.Error("Internal error occurs: " + ret);
                throw new IOException("Internal error");
            }

            _gadgetInfos.Clear();
            if (!string.IsNullOrWhiteSpace(pkgList))
            {
                foreach (var pkg in pkgList.Split(':'))
                {
                    var info = UIGadgetInfo.CreateUIGadgetInfo(pkg);
                    if (info != null)
                    {
                        try
                        {
                            _gadgetInfos.TryAdd(info.ResourceType, info);
                        }
                        catch (Exception e) when (e is ArgumentNullException || e is OverflowException)
                        {
                            Log.Error("Exception occurs. " + e.Message);
                        }
                    }
                }
            }
            Log.Info("# of Gadget after refresh (" + _gadgetInfos.Count + ")");
        }
    }
}
