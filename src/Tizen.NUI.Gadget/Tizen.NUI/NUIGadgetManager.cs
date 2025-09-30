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
using System.Runtime.CompilerServices;

namespace Tizen.NUI
{
    /// <summary>
    /// The NUIGadgetManager provides methods and events related to managing gadgets in the NUI.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class NUIGadgetManager
    {
        private static EventHandler<NUIGadgetLifecycleChangedEventArgs> s_lifecycleChangedEventHandler;
        private static readonly object s_lifecycleChangedEventLock = new object();
        private static EventHandler<NUIGadgetMessageReceivedEventArgs> s_messageReceivedEventHandler;
        private static readonly object s_messageReceivedEventLock = new object();

        static NUIGadgetManager()
        {
            UIGadgetManager.UIGadgetFactory = new NUIGadgetFactory();
        }

        /// <summary>
        /// Occurs when the lifecycle of the NUIGadget is changed.
        /// </summary>
        /// <remarks>
        /// This event is raised when the state of the NUIGadget changes.
        /// It provides information about the current state through the NUIGadgetLifecycleChangedEventArgs argument.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public static event EventHandler<NUIGadgetLifecycleChangedEventArgs> NUIGadgetLifecycleChanged
        {
            add
            {
                lock (s_lifecycleChangedEventLock)
                {
                    if (s_lifecycleChangedEventHandler == null)
                    {
                        Log.Info("add");
                        UIGadgetManager.UIGadgetLifecycleChanged += OnUIGadgetLifecycleChanged;
                    }
                    s_lifecycleChangedEventHandler += value;
                }
            }
            remove
            {
                lock (s_lifecycleChangedEventLock)
                {
                    s_lifecycleChangedEventHandler -= value;
                    if (s_lifecycleChangedEventHandler == null)
                    {
                        Log.Info("remove");
                        UIGadgetManager.UIGadgetLifecycleChanged -= OnUIGadgetLifecycleChanged;
                    }
                }
            }
        }

        private static void OnUIGadgetLifecycleChanged(object sender, UIGadgetLifecycleChangedEventArgs e)
        {
            lock (s_lifecycleChangedEventLock)
            {
                var args = new NUIGadgetLifecycleChangedEventArgs
                {
                    Gadget = (NUIGadget)e.UIGadget,
                    State = (NUIGadgetLifecycleState)e.State
                };
                s_lifecycleChangedEventHandler?.Invoke(sender, args);
            }
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
        public static void Load(string resourceType, bool useDefaultContext) => UIGadgetManager.Load(resourceType, useDefaultContext);

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
        public static void Unload(string resourceType) => UIGadgetManager.Unload(resourceType);

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
            Log.Info("ResourceType=" + resourceType + ",  ClassName=" + className);
            var gadget = UIGadgetManager.Add(resourceType, className, useDefaultContext) as NUIGadget;
            if (gadget == null)
            {
                Log.Error("Failed to create gadget instance. ClassName=" + className);
                return null;
            }

            gadget.NUIGadgetInfo = new NUIGadgetInfo(gadget.UIGadgetInfo);
            gadget.NUIGadgetResourceManager = new NUIGadgetResourceManager(gadget.NUIGadgetInfo);
            return gadget;
        }

        /// <summary>
        /// Retrieves the instances of currently running NUIGadgets.
        /// </summary>
        /// <returns>An enumerable list containing all the active NUIGadgets.</returns>
        /// <since_tizen> 10 </since_tizen>
        public static IEnumerable<NUIGadget> GetGadgets()
        {
            var gadgets = new List<NUIGadget>();
            foreach (var gadget in UIGadgetManager.GetUIGadgets())
            {
                gadgets.Add((NUIGadget)gadget);
            }
            return gadgets;
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
            var Infos = new List<NUIGadgetInfo>();
            foreach (var info in UIGadgetManager.GetUIGadgetInfos())
            {
                Infos.Add(new NUIGadgetInfo(info));
            }

            return Infos;
        }

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
        public static NUIGadget CreateInstance(string resourceType, string className, bool useDefaultContext) => (NUIGadget)UIGadgetManager.CreateInstance(resourceType, className, useDefaultContext);

        /// <summary>
        /// Executes the pre-creation process of the NUIGadget.
        /// </summary>
        /// <param name="gadget">The NUIGadget object to perform the pre-creation process.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 'gadget' argument is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void PreCreate(NUIGadget gadget) => UIGadgetManager.PreCreate(gadget);

        /// <summary>
        /// Executes the creation process of the NUIGadget.
        /// </summary>
        /// <param name="gadget">The NUIGadget object to perform the creation process.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 'gadget' argument is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Create(NUIGadget gadget) => UIGadgetManager.Create(gadget);

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
        public static void Remove(NUIGadget gadget) => UIGadgetManager.Remove(gadget);

        /// <summary>
        /// Removes all NUIGadgets from the NUIGadgetManager.
        /// </summary>
        /// <remarks>
        /// This method is called to remove all NUIGadgets that are currently registered in the NUIGadgetManager.
        /// It ensures that no more NUIGadgets exist after calling this method.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public static void RemoveAll() => UIGadgetManager.RemoveAll();

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
        public static void Resume(NUIGadget gadget) => UIGadgetManager.Resume(gadget);

        /// <summary>
        /// Pauses the execution of the specified NUIGadget.
        /// </summary>
        /// <remarks>
        /// Calling this method pauses the currently executing NUIGadget. It does not affect any other gadgets that may be running simultaneously.
        /// </remarks>
        /// <param name="gadget">The NUIGadget object whose execution needs to be paused.</param>
        /// <exception cref="ArgumentNullException">Thrown if the argument 'gadget' is null.</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void Pause(NUIGadget gadget) => UIGadgetManager.Pause(gadget);

        /// <summary>
        /// Sends the specified application control to the currently running NUIGadget.
        /// </summary>
        /// <param name="gadget">The NUIGadget object that will receive the app control.</param>
        /// <param name="appControl">The app control object containing the desired arguments and actions.</param>
        /// <exception cref="ArgumentException">Thrown if any of the arguments are invalid or missing.</exception>
        /// <exception cref="ArgumentNullException">Thrown if either 'gadget' or 'appControl' is null.</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void SendAppControl(NUIGadget gadget, AppControl appControl) => UIGadgetManager.SendAppControl(gadget, appControl);

        /// <summary>
        /// Occurs when the message is received.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public static event EventHandler<NUIGadgetMessageReceivedEventArgs> NUIGadgetMessageReceived
        {
            add
            {
                lock (s_messageReceivedEventLock)
                {
                    if (s_messageReceivedEventHandler == null)
                    {
                        UIGadgetManager.UIGadgetMessageReceived += OnUIGadgetMessageRecevied;
                    }
                    s_messageReceivedEventHandler += value;
                }
            }
            remove
            {
                lock (s_messageReceivedEventLock)
                {
                    s_messageReceivedEventHandler -= value;
                    if (s_messageReceivedEventHandler == null)
                    {
                        UIGadgetManager.UIGadgetMessageReceived -= OnUIGadgetMessageRecevied;
                    }
                }
            }
        }

        private static void OnUIGadgetMessageRecevied(object sender, UIGadgetMessageReceivedEventArgs e)
        {
            lock (s_messageReceivedEventLock)
            {
                s_messageReceivedEventHandler?.Invoke(sender, new NUIGadgetMessageReceivedEventArgs(e.Message));
            }
        }

        /// <summary>
        /// Sends the message to the NUIGadgetManager.
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ArgumentNullException">Thrown if either 'envelope' is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void SendMessage(Bundle message) => UIGadgetManager.SendMessage(message);

        /// <summary>
        /// Refresh gadget mount and update information in NUIGadgetManager.
        /// </summary>
        /// <remarks>
        /// To use this method properly, All the gadgets should be unloaded in advance.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown if any of gadgets is still loaded.</exception>
        /// <exception cref="IOException">Thrown if internal request fail.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Refresh() => UIGadgetManager.Refresh();
    }

    internal class NUIGadgetFactory : IUIGadgetFactory
    {
        UIGadget IUIGadgetFactory.CreateInstance(UIGadgetInfo info, string className, bool useDefaultContext)
        {
            NUIGadget gadget = useDefaultContext ? info.Assembly.CreateInstance(className, true) as NUIGadget : info.UIGadgetAssembly.CreateInstance(className) as NUIGadget;
            if (gadget == null)
            {
                Log.Info("Failed to create gadget instance. class name=" + className);
                return null;
            }

            gadget.NUIGadgetInfo = new NUIGadgetInfo(info);
            gadget.NUIGadgetResourceManager = new NUIGadgetResourceManager(gadget.NUIGadgetInfo);
            return gadget;
        }
    }
}