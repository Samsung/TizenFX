/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{

    using System;
    using System.Runtime.InteropServices;
    using Tizen.NUI.BaseComponents;


    internal class Builder : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Builder(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Builder_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Builder obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.


            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Builder(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
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
                        this.QuitSignal().Connect(_builderQuitEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_builderQuitEventHandler != null)
                    {
                        this.QuitSignal().Disconnect(_builderQuitEventCallbackDelegate);
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



        public Builder() : this(NDalicPINVOKE.Builder_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public void LoadFromString(string data, Builder.UIFormat format)
        {
            NDalicPINVOKE.Builder_LoadFromString__SWIG_0(swigCPtr, data, (int)format);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void LoadFromString(string data)
        {
            NDalicPINVOKE.Builder_LoadFromString__SWIG_1(swigCPtr, data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddConstants(PropertyMap map)
        {
            NDalicPINVOKE.Builder_AddConstants(swigCPtr, PropertyMap.getCPtr(map));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddConstant(string key, PropertyValue value)
        {
            NDalicPINVOKE.Builder_AddConstant(swigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PropertyMap GetConstants()
        {
            PropertyMap ret = new PropertyMap(NDalicPINVOKE.Builder_GetConstants(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PropertyValue GetConstant(string key)
        {
            PropertyValue ret = new PropertyValue(NDalicPINVOKE.Builder_GetConstant(swigCPtr, key), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName)
        {
            Animation ret = new Animation(NDalicPINVOKE.Builder_CreateAnimation__SWIG_0(swigCPtr, animationName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, PropertyMap map)
        {
            Animation ret = new Animation(NDalicPINVOKE.Builder_CreateAnimation__SWIG_1(swigCPtr, animationName, PropertyMap.getCPtr(map)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, View sourceActor)
        {
            Animation ret = new Animation(NDalicPINVOKE.Builder_CreateAnimation__SWIG_2(swigCPtr, animationName, View.getCPtr(sourceActor)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, PropertyMap map, View sourceActor)
        {
            Animation ret = new Animation(NDalicPINVOKE.Builder_CreateAnimation__SWIG_3(swigCPtr, animationName, PropertyMap.getCPtr(map), View.getCPtr(sourceActor)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View Create(string templateName)
        {
            View ret = new View(NDalicPINVOKE.Builder_Create__SWIG_0(swigCPtr, templateName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public BaseHandle Create(string templateName, PropertyMap map)
        {
            BaseHandle ret = new BaseHandle(NDalicPINVOKE.Builder_Create__SWIG_1(swigCPtr, templateName, PropertyMap.getCPtr(map)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public BaseHandle CreateFromJson(string json)
        {
            BaseHandle ret = new BaseHandle(NDalicPINVOKE.Builder_CreateFromJson(swigCPtr, json), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ApplyStyle(string styleName, Animatable handle)
        {
            bool ret = NDalicPINVOKE.Builder_ApplyStyle(swigCPtr, styleName, Animatable.getCPtr(handle));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ApplyFromJson(Animatable handle, string json)
        {
            bool ret = NDalicPINVOKE.Builder_ApplyFromJson(swigCPtr, Animatable.getCPtr(handle), json);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void AddViews(View toActor)
        {
            NDalicPINVOKE.Builder_AddActors__SWIG_0(swigCPtr, View.getCPtr(toActor));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddViews(string sectionName, View toActor)
        {
            NDalicPINVOKE.Builder_AddActors__SWIG_1(swigCPtr, sectionName, View.getCPtr(toActor));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void CreateRenderTask(string name)
        {
            NDalicPINVOKE.Builder_CreateRenderTask(swigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FrameBufferImage GetFrameBufferImage(string name)
        {
            FrameBufferImage ret = new FrameBufferImage(NDalicPINVOKE.Builder_GetFrameBufferImage(swigCPtr, name), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Path GetPath(string name)
        {
            Path ret = new Path(NDalicPINVOKE.Builder_GetPath(swigCPtr, name), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PathConstrainer GetPathConstrainer(string pathConstrainerName)
        {
            PathConstrainer ret = new PathConstrainer(NDalicPINVOKE.Builder_GetPathConstrainer(swigCPtr, pathConstrainerName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LinearConstrainer GetLinearConstrainer(string linearConstrainerName)
        {
            LinearConstrainer ret = new LinearConstrainer(NDalicPINVOKE.Builder_GetLinearConstrainer(swigCPtr, linearConstrainerName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal QuitSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Builder_QuitSignal(swigCPtr), false);
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
