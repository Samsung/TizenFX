/*
 *  Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;

using Xamarin.Forms;
using Tizen.MachineLearning.Nnstreamer.Test;

namespace XamarinForTizen.Tizen
{
    public class App : Application
    {
        Button btnPipeline;
        Button btnSingle;
        Label lblResult;
        
        
        public App()
        {
            btnPipeline = new Button
            {
                Text = "Pipeline Test",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            btnPipeline.Clicked += OnBtnPilelineClicked;

            btnSingle = new Button
            {
                Text = "Single Test",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            btnSingle.Clicked += OnBtnSingleClicked;

            lblResult = new Label
            {
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Start,
                    Children = {
                        btnPipeline,
                        btnSingle,
                        lblResult,
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void OnBtnPilelineClicked(object s, EventArgs e)
        {
            string retMsg = "";
            retMsg += "Pipeline Test Started\n\n";

            retMsg += "  * ConstructDestructTest_Success00: ";
            retMsg += PipelineTest.ConstructDestructTest_Success00() ? "OK\n" : "Failed!\n";

            retMsg += "  * ConstructDestructTest_Failure00: ";
            retMsg += PipelineTest.ConstructDestructTest_Failure00() ? "OK\n" : "Failed!\n";

            retMsg += "\nPipeline Test Done";

            lblResult.Text = retMsg;
        }

        private void OnBtnSingleClicked(object s, EventArgs e)
        {
            lblResult.Text = "Single Test Started\n";
            lblResult.Text += "Single Test is Done\n";
        }
    }
}
