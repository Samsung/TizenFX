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
using System.IO;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class StridingMeshInterface : BulletDisposableObject
	{
		protected internal StridingMeshInterface()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public unsafe UnmanagedMemoryStream GetIndexStream(int subpart = 0)
		{
			IntPtr vertexBase, indexBase;
			int numVerts, numFaces;
			PhyScalarType vertsType, indicesType;
			int vertexStride, indexStride;
			btStridingMeshInterface_getLockedReadOnlyVertexIndexBase(Native, out vertexBase, out numVerts, out vertsType, out vertexStride, out indexBase, out indexStride, out numFaces, out indicesType, subpart);

			int length = numFaces * indexStride;
			return new UnmanagedMemoryStream((byte*)indexBase.ToPointer(), length, length, FileAccess.ReadWrite);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public unsafe UnmanagedMemoryStream GetVertexStream(int subpart = 0)
		{
			IntPtr vertexBase, indexBase;
			int numVerts, numFaces;
			PhyScalarType vertsType, indicesType;
			int vertexStride, indexStride;
			btStridingMeshInterface_getLockedReadOnlyVertexIndexBase(Native, out vertexBase, out numVerts, out vertsType, out vertexStride, out indexBase, out indexStride, out numFaces, out indicesType, subpart);

			int length = numVerts * vertexStride;
			return new UnmanagedMemoryStream((byte*)vertexBase.ToPointer(), length, length, FileAccess.ReadWrite);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateAabbBruteForce(out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btStridingMeshInterface_calculateAabbBruteForce(Native, out aabbMin,
				out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CalculateSerializeBufferSize()
		{
			return btStridingMeshInterface_calculateSerializeBufferSize(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetLockedReadOnlyVertexIndexBase(out IntPtr vertexBase, out int numVerts,
			out PhyScalarType type, out int vertexStride, out IntPtr indexbase, out int indexStride,
			out int numFaces, out PhyScalarType indicesType, int subpart = 0)
		{
			btStridingMeshInterface_getLockedReadOnlyVertexIndexBase(Native, out vertexBase,
				out numVerts, out type, out vertexStride, out indexbase, out indexStride,
				out numFaces, out indicesType, subpart);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetLockedVertexIndexBase(out IntPtr vertexBase, out int numVerts,
			out PhyScalarType type, out int vertexStride, out IntPtr indexbase, out int indexStride,
			out int numFaces, out PhyScalarType indicesType, int subpart = 0)
		{
			btStridingMeshInterface_getLockedVertexIndexBase(Native, out vertexBase,
				out numVerts, out type, out vertexStride, out indexbase, out indexStride,
				out numFaces, out indicesType, subpart);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetPremadeAabb(out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btStridingMeshInterface_getPremadeAabb(Native, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InternalProcessAllTriangles(InternalTriangleIndexCallback callback,
		 	global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax)
		{
			btStridingMeshInterface_InternalProcessAllTriangles(Native, callback.Native,
				ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PreallocateIndices(int numIndices)
		{
			btStridingMeshInterface_preallocateIndices(Native, numIndices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PreallocateVertices(int numVerts)
		{
			btStridingMeshInterface_preallocateVertices(Native, numVerts);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPremadeAabb(ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax)
		{
			btStridingMeshInterface_setPremadeAabb(Native, ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPremadeAabb(global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax)
		{
			btStridingMeshInterface_setPremadeAabb(Native, ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UnLockReadOnlyVertexBase(int subpart)
		{
			btStridingMeshInterface_unLockReadOnlyVertexBase(Native, subpart);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UnLockVertexBase(int subpart)
		{
			btStridingMeshInterface_unLockVertexBase(Native, subpart);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasPremadeAabb => btStridingMeshInterface_hasPremadeAabb(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumSubParts => btStridingMeshInterface_getNumSubParts(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Scaling
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btStridingMeshInterface_getScaling(Native, out value);
				return value;
			}
			set => btStridingMeshInterface_setScaling(Native, ref value);
		}

		protected override void Dispose(bool disposing)
		{
			btStridingMeshInterface_delete(Native);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct MeshPartData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Vertices3F;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Vertices3D;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Indices32;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Indices16;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Indices8;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Indices16_2;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumTriangles;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumVertices;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(MeshPartData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct StridingMeshInterfaceData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr MeshPartsPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData Scaling;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumMeshParts;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(StridingMeshInterfaceData), fieldName).ToInt32(); }
	}
}
