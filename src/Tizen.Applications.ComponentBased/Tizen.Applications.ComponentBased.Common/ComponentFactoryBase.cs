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
        internal readonly Type _classType;
        internal readonly string _compId;
        internal IList<BaseComponent> _compInstances = new List<BaseComponent>();
        internal ComponentType _compType;
        private ComponentBasedApplicationBase _parent;

        internal ComponentFactoryBase(Type ctype, string id, ComponentType comp_type, ComponentBasedApplicationBase parent)
        {
            _compType = comp_type;
            _classType = ctype;
            _compId = id;
            _parent = parent;
        }

        internal ComponentType GetComponentType()
        {
            return _compType;
        }

        protected void OnLanguageChangedCallback(IntPtr context, string language, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnLanguageChangedCallback(language);
                }
            }
        }

        protected void OnDeviceOrientationChangedCallback(IntPtr context, int orientation, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnDeviceOrientationChangedCallback(orientation);
                }
            }
        }

        protected void OnLowBatteryCallback(IntPtr context, int status, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnLowBatteryCallback(status);
                }
            }
        }

        protected void OnLowMemoryCallback(IntPtr context, int status, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnLowMemoryCallback(status);
                }
            }
        }

        protected void OnRegionFormatChangedCallback(IntPtr context, string region, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnRegionFormatChangedCallback(region);
                }
            }
        }

        protected void OnSuspendedStateCallback(IntPtr context, int state, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnSuspendedStateCallback(state);
                }
            }
        }

        protected void OnRestoreCallback(IntPtr context, IntPtr content, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
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
            foreach (BaseComponent com in _compInstances)
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
