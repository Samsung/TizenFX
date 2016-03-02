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
        private static Dictionary<AppControlFilter, Type> _filterMap = new Dictionary<AppControlFilter, Type>();
        private static List<ApplicationContext> _contextList = new List<ApplicationContext>();
        private static Window _window = null;

        public static event EventHandler ApplicationInit;
        public static event EventHandler ApplicationExit;

        private static ApplicationContext CurrentContext { get { return _contextList.LastOrDefault(null); } }

        public static int Run(string[] args)
        {
            Interop.Application.UIAppLifecycleCallbacks ops;
            ops.OnCreate = (userData) =>
            {
                ApplicationInit(null, null);
                if (_window == null)
                    _window = new Window();
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
                    if (item.Key.IsMatch(appControl))
                    {
                        if (CurrentContext == null || !appControl.IsLaunchOperation())
                        {
                            ApplicationContext ctx = new ApplicationContext();
                            ctx.ReleaseContext += Ctx_ReleaseContext;
                            _contextList.Add(ctx);
                            Actor actor = ctx.StartActor(item.Value, appControl);
                            if (!_window.Visible) {
                                _window.Active();
                                _window.Show();
                                ctx.Resume();
                            }
                        }
                        break;
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
            throw new NotImplementedException();
        }

        public static void Exit()
        {
            ApplicationExit(null, null);
            throw new NotImplementedException();
        }

        private static void Ctx_ReleaseContext(object sender, EventArgs e)
        {
            var ctx = sender as ApplicationContext;
            if (ctx != null)
            {
                _contextList.Remove(ctx);
                if (_contextList.Count > 0)
                {
                    Hide();
                } else
                {
                    Exit();
                }
            }
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
