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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum GImpactShapeType
	{
		CompoundShape,
		TrimeshShapePart,
		TrimeshShape
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TetrahedronShapeEx : BuSimplex1To4
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TetrahedronShapeEx()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btTetrahedronShapeEx_new();
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetVertices(global::System.Numerics.Vector3 v0, global::System.Numerics.Vector3 v1, global::System.Numerics.Vector3 v2, global::System.Numerics.Vector3 v3)
		{
			btTetrahedronShapeEx_setVertices(Native, ref v0, ref v1, ref v2, ref v3);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class GImpactShapeInterface : ConcaveShape
	{
		private Aabb _localBox;

		protected internal GImpactShapeInterface()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetBulletTetrahedron(int primitiveIndex, TetrahedronShapeEx tetrahedron)
		{
			btGImpactShapeInterface_getBulletTetrahedron(Native, primitiveIndex, tetrahedron.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetBulletTriangle(int primitiveIndex, TriangleShapeEx triangle)
		{
			btGImpactShapeInterface_getBulletTriangle(Native, primitiveIndex, triangle.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetChildAabb(int childIndex, Matrix4x4 transform, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btGImpactShapeInterface_getChildAabb(Native, childIndex, ref transform,
				out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract CollisionShape GetChildShape(int index);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 GetChildTransform(int index)
		{
			Matrix4x4 value;
			btGImpactShapeInterface_getChildTransform(Native, index, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetPrimitiveTriangle(int index, PrimitiveTriangle triangle)
		{
			btGImpactShapeInterface_getPrimitiveTriangle(Native, index, triangle.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void LockChildShapes()
		{
			btGImpactShapeInterface_lockChildShapes(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PostUpdate()
		{
			btGImpactShapeInterface_postUpdate(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProcessAllTrianglesRayRef(TriangleCallback callback, ref global::System.Numerics.Vector3 rayFrom,
			ref global::System.Numerics.Vector3 rayTo)
		{
			btGImpactShapeInterface_processAllTrianglesRay(Native, callback.Native,
				ref rayFrom, ref rayTo);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProcessAllTrianglesRay(TriangleCallback callback, global::System.Numerics.Vector3 rayFrom,
		 global::System.Numerics.Vector3 rayTo)
		{
			btGImpactShapeInterface_processAllTrianglesRay(Native, callback.Native,
				ref rayFrom, ref rayTo);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTestRef(ref global::System.Numerics.Vector3 rayFrom, ref global::System.Numerics.Vector3 rayTo, RayResultCallback resultCallback)
		{
			btGImpactShapeInterface_rayTest(Native, ref rayFrom, ref rayTo, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTest(global::System.Numerics.Vector3 rayFrom, global::System.Numerics.Vector3 rayTo, RayResultCallback resultCallback)
		{
			btGImpactShapeInterface_rayTest(Native, ref rayFrom, ref rayTo, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetChildTransform(int index, Matrix4x4 transform)
		{
			btGImpactShapeInterface_setChildTransform(Native, index, ref transform);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UnlockChildShapes()
		{
			btGImpactShapeInterface_unlockChildShapes(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateBound()
		{
			btGImpactShapeInterface_updateBound(Native);
		}
		/*
		public GImpactBoxSet BoxSet
		{
			get { return btGImpactShapeInterface_getBoxSet(_native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ChildrenHasTransform => btGImpactShapeInterface_childrenHasTransform(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract GImpactShapeType GImpactShapeType { get; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasBoxSet => btGImpactShapeInterface_hasBoxSet(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb LocalBox => _localBox ?? (_localBox = new Aabb(btGImpactShapeInterface_getLocalBox(Native), this));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedsRetrieveTetrahedrons => btGImpactShapeInterface_needsRetrieveTetrahedrons(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedsRetrieveTriangles => btGImpactShapeInterface_needsRetrieveTriangles(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumChildShapes => btGImpactShapeInterface_getNumChildShapes(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract PrimitiveManagerBase PrimitiveManager { get; }
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class CompoundPrimitiveManager : PrimitiveManagerBase
	{
		internal CompoundPrimitiveManager(IntPtr native, GImpactCompoundShape compoundShape)
		{
			InitializeSubObject(native, compoundShape);

			CompoundShape = compoundShape;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactCompoundShape CompoundShape { get; }
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GImpactCompoundShape : GImpactShapeInterface
	{
		private CompoundPrimitiveManager _compoundPrimitiveManager;
		private List<CollisionShape> _childShapes = new List<CollisionShape>();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactCompoundShape(bool childrenHasTransform = true)
		{
			IntPtr native = btGImpactCompoundShape_new(childrenHasTransform);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddChildShape(Matrix4x4 localTransform, CollisionShape shape)
		{
			_childShapes.Add(shape);
			btGImpactCompoundShape_addChildShape(Native, ref localTransform, shape.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddChildShape(CollisionShape shape)
		{
			_childShapes.Add(shape);
			btGImpactCompoundShape_addChildShape2(Native, shape.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override CollisionShape GetChildShape(int index)
		{
			return _childShapes[index];
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override PrimitiveManagerBase PrimitiveManager => CompoundPrimitiveManager;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CompoundPrimitiveManager CompoundPrimitiveManager
		{
			get
			{
				if (_compoundPrimitiveManager == null)
				{
					_compoundPrimitiveManager = new CompoundPrimitiveManager(
						btGImpactCompoundShape_getCompoundPrimitiveManager(Native), this);
				}
				return _compoundPrimitiveManager;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override GImpactShapeType GImpactShapeType => GImpactShapeType.CompoundShape;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class TrimeshPrimitiveManager : PrimitiveManagerBase
	{
		private StridingMeshInterface _meshInterface;

		internal TrimeshPrimitiveManager(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TrimeshPrimitiveManager(StridingMeshInterface meshInterface, int part)
		{
			IntPtr native = btGImpactMeshShapePart_TrimeshPrimitiveManager_new(meshInterface.Native,
				part);
			InitializeUserOwned(native);

			_meshInterface = meshInterface;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TrimeshPrimitiveManager(TrimeshPrimitiveManager manager)
		{
			IntPtr native = btGImpactMeshShapePart_TrimeshPrimitiveManager_new2(manager.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TrimeshPrimitiveManager()
		{
			IntPtr native = btGImpactMeshShapePart_TrimeshPrimitiveManager_new3();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetBulletTriangle(int primIndex, TriangleShapeEx triangle)
		{
			btGImpactMeshShapePart_TrimeshPrimitiveManager_get_bullet_triangle(
				Native, primIndex, triangle.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetIndices(int faceIndex, out uint i0, out uint i1, out uint i2b)
		{
			btGImpactMeshShapePart_TrimeshPrimitiveManager_get_indices(Native,
				faceIndex, out i0, out i1, out i2b);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetVertex(uint vertexIndex, out global::System.Numerics.Vector3 vertex)
		{
			btGImpactMeshShapePart_TrimeshPrimitiveManager_get_vertex(Native,
				vertexIndex, out vertex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Lock()
		{
			btGImpactMeshShapePart_TrimeshPrimitiveManager_lock(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Unlock()
		{
			btGImpactMeshShapePart_TrimeshPrimitiveManager_unlock(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr IndexBase
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getIndexbase(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setIndexbase(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IndexStride
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getIndexstride(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setIndexstride(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PhyScalarType IndicesType
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getIndicestype(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setIndicestype(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LockCount
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getLock_count(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setLock_count(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Margin
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getMargin(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setMargin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StridingMeshInterface MeshInterface
		{
			get => _meshInterface;
			set
			{
				btGImpactMeshShapePart_TrimeshPrimitiveManager_setMeshInterface(Native, value.Native);
				_meshInterface = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Numfaces
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getNumfaces(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setNumfaces(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Numverts
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getNumverts(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setNumverts(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Part
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getPart(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setPart(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Scale
		{
			get
			{
			 global::System.Numerics.Vector3 value;
				btGImpactMeshShapePart_TrimeshPrimitiveManager_getScale(Native, out value);
				return value;
			}
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setScale(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Stride
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getStride(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setStride(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PhyScalarType Type
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getType(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setType(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr VertexBase
		{
			get => btGImpactMeshShapePart_TrimeshPrimitiveManager_getVertexbase(Native);
			set => btGImpactMeshShapePart_TrimeshPrimitiveManager_setVertexbase(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VertexCount => btGImpactMeshShapePart_TrimeshPrimitiveManager_get_vertex_count(Native);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GImpactMeshShapePart : GImpactShapeInterface
	{
		private TrimeshPrimitiveManager _gImpactTrimeshPrimitiveManager;

		internal GImpactMeshShapePart(IntPtr native, GImpactMeshShape owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactMeshShapePart()
		{
			IntPtr native = btGImpactMeshShapePart_new();
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactMeshShapePart(StridingMeshInterface meshInterface, int part)
		{
			IntPtr native = btGImpactMeshShapePart_new2(meshInterface.Native, part);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override CollisionShape GetChildShape(int index)
		{
			throw new InvalidOperationException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetVertex(int vertexIndex, out global::System.Numerics.Vector3 vertex)
		{
			btGImpactMeshShapePart_getVertex(Native, vertexIndex, out vertex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override GImpactShapeType GImpactShapeType => GImpactShapeType.TrimeshShapePart;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TrimeshPrimitiveManager GImpactTrimeshPrimitiveManager
		{
			get
			{
				if (_gImpactTrimeshPrimitiveManager == null)
				{
					_gImpactTrimeshPrimitiveManager = new TrimeshPrimitiveManager(
						btGImpactMeshShapePart_getTrimeshPrimitiveManager(Native), this);
				}
				return _gImpactTrimeshPrimitiveManager;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Part => btGImpactMeshShapePart_getPart(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override PrimitiveManagerBase PrimitiveManager => GImpactTrimeshPrimitiveManager;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VertexCount => btGImpactMeshShapePart_getVertexCount(Native);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GImpactMeshShape : GImpactShapeInterface
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactMeshShape(StridingMeshInterface meshInterface)
		{
			IntPtr native = btGImpactMeshShape_new(meshInterface.Native);
			InitializeCollisionShape(native);

			MeshInterface = meshInterface;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override CollisionShape GetChildShape(int index)
		{
			throw new InvalidOperationException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactMeshShapePart GetMeshPart(int index)
		{
			return new GImpactMeshShapePart(btGImpactMeshShape_getMeshPart(Native, index), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StridingMeshInterface MeshInterface { get; private set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MeshPartCount => btGImpactMeshShape_getMeshPartCount(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override PrimitiveManagerBase PrimitiveManager => null;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override GImpactShapeType GImpactShapeType => GImpactShapeType.TrimeshShape;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GImpactMeshShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShapeData CollisionShapeData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StridingMeshInterfaceData MeshInterface;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LocalScaling;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CollisionMargin;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GImpactSubType;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(GImpactMeshShapeData), fieldName).ToInt32(); }
	}
}
