using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Samples
{
    public class ClippedImage
    {
        public static float QUAD_GEOMETRY = 1.0f;
        public static float CIRCLE_GEOMETRY = 0.0f;
        static float[] circleArray;
        static float[] quadArray;

        static Geometry geometry = null;

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

        public static View Create(string imagePath )
        {
            // Create a view which whose geometry will be morphed between a circle and a quad
            View clippedImage = new View();
            clippedImage.ClippingMode = ClippingModeType.ClipChildren;

            // Create the required renderer and add to the clipped image view
            Shader shader = CreateShader();
            CreateGeometry();
            Renderer renderer = new Renderer(geometry, shader);
            renderer.BlendMode = 2;
            clippedImage.AddRenderer(renderer);

            // Register the property on the clipped image view which will allow animations between a circle and a quad
            int propertyIndex = clippedImage.RegisterProperty("uDelta", new PropertyValue(0.0f));

            // Add the actual image to the control
            View image = new ImageView(imagePath);
            image.WidthResizePolicy = ResizePolicyType.FillToParent;
            image.HeightResizePolicy = ResizePolicyType.FillToParent;
            image.ParentOrigin = ParentOrigin.Center;
            image.PivotPoint = PivotPoint.Center;
            image.PositionUsesPivotPoint = true;
            clippedImage.Add(image);

            return clippedImage;
        }

        private static Shader CreateShader()
        {
            Shader shader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER);

            return shader;
        }

        private static void CreateGeometry()
        {
            if(geometry == null)
            {
                geometry = new Geometry();

                const int vertexCount = 34;

                circleArray = new float[vertexCount * 2];
                quadArray = new float[vertexCount * 2];

                // Create the circle geometry

                // Radius is bound to actor's dimensions so this should not be increased.
                // If a bigger circle is required then the actor size should be increased.
                const float radius = 0.5f;
                Vector2 center = new Vector2(0.0f, 0.0f);

                // Create a buffer for vertex data
                Vector2[] circleBuffer = new Vector2[vertexCount];
                int idx = 0;

                // Center vertex for triangle fan
                circleBuffer[idx++] = center;

                // Outer vertices of the circle
                const int outerVertexCount = vertexCount - 1;

                for (int i = 0; i < outerVertexCount; ++i)
                {
                    float percent = (i / (float)(outerVertexCount - 1));
                    float rad = percent * 2.0f * (float)Math.PI;

                    // Vertex position
                    Vector2 tmpvec = new Vector2(0, 0);
                    tmpvec.X = (float)(center.X + radius * Math.Cos(rad));
                    tmpvec.Y = (float)(center.Y + radius * Math.Sin(rad));

                    circleBuffer[idx++] = tmpvec;
                }

                for(int i = 0; i < idx; i++)
                {
                    circleArray[i * 2] = circleBuffer[i].X;
                    circleArray[i * 2 + 1] = circleBuffer[i].Y;
                }

                PropertyMap circleVertexFormat = new PropertyMap();
                circleVertexFormat.Add("aPositionCircle", new PropertyValue((int)PropertyType.Vector2));
                PropertyBuffer circleVertices = new PropertyBuffer(circleVertexFormat);

                unsafe
                {
                    float* pc = (float*)Marshal.UnsafeAddrOfPinnedArrayElement(circleArray, 0);
                    IntPtr pA = new IntPtr(pc);
                    circleVertices.SetData(pA, vertexCount);
                }


                // Create the Quad Geometry
                Vector2[] quadBuffer = new Vector2[vertexCount];
                idx = 0;
                quadBuffer[idx++] = new Vector2(center.X, center.Y);

                const int vertsPerSide = (vertexCount - 2) / 4;
                Vector2 outer = new Vector2(0.5f, 0.0f);
                quadBuffer[idx++] = new Vector2(outer.X, outer.Y);
                float incrementPerBuffer = 1.0f / (float)(vertsPerSide);

                for (int i = 0; i < vertsPerSide && outer.Y < 0.5f; ++i)
                {
                    outer.Y += incrementPerBuffer;
                    quadBuffer[idx++] = new Vector2(outer.X, outer.Y);
                }

                for (int i = 0; i < vertsPerSide && outer.X > -0.5f; ++i)
                {
                    outer.X -= incrementPerBuffer;
                    quadBuffer[idx++] = new Vector2(outer.X, outer.Y);
                }

                for (int i = 0; i < vertsPerSide && outer.Y > -0.5f; ++i)
                {
                    outer.Y -= incrementPerBuffer;
                    quadBuffer[idx++] = new Vector2(outer.X, outer.Y);
                }

                for (int i = 0; i < vertsPerSide && outer.X < 0.5f; ++i)
                {
                    outer.X += incrementPerBuffer;
                    quadBuffer[idx++] = new Vector2(outer.X, outer.Y);
                }

                for (int i = 0; i < vertsPerSide && outer.Y < 0.0f; ++i)
                {
                    outer.Y += incrementPerBuffer;
                    quadBuffer[idx++] = new Vector2(outer.X, outer.Y);
                }

                for(int i = 0; i < idx; i++)
                {
                    quadArray[i * 2] = quadBuffer[i].X;
                    quadArray[i * 2 + 1] = quadBuffer[i].Y;
                }

                PropertyMap vertexFormat = new PropertyMap();
                vertexFormat.Add("aPositionQuad", new PropertyValue((int)PropertyType.Vector2));
                PropertyBuffer quadVertices2 = new PropertyBuffer(vertexFormat);
                unsafe
                {
                    float* pc = (float*)Marshal.UnsafeAddrOfPinnedArrayElement(quadArray, 0);
                    IntPtr pA = new IntPtr(pc);
                    quadVertices2.SetData(pA, vertexCount);
                }
                //int length2 = Marshal.SizeOf(quadBuffer[0]);
                //IntPtr p2 = Marshal.AllocHGlobal(length2 * vertexCount);
                //quadVertices2.SetData(p2, vertexCount);

                // Create the geometry object itself
                geometry.AddVertexBuffer(circleVertices);
                geometry.AddVertexBuffer(quadVertices2);
                geometry.SetType(Geometry.Type.TRIANGLE_FAN);
            }
        }
    }
}
