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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Reflection;
using Tizen.Applications;
using System.ComponentModel;

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
        private static readonly ConcurrentDictionary<string, NUIGadgetInfo> _gadgetInfos = new ConcurrentDictionary<string, NUIGadgetInfo>(StringComparer.Ordinal);
        private static readonly ConcurrentDictionary<NUIGadget, byte> _gadgets = new ConcurrentDictionary<NUIGadget, byte>();

        static NUIGadgetManager()
        {
            var ptr = Interop.Libc.GetEnvironmentVariable("GADGET_PKGIDS");
            if (ptr != IntPtr.Zero)
            {
                var packages = Marshal.PtrToStringAnsi(ptr);
                if (!string.IsNullOrWhiteSpace(packages))
                {
                    foreach (var pkg in packages.Split(':'))
                    {
                        var info = NUIGadgetInfo.CreateNUIGadgetInfo(pkg);
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
            app.LowMemory += (s, e) => HandleEvents(NUIGadgetEventType.LowMemory, e);
            app.LowBattery += (s, e) => HandleEvents(NUIGadgetEventType.LowBattery, e);
            app.LocaleChanged += (s, e) => HandleEvents(NUIGadgetEventType.LocaleChanged, e);
            app.RegionFormatChanged += (s, e) => HandleEvents(NUIGadgetEventType.RegionFormatChanged, e);
            app.DeviceOrientationChanged += (s, e) => HandleEvents(NUIGadgetEventType.DeviceOrientationChanged, e);
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
                _gadgets.TryRemove(args.Gadget, out _);
            }
        }

        private static NUIGadgetInfo Find(string resourceType)
        {
            if (!_gadgetInfos.TryGetValue(resourceType, out var info))
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
        public static void Load(string resourceType) => Load(resourceType, true);

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
            LoadInternal(info, useDefaultContext);
        }

        private static void LoadInternal(NUIGadgetInfo info, bool useDefaultContext)
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

                            Log.Warn("NUIGadget.Load(): " + info.ResourcePath + info.ExecutableFile + " ++");
                            info.Assembly = Assembly.Load(SystemIO.Path.GetFileNameWithoutExtension(info.ExecutableFile));
                            Log.Warn("NUIGadget.Load(): " + info.ResourcePath + info.ExecutableFile + " --");
                        }
                    }
                    else
                    {
                        if (info.NUIGadgetAssembly == null || !info.NUIGadgetAssembly.IsLoaded)
                        {
                            Log.Warn("NUIGadgetAssembly.Load(): " + info.GadgetResourcePath + info.ExecutableFile + " ++");
                            info.NUIGadgetAssembly = new NUIGadgetAssembly(info.GadgetResourcePath + info.ExecutableFile);
                            info.NUIGadgetAssembly.Load();
                            Log.Warn("NUIGadgetAssembly.Load(): " + info.GadgetResourcePath + info.ExecutableFile + " --");
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
            if (string.IsNullOrWhiteSpace(resourceType))
            {
                throw new ArgumentException("Invalid argument", nameof(resourceType));
            }

            NUIGadgetInfo info = Find(resourceType);
            if (info == null)
            {
                throw new ArgumentException("Invalid argument", nameof(resourceType));
            }

            lock (info)
            {
                if (info.NUIGadgetAssembly?.IsLoaded == true)
                {
                    info.NUIGadgetAssembly.Unload();
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
        public static NUIGadget Add(string resourceType, string className) => Add(resourceType, className, true);

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
            var gadget = CreateInstance(resourceType, className, useDefaultContext);
            if (gadget != null)
            {
                PreCreate(gadget);
                Create(gadget);
            }
            return gadget;
        }

        /// <summary>
        /// Retrieves the instances of currently running NUIGadgets.
        /// </summary>
        /// <returns>An enumerable list containing all the active NUIGadgets.</returns>
        /// <since_tizen> 10 </since_tizen>
        public static IEnumerable<NUIGadget> GetGadgets() => _gadgets.Keys;

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
        public static IEnumerable<NUIGadgetInfo> GetGadgetInfos() => _gadgetInfos.Values;


        /// <summary>
        /// Creates a new NUIGadget instance.
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
        /// <since_tizen> 13 </since_tizen>
        public static NUIGadget CreateInstance(string resourceType, string className, bool useDefaultContext)
        {
            if (string.IsNullOrWhiteSpace(resourceType) || string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Invalid argument");
            }

            NUIGadgetInfo info = Find(resourceType);
            LoadInternal(info, useDefaultContext);

            NUIGadget gadget = useDefaultContext ? info.Assembly.CreateInstance(className, true) as NUIGadget : info.NUIGadgetAssembly.CreateInstance(className);
            if (gadget == null)
            {
                throw new InvalidOperationException("Failed to create instance. className: " + className);
            }

            gadget.NUIGadgetInfo = info;
            gadget.ClassName = className;
            gadget.NUIGadgetResourceManager = new NUIGadgetResourceManager(info);
            gadget.LifecycleChanged += OnNUIGadgetLifecycleChanged;
            return gadget;
        }

        /// <summary>
        /// Executes the pre-creation process of the NUIGadget.
        /// </summary>
        /// <param name="gadget">The NUIGadget object to perform the pre-creation process.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 'gadget' argument is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void PreCreate(NUIGadget gadget)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            Log.Warn("ResourceType: " + gadget.NUIGadgetInfo.ResourceType + ", State: " + gadget.State);
            gadget.PreCreate();
        }

        /// <summary>
        /// Executes the creation process of the NUIGadget.
        /// </summary>
        /// <param name="gadget">The NUIGadget object to perform the creation process.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 'gadget' argument is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Create(NUIGadget gadget)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            if (_gadgets.ContainsKey(gadget))
            {
                Log.Error("Already exists. ResourceType:" + gadget.NUIGadgetInfo.ResourceType);
                return;
            }

            Log.Warn("ResourceType: " + gadget.NUIGadgetInfo.ResourceType + ", State: " + gadget.State);
            if (!gadget.Create())
            {
                throw new InvalidOperationException("The View MUST be created");
            }
            _gadgets.TryAdd(gadget, 0);
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
            if (gadget == null || !_gadgets.ContainsKey(gadget) || gadget.State == NUIGadgetLifecycleState.Destroyed)
            {
                return;
            }

            _gadgets.TryRemove(gadget, out _);
            CoreApplication.Post(() =>
            {
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
            foreach (var gadget in _gadgets.Keys.ToList())
            {
                Remove(gadget);
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
        /// <since_tizen> 10 </since_tizen>
        public static void Resume(NUIGadget gadget)
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

            if (!_gadgets.ContainsKey(gadget))
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

            if (!_gadgets.ContainsKey(gadget))
            {
                throw new ArgumentException("Invalid argument", nameof(gadget));
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
            if (extraData == null || !extraData.TryGet("__K_GADGET_RES_TYPE", out string resourceType) ||
                !extraData.TryGet("__K_GADGET_CLASS_NAME", out string className))
            {
                return false;
            }

            foreach (var gadget in _gadgets.Keys)
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
            foreach (NUIGadget gadget in _gadgets.Keys)
            {
                gadget.HandleEvents(eventType, args);
            }
        }

        /// <summary>
        /// Occurs when the message is received.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public static event EventHandler<NUIGadgetMessageReceivedEventArgs> NUIGadgetMessageReceived;

        /// <summary>
        /// Sends the message to the NUIGadgetManager.
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ArgumentNullException">Thrown if either 'envelope' is null.</exception>
        public static void SendMessage(Bundle message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            CoreApplication.Post(() =>
            {
                NUIGadgetMessageReceived?.Invoke(null, new NUIGadgetMessageReceivedEventArgs(message));
            });
        }

        /// <summary>
        /// Refresh gadget mount and update information in NUIGadgetManager.
        /// </summary>
        /// <remarks>
        /// To use this method properly, All the gadgets should be unloaded in advance.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown if any of gadgets is still loaded.</exception>
        /// <exception cref="IOException">Thrown if internal request fail.</exception>
        public static void Refresh()
        {
            foreach (var info in _gadgetInfos)
            {
                if (info.Value.NUIGadgetAssembly is not null)
                {
                    if (info.Value.NUIGadgetAssembly.IsLoaded == true)
                    {
                        Log.Error("Gadget still loaded: " + info.Key);
                        throw new InvalidOperationException("Gadget still loaded");
                    }
                }
            }

            foreach (var info in _gadgetInfos)
            {
                if (info.Value.NUIGadgetAssembly is not null)
                {
                    for (int i = 0; info.Value.NUIGadgetAssembly.IsAlive && i < 10; i++)
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
                    var info = NUIGadgetInfo.CreateNUIGadgetInfo(pkg);
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
