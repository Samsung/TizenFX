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
        private static readonly List<Service> s_serviceList = new List<Service>();
        private static readonly List<ActorGroup> s_actorGroupList = new List<ActorGroup>();

        private static readonly Window s_window = null;

        private static ActorGroup CurrentActorGroup
        {
            get
            {
                return s_actorGroupList.LastOrDefault(null);
            }
        }

        /// <summary>
        /// Occurs when the application starts.
        /// </summary>
        public static event EventHandler Created = delegate { };

        /// <summary>
        /// Occurs when the application's main loop exits.
        /// </summary>
        public static event EventHandler Exited = delegate { };

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
                if (CurrentActorGroup != null && CurrentActorGroup.TopActor != null)
                {
                    Actor actor = CurrentActorGroup.TopActor as Actor;
                    if (actor != null)
                    {
                        actor.Pause();
                    }
                }
            };
            ops.OnResume = (userData) =>
            {
                if (CurrentActorGroup != null && CurrentActorGroup.TopActor != null)
                {
                    Actor actor = CurrentActorGroup.TopActor as Actor;
                    if (actor != null)
                    {
                        actor.Resume();
                    }
                }
            };
            ops.OnAppControl = (appControlHandle, userData) =>
            {
                AppControl appControl = new AppControl(appControlHandle);
                if (appControl.IsService)
                {
                    foreach (var item in s_filterMap)
                    {
                        if (item.Key.IsMatch(appControl) && item.Value.IsSubclassOf(typeof(Service)))
                        {
                            StartService(item.Value, appControl);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var item in s_filterMap)
                    {
                        if (item.Key.IsMatch(appControl) && item.Value.IsSubclassOf(typeof(Actor)))
                        {
                            if (CurrentActorGroup == null || !appControl.IsLaunchOperation())
                            {
                                StartActor(null, item.Value, appControl);
                            }
                            break;
                        }
                    }
                }
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
        /// Hides the application.
        /// </summary>
        public static void Hide()
        {
            if (s_window != null)
                s_window.InActive();
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
        /// Registers an Actor class type.
        /// </summary>
        /// <param name="actorType">The type of Actor class.</param>
        public static void RegisterActor(Type actorType)
        {
            RegisterActor(actorType, new AppControlFilter[0] { });
        }

        /// <summary>
        /// Registers an Actor class type.
        /// </summary>
        /// <param name="actorType">The type of Actor class.</param>
        /// <param name="filter">The filter to match Actor and AppControl.</param>
        public static void RegisterActor(Type actorType, AppControlFilter filter)
        {
            RegisterActor(actorType, new AppControlFilter[] { filter });
        }

        /// <summary>
        /// Registers an Actor class type.
        /// </summary>
        /// <param name="actorType">The type of Actor class.</param>
        /// <param name="filters">The array of filters to match Actor and AppControl.</param>
        public static void RegisterActor(Type actorType, AppControlFilter[] filters)
        {
            if (!actorType.IsSubclassOf(typeof(Actor)))
                throw new ArgumentException(actorType.FullName + " is not a subclass of Actor.");

            RegisterContext(actorType, filters);
        }

        /// <summary>
        /// Registers an Service class type.
        /// </summary>
        /// <param name="serviceType">The type of Service class.</param>
        public static void RegisterService(Type serviceType)
        {
            RegisterService(serviceType, new AppControlFilter[0] { });
        }

        /// <summary>
        /// Registers an Service class type.
        /// </summary>
        /// <param name="serviceType">The type of Service class.</param>
        /// <param name="filter">The filter to match Service and AppControl.</param>
        public static void RegisterService(Type serviceType, AppControlFilter filter)
        {
            RegisterService(serviceType, new AppControlFilter[] { filter });
        }

        /// <summary>
        /// Registers an Service class type.
        /// </summary>
        /// <param name="serviceType">The type of Service class.</param>
        /// <param name="filters">The array of filters to match Service and AppControl.</param>
        public static void RegisterService(Type serviceType, AppControlFilter[] filters)
        {
            if (!serviceType.IsSubclassOf(typeof(Service)))
                throw new ArgumentException(serviceType.FullName + " is not a subclass of Service.");

            RegisterContext(serviceType, filters);
        }

        private static void RegisterContext(Type contextType, AppControlFilter[] filters)
        {
            foreach (var prop in contextType.GetProperties())
            {
                foreach (var attr in prop.GetCustomAttributes(false))
                {
                    var filter = attr as AppControlFilter;
                    if (filter != null)
                    {
                        s_filterMap.Add(filter, contextType);
                    }
                }
            }
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    s_filterMap.Add(filter, contextType);
                }
            }
        }

        internal static void StartActor(ActorGroup group, Type actorType, AppControl control)
        {
            if (!actorType.IsSubclassOf(typeof(Actor)))
            {
                throw new ArgumentException(actorType.FullName + " is not a subclass of Actor.");
            }

            // Window was created when the first UI Actor was created
            //if (s_window == null)
            //{
            //    s_window = new Window();
            //}

            ActorGroup actorGroup = group;
            if (actorGroup == null)
            {
                actorGroup = new ActorGroup();
                s_actorGroupList.Add(actorGroup);
            }
            actorGroup.StartActor(actorType, control);

            // TODO: consider resume operation
            //if (!s_window.Visible)
            //{
            //    s_window.Active();
            //    s_window.Show();
            //    actor.Resume();
            //}
        }

        internal static void StopActor(ActorGroup group, Actor actor)
        {
            group.StopActor(actor);
            if (group.IsEmpty)
            {
                s_actorGroupList.Remove(group);
                if (s_actorGroupList.Count == 0 && s_serviceList.Count == 0)
                {
                    Exit();
                }
                else
                {
                    Hide();
                }
            }
        }

        internal static void StartService(Type serviceType, AppControl control)
        {
            if (!serviceType.IsSubclassOf(typeof(Service)))
            {
                throw new ArgumentException(serviceType.FullName + " is not a subclass of Service.");
            }

            Service svc = s_serviceList.Find(s => s.GetType() == serviceType);
            if (svc == null)
            {
                svc = (Service)Activator.CreateInstance(serviceType);
                s_serviceList.Add(svc);
                svc.Create();
            }
            svc.Start(control);
        }

        internal static void StopService(Type serviceType)
        {
            if (!serviceType.IsSubclassOf(typeof(Service)))
            {
                throw new ArgumentException(serviceType.FullName + " is not a subclass of Service.");
            }

            Service svc = s_serviceList.Find(s => s.GetType() == serviceType);
            if (svc != null)
            {
                svc.Terminate();
                s_serviceList.Remove(svc);
                if (s_actorGroupList.Count == 0 && s_serviceList.Count == 0)
                {
                    Exit();
                }
            }
        }
    }
}
