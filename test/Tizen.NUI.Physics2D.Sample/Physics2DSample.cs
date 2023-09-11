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
*
*/

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;
using Tizen.NUI.Physics2D;
using Tizen.NUI.Physics2D.Chipmunk;



// Tests the basic functionality of the Chipmunk2D physics engine without the need of any rendering.
// It sets up a 2D physics simulation with a dynamic circle dropping to the top of two static segments
// representing the ground and bouncing back. The simulation is run for a fixed number of time steps,
// and the position of the circle body is printed at each step to verify the correctness of the physics
// simulation.

class Physics2DSample : NUIApplication
{
    static string IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

    Window mWindow;
    Vector2 mWindowSize;
    Matrix mTransform;
    PhysicsAdaptor mPhysicsAdaptor;

    protected override void OnCreate()
    {
        // Up call to the Base class first
        base.OnCreate();

        mWindow = Window.Instance;
        mWindow.BackgroundColor = Color.DarkOrchid;
        mWindowSize = mWindow.WindowSize;

        mTransform = new Matrix();
        mTransform.SetIdentityAndScale(new Vector3(1.0f, -1.0f, 1.0f));
        mTransform.SetTranslation(new Vector3(mWindowSize.Width * 0.5f, mWindowSize.Height * 0.5f, 0.0f));

        // Create a space for physics simulation
        mPhysicsAdaptor = new PhysicsAdaptor(mTransform, mWindowSize);
        mWindow.AddLayer(mPhysicsAdaptor.GetRootLayer());

        using (var accessor = mPhysicsAdaptor.GetAccessor())
        {
            var space = accessor.GetNative();

            // Set up gravity along the Y-axis (negative value for downward)
            var gravity = new Vect(0, -100);
            space.Gravity = gravity;

            // Create two static bodies (static bodies do not move) with shapes (segments) to form the ground
            var groundBody1 = new Body(BodyType.Static);
            var groundBody2 = new Body(BodyType.Static);

            // Add the body to the space
            space.AddBody(groundBody1);
            space.AddBody(groundBody2);

            var groundStart = new Vect(-1000.0f, 0.0f); // Start point of the ground
            var groundEnd = new Vect(1000.0f, 0.0f); // End point of the ground

            var groundShape1 = new Segment(groundBody1, groundStart, groundEnd, 0);
            var groundShape2 = new Segment(groundBody2, groundStart, groundEnd, 0);

            groundShape1.CollisionType = 0;
            groundShape2.CollisionType = 1;

            groundShape1.Elasticity = 0.85f;
            groundShape2.Elasticity = 0.85f;

            // Add the shapes to the space
            space.AddShape(groundShape1);
            space.AddShape(groundShape2);

            // Create a dynamic body with a circle shape
            var radius = 13.0;
            var mass = 1.0;
            var moment = Circle.MomentForCircle(mass, 0, radius, Vect.Zero);

            // Set initial position for the circle
            var circleBody = new Body(mass, moment);
            circleBody.Position = new Vect(0, 50);

            // Add the body to the space
            space.AddBody(circleBody);

            // Create a circle shape
            var circleShape = new Circle(circleBody, radius, Vect.Zero);
            circleShape.CollisionType = 2;
            circleShape.Elasticity = 0.85f;

            // Add the circle shape to the space
            space.AddShape(circleShape);

            View ball;
            ball = new ImageView(IMAGE_DIR + "blocks-ball.png")
            {
                Name = "ball",
                Size = new Size(26, 26)
            };

            var physicsBall = mPhysicsAdaptor.AddViewToBody(ball, circleBody);
            physicsBall.AsyncSetPhysicsPosition(new Vector3(0.0f, 100.0f, 0.0f));
            // Auto dispose of accessor
        }
        mPhysicsAdaptor.CreateSyncPoint();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        Physics2DSample example = new Physics2DSample();
        example.Run(args);
    }
}
