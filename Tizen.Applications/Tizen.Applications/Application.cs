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
        private static readonly ActorStack s_actorStack = new ActorStack();
        private static Window s_window = null;

        /// <summary>
        /// Occurs when the application starts.
        /// </summary>
        public static event EventHandler Created = delegate { };

        /// <summary>
        /// Occurs when the application's main loop exits.
        /// </summary>
        public static event EventHandler Exited = delegate { };

        private static Actor ForegroundActor
        {
            get
            {
                return s_actorStack.Peek();
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
                if (ForegroundActor != null)
                {
                    ForegroundActor.OnPause();
                }
            };
            ops.OnResume = (userData) =>
            {
                if (ForegroundActor != null)
                {
                    ForegroundActor.OnResume();
                }
            };
            ops.OnAppControl = (appControlHandle, userData) =>
            {
                AppControl appControl = new AppControl(appControlHandle);
                if (appControl.IsService)
                {
                    Type found = FindServiceInFilters(appControl);
                    if (found != null)
                    {
                        //StartService(found, appControl);
                    }
                }
                else
                {
                    Type found = FindActorInFilters(appControl);
                    if (found != null)
                    {
                        //StartActor(null, )
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

        internal static void StartActor(Context caller, Type actorType, Context.ActorFlags flags, AppControl control)
        {
            if (caller == null && actorType == null)
            {
                throw new ArgumentNullException("actorType");
            }

            Actor targetActor = null;

            Actor callerActor = caller as Actor;
            if (callerActor != null && ForegroundActor != callerActor)
            {
                throw new InvalidOperationException("StartActor() should be called from the foreground Actor.");
            }

            if (actorType == null)
            {
                actorType = FindActorInFilters(control);
                if (actorType == null)
                {
                    throw new ArgumentException("Could not find the matched Actor.", "control");
                }
            }

            if (callerActor != null && !IsFlagSet(flags, Context.ActorFlags.NewInstance))
            {
                targetActor = s_actorStack.FindInForegroundTask(actorType);
            }

            if (s_window == null)
            {
                s_window = new Window();
            }

            if (!s_window.Visible)
            {
                s_window.Active();
                s_window.Show();
            }

            if (targetActor == null)
            {
                targetActor = (Actor)Activator.CreateInstance(actorType);
                targetActor.OnCreate(callerActor != null ? callerActor.TaskId : Guid.NewGuid(), control);
                s_actorStack.Push(targetActor);
            }
            else
            {
                if (IsFlagSet(flags, Context.ActorFlags.ClearTop))
                {
                    while (targetActor != ForegroundActor)
                    {
                        Actor popped = s_actorStack.Pop();
                        popped.OnPause();
                        popped.OnDestroy();
                    }
                }
                else if (IsFlagSet(flags, Context.ActorFlags.MoveToTop))
                {
                    if (ForegroundActor != targetActor)
                    {
                        ForegroundActor.OnPause();
                        s_actorStack.MoveToTop(targetActor);
                    }
                }
            }
            ForegroundActor.OnStart();
            ForegroundActor.OnResume();
        }

        internal static void StopActor(Actor actor)
        {
            if (ForegroundActor == null)
            {
                throw new InvalidOperationException("The Actor stack is empty.");
            }

            Guid prevForegroundTaskId = ForegroundActor.TaskId;

            s_actorStack.Remove(actor);
            actor.OnPause();
            actor.OnDestroy();

            if (actor.TaskId == prevForegroundTaskId)
            {
                if (ForegroundActor.TaskId == actor.TaskId)
                {
                    ForegroundActor.OnResume();
                }
                else
                {
                    if (s_actorStack.Count == 0 && s_serviceList.Count == 0)
                    {
                        Exit();
                    }
                    else
                    {
                        s_window.Hide();
                    }
                }
            }
        }

        internal static void StartService(Type serviceType, AppControl control)
        {
            if (serviceType == null)
            {
                serviceType = FindServiceInFilters(control);
                if (serviceType == null)
                {
                    throw new ArgumentException("Could not find the matched Service.", "control");
                }
            }
            else
            {
                if (!serviceType.IsSubclassOf(typeof(Service)))
                {
                    throw new ArgumentException(serviceType.FullName + " is not a subclass of Service.", "serviceType");
                }
            }

            Service svc = s_serviceList.Find(s => s.GetType() == serviceType);
            if (svc == null)
            {
                svc = (Service)Activator.CreateInstance(serviceType);
                s_serviceList.Add(svc);
                svc.OnCreate(control);
            }
            svc.OnStart();
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
                svc.OnDestroy();
                s_serviceList.Remove(svc);
                if (ForegroundActor == null && s_serviceList.Count == 0)
                {
                    Exit();
                }
            }
        }

        internal static void Finish(Context caller)
        {
            if (caller is Actor)
            {
                StopActor(caller as Actor);
            }
            else if (caller is Service)
            {
                // TODO: check the value of GetType()
                StopService(caller.GetType());
            }
        }

        private static Type FindActorInFilters(AppControl control)
        {
            foreach (var item in s_filterMap)
            {
                if (item.Key.IsMatch(control) && item.Value.IsSubclassOf(typeof(Actor)))
                {
                    return item.Value;
                }
            }
            return null;
        }

        private static Type FindServiceInFilters(AppControl control)
        {
            foreach (var item in s_filterMap)
            {
                if (item.Key.IsMatch(control) && item.Value.IsSubclassOf(typeof(Service)))
                {
                    return item.Value;
                }
            }
            return null;
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

        private static bool IsFlagSet(Context.ActorFlags flags, Context.ActorFlags values)
        {
            return (values & flags) == values;
        }


        private class ActorStack
        {
            private readonly List<Actor> _actorList;

            public int Count
            {
                get
                {
                    return _actorList.Count;
                }
            }

            public ActorStack()
            {
                _actorList = new List<Actor>();
            }

            public Actor Peek()
            {
                return _actorList.LastOrDefault(null);
            }

            public void Push(Actor item)
            {
                _actorList.Add(item);
            }

            public Actor Pop()
            {
                Actor last = Peek();
                _actorList.Remove(last);
                return last;
            }

            public void Remove(Actor actor)
            {
                _actorList.Remove(actor);
            }

            public Actor FindInForegroundTask(Type actorType)
            {
                return _actorList.Find(s => s.GetType() == actorType && s.TaskId == Peek().TaskId);
            }

            public void MoveToTop(Actor actor)
            {
                _actorList.Remove(actor);
                _actorList.Add(actor);
            }
        }
    }
}
