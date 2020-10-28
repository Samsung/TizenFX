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

using System;
using System.ComponentModel;
using System.Reflection;

namespace ElmSharp
{
    /// <summary>
    /// Pre-created window which prepares features that takes time in advance.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PreloadedWindow : Window
    {
        static PreloadedWindow s_precreated;

        internal PreloadedWindow(bool useBaseLayout=true) : base("PreloadWindow")
        {
            s_precreated = this;
            if (useBaseLayout)
                InitializeBaseLayout();
            WarmupWidgets();
            BackButtonPressed += DummyHandler;
            BackButtonPressed -= DummyHandler;
            void DummyHandler(object sender, System.EventArgs e) { }

            if (Elementary.GetProfile() == "wearable")
            {
                WarmupWearableWidgets();
            }
        }

        public Layout BaseLayout
        {
            get;
            protected set;
        }

        public Conformant BaseConformant
        {
            get;
            protected set;
        }

        public object BaseCircleSurface
        {
            get;
            set;
        }


        public void InitializeBaseLayout()
        {
            var conformant = new Conformant(this);
            BaseConformant = conformant;
            conformant.Show();

            var layout = new Layout(conformant);
            layout.SetTheme("layout", "application", "default");
            layout.Show();

            BaseLayout = layout;
            conformant.SetContent(BaseLayout);
        }

        public void WarmupWidgets()
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

        public void WarmupWearableWidgets()
        {
            try
            {
                Assembly assem = Assembly.Load("ElmSharp.Wearable");
                var type = assem.GetType("ElmSharp.Wearable.Preload");
                type.GetMethod("WarmupWidgets", BindingFlags.Public | BindingFlags.Static).Invoke(null, new object[] { this });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Fail to preload ElmSharp.Wearable");
            }
        }

        public static PreloadedWindow GetInstance()
        {
            var instance = s_precreated;
            s_precreated = null;
            return instance;
        }

        public static PreloadedWindow PeekInstance()
        {
            return s_precreated;
        }
    }
}
