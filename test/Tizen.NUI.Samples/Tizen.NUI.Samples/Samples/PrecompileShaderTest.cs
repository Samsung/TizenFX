/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

using System.Threading;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class PrecompileShaderTest : IExample
    {
        private static string DEMO_IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
        private static string[] url = new string[]
        {
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-2.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-3.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-4.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-5.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-6.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-7.jpg",
        };

        private static readonly string VERTEX_SHADER =
        "attribute vec2  aPositionCircle;\n" +
        "attribute vec2  aPositionQuad;\n" +
        "uniform  float uDelta;\n" +
        "uniform mat4 uMvpMatrix;\n" +
        "uniform vec3    uSize;\n" +
        "\n" +
        "void main()\n" +
        "{\n" +
        "   vec4 vertexPosition = vec4(mix(aPositionCircle, aPositionQuad, uDelta), 0.0, 1.0);\n" +
        "   vertexPosition.xyz *= uSize;\n" +
        "   gl_Position = uMvpMatrix * vertexPosition;\n" +
        "}\n";

        private static readonly string FRAGMENT_SHADER =
        "precision mediump float;\n" +
        "void main()\n" +
        "{\n" +
        "   gl_FragColor = vec4(0.0, 0.0, 0.0, 0.0);\n" +
        "}\n";

        public void Activate()
        {
            Initialize();
        }

        public void Deactivate()
        {
        }

        private void Initialize()
        {
            //Originally, this call should be made in OnPreCreate(), but because of the nature of this sample, I had it called before the UI is composed.
            {
                PropertyMap imageShader = new PropertyMap();
                imageShader.Add("shaderType", new PropertyValue("image"));

                PropertyMap imageShader2 = new PropertyMap();
                imageShader2.Add("shaderType", new PropertyValue("image"));
                imageShader2.Add("shaderOption", new PropertyValue(new PropertyMap().Add("ROUNDED_CORNER", new PropertyValue(true))
                                                                                    .Add("MASKING", new PropertyValue(true))));

                PropertyMap textShader = new PropertyMap();
                textShader.Add("shaderType", new PropertyValue("text"));
                textShader.Add("shaderOption", new PropertyValue(new PropertyMap().Add("MULTI_COLOR", new PropertyValue(true))
                                                                        .Add("STYLES", new PropertyValue(true))));

                PropertyMap colorShader = new PropertyMap();
                colorShader.Add("shaderType", new PropertyValue("color"));
                colorShader.Add("shaderOption", new PropertyValue(new PropertyMap().Add("CUTOUT", new PropertyValue(true))
                                                                        .Add("BORDERLINE", new PropertyValue(true))));

                PropertyMap customShader = new PropertyMap();
                customShader.Add("shaderType", new PropertyValue("custom"));
                customShader.Add("shaderName", new PropertyValue("customShader"));
                customShader.Add("vertexShader", new PropertyValue(VERTEX_SHADER));
                customShader.Add("fragmentShader", new PropertyValue(FRAGMENT_SHADER));

                PropertyMap npatchShader = new PropertyMap();
                npatchShader.Add("shaderType", new PropertyValue("npatch"));

                VisualFactory.Instance.AddPrecompileShader(imageShader);
                VisualFactory.Instance.AddPrecompileShader(imageShader2);
                VisualFactory.Instance.AddPrecompileShader(textShader);
                VisualFactory.Instance.AddPrecompileShader(colorShader);
                VisualFactory.Instance.AddPrecompileShader(customShader);
                VisualFactory.Instance.AddPrecompileShader(npatchShader);
                VisualFactory.Instance.UsePreCompiledShader();
            }

            mainWin = NUIApplication.GetDefaultWindow();
            mainWin.BackgroundColor = Color.White;
            mainWin.WindowSize = new Size2D(1920, 1080);
            Size2D windowSize = new Size2D(mainWin.Size.Width, mainWin.Size.Height);

            imageViews = new ImageView[imageMax];
            for (int i = 0; i < imageMax; i++)
            {
                int width = (i % (imageMax / 2)) * imageWidth;
                int height = (i / (imageMax / 2)) * imageHeight;
                imageViews[i] = new ImageView();
                imageViews[i].Size2D = new Size2D(imageWidth, imageHeight);
                imageViews[i].Position2D = new Position2D(width, height);
                imageViews[i].ResourceUrl = url[i];

                if (i == 0)
                {
                    PropertyMap map = new PropertyMap();
                    PropertyMap customShader = new PropertyMap();
                    customShader.Add("vertexShader", new PropertyValue(VERTEX_SHADER));
                    customShader.Add("fragmentShader", new PropertyValue(FRAGMENT_SHADER));
                    map.Add("shader", new PropertyValue(customShader));
                    imageViews[i].Image = map;
                }

                mainWin.Add(imageViews[i]);
            }
            Tizen.Log.Info("NUI", "sleep for waiting precompile time(8sec) ... start");
            Thread.Sleep(8000);
            Tizen.Log.Info("NUI", "sleep for waiting precompile time(8sec) ... done!");
        }
        
        private Window mainWin;
        private ImageView[] imageViews = null;
        const int imageWidth = 500;
        const int imageHeight = 500;
        const int imageMax = 6;
        //Timer mTimer;
        int image_count = 0;
    }
}
