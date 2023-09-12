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
	public class TriangleMeshShape : ConcaveShape
	{
		protected internal TriangleMeshShape()
		{
		}

		protected internal void InitializeMembers(StridingMeshInterface meshInterface)
		{
			MeshInterface = meshInterface;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void LocalGetSupportingVertex(ref global::System.Numerics.Vector3 vec, out global::System.Numerics.Vector3 value)
		{
			btTriangleMeshShape_localGetSupportingVertex(Native, ref vec, out value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalGetSupportingVertex(global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btTriangleMeshShape_localGetSupportingVertex(Native, ref vec, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void LocalGetSupportingVertexWithoutMargin(ref global::System.Numerics.Vector3 vec, out global::System.Numerics.Vector3 value)
		{
			btTriangleMeshShape_localGetSupportingVertexWithoutMargin(Native, ref vec,
				out value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalGetSupportingVertexWithoutMargin(global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btTriangleMeshShape_localGetSupportingVertexWithoutMargin(Native, ref vec,
				out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RecalcLocalAabb()
		{
			btTriangleMeshShape_recalcLocalAabb(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalAabbMax
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTriangleMeshShape_getLocalAabbMax(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalAabbMin
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTriangleMeshShape_getLocalAabbMin(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StridingMeshInterface MeshInterface { get; private set; }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct TriangleMeshShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShapeData CollisionShapeData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StridingMeshInterfaceData MeshInterface;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr QuantizedFloatBvh;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr QuantizedDoubleBvh;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr TriangleInfoMap;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CollisionMargin;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Pad;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(TriangleMeshShapeData), fieldName).ToInt32(); }
	}
}
