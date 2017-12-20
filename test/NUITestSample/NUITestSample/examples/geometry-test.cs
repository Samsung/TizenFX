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
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;
using System.Linq;

namespace GeometryTest
{
    class Example : NUIApplication
    {
        public Example():base()
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

		[StructLayout(LayoutKind.Sequential)]
		public struct Vec2
		{
			float x;
			float y;
			public Vec2(float xIn, float yIn)
			{
				x = xIn;
				y = yIn;
			}
		}

		public struct TexturedQuadVertex
		{
			public Vec2 position;
			// public Vec2 textureCoordinates;
		};

		public static byte[] Struct2Bytes(TexturedQuadVertex[] obj)
		{
			int size = Marshal.SizeOf(obj);
			byte[] bytes = new byte[size];
			IntPtr ptr = Marshal.AllocHGlobal(size);
			Marshal.StructureToPtr(obj, ptr, false);
			Marshal.Copy(ptr, bytes, 0, size);
			Marshal.FreeHGlobal(ptr);
			return bytes;
		}
		
        private void Initialize()
        {
            // Connect the signal callback for window touched signal
            Window window = Window.Instance;
			window.BackgroundColor = Color.White;

			/* Vertex shader */
			const string VERTEX_SHADER = "" +
				"attribute mediump vec2 aPosition;\n" +
				"uniform   mediump mat4 uMvpMatrix;\n" +
				"uniform   mediump vec3 uSize;\n" +
				"\n" +
				"void main()\n" +
				"{\n" +
					"mediump vec4 vertexPosition = vec4(aPosition, 0.0, 1.0);\n" +
					"vertexPosition.xyz *= uSize;\n"+
					"gl_Position = uMvpMatrix * vertexPosition;\n" +
				"}\n";

			/* Fragment shader */
			const string FRAGMENT_SHADER = "" +
				"uniform mediump vec4 uColor;\n" +
				"\n" +
				"void main()\n" +
				"{\n" +
					"gl_FragColor = uColor;\n" +
				"}\n";

			TexturedQuadVertex vertex1 = new TexturedQuadVertex();
			vertex1.position = new Vec2(-1.0f, -1.0f);
			TexturedQuadVertex vertex2 = new TexturedQuadVertex();
			vertex2.position = new Vec2(1.0f, 1.0f);

			TexturedQuadVertex[] texturedQuadVertexData;
			texturedQuadVertexData = new TexturedQuadVertex[2] { vertex1, vertex2 };

			int lenght = Marshal.SizeOf(vertex1);
			IntPtr pA = Marshal.AllocHGlobal(lenght * 2);

			for (int i = 0; i < 2; i++)
			{
				Marshal.StructureToPtr(texturedQuadVertexData[i], pA + i * lenght, true);
			}

			/* Create Shader */
            Shader shader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER);
			
			/* Create Property buffer */
			PropertyMap vertexFormat = new PropertyMap();
			vertexFormat.Add("aPosition", new PropertyValue((int)PropertyType.Vector2));

			PropertyBuffer vertexBuffer = new PropertyBuffer( vertexFormat );
			vertexBuffer.SetData(pA, 4);

			/* Create geometry */
			Geometry geometry = new Geometry();
			geometry.AddVertexBuffer(vertexBuffer);
			geometry.SetType(Geometry.Type.LINES);

			/* Create renderer */
			Renderer renderer = new Renderer(geometry, shader);

			/* Create view */
			View view = new View()
			{
				Size2D = new Size2D(300, 300),
				ParentOrigin = ParentOrigin.Center,
				PivotPoint = PivotPoint.Center,
				PositionUsesPivotPoint = true,
				BackgroundColor = Color.Black,
			};
			view.AddRenderer(renderer);

            window.Add(view);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
