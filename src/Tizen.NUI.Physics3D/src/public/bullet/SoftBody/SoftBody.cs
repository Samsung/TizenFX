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

namespace Tizen.NUI.Physics3D.Bullet.SoftBody
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SoftBodyCollisionShape : ConvexShape
	{
		internal SoftBodyCollisionShape(IntPtr native, SoftBody owner)
		{
			InitializeCollisionShape(native, owner);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum AeroModel
	{
		VertexPoint,
		VertexTwoSided,
		VertexTwoSidedLiftDrag,
		VertexOneSided,
		FaceTwoSided,
		FaceTwoSidedLiftDrag,
		FaceOneSided
	}

	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum Collisions
	{
		None = 0,
		RigidSoftMask = 0x000f,
		SdfRigidSoft = 0x0001,
		ClusterConvexRigidSoft = 0x0002,
		SdfRigidDeformable = 0x0004,
		SoftSoftMask = 0x00F0,
		VertexFaceSoftSoft = 0x0010,
		ClusterClusterSoftSoft = 0x0020,
		ClusterSelf = 0x0040,
		VertexFaceDeformable = 0x0080,
		RigidDeformableFaceMask = 0x0F00,
		SdfRigidDeformableFace = 0x0100,
		SdfMultibodyDeformableFace = 0x0200,
		Default = SdfRigidSoft
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum FeatureType
	{
		None,
		Node,
		Link,
		Face,
		Tetra
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum JointType
	{
		Linear,
		Angular,
		Contact
	}

	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum MaterialFlags
	{
		None = 0,
		DebugDraw = 0x0001,
		Default = DebugDraw
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum PositionSolver
	{
		Linear,
		Anchors,
		RigidContacts,
		SoftContacts
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum SolverPresets
	{
		Positions,
		Velocities,
		Default
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum VelocitySolver
	{
		Linear
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SoftBodyWorldInfo : BulletDisposableObject
	{
		private BroadphaseInterface _broadphase;
		private Dispatcher _dispatcher;
		private SparseSdf _sparseSdf;

		internal SoftBodyWorldInfo(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftBodyWorldInfo()
		{
			IntPtr native = btSoftBodyWorldInfo_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AirDensity
		{
			get => btSoftBodyWorldInfo_getAir_density(Native);
			set => btSoftBodyWorldInfo_setAir_density(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphaseInterface Broadphase
		{
			get => _broadphase;
			set
			{
				btSoftBodyWorldInfo_setBroadphase(Native, (value != null) ? value.Native : IntPtr.Zero);
				_broadphase = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Dispatcher Dispatcher
		{
			get => _dispatcher;
			set
			{
				btSoftBodyWorldInfo_setDispatcher(Native, (value != null) ? value.Native : IntPtr.Zero);
				_dispatcher = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Gravity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBodyWorldInfo_getGravity(Native, out value);
				return value;
			}
			set => btSoftBodyWorldInfo_setGravity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxDisplacement
		{
			get => btSoftBodyWorldInfo_getMaxDisplacement(Native);
			set => btSoftBodyWorldInfo_setMaxDisplacement(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SparseSdf SparseSdf
		{
			get
			{
				if (_sparseSdf == null)
				{
					_sparseSdf = new SparseSdf(btSoftBodyWorldInfo_getSparsesdf(Native));
				}
				return _sparseSdf;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float WaterDensity
		{
			get => btSoftBodyWorldInfo_getWater_density(Native);
			set => btSoftBodyWorldInfo_setWater_density(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 WaterNormal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBodyWorldInfo_getWater_normal(Native, out value);
				return value;
			}
			set => btSoftBodyWorldInfo_setWater_normal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float WaterOffset
		{
			get => btSoftBodyWorldInfo_getWater_offset(Native);
			set => btSoftBodyWorldInfo_setWater_offset(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btSoftBodyWorldInfo_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AngularJoint : Joint
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class IControl : BulletDisposableObject
		{
			[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
			private delegate void PrepareUnmanagedDelegate(IntPtr angularJoint);
			[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
			private delegate float SpeedUnmanagedDelegate(IntPtr angularJoint, float current);

			private readonly PrepareUnmanagedDelegate _prepare;
			private readonly SpeedUnmanagedDelegate _speed;

			internal static IControl GetManaged(IntPtr native)
			{
				if (native == IntPtr.Zero)
				{
					return null;
				}

				if (native == Default.Native)
				{
					return Default;
				}

				IntPtr handle = btSoftBody_AJoint_IControlWrapper_getWrapperData(native);
				return GCHandle.FromIntPtr(handle).Target as IControl;
			}

			internal IControl(IntPtr native)
			{
				InitializeSubObject(native, this);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public IControl()
			{
				_prepare = PrepareUnmanaged;
				_speed = SpeedUnmanaged;

				IntPtr native = btSoftBody_AJoint_IControlWrapper_new(
					Marshal.GetFunctionPointerForDelegate(_prepare),
					Marshal.GetFunctionPointerForDelegate(_speed));
				InitializeUserOwned(native);

				GCHandle handle = GCHandle.Alloc(this, GCHandleType.Weak);
				btSoftBody_AJoint_IControlWrapper_setWrapperData(Native, GCHandle.ToIntPtr(handle));
			}

			static IControl _default;
			[EditorBrowsable(EditorBrowsableState.Never)]
			public static IControl Default =>
				_default ?? (_default = new IControl(btSoftBody_AJoint_IControl_Default()));

			private void PrepareUnmanaged(IntPtr angularJoint)
			{
				Prepare(new AngularJoint(angularJoint));
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public float SpeedUnmanaged(IntPtr angularJoint, float current)
			{
				return Speed(new AngularJoint(angularJoint), current);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public virtual void Prepare(AngularJoint angularJoint)
			{
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public virtual float Speed(AngularJoint angularJoint, float current)
			{
				return current;
			}

			protected override void Dispose(bool disposing)
			{
				if (IsUserOwned)
				{
					IntPtr handle = btSoftBody_AJoint_IControlWrapper_getWrapperData(Native);
					GCHandle.FromIntPtr(handle).Free();
					btSoftBody_AJoint_IControl_delete(Native);
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new class Specs : Joint.Specs
		{
			private IControl _iControl;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public Specs()
			{
				IntPtr native = btSoftBody_AJoint_Specs_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public global::System.Numerics.Vector3 Axis
			{
				get
				{
				 	global::System.Numerics.Vector3 value;
					btSoftBody_AJoint_Specs_getAxis(Native, out value);
					return value;
				}
				set => btSoftBody_AJoint_Specs_setAxis(Native, ref value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public IControl Control
			{
				get
				{
					if (_iControl == null)
					{
						_iControl = IControl.GetManaged(btSoftBody_AJoint_Specs_getIcontrol(Native));
					}
					return _iControl;
				}
				set
				{
					_iControl = value;
					btSoftBody_AJoint_Specs_setIcontrol(Native, value.Native);
				}
			}
		}

		private IControl _iControl;
		private Vector3Array _axis;

		internal AngularJoint(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array Axis
		{
			get
			{
				if (_axis == null)
				{
					_axis = new Vector3Array(btSoftBody_AJoint_getAxis(Native), 2);
				}
				return _axis;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IControl Control
		{
			get
			{
				if (_iControl == null)
				{
					_iControl = IControl.GetManaged(btSoftBody_AJoint_getIcontrol(Native));
				}
				return _iControl;
			}
			set
			{
				_iControl = value;
				btSoftBody_AJoint_setIcontrol(Native, value.Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Anchor : BulletObject
	{
		private Node _node;

		internal Anchor(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RigidBody Body
		{
			get => CollisionObject.GetManaged(btSoftBody_Anchor_getBody(Native)) as RigidBody;
			set => btSoftBody_Anchor_setBody(Native, (value != null) ? value.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 C0
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Anchor_getC0(Native, out value);
				return value;
			}
			set => btSoftBody_Anchor_setC0(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 C1
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Anchor_getC1(Native, out value);
				return value;
			}
			set => btSoftBody_Anchor_setC1(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float C2
		{
			get => btSoftBody_Anchor_getC2(Native);
			set => btSoftBody_Anchor_setC2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Influence
		{
			get => btSoftBody_Anchor_getInfluence(Native);
			set => btSoftBody_Anchor_setInfluence(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Local
		{
			get
			{
			    global::System.Numerics.Vector3 value;
				btSoftBody_Anchor_getLocal(Native, out value);
				return value;
			}
			set => btSoftBody_Anchor_setLocal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Node Node
		{
			get
			{
				IntPtr nodePtr = btSoftBody_Anchor_getNode(Native);
				if (_node != null && _node.Native == nodePtr) return _node;
				if (nodePtr == IntPtr.Zero) return null;
				_node = new Node(nodePtr);
				return _node;
			}
			set
			{
				btSoftBody_Anchor_setNode(Native, (value != null) ? value.Native : IntPtr.Zero);
				_node = value;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Body : BulletDisposableObject
	{
		private Cluster _soft;

		internal Body(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Body()
		{
			IntPtr native = btSoftBody_Body_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Body(CollisionObject colObj)
		{
			IntPtr native = btSoftBody_Body_new2(colObj.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Body(Cluster p)
		{
			IntPtr native = btSoftBody_Body_new3(p.Native);
			InitializeUserOwned(native);
			_soft = p;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Activate()
		{
			btSoftBody_Body_activate(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyAImpulse(Impulse impulse)
		{
			btSoftBody_Body_applyAImpulse(Native, impulse.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyDAImpulse(global::System.Numerics.Vector3 impulse)
		{
			btSoftBody_Body_applyDAImpulse(Native, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyDCImpulse(global::System.Numerics.Vector3 impulse)
		{
			btSoftBody_Body_applyDCImpulse(Native, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyDImpulse(global::System.Numerics.Vector3 impulse, global::System.Numerics.Vector3 rpos)
		{
			btSoftBody_Body_applyDImpulse(Native, ref impulse, ref rpos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyImpulse(Impulse impulse, global::System.Numerics.Vector3 rpos)
		{
			btSoftBody_Body_applyImpulse(Native, impulse.Native, ref rpos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyVAImpulse(global::System.Numerics.Vector3 impulse)
		{
			btSoftBody_Body_applyVAImpulse(Native, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyVImpulse(global::System.Numerics.Vector3 impulse, global::System.Numerics.Vector3 rpos)
		{
			btSoftBody_Body_applyVImpulse(Native, ref impulse, ref rpos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetAngularVelocity(global::System.Numerics.Vector3 rpos)
		{
		 	global::System.Numerics.Vector3 value;
			btSoftBody_Body_angularVelocity(Native, ref rpos, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Velocity(global::System.Numerics.Vector3 rpos)
		{
		 	global::System.Numerics.Vector3 value;
			btSoftBody_Body_velocity(Native, ref rpos, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Body_angularVelocity2(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject CollisionObject
		{
			get => CollisionObject.GetManaged(btSoftBody_Body_getCollisionObject(Native));
			set => btSoftBody_Body_setCollisionObject(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float InverseMass => btSoftBody_Body_invMass(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 InverseWorldInertia
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Body_invWorldInertia(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LinearVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Body_linearVelocity(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RigidBody Rigid
		{
			get => CollisionObject.GetManaged(btSoftBody_Body_getRigid(Native)) as RigidBody;
			set => btSoftBody_Body_setRigid(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Cluster Soft
		{
			get
			{
				IntPtr softPtr = btSoftBody_Body_getSoft(Native);
				if (_soft != null && _soft.Native == softPtr) return _soft;
				if (softPtr == IntPtr.Zero) return null;
				_soft = new Cluster(softPtr);
				return _soft;
			}
			set
			{
				btSoftBody_Body_setSoft(Native, (value != null) ? value.Native : IntPtr.Zero);
				_soft = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 Transform
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Body_xform(Native, out value);
				return value;
			}
		}

		protected override void Dispose(bool disposing)
		{
			btSoftBody_Body_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ContactJoint : Joint
	{
		private Vector3Array _rPos;

		internal ContactJoint(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Friction
		{
			get => btSoftBody_CJoint_getFriction(Native);
			set => btSoftBody_CJoint_setFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Life
		{
			get => btSoftBody_CJoint_getLife(Native);
			set => btSoftBody_CJoint_setLife(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MaxLife
		{
			get => btSoftBody_CJoint_getMaxlife(Native);
			set => btSoftBody_CJoint_setMaxlife(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Normal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_CJoint_getNormal(Native, out value);
				return value;
			}
			set => btSoftBody_CJoint_setNormal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array RPosition
		{
			get
			{
				if (_rPos == null)
				{
					_rPos = new Vector3Array(btSoftBody_CJoint_getRpos(Native), 2);
				}
				return _rPos;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Cluster
	{
		internal IntPtr Native;

		private AlignedVector3Array _framerefs;
		private Vector3Array _dImpulses;
		private DbvtNode _leaf;
		//private AlignedScalarArray _masses;
		private AlignedNodeArray _nodes;
		private Vector3Array _vImpulses;

		internal Cluster(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularDamping
		{
			get => btSoftBody_Cluster_getAdamping(Native);
			set => btSoftBody_Cluster_setAdamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Cluster_getAv(Native, out value);
				return value;
			}
			set => btSoftBody_Cluster_setAv(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ClusterIndex
		{
			get => btSoftBody_Cluster_getClusterIndex(Native);
			set => btSoftBody_Cluster_setClusterIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Collide
		{
			get => btSoftBody_Cluster_getCollide(Native);
			set => btSoftBody_Cluster_setCollide(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CenterOfMass
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Cluster_getCom(Native, out value);
				return value;
			}
			set => btSoftBody_Cluster_setCom(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ContainsAnchor
		{
			get => btSoftBody_Cluster_getContainsAnchor(Native);
			set => btSoftBody_Cluster_setContainsAnchor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array DImpulses
		{
			get
			{
				if (_dImpulses == null)
				{
					_dImpulses = new Vector3Array(btSoftBody_Cluster_getDimpulses(Native), 2);
				}
				return _dImpulses;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedVector3Array FrameRefs
		{
			get
			{
				if (_framerefs == null)
				{
					_framerefs = new AlignedVector3Array(btSoftBody_Cluster_getFramerefs(Native));
				}
				return _framerefs;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameTransform
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Cluster_getFramexform(Native, out value);
				return value;
			}
			set => btSoftBody_Cluster_setFramexform(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Idmass
		{
			get => btSoftBody_Cluster_getIdmass(Native);
			set => btSoftBody_Cluster_setIdmass(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float InverseMass
		{
			get => btSoftBody_Cluster_getImass(Native);
			set => btSoftBody_Cluster_setImass(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 InverseWorldInertia
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Cluster_getInvwi(Native, out value);
				return value;
			}
			set => btSoftBody_Cluster_setInvwi(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearDamping
		{
			get => btSoftBody_Cluster_getLdamping(Native);
			set => btSoftBody_Cluster_setLdamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Leaf
		{
			get
			{
				IntPtr leafPtr = btSoftBody_Cluster_getLeaf(Native);
				if (_leaf != null && _leaf.Native == leafPtr) return _leaf;
				if (leafPtr == IntPtr.Zero) return null;
				_leaf = new DbvtNode(leafPtr);
				return _leaf;
			}
			set
			{
				btSoftBody_Cluster_setLeaf(Native, (value != null) ? value.Native : IntPtr.Zero);
				_leaf = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LinearVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Cluster_getLv(Native, out value);
				return value;
			}
			set => btSoftBody_Cluster_setLv(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 Locii
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Cluster_getLocii(Native, out value);
				return value;
			}
			set => btSoftBody_Cluster_setLocii(Native, ref value);
		}

		/*
		public AlignedScalarArray Masses
		{
			get
			{
				if (_masses == null)
				{
					_masses = new AlignedVector3Array(btSoftBody_Cluster_getMasses(Native));
				}
				return _masses;
			}
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Matching
		{
			get => btSoftBody_Cluster_getMatching(Native);
			set => btSoftBody_Cluster_setMatching(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxSelfCollisionImpulse
		{
			get => btSoftBody_Cluster_getMaxSelfCollisionImpulse(Native);
			set => btSoftBody_Cluster_setMaxSelfCollisionImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float NodeDamping
		{
			get => btSoftBody_Cluster_getNdamping(Native);
			set => btSoftBody_Cluster_setNdamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedNodeArray Nodes
		{
			get
			{
				if (_nodes == null)
				{
					_nodes = new AlignedNodeArray(btSoftBody_Cluster_getNodes(Native));
				}
				return _nodes;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumDImpulses
		{
			get => btSoftBody_Cluster_getNdimpulses(Native);
			set => btSoftBody_Cluster_setNdimpulses(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumVImpulses
		{
			get => btSoftBody_Cluster_getNvimpulses(Native);
			set => btSoftBody_Cluster_setNvimpulses(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SelfCollisionImpulseFactor
		{
			get => btSoftBody_Cluster_getSelfCollisionImpulseFactor(Native);
			set => btSoftBody_Cluster_setSelfCollisionImpulseFactor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array VImpulses
		{
			get
			{
				if (_vImpulses == null)
				{
					_vImpulses = new Vector3Array(btSoftBody_Cluster_getVimpulses(Native), 2);
				}
				return _vImpulses;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Config
	{
		internal IntPtr Native;

		//private AlignedPSolverArray _dSequence;
		//private AlignedPSolverArray _pSequence;
		//private AlignedVSolverArray _vSequence;

		internal Config(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AeroModel AeroModel
		{
			get => btSoftBody_Config_getAeromodel(Native);
			set => btSoftBody_Config_setAeromodel(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AnchorHardness
		{
			get => btSoftBody_Config_getKAHR(Native);
			set => btSoftBody_Config_setKAHR(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ClusterIterations
		{
			get => btSoftBody_Config_getCiterations(Native);
			set => btSoftBody_Config_setCiterations(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Collisions Collisions
		{
			get => btSoftBody_Config_getCollisions(Native);
			set => btSoftBody_Config_setCollisions(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Damping
		{
			get => btSoftBody_Config_getKDP(Native);
			set => btSoftBody_Config_setKDP(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DynamicFriction
		{
			get => btSoftBody_Config_getKDF(Native);
			set => btSoftBody_Config_setKDF(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Drag
		{
			get => btSoftBody_Config_getKDG(Native);
			set => btSoftBody_Config_setKDG(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DriftIterations
		{
			get => btSoftBody_Config_getDiterations(Native);
			set => btSoftBody_Config_setDiterations(Native, value);
		}
		/*
		public AlignedPSolverArray DriftSequence
		{
			get
			{
				if (_dSequence == null)
				{
					_dSequence = new AlignedPSolverArray(btSoftBody_Config_getDsequence(Native));
				}
				return _dsequence;
			}
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float KineticContactHardness
		{
			get => btSoftBody_Config_getKKHR(Native);
			set => btSoftBody_Config_setKKHR(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Lift
		{
			get => btSoftBody_Config_getKLF(Native);
			set => btSoftBody_Config_setKLF(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxVolume
		{
			get => btSoftBody_Config_getMaxvolume(Native);
			set => btSoftBody_Config_setMaxvolume(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float PoseMatching
		{
			get => btSoftBody_Config_getKMT(Native);
			set => btSoftBody_Config_setKMT(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PositionIterations
		{
			get => btSoftBody_Config_getPiterations(Native);
			set => btSoftBody_Config_setPiterations(Native, value);
		}
		/*
		public AlignedPSolverArray PositionSequence
		{
			get
			{
				if (_pSequence == null)
				{
					_pSequence = new AlignedPSolverArray(btSoftBody_Config_getPsequence(Native));
				}
				return _psequence;
			}
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Pressure
		{
			get => btSoftBody_Config_getKPR(Native);
			set => btSoftBody_Config_setKPR(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RigidContactHardness
		{
			get => btSoftBody_Config_getKCHR(Native);
			set => btSoftBody_Config_setKCHR(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftContactHardness
		{
			get => btSoftBody_Config_getKSHR(Native);
			set => btSoftBody_Config_setKSHR(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftKineticHardness
		{
			get => btSoftBody_Config_getKSKHR_CL(Native);
			set => btSoftBody_Config_setKSKHR_CL(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftKineticImpulseSplit
		{
			get => btSoftBody_Config_getKSK_SPLT_CL(Native);
			set => btSoftBody_Config_setKSK_SPLT_CL(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftRigidHardness
		{
			get => btSoftBody_Config_getKSRHR_CL(Native);
			set => btSoftBody_Config_setKSRHR_CL(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftRigidImpulseSplit
		{
			get => btSoftBody_Config_getKSR_SPLT_CL(Native);
			set => btSoftBody_Config_setKSR_SPLT_CL(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftSoftHardness
		{
			get => btSoftBody_Config_getKSSHR_CL(Native);
			set => btSoftBody_Config_setKSSHR_CL(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftSoftImpulseSplit
		{
			get => btSoftBody_Config_getKSS_SPLT_CL(Native);
			set => btSoftBody_Config_setKSS_SPLT_CL(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float VolumeConversation
		{
			get => btSoftBody_Config_getKVC(Native);
			set => btSoftBody_Config_setKVC(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float VelocityCorrectionFactor
		{
			get => btSoftBody_Config_getKVCF(Native);
			set => btSoftBody_Config_setKVCF(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Timescale
		{
			get => btSoftBody_Config_getTimescale(Native);
			set => btSoftBody_Config_setTimescale(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VelocityIterations
		{
			get => btSoftBody_Config_getViterations(Native);
			set => btSoftBody_Config_setViterations(Native, value);
		}
		/*
		public AlignedVSolverArray VelocitySequence
		{
			get
			{
				if (_vSequence == null)
				{
					_vSequence = new AlignedPSolverArray(btSoftBody_Config_getVsequence(Native));
				}
				return _vsequence;
			}
		}
		*/
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Element
	{
		internal IntPtr Native;

		internal Element(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Tag
		{
			get => btSoftBody_Element_getTag(Native);
			set => btSoftBody_Element_setTag(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			Element element = obj as Element;
			if (element == null)
			{
				return false;
			}
			return Native == element.Native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return Native.GetHashCode();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Face : Feature
	{
		private DbvtNode _leaf;
		private NodePtrArray _n;

		internal Face(IntPtr native)
			: base(native)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Leaf
		{
			get
			{
				IntPtr leafPtr = btSoftBody_Face_getLeaf(Native);
				if (_leaf != null && _leaf.Native == leafPtr) return _leaf;
				if (leafPtr == IntPtr.Zero) return null;
				_leaf = new DbvtNode(leafPtr);
				return _leaf;
			}
			set
			{
				btSoftBody_Face_setLeaf(Native, (value != null) ? value.Native : IntPtr.Zero);
				_leaf = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NodePtrArray Nodes
		{
			get
			{
				if (_n == null)
				{
					_n = new NodePtrArray(btSoftBody_Face_getN(Native), 3);
				}
				return _n;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Normal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Face_getNormal(Native, out value);
				return value;
			}
			set => btSoftBody_Face_setNormal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestArea
		{
			get => btSoftBody_Face_getRa(Native);
			set => btSoftBody_Face_setRa(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Feature : Element
	{
		private Material _material;

		internal Feature(IntPtr native)
			: base(native)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Material Material
		{
			get
			{
				IntPtr materialPtr = btSoftBody_Feature_getMaterial(Native);
				if (_material != null && _material.Native == materialPtr) return _material;
				if (materialPtr == IntPtr.Zero) return null;
				_material = new Material(materialPtr);
				return _material;
			}
			set
			{
				btSoftBody_Feature_setMaterial(Native, (value != null) ? value.Native : IntPtr.Zero);
				_material = value;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class ImplicitFn : IDisposable
	{
		internal IntPtr Native;

		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate float EvalUnmanagedDelegate([In] ref global::System.Numerics.Vector3 x);

		private EvalUnmanagedDelegate _eval;

		protected ImplicitFn()
		{
			_eval = Eval;

			Native = btSoftBody_ImplicitFnWrapper_new(Marshal.GetFunctionPointerForDelegate(_eval));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract float Eval(ref global::System.Numerics.Vector3 x);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Native != IntPtr.Zero)
			{
				btSoftBody_ImplicitFn_delete(Native);
				Native = IntPtr.Zero;
			}
		}

		~ImplicitFn()
		{
			Dispose(false);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Impulse : IDisposable
	{
		internal IntPtr Native;

		internal Impulse(IntPtr native)
		{
			Native = native;
		}

		public Impulse()
		{
			Native = btSoftBody_Impulse_new();
		}
		/*
		public Impulse operator-()
		{
			return btSoftBody_Impulse_operator_n(Native);
		}

		public Impulse operator*(float x)
		{
			return btSoftBody_Impulse_operator_m(Native, x);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int AsDrift
		{
			get => btSoftBody_Impulse_getAsDrift(Native);
			set => btSoftBody_Impulse_setAsDrift(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int AsVelocity
		{
			get => btSoftBody_Impulse_getAsVelocity(Native);
			set => btSoftBody_Impulse_setAsVelocity(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Drift
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Impulse_getDrift(Native, out value);
				return value;
			}
			set => btSoftBody_Impulse_setDrift(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Velocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Impulse_getVelocity(Native, out value);
				return value;
			}
			set => btSoftBody_Impulse_setVelocity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Native != IntPtr.Zero)
			{
				btSoftBody_Impulse_delete(Native);
				Native = IntPtr.Zero;
			}
		}

		~Impulse()
		{
			Dispose(false);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class Joint : BulletObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class Specs : BulletDisposableObject
		{
			protected internal Specs()
			{
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public float ConstraintForceMixing
			{
				get => btSoftBody_Joint_Specs_getCfm(Native);
				set => btSoftBody_Joint_Specs_setCfm(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public float ErrorReductionParameter
			{
				get => btSoftBody_Joint_Specs_getErp(Native);
				set => btSoftBody_Joint_Specs_setErp(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public float Split
			{
				get => btSoftBody_Joint_Specs_getSplit(Native);
				set => btSoftBody_Joint_Specs_setSplit(Native, value);
			}

			protected override void Dispose(bool disposing)
			{
				btSoftBody_Joint_Specs_delete(Native);
			}
		}

		private BodyArray _bodies;
		private Vector3Array _refs;

		internal static Joint GetManaged(IntPtr native)
		{
			if (native == IntPtr.Zero)
			{
				return null;
			}

			switch (btSoftBody_Joint_Type(native))
			{
				case JointType.Angular:
					return new AngularJoint(native);
				case JointType.Contact:
					return new ContactJoint(native);
				case JointType.Linear:
					return new LinearJoint(native);
				default:
					throw new NotImplementedException();
			}
		}

		protected internal Joint()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Prepare(float deltaTime, int iterations)
		{
			btSoftBody_Joint_Prepare(Native, deltaTime, iterations);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Solve(float deltaTime, float sor)
		{
			btSoftBody_Joint_Solve(Native, deltaTime, sor);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Terminate(float deltaTime)
		{
			btSoftBody_Joint_Terminate(Native, deltaTime);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BodyArray Bodies => _bodies ?? (_bodies = new BodyArray(btSoftBody_Joint_getBodies(Native), 2));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ConstraintForceMixing
		{
			get => btSoftBody_Joint_getCfm(Native);
			set => btSoftBody_Joint_setCfm(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Delete
		{
			get => btSoftBody_Joint_getDelete(Native);
			set => btSoftBody_Joint_setDelete(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Drift
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Joint_getDrift(Native, out value);
				return value;
			}
			set => btSoftBody_Joint_setDrift(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ErrorReductionParameter
		{
			get => btSoftBody_Joint_getErp(Native);
			set => btSoftBody_Joint_setErp(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 MassMatrix
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Joint_getMassmatrix(Native, out value);
				return value;
			}
			set => btSoftBody_Joint_setMassmatrix(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array Refs
		{
			get
			{
				if (_refs == null)
				{
					_refs = new Vector3Array(btSoftBody_Joint_getRefs(Native), 2);
				}
				return _refs;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 SplitDrift
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Joint_getSdrift(Native, out value);
				return value;
			}
			set => btSoftBody_Joint_setSdrift(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Split
		{
			get => btSoftBody_Joint_getSplit(Native);
			set => btSoftBody_Joint_setSplit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public JointType Type => btSoftBody_Joint_Type(Native);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Link : Feature
	{
		private NodePtrArray _n;

		internal Link(IntPtr native)
			: base(native)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float C0
		{
			get => btSoftBody_Link_getC0(Native);
			set => btSoftBody_Link_setC0(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float C1
		{
			get => btSoftBody_Link_getC1(Native);
			set => btSoftBody_Link_setC1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float C2
		{
			get => btSoftBody_Link_getC2(Native);
			set => btSoftBody_Link_setC2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 C3
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Link_getC3(Native, out value);
				return value;
			}
			set => btSoftBody_Link_setC3(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IsBending
		{
			get => btSoftBody_Link_getBbending(Native);
			set => btSoftBody_Link_setBbending(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NodePtrArray Nodes
		{
			get
			{
				if (_n == null)
				{
					_n = new NodePtrArray(btSoftBody_Link_getN(Native), 2);
				}
				return _n;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestLength
		{
			get => btSoftBody_Link_getRl(Native);
			set => btSoftBody_Link_setRl(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LinearJoint : Joint
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new class Specs : Joint.Specs
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Specs()
			{
				IntPtr native = btSoftBody_LJoint_Specs_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public global::System.Numerics.Vector3 Position
			{
				get
				{
				 	global::System.Numerics.Vector3 value;
					btSoftBody_LJoint_Specs_getPosition(Native, out value);
					return value;
				}
				set => btSoftBody_LJoint_Specs_setPosition(Native, ref value);
			}
		}

		private Vector3Array _rPos;

		internal LinearJoint(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array RPos
		{
			get
			{
				if (_rPos == null)
				{
					_rPos = new Vector3Array(btSoftBody_LJoint_getRpos(Native), 2);
				}
				return _rPos;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Material : Element
	{
		internal Material(IntPtr native)
			: base(native)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularStiffness
		{
			get => btSoftBody_Material_getKAST(Native);
			set => btSoftBody_Material_setKAST(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MaterialFlags Flags
		{
			get => btSoftBody_Material_getFlags(Native);
			set => btSoftBody_Material_setFlags(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearStiffness
		{
			get => btSoftBody_Material_getKLST(Native);
			set => btSoftBody_Material_setKLST(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float VolumeStiffness
		{
			get => btSoftBody_Material_getKVST(Native);
			set => btSoftBody_Material_setKVST(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Node : Feature
	{
		private DbvtNode _leaf;

		internal Node(IntPtr native)
			: base(native)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Area
		{
			get => btSoftBody_Node_getArea(Native);
			set => btSoftBody_Node_setArea(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Force
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Node_getF(Native, out value);
				return value;
			}
			set => btSoftBody_Node_setF(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Index
		{
			get => btSoftBody_Node_getIndex(Native);
			set => btSoftBody_Node_setIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float InverseMass
		{
			get => btSoftBody_Node_getIm(Native);
			set => btSoftBody_Node_setIm(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IsAttached
		{
			get => btSoftBody_Node_getBattach(Native);
			set => btSoftBody_Node_setBattach(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Leaf
		{
			get
			{
				IntPtr leafPtr = btSoftBody_Node_getLeaf(Native);
				if (_leaf != null && _leaf.Native == leafPtr) return _leaf;
				if (leafPtr == IntPtr.Zero) return null;
				_leaf = new DbvtNode(leafPtr);
				return _leaf;
			}
			set
			{
				btSoftBody_Node_setLeaf(Native, (value != null) ? value.Native : IntPtr.Zero);
				_leaf = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Normal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Node_getN(Native, out value);
				return value;
			}
			set => btSoftBody_Node_setN(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Position
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Node_getX(Native, out value);
				return value;
			}
			set => btSoftBody_Node_setX(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Q
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Node_getQ(Native, out value);
				return value;
			}
			set => btSoftBody_Node_setQ(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Velocity
		{
			get
			{
			 global::System.Numerics.Vector3 value;
				btSoftBody_Node_getV(Native, out value);
				return value;
			}
			set => btSoftBody_Node_setV(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 VelocityPrevious
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Node_getVN(Native, out value);
				return value;
			}
			set => btSoftBody_Node_setVN(Native, ref value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Note : Element
	{
		private NodePtrArray _nodes;

		internal Note(IntPtr native)
			: base(native)
		{
		}
		/*
		public FloatArray Coords
		{
			get { return btSoftBody_Note_getCoords(Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public NodePtrArray Nodes
		{
			get
			{
				if (_nodes == null)
				{
					_nodes = new NodePtrArray(btSoftBody_Note_getNodes(Native), 4);
				}
				return _nodes;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Offset
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Note_getOffset(Native, out value);
				return value;
			}
			set => btSoftBody_Note_setOffset(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Rank
		{
			get => btSoftBody_Note_getRank(Native);
			set => btSoftBody_Note_setRank(Native, value);
		}

		// TODO: free memory
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string Text
		{
			get => btSoftBody_Note_getText(Native);
			set => btSoftBody_Note_setText(Native, Marshal.StringToHGlobalAnsi(value));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Pose
	{
		internal IntPtr Native;

		private AlignedVector3Array _pos;
		//private AlignedScalarArray _wgh;

		internal Pose(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 Aqq
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Pose_getAqq(Native, out value);
				return value;
			}
			set => btSoftBody_Pose_setAqq(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Com
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_Pose_getCom(Native, out value);
				return value;
			}
			set => btSoftBody_Pose_setCom(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsFrameValid
		{
			get => btSoftBody_Pose_getBframe(Native);
			set => btSoftBody_Pose_setBframe(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsVolumeValid
		{
			get => btSoftBody_Pose_getBvolume(Native);
			set => btSoftBody_Pose_setBvolume(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedVector3Array Positions
		{
			get
			{
				if (_pos == null)
				{
					_pos = new AlignedVector3Array(btSoftBody_Pose_getPos(Native));
				}
				return _pos;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 Rotation
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Pose_getRot(Native, out value);
				return value;
			}
			set => btSoftBody_Pose_setRot(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 Scale
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_Pose_getScl(Native, out value);
				return value;
			}
			set => btSoftBody_Pose_setScl(Native, ref value);
		}
		/*
		public AlignedScalarArray Weights
		{
			get
			{
				if (_wgh == null)
				{
					_wgh = new AlignedScalarArray(btSoftBody_Pose_getWgh(_native));
				}
				return _wgh;
			}
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Volume
		{
			get => btSoftBody_Pose_getVolume(Native);
			set => btSoftBody_Pose_setVolume(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class RayFromToCaster : Dbvt.ICollide
	{
		private Face _face;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RayFromToCaster(global::System.Numerics.Vector3 rayFrom, global::System.Numerics.Vector3 rayTo, float mxt)
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btSoftBody_RayFromToCaster_new(ref rayFrom, ref rayTo, mxt);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static float RayFromToTriangle(global::System.Numerics.Vector3 rayFrom, global::System.Numerics.Vector3 rayTo,
		 	global::System.Numerics.Vector3 rayNormalizedDirection, global::System.Numerics.Vector3 a, global::System.Numerics.Vector3 b, global::System.Numerics.Vector3 c, float maxt = float.MaxValue)
		{
			return btSoftBody_RayFromToCaster_rayFromToTriangle(ref rayFrom,
				ref rayTo, ref rayNormalizedDirection, ref a, ref b, ref c, maxt);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Face Face
		{
			get
			{
				if (_face == null)
				{
					IntPtr facePtr = btSoftBody_RayFromToCaster_getFace(Native);
					if (facePtr != IntPtr.Zero)
					{
						_face = new Face(facePtr);
					}
				}
				return _face;
			}
			set
			{
				btSoftBody_RayFromToCaster_setFace(Native, value.Native);
				_face = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Mint
		{
			get => btSoftBody_RayFromToCaster_getMint(Native);
			set => btSoftBody_RayFromToCaster_setMint(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 RayFrom
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_RayFromToCaster_getRayFrom(Native, out value);
				return value;
			}
			set => btSoftBody_RayFromToCaster_setRayFrom(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 RayNormalizedDirection
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_RayFromToCaster_getRayNormalizedDirection(Native, out value);
				return value;
			}
			set => btSoftBody_RayFromToCaster_setRayNormalizedDirection(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 RayTo
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_RayFromToCaster_getRayTo(Native, out value);
				return value;
			}
			set => btSoftBody_RayFromToCaster_setRayTo(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Tests
		{
			get => btSoftBody_RayFromToCaster_getTests(Native);
			set => btSoftBody_RayFromToCaster_setTests(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class RigidContact : IDisposable
	{
		internal IntPtr Native;

		private Node _node;
		private ContactInfo _cti;

		internal RigidContact(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RigidContact()
		{
			Native = btSoftBody_RContact_new();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 C0
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_RContact_getC0(Native, out value);
				return value;
			}
			set => btSoftBody_RContact_setC0(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 C1
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_RContact_getC1(Native, out value);
				return value;
			}
			set => btSoftBody_RContact_setC1(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float C2
		{
			get => btSoftBody_RContact_getC2(Native);
			set => btSoftBody_RContact_setC2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float C3
		{
			get => btSoftBody_RContact_getC3(Native);
			set => btSoftBody_RContact_setC3(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float C4
		{
			get => btSoftBody_RContact_getC4(Native);
			set => btSoftBody_RContact_setC4(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ContactInfo Cti
		{
			get
			{
				if (_cti == null)
				{
					_cti = new ContactInfo(btSoftBody_RContact_getCti(Native));
				}
				return _cti;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Node Node
		{
			get
			{
				IntPtr nodePtr = btSoftBody_RContact_getNode(Native);
				if (_node != null && _node.Native == nodePtr) return _node;
				if (nodePtr == IntPtr.Zero) return null;
				_node = new Node(nodePtr);
				return _node;
			}
			set
			{
				btSoftBody_RContact_setNode(Native, (value != null) ? value.Native : IntPtr.Zero);
				_node = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 T1
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_RContact_getT1(Native, out value);
				return value;
			}
			set => btSoftBody_RContact_setT1(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 T2
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_RContact_getT2(Native, out value);
				return value;
			}
			set => btSoftBody_RContact_setT2(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Native != IntPtr.Zero)
			{
				btSoftBody_RContact_delete(Native);
				Native = IntPtr.Zero;
			}
		}

		~RigidContact()
		{
			Dispose(false);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ContactInfo : IDisposable
	{
		internal IntPtr Native;

		internal ContactInfo(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ContactInfo()
		{
			Native = btSoftBody_sCti_new();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject CollisionObject
		{
			get => CollisionObject.GetManaged(btSoftBody_sCti_getColObj(Native));
			set => btSoftBody_sCti_setColObj(Native, (value != null) ? value.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Normal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_sCti_getNormal(Native, out value);
				return value;
			}
			set => btSoftBody_sCti_setNormal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Offset
		{
			get => btSoftBody_sCti_getOffset(Native);
			set => btSoftBody_sCti_setOffset(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Native != IntPtr.Zero)
			{
				btSoftBody_sCti_delete(Native);
				Native = IntPtr.Zero;
			}
		}

		~ContactInfo()
		{
			Dispose(false);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SoftContact : IDisposable
	{
		internal IntPtr Native;

		//private ScalarArray _cfm;
		private Face _face;
		private Node _node;

		internal SoftContact(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftContact()
		{
			Native = btSoftBody_SContact_new();
		}
		/*
		public ScalarArray ConstraintForceMixing
		{
			get
			{
				if (_cfm == null)
				{
					_cfm = new ScalarArray(btSoftBody_SContact_getCfm(Native), 2);
				}
				return _cfm;
			}
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Face Face
		{
			get
			{
				if (_face == null)
				{
					IntPtr facePtr = btSoftBody_SContact_getFace(Native);
					if (facePtr != IntPtr.Zero)
					{
						_face = new Face(facePtr);
					}
				}
				return _face;
			}
			set
			{
				btSoftBody_SContact_setFace(Native, (value != null) ? value.Native : IntPtr.Zero);
				_face = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Friction
		{
			get => btSoftBody_SContact_getFriction(Native);
			set => btSoftBody_SContact_setFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Margin
		{
			get => btSoftBody_SContact_getMargin(Native);
			set => btSoftBody_SContact_setMargin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Node Node
		{
			get
			{
				IntPtr nodePtr = btSoftBody_SContact_getNode(Native);
				if (_node != null && _node.Native == nodePtr) return _node;
				if (nodePtr == IntPtr.Zero) return null;
				_node = new Node(nodePtr);
				return _node;
			}
			set
			{
				btSoftBody_SContact_setNode(Native, value.Native);
				_node = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Normal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_SContact_getNormal(Native, out value);
				return value;
			}
			set => btSoftBody_SContact_setNormal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Weights
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_SContact_getWeights(Native, out value);
				return value;
			}
			set => btSoftBody_SContact_setWeights(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Native != IntPtr.Zero)
			{
				btSoftBody_SContact_delete(Native);
				Native = IntPtr.Zero;
			}
		}

		~SoftContact()
		{
			Dispose(false);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SolverState
	{
		internal IntPtr Native;

		internal SolverState(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float InverseSdt
		{
			get => btSoftBody_SolverState_getIsdt(Native);
			set => btSoftBody_SolverState_setIsdt(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RadialMargin
		{
			get => btSoftBody_SolverState_getRadmrg(Native);
			set => btSoftBody_SolverState_setRadmrg(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Sdt
		{
			get => btSoftBody_SolverState_getSdt(Native);
			set => btSoftBody_SolverState_setSdt(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float UpdateMargin
		{
			get => btSoftBody_SolverState_getUpdmrg(Native);
			set => btSoftBody_SolverState_setUpdmrg(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float VelocityMargin
		{
			get => btSoftBody_SolverState_getVelmrg(Native);
			set => btSoftBody_SolverState_setVelmrg(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SoftBodyRayCast
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftBody Body { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FeatureType Feature { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Fraction { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Index { get; set; }
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Tetra : Feature
	{
		private Vector3Array _c0;
		private DbvtNode _leaf;
		private NodePtrArray _nodes;

		internal Tetra(IntPtr native)
			: base(native)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array C0
		{
			get
			{
				if (_c0 == null)
				{
					_c0 = new Vector3Array(btSoftBody_Tetra_getC0(Native), 4);
				}
				return _c0;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float C1
		{
			get => btSoftBody_Tetra_getC1(Native);
			set => btSoftBody_Tetra_setC1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float C2
		{
			get => btSoftBody_Tetra_getC2(Native);
			set => btSoftBody_Tetra_setC2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Leaf
		{
			get
			{
				IntPtr leafPtr = btSoftBody_Tetra_getLeaf(Native);
				if (_leaf != null && _leaf.Native == leafPtr) return _leaf;
				if (leafPtr == IntPtr.Zero) return null;
				_leaf = new DbvtNode(leafPtr);
				return _leaf;
			}
			set
			{
				btSoftBody_Tetra_setLeaf(Native, (value != null) ? value.Native : IntPtr.Zero);
				_leaf = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NodePtrArray Nodes
		{
			get
			{
				if (_nodes == null)
				{
					_nodes = new NodePtrArray(btSoftBody_Tetra_getN(Native), 4);
				}
				return _nodes;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestVolume
		{
			get => btSoftBody_Tetra_getRv(Native);
			set => btSoftBody_Tetra_setRv(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TetraScratch
	{
		internal IntPtr Native;

		internal TetraScratch(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 F
		{
			get
			{
				Matrix4x4 value;
				btSoftBody_TetraScratch_getF(Native, out value);
				return value;
			}
			set => btSoftBody_TetraScratch_setF(Native, ref value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SoftBody : CollisionObject
	{
		private AlignedAnchorArray _anchors;
		private Vector3Array _bounds;
		private Dbvt _clusterDbvt;
		private Config _config;
		//private AlignedBoolArray _clusterConnectivity;
		private AlignedClusterArray _clusters;
		//private AlignedCollisionObjectArray _collisionDisabledObjects;
		private Dbvt _faceDbvt;
		private AlignedFaceArray _faces;
		private AlignedJointArray _joints;
		private AlignedLinkArray _links;
		private AlignedMaterialArray _materials;
		private Dbvt _nodeDbvt;
		private AlignedNodeArray _nodes;
		private AlignedNoteArray _notes;
		private Pose _pose;
		//private AlignedRigidContactArray _rigidContacts;
		//private AlignedSoftContactArray _softContacts;
		private SoftBodySolver _softBodySolver;
		private SolverState _solverState;
		private AlignedTetraArray _tetras;
		private AlignedTetraScratchArray _tetraScratches;
		private AlignedTetraScratchArray _tetraScratchesTn;
		//private AlignedIntArray _userIndexMapping;
		private SoftBodyWorldInfo _worldInfo;

		private List<AngularJoint.IControl> _aJointControls = new List<AngularJoint.IControl>();

		internal SoftBody(IntPtr native)
			: base(ConstructionInfo.Null)
		{
			InitializeCollisionObject(native);

			_collisionShape = new SoftBodyCollisionShape(btCollisionObject_getCollisionShape(Native), this);
			_collisionShape.AllocateUnmanagedHandle();

		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftBody(SoftBodyWorldInfo worldInfo, int nodeCount, global::System.Numerics.Vector3[] positions, float[] masses)
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btSoftBody_new(worldInfo.Native, nodeCount, positions, masses);
			InitializeCollisionObject(native);

			_collisionShape = new SoftBodyCollisionShape(btCollisionObject_getCollisionShape(Native), this);
			_collisionShape.AllocateUnmanagedHandle();
			_worldInfo = worldInfo;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftBody(SoftBodyWorldInfo worldInfo)
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btSoftBody_new2(worldInfo.Native);
			InitializeCollisionObject(native);

			_collisionShape = new SoftBodyCollisionShape(btCollisionObject_getCollisionShape(Native), this);
			_collisionShape.AllocateUnmanagedHandle();
			_worldInfo = worldInfo;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddAeroForceToFace(global::System.Numerics.Vector3 windVelocity, int faceIndex)
		{
			btSoftBody_addAeroForceToFace(Native, ref windVelocity, faceIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddAeroForceToNode(global::System.Numerics.Vector3 windVelocity, int nodeIndex)
		{
			btSoftBody_addAeroForceToNode(Native, ref windVelocity, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddForce(global::System.Numerics.Vector3 force)
		{
			btSoftBody_addForce(Native, ref force);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddForce(global::System.Numerics.Vector3 force, int node)
		{
			btSoftBody_addForce2(Native, ref force, node);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddVelocity(global::System.Numerics.Vector3 velocity)
		{
			btSoftBody_addVelocity(Native, ref velocity);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddVelocity(global::System.Numerics.Vector3 velocity, int node)
		{
			btSoftBody_addVelocity2(Native, ref velocity, node);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendAnchor(int node, RigidBody body, global::System.Numerics.Vector3 localPivot, bool disableCollisionBetweenLinkedBodies = false,
			float influence = 1.0f)
		{
			btSoftBody_appendAnchor(Native, node, body.Native, ref localPivot,
				disableCollisionBetweenLinkedBodies, influence);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendAnchor(int node, RigidBody body, bool disableCollisionBetweenLinkedBodies = false,
			float influence = 1.0f)
		{
			btSoftBody_appendAnchor2(Native, node, body.Native, disableCollisionBetweenLinkedBodies,
				influence);
		}

		private void StoreAngularJointControlRef(AngularJoint.Specs specs)
		{
			if (specs.Control != null && specs.Control != AngularJoint.IControl.Default)
			{
				_aJointControls.Add(specs.Control);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendAngularJoint(AngularJoint.Specs specs)
		{
			StoreAngularJointControlRef(specs);
			btSoftBody_appendAngularJoint(Native, specs.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendAngularJoint(AngularJoint.Specs specs, Body body)
		{
			StoreAngularJointControlRef(specs);
			btSoftBody_appendAngularJoint2(Native, specs.Native, body.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendAngularJoint(AngularJoint.Specs specs, SoftBody body)
		{
			StoreAngularJointControlRef(specs);
			btSoftBody_appendAngularJoint3(Native, specs.Native, body.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendAngularJoint(AngularJoint.Specs specs, Cluster body0, Body body1)
		{
			StoreAngularJointControlRef(specs);
			btSoftBody_appendAngularJoint4(Native, specs.Native, body0.Native, body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendFace(int model = -1, Material mat = null)
		{
			btSoftBody_appendFace(Native, model, mat != null ? mat.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendFace(int node0, int node1, int node2, Material mat = null)
		{
			btSoftBody_appendFace2(Native, node0, node1, node2, mat != null ? mat.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendLinearJoint(LinearJoint.Specs specs, SoftBody body)
		{
			btSoftBody_appendLinearJoint(Native, specs.Native, body.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendLinearJoint(LinearJoint.Specs specs)
		{
			btSoftBody_appendLinearJoint2(Native, specs.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendLinearJoint(LinearJoint.Specs specs, Body body)
		{
			btSoftBody_appendLinearJoint3(Native, specs.Native, body.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendLinearJoint(LinearJoint.Specs specs, Cluster body0, Body body1)
		{
			btSoftBody_appendLinearJoint4(Native, specs.Native, body0.Native, body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendLink(int node0, int node1, Material mat = null, bool checkExist = false)
		{
			btSoftBody_appendLink(Native, node0, node1, (mat != null) ? mat.Native : IntPtr.Zero, checkExist);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendLink(int model = -1, Material mat = null)
		{
			btSoftBody_appendLink2(Native, model, (mat != null) ? mat.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendLink(Node node0, Node node1, Material mat = null, bool checkExist = false)
		{
			btSoftBody_appendLink3(Native, node0.Native, node1.Native, (mat != null) ? mat.Native : IntPtr.Zero, checkExist);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Material AppendMaterial()
		{
			return new Material(btSoftBody_appendMaterial(Native));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendNode(global::System.Numerics.Vector3 x, float m)
		{
			btSoftBody_appendNode(Native, ref x, m);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendNote(string text, global::System.Numerics.Vector3 o, Face feature)
		{
			btSoftBody_appendNote(Native, Marshal.StringToHGlobalAnsi(text), ref o, feature.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendNote(string text, global::System.Numerics.Vector3 o, Link feature)
		{
			btSoftBody_appendNote2(Native, Marshal.StringToHGlobalAnsi(text), ref o, feature.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendNote(string text, global::System.Numerics.Vector3 o, Node feature)
		{
			btSoftBody_appendNote3(Native, Marshal.StringToHGlobalAnsi(text), ref o, feature.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendNote(string text, global::System.Numerics.Vector3 o)
		{
			btSoftBody_appendNote4(Native, Marshal.StringToHGlobalAnsi(text), ref o);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendNote(string text, global::System.Numerics.Vector3 o, global::System.Numerics.Vector4 c,
			Node n0 = null, Node n1 = null, Node n2 = null, Node n3 = null)
		{
			btSoftBody_appendNote5(Native, Marshal.StringToHGlobalAnsi(text), ref o, ref c,
				n0 != null ? n0.Native : IntPtr.Zero,
				n1 != null ? n1.Native : IntPtr.Zero,
				n2 != null ? n2.Native : IntPtr.Zero,
				n3 != null ? n3.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendTetra(int model, Material mat)
		{
			btSoftBody_appendTetra(Native, model, mat != null ? mat.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AppendTetra(int node0, int node1, int node2, int node3, Material mat = null)
		{
			btSoftBody_appendTetra2(Native, node0, node1, node2, node3, mat != null ? mat.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyClusters(bool drift)
		{
			btSoftBody_applyClusters(Native, drift);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyForces()
		{
			btSoftBody_applyForces(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckContact(CollisionObjectWrapper colObjWrap, global::System.Numerics.Vector3 x, float margin,
			ContactInfo cti)
		{
			return btSoftBody_checkContact(Native, colObjWrap.Native, ref x, margin,
				cti.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckDeformableContact(CollisionObjectWrapper colObjWrap, global::System.Numerics.Vector3 x, float margin,
			ContactInfo cti, bool predict = false)
		{
			return btSoftBody_checkDeformableContact(Native, colObjWrap.Native, ref x, margin,
				cti.Native, predict);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckFace(int node0, int node1, int node2)
		{
			return btSoftBody_checkFace(Native, node0, node1, node2);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckLink(Node node0, Node node1)
		{
			return btSoftBody_checkLink(Native, node0.Native, node1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckLink(int node0, int node1)
		{
			return btSoftBody_checkLink2(Native, node0, node1);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CleanupClusters()
		{
			_aJointControls.Clear();
			btSoftBody_cleanupClusters(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ClusterAImpulse(Cluster cluster, Impulse impulse)
		{
			btSoftBody_clusterAImpulse(cluster.Native, impulse.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ClusterCom(int cluster)
		{
		 	global::System.Numerics.Vector3 value;
			btSoftBody_clusterCom(Native, cluster, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static global::System.Numerics.Vector3 ClusterCom(Cluster cluster)
		{
		 	global::System.Numerics.Vector3 value;
			btSoftBody_clusterCom2(cluster.Native, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ClusterCount()
		{
			return btSoftBody_clusterCount(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ClusterDAImpulse(Cluster cluster, global::System.Numerics.Vector3 impulse)
		{
			btSoftBody_clusterDAImpulse(cluster.Native, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ClusterDCImpulse(Cluster cluster, global::System.Numerics.Vector3 impulse)
		{
			btSoftBody_clusterDCImpulse(cluster.Native, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ClusterDImpulse(Cluster cluster, global::System.Numerics.Vector3 rpos, global::System.Numerics.Vector3 impulse)
		{
			btSoftBody_clusterDImpulse(cluster.Native, ref rpos, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ClusterImpulse(Cluster cluster, global::System.Numerics.Vector3 rpos, Impulse impulse)
		{
			btSoftBody_clusterImpulse(cluster.Native, ref rpos, impulse.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ClusterVAImpulse(Cluster cluster, global::System.Numerics.Vector3 impulse)
		{
			btSoftBody_clusterVAImpulse(cluster.Native, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static global::System.Numerics.Vector3 ClusterVelocity(Cluster cluster, global::System.Numerics.Vector3 rpos)
		{
		 	global::System.Numerics.Vector3 value;
			btSoftBody_clusterVelocity(cluster.Native, ref rpos, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ClusterVImpulse(Cluster cluster, global::System.Numerics.Vector3 rpos, global::System.Numerics.Vector3 impulse)
		{
			btSoftBody_clusterVImpulse(cluster.Native, ref rpos, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CutLink(Node node0, Node node1, float position)
		{
			return btSoftBody_cutLink(Native, node0.Native, node1.Native, position);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CutLink(int node0, int node1, float position)
		{
			return btSoftBody_cutLink2(Native, node0, node1, position);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DampClusters()
		{
			btSoftBody_dampClusters(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DefaultCollisionHandler(CollisionObjectWrapper pcoWrap)
		{
			btSoftBody_defaultCollisionHandler(Native, pcoWrap.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DefaultCollisionHandler(SoftBody psb)
		{
			btSoftBody_defaultCollisionHandler2(Native, psb.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 EvaluateCom()
		{
		 	global::System.Numerics.Vector3 value;
			btSoftBody_evaluateCom(Native, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GenerateBendingConstraints(int distance, Material mat = null)
		{
			return btSoftBody_generateBendingConstraints(Native, distance, mat != null ? mat.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GenerateClusters(int k)
		{
			return btSoftBody_generateClusters(Native, k);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GenerateClusters(int k, int maxIterations)
		{
			return btSoftBody_generateClusters2(Native, k, maxIterations);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetAabb(out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btSoftBody_getAabb(Native, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetMass(int node)
		{
			return btSoftBody_getMass(Native, node);
		}
		/*
		public static psolver_t GetSolver(PositionSolver solver)
		{
			return btSoftBody_getSolver(solver._native);
		}

		public static vsolver_t GetSolver(VelocitySolver solver)
		{
			return btSoftBody_getSolver2(solver._native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void IndicesToPointers(int[] map = null)
		{
			btSoftBody_indicesToPointers(Native, map);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InitDefaults()
		{
			btSoftBody_initDefaults(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InitializeClusters()
		{
			btSoftBody_initializeClusters(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InitializeFaceTree()
		{
			btSoftBody_initializeFaceTree(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InitializeDmInverse()
		{
			btSoftBody_initializeDmInverse(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void IntegrateMotion()
		{
			btSoftBody_integrateMotion(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PointersToIndices()
		{
			btSoftBody_pointersToIndices(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PredictMotion(float deltaTime)
		{
			btSoftBody_predictMotion(Native, deltaTime);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PrepareClusters(int iterations)
		{
			btSoftBody_prepareClusters(Native, iterations);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void PSolveAnchors(SoftBody psb, float kst, float ti)
		{
			btSoftBody_PSolve_Anchors(psb.Native, kst, ti);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void PSolveLinks(SoftBody psb, float kst, float ti)
		{
			btSoftBody_PSolve_Links(psb.Native, kst, ti);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void PSolveRContacts(SoftBody psb, float kst, float ti)
		{
			btSoftBody_PSolve_RContacts(psb.Native, kst, ti);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void PSolveSContacts(SoftBody psb, float __unnamed1, float ti)
		{
			btSoftBody_PSolve_SContacts(psb.Native, __unnamed1, ti);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RandomizeConstraints()
		{
			btSoftBody_randomizeConstraints(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool RayTestRef(ref global::System.Numerics.Vector3 rayFrom, ref global::System.Numerics.Vector3 rayTo, SoftBodyRayCast results)
		{
			IntPtr rayCast = btSoftBody_sRayCast_new();
			bool ret = btSoftBody_rayTest(Native, ref rayFrom, ref rayTo, rayCast);
			results.Body = this;
			results.Feature = btSoftBody_sRayCast_getFeature(rayCast);
			results.Fraction = btSoftBody_sRayCast_getFraction(rayCast);
			results.Index = btSoftBody_sRayCast_getIndex(rayCast);
			btSoftBody_sRayCast_delete(rayCast);
			return ret;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool RayTest(global::System.Numerics.Vector3 rayFrom, global::System.Numerics.Vector3 rayTo, SoftBodyRayCast results)
		{
			IntPtr rayCast = btSoftBody_sRayCast_new();
			bool ret = btSoftBody_rayTest(Native, ref rayFrom, ref rayTo, rayCast);
			results.Body = this;
			results.Feature = btSoftBody_sRayCast_getFeature(rayCast);
			results.Fraction = btSoftBody_sRayCast_getFraction(rayCast);
			results.Index = btSoftBody_sRayCast_getIndex(rayCast);
			btSoftBody_sRayCast_delete(rayCast);
			return ret;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RayTest(global::System.Numerics.Vector3 rayFrom, global::System.Numerics.Vector3 rayTo, ref float mint, out FeatureType feature,
			out int index, bool countOnly)
		{
			return btSoftBody_rayTest2(Native, ref rayFrom, ref rayTo, ref mint,
				out feature, out index, countOnly);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Refine(ImplicitFn ifn, float accurary, bool cut)
		{
			btSoftBody_refine(Native, ifn.Native, accurary, cut);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ReleaseCluster(int index)
		{
			btSoftBody_releaseCluster(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ReleaseClusters()
		{
			btSoftBody_releaseClusters(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetLinkRestLengths()
		{
			btSoftBody_resetLinkRestLengths(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Rotate(Quaternion rot)
		{
			btSoftBody_rotate(Native, ref rot);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Scale(global::System.Numerics.Vector3 scl)
		{
			btSoftBody_scale(Native, ref scl);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetDampingCoefficient(float dampingCoeff)
		{
			btSoftBody_setDampingCoefficient(Native, dampingCoeff);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMass(int node, float mass)
		{
			btSoftBody_setMass(Native, node, mass);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPose(bool bvolume, bool bframe)
		{
			btSoftBody_setPose(Native, bvolume, bframe);
		}
		/*
		public void SetSolver(SolverPresets preset)
		{
			btSoftBody_setSolver(_native, preset._native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetTotalDensity(float density)
		{
			btSoftBody_setTotalDensity(Native, density);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetTotalMass(float mass, bool fromFaces = false)
		{
			btSoftBody_setTotalMass(Native, mass, fromFaces);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetVelocity(global::System.Numerics.Vector3 velocity)
		{
			btSoftBody_setVelocity(Native, ref velocity);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetVolumeDensity(float density)
		{
			btSoftBody_setVolumeDensity(Native, density);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetVolumeMass(float mass)
		{
			btSoftBody_setVolumeMass(Native, mass);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void SolveClusters(AlignedSoftBodyArray bodies)
		{
			btSoftBody_solveClusters(bodies.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SolveClusters(float sor)
		{
			btSoftBody_solveClusters2(Native, sor);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void SolveCommonConstraints(SoftBody bodies, int count, int iterations)
		{
			btSoftBody_solveCommonConstraints(bodies.Native, count, iterations);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SolveConstraints()
		{
			btSoftBody_solveConstraints(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void StaticSolve(int iterations)
		{
			btSoftBody_staticSolve(Native, iterations);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Transform(Matrix4x4 trs)
		{
			btSoftBody_transform(Native, ref trs);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Translate(global::System.Numerics.Vector3 trs)
		{
			btSoftBody_translate(Native, ref trs);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Translate(float x, float y, float z)
		{
		 	global::System.Numerics.Vector3 trs = new global::System.Numerics.Vector3(x, y, z);
			btSoftBody_translate(Native, ref trs);
		}
		/*
		public static SoftBody Upcast(CollisionObject colObj)
		{
			return btSoftBody_upcast(colObj._native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateArea(bool averageArea = true)
		{
			btSoftBody_updateArea(Native, averageArea);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateBounds()
		{
			btSoftBody_updateBounds(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateClusters()
		{
			btSoftBody_updateClusters(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateConstants()
		{
			btSoftBody_updateConstants(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateLinkConstants()
		{
			btSoftBody_updateLinkConstants(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateNormals()
		{
			btSoftBody_updateNormals(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdatePose()
		{
			btSoftBody_updatePose(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void VSolveLinks(SoftBody psb, float kst)
		{
			btSoftBody_VSolve_Links(psb.Native, kst);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetFaceVertexData(ref float[] vertices)
		{
			int floatCount = Faces.Count * 3 * 3;

			// Do not use Array.Resize, because it copies the old data
			if (vertices == null || vertices.Length != floatCount)
			{
				vertices = new float[floatCount];
			}

			return btSoftBody_getFaceVertexData(Native, vertices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetFaceVertexData(ref global::System.Numerics.Vector3[] vertices)
		{
			int vertexCount = Faces.Count * 3;

			if (vertices == null || vertices.Length != vertexCount)
			{
				vertices = new global::System.Numerics.Vector3[vertexCount];
			}

			return btSoftBody_getFaceVertexData(Native, vertices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetFaceVertexNormalData(ref global::System.Numerics.Vector3[] vertices)
		{
			int vertexNormalCount = Faces.Count * 3 * 2;

			if (vertices == null || vertices.Length != vertexNormalCount)
			{
				vertices = new global::System.Numerics.Vector3[vertexNormalCount];
			}

			return btSoftBody_getFaceVertexNormalData(Native, vertices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetFaceVertexNormalData(ref global::System.Numerics.Vector3[] vertices, ref global::System.Numerics.Vector3[] normals)
		{
			int vertexCount = Faces.Count * 3;

			if (vertices == null || vertices.Length != vertexCount)
			{
				vertices = new global::System.Numerics.Vector3[vertexCount];
			}
			if (normals == null || normals.Length != vertexCount)
			{
				normals = new global::System.Numerics.Vector3[vertexCount];
			}

			return btSoftBody_getFaceVertexNormalData2(Native, vertices, normals);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetLinkVertexData(ref global::System.Numerics.Vector3[] vertices)
		{
			int vertexCount = Links.Count * 2;

			if (vertices == null || vertices.Length != vertexCount)
			{
				vertices = new global::System.Numerics.Vector3[vertexCount];
			}

			return btSoftBody_getLinkVertexData(Native, vertices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetLinkVertexNormalData(ref global::System.Numerics.Vector3[] vertices)
		{
			int vertexNormalCount = Links.Count * 2 * 2;

			if (vertices == null || vertices.Length != vertexNormalCount)
			{
				vertices = new global::System.Numerics.Vector3[vertexNormalCount];
			}

			return btSoftBody_getLinkVertexNormalData(Native, vertices);
		}

		int GetTetraVertexData(ref global::System.Numerics.Vector3[] vertices)
		{
			int vertexCount = Tetras.Count * 12;

			if (vertices == null || vertices.Length != vertexCount)
			{
				vertices = new global::System.Numerics.Vector3[vertexCount];
			}

			return btSoftBody_getTetraVertexData(Native, vertices);
		}

		int GetTetraVertexNormalData(ref global::System.Numerics.Vector3[] vertices)
		{
			int vertexNormalCount = Tetras.Count * 12 * 2;

			if (vertices == null || vertices.Length != vertexNormalCount)
			{
				vertices = new global::System.Numerics.Vector3[vertexNormalCount];
			}

			return btSoftBody_getTetraVertexNormalData(Native, vertices);
		}

		int GetTetraVertexNormalData(ref global::System.Numerics.Vector3[] vertices, ref global::System.Numerics.Vector3[] normals)
		{
			int vertexCount = Tetras.Count * 12;

			if (vertices == null || vertices.Length != vertexCount)
			{
				vertices = new global::System.Numerics.Vector3[vertexCount];
			}
			if (normals == null || normals.Length != vertexCount)
			{
				normals = new global::System.Numerics.Vector3[vertexCount];
			}

			return btSoftBody_getTetraVertexNormalData2(Native, vertices, normals);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetVertexNormalData(ref global::System.Numerics.Vector3[] data)
		{
			if (Faces.Count != 0)
			{
				return GetFaceVertexNormalData(ref data);
			}
			else if (Tetras.Count != 0)
			{
				return GetTetraVertexNormalData(ref data);
			}
			return GetLinkVertexNormalData(ref data);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetVertexNormalData(ref global::System.Numerics.Vector3[] vertices, ref global::System.Numerics.Vector3[] normals)
		{
			if (Faces.Count != 0)
			{
				return GetFaceVertexNormalData(ref vertices, ref normals);
			}
			else if (Tetras.Count != 0)
			{
				return GetTetraVertexNormalData(ref vertices, ref normals);
			}
			normals = null;
			return GetLinkVertexData(ref vertices);
		}

		protected override void Dispose(bool disposing)
		{
			_collisionShape.FreeUnmanagedHandle();

			base.Dispose(disposing);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedAnchorArray Anchors
		{
			get
			{
				if (_anchors == null)
				{
					_anchors = new AlignedAnchorArray(btSoftBody_getAnchors(Native));
				}
				return _anchors;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3Array Bounds
		{
			get
			{
				if (_bounds == null)
				{
					_bounds = new Vector3Array(btSoftBody_getBounds(Native), 2);
				}
				return _bounds;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Dbvt ClusterDbvt
		{
			get
			{
				if (_clusterDbvt == null)
				{
					_clusterDbvt = new Dbvt(btSoftBody_getCdbvt(Native));
				}
				return _clusterDbvt;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Config Cfg
		{
			get
			{
				if (_config == null)
				{
					_config = new Config(btSoftBody_getCfg(Native));
				}
				return _config;
			}
		}
		/*
		public AlignedObjectArray ClusterConnectivity
		{
			get { return btSoftBody_getClusterConnectivity(_native); }
			set { btSoftBody_setClusterConnectivity(_native, value._native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedClusterArray Clusters
		{
			get
			{
				if (_clusters == null)
				{
					_clusters = new AlignedClusterArray(btSoftBody_getClusters(Native));
				}
				return _clusters;
			}
		}
		/*
		public AlignedObjectArray<CollisionObject> CollisionDisabledObjects
		{
			get { return btSoftBody_getCollisionDisabledObjects(_native); }
			set { btSoftBody_setCollisionDisabledObjects(_native, value._native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedFaceArray Faces
		{
			get
			{
				if (_faces == null)
				{
					_faces = new AlignedFaceArray(btSoftBody_getFaces(Native));
				}
				return _faces;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Dbvt FaceDbvt
		{
			get
			{
				if (_faceDbvt == null)
				{
					_faceDbvt = new Dbvt(btSoftBody_getFdbvt(Native));
				}
				return _faceDbvt;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedJointArray Joints
		{
			get
			{
				if (_joints == null)
				{
					_joints = new AlignedJointArray(btSoftBody_getJoints(Native));
				}
				return _joints;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedLinkArray Links
		{
			get
			{
				if (_links == null)
				{
					_links = new AlignedLinkArray(btSoftBody_getLinks(Native));
				}
				return _links;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedMaterialArray Materials
		{
			get
			{
				if (_materials == null)
				{
					_materials = new AlignedMaterialArray(btSoftBody_getMaterials(Native));
				}
				return _materials;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Dbvt NodeDbvt
		{
			get
			{
				if (_nodeDbvt == null)
				{
					_nodeDbvt = new Dbvt(btSoftBody_getNdbvt(Native));
				}
				return _nodeDbvt;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedNodeArray Nodes
		{
			get
			{
				if (_nodes == null)
				{
					_nodes = new AlignedNodeArray(btSoftBody_getNodes(Native));
				}
				return _nodes;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedNoteArray Notes
		{
			get
			{
				if (_notes == null)
				{
					_notes = new AlignedNoteArray(btSoftBody_getNotes(Native));
				}
				return _notes;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Pose Pose
		{
			get
			{
				if (_pose == null)
				{
					_pose = new Pose(btSoftBody_getPose(Native));
				}
				return _pose;
			}
		}
		/*
		public tRContactArray Rcontacts
		{
			get { return btSoftBody_getRcontacts(_native); }
			set { btSoftBody_setRcontacts(_native, value._native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestLengthScale
		{
			get => btSoftBody_getRestLengthScale(Native);
			set => btSoftBody_setRestLengthScale(Native, value);
		}
		/*
		public tSContactArray Scontacts
		{
			get { return btSoftBody_getScontacts(_native); }
			set { btSoftBody_setScontacts(_native, value._native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftBodySolver SoftBodySolver
		{
			get => _softBodySolver;
			set
			{
				btSoftBody_setSoftBodySolver(Native, (value != null) ? value.Native : IntPtr.Zero);
				_softBodySolver = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SolverState SolverState
		{
			get
			{
				if (_solverState == null)
				{
					_solverState = new SolverState(btSoftBody_getSst(Native));
				}
				return _solverState;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public object Tag { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedTetraArray Tetras
		{
			get
			{
				if (_tetras == null)
				{
					_tetras = new AlignedTetraArray(btSoftBody_getTetras(Native));
				}
				return _tetras;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedTetraScratchArray TetraScratches
		{
			get
			{
				if (_tetraScratches == null)
				{
					_tetraScratches = new AlignedTetraScratchArray(btSoftBody_getTetraScratches(Native));
				}
				return _tetraScratches;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedTetraScratchArray TetraScratchesTn
		{
			get
			{
				if (_tetraScratchesTn == null)
				{
					_tetraScratchesTn = new AlignedTetraScratchArray(btSoftBody_getTetraScratchesTn(Native));
				}
				return _tetraScratchesTn;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Timeacc
		{
			get => btSoftBody_getTimeacc(Native);
			set => btSoftBody_setTimeacc(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TotalMass
		{
			get => btSoftBody_getTotalMass(Native);
			set => SetTotalMass(value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UpdateRuntimeConstants
		{
			get => btSoftBody_getBUpdateRtCst(Native);
			set => btSoftBody_setBUpdateRtCst(Native, value);
		}

		/*
		public AlignedObjectArray UserIndexMapping
		{
			get { return btSoftBody_getUserIndexMapping(_native); }
			set { btSoftBody_setUserIndexMapping(_native, value._native); }
		}
		*/

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseSelfCollision
		{
			get => btSoftBody_useSelfCollision(Native);
			set => btSoftBody_setSelfCollision(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 WindVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSoftBody_getWindVelocity(Native, out value);
				return value;
			}
			set => btSoftBody_setWindVelocity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Volume => btSoftBody_getVolume(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftBodyWorldInfo WorldInfo
		{
			get => _worldInfo; set
			{
				btSoftBody_setWorldInfo(Native, value.Native);
				_worldInfo = value;
			}
		}
	}
}
