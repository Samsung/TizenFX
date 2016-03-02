using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Application
{
    public static class Application
    {
        private static Dictionary<string, Type> _actorMap = new Dictionary<string, Type>();
        private static Dictionary<AppControlFilter, Type> _filterMap = new Dictionary<AppControlFilter, Type>();
        private static List<ApplicationContext> _contextList = new List<ApplicationContext>();

        public static event EventHandler ApplicationInit;
        public static event EventHandler ApplicationExit;

        public static ApplicationContext CurrentContext { get { return _contextList.LastOrDefault(null); } }

        public static int Run(string[] args)
        {
            Interop.Application.UIAppLifecycleCallbacks ops;
            ops.OnCreate = (userData) =>
            {
                _contextList.Add(new ApplicationContext());
                ApplicationInit(null, null);
                return true;
            };
            ops.OnPause = (userData) =>
            {
                if (CurrentContext != null)
                {
                    CurrentContext.Pause();
                }
            };
            ops.OnResume = (userData) =>
            {
                if (CurrentContext != null)
                {
                    CurrentContext.Resume();
                }
            };
            ops.OnAppControl = (appControlHandle, userData) =>
            {
                AppControl appControl = new AppControl(appControlHandle);
                foreach (var item in _filterMap)
                {
                    if (item.Key.IsMatched(appControl))
                    {
                        // Relaunch?
                        if (appControl.IsLaunchOperation() && CurrentContext != null && !CurrentContext.Empty())
                        {
                            // TODO: Resume should be called by windows event
                            CurrentContext.Resume();
                        }
                        // Create new context and new actor when launching first or receiving appcontrol except launch.
                        else
                        {
                            ApplicationContext ctx = new ApplicationContext();
                            _contextList.Add(ctx);
                            Actor actor = ctx.StartActor(item.Value, appControl);
                            // TODO: Resume should be called by windows event
                            actor.Resume();
                        }
                        break;
                    }
                }
            };
            ops.OnTerminate = (userData) =>
            {
                // TODO: Remove context and actors
                ApplicationExit(null, null);
            };

            TizenSynchronizationContext.Initialize();

            int ret = Interop.Application.UIAppMain(args.Length, args, ref ops, IntPtr.Zero);

            return ret;
        }



        public static void AddActor(Type clazz)
        {
            AddActor(clazz, new AppControlFilter[0] { });
        }

        public static void AddActor(Type clazz, AppControlFilter filter)
        {
            AddActor(clazz, new AppControlFilter[] { filter });
        }

        public static void AddActor(Type clazz, AppControlFilter[] filters)
        {
            if (!clazz.IsSubclassOf(typeof(Actor)))
                throw new ArgumentException(clazz.FullName + " is not a subclass of Actor.");

            _actorMap[clazz.FullName] = clazz;

            foreach (var prop in clazz.GetProperties())
            {
                foreach (var attr in prop.GetCustomAttributes(false))
                {
                    var filter = attr as AppControlFilter;
                    if (filter != null)
                    {
                        _filterMap.Add(filter, clazz);
                    }
                }
            }
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    _filterMap.Add(filter, clazz);
                }
            }
        }

    }


}
