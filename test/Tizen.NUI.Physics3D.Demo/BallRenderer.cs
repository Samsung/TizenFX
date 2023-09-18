/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd.
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
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Physics3D.Bullet;


class BallRenderer
{
    static string IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
    static string TEXTURE_URL = IMAGE_DIR + "/background-3.jpg";

    private static readonly string VERTEX_SHADER =
        "attribute mediump vec3 aPosition;  // DALi shader builtin\n" +
        "attribute mediump vec2 aTexCoord;  // DALi shader builtin\n" +
        "uniform   mediump mat4 uMvpMatrix; // DALi shader builtin\n" +
        "uniform   mediump mat4 uViewMatrix; // DALi shader builtin\n" +
        "uniform   mediump mat4 uModelView; // DALi shader builtin\n" +
        "uniform   mediump vec3 uSize;      // DALi shader builtin\n" +
        "uniform   mediump vec3 uLightPos;  // Property\n" + 
        "varying mediump vec3 vIllumination;\n" +
        "varying mediump vec2 vTexCoord;\n" +
        "\n" +
        "void main()\n" +
        "{\n" +
        "  mediump vec4 vertexPosition = vec4(aPosition, 1.0);\n" +
        "  mediump vec3 normal = normalize(vertexPosition.xyz);\n" +
        "\n" +
        "  vertexPosition.xyz *= uSize;\n" +
        "  vec4 pos = uModelView * vertexPosition;\n" +
        "\n" +
        "  vec4 lightPosition = vec4(uLightPos, 1.0);\n" +
        "  vec4 mvLightPos = uViewMatrix * lightPosition;\n" +
        "  vec3 vectorToLight = normalize(mvLightPos.xyz - pos.xyz);\n" +
        "  float lightDiffuse = max(dot(vectorToLight, normal), 0.0);\n" +
        "\n" +
        "  vIllumination = vec3(lightDiffuse * 0.5 + 0.5);\n" +
        "  vTexCoord = aTexCoord;\n" +
        "  gl_Position = uMvpMatrix * vertexPosition;\n" +
        "}\n";

    private static readonly string FRAGMENT_SHADER =
        "uniform sampler2D uTexture;\n" +
        "uniform mediump float uBrightness;\n" +
        "varying mediump vec2 vTexCoord;\n" +
        "varying mediump vec3 vIllumination;\n" +
        "\n" +
        "mediump vec3 redistribute_rgb(mediump vec3 color)\n" +
        "{\n" +
        "    mediump float threshold = 0.9999999;\n" +
        "    mediump float m = max(max(color.r, color.g), color.b);\n" +
        "    if(m <= threshold)\n" +
        "    {\n" +
        "        return color;\n" +
        "    }\n" +
        "    mediump float total = color.r + color.g + color.b;\n" +
        "    if( total >= 3.0 * threshold)\n" +
        "    {\n" +
        "        return vec3(threshold);\n" +
        "    }\n" +
        "    mediump float x = (3.0 * threshold - total) / (3.0 * m - total);\n" +
        "    mediump float gray = threshold - x * m;\n" +
        "    return vec3(gray) + vec3(x)*color;\n" +
        "}\n" +
        "\n" +
        "void main()\n" +
        "{\n" +
        "  mediump vec4 texColor = texture2D( uTexture, vTexCoord );\n" +
        "\n" +
        "  //mediump vec3 pcol=vec3(vIllumination.rgb * texColor.rgb)*(1.0+uBrightness);\n" +
        "  //gl_FragColor = vec4( redistribute_rgb(pcol), 1.0);\n" +
        "  //gl_FragColor = texColor;\n" +
        "  gl_FragColor = vec4(vIllumination.rgb * texColor.rgb, texColor.a);\n" +
        "}\n";

    static Geometry gBallGeometry;
    static TextureSet gBallTextureSet;
    static Shader gBallShader;

    private struct Vec2
    {
        public float X { get; }
        public float Y { get; }

