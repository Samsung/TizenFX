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
using Vector2 = Tizen.NUI.Vector2;
using Vector3 = Tizen.NUI.Vector3;

// This is an example of running a basic Bullet physics simulation - it tests that the
// C# physics wrappers and native integration wrappers work together.
// It renders a ball that falls under gravity
class Physics3DSample : NUIApplication
{
    private Window _window;
    private Vector2 _windowSize;
    private Matrix _transform;
    private PhysicsAdaptor _physicsAdaptor;
    private HashSet<CollisionShape> _collisionShapes;
    private List<PhysicsActor> _physicsActors;

    protected override void OnCreate()
    {
        base.OnCreate();

        _window = Window.Instance;
        _window.BackgroundColor = Color.Navy;
        _windowSize = _window.WindowSize;
        _window.KeyEvent += OnKeyEvent;

        _transform = new Matrix();
        _transform.SetIdentityAndScale(new Vector3(1.0f, -1.0f, 1.0f));
        _transform.SetTranslation(new Vector3(_windowSize.Width * 0.5f, _windowSize.Height * 0.5f, -100.0f));

        _physicsAdaptor = new PhysicsAdaptor(_transform, _windowSize);

        _window.AddLayer(_physicsAdaptor.GetRootLayer());
        _physicsActors = new List<PhysicsActor>();
        _collisionShapes = new HashSet<CollisionShape>();

        using(var accessor = _physicsAdaptor.GetAccessor())
        {
            var dynamicsWorld = accessor.GetNative();

            var gravity = new System.Numerics.Vector3(0.0f, -600.0f, 0.0f);
            dynamicsWorld.SetGravity(ref gravity);

            CreateGround(dynamicsWorld);
            CreateBall(dynamicsWorld);
        }
        _physicsAdaptor.CreateSyncPoint();
    }

    private void OnKeyEvent(object source, Window.KeyEventArgs e)
    {
        if (e.Key.State != Key.StateType.Down) return;
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

    private void CreateGround(DiscreteDynamicsWorld dynamicsWorld)
    {
        var size = new Vector3(2.0f * _windowSize.Width, 10.0f, 2.0f * _windowSize.Height);
        var groundView = new View();

        var physicsActor = CreateBrick(dynamicsWorld, groundView, 0.0f, 0.5f, 0.5f, size);
        physicsActor.AsyncSetPhysicsPosition(new Vector3(0.0f, 0.5f * _windowSize.Height - 10.0f, 0.0f));
        physicsActor.AsyncSetPhysicsRotation(new Rotation(new Radian(0.1f), Vector3.ZAxis));
        _physicsActors.Add(physicsActor);
    }

    private void CreateBall(DiscreteDynamicsWorld dynamicsWorld)
    {
        const float ballMass       = 2.0f;
        const float ballRadius     = 50.0f;

        var ball = new SphereShape(ballRadius);
        _collisionShapes.Add(ball);

        var transform = Matrix4x4.Identity;
        var body = CreateRigidBody(dynamicsWorld, ballMass, transform, ball);

        body.Friction = 0.1f;
        body.Restitution = 0.95f;
        
        var view = BallRenderer.CreateView(new Vector3(2.0f*ballRadius, 2.0f*ballRadius, 2.0f*ballRadius), Color.White);
        var physicsBall = _physicsAdaptor.AddViewToBody(view, body);

        physicsBall.AsyncSetPhysicsPosition(new Vector3(0.0f, -400.0f, -150.0f));
        _physicsActors.Add(physicsBall);
    }

    private PhysicsActor CreateBrick(DiscreteDynamicsWorld dynamicsWorld, View view,
        float mass, float elasticity, float friction, Vector3 size)
    {
        var halfExtents = new System.Numerics.Vector3(size.Width * 0.5f, size.Height * 0.5f, size.Depth * 0.5f);
        var shape = new BoxShape(halfExtents);
        
        var startTransform = Matrix4x4.Identity;
        var body = CreateRigidBody(dynamicsWorld, mass, startTransform, shape);

        body.Friction = friction;
        body.Restitution = elasticity;

        var physicsActor = _physicsAdaptor.AddViewToBody(view, body);
        return physicsActor;
    }

    private static RigidBody CreateRigidBody(DiscreteDynamicsWorld dynamicsWorld, float mass, Matrix4x4 transform, CollisionShape shape)
    {
        var isDynamic = (mass != 0.0);
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
        using(var accessor = _physicsAdaptor.GetAccessor())
        {
            var dynamicsWorld = accessor.GetNative();

            foreach( var physicsActor in _physicsActors )
            {
                var body = physicsActor.GetBody();
                _physicsAdaptor.RemoveViewFromBody(physicsActor);
                dynamicsWorld.RemoveRigidBody(body);
                body.Dispose();
            }
            // Clean up
            foreach (var shape in _collisionShapes)
            {
                shape.Dispose();
            }
        }
        _physicsAdaptor.Dispose();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        var example = new Physics3DSample();
        example.Run(args);
    }
}
