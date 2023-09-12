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
using Tizen.NUI.Physics2D.Chipmunk;

// Tests the basic functionality of the Chipmunk2D physics engine without the need of any rendering.
// It sets up a 2D physics simulation with a dynamic circle dropping to the top of two static segments
// representing the ground and bouncing back. The simulation is run for a fixed number of time steps,
// and the position of the circle body is printed at each step to verify the correctness of the physics
// simulation.

class Physics2DSample
{
    public Physics2DSample()
    {
        // Create a space for physics simulation
        var space = new Space();
    
        // Set up gravity along the Y-axis (negative value for downward)
        var gravity = new Vect(0, -100);
        space.Gravity = gravity;
        
        // Create two static bodies (static bodies do not move) with shapes (segments) to form the ground
        var groundBody1 = new Body(BodyType.Static);
        var groundBody2 = new Body(BodyType.Static);
                    
        // Add the body to the space
        space.AddBody(groundBody1);
        space.AddBody(groundBody2);

        var groundStart = new Vect(-1000, 0); // Start point of the ground
        var groundEnd = new Vect(1000, 0); // End point of the ground
    
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
        var radius = 20.0;
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

        // Detect the collision between the circle and the ground        
        CollisionHandler handler = space.GetOrCreateCollisionHandler(0, 2);
        handler.Data = new StringBuilder();
        
        handler.Begin = (arbiterHandle, spaceHandle, userData) =>
        {
            StringBuilder builder = (StringBuilder)userData;
            _ = builder.Append("Begin -> ");
            
            Console.WriteLine("CollisionHandler::" + handler.Data.ToString());
        };
    
        handler.PreSolve = (arbiterHandle, spaceHandle, userData) =>
        {
            StringBuilder builder = (StringBuilder)userData;
            _ = builder.Append("PreSolve -> ");
            
            Console.WriteLine("CollisionHandler::" + handler.Data.ToString());
    
            return true;
        };
    
        handler.PostSolve = (arbiterHandle, spaceHandle, userData) =>
        {
            StringBuilder builder = (StringBuilder)userData;
            _ = builder.Append("PostSolve -> ");
            
            Console.WriteLine("CollisionHandler::" + handler.Data.ToString());
        };
    
        handler.Separate = (arbiterHandle, spaceHandle, userData) =>
        {
            StringBuilder builder = (StringBuilder)userData;
            _ = builder.Append("Separate -> ");
            
            Console.WriteLine("CollisionHandler::" + handler.Data.ToString());
        };
        
    
        // Simulate the physics for some time steps
        var numSteps = 60; // Number of simulation steps
        var timeStep = 1.0 / 60.0; // Time step for each simulation step (60 FPS)
        
        // Set the velocity of the circle body to make it move to the right
        circleBody.Velocity = new Vect(100, 0); // Velocity of (100, 0) along the X-axis
        
        for (int i = 0; i < numSteps; ++i)
        {
            space.Step(timeStep);
    
            // Print the position of the circle body during simulation
            var position = circleBody.Position;
            Console.WriteLine("Step " + i + " - Circle Position: (" + position.X + ", " + position.Y + ")");
        }

        // Make a point query on a shape
        {
            circleShape.Filter = new ShapeFilter((UIntPtr)10, 1, 5);
            ShapeFilter filter = circleShape.Filter;
            Console.WriteLine("ShapeFilter: " + filter.Group + ", " + filter.Categories + ", " + filter.Mask);
        
            var body = new Body(1, 1.66);
            var shape = new Box(body, 2, 2, 0);
    
            PointQueryInfo point = shape.PointQuery(new Vect(3, 4));
            Console.WriteLine("Shape PointQuery: Distance: " + point.Distance + ", Point: " + point.Point + ", Gradient.X: " + point.Gradient.X + ", Gradient.Y: " + point.Gradient.Y);            
    
            shape.Dispose();
            body.Dispose();
        }
    
        // Make a point query on a space
        {
            var mySpace = new Space();
            var body = new Body(1, 1.66);
            var shape = new Box(body, 100, 100, 0);
    
            body.Position = new Vect(0, 0);
    
            PointQueryInfo[] infos = mySpace.PointQuery(body.Position, 10.0, ShapeFilter.FILTER_ALL).ToArray();
            Console.WriteLine("Space PointQuery: infos.Length: " + infos.Length);
    
            mySpace.AddBody(body);
            mySpace.AddShape(shape);
    
            infos = mySpace.PointQuery(body.Position, 10.0, ShapeFilter.FILTER_ALL).ToArray();
            Console.WriteLine("Space PointQuery: infos.Length: " + infos.Length);
    
            if (infos.Length > 0 && shape == infos[0].Shape)
            {
                Console.WriteLine("Space PointQuery: The shape matches");
            }
    
            PointQueryInfo info = space.PointQueryNearest(new Vect(0, 0), 100.0, ShapeFilter.FILTER_ALL);
            
            if (info == null || info.Shape == null)
            {
                Console.WriteLine("Space PointQueryNearest: No shape is found");
            }
            else
            {
                Console.WriteLine("Shape PointQueryNearest: Distance: " + info.Distance + ", Point: " + info.Point + ", Gradient.X: "  + info.Gradient.X + ", Gradient.Y: " + info.Gradient.Y + ", Body position: " + info.Shape.Body.Position);
            }
    
            shape.Dispose();
            body.Dispose();
            mySpace.Dispose();
        }
        
        // Clean up
        groundShape1.Dispose();
        groundShape2.Dispose();
        circleShape.Dispose();
    
        groundBody1.Dispose();
        groundBody2.Dispose();
        circleBody.Dispose();
    
        space.Dispose();
    }
    
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        Physics2DSample example = new Physics2DSample();
    }
}

