/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class Builder : BaseHandle
    {
        internal Builder(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }


        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Builder.DeleteBuilder(swigCPtr);
        }

        public class QuitEventArgs : EventArgs
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void QuitEventCallbackDelegate();
        private DaliEventHandler<object, QuitEventArgs> builderQuitEventHandler;
        private QuitEventCallbackDelegate builderQuitEventCallbackDelegate;

        public event DaliEventHandler<object, QuitEventArgs> Quit
        {
            add
            {
                // Restricted to only one listener
                if (builderQuitEventHandler == null)
                {
                    builderQuitEventHandler += value;
                    builderQuitEventCallbackDelegate = OnQuit;
                    Interop.Builder.QuitConnect(SwigCPtr, builderQuitEventCallbackDelegate.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                else
                {
                    Tizen.Log.Error("NUI", "[Builder.Quit] Only one listener is allowed\n");
                }
            }

            remove
            {
                if (builderQuitEventHandler != null)
                {
                    builderQuitEventHandler -= value;
                    if (builderQuitEventHandler == null)
                    {
                        Interop.Builder.QuitDisconnect(SwigCPtr, builderQuitEventCallbackDelegate.ToHandleRef(this));
                        NDalicPINVOKE.ThrowExceptionIfExists();
                        builderQuitEventCallbackDelegate = null;
                    }
                }
            }
        }

        // Callback for Builder QuitSignal
        private void OnQuit()
        {
            QuitEventArgs e = new QuitEventArgs();

            if (builderQuitEventHandler != null)
            {
                //here we send all data to user event handlers
                builderQuitEventHandler(this, e);
            }
        }

        ///
        public void LoadFromFile(string fileName)
        {
            try
            {
                string json = System.IO.File.ReadAllText(fileName);
                if (json.Length > 0)
                {
                    LoadFromString(json);
                }
                else
                {
                    throw new global::System.InvalidOperationException("Failed to load file " + fileName);

                }
            }
            catch (System.Exception e)
            {
                NUILog.Error(e.Message);
                throw new global::System.InvalidOperationException("Failed to parse " + fileName);
            }
        }

        public Builder() : this(Interop.Builder.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void LoadFromString(string data, Builder.UIFormat format)
        {
            Interop.Builder.LoadFromString(SwigCPtr, data, (int)format);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void LoadFromString(string data)
        {
            Interop.Builder.LoadFromString(SwigCPtr, data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddConstants(PropertyMap map)
        {
            Interop.Builder.AddConstants(SwigCPtr, PropertyMap.getCPtr(map));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddConstant(string key, PropertyValue value)
        {
            Interop.Builder.AddConstant(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PropertyMap GetConstants()
        {
            PropertyMap ret = new PropertyMap(Interop.Builder.GetConstants(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PropertyValue GetConstant(string key)
        {
            PropertyValue ret = new PropertyValue(Interop.Builder.GetConstant(SwigCPtr, key), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName)
        {
            Animation ret = new Animation(Interop.Builder.CreateAnimation(SwigCPtr, animationName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, PropertyMap map)
        {
            Animation ret = new Animation(Interop.Builder.CreateAnimationWithPropertyMap(SwigCPtr, animationName, PropertyMap.getCPtr(map)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, View sourceActor)
        {
            Animation ret = new Animation(Interop.Builder.CreateAnimationWithView(SwigCPtr, animationName, View.getCPtr(sourceActor)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, PropertyMap map, View sourceActor)
        {
            Animation ret = new Animation(Interop.Builder.CreateAnimation(SwigCPtr, animationName, PropertyMap.getCPtr(map), View.getCPtr(sourceActor)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View Create(string templateName)
        {
            View ret = new View(Interop.Builder.Create(SwigCPtr, templateName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public BaseHandle Create(string templateName, PropertyMap map)
        {
            BaseHandle ret = new BaseHandle(Interop.Builder.Create(SwigCPtr, templateName, PropertyMap.getCPtr(map)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public BaseHandle CreateFromJson(string json)
        {
            BaseHandle ret = new BaseHandle(Interop.Builder.CreateFromJson(SwigCPtr, json), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ApplyStyle(string styleName, Animatable handle)
        {
            bool ret = Interop.Builder.ApplyStyle(SwigCPtr, styleName, Animatable.getCPtr(handle));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ApplyFromJson(Animatable handle, string json)
        {
            bool ret = Interop.Builder.ApplyFromJson(SwigCPtr, Animatable.getCPtr(handle), json);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void AddViews(View toActor)
        {
            Interop.Builder.AddActors(SwigCPtr, View.getCPtr(toActor));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddViews(string sectionName, View toActor)
        {
            Interop.Builder.AddActors(SwigCPtr, sectionName, View.getCPtr(toActor));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void CreateRenderTask(string name)
        {
            Interop.Builder.CreateRenderTask(SwigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Path GetPath(string name)
        {
            Path ret = new Path(Interop.Builder.GetPath(SwigCPtr, name), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PathConstrainer GetPathConstrainer(string pathConstrainerName)
        {
            global::System.IntPtr cPtr = Interop.Builder.GetPathConstrainer(SwigCPtr, pathConstrainerName);

            PathConstrainer ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as PathConstrainer;
            if (ret != null)
            {
                global::System.Runtime.InteropServices.HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            else
            {
                ret = new PathConstrainer(cPtr, true);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LinearConstrainer GetLinearConstrainer(string linearConstrainerName)
        {
            global::System.IntPtr cPtr = Interop.Builder.GetLinearConstrainer(SwigCPtr, linearConstrainerName);

            LinearConstrainer ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as LinearConstrainer;
            if (ret != null)
            {
                global::System.Runtime.InteropServices.HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            else
            {
                ret = new LinearConstrainer(cPtr, true);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public enum UIFormat
        {
            JSON
        }
    }
}
