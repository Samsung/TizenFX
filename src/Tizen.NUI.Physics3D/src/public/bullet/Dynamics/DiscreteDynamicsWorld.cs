/*
 * Copyright (c) 2013-2022 Andres Traks
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from the use of this software.
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it freely,
 * subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System;
using System.IO;
using System.ComponentModel;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DiscreteDynamicsWorld : DynamicsWorld
    {
        private SimulationIslandManager _simulationIslandManager;

        protected internal DiscreteDynamicsWorld()
        {
        }

        // Create handle to un-owned world.
        internal DiscreteDynamicsWorld(IntPtr native)
        {
            InitializeSubObject(native, this);

            // Matches the types used by the native PhysicsWorld initializer
            var dispatcher = new CollisionDispatcher(btCollisionWorld_getDispatcher(Native), this);
            var broadphase = new DbvtBroadphase(btCollisionWorld_getBroadphase(Native), this);
            var solver = new SequentialImpulseConstraintSolver(btDynamicsWorld_getConstraintSolver(Native), this);
            InitializeMembers(dispatcher, broadphase, solver);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DiscreteDynamicsWorld(Dispatcher dispatcher, BroadphaseInterface pairCache,
            ConstraintSolver constraintSolver, CollisionConfiguration collisionConfiguration)
        {
            IntPtr native = btDiscreteDynamicsWorld_new(
                dispatcher != null ? dispatcher.Native : IntPtr.Zero,
                pairCache != null ? pairCache.Native : IntPtr.Zero,
                constraintSolver != null ? constraintSolver.Native : IntPtr.Zero,
                collisionConfiguration != null ? collisionConfiguration.Native : IntPtr.Zero);
            InitializeUserOwned(native);
            InitializeMembers(dispatcher, pairCache, constraintSolver);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyGravity()
        {
            btDiscreteDynamicsWorld_applyGravity(Native);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DebugDrawConstraint(TypedConstraint constraint)
        {
            btDiscreteDynamicsWorld_debugDrawConstraint(Native, constraint.Native);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetNumTasks(int numTasks)
        {
            btDiscreteDynamicsWorld_setNumTasks(Native, numTasks);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SolveConstraints(ContactSolverInfo solverInfo)
        {
            btDiscreteDynamicsWorld_solveConstraints(Native, solverInfo.Native);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SynchronizeSingleMotionState(RigidBody body)
        {
            btDiscreteDynamicsWorld_synchronizeSingleMotionState(Native, body.Native);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateVehicles(float timeStep)
        {
            btDiscreteDynamicsWorld_updateVehicles(Native, timeStep);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ApplySpeculativeContactRestitution
        {
            get => btDiscreteDynamicsWorld_getApplySpeculativeContactRestitution(Native);
            set => btDiscreteDynamicsWorld_setApplySpeculativeContactRestitution(Native, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LatencyMotionStateInterpolation
        {
            get => btDiscreteDynamicsWorld_getLatencyMotionStateInterpolation(Native);
            set => btDiscreteDynamicsWorld_setLatencyMotionStateInterpolation(Native, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public SimulationIslandManager SimulationIslandManager
        {
            get
            {
                if (_simulationIslandManager == null)
                {
                    _simulationIslandManager = new SimulationIslandManager(btDiscreteDynamicsWorld_getSimulationIslandManager(Native));
                }
                return _simulationIslandManager;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SynchronizeAllMotionStates
        {
            get => btDiscreteDynamicsWorld_getSynchronizeAllMotionStates(Native);
            set => btDiscreteDynamicsWorld_setSynchronizeAllMotionStates(Native, value);
        }
    }
}
