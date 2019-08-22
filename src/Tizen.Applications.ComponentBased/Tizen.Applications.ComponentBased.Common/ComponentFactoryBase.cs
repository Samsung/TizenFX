using System;
using System.Collections.Generic;
using System.Text;
using Tizen.Applications.CoreBackend;
using static Interop.CBApplication;
using static Tizen.Applications.CoreBackend.DefaultCoreBackend;

namespace Tizen.Applications.ComponentBased.Common
{
    internal abstract class ComponentFactoryBase
    {
        public IList<BaseComponent> ComponentInstances { get; }
        public Type ComponentClassType { get; }
        public ComponentType ComponentType { get; }
        public string ComponentId { get; }
        public ComponentBasedApplicationBase Parent { get; }

        internal ComponentFactoryBase(Type ctype, string id, ComponentType comp_type, ComponentBasedApplicationBase parent)
        {
            ComponentType = comp_type;
            ComponentClassType = ctype;
            ComponentId = id;
            Parent = parent;
            ComponentInstances = new List<BaseComponent>();
        }

        protected void OnLanguageChangedCallback(IntPtr context, string language, IntPtr userData)
        {
            foreach (BaseComponent com in ComponentInstances)
            {
                if (com.Handle == context)
                {
                    com.OnLanguageChangedCallback(language);
                }
            }
        }

        protected void OnDeviceOrientationChangedCallback(IntPtr context, int orientation, IntPtr userData)
        {
            foreach (BaseComponent com in ComponentInstances)
            {
                if (com.Handle == context)
                {
                    com.OnDeviceOrientationChangedCallback(orientation);
                }
            }
        }

        protected void OnLowBatteryCallback(IntPtr context, int status, IntPtr userData)
        {
            foreach (BaseComponent com in ComponentInstances)
            {
                if (com.Handle == context)
                {
                    com.OnLowBatteryCallback(status);
                }
            }
        }

        protected void OnLowMemoryCallback(IntPtr context, int status, IntPtr userData)
        {
            foreach (BaseComponent com in ComponentInstances)
            {
                if (com.Handle == context)
                {
                    com.OnLowMemoryCallback(status);
                }
            }
        }

        protected void OnRegionFormatChangedCallback(IntPtr context, string region, IntPtr userData)
        {
            foreach (BaseComponent com in ComponentInstances)
            {
                if (com.Handle == context)
                {
                    com.OnRegionFormatChangedCallback(region);
                }
            }
        }

        protected void OnSuspendedStateCallback(IntPtr context, int state, IntPtr userData)
        {
            foreach (BaseComponent com in ComponentInstances)
            {
                if (com.Handle == context)
                {
                    com.OnSuspendedStateCallback(state);
                }
            }
        }

        protected void OnRestoreCallback(IntPtr context, IntPtr content, IntPtr userData)
        {
            foreach (BaseComponent com in ComponentInstances)
            {
                if (com.Handle == context)
                {
                    Bundle bundle = null;

                    if (content != IntPtr.Zero)
                        bundle = new Bundle(new SafeBundleHandle(content, false));
                    com.OnRestoreContents(bundle);
                    break;
                }
            }
        }

        protected void OnSaveCallback(IntPtr context, IntPtr content, IntPtr userData)
        {
            foreach (BaseComponent com in ComponentInstances)
            {
                if (com.Handle == context)
                {
                    Bundle bundle = null;

                    if (content != IntPtr.Zero)
                        bundle = new Bundle(new SafeBundleHandle(content, false));
                    com.OnSaveContent(bundle);
                    break;
                }
            }
        }

        internal abstract IntPtr Bind(IntPtr h);
    }
}
