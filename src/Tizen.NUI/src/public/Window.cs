/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

    /// <summary>
    /// The window class is used internally for drawing.<br>
    /// A Window has an orientation and indicator properties.<br>
    /// </summary>
    public class Window : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private global::System.Runtime.InteropServices.HandleRef stageCPtr;

        internal Window(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Window_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            if (NDalicPINVOKE.Stage_IsInstalled())
            {
                stageCPtr = new global::System.Runtime.InteropServices.HandleRef(this, NDalicPINVOKE.Stage_GetCurrent());
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Window obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// To make Window instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
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

                    //Unreference this instance from Registry.
                    Registry.Unregister(this);

                    NDalicPINVOKE.delete_Window(swigCPtr);
                    NDalicPINVOKE.delete_Stage(stageCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        internal static Window GetCurrent()
        {
            Window ret = new Window(NDalicPINVOKE.Stage_GetCurrent(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

       internal static bool IsInstalled()
       {
            bool ret = NDalicPINVOKE.Stage_IsInstalled();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
       }

        [Obsolete("Please do not use! this will be internal method")]
        public void SetAcceptFocus(bool accept)
        {
            NDalicPINVOKE.SetAcceptFocus(swigCPtr, accept);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("Please do not use! this will be internal method")]
        public bool IsFocusAcceptable()
        {
            return NDalicPINVOKE.IsFocusAcceptable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Shows the window if it is hidden.
        /// </summary>
        public void Show()
        {
            NDalicPINVOKE.Show(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Hides the window if it is showing.
        /// </summary>
        public void Hide()
        {
            NDalicPINVOKE.Hide(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves whether the window is visible or not.
        /// </summary>
        /// <returns>true, if the windoe is visible</returns>
        public bool IsVisible()
        {
            bool temp = NDalicPINVOKE.IsVisible(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return temp;
        }

        /// <summary>
        /// Gets the count of supported auxiliary hints of the window.
        /// </summary>
        /// <returns>The number of supported auxiliary hints.</returns>
        public uint GetSupportedAuxiliaryHintCount() {
            uint ret = NDalicPINVOKE.GetSupportedAuxiliaryHintCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the supported auxiliary hint string of the window.
        /// </summary>
        /// <param name="index">The index of the supported auxiliary hint lists.</param>
        /// <returns>The auxiliary hint string of the index.</returns>
        public string GetSupportedAuxiliaryHint(uint index) {
            string ret = NDalicPINVOKE.GetSupportedAuxiliaryHint(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates an auxiliary hint of the window.
        /// </summary>
        /// <param name="hint">The auxiliary hint string.</param>
        /// <param name="value">The value string.</param>
        /// <returns>The ID of created auxiliary hint, or 0 on failure.</returns>
        public uint AddAuxiliaryHint(string hint, string value) {
            uint ret = NDalicPINVOKE.AddAuxiliaryHint(swigCPtr, hint, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes an auxiliary hint of the window.
        /// </summary>
        /// <param name="id">The ID of the auxiliary hint.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        public bool RemoveAuxiliaryHint(uint id) {
            bool ret = NDalicPINVOKE.RemoveAuxiliaryHint(swigCPtr, id);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Changes a value of the auxiliary hint.
        /// </summary>
        /// <param name="id">The auxiliary hint ID.</param>
        /// <param name="value">The value string to be set.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        public bool SetAuxiliaryHintValue(uint id, string value) {
            bool ret = NDalicPINVOKE.SetAuxiliaryHintValue(swigCPtr, id, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets a value of the auxiliary hint.
        /// </summary>
        /// <param name="id">The auxiliary hint ID.</param>
        /// <returns>The string value of the auxiliary hint ID, or an empty string if none exists.</returns>
        public string GetAuxiliaryHintValue(uint id) {
            string ret = NDalicPINVOKE.GetAuxiliaryHintValue(swigCPtr, id);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets an ID of the auxiliary hint string.
        /// </summary>
        /// <param name="hint">The auxiliary hint string.</param>
        /// <returns>The ID of auxiliary hint string, or 0 on failure.</returns>
        public uint GetAuxiliaryHintId(string hint) {
            uint ret = NDalicPINVOKE.GetAuxiliaryHintId(swigCPtr, hint);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a region to accept input events.
        /// </summary>
        /// <param name="inputRegion">The region to accept input events.</param>
        public void SetInputRegion(Rectangle inputRegion) {
            NDalicPINVOKE.SetInputRegion(swigCPtr, Rectangle.getCPtr(inputRegion));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets/Sets a window type.
        /// </summary>
        public WindowType Type
        {
            get
            {
                WindowType ret = (WindowType)NDalicPINVOKE.GetType(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                NDalicPINVOKE.SetType(swigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Sets a priority level for the specified notification window.
        /// </summary>
        /// <param name="level">The notification window level.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        public bool SetNotificationLevel(NotificationLevel level) {
            bool ret = NDalicPINVOKE.SetNotificationLevel(swigCPtr, (int)level);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets a priority level for the specified notification window.
        /// </summary>
        /// <returns>The notification window level.</returns>
        public NotificationLevel GetNotificationLevel() {
            NotificationLevel ret = (NotificationLevel)NDalicPINVOKE.GetNotificationLevel(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a transparent window's visual state to opaque.
        /// </summary>
        /// <param name="opaque">Whether the window's visual state is opaque.</param>
        public void SetOpaqueState(bool opaque) {
            NDalicPINVOKE.SetOpaqueState(swigCPtr, opaque);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether a transparent window's visual state is opaque or not.
        /// </summary>
        /// <returns>True if the window's visual state is opaque, false otherwise.</returns>
        public bool IsOpaqueState() {
            bool ret = NDalicPINVOKE.IsOpaqueState(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a window's screen mode.
        /// </summary>
        /// <param name="screenMode">The screen mode.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        public bool SetScreenMode(ScreenMode screenMode) {
            bool ret = NDalicPINVOKE.SetScreenMode(swigCPtr, (int)screenMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets a screen mode of the window.
        /// </summary>
        /// <returns>The screen mode.</returns>
        public ScreenMode GetScreenMode() {
            ScreenMode ret = (ScreenMode)NDalicPINVOKE.GetScreenMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets preferred brightness of the window.
        /// </summary>
        /// <param name="brightness">The preferred brightness (0 to 100).</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        public bool SetBrightness(int brightness) {
            bool ret = NDalicPINVOKE.SetBrightness(swigCPtr, brightness);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets preffered brightness of the window.
        /// </summary>
        /// <returns>The preffered brightness.</returns>
        public int GetBrightness() {
            int ret = NDalicPINVOKE.GetBrightness(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public class FocusChangedEventArgs : EventArgs
        {
            public bool FocusGained
            {
                get;
                set;
            }
        }

        private WindowFocusChangedEventCallbackType _windowFocusChangedEventCallback;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowFocusChangedEventCallbackType(bool focusGained);
        private event EventHandler<FocusChangedEventArgs> _windowFocusChangedEventHandler;

        public event EventHandler<FocusChangedEventArgs> FocusChanged
        {
            add
            {
                if (_windowFocusChangedEventHandler == null)
                {
                    _windowFocusChangedEventCallback = OnWindowFocusedChanged;
                    WindowFocusChangedSignal().Connect(_windowFocusChangedEventCallback);
                }

                _windowFocusChangedEventHandler += value;
            }
            remove
            {
                _windowFocusChangedEventHandler -= value;

                if (_windowFocusChangedEventHandler == null && WindowFocusChangedSignal().Empty() == false && _windowFocusChangedEventCallback != null)
                {
                    WindowFocusChangedSignal().Disconnect(_windowFocusChangedEventCallback);
                }
            }
        }

        private void OnWindowFocusedChanged(bool focusGained)
        {
            FocusChangedEventArgs e = new FocusChangedEventArgs();

            e.FocusGained = focusGained;

            if (_windowFocusChangedEventHandler != null)
            {
                _windowFocusChangedEventHandler(this, e);
            }
        }

        internal WindowFocusSignalType WindowFocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(NDalicPINVOKE.FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Window(Rectangle windowPosition, string name, bool isTransparent) : this(NDalicPINVOKE.Window_New__SWIG_0(Rectangle.getCPtr(windowPosition), name, isTransparent), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Window(Rectangle windowPosition, string name) : this(NDalicPINVOKE.Window_New__SWIG_1(Rectangle.getCPtr(windowPosition), name), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Window(Rectangle windowPosition, string name, string className, bool isTransparent) : this(NDalicPINVOKE.Window_New__SWIG_2(Rectangle.getCPtr(windowPosition), name, className, isTransparent), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Window(Rectangle windowPosition, string name, string className) : this(NDalicPINVOKE.Window_New__SWIG_3(Rectangle.getCPtr(windowPosition), name, className), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void ShowIndicator(Window.IndicatorVisibleMode visibleMode)
        {
            NDalicPINVOKE.Window_ShowIndicator(swigCPtr, (int)visibleMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetIndicatorBackgroundOpacity(Window.IndicatorBackgroundOpacity opacity)
        {
            NDalicPINVOKE.Window_SetIndicatorBgOpacity(swigCPtr, (int)opacity);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RotateIndicator(Window.WindowOrientation orientation)
        {
            NDalicPINVOKE.Window_RotateIndicator(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetClass(string name, string klass)
        {
            NDalicPINVOKE.Window_SetClass(swigCPtr, name, klass);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raises window to the top of Window stack.
        /// </summary>
        public void Raise()
        {
            NDalicPINVOKE.Window_Raise(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Lowers window to the bottom of Window stack.
        /// </summary>
        public void Lower()
        {
            NDalicPINVOKE.Window_Lower(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Activates window to the top of Window stack even it is iconified.
        /// </summary>
        public void Activate()
        {
            NDalicPINVOKE.Window_Activate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AddAvailableOrientation(Window.WindowOrientation orientation)
        {
            NDalicPINVOKE.Window_AddAvailableOrientation(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RemoveAvailableOrientation(Window.WindowOrientation orientation)
        {
            NDalicPINVOKE.Window_RemoveAvailableOrientation(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPreferredOrientation(Window.WindowOrientation orientation)
        {
            NDalicPINVOKE.Window_SetPreferredOrientation(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Window.WindowOrientation GetPreferredOrientation()
        {
            Window.WindowOrientation ret = (Window.WindowOrientation)NDalicPINVOKE.Window_GetPreferredOrientation(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal DragAndDropDetector GetDragAndDropDetector()
        {
            DragAndDropDetector ret = new DragAndDropDetector(NDalicPINVOKE.Window_GetDragAndDropDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Any GetNativeHandle()
        {
            Any ret = new Any(NDalicPINVOKE.Window_GetNativeHandle(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WindowFocusSignalType FocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(NDalicPINVOKE.FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get default ( root ) layer.
        /// </summary>
        /// <returns>The root layer</returns>
        public Layer GetDefaultLayer()
        {
            return this.GetRootLayer();
        }

        internal void Add(Layer layer)
        {
            NDalicPINVOKE.Stage_Add(stageCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Remove(Layer layer)
        {
            NDalicPINVOKE.Stage_Remove(stageCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Add(View view)
        {
            NDalicPINVOKE.Stage_Add(stageCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Remove(View view)
        {
            NDalicPINVOKE.Stage_Remove(stageCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetSize()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Stage_GetSize(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RenderTaskList GetRenderTaskList()
        {
            RenderTaskList ret = new RenderTaskList(NDalicPINVOKE.Stage_GetRenderTaskList(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the number of on-window layers.
        /// </summary>
        /// <returns>The number of layers.</returns>
        /// <remarks>Note that a default layer is always provided (count >= 1).</remarks>
        internal uint GetLayerCount()
        {
            uint ret = NDalicPINVOKE.Stage_GetLayerCount(stageCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Layer GetLayer(uint depth)
        {
            Layer ret = new Layer(NDalicPINVOKE.Stage_GetLayer(stageCPtr, depth), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Layer GetRootLayer()
        {
            Layer ret = new Layer(NDalicPINVOKE.Stage_GetRootLayer(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetBackgroundColor(Vector4 color)
        {
            NDalicPINVOKE.Stage_SetBackgroundColor(stageCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.Stage_GetBackgroundColor(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector2 GetDpi()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Stage_GetDpi(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ObjectRegistry GetObjectRegistry()
        {
            ObjectRegistry ret = new ObjectRegistry(NDalicPINVOKE.Stage_GetObjectRegistry(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Keep rendering for at least the given amount of time.
        /// </summary>
        /// <param name="durationSeconds">Time to keep rendering, 0 means render at least one more frame</param>
        public void KeepRendering(float durationSeconds)
        {
            NDalicPINVOKE.Stage_KeepRendering(stageCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal KeyEventSignal KeyEventSignal()
        {
            KeyEventSignal ret = new KeyEventSignal(NDalicPINVOKE.Stage_KeyEventSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal EventProcessingFinishedSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_EventProcessingFinishedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchSignal TouchSignal()
        {
            TouchSignal ret = new TouchSignal(NDalicPINVOKE.Stage_TouchSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private StageWheelSignal WheelEventSignal()
        {
            StageWheelSignal ret = new StageWheelSignal(NDalicPINVOKE.Stage_WheelEventSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ContextLostSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_ContextLostSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ContextRegainedSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_ContextRegainedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal SceneCreatedSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_SceneCreatedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ResizedSignal ResizedSignal()
        {
            ResizedSignal ret = new ResizedSignal(NDalicManualPINVOKE.Window_ResizedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Vector4 DEFAULT_BACKGROUND_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Stage_DEFAULT_BACKGROUND_COLOR_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Vector4 DEBUG_BACKGROUND_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Stage_DEBUG_BACKGROUND_COLOR_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private static readonly Window instance = Application.Instance.GetWindow();

        /// <summary>
        /// Stage instance property (read-only).<br>
        /// Gets the current Window.<br>
        /// </summary>
        public static Window Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Grabs the key specified by a key for a window only when a window is the topmost window. <br>
        /// This function can be used for following example scenarios: <br>
        /// - Mobile - Using volume up/down as zoom up/down in camera apps. <br>
        /// </summary>
        /// <param name="DaliKey">The key code to grab</param>
        /// <returns>true if the grab succeeds</returns>
        public bool GrabKeyTopmost(int DaliKey)
        {
            bool ret = NDalicManualPINVOKE.GrabKeyTopmost(HandleRef.ToIntPtr(this.swigCPtr), DaliKey);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Ungrabs the key specified by a key for a window. <br>
        /// Note: If this function is called between key down and up events of a grabbed key, an application doesn't receive the key up event.<br>
        /// </summary>
        /// <param name="DaliKey">The key code to ungrab</param>
        /// <returns>true if the ungrab succeeds</returns>
        public bool UngrabKeyTopmost(int DaliKey)
        {
            bool ret = NDalicManualPINVOKE.UngrabKeyTopmost(HandleRef.ToIntPtr(this.swigCPtr), DaliKey);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        ///  Grabs the key specified by a key for a window in a GrabMode. <br>
        ///  Details: This function can be used for following example scenarios: <br>
        ///  - TV - A user might want to change the volume or channel of the background TV contents while focusing on the foregrund app. <br>
        ///  - Mobile - When a user presses Home key, the homescreen appears regardless of current foreground app. <br>
        ///  - Mobile - Using volume up/down as zoom up/down in camera apps. <br>
        /// </summary>
        /// <param name="DaliKey">The key code to grab</param>
        /// <param name="GrabMode">The grab mode for the key</param>
        /// <returns>true if the grab succeeds</returns>
        public bool GrabKey(int DaliKey, KeyGrabMode GrabMode)
        {
            bool ret = NDalicManualPINVOKE.GrabKey(HandleRef.ToIntPtr(this.swigCPtr), DaliKey, (int)GrabMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Ungrabs the key specified by a key for a window.  <br>
        /// Note: If this function is called between key down and up events of a grabbed key, an application doesn't receive the key up event. <br>
        /// </summary>
        /// <param name="DaliKey">The key code to ungrab</param>
        /// <returns>true if the ungrab succeeds</returns>
        public bool UngrabKey(int DaliKey)
        {
            bool ret = NDalicManualPINVOKE.UngrabKey(HandleRef.ToIntPtr(this.swigCPtr), DaliKey);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal System.IntPtr GetNativeWindowHandler()
        {
            System.IntPtr ret = NDalicManualPINVOKE.GetNativeWindowHandler(HandleRef.ToIntPtr(this.swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Enumeration for orientation of the window is the way in which a rectangular page is oriented for normal viewing.
        /// </summary>
        public enum WindowOrientation
        {
            Portrait = 0,
            Landscape = 90,
            PortraitInverse = 180,
            LandscapeInverse = 270
        }

        /// <summary>
        /// Enumeration for key grab mode for platform-level APIs.
        /// </summary>
        public enum KeyGrabMode
        {
            /// <summary>
            /// Grab a key only when on the top of the grabbing-window stack mode.
            /// </summary>
            Topmost = 0,
            /// <summary>
            /// Grab a key together with the other client window(s) mode.
            /// </summary>
            Shared,
            /// <summary>
            /// Grab a key exclusively regardless of the grabbing-window's position on the window stack with the possibility of overriding the grab by the other client window mode.
            /// </summary>
            OverrideExclusive,
            /// <summary>
            /// Grab a key exclusively regardless of the grabbing-window's position on the window stack mode.
            /// </summary>
            Exclusive
        };

        /// <summary>
        /// Enumeration for opacity of the indicator.
        /// </summary>
        internal enum IndicatorBackgroundOpacity
        {
            Opaque = 100,
            Translucent = 50,
            Transparent = 0
        }

        /// <summary>
        /// Enumeration for visible mode of the indicator.
        /// </summary>
        internal enum IndicatorVisibleMode
        {
            Invisible = 0,
            Visible = 1,
            Auto = 2
        }

        /// <summary>
        /// Touch event argument.
        /// </summary>
        public class TouchEventArgs : EventArgs
        {
            private Touch _touch;

            /// <summary>
            /// Touch.
            /// </summary>
            public Touch Touch
            {
                get
                {
                    return _touch;
                }
                set
                {
                    _touch = value;
                }
            }
        }

        private event EventHandler<TouchEventArgs> _stageTouchHandler;
        private EventCallbackDelegateType1 _stageTouchCallbackDelegate;

        /// <summary>
        /// This is emitted when the screen is touched and when the touch ends.<br>
        /// If there are multiple touch points, then this will be emitted when the first touch occurs and
        /// then when the last finger is lifted.<br>
        /// An interrupted event will also be emitted (if it occurs).<br>
        /// </summary>
        public event EventHandler<TouchEventArgs> TouchEvent
        {
            add
            {
                lock (this)
                {
                    _stageTouchHandler += value;
                    _stageTouchCallbackDelegate = OnStageTouch;
                    this.TouchSignal().Connect(_stageTouchCallbackDelegate);
                }
            }
            remove
            {
                lock (this)
                {
                    if (_stageTouchHandler != null)
                    {
                        this.TouchSignal().Disconnect(_stageTouchCallbackDelegate);
                    }
                    _stageTouchHandler -= value;
                }
            }
        }

        private void OnStageTouch(IntPtr data)
        {
            TouchEventArgs e = new TouchEventArgs();

            if (data != null)
            {
                e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(data);
            }

            if (_stageTouchHandler != null)
            {
                _stageTouchHandler(this, e);
            }
        }

        /// <summary>
        /// Wheel event arguments.
        /// </summary>
        public class WheelEventArgs : EventArgs
        {
            private Wheel _wheel;

            /// <summary>
            /// Wheel.
            /// </summary>
            public Wheel Wheel
            {
                get
                {
                    return _wheel;
                }
                set
                {
                    _wheel = value;
                }
            }
        }

        private event EventHandler<WheelEventArgs> _stageWheelHandler;
        private EventCallbackDelegateType1 _stageWheelCallbackDelegate;

        /// <summary>
        /// Event emitted when wheel event is received.
        /// </summary>
        public event EventHandler<WheelEventArgs> WheelEvent
        {
            add
            {
                if (_stageWheelHandler == null)
                {
                    _stageWheelCallbackDelegate = OnStageWheel;
                    WheelEventSignal().Connect(_stageWheelCallbackDelegate);
                }
                _stageWheelHandler += value;
            }
            remove
            {
                _stageWheelHandler -= value;
                if (_stageWheelHandler == null && WheelEventSignal().Empty() == false)
                {
                    WheelEventSignal().Disconnect(_stageWheelCallbackDelegate);
                }
            }
        }

        private void OnStageWheel(IntPtr data)
        {
            WheelEventArgs e = new WheelEventArgs();

            if (data != null)
            {
                e.Wheel = Tizen.NUI.Wheel.GetWheelFromPtr(data);
            }

            if (_stageWheelHandler != null)
            {
                _stageWheelHandler(this, e);
            }
        }

        /// <summary>
        /// Key event arguments.
        /// </summary>
        public class KeyEventArgs : EventArgs
        {
            private Key _key;

            /// <summary>
            /// Key
            /// </summary>
            public Key Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    _key = value;
                }
            }
        }

        private event EventHandler<KeyEventArgs> _stageKeyHandler;
        private EventCallbackDelegateType1 _stageKeyCallbackDelegate;

        /// <summary>
        /// Event emitted when key event is received.
        /// </summary>
        public event EventHandler<KeyEventArgs> KeyEvent
        {
            add
            {
                if (_stageKeyHandler == null)
                {
                    _stageKeyCallbackDelegate = OnStageKey;
                    KeyEventSignal().Connect(_stageKeyCallbackDelegate);
                }
                _stageKeyHandler += value;
            }
            remove
            {
                _stageKeyHandler -= value;
                if (_stageKeyHandler == null && KeyEventSignal().Empty() == false)
                {
                    KeyEventSignal().Disconnect(_stageKeyCallbackDelegate);
                }
            }
        }

        // Callback for Stage KeyEventsignal
        private void OnStageKey(IntPtr data)
        {
            KeyEventArgs e = new KeyEventArgs();

            if (data != null)
            {
                e.Key = Tizen.NUI.Key.GetKeyFromPtr(data);
            }

            if (_stageKeyHandler != null)
            {
                //here we send all data to user event handlers
                _stageKeyHandler(this, e);
            }
        }


        private event EventHandler _stageEventProcessingFinishedEventHandler;
        private EventCallbackDelegateType0 _stageEventProcessingFinishedEventCallbackDelegate;

        internal event EventHandler EventProcessingFinished
        {
            add
            {
                if (_stageEventProcessingFinishedEventHandler == null)
                {
                    _stageEventProcessingFinishedEventCallbackDelegate = OnEventProcessingFinished;
                    EventProcessingFinishedSignal().Connect(_stageEventProcessingFinishedEventCallbackDelegate);
                }
                _stageEventProcessingFinishedEventHandler += value;

            }
            remove
            {
                _stageEventProcessingFinishedEventHandler -= value;
                if (_stageEventProcessingFinishedEventHandler == null && EventProcessingFinishedSignal().Empty() == false)
                {
                    EventProcessingFinishedSignal().Disconnect(_stageEventProcessingFinishedEventCallbackDelegate);
                }
            }
        }

        // Callback for Stage EventProcessingFinishedSignal
        private void OnEventProcessingFinished()
        {
            if (_stageEventProcessingFinishedEventHandler != null)
            {
                _stageEventProcessingFinishedEventHandler(this, null);
            }
        }


        private EventHandler _stageContextLostEventHandler;
        private EventCallbackDelegateType0 _stageContextLostEventCallbackDelegate;

        internal event EventHandler ContextLost
        {
            add
            {
                if (_stageContextLostEventHandler == null)
                {
                    _stageContextLostEventCallbackDelegate = OnContextLost;
                    ContextLostSignal().Connect(_stageContextLostEventCallbackDelegate);
                }
                _stageContextLostEventHandler += value;
            }
            remove
            {
                _stageContextLostEventHandler -= value;
                if (_stageContextLostEventHandler == null && ContextLostSignal().Empty() == false)
                {
                    ContextLostSignal().Disconnect(_stageContextLostEventCallbackDelegate);
                }
            }
        }

        // Callback for Stage ContextLostSignal
        private void OnContextLost()
        {
            if (_stageContextLostEventHandler != null)
            {
                _stageContextLostEventHandler(this, null);
            }
        }


        private EventHandler _stageContextRegainedEventHandler;
        private EventCallbackDelegateType0 _stageContextRegainedEventCallbackDelegate;

        internal event EventHandler ContextRegained
        {
            add
            {
                if (_stageContextRegainedEventHandler == null)
                {
                    _stageContextRegainedEventCallbackDelegate = OnContextRegained;
                    ContextRegainedSignal().Connect(_stageContextRegainedEventCallbackDelegate);
                }
                _stageContextRegainedEventHandler += value;
            }
            remove
            {
                _stageContextRegainedEventHandler -= value;
                if (_stageContextRegainedEventHandler == null && ContextRegainedSignal().Empty() == false)
                {
                    this.ContextRegainedSignal().Disconnect(_stageContextRegainedEventCallbackDelegate);
                }
            }
        }

        // Callback for Stage ContextRegainedSignal
        private void OnContextRegained()
        {
            if (_stageContextRegainedEventHandler != null)
            {
                _stageContextRegainedEventHandler(this, null);
            }
        }


        private EventHandler _stageSceneCreatedEventHandler;
        private EventCallbackDelegateType0 _stageSceneCreatedEventCallbackDelegate;

        internal event EventHandler SceneCreated
        {
            add
            {
                if (_stageSceneCreatedEventHandler == null)
                {
                    _stageSceneCreatedEventCallbackDelegate = OnSceneCreated;
                    SceneCreatedSignal().Connect(_stageSceneCreatedEventCallbackDelegate);
                }
                _stageSceneCreatedEventHandler += value;
            }
            remove
            {
                _stageSceneCreatedEventHandler -= value;
                if (_stageSceneCreatedEventHandler == null && SceneCreatedSignal().Empty() == false)
                {
                    SceneCreatedSignal().Disconnect(_stageSceneCreatedEventCallbackDelegate);
                }
            }
        }

        // Callback for Stage SceneCreatedSignal
        private void OnSceneCreated()
        {
            if (_stageSceneCreatedEventHandler != null)
            {
                _stageSceneCreatedEventHandler(this, null);
            }
        }

        public class ResizedEventArgs : EventArgs
        {
            int _width;
            int _height;

            public int Width
            {
                get
                {
                    return _width;
                }
                set
                {
                    _width = value;
                }
            }

            public int Height
            {
                get
                {
                    return _height;
                }
                set
                {
                    _height = value;
                }
            }
        }

        private WindowResizedEventCallbackType _windowResizedEventCallback;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowResizedEventCallbackType(int width, int height);
        private event EventHandler<ResizedEventArgs> _windowResizedEventHandler;

        public event EventHandler<ResizedEventArgs> Resized
        {
            add
            {
                if (_windowResizedEventHandler == null)
                {
                    _windowResizedEventCallback = OnResized;
                    ResizedSignal().Connect(_windowResizedEventCallback);
                }

                _windowResizedEventHandler += value;
            }
            remove
            {
                _windowResizedEventHandler -= value;

                if (_windowResizedEventHandler == null && ResizedSignal().Empty() == false && _windowResizedEventCallback != null)
                {
                    ResizedSignal().Disconnect(_windowResizedEventCallback);
                }
            }
        }

        private void OnResized(int width, int height)
        {
            ResizedEventArgs e = new ResizedEventArgs();
            e.Width = width;
            e.Height = height;

            if (_windowResizedEventHandler != null)
            {
                _windowResizedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Window size property (read-only).
        /// </summary>
        public Size2D Size
        {
            get
            {
                Size2D ret = GetSize();
                return ret;
            }
        }

        /// <summary>
        /// Background color property.
        /// </summary>
        public Color BackgroundColor
        {
            set
            {
                SetBackgroundColor(value);
            }
            get
            {
                Color ret = GetBackgroundColor();
                return ret;
            }
        }

        /// <summary>
        /// Dpi property (read-only).<br>
        /// Retrieves the DPI of the display device to which the Window is connected.<br>
        /// </summary>
        public Vector2 Dpi
        {
            get
            {
                return GetDpi();
            }
        }

        /// <summary>
        /// Layer count property (read-only).<br>
        /// Queries the number of on-Window layers.<br>
        /// </summary>
        public uint LayerCount
        {
            get
            {
                return GetLayerCount();
            }
        }


        /// <summary>
        /// Add layer to the Stage.
        /// </summary>
        /// <param name="layer">Layer to add</param>
        public void AddLayer(Layer layer)
        {
            NDalicPINVOKE.Stage_Add(stageCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Remove layer from the Stage.
        /// </summary>
        /// <param name="layer">Layer to remove</param>
        public void RemoveLayer(Layer layer)
        {
            NDalicPINVOKE.Stage_Remove(stageCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("Please do not use! this will be deprecated")]
        public class WindowFocusChangedEventArgs : EventArgs
        {
            public bool FocusGained
            {
                get;
                set;
            }
        }

        private WindowFocusChangedEventCallbackType _windowFocusChangedEventCallback2;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowFocusChangedEventCallbackType2(bool focusGained);
        private event EventHandler<WindowFocusChangedEventArgs> _windowFocusChangedEventHandler2;

        [Obsolete("Please do not use! this will be deprecated")]
        public event EventHandler<WindowFocusChangedEventArgs> WindowFocusChanged
        {
            add
            {
                if (_windowFocusChangedEventHandler2 == null)
                {
                    _windowFocusChangedEventCallback2 = OnWindowFocusedChanged2;
                    WindowFocusChangedSignal().Connect(_windowFocusChangedEventCallback2);
                }

                _windowFocusChangedEventHandler2 += value;
            }
            remove
            {
                _windowFocusChangedEventHandler2 -= value;

                if (_windowFocusChangedEventHandler2 == null && WindowFocusChangedSignal().Empty() == false && _windowFocusChangedEventCallback2 != null)
                {
                    WindowFocusChangedSignal().Disconnect(_windowFocusChangedEventCallback2);
                }
            }
        }

        private void OnWindowFocusedChanged2(bool focusGained)
        {
            WindowFocusChangedEventArgs e = new WindowFocusChangedEventArgs();

            e.FocusGained = focusGained;

            if (_windowFocusChangedEventHandler2 != null)
            {
                _windowFocusChangedEventHandler2(this, e);
            }
        }




    }
}
