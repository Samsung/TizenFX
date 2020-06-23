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
using Tizen.NUI.Components;

namespace Tizen.NUI.Examples
{
    public partial class AppDetailPage : ContentPage
    {
        private Vector2 bezierPointIn1 = new Vector2(0.21f, 2);
        private Vector2 bezierPointIn2 = new Vector2(0.14f, 1);
        private Vector2 bezierPointOut1 = new Vector2(0.19f, 1);
        private Vector2 bezierPointOut2 = new Vector2(0.22f, 1);
        private Animation scaleInAni = null;
        private Animation scaleOutAni = null;
        private Animation selectedAni = null;
        private TableView listTable = null;
        private ImageView detailButton = null;

        public AppDetailPage(Window win) : base (win)
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
            detailButton.KeyEvent -= OnKeyEvent;

            base.Dispose(type);
        }

        public override void SetFocus()
        {
            detailButton = Content.FindChildByName("DetailButton") as ImageView;
            listTable = Content.FindChildByName("ListTable") as TableView;
 
            FocusManager.Instance.FocusIndicator = new View();
            FocusManager.Instance.SetCurrentFocusView(detailButton);
            FocusManager.Instance.PreFocusChange += OnPreFocusChange;
            detailButton.KeyEvent += OnKeyEvent;
        }

        private View OnPreFocusChange(object obj, FocusManager.PreFocusChangeEventArgs e)
        {
            if (e.CurrentView != null && !e.ProposedView)
            {
                if (e.Direction == View.FocusDirection.Down)
                {
                    e.ProposedView = listTable;
                }
                if (e.Direction == View.FocusDirection.Up)
                {
                    e.ProposedView = detailButton;
                }
            }
            if (!e.ProposedView && !e.CurrentView)
            {
                e.ProposedView = detailButton;
            }
            return e.ProposedView;
        }

        private bool OnKeyEvent(object obj, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                //Tizen.Log.Fatal("NUISamples", "key name: " + e.Key.KeyPressedName);
                if (e.Key.KeyPressedName == "Return")
                {
                    if (selectedAni == null)
                    {
                        selectedAni = new Animation(417)
                        {
                            DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1))
                        };
                    }
                    selectedAni.Clear();
                    selectedAni.AnimateTo(detailButton, "Opacity", 0.8f, 0, 167);
                    selectedAni.AnimateTo(detailButton, "Scale", new Vector3(1.0f, 1.0f, 1.0f), 0, 167);
                    selectedAni.AnimateTo(detailButton, "Opacity", 1.0f, 167, 417);
                    selectedAni.AnimateTo(detailButton, "Scale", new Vector3(1.08f, 1.08f, 1.08f), 167, 417);
                    selectedAni.Play();

                    TextLabel buttonLabel = Content.FindChildByName("ButtonLabel") as TextLabel;
                    if (buttonLabel.Text == "Install")
                    {
                        buttonLabel.Text = "Open";
                    }
                    else if (buttonLabel.Text == "Open")
                    {
                        buttonLabel.Text = "Install";
                    }
                    
                    return true;
                }
            }
            return false;
        }

        private bool OnClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;
                button.Text = "Open";
            }
            return true;
        }

        private void OnFocusGained(object obj, EventArgs e)
        {
            ImageView view = obj as ImageView;
            if (view.Name == "DetailButton")
            {
                view.ResourceUrl = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/r_highlight_bg_focus_9patch.png";
                view.Border = new Rectangle(14,14,20,20);
            }
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
            if (view.Name == "DetailButton")
            {
                view.ResourceUrl = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/c_basic_button_white_bg_normal.9.png";
                view.Border = new Rectangle(4,4,5,5);
            }
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