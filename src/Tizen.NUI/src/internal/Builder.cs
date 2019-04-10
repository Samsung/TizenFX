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

        internal Builder(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Builder.Builder_SWIGUpcast(cPtr), cMemoryOwn)
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
                    Interop.Builder.delete_Builder(swigCPtr);
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



        public Builder() : this(Interop.Builder.Builder_New(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();

        }
        public void LoadFromString(string data, Builder.UIFormat format)
        {
            Interop.Builder.Builder_LoadFromString__SWIG_0(swigCPtr, data, (int)format);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void LoadFromString(string data)
        {
            Interop.Builder.Builder_LoadFromString__SWIG_1(swigCPtr, data);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void AddConstants(PropertyMap map)
        {
            Interop.Builder.Builder_AddConstants(swigCPtr, PropertyMap.getCPtr(map));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void AddConstant(string key, PropertyValue value)
        {
            Interop.Builder.Builder_AddConstant(swigCPtr, key, PropertyValue.getCPtr(value));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public PropertyMap GetConstants()
        {
            PropertyMap ret = new PropertyMap(Interop.Builder.Builder_GetConstants(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public PropertyValue GetConstant(string key)
        {
            PropertyValue ret = new PropertyValue(Interop.Builder.Builder_GetConstant(swigCPtr, key), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName)
        {
            Animation ret = new Animation(Interop.Builder.Builder_CreateAnimation__SWIG_0(swigCPtr, animationName), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, PropertyMap map)
        {
            Animation ret = new Animation(Interop.Builder.Builder_CreateAnimation__SWIG_1(swigCPtr, animationName, PropertyMap.getCPtr(map)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, View sourceActor)
        {
            Animation ret = new Animation(Interop.Builder.Builder_CreateAnimation__SWIG_2(swigCPtr, animationName, View.getCPtr(sourceActor)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateAnimation(string animationName, PropertyMap map, View sourceActor)
        {
            Animation ret = new Animation(Interop.Builder.Builder_CreateAnimation__SWIG_3(swigCPtr, animationName, PropertyMap.getCPtr(map), View.getCPtr(sourceActor)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public View Create(string templateName)
        {
            View ret = new View(Interop.Builder.Builder_Create__SWIG_0(swigCPtr, templateName), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public BaseHandle Create(string templateName, PropertyMap map)
        {
            BaseHandle ret = new BaseHandle(Interop.Builder.Builder_Create__SWIG_1(swigCPtr, templateName, PropertyMap.getCPtr(map)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public BaseHandle CreateFromJson(string json)
        {
            BaseHandle ret = new BaseHandle(Interop.Builder.Builder_CreateFromJson(swigCPtr, json), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ApplyStyle(string styleName, Animatable handle)
        {
            bool ret = Interop.Builder.Builder_ApplyStyle(swigCPtr, styleName, Animatable.getCPtr(handle));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ApplyFromJson(Animatable handle, string json)
        {
            bool ret = Interop.Builder.Builder_ApplyFromJson(swigCPtr, Animatable.getCPtr(handle), json);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void AddViews(View toActor)
        {
            Interop.Builder.Builder_AddActors__SWIG_0(swigCPtr, View.getCPtr(toActor));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void AddViews(string sectionName, View toActor)
        {
            Interop.Builder.Builder_AddActors__SWIG_1(swigCPtr, sectionName, View.getCPtr(toActor));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void CreateRenderTask(string name)
        {
            Interop.Builder.Builder_CreateRenderTask(swigCPtr, name);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal FrameBufferImage GetFrameBufferImage(string name)
        {
            FrameBufferImage ret = new FrameBufferImage(Interop.Builder.Builder_GetFrameBufferImage(swigCPtr, name), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public Path GetPath(string name)
        {
            Path ret = new Path(Interop.Builder.Builder_GetPath(swigCPtr, name), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PathConstrainer GetPathConstrainer(string pathConstrainerName)
        {
            PathConstrainer ret = new PathConstrainer(Interop.Builder.Builder_GetPathConstrainer(swigCPtr, pathConstrainerName), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LinearConstrainer GetLinearConstrainer(string linearConstrainerName)
        {
            LinearConstrainer ret = new LinearConstrainer(Interop.Builder.Builder_GetLinearConstrainer(swigCPtr, linearConstrainerName), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal QuitSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.Builder.Builder_QuitSignal(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum UIFormat
        {
            JSON
        }

    }

}
