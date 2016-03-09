using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    public static class Application
    {
        private static Dictionary<AppControlFilter, Type> s_filterMap = new Dictionary<AppControlFilter, Type>();
        private static ContextGroup s_serviceGroup = new ContextGroup();
        private static List<ContextGroup> s_actorGroupList = new List<ContextGroup>();

        private static Window s_window = null;

        private static ContextGroup CurrentActorGroup
        {
            get
            {
                return s_actorGroupList.LastOrDefault(null);
            }
        }

        public static event EventHandler Created = delegate { };
        public static event EventHandler Exited = delegate { };

        public static int Run(string[] args)
        {
            Interop.Application.UIAppLifecycleCallbacks ops;
            ops.OnCreate = (userData) =>
            {
                Created(null, EventArgs.Empty);
                return true;
            };
            ops.OnPause = (userData) =>
            {
                if (CurrentActorGroup != null && CurrentActorGroup.TopContext != null)
                {
                    Actor actor = CurrentActorGroup.TopContext as Actor;
                    if (actor != null)
                    {
                        actor.Pause();
                    }
                }
            };
            ops.OnResume = (userData) =>
            {
                if (CurrentActorGroup != null && CurrentActorGroup.TopContext != null)
                {
                    Actor actor = CurrentActorGroup.TopContext as Actor;
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
                            // Window was created when the first UI Actor was created
                            if (s_window == null)
                            {
                                s_window = new Window();
                            }

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

            int ret = Interop.Application.UIAppMain(args.Length, args, ref ops, IntPtr.Zero);

            return ret;
        }

        public static void Hide()
        {
            if (s_window != null)
                s_window.InActive();
        }

        public static void Exit()
        {
            Exited(null, null);
            throw new NotImplementedException();
        }

        public static void RegisterActor(Type clazz)
        {
            RegisterActor(clazz, new AppControlFilter[0] { });
        }

        public static void RegisterActor(Type clazz, AppControlFilter filter)
        {
            RegisterActor(clazz, new AppControlFilter[] { filter });
        }

        public static void RegisterActor(Type clazz, AppControlFilter[] filters)
        {
            if (!clazz.IsSubclassOf(typeof(Actor)))
                throw new ArgumentException(clazz.FullName + " is not a subclass of Actor.");

            RegisterContext(clazz, filters);
        }

        public static void RegisterService(Type clazz)
        {
            RegisterService(clazz, new AppControlFilter[0] { });
        }

        public static void RegisterService(Type clazz, AppControlFilter filter)
        {
            RegisterService(clazz, new AppControlFilter[] { filter });
        }

        public static void RegisterService(Type clazz, AppControlFilter[] filters)
        {
            if (!clazz.IsSubclassOf(typeof(Service)))
                throw new ArgumentException(clazz.FullName + " is not a subclass of Service.");

            RegisterContext(clazz, filters);
        }

        private static void RegisterContext(Type clazz, AppControlFilter[] filters)
        {
            foreach (var prop in clazz.GetProperties())
            {
                foreach (var attr in prop.GetCustomAttributes(false))
                {
                    var filter = attr as AppControlFilter;
                    if (filter != null)
                    {
                        s_filterMap.Add(filter, clazz);
                    }
                }
            }
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    s_filterMap.Add(filter, clazz);
                }
            }
        }

        internal static void StartActor(ContextGroup group, Type actorType, AppControl control)
        {
            if (!actorType.IsSubclassOf(typeof(Actor)))
            {
                throw new ArgumentException(actorType.FullName + " is not a subclass of Actor.");
            }

            Actor actor = (Actor)Activator.CreateInstance(actorType);
            ContextGroup ctxGroup = group;
            if (ctxGroup == null)
            {
                ctxGroup = new ContextGroup();
                s_actorGroupList.Add(ctxGroup);
            }
            ctxGroup.AddContext(actor);
            actor.Create(ctxGroup);
            actor.Start(control);

            // TODO: consider resume operation
            if (!s_window.Visible)
            {
                s_window.Active();
                s_window.Show();
                actor.Resume();
            }
        }

        internal static void StopActor(ContextGroup group, Actor actor)
        {
            actor.Pause();
            actor.Terminate();
            group.RemoveContext(actor);
            if (group.IsEmpty)
            {
                s_actorGroupList.Remove(group);
                if (s_actorGroupList.Count == 0 && s_serviceGroup.IsEmpty)
                {
                    Exit();
                }
                else
                {
                    Hide();
                }
            }
            else
            {
                Actor nextActor = group.TopContext as Actor;
                if (nextActor != null)
                {
                    nextActor.Resume();
                }
            }
        }

        internal static void StartService(Type serviceType, AppControl control)
        {
            if (!serviceType.IsSubclassOf(typeof(Service)))
            {
                throw new ArgumentException(serviceType.FullName + " is not a subclass of Service.");
            }

            Context ctx = s_serviceGroup.FindContext(serviceType);
            if (ctx == null)
            {
                // Register ContextRemoved Handler once
                ctx = (Service)Activator.CreateInstance(serviceType);
                s_serviceGroup.AddContext(ctx);
                ctx.Create(s_serviceGroup);
            }
            ctx.Start(control);
        }

        internal static void StopService(Type serviceType)
        {
            if (!serviceType.IsSubclassOf(typeof(Service)))
            {
                throw new ArgumentException(serviceType.FullName + " is not a subclass of Service.");
            }

            Context ctx = s_serviceGroup.FindContext(serviceType);
            if (ctx != null)
            {
                ctx.Terminate();
                s_serviceGroup.RemoveContext(ctx);
                if (s_serviceGroup.IsEmpty)
                {
                    if (s_actorGroupList.Count == 0)
                    {
                        Exit();
                    }
                }
            }
        }
    }
}
