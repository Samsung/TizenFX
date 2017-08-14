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

namespace MyCSharpExample
{
    class Example : NUIApplication
    {
        const int num = 2;
        View[] view;

        View lastFocusedView;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            view = new View[2];

            for (int i = 0; i < num; i++)
            {
                view[i] = new View();
                view[i].Size2D = new Size2D(200, 200);
                view[i].BackgroundColor = Color.Blue;
                view[i].Position = new Position(300 + i * 300, 300, 0);
                view[i].Name = "MyView" + i;
                view[i].Focusable = true;
                Window.Instance.Add(view[i]);
                view[i].FocusGained += FocusNavigationSample_FocusGained;
                view[i].FocusLost += FocusNavigationSample_FocusLost;
                view[i].KeyEvent += FocusNavigationSample_KeyEvent;
            }

            view[0].RightFocusableView = view[1];
            view[0].LeftFocusableView = view[1];
            view[1].RightFocusableView = view[0];
            view[1].LeftFocusableView = view[0];

            FocusManager.Instance.SetCurrentFocusView(view[0]);
            FocusManager.Instance.PreFocusChange += Instance_PreFocusChange;

            Window.Instance.TouchEvent += Instance_Touch;
        }

        private void Instance_Touch(object sender, Window.TouchEventArgs e)
        {
            Tizen.Log.Debug("NUI", "window touched! set key focus as view[0]!");
            FocusManager.Instance.SetCurrentFocusView(view[0]);
        }

        private bool FocusNavigationSample_KeyEvent(object source, View.KeyEventArgs e)
        {
            Tizen.Log.Debug("NUI", "...");
            View view = source as View;

            Tizen.Log.Debug("NUI", "NUI-1 " + "View-" + view.Name + ", Pressed-" + e.Key.KeyPressedName + e.Key.State.ToString());

            return false;
        }

        private void FocusNavigationSample_FocusLost(object sender, EventArgs e)
        {
            Tizen.Log.Debug("NUI", "...");
            View view = sender as View;
            view.BackgroundColor = Color.Blue;
            view.Scale = new Vector3(1.0f, 1.0f, 1.0f);

            Tizen.Log.Debug("NUI", "NUI-2 " + "FocusLost-" + view.Name);
        }

        private void FocusNavigationSample_FocusGained(object sender, EventArgs e)
        {
            Tizen.Log.Debug("NUI", "...");
            View view = sender as View;
            view.BackgroundColor = Color.Red;
            view.Scale = new Vector3(1.2f, 1.2f, 1.0f);

            Tizen.Log.Debug("NUI", "NUI-3 " + "FocusGained-" + view.Name);
        }

        private View Instance_PreFocusChange(object source, FocusManager.PreFocusChangeEventArgs e)
        {
            Tizen.Log.Debug("NUI", "...");
            View currentView = (e.CurrentView) ?? lastFocusedView;
            View nextView = null;

            Tizen.Log.Debug("NUI", "NUI-4 " + "PreFocusChange-" + e.Direction);

            if (currentView != null && currentView.HasBody())
                Tizen.Log.Debug("NUI", "NUI-5 " + " Current-" + currentView.Name);

            if (currentView)
            {
                switch (e.Direction)
                {
                    case View.FocusDirection.Left:
                        nextView = currentView.LeftFocusableView;
                        if (nextView == null)
                            Tizen.Log.Debug("NUI", "NUI-6 " + "LeftFocusableView is NULL!!!!");
                        else
                            Tizen.Log.Debug("NUI", "NUI-7 " + currentView.Name + ".LeftFocusableView =" + nextView.Name);
                        break;
                    case View.FocusDirection.Right:
                        nextView = currentView.RightFocusableView;
                        if (nextView == null)
                            Tizen.Log.Debug("NUI", "NUI-8 " + "RightFocusableView is NULL!!!!");
                        else
                            Tizen.Log.Debug("NUI", "NUI-9 " + currentView.Name + ".RightFocusableView =" + nextView.Name);
                        break;
                    case View.FocusDirection.Up:
                        nextView = currentView.UpFocusableView;
                        if (nextView == null)
                            Tizen.Log.Debug("NUI", "NUI-10 " + "UpFocusableView is NULL!!!!");
                        else
                            Tizen.Log.Debug("NUI", "NUI-11 " + currentView.Name + ".UpFocusableView =" + nextView.Name);
                        break;
                    case View.FocusDirection.Down:
                        nextView = currentView.DownFocusableView;
                        if (nextView == null)
                            Tizen.Log.Debug("NUI", "NUI-12 " + "DownFocusableView is NULL!!!!");
                        else
                            Tizen.Log.Debug("NUI", "NUI-13 " + currentView.Name + ".DownFocusableView =" + nextView.Name);
                        break;
                    default:
                        nextView = null;  //added
                        break;
                }
            }

            if (e.ProposedView == null)
            {
                Tizen.Log.Debug("NUI", "NUI-14 " + "ProposedView in NULL!!");
            }
            else if (e.ProposedView.HasBody())
            {
                Tizen.Log.Debug("NUI", "NUI-15 " + "ProposedView-" + e.ProposedView.Name);
            }
            else
            {
                Tizen.Log.Debug("NUI", "NUI-16 " + "ProposedView does NOT have body!!!" + e.ProposedView);
            }

            nextView = nextView ?? (e.ProposedView) ?? currentView;
            lastFocusedView = nextView;

            if (nextView != null && nextView.HasBody())
                Tizen.Log.Debug("NUI", "NUI-17 " + "Next-" + nextView.Name);

            return nextView;
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}