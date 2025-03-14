using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class RendererUpdateAreaTest : IExample
    {
        static readonly string VERTEX_SHADER =
        "//@name RendererUpdateAreaTest.vert\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision highp float;\n"+
        "INPUT highp vec2 aPosition;\n" +
        "\n" +
        "UNIFORM_BLOCK VertBlock\n" +
        "{\n" +
        "  UNIFORM highp mat4 uMvpMatrix;\n" +
        "  UNIFORM highp vec3 uSize;\n" +
        "  UNIFORM highp vec2 uCustomExtraSize;\n" +
        "};\n" +
        "void main()\n" +
        "{\n" +
        "    vec4 pos = vec4(aPosition, 0.0, 1.0) * vec4(uSize.xy + uCustomExtraSize, 0.0, 1.0);\n" +
        "    gl_Position = uMvpMatrix * pos;\n" +
        "}\n";

        static readonly string FRAGMENT_SHADER =
        "//@name RendererUpdateAreaTest.frag\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision highp float;\n"+
        "\n" +
        "UNIFORM_BLOCK FragBlock\n" +
        "{\n" +
        "  UNIFORM lowp vec4 uColor;\n" +
        "};\n" +
        "\n" +
        "void main()\n" +
        "{\n" +
        "    gl_FragColor = uColor;\n" +
        "}\n";


        struct SimpleQuadVertex
        {
            public UIVector2 position;
        }

        private PropertyBuffer CreateQuadPropertyBuffer()
        {
            /* Create Property buffer */
            PropertyMap vertexFormat = new PropertyMap();
            vertexFormat.Add("aPosition", (int)PropertyType.Vector2);

            PropertyBuffer vertexBuffer = new PropertyBuffer(vertexFormat);
            
            SimpleQuadVertex vertex1 = new SimpleQuadVertex();
            SimpleQuadVertex vertex2 = new SimpleQuadVertex();
            SimpleQuadVertex vertex3 = new SimpleQuadVertex();
            SimpleQuadVertex vertex4 = new SimpleQuadVertex();
            vertex1.position = new UIVector2(-0.5f, -0.5f);
            vertex2.position = new UIVector2(-0.5f, 0.5f);
            vertex3.position = new UIVector2(0.5f, -0.5f);
            vertex4.position = new UIVector2(0.5f, 0.5f);

            SimpleQuadVertex[] texturedQuadVertexData = new SimpleQuadVertex[4] { vertex1, vertex2, vertex3, vertex4 };

            int size = Marshal.SizeOf(vertex1);
            IntPtr pA = Marshal.AllocHGlobal(checked(size * texturedQuadVertexData.Length));

            try
            {
                for (int i = 0; i < texturedQuadVertexData.Length; i++)
                {
                    Marshal.StructureToPtr(texturedQuadVertexData[i], pA + i * size, true);
                }

                vertexBuffer.SetData(pA, (uint)texturedQuadVertexData.Length);
            }
            catch(Exception e)
            {
                Tizen.Log.Error("NUI", "Exception in FrameBrokerBase : " + e.Message);
            }
            finally
            {
                // Free AllocHGlobal memory after call PropertyBuffer.SetData()
                Marshal.FreeHGlobal(pA);
            }

            vertexFormat.Dispose();

            return vertexBuffer;
        }

        private Window win;
        private View root;
        private Animation moveAnimation;

        private Dictionary<string, Texture> textureDictionary = new();

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                Name = "root",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            win.Add(root);

            moveAnimation = new Animation(1500); //1.5s
            moveAnimation.LoopingMode = Animation.LoopingModes.AutoReverse;
            moveAnimation.Looping = true;

            AddViews();
            var infoLabel = new TextLabel()
            {
                Text = "1'st : No update area extents\n2'nd : Extents just half.\n3'rd : Fit extented area.",
                MultiLine = true,
            };
            root.Add(infoLabel);

            moveAnimation.Play();
        }

        private void AddViews()
        {
            for(int i = 0; i < 3; i++)
            {
                // View area is red, and additional renderer area is yellow.
                View view = new View()
                {
                    Color = Color.Yellow,
                    BackgroundColor = Color.Red,
                    SizeWidth = 50.0f,
                    SizeHeight = 50.0f,
                    PositionX = 0.0f,
                    PositionY = i * 250.0f + 50.0f,
                };

                var renderer = GenerateRenderer();

                // Make it draw under the background
                renderer.DepthIndex = Renderer.Ranges.Background - 1;

                renderer.UpdateAreaExtents = new UIExtents((float)i * 12.5f, (float)i * 7.5f);

                view.AddRenderer(renderer);
                root.Add(view);

                moveAnimation.AnimateTo(view, "PositionX", 350.0f);
            }
        }

        private Geometry GenerateGeometry()
        {
            using PropertyBuffer vertexBuffer = CreateQuadPropertyBuffer();
            Geometry geometry = new Geometry();
            geometry.AddVertexBuffer(vertexBuffer);
            geometry.SetType(Geometry.Type.TRIANGLE_STRIP);

            return geometry;
        }

        private Shader GenerateShader()
        {
            Shader shader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER, "RendererUpdateAreaTest");
            return shader;
        }

        private Renderer GenerateRenderer()
        {
            Renderer renderer = new Renderer();
            Geometry geometry = GenerateGeometry();
            Shader shader = GenerateShader();

            renderer.SetGeometry(geometry);
            renderer.SetShader(shader);

            renderer.RegisterProperty("uCustomExtraSize", new PropertyValue(new UIVector2(50.0f, 30.0f)));

            return renderer;
        }

        public void Deactivate()
        {
            moveAnimation.Stop();
            root.Unparent();
            root.Dispose();
        }
    }
}
