using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class ConstraintWithCustomShaderTest : IExample
    {
        static readonly string VERTEX_SHADER =
        "//@name ConstraintWithCustomShaderTest.vert\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision highp float;\n" +
        "INPUT highp vec2 aPosition;\n" +
        "OUTPUT highp vec2 vPosition;\n" +
        "FLAT OUTPUT highp float vCornerRadius;\n" +
        "\n" +
        "UNIFORM_BLOCK VertBlock\n" +
        "{\n" +
        "  UNIFORM highp mat4 uMvpMatrix;\n" +
        "  UNIFORM highp float uCornerRadius;\n" +
        "};\n" +
        "UNIFORM_BLOCK SharedBlock\n" +
        "{\n" +
        "  UNIFORM highp vec3 uSize;\n" +
        "}\n" +
        "void main()\n" +
        "{\n" +
        "    vec4 pos = vec4(aPosition, 0.0, 1.0) * vec4(uSize.xy, 0.0, 1.0);\n" +
        "    vPosition = (aPosition + vec2(0.5)) * uSize.xy;\n" +
        "    vCornerRadius = max(0.0, min(uCornerRadius, min(uSize.x, uSize.y)));\n" +
        "\n" +
        "    gl_Position = uMvpMatrix * pos;\n" +
        "}\n";

        static readonly string FRAGMENT_SHADER =
        "//@name ConstraintWithCustomShaderTest.frag\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision highp float;\n" +
        "INPUT highp vec2 vPosition;\n" +
        "FLAT INPUT highp float vCornerRadius;\n" +
        "\n" +
        "UNIFORM_BLOCK SharedBlock\n" +
        "{\n" +
        "  UNIFORM highp vec3 uSize;\n" +
        "}\n" +
        "UNIFORM_BLOCK FragBlock\n" +
        "{\n" +
        "  UNIFORM lowp vec4 uColor;\n" +
        "  UNIFORM highp vec2 CursorPosition;\n" +
        "  UNIFORM highp float uCornerSquareness;\n" +
        "  UNIFORM highp float uCustomCursorRadius;\n" +
        "};\n" +
        "\n" +
        "// Simplest CornerRadius implements\n" +
        "float roundedBoxSDF(vec2 pixelPositionFromCenter, vec2 rectangleEdgePositionFromCenter, float radius, float squareness) {\n" +
        "  highp vec2 diff = pixelPositionFromCenter\n" +
        "                    - rectangleEdgePositionFromCenter\n" +
        "                    + radius;\n" +
        "\n" +
        "  // If squareness is near 1.0 or 0.0, it make some numeric error. Let we avoid this situation by heuristic value.\n" +
        "  if(squareness < 0.01)\n" +
        "  {\n" +
        "    return length(max(diff, 0.0)) + min(0.0, max(diff.x, diff.y)) - radius;\n" +
        "  }\n" +
        "  if(squareness > 0.99)\n" +
        "  {\n" +
        "    return max(diff.x, diff.y) - radius;\n" +
        "  }\n" +
        "\n" +
        "  highp vec2 positiveDiff = max(diff, 0.0);\n" +
        "\n" +
        "  // make sqr to avoid duplicate codes.\n" +
        "  positiveDiff *= positiveDiff;\n" +
        "\n" +
        "  // TODO : Could we remove this double-sqrt code?\n" +
        "  return sqrt(((positiveDiff.x + positiveDiff.y)\n" +
        "               + sqrt(positiveDiff.x * positiveDiff.x\n" +
        "                      + positiveDiff.y * positiveDiff.y\n" +
        "                      + (2.0 - 4.0 * squareness * squareness) * positiveDiff.x * positiveDiff.y))\n" +
        "              * 0.5)\n" +
        "         + min(0.0, max(diff.x, diff.y)) ///< Consider negative potential, to avoid visual defect when radius is zero\n" +
        "         - radius;\n" +
        "}\n" +
        "\n" +
        "void main()\n" +
        "{\n" +
        "    highp float dist = length(vPosition - CursorPosition);\n" +
        "    dist /= uCustomCursorRadius;\n" +
        "    gl_FragColor = uColor * vec4(dist, 0.0, 1.0, 1.0);\n" +
        " \n" +
        "    highp vec2 location = abs(vPosition.xy - vec2(0.5) * uSize.xy);\n" +
        "    highp vec2 halfSize = uSize.xy * 0.5;\n" +
        "    highp float radius = vCornerRadius;\n" +
        "    highp float edgeSoftness = min(1.0, radius);" +
        "\n" +
        "    highp float signedDistance = roundedBoxSDF(location, halfSize, radius, uCornerSquareness);\n" +
        "    mediump float smoothedAlpha = 1.0 - smoothstep(-edgeSoftness, edgeSoftness, signedDistance);\n" +
        "\n" +
        "    gl_FragColor.a *= smoothedAlpha;\n" +
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

        private enum ConstraintBehaviorType
        {
            None = 0,
            Noise,
            Max,
        };
        private static ConstraintBehaviorType constraintType;
        private static float gWindowWidth = 0.0f;
        private static float gWindowHeight = 0.0f;
        private static Random rand = new Random();

        private static object lockObject = new object();

        private const bool _printLogs = false; // Make it true if you want to see the logs

        private static UIVector2 OnConstraintVector2(UIVector2 current, uint id, in PropertyInputContainer container)
        {
            float viewWidth = container.GetFloat(0u);
            float viewHeight = container.GetFloat(1u);
            UIVector3 viewPosition = container.GetVector3(2u);
            UIColor viewColor = container.GetColor(3u);
            using Rotation viewRotation = container.GetRotation(4u);
            using Matrix viewModelMatrix = container.GetMatrix(5u);

            float hoveViewX = container.GetFloat(6u);
            float hoveViewY = container.GetFloat(7u);

            using Vector3 axis = new Vector3();
            using Radian angle = new Radian();
            bool converted = viewRotation.GetAxisAngle(axis, angle);

            ConstraintBehaviorType type;
            lock (lockObject)
            {
                type = constraintType;
            }

            UIVector2 result = new UIVector2(hoveViewX - viewPosition.X + viewWidth * 0.5f, hoveViewY - viewPosition.Y + viewHeight * 0.5f);
            switch(type)
            {
                case ConstraintBehaviorType.Noise:
                {
                    result = new UIVector2(result.X + rand.Next(-1000, 1000) * 0.01f, result.Y + rand.Next(-1000, 1000) * 0.01f);
                    break;
                }
                default:
                {
                    // Do nothing.
                    break;
                }
            }

            if (_printLogs)
            {
                Tizen.Log.Error("NUI", $"ID : {id}, container size : {container.Count}, current : {current.X}, {current.Y}\n");
                Tizen.Log.Error("NUI", $"w:{viewWidth} h:{viewHeight}, x:{viewPosition.X}, y:{viewPosition.Y}, z:{viewPosition.Z}\n");
                Tizen.Log.Error("NUI", $"r:{viewColor.R} g:{viewColor.G}, b:{viewColor.B}, a:{viewColor.A}\n");
                Tizen.Log.Error("NUI", $"{converted} / angle:{angle.Value} axis:{axis.X}, {axis.Y}, {axis.Z}\n");
                Tizen.Log.Error("NUI", $"hover : {hoveViewX}, {hoveViewY}\n");

                Tizen.Log.Error("NUI", $"  Model Matrix :\n");
                for (uint i = 0; i < 4; i++)
                {
                    Tizen.Log.Error("NUI", $"  {viewModelMatrix.ValueOfIndex(i, 0)}, {viewModelMatrix.ValueOfIndex(i, 1)}, {viewModelMatrix.ValueOfIndex(i, 2)}, {viewModelMatrix.ValueOfIndex(i, 3)}\n");
                }
                Tizen.Log.Error("NUI", $"ID : {id}, result : {result.X}, {result.Y}\n");
            }

            return result;
        }

        private static float OnConstraintFloat(float current, uint id, in PropertyInputContainer container)
        {
            float result = container.GetVector4(0u).X;
            if(container.Count > 1)
            {
                switch((VisualTransformPolicyType)container.GetInteger(1u))
                {
                    case VisualTransformPolicyType.Relative:
                    {
                        result *= Math.Min(container.GetFloat(2u), container.GetFloat(3u));
                        break;
                    }
                    case VisualTransformPolicyType.Absolute:
                    {
                        break;
                    }
                }
            }

            if (_printLogs)
            {
                Tizen.Log.Error("NUI", $"ID : {id}, container size : {container.Count}, current : {current}, input : {container.GetVector4(0u).X}, result : {result}\n");
                if(container.Count > 1)
                {
                    Tizen.Log.Error("NUI", $"Type : {container.GetPropertyType(1u)}, value : {container.GetInteger(1u)}\n");
                    switch((VisualTransformPolicyType)container.GetInteger(1u))
                    {
                        case VisualTransformPolicyType.Relative:
                        {
                            Tizen.Log.Error("NUI", $"Relative\n");
                            break;
                        }
                        case VisualTransformPolicyType.Absolute:
                        {
                            Tizen.Log.Error("NUI", $"Absolute\n");
                            break;
                        }
                    }
                }
            }
            return result;
        }

        private static Rotation OnConstraintRotation(in Rotation current, uint id, in PropertyInputContainer container)
        {
            float windowWidth, windowHeight;
            lock (lockObject)
            {
                windowWidth = gWindowWidth;
                windowHeight = gWindowHeight;
            }
            float cursorX = container.GetFloat(0u) / windowWidth;
            float cursorY = container.GetFloat(1u) / windowHeight;

            using Radian pitch = new Radian(-cursorY * 0.2f);
            using Radian yaw = new Radian(cursorX * 0.2f);
            using Radian roll = new Radian(0.0f);
            Rotation rotation = new Rotation(pitch, yaw, roll);
            if (_printLogs)
            {
                Tizen.Log.Error("NUI", $"ID : {id}, container size : {container.Count}, cursor pos : {cursorX}, {cursorY}\n");

                using Vector3 axis = new Vector3();
                using Radian angle = new Radian();
                bool converted = current.GetAxisAngle(axis, angle);
                Tizen.Log.Error("NUI", $"Current : {converted} / angle:{angle.Value} axis:{axis.X}, {axis.Y}, {axis.Z}\n");

                converted = rotation.GetAxisAngle(axis, angle);
                Tizen.Log.Error("NUI", $"Result : {converted} / angle:{angle.Value} axis:{axis.X}, {axis.Y}, {axis.Z}\n");
            }
            return rotation;
        }

        private Window win;
        private View root;
        private Layer overlayLayer;

        private View view; // Custom renderable holder
        private View hoverView;

        private static Geometry geometry;
        private static Shader shader;
        private Renderable renderable;

        private Constraint constraint;
        private bool constraintApplied;

        private Constraint cornerConstraint;
        private Constraint cornerConstraint2;

        private Constraint orientationConstraint;

        private Animation radiusAnimation;

        private Animation cursorMoveAnimation;
        private int cursorPositionIndex;

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();

            lock (lockObject)
            {
                gWindowWidth = win.Size.Width;
                gWindowHeight = win.Size.Height;
            }

            win.OrientationChanged += OnWindowOrientationChangedEvent;
            win.Resized += WindowResized;
            win.KeyEvent += WindowKeyEvent;

            root = new View()
            {
                Name = "root",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            win.Add(root);

            CreateCustomRenderableView();
            GenerateConstraint();

            var infoLabel = new TextLabel()
            {
                Text = "Constraint the mouse cursor position, and use this value as custom shader uniform.\n" +
                       "If touch down and release, curosr position animate.\n" +
                       "\n" +
                       "  Press 0 to give noise at cursor constraint result\n" +
                       "  Press 1 to test re-generate new constraints\n" +
                       "  Press 2 to test Apply / Remove cursor constraint\n" +
                       "  Press 3 to test re-generate source view\n" +
                       "  Press 4 to test re-generate target renderer\n" +
                       "  Press 5 to test corner radius / squareness change of view\n",
                MultiLine = true,
            };
            overlayLayer = new Layer();
            win.AddLayer(overlayLayer);
            overlayLayer.Add(infoLabel);
        }

        public void Deactivate()
        {
            root?.Unparent();
            root?.DisposeRecursively();

            if (constraint != null)
            {
                Tizen.Log.Error("NUI", $"Constraint with ID : {constraint.ID} will be Disposed(), but callback could be comes after now\n");
                constraint?.Dispose();
            }

            if (cornerConstraint != null)
            {
                Tizen.Log.Error("NUI", $"Constraint with ID : {cornerConstraint.ID} will be Disposed(), but callback could be comes after now\n");
                cornerConstraint?.Dispose();
            }

            if (cornerConstraint2 != null)
            {
                Tizen.Log.Error("NUI", $"Constraint with ID : {cornerConstraint2.ID} will be Disposed(), but callback could be comes after now\n");
                cornerConstraint2?.Dispose();
            }

            if (orientationConstraint != null)
            {
                Tizen.Log.Error("NUI", $"Constraint with ID : {orientationConstraint.ID} will be Disposed(), but callback could be comes after now\n");
                orientationConstraint?.Dispose();
            }

            if (overlayLayer != null)
            {
                win?.RemoveLayer(overlayLayer);
            }

            renderable?.Dispose();
            overlayLayer?.Dispose();

            if (win != null)
            {
                win.OrientationChanged -= OnWindowOrientationChangedEvent;
                win.Resized -= WindowResized;
                win.KeyEvent -= WindowKeyEvent;
            }
        }

        private void OnWindowOrientationChangedEvent(object sender, WindowOrientationChangedEventArgs e)
        {
            Window.WindowOrientation orientation = e.WindowOrientation;
            Tizen.Log.Error("NUI", $"OnWindowOrientationChangedEvent() called!, orientation:{orientation}");
        }

        private void WindowResized(object sender, Window.ResizedEventArgs e)
        {
            lock (lockObject)
            {
                gWindowWidth = e.WindowSize.Width;
                gWindowHeight = e.WindowSize.Height;
            }
            Tizen.Log.Error("NUI", $"Window resized : {gWindowWidth}, {gWindowHeight}\n");
        }

        private void WindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "0")
                {
                    lock (lockObject)
                    {
                        constraintType = (ConstraintBehaviorType)(((int)constraintType + 1) % ((int)ConstraintBehaviorType.Max));

                        Tizen.Log.Error("NUI", $"Constraint : {constraint.ID} will act by {constraintType}\n");
                    }
                }
                if (e.Key.KeyPressedName == "1")
                {
                    GenerateConstraint();
                }
                if (e.Key.KeyPressedName == "2")
                {
                    ToggleConstraintActivation();
                }
                if (e.Key.KeyPressedName == "3")
                {
                    RegenerateView();
                }
                if (e.Key.KeyPressedName == "4")
                {
                    RegenerateRenderable();
                }
                if (e.Key.KeyPressedName == "5")
                {
                    float v = view.CornerRadius.X;
                    view.CornerRadius = 0.35f - v;
                }
            }
        }

        private void CreateCustomRenderableView()
        {
            view = new View()
            {
                SizeWidth = 300,
                SizeHeight = 500,
                PositionX = 50,
                PositionY = 100,

                CornerRadius = 0.35f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                CornerSquareness = 0.6f,
            };

            hoverView = new View()
            {
                BackgroundColor = Color.Black,
                SizeWidth = 4,
                SizeHeight = 4,
                PositionX = 200,
                PositionY = 350,
            };

            cursorMoveAnimation = new Animation(500);

            root.HoverEvent += (o, e) =>
            {
                //if (cursorMoveAnimation.State == Animation.States.Stopped)
                {
                    using var localPosition = e.Hover.GetLocalPosition(0u);
                    hoverView.PositionX = localPosition.X;
                    hoverView.PositionY = localPosition.Y;
                }
                return true;
            };

            root.TouchEvent += (o, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    cursorMoveAnimation.Stop();
                    cursorMoveAnimation.Clear();
                }
                else if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    cursorMoveAnimation.Stop();
                    cursorMoveAnimation.Clear();

                    // Reverse the animation localPosition -> currentPosition.
                    // If than, it will works like currentPositoin -> latest position what updated by Hover
                    using var localPosition = e.Touch.GetLocalPosition(0u);
                    cursorMoveAnimation.AnimateTo(hoverView, "PositionX", hoverView.PositionX, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutBack));
                    cursorMoveAnimation.AnimateTo(hoverView, "PositionY", hoverView.PositionY, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutBack));
                    cursorMoveAnimation.SpeedFactor = -1;
                    cursorMoveAnimation.Play();

                    hoverView.PositionX = localPosition.X;
                    hoverView.PositionY = localPosition.Y;
                }
                return true;
            };

            renderable = GenerateRenderable();
            view.AddRenderable(renderable);

            root.Add(view);
            root.Add(hoverView);
        }

        private void GenerateConstraint()
        {
            if (constraint != null)
            {
                Tizen.Log.Error("NUI", $"Constraint with ID : {constraint.ID} will be Disposed(), but callback could be comes after now\n");
                constraint.Dispose();
            }

            // Create constraint for renderable
            // Note that we cannot use "CursorPosition" as input of property name, because
            // the first charactor of property name become lower case internally.
            // To avoid this situation, we should use the index of property.
            constraint = Constraint.GenerateConstraint(renderable, cursorPositionIndex, new Constraint.ConstraintVector2FunctionCallbackType(OnConstraintVector2));
            constraint.AddSource(view, "SizeWidth");
            constraint.AddSource(view, "SizeHeight");
            constraint.AddSource(view, view.GetPropertyIndex("WorldPosition")); // Test for Vector3
            constraint.AddSource(view, view.GetPropertyIndex("Color")); // Test for Vector4
            constraint.AddSource(view, view.GetPropertyIndex("Orientation")); // Test for rotation
            constraint.AddSource(view, view.GetPropertyIndex("WorldMatrix")); // Test for matrix
            constraint.AddSource(hoverView, "WorldPositionX");
            constraint.AddSource(hoverView, hoverView.GetPropertyIndex("WorldPositionY"));
            constraint.Apply();

            cornerConstraint?.Dispose();
            cornerConstraint2?.Dispose();
            orientationConstraint?.Dispose();
            cornerConstraint = null;
            cornerConstraint2 = null;
            orientationConstraint = null;

            // Set corner radius as input of constraints
            cornerConstraint = Constraint.GenerateConstraint(renderable, "uCornerRadius", new Constraint.ConstraintFloatFunctionCallbackType(OnConstraintFloat));
            cornerConstraint.AddSource(view, "viewCornerRadius");
            cornerConstraint.AddSource(view, "viewCornerRadiusPolicy");
            cornerConstraint.AddSource(view, "sizeWidth");
            cornerConstraint.AddSource(view, "sizeHeight");
            cornerConstraint.Apply();

            // Note that the first charactor of property name become lower case internally.
            // Here, "UCornerSquareness" -> "uCornerSquareness", "ViewCornerSquareness" -> "viewcornerSquareness"
            cornerConstraint2 = Constraint.GenerateConstraint(renderable, "UCornerSquareness", new Constraint.ConstraintFloatFunctionCallbackType(OnConstraintFloat));
            cornerConstraint2.AddSource(view, "ViewCornerSquareness");
            cornerConstraint2.Apply();

            // Set orientation as input of constraints
            orientationConstraint = Constraint.GenerateConstraint(view, "Orientation", new Constraint.ConstraintRotationFunctionCallbackType(OnConstraintRotation));
            orientationConstraint.AddSource(hoverView, "worldPositionX");
            orientationConstraint.AddSource(hoverView, "WorldPositionY");
            orientationConstraint.Apply();

            constraintApplied = true;

            Tizen.Log.Error("NUI", $"Constraint with ID : {constraint.ID} {cornerConstraint.ID} {cornerConstraint2.ID} {orientationConstraint.ID} Created and applied\n");
        }

        private void ToggleConstraintActivation()
        {
            if (constraint != null)
            {
                if (constraintApplied)
                {
                    constraint.Remove();
                    Tizen.Log.Error("NUI", $"Constraint with ID : {constraint.ID} removed\n");
                }
                else
                {
                    constraint.Apply();
                    Tizen.Log.Error("NUI", $"Constraint with ID : {constraint.ID} applied\n");
                }
                constraintApplied ^= true;
            }
        }

        private void RegenerateView()
        {
            view.Dispose();
            hoverView.Dispose();

            view = new View()
            {
                SizeWidth = 300,
                SizeHeight = 500,
                PositionX = 50,
                PositionY = 100,

                CornerRadius = 0.35f,
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                CornerSquareness = 0.6f,
            };

            hoverView = new View()
            {
                BackgroundColor = Color.Black,
                SizeWidth = 4,
                SizeHeight = 4,
                PositionX = 200,
                PositionY = 350,
            };

            view.AddRenderable(renderable);
            root.Add(view);
            root.Add(hoverView);

            if (constraint != null)
            {
                Tizen.Log.Error("NUI", $"Constraint with ID : {constraint.ID} {orientationConstraint.ID} {cornerConstraint.ID} {cornerConstraint2.ID} invalidate after RenderThread object destroyed\n");
            }
        }

        private void RegenerateRenderable()
        {
            view.RemoveRenderable(renderable);
            renderable.Dispose();

            renderable = GenerateRenderable();
            view.AddRenderable(renderable);

            if (constraint != null)
            {
                Tizen.Log.Error("NUI", $"Constraint with ID : {constraint.ID} {cornerConstraint.ID} {cornerConstraint2.ID} invalidate after RenderThread object destroyed\n");
            }
        }

        private Geometry GenerateGeometry()
        {
            if (geometry == null)
            {
                using PropertyBuffer vertexBuffer = CreateQuadPropertyBuffer();
                geometry = new Geometry();
                geometry.AddVertexBuffer(vertexBuffer);
                geometry.SetType(Geometry.Type.TRIANGLE_STRIP);
            }
            return geometry;
        }

        private Shader GenerateShader()
        {
            if (shader == null)
            {
                shader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER, "ConstraintWithCustomShaderTest");
            }
            return shader;
        }

        private Renderable GenerateRenderable()
        {
            if (renderable == null)
            {
                renderable = new Renderable()
                {
                    Geometry = GenerateGeometry(),
                    Shader = GenerateShader(),
                };

                // Note that if the first charactor of custom registered property name is not lower case,
                // We cannot access to that property by name.
                // In this case, we should keep the index of property to access, or animate, or constraint it.
                cursorPositionIndex = renderable.RegisterProperty("CursorPosition", new PropertyValue(100.0f, 200.0f));

                renderable.RegisterProperty("uCustomCursorRadius", new PropertyValue(300.0f));
                renderable.RegisterProperty("uCornerRadius", new PropertyValue(0.0f));
                renderable.RegisterProperty("uCornerSquareness", new PropertyValue(0.0f));

                //renderable.BlendPreMultipliedAlpha = true;
                renderable.BlendMode = BlendMode.On;

                radiusAnimation = new Animation(10000);
                radiusAnimation.LoopingMode = Animation.LoopingModes.AutoReverse;
                radiusAnimation.Looping = true;
                radiusAnimation.AnimateTo(renderable, "uCustomCursorRadius", 50.0f, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOutSine));
                radiusAnimation.Play();
            }

            return renderable;
        }
    }
}
