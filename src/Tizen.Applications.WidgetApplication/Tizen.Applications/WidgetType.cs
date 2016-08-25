// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;

namespace Tizen.Applications
{
    internal class WidgetType
    {
        internal readonly Type ClassType;
        internal readonly string Id;
        internal IList<WidgetBase> WidgetInstances = new List<WidgetBase>();

        private Interop.Widget.WidgetiInstanceLifecycleCallbacks _callbacks;

        internal WidgetType(Type ctype, string id)
        {
            ClassType = ctype;
            Id = id;
            _callbacks.OnCreate = new Interop.Widget.WidgetInstanceCreateCallback(OnCreate);
            _callbacks.OnDestroy = new Interop.Widget.WidgetInstanceDestroyCallback(OnDestroy);
            _callbacks.OnPause = new Interop.Widget.WidgetInstancePauseCallback(OnPause);
            _callbacks.OnResume = new Interop.Widget.WidgetInstanceResumeCallback(OnResume);
            _callbacks.OnResize = new Interop.Widget.WidgetInstanceResizeCallback(OnResize);
            _callbacks.OnUpdate = new Interop.Widget.WidgetInstanceUpdateCallback(OnUpdate);
        }

        internal IntPtr Bind(IntPtr h)
        {
            return Interop.Widget.AddClass(h, Id, _callbacks, IntPtr.Zero);
        }

        private int OnCreate(IntPtr context, IntPtr content, int w, int h, IntPtr userData)
        {
            WidgetBase b = Activator.CreateInstance(ClassType) as WidgetBase;
            Bundle bundle = null;

            if (b == null)
                return 0;

            b.Bind(context, Id);
            WidgetInstances.Add(b);
            if (content != IntPtr.Zero)
                bundle = new Bundle(new SafeBundleHandle(content, false));
            b.OnCreate(bundle, w, h);

            return 0;
        }

        private int OnDestroy(IntPtr context, Interop.Widget.WidgetAppDestroyType reason, IntPtr content, IntPtr userData)
        {
            foreach (WidgetBase w in WidgetInstances)
            {
                if(w.Handle == context)
                {
                    Bundle bundle = null;

                    if (content != IntPtr.Zero)
                        bundle = new Bundle(new SafeBundleHandle(content, false));

                    w.OnDestroy(reason == Interop.Widget.WidgetAppDestroyType.Permanent ?
                        WidgetBase.WidgetDestroyType.Permanent :
                        WidgetBase.WidgetDestroyType.Temporary, bundle);
                    WidgetInstances.Remove(w);
                    break;
                }
            }

            return 0;
        }

        private int OnPause(IntPtr context, IntPtr userData)
        {
            foreach (WidgetBase w in WidgetInstances)
            {
                if (w.Handle == context)
                {
                    w.OnPause();
                    break;
                }
            }
            return 0;
        }

        private int OnResume(IntPtr context, IntPtr userData)
        {
            foreach (WidgetBase w in WidgetInstances)
            {
                if (w.Handle == context)
                {
                    w.OnResume();
                    break;
                }
            }
            return 0;
        }

        private int OnResize(IntPtr context, int w, int h, IntPtr userData)
        {
            foreach (WidgetBase o in WidgetInstances)
            {
                if (o.Handle == context)
                {
                    o.OnResize(w, h);
                    break;
                }
            }
            return 0;
        }

        private int OnUpdate(IntPtr context, IntPtr content, int force, IntPtr userData)
        {
            foreach (WidgetBase o in WidgetInstances)
            {
                if (o.Handle == context)
                {
                    Bundle bundle = null;

                    if (content != IntPtr.Zero)
                        bundle = new Bundle(new SafeBundleHandle(content, false));
                    o.OnUpdate(bundle, force != 0 ? true : false);
                    break;
                }
            }
            return 0;
        }
    }
}

