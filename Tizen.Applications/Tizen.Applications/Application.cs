/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;

using Tizen.UI;

namespace Tizen.Applications
{
    /// <summary>
    /// Provides static methods and properties to manage an application, such as methods to register Actors and Services, 
    /// to start an application.
    /// </summary>
    public static class Application
    {
        private static readonly Dictionary<AppControlFilter, Type> s_filterMap = new Dictionary<AppControlFilter, Type>();
        private static readonly List<ServiceController> s_serviceControllerList = new List<ServiceController>();
        private static readonly UIControllerStack s_uiControllerStack = new UIControllerStack();
        private static Window s_defaultWindow = null;

        /// <summary>
        /// Occurs when the application starts.
        /// </summary>
        public static event EventHandler Created = delegate { };

        /// <summary>
        /// Occurs when the application's main loop exits.
        /// </summary>
        public static event EventHandler Exited = delegate { };

        private static UIController Foreground
        {
            get
            {
                return s_uiControllerStack.Peek();
            }
        }

        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">The command-line arguments</param>
        public static void Run(string[] args)
        {
            Interop.Application.UIAppLifecycleCallbacks ops;
            ops.OnCreate = (userData) =>
            {
                Created(null, EventArgs.Empty);
                return true;
            };
            ops.OnPause = (userData) =>
            {
                if (Foreground != null)
                {
                    Foreground.SendPause();
                }
            };
            ops.OnResume = (userData) =>
            {
                if (Foreground != null)
                {
                    Foreground.SendResume();
                }
            };
            ops.OnAppControl = (appControlHandle, userData) =>
            {
                AppControl control = new AppControl(appControlHandle);
                StartController(null, null, control, Controller.ControlFlags.NewInstance);
            };
            ops.OnTerminate = (userData) =>
            {
                Exit();
            };

            TizenSynchronizationContext.Initialize();

            // TODO: check ret of UIAppMain and throw exceptions when errors are returned.
            Interop.Application.UIAppMain(args.Length, args, ref ops, IntPtr.Zero);
        }

        /// <summary>
        /// Exits the main loop of application.
        /// </summary>
        public static void Exit()
        {
            Exited(null, null);
            // TODO: clear context and group
            Interop.Application.UIAppExit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerType"></param>
        public static void RegisterController(Type controllerType)
        {
            RegisterController(controllerType, new AppControlFilter[0] { });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerType"></param>
        /// <param name="filter"></param>
        public static void RegisterController(Type controllerType, AppControlFilter filter)
        {
            RegisterController(controllerType, new AppControlFilter[] { filter });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerType"></param>
        /// <param name="filters"></param>
        public static void RegisterController(Type controllerType, AppControlFilter[] filters)
        {
            if (controllerType == null)
            {
                throw new ArgumentNullException("controllerType");
            }

            if (!controllerType.IsSubclassOf(typeof(UIController)) || !controllerType.IsSubclassOf(typeof(ServiceController)))
            {                
                throw new ArgumentException(controllerType.FullName + " is not a sub class of UIController or ServiceController.", "controllerType");
            }

            foreach (var prop in controllerType.GetProperties())
            {
                foreach (var attr in prop.GetCustomAttributes(false))
                {
                    var filter = attr as AppControlFilter;
                    if (filter != null)
                    {
                        s_filterMap.Add(filter, controllerType);
                    }
                }
            }
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    s_filterMap.Add(filter, controllerType);
                }
            }
        }
        
        internal static void StartController(Controller caller, Type controllerType, AppControl control, Controller.ControlFlags flags)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            if (controllerType == null)
            {
                controllerType = FindControllerInFilterMap(control);
                if (controllerType == null)
                {
                    throw new ArgumentException("Could not find any matched controller.", "controllerType");
                }
            }

            if (controllerType.IsSubclassOf(typeof(UIController)))
            {
                UIController target = null;
                UIController uiCaller = caller as UIController;
                if (uiCaller != null && uiCaller != Foreground)
                {
                    throw new InvalidOperationException("Starting UIController should be called from the foreground.");
                }
                if (uiCaller != null && !IsFlagSet(flags, Controller.ControlFlags.NewInstance))
                {
                    target = s_uiControllerStack.FindInForegroundTask(controllerType);
                }


                if (s_defaultWindow == null)
                {
                    s_defaultWindow = new Window();
                }

                if (!s_defaultWindow.Visible)
                {
                    s_defaultWindow.Active();
                    s_defaultWindow.Show();
                }

                if (target == null)
                {
                    target = (UIController)Activator.CreateInstance(controllerType);
                    target.TaskId = uiCaller == null ? Guid.NewGuid() : uiCaller.TaskId;
                    target.Window = s_defaultWindow;
                    target.SendCreate();
                    s_uiControllerStack.Push(target);
                }
                else
                {
                    if (IsFlagSet(flags, Controller.ControlFlags.ClearTop))
                    {
                        while (target != Foreground)
                        {
                            UIController popped = s_uiControllerStack.Pop();
                            popped.SendPause();
                            popped.SendDestroy();
                        }
                    }
                    else if (IsFlagSet(flags, Controller.ControlFlags.MoveToTop))
                    {
                        if (Foreground != target)
                        {
                            Foreground.SendPause();
                            s_uiControllerStack.MoveToTop(target);
                        }
                    }
                }
                Foreground.SendStart(control);
                Foreground.SendResume();
            }
            else if (controllerType.IsSubclassOf(typeof(ServiceController)))
            {
                ServiceController svc = s_serviceControllerList.Find(s => s.GetType() == controllerType);
                if (svc == null)
                {
                    svc = (ServiceController)Activator.CreateInstance(controllerType);
                    s_serviceControllerList.Add(svc);
                    svc.SendCreate();
                }
                svc.SendStart(control);
            }
            else
            {
                throw new ArgumentException("Invalid controller type.", "controllerType");
            }
        }

