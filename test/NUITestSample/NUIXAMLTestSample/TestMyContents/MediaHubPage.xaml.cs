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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Examples
{
    public partial class MediaHubPage : ContentPage
    {
        private Vector2 bezierPointIn1 = new Vector2(0.21f, 2);
        private Vector2 bezierPointIn2 = new Vector2(0.14f, 1);
        private Vector2 bezierPointOut1 = new Vector2(0.19f, 1);
        private Vector2 bezierPointOut2 = new Vector2(0.22f, 1);
        private Animation scaleInAni = null;
        private Animation scaleOutAni = null;
        private TableView contentTable = null;
        private TableView optionList = null;

        public MediaHubPage(Window win) : base (win)
        {
            InitializeComponent();
            Root.BackgroundImage = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/mc_bg.png";
            ClearEvent += OnClearEvent;
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
            ClearEvent -= OnClearEvent;

            base.Dispose(type);
        }

        public override void SetFocus()
        {
        }

        private void OnClearEvent(object obj, EventArgs e)
        {
            Root.BackgroundImage = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/mc_bg.png";
        }

        private View OnPreFocusChange(object obj, FocusManager.PreFocusChangeEventArgs e)
        {
            if (e.CurrentView != null && !e.ProposedView)
            {
                if (e.Direction == View.FocusDirection.Down)
                {
                    e.ProposedView = optionList;//.GetChildAt(0);
                }
                if (e.Direction == View.FocusDirection.Up)
                {
                    e.ProposedView = contentTable;//.GetChildAt(0);
                }
                Tizen.Log.Fatal("NUISamples", "proposed view is null ");
                // Console.WriteLine("==================  Proposed view null");
            }
            if (!e.ProposedView && !e.CurrentView)
            {
                e.ProposedView = contentTable;//.GetChildAt(0);
            }
            return e.ProposedView;
        }

        private bool OnClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;
                button.Text = "Click Me";
            }
            return true;
        }

        private void OnFocusGained(object obj, EventArgs e)
        {
            View view = obj as View;
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
            View view = obj as View;
            if (scaleOutAni == null)
            {
                scaleOutAni = new Animation();
            }
            scaleOutAni.Clear();
            scaleOutAni.EndAction = Animation.EndActions.StopFinal;
            scaleOutAni.AnimateTo(view, "Scale", new Vector3(1.0f, 1.0f, 0), 0, 850, new AlphaFunction(bezierPointOut1, bezierPointOut2));
            scaleOutAni.Play();
        }

        private void OnOptionsFocusGained(object obj, EventArgs e)
        {
            ImageView view = obj as ImageView;
            view.ResourceUrl = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/r_highlight_bg_focus_9patch.png";
            view.Border = new Rectangle(14,14,20,20);
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

        private void OnOptionsFocusLost(object obj, EventArgs e)
        {
            ImageView view = obj as ImageView;
            view.ResourceUrl = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/c_basic_button_white_bg_normal.9.png";
            view.Border = new Rectangle(4,4,5,5);
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