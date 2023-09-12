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
using Tizen.NUI.Physics3D.Bullet;

// This is an example of running a basic Bullet physics simulation

class Physics3DSample
{
    public Physics3DSample()
    {
        // Collision configuration contains default setup for memory, collision setup. Advanced users can create their own configuration.
        var collisionConfiguration = new DefaultCollisionConfiguration();
        
        // Use the default collision dispatcher. For parallel processing you can use a diffent dispatcher
        var dispatcher = new CollisionDispatcher(collisionConfiguration);
        
        // DbvtBroadphase is a good general purpose broadphase.
        var overlappingPairCache = new DbvtBroadphase();
        
        // The default constraint solver.
        var solver = new SequentialImpulseConstraintSolver();
        
        var dynamicsWorld = new DiscreteDynamicsWorld(dispatcher, overlappingPairCache, solver, collisionConfiguration);

        var gravity = new Vector3(0.0f, -10.0f, 0.0f);
        dynamicsWorld.SetGravity(ref gravity);

        // Create a few basic rigid bodies
        var collisionShapes = new HashSet<CollisionShape>();

        // The ground is a cube of side 100 at position y = -56.
        // The sphere will hit it at y = -6, with center at -5
        {
            var groundShape = new BoxShape(new Vector3(50.0f));
            collisionShapes.Add(groundShape);
        
            var groundTransform = Matrix4x4.CreateTranslation(new Vector3(0.0f, -56.0f, 0.0f));
        
            // Using motion state is optional, it provides interpolation capabilities, and only synchronizes 'active' objects
            var myMotionState = new DefaultMotionState(groundTransform);
            
            const float mass = 0.0f;
            var localInertia = Vector3.Zero;
            var rbInfo = new RigidBodyConstructionInfo(mass, myMotionState, groundShape, localInertia);

            var body = new RigidBody(rbInfo);
        
            // Add the static body for the ground to the world
            dynamicsWorld.AddRigidBody(body);
            
            rbInfo.Dispose();
        }

        {
            // Create a dynamic rigid body
            var colShape = new SphereShape(1.0f);
            collisionShapes.Add(colShape);
            
            Matrix4x4 startTransform = Matrix4x4.CreateTranslation(new Vector3(2.0f, 10.0f, 0.0f));;
            
            // Using motion state is recommended, it provides interpolation capabilities, and only synchronizes 'active' objects
            var myMotionState = new DefaultMotionState(startTransform);;

            const float mass = 1.0f;
            
            // rigidbody is dynamic if and only if mass is non zero, otherwise static
            Vector3 localInertia;
            colShape.CalculateLocalInertia(mass, out localInertia);
            
            var rbInfo = new RigidBodyConstructionInfo(mass, myMotionState, colShape, localInertia);

            var body = new RigidBody(rbInfo);

            // Add the dynamic body to the world
            dynamicsWorld.AddRigidBody(body);
            
            rbInfo.Dispose();
        }

        // Do the simulation
        for (int i = 0; i < 150; i++)
        {
            dynamicsWorld.StepSimulation(1.0f / 60.0f, 10);

            // Print positions of all objects
            for (int j = dynamicsWorld.NumCollisionObjects - 1; j >= 0; j--)
            {
                CollisionObject obj = dynamicsWorld.CollisionObjectArray[j];
                var body = obj as RigidBody;
                
                Matrix4x4 trans;
                if (body != null && body.MotionState != null)
                {
                    body.MotionState.GetWorldTransform(out trans);
                }
                else
                {
                    obj.GetWorldTransform(out trans);
                }
                
                Console.WriteLine("world pos object " + j + ": " + trans.Translation.ToString("F6"));
            }
        }
        
        // Clean up in the reverse order of creation/initialization
        for (int i = dynamicsWorld.NumCollisionObjects - 1; i >= 0; i--)
        {
            CollisionObject obj = dynamicsWorld.CollisionObjectArray[i];
            var body = obj as RigidBody;
            
            if (body != null && body.MotionState != null)
            {
                body.MotionState.Dispose();
            }

            dynamicsWorld.RemoveCollisionObject(obj);

            obj.Dispose();
        }

        foreach (var shape in collisionShapes)
        {
            shape.Dispose();
        }
    }
    
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        Physics3DSample example = new Physics3DSample();
    }
}

