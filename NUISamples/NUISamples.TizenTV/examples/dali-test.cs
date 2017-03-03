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
using Dali;

namespace MyCSharpExample
{
    class Example
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void CallbackDelegate(IntPtr appPtr); // void, void delgate

        private Dali.Application _application;

        public Example(Dali.Application application)
        {
            _application = application;
            Console.WriteLine( "InitSignal connection count = " + _application.InitSignal().GetConnectionCount() );

            _application.Initialized += Initialize;
            Console.WriteLine( "InitSignal connection count = " + _application.InitSignal().GetConnectionCount() );
        }

        public void Initialize(object source, NUIApplicationInitEventArgs e)
        {
            OperatorTests();

            CustomViewPropertyTest();

            Handle handle = new Handle();
            int myPropertyIndex = handle.RegisterProperty("myProperty", new Property.Value(10.0f), Property.AccessMode.READ_WRITE);
            float myProperty = 0.0f;
            handle.GetProperty(myPropertyIndex).Get(ref myProperty);
            Console.WriteLine( "myProperty value: " + myProperty );

            int myPropertyIndex2 = handle.RegisterProperty("myProperty2", new Property.Value(new Size(5.0f, 5.0f)), Property.AccessMode.READ_WRITE);
            Size myProperty2 = new Size(0.0f, 0.0f);
            handle.GetProperty(myPropertyIndex2).Get(myProperty2);
            Console.WriteLine( "myProperty2 value: " + myProperty2.W + ", " + myProperty2.H );

            Actor actor = new Actor();
            actor.Size = new Position(200.0f, 200.0f, 0.0f);
            actor.Name = "MyActor";
            actor.Color = new Color(1.0f, 0.0f, 1.0f, 0.8f);
            Console.WriteLine("Actor id: {0}", actor.GetId());
            Console.WriteLine("Actor size: " + actor.Size.X + ", " + actor.Size.Y);
            Console.WriteLine("Actor name: " + actor.Name);

            Stage stage = Stage.GetCurrent();
            stage.BackgroundColor = Color.White;
            Size stageSize = stage.Size;
            Console.WriteLine("Stage size: " + stageSize.W + ", " + stageSize.H);
            stage.Add(actor);

            TextLabel text = new TextLabel("Hello Mono World");
            text.ParentOrigin = NDalic.ParentOriginCenter;
            text.AnchorPoint = NDalic.AnchorPointCenter;
            text.HorizontalAlignment = "CENTER";
            stage.Add(text);

            Console.WriteLine( "Text label text:  " + text.Text );

            Console.WriteLine( "Text label point size:  " + text.PointSize );
            text.PointSize = 32.0f;
            Console.WriteLine( "Text label new point size:  " + text.PointSize );

            RectanglePaddingClassTest();

            Console.WriteLine( " *************************" );
            Size Size = new Size(100, 50);
            Console.WriteLine( "    Created " + Size );
            Console.WriteLine( "    Size x =  " + Size.W + ", y = " + Size.H );
            Size += new Size(20, 20);
            Console.WriteLine( "    Size x =  " + Size.W + ", y = " + Size.H );
            Size.W += 10;
            Size.H += 10;
            Console.WriteLine( "    Size width =  " + Size.W + ", height = " + Size.H );

            Console.WriteLine( " *************************" );
            Position Position = new Position(20, 100, 50);
            Console.WriteLine( "    Created " + Position );
            Console.WriteLine( "    Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z );
            Position += new Position(20, 20, 20);
            Console.WriteLine( "    Position x =  " + Position.X + ", y = " + Position.Y + ", z = " + Position.Z );
            Position.X += 10;
            Position.Y += 10;
            Position.Z += 10;
            Console.WriteLine( "    Position width =  " + Position.X + ", height = " + Position.Y + ", depth = " + Position.Z );
            Position parentOrigin = new Dali.Position(NDalic.ParentOriginBottomRight);
            Console.WriteLine( "    parentOrigin x =  " + parentOrigin.X + ", y = " + parentOrigin.Y + ", z = " + parentOrigin.Z );

            Console.WriteLine( " *************************" );
            Color color = new Color(20, 100, 50, 200);
            Console.WriteLine( "    Created " + color );
            Console.WriteLine( "    Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A );
            color += new Color(20, 20, 20, 20);
            Console.WriteLine( "    Color R =  " + color.R + ", G = " + color.G + ", B = " + color.B + ", A = " + color.A );
            color.R += 10;
            color.G += 10;
            color.B += 10;
            color.A += 10;
            Console.WriteLine( "    Color r =  " + color.R + ", g = " + color.G + ", b = " + color.B + ", a = " + color.A );
        }

        public void RectanglePaddingClassTest()
        {
            using (Rectangle r1 = new Rectangle(2, 5, 20, 30))
            {
                Console.WriteLine( "    Created " + r1 );
                Console.WriteLine( "    IsEmpty() =  " + r1.IsEmpty() );
                Console.WriteLine( "    Left =  " + r1.Left() );
                Console.WriteLine( "    Right =  " + r1.Right() );
                Console.WriteLine( "    Top  = " + r1.Top() );
                Console.WriteLine( "    Bottom  = " + r1.Bottom() );
                Console.WriteLine( "    Area  = " + r1.Area() );
            }

            Console.WriteLine( " *************************" );

            using (Rectangle r2 = new Rectangle(2, 5, 20, 30))
            {
                Console.WriteLine( "    Created " + r2 );
                r2.Set(1,1,40,40);
                Console.WriteLine( "    IsEmpty() =  " + r2.IsEmpty() );
                Console.WriteLine( "    Left =  " + r2.Left() );
                Console.WriteLine( "    Right =  " + r2.Right() );
                Console.WriteLine( "    Top  = " + r2.Top() );
                Console.WriteLine( "    Bottom  = " + r2.Bottom() );
                Console.WriteLine( "    Area  = " + r2.Area() );
            }

            Console.WriteLine( " *************************" );

            Rectangle r3 = new Rectangle(10, 10, 20, 20);
            Rectangle r4 = new Rectangle(10, 10, 20, 20);

            if (r3 == r4)
            {
                Console.WriteLine("r3 == r4");
            }
            else
            {
                Console.WriteLine("r3 != r4");
            }

            r4 = new Rectangle(12, 10, 20, 20);

            if (r3 == r4)
            {
                Console.WriteLine("r3 == r4");
            }
            else
            {
                Console.WriteLine("r3 != r4");
            }

            PaddingType p1 = new PaddingType(10.5f, 10.7f, 20.8f, 20.8f);
            PaddingType p2 = new PaddingType(10.5f, 10.7f, 20.8f, 20.8f);

            if (p1 == p2)
            {
                Console.WriteLine("p1 == p2");
            }
            else
            {
                Console.WriteLine("p1 != p2");
            }

            p2 = new PaddingType(12.0f, 10.7f, 20.2f, 20.0f);

            if (p1 == p2)
            {
                Console.WriteLine("p1 == p2");
            }
            else
            {
                Console.WriteLine("p1 != p2");
            }
        }

        public void OperatorTests()
        {
            Actor actor = new Actor();
            Actor differentActor = new Actor();
            Actor actorSame = actor;
            Actor nullActor = null;

            // test the true operator
            if ( actor )
            {
                Console.WriteLine ("BaseHandle Operator true (actor) : test passed ");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator true (actor): test failed ");
            }

            Actor parent = actor.GetParent ();

            if ( parent )
            {
                Console.WriteLine ("Handle with Empty body  :failed ");
            }
            else
            {
                Console.WriteLine ("Valid with Empty body  :passed ");
            }

            actor.Add( differentActor );

            // here we test two different C# objects, which on the native side have the same body/ ref-object
            if ( actor == differentActor.GetParent() )
            {
                Console.WriteLine ("actor == differentActor.GetParent() :passed ");
            }
            else
            {
                Console.WriteLine ("actor == differentActor.GetParent() :failed ");
            }

            if ( differentActor == differentActor.GetParent() )
            {
                Console.WriteLine ("differentActor == differentActor.GetParent() :failed ");
            }
            else
            {
                Console.WriteLine ("differentActor == differentActor.GetParent() :passed ");
            }

            if ( nullActor )
            {
                Console.WriteLine ("BaseHandle Operator true (nullActor) : test failed ");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator true (nullActor): test passed ");
            }

            // ! operator
            if ( !actor )
            {
                Console.WriteLine ("BaseHandle Operator !(actor) : test failed ");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator !(actor): test passed ");
            }

            if ( !nullActor )
            {
                Console.WriteLine ("BaseHandle Operator !(nullActor) : test passed ");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator !(nullActor): test failed ");
            }

            // Note: operator false only used inside & operator
            // test equality operator ==
            if ( actor == actorSame )
            {
                Console.WriteLine ("BaseHandle Operator  (actor == actorSame) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator  (actor == actorSame) : test failed");
            }

            if ( actor == differentActor )
            {
                Console.WriteLine ("BaseHandle Operator (actor == differentActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor == differentActor) : test passed");
            }

            if ( actor == nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (actor == nullActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor == nullActor) : test passed");
            }

            if ( nullActor == nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (nullActor == nullActor) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (nullActor == nullActor) : test failed");
            }

            // test || operator
            if ( actor || actorSame )
            {
                Console.WriteLine ("BaseHandle Operator (actor || actorSame) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor || actorSame) : test failed");
            }

            if ( actor || nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (actor || nullActor) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor || nullActor) : test failed");
            }

            if ( nullActor || nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (nullActor || nullActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (nullActor || nullActor) : test passed");
            }

            // test && operator
            if ( actor && actorSame )
            {
                Console.WriteLine ("BaseHandle Operator (actor && actorSame) : test passed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor && actorSame) : test failed");
            }

            if ( actor && nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (actor && nullActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (actor && nullActor) : test passed");
            }

            if ( nullActor && nullActor )
            {
                Console.WriteLine ("BaseHandle Operator (nullActor && nullActor) : test failed");
            }
            else
            {
                Console.WriteLine ("BaseHandle Operator (nullActor && nullActor) : test passed");
            }
        }

        public void CustomViewPropertyTest()
        {
            // Create a Spin control
            Spin spin = new Spin();

            // Background property
            Property.Map background = new Property.Map();
            background.Add( Dali.Constants.Visual.Property.Type, new Property.Value((int)Dali.Constants.Visual.Type.Color) )
                .Add( Dali.Constants.ColorVisualProperty.MixColor, new Property.Value(Color.Red) );
            spin.Background = background;

            background = spin.Background;
            Vector4 backgroundColor = new Vector4();
            background.Find(Dali.Constants.ColorVisualProperty.MixColor).Get(backgroundColor);
            if( backgroundColor == Color.Red )
            {
                Console.WriteLine ("Custom View Background property : test passed");
            }
            else
            {
                Console.WriteLine ("Custom View Background property : test failed");
            }

            // BackgroundColor property
            spin.BackgroundColor = Color.Yellow;
            if(spin.BackgroundColor == Color.Yellow)
            {
                Console.WriteLine ("Custom View BackgroundColor property : test passed");
            }
            else
            {
                Console.WriteLine ("Custom View BackgroundColor property : test failed");
            }

            // StyleName property
            spin.StyleName = "MyCustomStyle";
            if(spin.StyleName == "MyCustomStyle")
            {
                Console.WriteLine ("Custom View StyleName property : test passed");
            }
            else
            {
                Console.WriteLine ("Custom View StyleName property : test failed");
            }
        }

        public void MainLoop()
        {
            _application.MainLoop ();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine ("Hello Mono World");

            Example example = new Example(Application.NewApplication());
            example.MainLoop ();
        }
    }
}
