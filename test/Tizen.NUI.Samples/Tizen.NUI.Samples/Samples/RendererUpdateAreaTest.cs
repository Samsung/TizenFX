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
                Tizen.Log.Error("NUI", "Exception in PropertyBuffer : " + e.Message);
            }
            finally
            {
                // Free AllocHGlobal memory after call PropertyBuffer.SetData()
                Marshal.FreeHGlobal(pA);
            }

            vertexFormat.Dispose();

            return vertexBuffer;
        }

        static private readonly float extraSizeWidth = 100.0f;
        static private readonly float extraSizeHeight = 100.0f;

        private Window win;
        private View root;
        private View[] subView = new View[3];
        private Animation moveXAnimation;
        private Animation moveYAnimation;
        private Timer mTimer;
        private int showingViewIndex = 0;

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

            moveXAnimation = new Animation(3000); //3.0s
            moveYAnimation = new Animation(2600); //2.6s

            AddViews();
            var infoLabel = new TextLabel()
            {
                Text = "1'st : No update area extents\n2'nd : Extents just right and bottom.\n3'rd : Fit extented area.",
                MultiLine = true,
            };
            root.Add(infoLabel);

            moveXAnimation.Looping = true;
            moveXAnimation.LoopingMode = Animation.LoopingModes.AutoReverse;
            moveXAnimation.Play();
            moveYAnimation.Looping = true;
            moveYAnimation.LoopingMode = Animation.LoopingModes.AutoReverse;
            moveYAnimation.Play();

            // Visibility change timer
            subView[showingViewIndex].Show();

            mTimer = new Timer(2000);
            mTimer.Tick += OnTick;
            mTimer.Start();
        }


        private bool OnTick(object o, EventArgs e)
        {
            subView[showingViewIndex].Hide();
            showingViewIndex = (showingViewIndex + 1)%3;
            subView[showingViewIndex].Show();
            return true;
        }

        private void AddViews()
        {
            for(int i = 0; i < 3; i++)
            {
                // View area is red, and additional renderable area is yellow.
                View view = new View()
                {
                    Color = Color.Yellow,
                    BackgroundColor = Color.Red,
                    SizeWidth = 8.0f,
                    SizeHeight = 8.0f,
                    PositionX = extraSizeWidth * 0.5f,
                    PositionY = extraSizeHeight * 0.5f,
                };

                var renderable = GenerateRenderable();

                // Make it draw under the background
                renderable.DepthIndex = DepthIndexRanges.Background - 1;

                if (i == 1)
                {
                    renderable.UpdateArea = new UIExtents(0.0f, extraSizeHeight * 0.5f, 0.0f, extraSizeHeight * 0.5f);
                }
                else if (i == 2)
                {
                    renderable.UpdateArea = new UIExtents(extraSizeHeight * 0.5f, extraSizeHeight * 0.5f, extraSizeHeight * 0.5f, extraSizeHeight * 0.5f);
                }

                view.AddRenderable(renderable);

                moveXAnimation.AnimateBy(view, "PositionX", 350.0f);
                moveYAnimation.AnimateBy(view, "PositionY", 200.0f);

                View playGroundView = new View()
                {
                    BorderlineWidth = 2.0f,
                    BorderlineOffset = 1.0f,
                    SizeWidth = 8.0f + 350.0f + extraSizeWidth,
                    SizeHeight = 8.0f + 200.0f + extraSizeHeight,
                    PositionX = 15.0f,
                    PositionY = i * 250.0f + 15.0f,
                };

                playGroundView.Hide();

                playGroundView.Add(view);
                root.Add(playGroundView);
                subView[i] = playGroundView;
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

        private Renderable GenerateRenderable()
        {
            Renderable renderable = new Renderable()
            {
                Geometry = GenerateGeometry(),
                Shader = GenerateShader(),
            };

            renderable.RegisterProperty("uCustomExtraSize", new PropertyValue(new UIVector2(extraSizeWidth, extraSizeHeight)));

            return renderable;
        }

        public void Deactivate()
        {
            mTimer?.Stop();
            mTimer?.Dispose();
            moveXAnimation?.Stop();
            moveXAnimation?.Dispose();
            moveYAnimation?.Stop();
            moveYAnimation?.Dispose();
            root?.Unparent();
            root?.Dispose();
        }
    }
}
