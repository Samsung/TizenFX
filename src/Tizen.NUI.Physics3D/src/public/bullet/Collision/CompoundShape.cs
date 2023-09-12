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
using System.Runtime.InteropServices;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CompoundShapeChild : BulletObject
	{
		private CollisionShape _childShape;

		internal CompoundShapeChild(IntPtr native, CollisionShape childShape)
		{
			Initialize(native);
			_childShape = childShape;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ChildMargin
		{
			get => btCompoundShapeChild_getChildMargin(Native);
			set => btCompoundShapeChild_setChildMargin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShape ChildShape
		{
			get => _childShape;
			set
			{
				btCompoundShapeChild_setChildShape(Native, value.Native);
				_childShape = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphaseNativeType ChildShapeType
		{
			get => btCompoundShapeChild_getChildShapeType(Native);
			set => btCompoundShapeChild_setChildShapeType(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Node
		{
			get
			{
				IntPtr ptr = btCompoundShapeChild_getNode(Native);
				return (ptr != IntPtr.Zero) ? new DbvtNode(ptr) : null;
			}
			set => btCompoundShapeChild_setNode(Native, (value != null) ? value.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 Transform
		{
			get
			{
				Matrix4x4 value;
				btCompoundShapeChild_getTransform(Native, out value);
				return value;
			}
			set => btCompoundShapeChild_setTransform(Native, ref value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CompoundShape : CollisionShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CompoundShape(bool enableDynamicAabbTree = true, int initialChildCapacity = 0)
		{
			IntPtr native = btCompoundShape_new(enableDynamicAabbTree, initialChildCapacity);
			InitializeCollisionShape(native);

			ChildList = new CompoundShapeChildArray(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddChildShapeRef(ref Matrix4x4 localTransform, CollisionShape shape)
		{
			ChildList.AddChildShape(ref localTransform, shape);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddChildShape(Matrix4x4 localTransform, CollisionShape shape)
		{
			ChildList.AddChildShape(ref localTransform, shape);
		}

	   [EditorBrowsable(EditorBrowsableState.Never)]
	   public void CalculatePrincipalAxisTransform(float[] masses, ref Matrix4x4 principal,
			out global::System.Numerics.Vector3 inertia)
		{
			btCompoundShape_calculatePrincipalAxisTransform(Native, masses,
				ref principal, out inertia);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CreateAabbTreeFromChildren()
		{
			btCompoundShape_createAabbTreeFromChildren(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShape GetChildShape(int index)
		{
			return ChildList[index].ChildShape;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetChildTransform(int index, out Matrix4x4 value)
		{
			btCompoundShape_getChildTransform(Native, index, out value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 GetChildTransform(int index)
		{
			Matrix4x4 value;
			btCompoundShape_getChildTransform(Native, index, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RecalculateLocalAabb()
		{
			btCompoundShape_recalculateLocalAabb(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveChildShape(CollisionShape shape)
		{
			ChildList.RemoveChildShape(shape);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveChildShapeByIndex(int childShapeIndex)
		{
			ChildList.RemoveChildShapeByIndex(childShapeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateChildTransform(int childIndex, Matrix4x4 newChildTransform,
			bool shouldRecalculateLocalAabb = true)
		{
			btCompoundShape_updateChildTransform(Native, childIndex, ref newChildTransform,
				shouldRecalculateLocalAabb);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CompoundShapeChildArray ChildList { get; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Dbvt DynamicAabbTree => new Dbvt(btCompoundShape_getDynamicAabbTree(Native));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumChildShapes => ChildList.Count;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UpdateRevision => btCompoundShape_getUpdateRevision(Native);
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CompoundShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShapeData CollisionShapeData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr ChildShapePtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumChildShapes;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CollisionMargin;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(CompoundShapeData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CompoundShapeChildData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData Transform;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr ChildShape;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ChildShapeType;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ChildMargin;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(CompoundShapeChildData), fieldName).ToInt32(); }
	}
}
