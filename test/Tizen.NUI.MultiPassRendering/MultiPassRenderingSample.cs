/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

class MultiPassRenderingSample : NUIApplication
{
    Window mWindow;
    Vector2 mWindowSize;

    RenderTaskList mRenderTaskList;

    void OnResized(object source, Window.ResizedEventArgs e)
    {
        mWindowSize = e.WindowSize;
    }

    void OnKeyEvent(object source, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down)
        {
            switch (e.Key.KeyPressedName)
            {
                case "Escape":
                case "Back":
                {
                    Deactivate();
                    Exit();
                    break;
                }

                case "Return":
                case "Select":
                {
                    break;
                }

            }
        }
    }

    private void AttachViewer(Texture texture, Size size, Position position)
    {
        ImageUrl imageUrl = texture.GenerateUrl();
        ImageView textureViewer = new ImageView(imageUrl.ToString())
        {
            Size = size,
            Position = position,
        };

        mWindow.Add(textureViewer);
    }

    #region First Scene Creation
    private RenderTask mFirstRenderTask; // Must have reference. Dispose will remove rendering automatically
    private FrameBuffer mFirstFrameBuffer;
    private Texture mFirstRenderedTexture;
    private Texture mFirstDepthTexture;

    const uint c_FirstSceneWidth = 100u;
    const uint c_FirstSceneHeight = 200u;

    private Animation mFirstSceneAnimation;

    private void CreateFirstScene()
    {
        mFirstRenderTask = mRenderTaskList.CreateTask();

        mFirstRenderTask.SetExclusive(true);
        mFirstRenderTask.SetClearEnabled(true);
        mFirstRenderTask.SetCullMode(false); // Allways rendering even if scene is out of camera.
        mFirstRenderTask.SetRefreshRate(1); // Refresh Always

        mFirstRenderTask.ClearColor = new Vector4(0.0f, 0.0f, 1.0f, 0.5f);
        mFirstRenderTask.OrderIndex = -100;

        // TODO : Tizen.NUI.Camera is deprecated! Need to find more good way to support it.
        Tizen.NUI.Camera camera = new Tizen.NUI.Camera()
        {
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
        };
        camera.SetPerspectiveProjection(new Vector2(c_FirstSceneWidth, c_FirstSceneHeight));
        camera.SetInvertYAxis(true);

        camera.NearPlaneDistance = camera.Position.Z - 0.1f;
        camera.FarPlaneDistance = camera.Position.Z + 0.1f;

        mFirstRenderTask.SetCamera(camera);

        mFirstFrameBuffer = new FrameBuffer(c_FirstSceneWidth, c_FirstSceneHeight, 0);
        mFirstRenderedTexture = new Texture(TextureShape.Texture2D, PixelFormat.RGBA8888, c_FirstSceneWidth, c_FirstSceneHeight);
        mFirstFrameBuffer.AttachColorTexture(mFirstRenderedTexture);
        mFirstRenderTask.SetFrameBuffer(mFirstFrameBuffer);

        View firstSceneRoot = new View()
        {
            Size = new Size(c_FirstSceneWidth / 2, c_FirstSceneHeight / 2),
            Position = new Position(0, 0),
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
            BackgroundColor = Color.Red,
        };

        View firstSceneChild = new View()
        {
            Size = new Size(c_FirstSceneWidth / 3, c_FirstSceneHeight / 3),
            Position = new Position(10, -10),
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
            BackgroundColor = Color.Yellow,
        };

        mFirstRenderTask.SetSourceView(firstSceneRoot);

        mWindow.Add(camera);
        mWindow.Add(firstSceneRoot);
        firstSceneRoot.Add(firstSceneChild);

        mFirstSceneAnimation = new Animation(1000);
        mFirstSceneAnimation.AnimateTo(firstSceneChild, "Position", new Vector3(100, 100, 0));
        mFirstSceneAnimation.Looping = true;
        mFirstSceneAnimation.Play();

        AttachViewer(mFirstRenderedTexture, new Size(c_FirstSceneWidth, c_FirstSceneHeight), new Position(10, 10));
    }
    #endregion

    #region Second Scene Creation
    private RenderTask mSecondRenderTask; // Must have reference. Dispose will remove rendering automatically
    private FrameBuffer mSecondFrameBuffer;
    private Texture mSecondRenderedTexture;
    private Texture mSecondDepthTexture;

    const uint c_SecondSceneWidth = 400u;
    const uint c_SecondSceneHeight = 200u;

    private Animation mSecondSceneAnimation;
    private void CreateSecondScene()
    {
        mSecondRenderTask = mRenderTaskList.CreateTask();

        mSecondRenderTask.SetExclusive(true);
        mSecondRenderTask.SetClearEnabled(true);
        mSecondRenderTask.SetCullMode(false); // Allways rendering even if scene is out of camera.
        mSecondRenderTask.SetRefreshRate(5); // Refresh per 5 frame

        mSecondRenderTask.ClearColor = new Vector4(0.0f, 1.0f, 0.0f, 0.5f);
        mSecondRenderTask.OrderIndex = mFirstRenderTask.OrderIndex + 1;

        // TODO : Tizen.NUI.Camera is deprecated! Need to find more good way to support it.
        Tizen.NUI.Camera camera = new Tizen.NUI.Camera()
        {
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
        };
        camera.SetPerspectiveProjection(new Vector2(c_SecondSceneWidth, c_SecondSceneHeight));
        camera.SetInvertYAxis(true);

        mSecondRenderTask.SetCamera(camera);

        mSecondFrameBuffer = new FrameBuffer(c_SecondSceneWidth, c_SecondSceneHeight, 0);
        mSecondRenderedTexture = new Texture(TextureShape.Texture2D, PixelFormat.RGBA8888, c_SecondSceneWidth, c_SecondSceneHeight);
        mSecondFrameBuffer.AttachColorTexture(mSecondRenderedTexture);
        mSecondRenderTask.SetFrameBuffer(mSecondFrameBuffer);

        var firstFrameBufferUrl = mFirstFrameBuffer.GenerateUrl(0u);

        View secondSceneRoot = new View()
        {
            Size = new Size(c_FirstSceneWidth * 0.75f, c_FirstSceneHeight * 0.75f),
            Position = new Position(0, 0),
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
            BackgroundImage = firstFrameBufferUrl.ToString(),
        };

        mSecondRenderTask.SetSourceView(secondSceneRoot);

        mWindow.Add(camera);
        mWindow.Add(secondSceneRoot);

        mSecondSceneAnimation = new Animation(3000);
        mSecondSceneAnimation.AnimateBy(secondSceneRoot, "Orientation", new Rotation(new Radian((float)Math.PI * 2.0f), Vector3.YAxis));
        mSecondSceneAnimation.Looping = true;
        mSecondSceneAnimation.Play();

        AttachViewer(mSecondRenderedTexture, new Size(c_SecondSceneWidth, c_SecondSceneHeight), new Position(20 + c_FirstSceneWidth, 10));
    }
    #endregion

    #region Third Scene Creation
    private RenderTask mThirdRenderTask; // Must have reference. Dispose will remove rendering automatically
    private FrameBuffer mThirdFrameBuffer;
    private Texture mThirdRenderedTexture;
    private Texture mThirdDepthTexture;

    const uint c_ThirdSceneWidth = 450u;
    const uint c_ThirdSceneHeight = 400u;

    private Animation mThirdSceneAnimation;
    private void CreateThirdScene()
    {
        mThirdRenderTask = mRenderTaskList.CreateTask();

        mThirdRenderTask.SetExclusive(true);
        mThirdRenderTask.SetClearEnabled(true);
        mThirdRenderTask.SetCullMode(false); // Allways rendering even if scene is out of camera.
        mThirdRenderTask.SetRefreshRate(1); // Refresh always

        mThirdRenderTask.ClearColor = Vector4.Zero;
        mThirdRenderTask.OrderIndex = mSecondRenderTask.OrderIndex + 1;

        // TODO : Tizen.NUI.Camera is deprecated! Need to find more good way to support it.
        Tizen.NUI.Camera camera = new Tizen.NUI.Camera()
        {
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
        };
        camera.SetPerspectiveProjection(new Vector2(c_ThirdSceneWidth, c_ThirdSceneHeight));
        camera.SetInvertYAxis(true);

        mThirdRenderTask.SetCamera(camera);

        mThirdFrameBuffer = new FrameBuffer(c_ThirdSceneWidth, c_ThirdSceneHeight, 0);
        mThirdRenderedTexture = new Texture(TextureShape.Texture2D, PixelFormat.RGBA8888, c_ThirdSceneWidth, c_ThirdSceneHeight);
        mThirdFrameBuffer.AttachColorTexture(mThirdRenderedTexture);
        mThirdRenderTask.SetFrameBuffer(mThirdFrameBuffer);

        View thirdSceneRoot = new View()
        {
            Size = new Size(c_ThirdSceneWidth, c_ThirdSceneHeight),
            Position = new Position(0, 0),
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
        };

        thirdSceneRoot.AddRenderable(GenerateThirdRenderable());

        mThirdRenderTask.SetSourceView(thirdSceneRoot);

        mWindow.Add(camera);
        mWindow.Add(thirdSceneRoot);

        mThirdSceneAnimation = new Animation(3000);
        mThirdSceneAnimation.AnimateBy(thirdSceneRoot.GetRenderableAt(0u).Shader, "uDelta", (float)Math.PI * 2.0f);
        mThirdSceneAnimation.Looping = true;
        mThirdSceneAnimation.Play();

        AttachViewer(mThirdRenderedTexture, new Size(c_ThirdSceneWidth, c_ThirdSceneHeight), new Position(10, 20 + c_SecondSceneHeight));
    }

    private Renderable GenerateThirdRenderable()
    {
        Renderable renderer = new Renderable();
        renderer.Geometry = GenerateGeometry();
        renderer.Shader = GenerateShader();

        TextureSet textureSet = new TextureSet();
        Sampler sampler = new Sampler();
        sampler.SetWrapMode(WrapModeType.MirroredRepeat, WrapModeType.MirroredRepeat);
        textureSet.SetTexture(0u, mSecondRenderedTexture);
        textureSet.SetSampler(0u, sampler);
        renderer.TextureSet = textureSet;
        return renderer;
    }
    
    struct SimpleQuadVertex
    {
        public UIVector2 position;
    }

    private PropertyBuffer CreateQuadPropertyBuffer()
    {
        /* Create Property buffer */
        PropertyMap vertexFormat = new PropertyMap();
        vertexFormat.Add("aPosition", new PropertyValue((int)PropertyType.Vector2));

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
        string vertexShader =
        "//@name GenerateThirdRenderable.vert\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision highp float;\n"+
        "INPUT highp vec2 aPosition;\n" +
        "OUTPUT highp vec2 vTexCoord;\n" +
        "\n" +
        "UNIFORM_BLOCK VertBlock\n" +
        "{\n" +
        "  UNIFORM highp mat4 uMvpMatrix;\n" +
        "  UNIFORM highp vec3 uSize;\n" +
        "};\n" +
        "void main()\n" +
        "{\n" +
        "    vTexCoord = aPosition + vec2(0.5);\n" +
        "    vec4 pos = vec4(aPosition, 0.0, 1.0) * vec4(uSize.x, uSize.y, 0.0, 1.0);\n" +
        "    gl_Position = uMvpMatrix * pos;\n" +
        "}\n";

        string fragmentShader =
        "//@name GenerateThirdRenderable.frag\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision highp float;\n"+
        "INPUT highp vec2 vTexCoord;\n" +
        "\n" +
        "UNIFORM sampler2D sTexture;\n" +
        "UNIFORM_BLOCK FragBlock\n" +
        "{\n" +
        "  UNIFORM highp float uDelta;\n" +
        "  UNIFORM lowp vec4 uColor;\n" +
        "};\n" +
        "\n" +
        "void main()\n" +
        "{\n" +
        "    highp vec2 pos = -1.0 + 2.0 * vTexCoord;\n" +
        "    highp float len = length(pos);\n" +
        "    highp float height = sin( len * 12.0 - uDelta * 4.0 );\n" +
        "    highp vec2 texCoord = vTexCoord + pos/len * height * 0.02;\n" +
        "    lowp vec4 texColor = TEXTURE(sTexture, texCoord);\n" +
        "    texColor.rgb *= (0.9 + height * 0.1);\n" +
        "    gl_FragColor = texColor * uColor;\n" +
        "}\n";

        Shader shader = new Shader(vertexShader, fragmentShader, "GenerateThirdRenderable");
        shader.RegisterProperty("uDelta", new PropertyValue(0.0f));
        return shader;
    }
    #endregion

    public void Activate()
    {
        mWindow = Window.Default;
        mWindow.BackgroundColor = Color.White;
        mWindowSize = mWindow.WindowSize;

        mWindow.Resized += OnResized;
        mWindow.KeyEvent += OnKeyEvent;

        mRenderTaskList = mWindow.GetRenderTaskList();

        CreateFirstScene();
        CreateSecondScene();
        CreateThirdScene();
    }

    public void Deactivate()
    {
        if (mWindow != null)
        {
            mWindow.KeyEvent -= OnKeyEvent;
            mWindow.Resized -= OnResized;
            mWindow = null;
        }
    }

    protected override void OnCreate()
    {
        // Up call to the Base class first
        base.OnCreate();
        Activate();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        MultiPassRenderingSample example = new MultiPassRenderingSample();
        example.Run(args);
    }
}
