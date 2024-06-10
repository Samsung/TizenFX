/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// DragAndDrop controls the drag object and data.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000: Dispose objects before losing scope", Justification = "It does not have ownership.")]
    public class DragAndDrop : BaseHandle
    {
        public delegate void SourceEventHandler(DragSourceEventType sourceEventType);
        private delegate void InternalSourceEventHandler(int sourceEventType);
        public delegate void DragAndDropEventHandler(View targetView, DragEvent dragEvent);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void DragAndDropWindowEventHandler(Window targetWindow, DragEvent dragEvent);
        private delegate void InternalDragAndDropEventHandler(global::System.IntPtr dragEvent);
        private InternalSourceEventHandler sourceEventCb;
        private Dictionary<View, InternalDragAndDropEventHandler> targetEventDictionary = new Dictionary<View, InternalDragAndDropEventHandler>();
        private Dictionary<Window, InternalDragAndDropEventHandler> targetWindowEventDictionary = new Dictionary<Window, InternalDragAndDropEventHandler>();
        private View mShadowView;
        private Window mDragWindow;
        private int shadowWidth;
        private int shadowHeight;
        private int dragWindowOffsetX = 0;
        private int dragWindowOffsetY = 0;

        private bool initDrag = false;

        private const int MinDragWindowWidth = 100;
        private const int MinDragWindowHeight = 100;

        private DragAndDrop() : this(Interop.DragAndDrop.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private DragAndDrop(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {

        }

        private void ReleaseDragWindow()
        {
            if (mDragWindow)
            {                        
                if (mShadowView)
                {
                    //Application has Shadow View ownership, so DnD doesn't dispose Shadow View
                    mDragWindow.Remove(mShadowView);
                    mShadowView = null;
                }
            
                mDragWindow.Dispose();
                mDragWindow = null;                      
            }         
        }

        /// <summary>
        /// Gets the singleton instance of DragAndDrop.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public static DragAndDrop Instance { get; } = new DragAndDrop();

        /// <summary>
        /// Starts drag and drop.
        /// </summary>
        /// <param name="sourceView">The soruce view</param>
        /// <param name="shadowView">The shadow view for drag object</param>
        /// <param name="dragData">The data to send</param>
        /// <param name="callback">The source event callback</param>
        /// <since_tizen> 10 </since_tizen>
        public void StartDragAndDrop(View sourceView, View shadowView, DragData dragData, SourceEventHandler callback)
        {            
            if (initDrag)
            {
                 Tizen.Log.Fatal("NUI", "Start Drag And Drop Initializing...");
                 return;
            }
            initDrag = true;

            if (Window.IsSupportedMultiWindow() == false)
            {
                throw new NotSupportedException("This device does not support surfaceless_context. So Window cannot be created.");
            }

            if (null == shadowView)
            {
                throw new ArgumentNullException(nameof(shadowView));
            }

            ReleaseDragWindow();

            shadowWidth = (int)shadowView.Size.Width;
            shadowHeight = (int)shadowView.Size.Height;

            if (shadowView.Size.Width < MinDragWindowWidth)
            {
                shadowWidth = MinDragWindowWidth;
            }

            if (shadowView.Size.Height < MinDragWindowHeight)
            {
                shadowHeight = MinDragWindowHeight;
            }

            mDragWindow = new Window("DragWindow", new Rectangle(dragWindowOffsetX, dragWindowOffsetY, shadowWidth, shadowHeight), true)
            {
                BackgroundColor = Color.Transparent,
            };

            if (mDragWindow)
            {
                //Set Window Orientation Available
                List<Window.WindowOrientation> list = new List<Window.WindowOrientation>();
                list.Add(Window.WindowOrientation.Landscape);
                list.Add(Window.WindowOrientation.LandscapeInverse);
                list.Add(Window.WindowOrientation.NoOrientationPreference);
                list.Add(Window.WindowOrientation.Portrait);
                list.Add(Window.WindowOrientation.PortraitInverse);
                mDragWindow.SetAvailableOrientations(list);

                //Initialize Drag Window Size based on Shadow View Size,
                //Don't set Drag Window Posiiton, Window Server sets Position Internally
                mDragWindow.SetWindowSize(new Size(shadowWidth, shadowHeight));

                //Make Position 0, 0 for Moving into Drag Window
                shadowView.Position = new Position(0, 0);
            
                mShadowView = shadowView;
                mDragWindow.Add(mShadowView);
           
                sourceEventCb = (sourceEventType) =>
                {   
                    if ((DragSourceEventType)sourceEventType != DragSourceEventType.Start)
                    {     
                        Tizen.Log.Fatal("NUI", "DnD Source Event is Called");  
                        ReleaseDragWindow();                
                    }

                    callback((DragSourceEventType)sourceEventType);
                };

                //Show Drag Window before StartDragAndDrop
                mDragWindow.Show();

                if (!Interop.DragAndDrop.StartDragAndDrop(SwigCPtr, View.getCPtr(sourceView), Window.getCPtr(mDragWindow), dragData.MimeType, dragData.Data,
                                                        new global::System.Runtime.InteropServices.HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(sourceEventCb))))
                {
                    throw new InvalidOperationException("Fail to StartDragAndDrop");
                }

            }         
            
            initDrag = false;
        }

        /// <summary>
        /// Adds listener for drop targets
        /// </summary>
        /// <param name="targetView">The target view</param>
        /// <param name="callback">The callback function to get drag event when the drag source enters, moves, leaves and drops on the drop target</param>
        /// <since_tizen> 10 </since_tizen>
        public void AddListener(View targetView, DragAndDropEventHandler callback)
        {
            InternalDragAndDropEventHandler cb = (dragEvent) =>
            {
                DragType type = (DragType)Interop.DragAndDrop.GetAction(dragEvent);
                DragEvent ev = new DragEvent();
                global::System.IntPtr cPtr = Interop.DragAndDrop.GetPosition(dragEvent);
                ev.Position = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, true);

                if (type == DragType.Enter)
                {
                    ev.DragType = type;
                    ev.MimeType = Interop.DragAndDrop.GetMimeType(dragEvent);
                    callback(targetView, ev);
                }
                else if (type == DragType.Leave)
                {
                    ev.DragType = type;
                    callback(targetView, ev);
                }
                else if (type == DragType.Move)
                {
                    ev.DragType = type;
                    ev.MimeType = Interop.DragAndDrop.GetMimeType(dragEvent);
                    callback(targetView, ev);
                }
                else if (type == DragType.Drop)
                {
                    ev.DragType = type;
                    ev.MimeType = Interop.DragAndDrop.GetMimeType(dragEvent);
                    ev.Data = Interop.DragAndDrop.GetData(dragEvent);
                    callback(targetView, ev);
                }
            };

            targetEventDictionary.Add(targetView, cb);

            if (!Interop.DragAndDrop.AddListener(SwigCPtr, View.getCPtr(targetView),
                                                 new global::System.Runtime.InteropServices.HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(cb))))
            {
                 throw new InvalidOperationException("Fail to AddListener for View");
            }
        }

        /// <summary>
        /// Removes listener for drop targets
        /// </summary>
        /// <param name="targetView">The target view</param>
        /// <param name="callback">The callback function to remove</param>
        /// <since_tizen> 10 </since_tizen>
        public void RemoveListener(View targetView, DragAndDropEventHandler callback)
        {
            if (!targetEventDictionary.ContainsKey(targetView))
            {
                 throw new InvalidOperationException("Fail to RemoveListener for View");
            }

            InternalDragAndDropEventHandler cb = targetEventDictionary[targetView];
            targetEventDictionary.Remove(targetView);
            if (!Interop.DragAndDrop.RemoveListener(SwigCPtr, View.getCPtr(targetView),
                                                    new global::System.Runtime.InteropServices.HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(cb))))
            {
                 throw new InvalidOperationException("Fail to RemoveListener for View");
            }
        }

        /// <summary>
        /// Adds listener for drop targets
        /// </summary>
        /// <param name="targetWindow">The target Window</param>
        /// <param name="callback">The callback function to get drag event when the drag source enters, moves, leaves and drops on the drop target</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddListener(Window targetWindow, DragAndDropWindowEventHandler callback)
        {
            InternalDragAndDropEventHandler cb = (dragEvent) =>
            {
                DragType type = (DragType)Interop.DragAndDrop.GetAction(dragEvent);
                DragEvent ev = new DragEvent();
                global::System.IntPtr cPtr = Interop.DragAndDrop.GetPosition(dragEvent);
                ev.Position = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);

                if (type == DragType.Enter)
                {
                    ev.DragType = type;
                    callback(targetWindow, ev);
                }
                else if (type == DragType.Leave)
                {
                    ev.DragType = type;
                    callback(targetWindow, ev);
                }
                else if (type == DragType.Move)
                {
                    ev.DragType = type;
                    callback(targetWindow, ev);
                }
                else if (type == DragType.Drop)
                {
                    ev.DragType = type;
                    ev.MimeType = Interop.DragAndDrop.GetMimeType(dragEvent);
                    ev.Data = Interop.DragAndDrop.GetData(dragEvent);
                    callback(targetWindow, ev);
                }
            };

            targetWindowEventDictionary.Add(targetWindow, cb);

            if (!Interop.DragAndDrop.WindowAddListener(SwigCPtr, Window.getCPtr(targetWindow),
                                                       new global::System.Runtime.InteropServices.HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(cb))))
            {
                 throw new InvalidOperationException("Fail to AddListener for Window");
            }
        }

        /// <summary>
        /// Removes listener for drop targets
        /// </summary>
        /// <param name="targetWindow">The target window</param>
        /// <param name="callback">The callback function to remove</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveListener(Window targetWindow, DragAndDropWindowEventHandler callback)
        {
            if (!targetWindowEventDictionary.ContainsKey(targetWindow))
            {
                 throw new InvalidOperationException("Fail to RemoveListener for Window");
            }

            InternalDragAndDropEventHandler cb = targetWindowEventDictionary[targetWindow];
            targetWindowEventDictionary.Remove(targetWindow);
            if (!Interop.DragAndDrop.WindowRemoveListener(SwigCPtr, Window.getCPtr(targetWindow),
                                                          new global::System.Runtime.InteropServices.HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(cb))))
            {
                 throw new InvalidOperationException("Fail to RemoveListener for Window");
            }
        }

        /// <summary>
        /// Sets drag window offset
        /// </summary>
        /// <param name="x">The x direction offset</param>
        /// <param name="y">The y direction offset</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDragWindowOffset(int x, int y)
        {
            dragWindowOffsetX = x;
            dragWindowOffsetY = y;
        }
    }
}
