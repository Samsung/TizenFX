/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
    /// DragAndDrop controls the drag objet and data.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000: Dispose objects before losing scope", Justification = "It does not have ownership.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DragAndDrop : BaseHandle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SourceEventHandler(SourceEventType sourceEventType);
        private delegate void InternalSourceEventHandler(int sourceEventType);
        public delegate void DragAndDropEventHandler(View targetView, DragEvent dragEvent);
        private delegate void InternalDragAndDropEventHandler(global::System.IntPtr dragEvent);
        private InternalSourceEventHandler sourceEventCb;
        private Dictionary<View, InternalDragAndDropEventHandler> targetEventDictionary = new Dictionary<View, InternalDragAndDropEventHandler>();
        private Window mDragWindow;
        private const int shadowWidth = 150;
        private const int shadowHeight = 150;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private DragAndDrop() : this(Interop.DragAndDrop.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private DragAndDrop(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DragAndDrop Instance { get; } = new DragAndDrop();

        /// <summary>
        /// Starts drag and drop.
        /// </summary>
        /// <param name="sourceView">The soruce view</param>
        /// <param name="shadowView">The shadow view for drag object</param>
        /// <param name="dragData">The data to send</param>
        /// <param name="callback">The source event callback</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartDragAndDrop(View sourceView, View shadowView, DragData dragData, SourceEventHandler callback)
        {
            if (null == shadowView)
            {
                throw new ArgumentNullException(nameof(shadowView));
            }

            if (mDragWindow)
            {
                mDragWindow.Hide();
                mDragWindow.Dispose();
                mDragWindow = null;
            }

            //FIXME: Drag window cannot be reused because the current window server does not allow reuse.
            //       When window server allows the drag window to be reused, makes the mDragWindow created once.
            mDragWindow = new Window("DragWindow", new Rectangle(-shadowWidth, -shadowHeight, shadowWidth, shadowHeight), true)
            {
              BackgroundColor = Color.Transparent,
            };

            if (mDragWindow)
            {
                shadowView.SetSize(shadowWidth, shadowHeight);
                shadowView.SetOpacity(0.9f);

                mDragWindow.Add(shadowView);
                mDragWindow.Show();

                sourceEventCb = (sourceEventType) =>
                {
                    callback((SourceEventType)sourceEventType);
                };

                if (!Interop.DragAndDrop.StartDragAndDrop(SwigCPtr, View.getCPtr(sourceView), Window.getCPtr(mDragWindow), dragData.MimeType, dragData.Data,
                                                        new global::System.Runtime.InteropServices.HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(sourceEventCb))))
                {
                    throw new InvalidOperationException("Fail to StartDragAndDrop");
                }
            }
        }

        /// <summary>
        /// Adds listener for drop targets
        /// </summary>
        /// <param name="targetView">The target view</param>
        /// <param name="callback">The callback function to get drag event</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddListener(View targetView, DragAndDropEventHandler callback)
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
                 throw new InvalidOperationException("Fail to AddListener");
            }
        }

        /// <summary>
        /// Removes listener for drop targets
        /// </summary>
        /// <param name="targetView">The target view</param>
        /// <param name="callback">The callback function to remove</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveListener(View targetView, DragAndDropEventHandler callback)
        {
            if (!targetEventDictionary.ContainsKey(targetView))
            {
                 throw new InvalidOperationException("Fail to RemoveListener");
            }

            InternalDragAndDropEventHandler cb = targetEventDictionary[targetView];
            targetEventDictionary.Remove(targetView);
            if (!Interop.DragAndDrop.RemoveListener(SwigCPtr, View.getCPtr(targetView),
                                                    new global::System.Runtime.InteropServices.HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(cb))))
            {
                 throw new InvalidOperationException("Fail to RemoveListener");
            }
        }
    }
}
