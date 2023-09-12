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
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum DynamicsWorldType
	{
		Simple = 1,
		Discrete = 2,
		Continuous = 3,
		SoftRigid = 4,
		Gpu = 5,
		SoftMultiBody = 6,
		DeformableMultiBody = 7
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class DynamicsWorld : CollisionWorld
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public delegate void InternalTickCallback(DynamicsWorld world, float timeStep);
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		delegate void InternalTickCallbackUnmanaged(IntPtr world, float timeStep);

		private InternalTickCallback _preTickCallback;
		private InternalTickCallback _postTickCallback;
		private InternalTickCallbackUnmanaged _preTickCallbackUnmanaged;
		private InternalTickCallbackUnmanaged _postTickCallbackUnmanaged;
		private ConstraintSolver _constraintSolver;
		private ContactSolverInfo _solverInfo;

		private Dictionary<IAction, ActionInterfaceWrapper> _actions;
		private List<TypedConstraint> _constraints = new List<TypedConstraint>();

		internal DynamicsWorld()
		{
		}

		protected internal void InitializeMembers(Dispatcher dispatcher, BroadphaseInterface pairCache, ConstraintSolver constraintSolver)
		{
			InitializeMembers(dispatcher, pairCache);
			_constraintSolver = constraintSolver;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddAction(IAction action)
		{
			if (_actions == null)
			{
				_actions = new Dictionary<IAction, ActionInterfaceWrapper>();
			}
			else if (_actions.ContainsKey(action))
			{
				return;
			}

			var wrapper = new ActionInterfaceWrapper(action, this);
			_actions.Add(action, wrapper);
			btDynamicsWorld_addAction(Native, wrapper.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddConstraint(TypedConstraint constraint, bool disableCollisionsBetweenLinkedBodies = false)
		{
			_constraints.Add(constraint);
			btDynamicsWorld_addConstraint(Native, constraint.Native, disableCollisionsBetweenLinkedBodies);

			if (disableCollisionsBetweenLinkedBodies)
			{
				RigidBody rigidBody = constraint.RigidBodyA;
				if (rigidBody._constraintRefs == null)
				{
					rigidBody._constraintRefs = new List<TypedConstraint>();
				}
				rigidBody._constraintRefs.Add(constraint);

				rigidBody = constraint.RigidBodyB;
				if (rigidBody._constraintRefs == null)
				{
					rigidBody._constraintRefs = new List<TypedConstraint>();
				}
				rigidBody._constraintRefs.Add(constraint);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddRigidBody(RigidBody body)
		{
			CollisionObjectArray.Add(body);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddRigidBody(RigidBody body, CollisionFilterGroups group, CollisionFilterGroups mask)
		{
			CollisionObjectArray.Add(body, (int)group, (int)mask);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddRigidBody(RigidBody body, int group, int mask)
		{
			CollisionObjectArray.Add(body, group, mask);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearForces()
		{
			btDynamicsWorld_clearForces(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraint GetConstraint(int index)
		{
			global::System.Diagnostics.Debug.Assert(btDynamicsWorld_getConstraint(Native, index) == _constraints[index].Native);
			return _constraints[index];
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetGravity(out global::System.Numerics.Vector3 gravity)
		{
			btDynamicsWorld_getGravity(Native, out gravity);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveAction(IAction action)
		{
			if (_actions == null)
			{
				// No actions have been added
				return;
			}

			ActionInterfaceWrapper wrapper;
			if (_actions.TryGetValue(action, out wrapper))
			{
				btDynamicsWorld_removeAction(Native, wrapper.Native);
				_actions.Remove(action);
				wrapper.Dispose();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveConstraint(TypedConstraint constraint)
		{
			RigidBody rigidBody = constraint.RigidBodyA;
			if (rigidBody._constraintRefs != null)
			{
				rigidBody._constraintRefs.Remove(constraint);
			}
			rigidBody = constraint.RigidBodyB;
			if (rigidBody._constraintRefs != null)
			{
				rigidBody._constraintRefs.Remove(constraint);
			}

			int itemIndex = _constraints.IndexOf(constraint);
			if (itemIndex == -1)
			{
				return;
			}

			int lastIndex = _constraints.Count - 1;
			_constraints[itemIndex] = _constraints[lastIndex];
			_constraints.RemoveAt(lastIndex);
			btDynamicsWorld_removeConstraint(Native, constraint.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveRigidBody(RigidBody body)
		{
			CollisionObjectArray.Remove(body);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetGravity(ref global::System.Numerics.Vector3 gravity)
		{
			btDynamicsWorld_setGravity(Native, ref gravity);
		}

		private void InternalPreTickCallbackNative(IntPtr world, float timeStep)
		{
			_preTickCallback(this, timeStep);
		}

		private void InternalPostTickCallbackNative(IntPtr world, float timeStep)
		{
			_postTickCallback(this, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetInternalTickCallback(InternalTickCallback callback, object worldUserInfo = null,
			bool isPreTick = false)
		{
			if (isPreTick)
			{
				SetInternalPreTickCallback(callback);
			}
			else
			{
				SetInternalPostTickCallback(callback);
			}
			WorldUserInfo = worldUserInfo;
		}

		private void SetInternalPreTickCallback(InternalTickCallback callback)
		{
			if (_preTickCallback != callback)
			{
				_preTickCallback = callback;
				if (callback != null)
				{
					if (_preTickCallbackUnmanaged == null)
					{
						_preTickCallbackUnmanaged = new InternalTickCallbackUnmanaged(InternalPreTickCallbackNative);
					}
					btDynamicsWorld_setInternalTickCallback(Native,
						Marshal.GetFunctionPointerForDelegate(_preTickCallbackUnmanaged), IntPtr.Zero, true);
				}
				else
				{
					_preTickCallbackUnmanaged = null;
					btDynamicsWorld_setInternalTickCallback(Native, IntPtr.Zero, IntPtr.Zero, true);
				}
			}
		}

		private void SetInternalPostTickCallback(InternalTickCallback callback)
		{
			if (_postTickCallback != callback)
			{
				_postTickCallback = callback;
				if (callback != null)
				{
					if (_postTickCallbackUnmanaged == null)
					{
						_postTickCallbackUnmanaged = new InternalTickCallbackUnmanaged(InternalPostTickCallbackNative);
					}
					btDynamicsWorld_setInternalTickCallback(Native,
						Marshal.GetFunctionPointerForDelegate(_postTickCallbackUnmanaged), IntPtr.Zero, false);
				}
				else
				{
					_postTickCallbackUnmanaged = null;
					btDynamicsWorld_setInternalTickCallback(Native, IntPtr.Zero, IntPtr.Zero, false);
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int StepSimulation(float timeStep, int maxSubSteps = 1, float fixedTimeStep = 1.0f / 60.0f)
		{
			return btDynamicsWorld_stepSimulation(Native, timeStep, maxSubSteps,
				fixedTimeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SynchronizeMotionStates()
		{
			btDynamicsWorld_synchronizeMotionStates(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConstraintSolver ConstraintSolver
		{
			get
			{
				if (_constraintSolver == null)
				{
					_constraintSolver = new SequentialImpulseConstraintSolver(btDynamicsWorld_getConstraintSolver(Native), this);
				}
				return _constraintSolver;
			}
			set
			{
				_constraintSolver = value;
				btDynamicsWorld_setConstraintSolver(Native, value.Native);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Gravity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btDynamicsWorld_getGravity(Native, out value);
				return value;
			}
			set => btDynamicsWorld_setGravity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumConstraints => btDynamicsWorld_getNumConstraints(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ContactSolverInfo SolverInfo
		{
			get
			{
				if (_solverInfo == null)
				{
					_solverInfo = new ContactSolverInfo(btDynamicsWorld_getSolverInfo(Native), this);
				}
				return _solverInfo;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DynamicsWorldType WorldType => btDynamicsWorld_getWorldType(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public object WorldUserInfo { get; set; }

		protected override void Dispose(bool disposing)
		{
			if (_actions != null)
			{
				foreach (ActionInterfaceWrapper wrapper in _actions.Values)
				{
					wrapper.Dispose();
				}
			}

			base.Dispose(disposing);
		}
	}
}
