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

using Tizen.NUI.BaseComponents;

using global::System;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class NativeImageSourceSample : IExample
    {
        private const string tag = "NUITEST";
        private Window mainWin;
        private ImageView imageView;
        private NativeImageSource source;
        private Task bufferAssignTask;
        const int imageWidth = 300;
        const int imageHeight = 300;

        public void Activate()
        {
            Initialize();
        }

        public void Deactivate()
        {
            if (bufferAssignTask != null)
            {
                try
                {
                    bufferAssignTask.Wait();
                }
                catch(Exception ex)
                {
                    Tizen.Log.Error("NUI", $"Exception {ex.Message}\n");
                }
                bufferAssignTask = null;
            }
        }

        private void Initialize()
        {
            mainWin = NUIApplication.GetDefaultWindow();
            mainWin.BackgroundColor = Color.White;
            Size2D windowSize = new Size2D(mainWin.Size.Width,mainWin.Size.Height);

            NativeImageSource source = new NativeImageSource((uint)windowSize.Width, (uint)windowSize.Height, NativeImageSource.ColorDepth.Default);
            var url = source.GenerateUrl();

            bufferAssignTask = AssignBuffer();

            imageView = new ImageView(url.ToString());
            imageView.Size2D = new Size2D(imageWidth, imageHeight);
            mainWin.Add(imageView);
        }

        private Task AssignBuffer()
        {
            Task task = new Task(() =>
            {
                int bufferWidth = 0;
                int bufferHeight = 0;
                int bufferStride = 0;
                var buffer = source.AcquireBuffer(ref bufferWidth, ref bufferHeight, ref bufferStride);
                Tizen.Log.Error("NUI", $"AcquireBuffer {bufferWidth} x {bufferHeight} with stride {bufferStride}\n");
                uint size = (uint) bufferWidth * (uint) bufferHeight * 4;
                unsafe
                {
                    byte* ptrData = (byte*) buffer.ToPointer();
                    for(int i=0; i< size; i+=4)
                    {
                        ptrData[i] = 0;
                        ptrData[i+1] = 255;
                        ptrData[i+2] = 0;
                        ptrData[i+3] = 255;
                    }
                }
                Tizen.Log.Error("NUI", $"ReleaseBuffer\n");
                source.ReleaseBuffer();
            });
            task.Start();
            return task;
        }
    }
}
