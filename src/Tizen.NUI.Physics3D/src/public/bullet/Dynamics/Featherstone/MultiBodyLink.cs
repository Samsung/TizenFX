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
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum FeatherstoneJointType
	{
		Revolute = 0,
		Prismatic = 1,
		Spherical = 2,
		Planar = 3,
		Fixed = 4,
		Invalid
	}

	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum MultiBodyLinkFlags
	{
		None = 0,
		DisableParentCollision = 1
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class MultiBodyLink
	{
		internal IntPtr Native;

		internal MultiBodyLink(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetAxisBottom(int dof)
		{
		 	global::System.Numerics.Vector3 value;
			btMultibodyLink_getAxisBottom(Native, dof, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetAxisTop(int dof)
		{
		 	global::System.Numerics.Vector3 value;
			btMultibodyLink_getAxisTop(Native, dof, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAxisBottom(int dof, float x, float y, float z)
		{
			btMultibodyLink_setAxisBottom(Native, dof, x, y, z);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAxisBottom(int dof, global::System.Numerics.Vector3 axis)
		{
			btMultibodyLink_setAxisBottom2(Native, dof, ref axis);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAxisTop(int dof, float x, float y, float z)
		{
			btMultibodyLink_setAxisTop(Native, dof, x, y, z);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAxisTop(int dof, global::System.Numerics.Vector3 axis)
		{
			btMultibodyLink_setAxisTop2(Native, dof, ref axis);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateCacheMultiDof(float[] pq = null)
		{
			btMultibodyLink_updateCacheMultiDof(Native, pq);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateInterpolationCacheMultiDof()
		{
			btMultibodyLink_updateInterpolationCacheMultiDof(Native);
		}
/*
		public SpatialMotionVector AbsFrameLocVelocity
		{
			get { return btMultibodyLink_getAbsFrameLocVelocity(_native); }
			set { btMultibodyLink_setAbsFrameLocVelocity(_native, value._native); }
		}

		public SpatialMotionVector AbsFrameTotVelocity
		{
			get { return btMultibodyLink_getAbsFrameTotVelocity(_native); }
			set { btMultibodyLink_setAbsFrameTotVelocity(_native, value._native); }
		}
*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AppliedConstraintForce
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultibodyLink_getAppliedConstraintForce(Native, out value);
				return value;
			}
			set => btMultibodyLink_setAppliedConstraintForce(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AppliedConstraintTorque
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultibodyLink_getAppliedConstraintTorque(Native, out value);
				return value;
			}
			set => btMultibodyLink_setAppliedConstraintTorque(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AppliedForce
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultibodyLink_getAppliedForce(Native, out value);
				return value;
			}
			set => btMultibodyLink_setAppliedForce(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AppliedTorque
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultibodyLink_getAppliedTorque(Native, out value);
				return value;
			}
			set => btMultibodyLink_setAppliedTorque(Native, ref value);
		}
/*
		public SpatialMotionVector[] Axes
		{
			get { return btMultibodyLink_getAxes(_native); }
		}
*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Quaternion CachedRotParentToThis
		{
			get
			{
				Quaternion value;
				btMultibodyLink_getCachedRotParentToThis(Native, out value);
				return value;
			}
			set => btMultibodyLink_setCachedRotParentToThis(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Quaternion CachedRotParentToThisInterpolate
		{
			get
			{
				Quaternion value;
				btMultibodyLink_getCachedRotParentToThisInterpolate(Native, out value);
				return value;
			}
			set => btMultibodyLink_setCachedRotParentToThisInterpolate(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CachedRVector
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultibodyLink_getCachedRVector(Native, out value);
				return value;
			}
			set => btMultibodyLink_setCachedRVector(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CachedRVectorInterpolate
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultibodyLink_getCachedRVectorInterpolate(Native, out value);
				return value;
			}
			set => btMultibodyLink_setCachedRVectorInterpolate(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 CachedWorldTransform
		{
			get
			{
				Matrix4x4 value;
				btMultibodyLink_getCachedWorldTransform(Native, out value);
				return value;
			}
			set => btMultibodyLink_setCachedWorldTransform(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CfgOffset
		{
			get => btMultibodyLink_getCfgOffset(Native);
			set => btMultibodyLink_setCfgOffset(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBodyLinkCollider Collider
		{
			get => CollisionObject.GetManaged(btMultibodyLink_getCollider(Native)) as MultiBodyLinkCollider;
			set => btMultibodyLink_setCollider(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DofCount
		{
			get => btMultibodyLink_getDofCount(Native);
			set => btMultibodyLink_setDofCount(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DofOffset
		{
			get => btMultibodyLink_getDofOffset(Native);
			set => btMultibodyLink_setDofOffset(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 DVector
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultibodyLink_getDVector(Native, out value);
				return value;
			}
			set => btMultibodyLink_setDVector(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 EVector
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultibodyLink_getEVector(Native, out value);
				return value;
			}
			set => btMultibodyLink_setEVector(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Flags
		{
			get => btMultibodyLink_getFlags(Native);
			set => btMultibodyLink_setFlags(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 InertiaLocal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultibodyLink_getInertiaLocal(Native, out value);
				return value;
			}
			set => btMultibodyLink_setInertiaLocal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float JointDamping
		{
			get => btMultibodyLink_getJointDamping(Native);
			set => btMultibodyLink_setJointDamping(Native, value);
		}
		/*
		public MultiBodyJointFeedback JointFeedback
		{
			get { return _jointFeedback; }
			set
			{
				btMultibodyLink_setJointFeedback(_native, value._native);
				_jointFeedback = value;
			}
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float JointFriction
		{
			get => btMultibodyLink_getJointFriction(Native);
			set => btMultibodyLink_setJointFriction(Native, value);
		}
		/*
		public char JointName
		{
			get { return btMultibodyLink_getJointName(_native); }
			set { btMultibodyLink_setJointName(_native, value._native); }
		}

		public FloatArray JointPos
		{
			get { return btMultibodyLink_getJointPos(_native); }
		}

		public FloatArray JointTorque
		{
			get { return btMultibodyLink_getJointTorque(_native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FeatherstoneJointType JointType
		{
			get => btMultibodyLink_getJointType(Native);
			set => btMultibodyLink_setJointType(Native, value);
		}
	   /*
		public char LinkName
		{
			get { return btMultibodyLink_getLinkName(_native); }
			set { btMultibodyLink_setLinkName(_native, value._native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Mass
		{
			get => btMultibodyLink_getMass(Native);
			set => btMultibodyLink_setMass(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Parent
		{
			get => btMultibodyLink_getParent(Native);
			set => btMultibodyLink_setParent(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PosVarCount
		{
			get => btMultibodyLink_getPosVarCount(Native);
			set => btMultibodyLink_setPosVarCount(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr UserPtr
		{
			get => btMultibodyLink_getUserPtr(Native);
			set => btMultibodyLink_setUserPtr(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Quaternion ZeroRotParentToThis
		{
			get
			{
				Quaternion value;
				btMultibodyLink_getZeroRotParentToThis(Native, out value);
				return value;
			}
			set => btMultibodyLink_setZeroRotParentToThis(Native, ref value);
		}
	}
}
