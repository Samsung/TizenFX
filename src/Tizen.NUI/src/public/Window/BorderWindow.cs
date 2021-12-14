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

using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public partial class Window
    {
        #region Constant Fields
        #endregion //Constant Fields

        #region Fields
        //ToDo: need to be removed, should be implemented properly
        internal TextLabel borderText;

        private Layer borderWindowRootLayer = null;
        private Layer borderWindowBottomLayer = null;
        private bool isBorderWindow = false;
        //ToDo: need to set default value, 50 is just for test
        private int bottomLayerSize = 50;
        //ToDo: remove this later, this is just for test
        private int testCnt = 0;
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsBorderEnabled => isBorderWindow;
        #endregion //Properties

        #region Indexers
        #endregion //Indexers

        #region Methods
        internal void EnableBorderWindowRootLayer(Size2D winSize, Position2D winPosition)
        {
            GetDefaultLayer().Name = "OriginalRootLayer";

            // this is very critical for the code order. this should be placed after GetDefaultLayer()!
            isBorderWindow = true;

            this.WindowSize = winSize;
            this.WindowPosition = winPosition;

            GetBorderWindowRootLayer();

            GetBorderWindowBottomLayer();

            TestAddBorder();

            Resized += OnBorderWindowResized;
        }

        internal void OnBorderWindowResized(object sender, Window.ResizedEventArgs e)
        {
            Interop.ActorInternal.SetSize(GetBorderWindowRootLayer().SwigCPtr, WindowSize.Width, WindowSize.Height);
            Interop.ActorInternal.SetSize(GetBorderWindowBottomLayer().SwigCPtr, WindowSize.Width, bottomLayerSize);

            if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }

            //ToDo: need to be modified, this is just for test
            if (borderText != null)
            {
                testCnt++;
                borderText.Text = $"test BorderWindow! click to enlarge win! cnt={testCnt}";
            }
        }

        internal Layer GetBorderWindowBottomLayer()
        {
            if (borderWindowBottomLayer == null)
            {
                borderWindowBottomLayer = new Layer();
                borderWindowBottomLayer.Name = "BorderWindowBottomLayer";
                Interop.ActorInternal.SetParentOrigin(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.ParentOrigin.BottomCenter.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowBottomLayer.SwigCPtr, Tizen.NUI.PivotPoint.BottomCenter.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowBottomLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowBottomLayer.SwigCPtr, WindowSize.Width, bottomLayerSize);
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
                Interop.ActorInternal.SetParentOrigin(borderWindowRootLayer.SwigCPtr, Tizen.NUI.ParentOrigin.TopLeft.SwigCPtr);
                Interop.Actor.SetAnchorPoint(borderWindowRootLayer.SwigCPtr, Tizen.NUI.PivotPoint.TopLeft.SwigCPtr);
                Interop.Actor.Add(rootLayer.SwigCPtr, borderWindowRootLayer.SwigCPtr);
                Interop.ActorInternal.SetSize(borderWindowRootLayer.SwigCPtr, WindowSize.Width, WindowSize.Height);
                if (NDalicPINVOKE.SWIGPendingException.Pending) { throw NDalicPINVOKE.SWIGPendingException.Retrieve(); }
            }

            return borderWindowRootLayer;
        }

        //ToDo: need to be removed, should be implemented properly
        internal void TestAddBorder()
        {
            borderText = new TextLabel()
            {
                Text = "test BorderWindow! click to enlarge win!",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = new Color(1, 0, 0, 0.5f),
                PointSize = 15,
            };
            GetBorderWindowBottomLayer().Add(borderText);
            borderText.TouchEvent += onBorderTextTouched;
        }

        //ToDo: need to be removed, should be implemented properly
        private bool onBorderTextTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                this.WindowSize += new Size2D(10, 10);
            }
            return true;
        }

        private void convertBorderWindowSizeToRealWindowSize(Uint16Pair size)
        {
            if (isBorderWindow)
            {
                var height = (ushort)(size.GetHeight() + bottomLayerSize);
                size.SetHeight(height);
            }
        }

        private void convertRealWindowSizeToBorderWindowSize(Uint16Pair size)
        {
            if (isBorderWindow)
            {
                var height = (ushort)(size.GetHeight() - bottomLayerSize);
                size.SetHeight(height);
            }
        }
        #endregion //Methods

        #region Structs
        #endregion //Structs

        #region Classes
        #endregion //Classes
    }
}
