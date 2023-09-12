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
using System.IO;
using System.Runtime.InteropServices;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class IndexedMesh : BulletDisposableObject
	{
		private bool _ownsData;

		internal IndexedMesh(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IndexedMesh()
		{
			IntPtr native = btIndexedMesh_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Allocate(int numTriangles, int numVertices, int triangleIndexStride = sizeof(int) * 3, int vertexStride = sizeof(float) * 3)
		{
			if (_ownsData)
			{
				Free();
			}
			else
			{
				_ownsData = true;
			}

			switch (triangleIndexStride)
			{
				case sizeof(byte) * 3:
					IndexType = PhyScalarType.Byte;
					break;
				case sizeof(short) * 3:
					IndexType = PhyScalarType.Int16;
					break;
				case sizeof(int) * 3:
				default:
					IndexType = PhyScalarType.Int32;
					break;
			}
			VertexType = PhyScalarType.Single;

			NumTriangles = numTriangles;
			TriangleIndexBase = Marshal.AllocHGlobal(numTriangles * triangleIndexStride);
			TriangleIndexStride = triangleIndexStride;
			NumVertices = numVertices;
			VertexBase = Marshal.AllocHGlobal(numVertices * vertexStride);
			VertexStride = vertexStride;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Free()
		{
			if (_ownsData)
			{
				Marshal.FreeHGlobal(TriangleIndexBase);
				Marshal.FreeHGlobal(VertexBase);
				_ownsData = false;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public unsafe UnmanagedMemoryStream GetTriangleStream()
		{
			int length = NumTriangles * TriangleIndexStride;
			return new UnmanagedMemoryStream((byte*)TriangleIndexBase.ToPointer(), length, length, FileAccess.ReadWrite);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public unsafe UnmanagedMemoryStream GetVertexStream()
		{
			int length = NumVertices * VertexStride;
			return new UnmanagedMemoryStream((byte*)btIndexedMesh_getVertexBase(Native).ToPointer(), length, length, FileAccess.ReadWrite);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetData(ICollection<int> triangles, ICollection<float> vertices)
		{
			SetTriangles(triangles);

			float[] vertexArray = vertices as float[];
			if (vertexArray == null)
			{
				vertexArray = new float[vertices.Count];
				vertices.CopyTo(vertexArray, 0);
			}
			Marshal.Copy(vertexArray, 0, VertexBase, vertices.Count);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetData(ICollection<int> triangles, ICollection<global::System.Numerics.Vector3> vertices)
		{
			SetTriangles(triangles);

			float[] vertexArray = new float[vertices.Count * 3];
			int i = 0;
			foreach (global::System.Numerics.Vector3 v in vertices)
			{
				vertexArray[i] = v.X;
				vertexArray[i + 1] = v.Y;
				vertexArray[i + 2] = v.Z;
				i += 3;
			}
			Marshal.Copy(vertexArray, 0, VertexBase, vertexArray.Length);
		}

		private void SetTriangles(ICollection<int> triangles)
		{
			int[] triangleArray = triangles as int[];
			if (triangleArray == null)
			{
				triangleArray = new int[triangles.Count];
				triangles.CopyTo(triangleArray, 0);
			}
			Marshal.Copy(triangleArray, 0, TriangleIndexBase, triangleArray.Length);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PhyScalarType IndexType
		{
			get => btIndexedMesh_getIndexType(Native);
			set => btIndexedMesh_setIndexType(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumTriangles
		{
			get => btIndexedMesh_getNumTriangles(Native);
			set => btIndexedMesh_setNumTriangles(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumVertices
		{
			get => btIndexedMesh_getNumVertices(Native);
			set => btIndexedMesh_setNumVertices(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr TriangleIndexBase
		{
			get => btIndexedMesh_getTriangleIndexBase(Native);
			set => btIndexedMesh_setTriangleIndexBase(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TriangleIndexStride
		{
			get => btIndexedMesh_getTriangleIndexStride(Native);
			set => btIndexedMesh_setTriangleIndexStride(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr VertexBase
		{
			get => btIndexedMesh_getVertexBase(Native);
			set => btIndexedMesh_setVertexBase(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VertexStride
		{
			get => btIndexedMesh_getVertexStride(Native);
			set => btIndexedMesh_setVertexStride(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PhyScalarType VertexType
		{
			get => btIndexedMesh_getVertexType(Native);
			set => btIndexedMesh_setVertexType(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			Free();
			if (IsUserOwned)
			{
				btIndexedMesh_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriangleIndexVertexArray : StridingMeshInterface
	{
		private IndexedMesh _initialMesh;

		internal TriangleIndexVertexArray(ConstructionInfo info)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleIndexVertexArray()
		{
			IntPtr native = btTriangleIndexVertexArray_new();
			InitializeUserOwned(native);
			InitializeMembers();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleIndexVertexArray(ICollection<int> triangles, ICollection<float> vertices)
		{
			IntPtr native = btTriangleIndexVertexArray_new();
			InitializeUserOwned(native);
			InitializeMembers();

			_initialMesh = new IndexedMesh();
			_initialMesh.Allocate(triangles.Count / 3, vertices.Count / 3);
			_initialMesh.SetData(triangles, vertices);
			AddIndexedMesh(_initialMesh);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleIndexVertexArray(ICollection<int> triangles, ICollection<global::System.Numerics.Vector3> vertices)
		{
			IntPtr native = btTriangleIndexVertexArray_new();
			InitializeUserOwned(native);
			InitializeMembers();

			_initialMesh = new IndexedMesh();
			_initialMesh.Allocate(triangles.Count / 3, vertices.Count);
			_initialMesh.SetData(triangles, vertices);
			AddIndexedMesh(_initialMesh);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleIndexVertexArray(int numTriangles, IntPtr triangleIndexBase, int triangleIndexStride, int numVertices, IntPtr vertexBase, int vertexStride)
		{
			IntPtr native = btTriangleIndexVertexArray_new2(numTriangles, triangleIndexBase, triangleIndexStride, numVertices, vertexBase, vertexStride);
			InitializeUserOwned(native);
			InitializeMembers();
		}

		protected internal void InitializeMembers()
		{
			IndexedMeshArray = new AlignedIndexedMeshArray(btTriangleIndexVertexArray_getIndexedMeshArray(Native), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddIndexedMesh(IndexedMesh mesh, PhyScalarType indexType = PhyScalarType.Int32)
		{
			mesh.IndexType = indexType;
			IndexedMeshArray.Add(mesh);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedIndexedMeshArray IndexedMeshArray { get; private set; }

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_initialMesh != null)
				{
					_initialMesh.Dispose();
					_initialMesh = null;
				}
			}
			base.Dispose(disposing);
		}
	}
}
