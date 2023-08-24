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

using global::System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class MultiWindowDisposeTest : IExample
    {
        private Window mainWindow = null;
        private const int maxSubWinNum = 3;
        private const int maxNumViewNLayer = 3;
        private const int maxWinSize = 600;
        private const int minWinSize = 300;
        private List<Window> subWinList = new List<Window>();

        private Random rand = new Random();
        private Timer timer = new Timer(9000);
        private int toggle;

        public void Activate()
        {

            Tizen.Log.Debug("NUITEST", "Activate()!");
            mainWindow = NUIApplication.GetDefaultWindow();
            mainWindow.BackgroundColor = Color.White;

            addSeveralLayersAndViews(mainWindow);

            timer.Tick += (s, e) =>
            {
                if (++toggle % 2 == 1)
                {
                    createSubWindows();
                }
                else
                {
                    disposeSubWindows();
                }
                return true;
            };
            timer.Start();
        }

        private void createSubWindows()
        {
            for (int i = 0; i < maxSubWinNum; i++)
            {
                var win = new Window();
                win.WindowSize = new Size2D(rand.Next(minWinSize, maxWinSize), rand.Next(minWinSize, maxWinSize));
                win.WindowPosition = new Position2D(rand.Next(0, minWinSize * 2), rand.Next(0, minWinSize * 2));
                win.BackgroundColor = new Color((float)rand.Next(100, 255) / 255.0f, (float)rand.Next(100, 255) / 255.0f, (float)rand.Next(100, 255) / 255.0f, 0.6f);
                win.SetOpaqueState(false);
                addSeveralLayersAndViews(win);
                subWinList.Add(win);
            }
        }

        private void disposeSubWindows()
        {
            foreach (var win in subWinList)
            {
                if (win)
                {
                    win.Dispose();
                }
            }
            subWinList.Clear();
        }

        private void addSeveralLayersAndViews(Window win)
        {
            for (int i = 0; i < maxNumViewNLayer; i++)
            {

                var root = new View()
                {
                    Layout = new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                        Padding = new Extents(10, 10, 10, 10),
                    },
                    BackgroundColor = new Color((float)rand.Next(100, 255) / 255.0f, (float)rand.Next(100, 255) / 255.0f, (float)rand.Next(100, 255) / 255.0f, 0.6f),
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                };

                for (int j = 0; j < maxNumViewNLayer; j++)
                {
                    var child = new View()
                    {
                        BackgroundColor = new Color((float)rand.Next(100, 255) / 255.0f, (float)rand.Next(100, 255) / 255.0f, (float)rand.Next(100, 255) / 255.0f, 0.6f),
                        WidthSpecification = LayoutParamPolicies.MatchParent,
                    };
                    root.Add(child);
                }

                var layer = new Layer();
                layer.Add(root);
                win.AddLayer(layer);
            }
        }

        public void Deactivate()
        {
            timer.Stop();
            timer.Dispose();

            Tizen.Log.Debug("NUITEST", "Deactivate() dispose subWindow!");
            disposeSubWindows();
        }
    }
}
