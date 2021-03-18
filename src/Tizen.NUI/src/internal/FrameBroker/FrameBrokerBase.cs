/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.Applications;
using Tizen.Applications.Exceptions;

namespace Tizen.NUI
{
    /// <summary>
    /// Represents the Frame Broker.
    /// </summary>
    internal abstract class FrameBrokerBase : IDisposable
    {
        private string logTag = "NUI";
        private readonly SafeFrameBrokerHandle handle;
        private Dictionary<int, Interop.FrameBroker.AppControlResultCallback> resultCallbackMaps = new Dictionary<int, Interop.FrameBroker.AppControlResultCallback>();
        private int resultId = 0;
        private Interop.FrameBroker.FrameContextLifecycleCallbacks callbacks;
        private IntPtr context = IntPtr.Zero;
        private bool disposed = false;

        private Renderer renderer;
        private TextureSet textureSet;

        /// <summary>
        /// Initializes the FrameBroker class.
        /// </summary>
        /// <param name="window">The window instance of Ecore_Wl2_Window pointer.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid parameter.</exception>
        /// <exception cref="Applications.Exceptions.OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed to create the frame broker handle.</exception>
        /// <remarks>This class is only available for platform level signed applications.</remarks>
        internal FrameBrokerBase(Window window)
        {
            Interop.FrameBroker.ErrorCode err;

            if (window == null)
            {
                throw FrameBrokerBaseErrorFactory.GetException(Interop.FrameBroker.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            callbacks.OnCreate = new Interop.FrameBroker.FrameContextCreateCallback(OnCreateNative);
            callbacks.OnResume = new Interop.FrameBroker.FrameContextResumeCallback(OnResumeNavie);
            callbacks.OnPause = new Interop.FrameBroker.FrameContextPauseCallback(OnPauseNative);
            callbacks.OnDestroy = new Interop.FrameBroker.FrameContextDestroyCallback(OnDestroyNative);
            callbacks.OnError = new Interop.FrameBroker.FrameContextErrorCallback(OnErrorNative);
            callbacks.OnUpdate = new Interop.FrameBroker.FrameContextUpdateCallback(OnUpdateNative);

            err = Interop.FrameBroker.Create(window.GetNativeWindowHandler(), ref callbacks, IntPtr.Zero, out handle);
            if (err != Interop.FrameBroker.ErrorCode.None)
            {
                throw FrameBrokerBaseErrorFactory.GetException(err, "Failed to create frame broker handle");
            }
        }

        /// <summary>
        /// Sends the launch request asynchronously.
        /// </summary>
        /// <remarks>
        /// The operation is mandatory information for the launch request.
        /// If the operation is not specified, AppControlOperations.Default is used by default.
        /// If the operation is AppControlOperations.Default, the application ID is mandatory to explicitly launch the application.<br/>
        /// Since Tizen 2.4, the launch request of the service application over out of packages is restricted by the platform.
        /// Also, implicit launch requests are NOT delivered to service applications since 2.4.
        /// To launch a service application, an explicit launch request with the application ID given by property ApplicationId MUST be sent.
        /// </remarks>
        /// <param name="appControl">The AppControl.</param>
        /// <param name="toProvider"> The flag, if it's true, the launch request is sent to the frame provider application.</param>
        /// <returns>A task with the result of the launch request.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="AppNotFoundException">Thrown when the application to run is not found.</exception>
        /// <exception cref="LaunchRejectedException">Thrown when the launch request is rejected.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        internal Task<FrameBrokerBaseResult> SendLaunchRequest(AppControl appControl, bool toProvider)
        {
            if (appControl == null)
            {
                throw FrameBrokerBaseErrorFactory.GetException(Interop.FrameBroker.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            var task = new TaskCompletionSource<FrameBrokerBaseResult>();
            int requestId = 0;

            lock (resultCallbackMaps)
            {
                requestId = resultId++;
                resultCallbackMaps[requestId] = (handle, result, userData) =>
                {
                    task.SetResult((FrameBrokerBaseResult)result);
                    lock (resultCallbackMaps)
                    {
                        resultCallbackMaps.Remove((int)userData);
                    }
                };
            }

            Interop.FrameBroker.ErrorCode err;
            if (toProvider)
                err = Interop.FrameBroker.SendLaunchRequestToProvider(handle, appControl.SafeAppControlHandle, resultCallbackMaps[requestId], null, (IntPtr)requestId);
            else
                err = Interop.FrameBroker.SendLaunchRequest(handle, appControl.SafeAppControlHandle, resultCallbackMaps[requestId], null, (IntPtr)requestId);

            if (err != Interop.FrameBroker.ErrorCode.None)
            {
                throw FrameBrokerBaseErrorFactory.GetException(err, "Failed to send launch request");
            }

            return task.Task;
        }

        /// <summary>
        /// Notifies that the animation is started.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        internal void StartAnimation()
        {
            Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.StartAnimation(context);
            if (err != Interop.FrameBroker.ErrorCode.None)
            {
                throw FrameBrokerBaseErrorFactory.GetException(err, "Failed to notify that the animation is started");
            }
        }

        /// <summary>
        /// Notifies that the animation is finished.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        internal void FinishAnimation()
        {
            Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.FinishAnimation(context);
            if (err != Interop.FrameBroker.ErrorCode.None)
            {
                throw FrameBrokerBaseErrorFactory.GetException(err, "Failed to notify that the animation is finished");
            }
        }

        /// <summary>
        /// Occurs whenever the frame is created.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameCreated()
        {
            Log.Warn(logTag, "The OnFrameCreated() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the frame is resumed.
        /// </summary>
        /// <param name="frame">The frame data.</param>
        /// <remarks>
        /// When the frame has been prepared, this function is called.
        /// The caller can start animations, To notify that the animation is started, the caller should call StartAnimation().
        /// After the animation is finished, the caller should call FinishAnimation() to notify.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameResumed(FrameData frame)
        {
            Log.Warn(logTag, "The OnFrameResumed() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the frame is updated.
        /// </summary>
        /// <param name="frame">The frame data.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameUpdated(FrameData frame)
        {
            Log.Warn(logTag, "The OnFrameUpdated() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the frame is paused.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFramePaused()
        {
            Log.Warn(logTag, "The OnFramePaused() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the frame is destroyed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameDestroyed()
        {
            Log.Warn(logTag, "The OnFrameDestroyed() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the system error is occurred.
        /// </summary>
        /// <param name="error">The frame error.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameErred(FrameError error)
        {
            Log.Warn(logTag, "The OnFrameErred() is not implemented");
        }

        private void OnCreateNative(IntPtr context, IntPtr userData)
        {
            this.context = context;
            OnFrameCreated();
        }

        private void OnResumeNavie(IntPtr context, IntPtr frame, IntPtr userData)
        {
            OnFrameResumed(new FrameData(frame));
        }

        private void OnPauseNative(IntPtr context, IntPtr userData)
        {
            OnFramePaused();
        }

        private void OnDestroyNative(IntPtr context, IntPtr userData)
        {
            context = IntPtr.Zero;
            OnFrameDestroyed();
        }

        private void OnErrorNative(IntPtr context, int error, IntPtr userData)
        {
            context = IntPtr.Zero;
            OnFrameErred((FrameError)error);
        }

        private void OnUpdateNative(IntPtr context, IntPtr frame, IntPtr userData)
        {
            OnFrameUpdated(new FrameData(frame));
        }


        private Shader CreateShader()
        {
            string vertex_shader =
                "attribute mediump vec2 aPosition;\n" +
                "varying mediump vec2 vTexCoord;\n" +
                "uniform highp mat4 uMvpMatrix;\n" +
                "uniform mediump vec3 uSize;\n" +
                "varying mediump vec2 sTexCoordRect;\n" +
                "void main()\n" +
                "{\n" +
                "gl_Position = uMvpMatrix * vec4(aPosition * uSize.xy, 0.0, 1.0);\n" +
                "vTexCoord = aPosition + vec2(0.5);\n" +
                "}\n";

            string fragment_shader =
                "#extension GL_OES_EGL_image_external:require\n" +
                "uniform lowp vec4 uColor;\n" +
                "varying mediump vec2 vTexCoord;\n" +
                "uniform samplerExternalOES sTexture;\n" +
                "void main()\n" +
                "{\n" +
                "gl_FragColor = texture2D(sTexture, vTexCoord) * uColor;\n" +
                "}\n";

            return new Shader(vertex_shader, fragment_shader);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Vec2
        {
            float x;
            float y;
            public Vec2(float xIn, float yIn)
            {
                x = xIn;
                y = yIn;
            }
        }

        private struct TexturedQuadVertex
        {
            public Vec2 position;
        };

        private IntPtr RectangleDataPtr()
        {
            TexturedQuadVertex vertex1 = new TexturedQuadVertex();
            TexturedQuadVertex vertex2 = new TexturedQuadVertex();
            TexturedQuadVertex vertex3 = new TexturedQuadVertex();
            TexturedQuadVertex vertex4 = new TexturedQuadVertex();
            vertex1.position = new Vec2(-0.5f, -0.5f);
            vertex2.position = new Vec2(-0.5f, 0.5f);
            vertex3.position = new Vec2(0.5f, -0.5f);
            vertex4.position = new Vec2(0.5f, 0.5f);

            TexturedQuadVertex[] texturedQuadVertexData = new TexturedQuadVertex[4] { vertex1, vertex2, vertex3, vertex4 };

            int lenght = Marshal.SizeOf(vertex1);
            IntPtr pA = Marshal.AllocHGlobal(lenght * 4);

            for (int i = 0; i < 4; i++)
            {
                Marshal.StructureToPtr(texturedQuadVertexData[i], pA + i * lenght, true);
            }

            return pA;
        }

        private Geometry CreateQuadGeometry()
        {
            /* Create Property buffer */
            PropertyValue value = new PropertyValue((int)PropertyType.Vector2);
            PropertyMap vertexFormat = new PropertyMap();
            PropertyBuffer vertexBuffer = new PropertyBuffer(vertexFormat);

            vertexFormat.Add("aPosition", value);
            vertexBuffer.SetData(RectangleDataPtr(), 4);

            Geometry geometry = new Geometry();
            geometry.AddVertexBuffer(vertexBuffer);
            geometry.SetType(Geometry.Type.TRIANGLE_STRIP);

            value.Dispose();
            vertexFormat.Dispose();
            vertexBuffer.Dispose();

            return geometry;
        }

        internal Renderer GetRenderer(FrameData data)
        {
            Geometry geometry = CreateQuadGeometry();
            Shader shader = CreateShader();
            Texture texture = null;
            renderer = new Renderer(geometry, shader);
            textureSet = new TextureSet();

            switch (data.Type)
            {
                case FrameData.FrameType.RemoteSurfaceTbmSurface:
                    if (data.TbmSurface == null)
                    {
                        geometry.Dispose();
                        shader.Dispose();
                        return null;
                    }
                    texture = new Texture(data.TbmSurface);
                    textureSet.SetTexture(0, texture);
                    renderer.SetTextures(textureSet);
                    break;
                default:
                    break;
            }

            texture?.Dispose();
            geometry.Dispose();
            shader.Dispose();
            return renderer;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                handle.Dispose();
                renderer?.Dispose();
                textureSet?.Dispose();
                disposed = true;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);

        }
    }
}
