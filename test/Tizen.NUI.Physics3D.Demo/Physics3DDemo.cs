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
using System.Numerics;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Physics3D;
using Tizen.NUI.Physics3D.Bullet;

// This is an example of running a basic Bullet physics simulation - it tests that the
// C# physics wrappers and native integration wrappers work together.
// It renders a ball that falls under gravity
class Physics3DSample : NUIApplication
{
    static string IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

    Window mWindow;
    Tizen.NUI.Vector2 mWindowSize;
    Matrix mTransform;
    PhysicsAdaptor mPhysicsAdaptor;
    HashSet<CollisionShape> mCollisionShapes;
    List<PhysicsActor> mPhysicsActors;

    protected override void OnCreate()
    {
        base.OnCreate();

        mWindow = Window.Instance;
        mWindow.BackgroundColor = Color.DarkOrchid;
        mWindowSize = mWindow.WindowSize;
        mWindow.KeyEvent += OnKeyEvent;

        mTransform = new Matrix();
        mTransform.SetIdentityAndScale(new Tizen.NUI.Vector3(1.0f, -1.0f, 1.0f));
        mTransform.SetTranslation(new Tizen.NUI.Vector3(mWindowSize.Width * 0.5f, mWindowSize.Height * 0.5f, -100.0f));

        mPhysicsAdaptor = new PhysicsAdaptor(mTransform, mWindowSize);

        mWindow.AddLayer(mPhysicsAdaptor.GetRootLayer());
        mPhysicsActors = new List<PhysicsActor>();
        mCollisionShapes = new HashSet<CollisionShape>();

        using(var accessor = mPhysicsAdaptor.GetAccessor())
        {
            var dynamicsWorld = accessor.GetNative();

            var gravity = new System.Numerics.Vector3(0.0f, -400.0f, 0.0f);
            dynamicsWorld.SetGravity(ref gravity);

            CreateGround(dynamicsWorld);
            CreateBall(dynamicsWorld);
        }
        mPhysicsAdaptor.CreateSyncPoint();
    }

    void OnKeyEvent(object source, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down)
        {
            switch( e.Key.KeyPressedName )
            {
                case "Escape":
                case "Back":
                {
                    Exit();
                }
                break;
            }
        }
    }

    void CreateGround(DiscreteDynamicsWorld dynamicsWorld)
    {
        var size = new Tizen.NUI.Vector3(2.0f * mWindowSize.Width, 10.0f, 2.0f * mWindowSize.Height);
        var groundView = new View(); //CubeRenderer.CreateView(size, BRICK_WALL);

        var physicsActor = CreateBrick(dynamicsWorld, groundView, 0.0f, 0.5f, 0.5f, size);
        physicsActor.AsyncSetPhysicsPosition(new Tizen.NUI.Vector3(0.0f, 0.5f * mWindowSize.Height - 10.0f, 0.0f));
        physicsActor.AsyncSetPhysicsRotation(new Tizen.NUI.Rotation(new Radian(0.1f), Tizen.NUI.Vector3.ZAxis));
        mPhysicsActors.Add(physicsActor);
    }

    void CreateBall(DiscreteDynamicsWorld dynamicsWorld)
    {
        const float BALL_MASS       = 2.0f;
        const float BALL_RADIUS     = 50.0f;

        var ball = new SphereShape(BALL_RADIUS);
        mCollisionShapes.Add(ball);

        Matrix4x4 transform = Matrix4x4.Identity;
        RigidBody body = CreateRigidBody(dynamicsWorld, BALL_MASS, transform, ball);

        body.Friction = 0.1f;
        body.Restitution = 0.95f;

        View view = new ImageView(IMAGE_DIR + "blocks-ball.png")
        {
            Name = "ball",
            Size = new Size(2.0f*BALL_RADIUS, 2.0f*BALL_RADIUS)
        };
        var physicsBall = mPhysicsAdaptor.AddViewToBody(view, body);

        physicsBall.AsyncSetPhysicsPosition(new Tizen.NUI.Vector3(0.0f, -400.0f, -150.0f));
        mPhysicsActors.Add(physicsBall);
    }

    PhysicsActor CreateBrick(DiscreteDynamicsWorld dynamicsWorld, View view,
                             float mass, float elasticity, float friction, Tizen.NUI.Vector3 size)
    {
        var halfExtents = new System.Numerics.Vector3(size.Width * 0.5f, size.Height * 0.5f, size.Depth * 0.5f);
        var shape = new BoxShape(halfExtents);
        System.Numerics.Vector3 inertia;
        shape.CalculateLocalInertia(mass, out inertia);
        Matrix4x4 startTransform = Matrix4x4.Identity;

        RigidBody body = CreateRigidBody(dynamicsWorld, mass, startTransform, shape);

        body.Friction = friction;
        body.Restitution = elasticity;

        var physicsActor = mPhysicsAdaptor.AddViewToBody(view, body);
        return physicsActor;
    }

    RigidBody CreateRigidBody(DiscreteDynamicsWorld dynamicsWorld, float mass, Matrix4x4 transform, CollisionShape shape)
    {
        bool isDynamic = (mass != 0.0);
        var localInertia = new System.Numerics.Vector3(0.0f, 0.0f, 0.0f);
        if(isDynamic)
        {
            localInertia = shape.CalculateLocalInertia(mass);
        }
        var motionState = new DefaultMotionState(transform);

        var rbInfo = new RigidBodyConstructionInfo(mass, motionState, shape, localInertia);
        var body = new RigidBody(rbInfo);

        dynamicsWorld.AddRigidBody(body);
        return body;
    }

    protected override void OnTerminate()
    {
        base.OnTerminate();
        using(var accessor = mPhysicsAdaptor.GetAccessor())
        {
            var dynamicsWorld = accessor.GetNative();

            foreach( var physicsActor in mPhysicsActors )
            {
                var body = physicsActor.GetBody();
                mPhysicsAdaptor.RemoveViewFromBody(physicsActor);
                dynamicsWorld.RemoveRigidBody(body);
                body.Dispose();
            }
            // Clean up
            foreach (var shape in mCollisionShapes)
            {
                shape.Dispose();
            }
        }
        mPhysicsAdaptor.Dispose();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        Physics3DSample example = new Physics3DSample();
        example.Run(args);
    }
}
