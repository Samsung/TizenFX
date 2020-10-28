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

    internal class PageTurnView : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal PageTurnView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.PageTurnView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PageTurnView obj)
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
                    NDalicPINVOKE.delete_PageTurnView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }




        /// <since_tizen> 3 </since_tizen>
        public class PagePanStartedEventArgs : EventArgs
        {
            private PageTurnView _pageTurnView;

            /// <since_tizen> 3 </since_tizen>
            public PageTurnView PageTurnView
            {
                get
                {
                    return _pageTurnView;
                }
                set
                {
                    _pageTurnView = value;
                }
            }
        }

        /// <since_tizen> 3 </since_tizen>
        public class PagePanFinishedEventArgs : EventArgs
        {
            private PageTurnView _pageTurnView;

            /// <since_tizen> 3 </since_tizen>
            public PageTurnView PageTurnView
            {
                get
                {
                    return _pageTurnView;
                }
                set
                {
                    _pageTurnView = value;
                }
            }
        }

        /// <since_tizen> 3 </since_tizen>
        public class PageTurnStartedEventArgs : EventArgs
        {
            private PageTurnView _pageTurnView;
            private uint _pageIndex;
            private bool _isTurningForward;

            /// <since_tizen> 3 </since_tizen>
            public PageTurnView PageTurnView
            {
                get
                {
                    return _pageTurnView;
                }
                set
                {
                    _pageTurnView = value;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public uint PageIndex
            {
                get
                {
                    return _pageIndex;
                }
                set
                {
                    _pageIndex = value;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public bool IsTurningForward
            {
                get
                {
                    return _isTurningForward;
                }
                set
                {
                    _isTurningForward = value;
                }
            }

        }

        /// <since_tizen> 3 </since_tizen>
        public class PageTurnFinishedEventArgs : EventArgs
        {
            private PageTurnView _pageTurnView;
            private uint _pageIndex;
            private bool _isTurningForward;

            /// <since_tizen> 3 </since_tizen>
            public PageTurnView PageTurnView
            {
                get
                {
                    return _pageTurnView;
                }
                set
                {
                    _pageTurnView = value;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public uint PageIndex
            {
                get
                {
                    return _pageIndex;
                }
                set
                {
                    _pageIndex = value;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public bool IsTurningForward
            {
                get
                {
                    return _isTurningForward;
                }
                set
                {
                    _isTurningForward = value;
                }
            }

        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void PagePanStartedCallbackDelegate(IntPtr page);
        private DaliEventHandler<object, PagePanStartedEventArgs> _pageTurnViewPagePanStartedEventHandler;
        private PagePanStartedCallbackDelegate _pageTurnViewPagePanStartedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void PagePanFinishedCallbackDelegate(IntPtr page);
        private DaliEventHandler<object, PagePanFinishedEventArgs> _pageTurnViewPagePanFinishedEventHandler;
        private PagePanFinishedCallbackDelegate _pageTurnViewPagePanFinishedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void PageTurnStartedCallbackDelegate(IntPtr page, uint pageIndex, bool isTurningForward);
        private DaliEventHandler<object, PageTurnStartedEventArgs> _pageTurnViewPageTurnStartedEventHandler;
        private PageTurnStartedCallbackDelegate _pageTurnViewPageTurnStartedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void PageTurnFinishedCallbackDelegate(IntPtr page, uint pageIndex, bool isTurningForward);
        private DaliEventHandler<object, PageTurnFinishedEventArgs> _pageTurnViewPageTurnFinishedEventHandler;
        private PageTurnFinishedCallbackDelegate _pageTurnViewPageTurnFinishedCallbackDelegate;

        public event DaliEventHandler<object, PagePanStartedEventArgs> PagePanStarted
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_pageTurnViewPagePanStartedEventHandler == null)
                    {
                        _pageTurnViewPagePanStartedEventHandler += value;

                        _pageTurnViewPagePanStartedCallbackDelegate = new PagePanStartedCallbackDelegate(OnPagePanStarted);
                        this.PagePanStartedSignal().Connect(_pageTurnViewPagePanStartedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_pageTurnViewPagePanStartedEventHandler != null)
                    {
                        this.PagePanStartedSignal().Disconnect(_pageTurnViewPagePanStartedCallbackDelegate);
                    }

                    _pageTurnViewPagePanStartedEventHandler -= value;
                }
            }
        }

        // Callback for PageTurnView PagePanStarted signal
        private void OnPagePanStarted(IntPtr page)
        {
            PagePanStartedEventArgs e = new PagePanStartedEventArgs();

            // Populate all members of "e" (PagePanStartedEventArgs) with real page
            e.PageTurnView = PageTurnView.GetPageTurnViewFromPtr(page);

            if (_pageTurnViewPagePanStartedEventHandler != null)
            {
                //here we send all page to user event handlers
                _pageTurnViewPagePanStartedEventHandler(this, e);
            }
        }

        public event DaliEventHandler<object, PagePanFinishedEventArgs> PagePanFinished
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_pageTurnViewPagePanFinishedEventHandler == null)
                    {
                        _pageTurnViewPagePanFinishedEventHandler += value;

                        _pageTurnViewPagePanFinishedCallbackDelegate = new PagePanFinishedCallbackDelegate(OnPagePanFinished);
                        this.PagePanFinishedSignal().Connect(_pageTurnViewPagePanFinishedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_pageTurnViewPagePanFinishedEventHandler != null)
                    {
                        this.PagePanFinishedSignal().Disconnect(_pageTurnViewPagePanFinishedCallbackDelegate);
                    }

                    _pageTurnViewPagePanFinishedEventHandler -= value;
                }
            }
        }

        // Callback for PageTurnView PagePanFinished signal
        private void OnPagePanFinished(IntPtr page)
        {
            PagePanFinishedEventArgs e = new PagePanFinishedEventArgs();

            // Populate all members of "e" (PagePanFinishedEventArgs) with real page
            e.PageTurnView = PageTurnView.GetPageTurnViewFromPtr(page);

            if (_pageTurnViewPagePanFinishedEventHandler != null)
            {
                //here we send all page to user event handlers
                _pageTurnViewPagePanFinishedEventHandler(this, e);
            }
        }


        public event DaliEventHandler<object, PageTurnStartedEventArgs> PageTurnStarted
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_pageTurnViewPageTurnStartedEventHandler == null)
                    {
                        _pageTurnViewPageTurnStartedEventHandler += value;

                        _pageTurnViewPageTurnStartedCallbackDelegate = new PageTurnStartedCallbackDelegate(OnPageTurnStarted);
                        this.PageTurnStartedSignal().Connect(_pageTurnViewPageTurnStartedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_pageTurnViewPageTurnStartedEventHandler != null)
                    {
                        this.PageTurnStartedSignal().Disconnect(_pageTurnViewPageTurnStartedCallbackDelegate);
                    }

                    _pageTurnViewPageTurnStartedEventHandler -= value;
                }
            }
        }

        // Callback for PageTurnView PageTurnStarted signal
        private void OnPageTurnStarted(IntPtr page, uint pageIndex, bool isTurningForward)
        {
            PageTurnStartedEventArgs e = new PageTurnStartedEventArgs();

            // Populate all members of "e" (PageTurnStartedEventArgs) with real page
            e.PageTurnView = PageTurnView.GetPageTurnViewFromPtr(page);
            e.PageIndex = pageIndex;
            e.IsTurningForward = isTurningForward;


            if (_pageTurnViewPageTurnStartedEventHandler != null)
            {
                //here we send all page to user event handlers
                _pageTurnViewPageTurnStartedEventHandler(this, e);
            }
        }


        public event DaliEventHandler<object, PageTurnFinishedEventArgs> PageTurnFinished
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_pageTurnViewPageTurnFinishedEventHandler == null)
                    {
                        _pageTurnViewPageTurnFinishedEventHandler += value;

                        _pageTurnViewPageTurnFinishedCallbackDelegate = new PageTurnFinishedCallbackDelegate(OnPageTurnFinished);
                        this.PageTurnFinishedSignal().Connect(_pageTurnViewPageTurnFinishedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_pageTurnViewPageTurnFinishedEventHandler != null)
                    {
                        this.PageTurnFinishedSignal().Disconnect(_pageTurnViewPageTurnFinishedCallbackDelegate);
                    }

                    _pageTurnViewPageTurnFinishedEventHandler -= value;
                }
            }
        }

        // Callback for PageTurnView PageTurnFinished signal
        private void OnPageTurnFinished(IntPtr page, uint pageIndex, bool isTurningForward)
        {
            PageTurnFinishedEventArgs e = new PageTurnFinishedEventArgs();

            // Populate all members of "e" (PageTurnFinishedEventArgs) with real page
            e.PageTurnView = PageTurnView.GetPageTurnViewFromPtr(page);
            e.PageIndex = pageIndex;
            e.IsTurningForward = isTurningForward;


            if (_pageTurnViewPageTurnFinishedEventHandler != null)
            {
                //here we send all page to user event handlers
                _pageTurnViewPageTurnFinishedEventHandler(this, e);
            }
        }

        public static PageTurnView GetPageTurnViewFromPtr(global::System.IntPtr cPtr)
        {
            PageTurnView ret = new PageTurnView(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <since_tizen> 3 </since_tizen>
        public new class Property : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            /// <since_tizen> 3 </since_tizen>
            protected bool swigCMemOwn;

            internal Property(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;
            //A Flat to check if it is already disposed.
            /// <since_tizen> 3 </since_tizen>
            protected bool disposed = false;


            ~Property()
            {
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public void Dispose()
            {
                //Throw excpetion if Dispose() is called in separate thread.
                if (!Window.IsInstalled())
                {
                    throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
                }

                if (isDisposeQueued)
                {
                    Dispose(DisposeTypes.Implicit);
                }
                else
                {
                    Dispose(DisposeTypes.Explicit);
                    System.GC.SuppressFinalize(this);
                }
            }

            /// <since_tizen> 3 </since_tizen>
            protected virtual void Dispose(DisposeTypes type)
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
                        NDalicPINVOKE.delete_PageTurnView_Property(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }

                disposed = true;
            }

            /// <since_tizen> 3 </since_tizen>
            public Property() : this(NDalicPINVOKE.new_PageTurnView_Property(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <since_tizen> 3 </since_tizen>
            public static readonly int PAGE_SIZE = NDalicPINVOKE.PageTurnView_Property_PAGE_SIZE_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int CURRENT_PAGE_ID = NDalicPINVOKE.PageTurnView_Property_CURRENT_PAGE_ID_get();
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SPINE_SHADOW = NDalicPINVOKE.PageTurnView_Property_SPINE_SHADOW_get();

        }

        public PageTurnView() : this(NDalicPINVOKE.new_PageTurnView__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PageTurnView(PageTurnView handle) : this(NDalicPINVOKE.new_PageTurnView__SWIG_1(PageTurnView.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PageTurnView Assign(PageTurnView handle)
        {
            PageTurnView ret = new PageTurnView(NDalicPINVOKE.PageTurnView_Assign(swigCPtr, PageTurnView.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public new static PageTurnView DownCast(BaseHandle handle)
        {
            PageTurnView ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as PageTurnView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PageTurnSignal PageTurnStartedSignal()
        {
            PageTurnSignal ret = new PageTurnSignal(NDalicPINVOKE.PageTurnView_PageTurnStartedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PageTurnSignal PageTurnFinishedSignal()
        {
            PageTurnSignal ret = new PageTurnSignal(NDalicPINVOKE.PageTurnView_PageTurnFinishedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PagePanSignal PagePanStartedSignal()
        {
            PagePanSignal ret = new PagePanSignal(NDalicPINVOKE.PageTurnView_PagePanStartedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PagePanSignal PagePanFinishedSignal()
        {
            PagePanSignal ret = new PagePanSignal(NDalicPINVOKE.PageTurnView_PagePanFinishedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        public Vector2 PageSize
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(PageTurnView.Property.PAGE_SIZE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(PageTurnView.Property.PAGE_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }
        public int CurrentPageId
        {
            get
            {
                int temp = 0;
                GetProperty(PageTurnView.Property.CURRENT_PAGE_ID).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(PageTurnView.Property.CURRENT_PAGE_ID, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 SpineShadow
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(PageTurnView.Property.SPINE_SHADOW).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(PageTurnView.Property.SPINE_SHADOW, new Tizen.NUI.PropertyValue(value));
            }
        }

    }

}
