/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

        internal Builder(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Builder.Upcast(cPtr), cMemoryOwn)
        {
        }


        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Builder.DeleteBuilder(swigCPtr);
        }

        /// <since_tizen> 3 </since_tizen>
        public class QuitEventArgs : EventArgs
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void QuitEventCallbackDelegate();
        private DaliEventHandler<object, QuitEventArgs> _builderQuitEventHandler;
        private QuitEventCallbackDelegate _builderQuitEventCallbackDelegate;

        public event DaliEventHandler<object, QuitEventArgs> Quit
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_builderQuitEventHandler == null)
                    {
                        _builderQuitEventHandler += value;

                        _builderQuitEventCallbackDelegate = new QuitEventCallbackDelegate(OnQuit);
                        VoidSignal quitSignal = this.QuitSignal();
                        quitSignal?.Connect(_builderQuitEventCallbackDelegate);
                        quitSignal?.Dispose();
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_builderQuitEventHandler != null)
                    {
                        VoidSignal quitSignal = this.QuitSignal();
                        quitSignal?.Disconnect(_builderQuitEventCallbackDelegate);
                        quitSignal?.Dispose();
                    }

                    _builderQuitEventHandler -= value;
                }
            }
        }

        // Callback for Builder QuitSignal
        private void OnQuit()
        {
            QuitEventArgs e = new QuitEventArgs();

            if (_builderQuitEventHandler != null)
            {
                //here we send all data to user event handlers
                _builderQuitEventHandler(this, e);
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
            Interop.Builder.LoadFromString(swigCPtr, data, (int)format);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void LoadFromString(string data)
        {
            Interop.Builder.LoadFromString(swigCPtr, data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddConstants(PropertyMap map)
        {
            Interop.Builder.AddConstants(swigCPtr, PropertyMap.getCPtr(map));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddConstant(string key, PropertyValue value)
        {
            Interop.Builder.AddConstant(swigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PropertyMap GetConstants()
        {
            PropertyMap ret = new PropertyMap(Interop.Builder.GetConstants(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PropertyValue GetConstant(string key)
        {
            PropertyValue ret = new PropertyValue(Interop.Builder.GetConstant(swigCPtr, key), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName)
        {
            Animation ret = new Animation(Interop.Builder.CreateAnimation(swigCPtr, animationName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, PropertyMap map)
        {
            Animation ret = new Animation(Interop.Builder.CreateAnimationWithPropertyMap(swigCPtr, animationName, PropertyMap.getCPtr(map)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, View sourceActor)
        {
            Animation ret = new Animation(Interop.Builder.CreateAnimationWithView(swigCPtr, animationName, View.getCPtr(sourceActor)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, PropertyMap map, View sourceActor)
        {
            Animation ret = new Animation(Interop.Builder.CreateAnimation(swigCPtr, animationName, PropertyMap.getCPtr(map), View.getCPtr(sourceActor)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View Create(string templateName)
        {
            View ret = new View(Interop.Builder.Create(swigCPtr, templateName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public BaseHandle Create(string templateName, PropertyMap map)
        {
            BaseHandle ret = new BaseHandle(Interop.Builder.Create(swigCPtr, templateName, PropertyMap.getCPtr(map)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public BaseHandle CreateFromJson(string json)
        {
            BaseHandle ret = new BaseHandle(Interop.Builder.CreateFromJson(swigCPtr, json), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ApplyStyle(string styleName, Animatable handle)
        {
            bool ret = Interop.Builder.ApplyStyle(swigCPtr, styleName, Animatable.getCPtr(handle));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ApplyFromJson(Animatable handle, string json)
        {
            bool ret = Interop.Builder.ApplyFromJson(swigCPtr, Animatable.getCPtr(handle), json);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void AddViews(View toActor)
        {
            Interop.Builder.AddActors(swigCPtr, View.getCPtr(toActor));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddViews(string sectionName, View toActor)
        {
            Interop.Builder.AddActors(swigCPtr, sectionName, View.getCPtr(toActor));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void CreateRenderTask(string name)
        {
            Interop.Builder.CreateRenderTask(swigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Path GetPath(string name)
        {
            Path ret = new Path(Interop.Builder.GetPath(swigCPtr, name), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PathConstrainer GetPathConstrainer(string pathConstrainerName)
        {
            PathConstrainer ret = new PathConstrainer(Interop.Builder.GetPathConstrainer(swigCPtr, pathConstrainerName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LinearConstrainer GetLinearConstrainer(string linearConstrainerName)
        {
            LinearConstrainer ret = new LinearConstrainer(Interop.Builder.GetLinearConstrainer(swigCPtr, linearConstrainerName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal QuitSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.Builder.QuitSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum UIFormat
        {
            JSON
        }
    }
}