        internal static void StopController(UIController target)
        {
            if (Foreground == null)
            {
                throw new InvalidOperationException("The UIController stack is empty.");
            }

            Guid prevForegroundTaskId = Foreground.TaskId;

            s_uiControllerStack.Remove(target);
            target.SendPause();
            target.SendDestroy();
            if (target.TaskId == prevForegroundTaskId)
            {
                if (Foreground.TaskId == target.TaskId)
                {
                    Foreground.SendResume();
                }
                else
                {
                    if (s_uiControllerStack.Count == 0 && s_serviceControllerList.Count == 0)
                    {
                        Exit();
                    }
                    else
                    {
                        s_defaultWindow.Hide();
                    }
                }
            }
        }

        internal static void StopController(Type controllerType)
        {
            if (controllerType.IsSubclassOf(typeof(UIController)))
            {                
                UIController target = s_uiControllerStack.Find(controllerType);
                if (target == null)
                {
                    throw new InvalidOperationException("Could not find the UIController to stop.");
                }
                StopController(target);
            }
            else if (controllerType.IsSubclassOf(typeof(ServiceController)))
            {
                ServiceController svc = s_serviceControllerList.Find(s => s.GetType() == controllerType);
                if (svc != null)
                {
                    svc.SendDestroy();
                    s_serviceControllerList.Remove(svc);
                    if (s_uiControllerStack.Count == 0 && s_serviceControllerList.Count == 0)
                    {
                        Exit();
                    }
                }
            }
        }
        
        private static Type FindControllerInFilterMap(AppControl control)
        {            
            foreach (var item in s_filterMap)
            {
                if (item.Key.IsMatch(control))
                {
                    return item.Value;
                }
            }
            return null;
        }
        
        private static bool IsFlagSet(Controller.ControlFlags flags, Controller.ControlFlags values)
        {
            return (values & flags) == values;
        }


        private class UIControllerStack
        {
            private readonly List<UIController> _uiControllerList;

            public int Count
            {
                get
                {
                    return _uiControllerList.Count;
                }
            }

            public UIControllerStack()
            {
                _uiControllerList = new List<UIController>();
            }

            public UIController Peek()
            {
                return _uiControllerList.LastOrDefault(null);
            }

            public void Push(UIController item)
            {
                _uiControllerList.Add(item);
            }

            public UIController Pop()
            {
                UIController last = Peek();
                _uiControllerList.Remove(last);
                return last;
            }

            public void Remove(UIController actor)
            {
                _uiControllerList.Remove(actor);
            }

            public UIController Find(Type controllerType)
            {
                return _uiControllerList.Find(s => s.GetType() == controllerType);
            }

            public UIController FindInForegroundTask(Type controllerType)
            {
                return _uiControllerList.Find(s => s.GetType() == controllerType && s.TaskId == Peek().TaskId);
            }

            public void MoveToTop(UIController actor)
            {
                _uiControllerList.Remove(actor);
                _uiControllerList.Add(actor);
            }
        }
    }
}
