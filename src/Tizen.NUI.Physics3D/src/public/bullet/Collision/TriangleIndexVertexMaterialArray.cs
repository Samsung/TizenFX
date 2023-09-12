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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class MaterialProperties : BulletDisposableObject
	{
		public MaterialProperties()
		{
			IntPtr native = btMaterialProperties_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr MaterialBase
		{
			get => btMaterialProperties_getMaterialBase(Native);
			set => btMaterialProperties_setMaterialBase(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MaterialStride
		{
			get => btMaterialProperties_getMaterialStride(Native);
			set => btMaterialProperties_setMaterialStride(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PhyScalarType MaterialType
		{
			get => btMaterialProperties_getMaterialType(Native);
			set => btMaterialProperties_setMaterialType(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumMaterials
		{
			get => btMaterialProperties_getNumMaterials(Native);
			set => btMaterialProperties_setNumMaterials(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumTriangles
		{
			get => btMaterialProperties_getNumTriangles(Native);
			set => btMaterialProperties_setNumTriangles(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr TriangleMaterialsBase
		{
			get => btMaterialProperties_getTriangleMaterialsBase(Native);
			set => btMaterialProperties_setTriangleMaterialsBase(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TriangleMaterialStride
		{
			get => btMaterialProperties_getTriangleMaterialStride(Native);
			set => btMaterialProperties_setTriangleMaterialStride(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PhyScalarType TriangleType
		{
			get => btMaterialProperties_getTriangleType(Native);
			set => btMaterialProperties_setTriangleType(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			btMaterialProperties_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriangleIndexVertexMaterialArray : TriangleIndexVertexArray
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleIndexVertexMaterialArray()
		{
			IntPtr native = btTriangleIndexVertexMaterialArray_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleIndexVertexMaterialArray(int numTriangles, IntPtr triangleIndexBase,
			int triangleIndexStride, int numVertices, IntPtr vertexBase, int vertexStride,
			int numMaterials, IntPtr materialBase, int materialStride, IntPtr triangleMaterialsBase,
			int materialIndexStride)
		{
			IntPtr native = btTriangleIndexVertexMaterialArray_new2(numTriangles, triangleIndexBase,
				triangleIndexStride, numVertices, vertexBase, vertexStride,
				numMaterials, materialBase, materialStride, triangleMaterialsBase,
				materialIndexStride);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddMaterialProperties(MaterialProperties mat, PhyScalarType triangleType = PhyScalarType.Int32)
		{
			btTriangleIndexVertexMaterialArray_addMaterialProperties(Native, mat.Native,
				triangleType);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetLockedMaterialBase(out IntPtr materialBase, out int numMaterials,
			out PhyScalarType materialType, out int materialStride, out IntPtr triangleMaterialBase,
			out int numTriangles, out int triangleMaterialStride, out PhyScalarType triangleType,
			int subpart = 0)
		{
			btTriangleIndexVertexMaterialArray_getLockedMaterialBase(Native, out materialBase,
				out numMaterials, out materialType, out materialStride, out triangleMaterialBase,
				out numTriangles, out triangleMaterialStride, out triangleType, subpart);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetLockedReadOnlyMaterialBase(out IntPtr materialBase, out int numMaterials,
			out PhyScalarType materialType, out int materialStride, out IntPtr triangleMaterialBase,
			out int numTriangles, out int triangleMaterialStride, out PhyScalarType triangleType,
			int subpart = 0)
		{
			btTriangleIndexVertexMaterialArray_getLockedReadOnlyMaterialBase(Native,
				out materialBase, out numMaterials, out materialType, out materialStride,
				out triangleMaterialBase, out numTriangles, out triangleMaterialStride,
				out triangleType, subpart);
		}
	}
}
