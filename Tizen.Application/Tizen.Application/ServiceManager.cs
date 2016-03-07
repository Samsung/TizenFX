using System;
using System.Collections.Generic;

namespace Tizen.Application
{
    public class ServiceManager
    {
        private Dictionary<AppControlFilter, Type> _filterMap = new Dictionary<AppControlFilter, Type>();
        private Dictionary<Type, Service> _runningService = new Dictionary<Type, Service>();

        public ServiceManager() { }
        internal void AddServiceHandler(Type clazz, AppControlFilter[] filters)
        {
            if (!clazz.IsSubclassOf(typeof(Service)))
                throw new ArgumentException(clazz.FullName + " is not a subclass of Service.");

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
        internal void OnAppControl(AppControl appControl)
        {
            foreach (var item in _filterMap)
            {
                if (item.Key.IsMatch(appControl))
                {
                    StartService(item.Value, appControl);
                    break;
                }
            }
        }

        internal void StartService(Type clazz, AppControl appControl)
        {
            lock (_runningService)
            {
                if (_runningService.ContainsKey(clazz))
                {
                    _runningService[clazz].DidAppControl(appControl);
                } else
                {
                    _runningService[clazz] = (Service)Activator.CreateInstance(clazz);
                    _runningService[clazz].DidCreate();
                    _runningService[clazz].DidAppControl(appControl);
                }
            }
        }

        internal void StopService(Type clazz)
        {
            lock (_runningService)
            {
                if (_runningService.ContainsKey(clazz))
                {
                    _runningService[clazz].DidTerminate();
                    _runningService.Remove(clazz);
                }
            }
        }

        internal bool ServiceAlived
        {
            get
            {
                lock (_runningService)
                {
                    return _runningService.Count > 0;
                }
            }
        }
    }
}
