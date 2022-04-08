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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public partial class Window
    {
        #region Constant Fields
        #endregion //Constant Fields

        #region Fields
        private BorderInterface borderInterface = null;
        private Layer borderWindowRootLayer = null;
        private Layer borderWindowBottomLayer = null;
        private bool isBorderWindow = false;

        // for border area
        private View rootView = null;

        // for window area
        private float preScale = 1;
        private ResizeDirection direction = ResizeDirection.None;
        #endregion //Fields

        #region Constructors
        #endregion //Constructors

        #region Distructors
        #endregion //Distructors

        #region Delegates
        #endregion //Delegates

        #region Events
        #endregion //Events

        #region Enums
        #endregion //Enums

        #region Interfaces
        #endregion //Interfaces

        #region Properties
        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsBorderEnabled => isBorderWindow;
        #endregion //Properties

        #region Indexers
        #endregion //Indexers

        #region Methods


        /// <summary>
        /// Enable the border window with BorderInterface.
        /// This adds a border area to the Window.
        /// The border's UI is configured using BorderInterface.
        /// Users can reisze and move by touching the border area.
        /// </summary>
        /// <param name="borderInterface">The BorderInterface.</param>
        /// <returns>Whether the border window is enabled</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableBorderWindow(BorderInterface borderInterface = null)
        {
            if (isBorderWindow == true)
            {
                Tizen.Log.Error("NUI", $"Already EnableBorderWindow\n");
                return false;
            }

            if (borderInterface == null)
            {
                borderInterface = new BorderWindow();
            }

            GetDefaultLayer().Name = "OriginalRootLayer";

            Resized += OnBorderWindowResized;
            this.borderInterface = borderInterface;
            borderInterface.SetWindow(this);

            isBorderWindow = true;

            // The current window is as below
            //    *****
            //    *****
            // Increase the window size as much as the border area.
            ///  #######
            ///  #*****#
            ///  #*****#
            ///  #$$$$$#
            ///  #$$$$$#
            /// '#' is BorderLineThickness
            /// '$' is BorderHeight
            WindowSize += new Size2D((int)borderInterface.GetBorderLineThickness() * 2, (int)(borderInterface.GetBorderHeight() + borderInterface.GetBorderLineThickness()));

            if (CreateBorder() == false)
            {
                WindowSize -= new Size2D((int)borderInterface.GetBorderLineThickness() * 2, (int)(borderInterface.GetBorderHeight() + borderInterface.GetBorderLineThickness()));
                Resized -= OnBorderWindowResized;
                isBorderWindow = false;
                this.borderInterface = null;
                return false;
            }


            SetTransparency(true);
            BackgroundColor = Color.Transparent;

            EnableFloatingMode(true);

            borderInterface.OnCreated(rootView);

            return true;
        }

        /// Create the border UI.
        private bool CreateBorder()
        {
            rootView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            // Gets the Border's UI.
            borderInterface.CreateBorderView(rootView);
            if (rootView == null)
            {
                return false;
            }
            else
            {
                // Add a view to the border layer.
                GetBorderWindowBottomLayer().Add(rootView);

                return true;
            }
        }

        public ResizeDirection GetDirection(PanGesture panGesture)
        {
            float xPosition = panGesture.Position.X;
            float yPosition = panGesture.Position.Y;
            direction = ResizeDirection.None;


            // check bottom left corner
            if (xPosition < borderInterface.GetTouchThickness() && yPosition > WindowSize.Height + borderInterface.GetBorderHeight() - borderInterface.GetTouchThickness())
            {
                direction = ResizeDirection.BottomLeft;
            }
            // check bottom right corner
            else if (xPosition > WindowSize.Width + borderInterface.GetBorderLineThickness()*2 - borderInterface.GetTouchThickness() && yPosition > WindowSize.Height + borderInterface.GetBorderHeight() - borderInterface.GetTouchThickness())
            {
                direction = ResizeDirection.BottomRight;
            }
            // check top left corner
            else if (xPosition < borderInterface.GetTouchThickness() && yPosition <  borderInterface.GetTouchThickness())
            {
                direction = ResizeDirection.TopLeft;
            }
            // check top right corner
            else if (xPosition > WindowSize.Width + borderInterface.GetBorderLineThickness()*2 - borderInterface.GetTouchThickness() && yPosition < borderInterface.GetTouchThickness())
            {
                direction = ResizeDirection.TopRight;
            }
            // check left side
            else if (xPosition < borderInterface.GetTouchThickness())
            {
                direction = ResizeDirection.Left;
            }
            // check right side
            else if (xPosition > WindowSize.Width + borderInterface.GetBorderLineThickness()*2 - borderInterface.GetTouchThickness())
            {
                direction = ResizeDirection.Right;
            }
            // check bottom side
            else if (yPosition > WindowSize.Height + borderInterface.GetBorderHeight() + borderInterface.GetBorderLineThickness() - borderInterface.GetTouchThickness())
            {
                direction = ResizeDirection.Bottom;
            }
            // check top side
            else if (yPosition < borderInterface.GetTouchThickness())
            {
                direction = ResizeDirection.Top;
            }
            // check move
            else if (yPosition > WindowSize.Height)
            {
                direction = ResizeDirection.Move;
            }

            return direction;
        }


        // Called when the window size has changed.
        private void OnBorderWindowResized(object sender, Window.ResizedEventArgs e)
        {
            Tizen.Log.Error("gab_test", $"OnBorderWindowResized {e.WindowSize.Width},{e.WindowSize.Height}\n");
            int resizeWidth = e.WindowSize.Width;
            int resizeHeight = e.WindowSize.Height;
            if (borderInterface != null)
            {
                if (borderInterface.GetMinSize() != null)
                {
                    resizeWidth = borderInterface.GetMinSize().Width > resizeWidth ? (int)borderInterface.GetMinSize().Width : resizeWidth;
                    resizeHeight = borderInterface.GetMinSize().Height > resizeHeight ? (int)borderInterface.GetMinSize().Height : resizeHeight;
                }

                if (borderInterface.GetMaxSize() != null)
                {
                    resizeWidth = borderInterface.GetMaxSize().Width < resizeWidth ? (int)borderInterface.GetMaxSize().Width : resizeWidth;
                    resizeHeight = borderInterface.GetMaxSize().Height < resizeHeight ? (int)borderInterface.GetMaxSize().Height : resizeHeight;
                }
            }

            if (resizeWidth != e.WindowSize.Width || resizeHeight != e.WindowSize.Height)
            {
                WindowSize = new Size2D(resizeWidth, resizeHeight);
            }
            Interop.ActorInternal.SetSize(GetBorderWindowRootLayer().SwigCPtr, resizeWidth, resizeHeight);
            Interop.ActorInternal.SetSize(GetBorderWindowBottomLayer().SwigCPtr, resizeWidth+borderInterface.GetBorderLineThickness()*2, resizeHeight+borderInterface.GetBorderHeight()+borderInterface.GetBorderLineThickness());

            if (borderInterface != null)
            {
                borderInterface.OnResized(resizeWidth, resizeHeight);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
        }

        internal Layer GetBorderWindowBottomLayer()
        {
            if (borderWindowBottomLayer == null)
            {
                borderWindowBottomLayer = new Layer();
                borderWindowBottomLayer.Name = "BorderWindowBottomLayer";
                Interop.ActorInternal.SetParentOrigin(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.ParentOrigin.TopCenter.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.PivotPoint.TopCenter.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowBottomLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowBottomLayer.SwigCPtr, WindowSize.Width+borderInterface.GetBorderLineThickness()*2, WindowSize.Height+borderInterface.GetBorderLineThickness());
                borderWindowBottomLayer.SetWindow(this);
                borderWindowBottomLayer.LowerToBottom();

                if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
            }
            return borderWindowBottomLayer;
        }

        internal Layer GetBorderWindowRootLayer()
        {
            if (borderWindowRootLayer == null)
            {
                borderWindowRootLayer = new Layer();
                borderWindowRootLayer.Name = "RootLayer";
                Interop.ActorInternal.SetParentOrigin(borderWindowRootLayer.SwigCPtr, Tizen.NUI.ParentOrigin.TopCenter.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowRootLayer.SwigCPtr, Tizen.NUI.PivotPoint.TopCenter.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowRootLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowRootLayer.SwigCPtr, WindowSize.Width, WindowSize.Height-borderInterface.GetBorderHeight()-borderInterface.GetBorderLineThickness());
                Interop.ActorInternal.SetPosition(borderWindowRootLayer.SwigCPtr, 0, borderInterface.GetBorderLineThickness());

                if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
            }

            return borderWindowRootLayer;
        }

        internal void DisposeBorder()
        {
            borderInterface.Dispose();
            Resized -= OnBorderWindowResized;
            GetBorderWindowBottomLayer().Dispose();
        }

        private void convertBorderWindowSizeToRealWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true)
            {
                var height = (ushort)(size.GetHeight() + borderInterface.GetBorderHeight()+borderInterface.GetBorderLineThickness());
                var width = (ushort)(size.GetWidth() + borderInterface.GetBorderLineThickness()*2);
                size.SetHeight(height);
                size.SetWidth(width);
            }
        }

        private void convertRealWindowSizeToBorderWindowSize(Uint16Pair size)
        {
            if (isBorderWindow == true)
            {
                var height = (ushort)(size.GetHeight() - borderInterface.GetBorderHeight()-borderInterface.GetBorderLineThickness());
                var width = (ushort)(size.GetWidth() - borderInterface.GetBorderLineThickness()*2);
                size.SetHeight(height);
                size.SetWidth(width);
            }
        }
        #endregion //Methods

        #region Structs
        #endregion //Structs

        #region Classes
        internal class BorderWindow : DefaultBorder
        {
        }
        #endregion //Classes
    }



}
