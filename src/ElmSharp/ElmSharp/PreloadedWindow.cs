/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace ElmSharp
{
    internal class PreloadedWindow : Window
    {
        static PreloadedWindow s_precreated;

        public PreloadedWindow(bool useBaseLayout=true) : base("PreloadWindow")
        {
            s_precreated = this;
            if (useBaseLayout)
                InitializeBaseLayout();
            CreateWidgets();
            BackButtonPressed += DummyHandler;
            BackButtonPressed -= DummyHandler;
            void DummyHandler(object sender, System.EventArgs e) { }
        }

        public Layout BaseLayout
        {
            get;
            protected set;
        }

        public void InitializeBaseLayout()
        {
            var conformant = new Conformant(this);
            conformant.Show();

            var layout = new Layout(conformant);
            layout.SetTheme("layout", "application", "default");
            layout.Show();

            BaseLayout = layout;
            conformant.SetContent(BaseLayout);
        }

        public void CreateWidgets()
        {
            new Entry(this).Unrealize();
            new Scroller(this).Unrealize();
            new Box(this).Unrealize();
            new Label(this).Unrealize();
            new GenList(this).Unrealize();
            new Button(this).Unrealize();
            new Check(this).Unrealize();
            new Naviframe(this).Unrealize();
            new Slider(this).Unrealize();
            new Spinner(this).Unrealize();
            new ProgressBar(this).Unrealize();
            new GestureLayer(this).Unrealize();
            new Polygon(this).Unrealize();
            new Image(this).Unrealize();
            //TODO: Consider to call Image.LoadAsync()
        }

        public static PreloadedWindow GetInstance()
        {
            var instance = s_precreated;
            s_precreated = null;
            return instance;
        }
    }
}
