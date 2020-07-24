/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public partial class SearchPage : ContentPage
    {
        private Vector2 bezierPointIn1 = new Vector2(0.21f, 2);
        private Vector2 bezierPointIn2 = new Vector2(0.14f, 1);
        private Vector2 bezierPointOut1 = new Vector2(0.19f, 1);
        private Vector2 bezierPointOut2 = new Vector2(0.22f, 1);
        private Animation scaleInAni = null;
        private Animation scaleOutAni = null;
        private TableView upperListTable = null;
        private TableView midListTable = null;
        private TableView bottomListTable = null;

        public SearchPage(Window win) : base (win)
        {
            InitializeComponent();
            Root.BackgroundImage = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/store_default_bg_01.png";
        }

        /// <summary>
        /// To make the ContentPage instance be disposed.
        /// </summary>
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
            scaleInAni?.Dispose();
            scaleInAni = null;
            scaleOutAni?.Dispose();
            scaleOutAni = null;
            FocusManager.Instance.PreFocusChange -= OnPreFocusChange;

            base.Dispose(type);
        }

        public override void SetFocus()
        {
            upperListTable = Root.FindChildByName("UpperListTable") as TableView;
            midListTable = Root.FindChildByName("MidListTable") as TableView;
            bottomListTable = Root.FindChildByName("BottomListTable") as TableView;
 
            FocusManager.Instance.FocusIndicator = new View();
            FocusManager.Instance.SetCurrentFocusView(upperListTable.GetChildAt(0));
            FocusManager.Instance.PreFocusChange += OnPreFocusChange;
        }

        private View OnPreFocusChange(object obj, FocusManager.PreFocusChangeEventArgs e)
        {
            if (e.CurrentView != null && !e.ProposedView)
            {
                if (e.Direction == View.FocusDirection.Down)
                {
                    View view = e.CurrentView.GetParent() as View;
                    if (view.Name == "UpperListTable")
                    {
                        e.ProposedView = midListTable.GetChildAt(new TableView.CellPosition(0, 0)); ;
                    }
                    else if (view.Name == "MidListTable")
                    {
                        e.ProposedView = bottomListTable.GetChildAt(new TableView.CellPosition(0, 0)); ;
                    }
                }
                else if (e.Direction == View.FocusDirection.Up)
                {
                    View view = e.CurrentView.GetParent() as View;
                    if (view.Name == "BottomListTable")
                    {
                        e.ProposedView = midListTable.GetChildAt(new TableView.CellPosition(0, 0)); ;
                    }
                    else if (view.Name == "MidListTable")
                    {
                        e.ProposedView = upperListTable.GetChildAt(new TableView.CellPosition(0, 0)); ;
                    }
                }
            }
            if (!e.ProposedView && !e.CurrentView)
            {
                e.ProposedView = upperListTable.GetChildAt(new TableView.CellPosition(0, 0)); ;
            }
            return e.ProposedView;
        }

        private void OnFocusGained(object obj, EventArgs e)
        {
            ImageView view = obj as ImageView;

            view.RaiseToTop();
             if (scaleInAni == null)
            {
                scaleInAni = new Animation();
            }
            scaleInAni.Clear();
            scaleInAni.EndAction = Animation.EndActions.StopFinal;
            scaleInAni.AnimateTo(view, "Scale", new Vector3(1.2f, 1.2f, 0), 0, 1100, new AlphaFunction(bezierPointIn1, bezierPointIn2));
            scaleInAni.Play();
        }

        private void OnFocusLost(object obj, EventArgs e)
        {
            ImageView view = obj as ImageView;

            if (scaleOutAni == null)
            {
                scaleOutAni = new Animation();
            }
            scaleOutAni.Clear();
            scaleOutAni.EndAction = Animation.EndActions.StopFinal;
            scaleOutAni.AnimateTo(view, "Scale", new Vector3(1.0f, 1.0f, 0), 0, 850, new AlphaFunction(bezierPointOut1, bezierPointOut2));
            scaleOutAni.Play();
        }
    }
}