        public Vec2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X - b.X, a.Y - b.Y);
        }
    };

    private struct Vec3
    {
        public float X;
        public float Y;
        public float Z;

        public Vec3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Vec3 operator +(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vec3 operator -(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vec3 operator *(Vec3 a, float scale)
        {
            return new Vec3(a.X * scale, a.Y * scale, a.Z * scale);
        }

        public float Length()
        {
            return MathF.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static Vec3 Normalize(Vec3 aVec3)
        {
            var length = aVec3.Length();
            return length <= 0 ? aVec3 : new Vec3(aVec3.X / length, aVec3.Y / length, aVec3.Z / length);
        }
    }

    private struct Vertex
    {
        public Vec3 aPosition;
        public Vec2 aTexCoord;

        public Vertex(Vec3 position, Vec2 uv)
        {
            this.aPosition = new Vec3(position.X, position.Y, position.Z);
            this.aTexCoord = new Vec2(uv.X, uv.Y);
        }
        public Vertex(Vec3 position)
        {
            this.aPosition = new Vec3(position.X, position.Y, position.Z);
            this.aTexCoord = new Vec2(0.0f, 0.0f);
        }

        public void SetTexCoord(Vector2 uv)
        {
            this.aTexCoord = new Vec2(uv.X, uv.Y);
        }
    };

    private static void SubDivide(ref List<Vertex> vertices, ref List<ushort> indices)
    {
        var triangleCount = indices.Count / 3;
        for(var i = 0; i < triangleCount; ++i)
        {
            var v1 = vertices[indices[i * 3]].aPosition;
            var v2 = vertices[indices[i * 3 + 1]].aPosition;
            var v3 = vertices[indices[i * 3 + 2]].aPosition;
            // Triangle subdivision adds pts halfway along each edge.
            var     v4 = v1 + (v2 - v1) * 0.5f;
            var     v5 = v2 + (v3 - v2) * 0.5f;
            var     v6 = v3 + (v1 - v3) * 0.5f;
            int j  = vertices.Count;
            vertices.Add(new Vertex(v4, new Vec2()));
            vertices.Add(new Vertex(v5, new Vec2()));
            vertices.Add(new Vertex(v6, new Vec2()));

            // Now, original tri breaks into 4, so replace this tri, and add 3 more
            ushort i1        = indices[i * 3 + 1];
            ushort i2        = indices[i * 3 + 2];
            indices[i * 3 + 1] = (ushort)j;
            indices[i * 3 + 2] = (ushort)(j + 2);

            var newTris = new List<ushort> {(ushort)j, i1, (ushort)(j + 1), (ushort) j, (ushort)(j + 1), (ushort)(j + 2), (ushort)(j + 1), i2, (ushort)(j + 2)};
            indices.AddRange( newTris );
        }
    }

    private static void Normalize(ref List<Vertex> vertices)
    {
        Span<Vertex> vertexSpan = CollectionsMarshal.AsSpan(vertices);
        for(var i=0; i<vertices.Count; ++i)
        {
            vertexSpan[i].aPosition = Vec3.Normalize(vertexSpan[i].aPosition);
        }
    }

    private static void MapUVsToSphere(ref List<Vertex> vertices)
    {
        // Convert world coords to long-lat
        // Assume radius=1;
        // V=(cos(long)cos(lat), sin(long)cos(lat), sin(lat))
        // => lat=arcsin(z), range (-PI/2, PI/2); => 0.5+(asin(z)/PI) range(0,1)
        // => y/x = sin(long)/cos(long) => long = atan2(y/x), range(-pi, pi)
        Span<Vertex> vertexSpan = CollectionsMarshal.AsSpan(vertices);
        for(var i=0; i<vertices.Count; ++i)
        {
            vertexSpan[i].SetTexCoord( new Vector2(1.0f - (0.5f + (MathF.Asin(vertexSpan[i].aPosition.Z) / MathF.PI)),
                1.0f + (MathF.Atan2(vertexSpan[i].aPosition.Y, vertexSpan[i].aPosition.X) / (2.0f * MathF.PI))));
        }
        Normalize(ref vertices);
    }

    private static Geometry CreateBallGeometry()
    {
        if (gBallGeometry) return gBallGeometry;
        var phi = (1.0f + MathF.Sqrt(5.0f)) * 0.5f; // golden ratio
        var a   = 1.0f;
        var b   = 1.0f / phi;

        // add vertices
        var vertices = new List<Vertex>
        {
            new Vertex(new Vec3(0, b, -a)),
            new Vertex(new Vec3(b, a, 0)),
            new Vertex(new Vec3(-b, a, -a)),
            new Vertex(new Vec3(0, b, a)),
            new Vertex(new Vec3(0, -b, a)),
            new Vertex(new Vec3(-a, 0, b)),
            new Vertex(new Vec3(0, -b, -a)),
            new Vertex(new Vec3(a, 0, -b)),
            new Vertex(new Vec3(a, 0, b)),
            new Vertex(new Vec3(-a, 0, -b)),
            new Vertex(new Vec3(b, -a, 0)),
            new Vertex(new Vec3(-b, -a, 0))
        };

        Normalize(ref vertices);

        var indices = new List<ushort>{
            2, 1, 0, 1, 2, 3, 5, 4, 3, 4, 8, 3, 7, 6, 0, 6, 9, 0, 11, 10, 4, 10, 11, 6, 9, 5, 2, 5, 9, 11, 8,
            7, 1, 7, 8, 10, 2, 5, 3, 8, 1, 3, 9, 2, 0, 1, 7, 0, 11, 9, 6, 7, 10, 6, 5, 11, 3, 10, 8, 4};

        // 2 subdivisions gives a reasonably nice sphere
        SubDivide(ref vertices, ref indices);
        SubDivide(ref vertices, ref indices);

        MapUVsToSphere(ref vertices);

        var format = new PropertyMap();
        format.Add("aPosition", new PropertyValue((int)PropertyType.Vector3));
        format.Add("aTexCoord", new PropertyValue((int)PropertyType.Vector2));
        var vertexBuffer = new VertexBuffer(format);
        var vertexData = vertices.ToArray();
        vertexBuffer.SetData(vertexData);
        gBallGeometry = new Geometry();
        gBallGeometry.AddVertexBuffer(vertexBuffer);
        gBallGeometry.SetIndexBuffer(indices.ToArray(), (uint)indices.Count);
        gBallGeometry.SetType(Geometry.Type.TRIANGLES);
        return gBallGeometry;
    }

    private static TextureSet CreateTexture(string url)
    {
        // Load image from file
        var pb = ImageLoader.LoadImageFromFile(url);//, new Size2D(), FittingModeType.ScaleToFill);
        var pixels = PixelBuffer.Convert(pb);
        var texture = new Texture(TextureType.TEXTURE_2D, pixels.GetPixelFormat(), pixels.GetWidth(), pixels.GetHeight());
        texture.Upload(pixels);

        // create TextureSet
        var textureSet = new TextureSet();
        textureSet.SetTexture(0, texture);
        return textureSet;
    }

    private static Shader CreateShader()
    {
        if(!gBallShader)
        {
            gBallShader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER);
        }
        return gBallShader;
    }

    private static Renderer CreateRenderer(TextureSet textures)
    {
        var geometry = CreateBallGeometry();
        var shader = CreateShader();
        var renderer = new Renderer(geometry, shader);
        renderer.SetTextures(textures);
        renderer.FaceCullingMode = (int)FaceCullingModeType.Back;
        return renderer;
    }

    public static View CreateView(Vector3 size, Vector4 color)
    {
        var actor = new View();
        actor.PivotPoint = PivotPoint.Center;
        actor.ParentOrigin = ParentOrigin.Center;
        actor.Position = new Vector3(0.0f, 0.0f, 0.0f);
        actor.Size = new Vector3(size.X, size.Y, size.Z) * 0.5f;
        actor.Color = color;
        if(!gBallTextureSet)
        {
            gBallTextureSet = CreateTexture(TEXTURE_URL);
        }
        var renderer = CreateRenderer(gBallTextureSet);
        actor.AddRenderer(renderer);
        return actor;
    }

    public static View CreateView(Vector3 size, string url)
    {
        var actor = new View();
        actor.PivotPoint = PivotPoint.Center;
        actor.ParentOrigin = ParentOrigin.Center;
        actor.Position = new Vector3(0.0f, 0.0f, 0.0f);
        actor.Size = size * 0.5f;

        var textures = CreateTexture(url);
        var   renderer = CreateRenderer(textures);
        actor.AddRenderer(renderer);
        actor.RegisterProperty("uLightPos", PropertyValue.CreateFromObject(new Vector3(400.0f, -400.0f, 400.0f)));
        return actor;
    }
}
