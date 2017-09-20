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

namespace TTSPlayerTest
{
    class Example : NUIApplication
    {
        public Example() : base()
        {
        }

        public Example(string stylesheet) : base(stylesheet)
        {
        }

        public Example(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TTSPlayer ttsPlayer = TTSPlayer.Get(TTSPlayer.TTSMode.Default);
            ttsPlayer.Play("tts player test");

            ttsPlayer.StateChanged += (s, e) =>
            {
                Tizen.Log.Debug("NUI", "TTS state changed!!!");
            };
            ttsPlayer.Pause();
            ttsPlayer.Resume();
            ttsPlayer.Stop();
            Tizen.Log.Debug("NUI", "TTS state: " + ttsPlayer.GetState());
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
