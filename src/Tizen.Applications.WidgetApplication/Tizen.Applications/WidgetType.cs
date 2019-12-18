/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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

            b.Bind(context, Interop.Widget.GetAppId(context));
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

