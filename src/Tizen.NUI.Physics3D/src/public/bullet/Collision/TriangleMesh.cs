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
	public class TriangleMesh : TriangleIndexVertexArray
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleMesh(bool use32BitIndices = true, bool use4ComponentVertices = true)
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btTriangleMesh_new(use32BitIndices, use4ComponentVertices);
			InitializeUserOwned(native);
			InitializeMembers();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddIndex(int index)
		{
			btTriangleMesh_addIndex(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddTriangleRef(ref global::System.Numerics.Vector3 vertex0, ref global::System.Numerics.Vector3 vertex1, ref global::System.Numerics.Vector3 vertex2,
			bool removeDuplicateVertices = false)
		{
			btTriangleMesh_addTriangle(Native, ref vertex0, ref vertex1, ref vertex2,
			removeDuplicateVertices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddTriangle(global::System.Numerics.Vector3 vertex0, global::System.Numerics.Vector3 vertex1, global::System.Numerics.Vector3 vertex2,
			bool removeDuplicateVertices = false)
		{
			btTriangleMesh_addTriangle(Native, ref vertex0, ref vertex1, ref vertex2,
				removeDuplicateVertices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddTriangleIndices(int index1, int index2, int index3)
		{
			btTriangleMesh_addTriangleIndices(Native, index1, index2, index3);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FindOrAddVertexRef(global::System.Numerics.Vector3 vertex, bool removeDuplicateVertices)
		{
			return btTriangleMesh_findOrAddVertex(Native, ref vertex, removeDuplicateVertices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FindOrAddVertex(global::System.Numerics.Vector3 vertex, bool removeDuplicateVertices)
		{
			return btTriangleMesh_findOrAddVertex(Native, ref vertex, removeDuplicateVertices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumTriangles => btTriangleMesh_getNumTriangles(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Use32BitIndices => btTriangleMesh_getUse32bitIndices(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Use4ComponentVertices => btTriangleMesh_getUse4componentVertices(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float WeldingThreshold
		{
			get => btTriangleMesh_getWeldingThreshold(Native);
			set => btTriangleMesh_setWeldingThreshold(Native, value);
		}
	}
}
