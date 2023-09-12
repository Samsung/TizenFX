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
	public class Triangle : BulletDisposableObject
	{
		internal Triangle(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Triangle()
		{
			IntPtr native = btTriangle_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PartId
		{
			get => btTriangle_getPartId(Native);
			set => btTriangle_setPartId(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TriangleIndex
		{
			get => btTriangle_getTriangleIndex(Native);
			set => btTriangle_setTriangleIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Vertex0
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTriangle_getVertex0(Native, out value);
				return value;
			}
			set => btTriangle_setVertex0(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Vertex1
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTriangle_getVertex1(Native, out value);
				return value;
			}
			set => btTriangle_setVertex1(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Vertex2
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTriangle_getVertex2(Native, out value);
				return value;
			}
			set => btTriangle_setVertex2(Native, ref value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btTriangle_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriangleBuffer : TriangleCallback
	{
		/*
		public TriangleBuffer()
			: base(btTriangleBuffer_new())
		{
		}
		*/

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleBuffer()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearBuffer()
		{
			btTriangleBuffer_clearBuffer(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Triangle GetTriangle(int index)
		{
			return new Triangle(btTriangleBuffer_getTriangle(Native, index), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void ProcessTriangle(ref global::System.Numerics.Vector3 vector0, ref global::System.Numerics.Vector3 vector1, ref global::System.Numerics.Vector3 vector2, int partId, int triangleIndex)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumTriangles => btTriangleBuffer_getNumTriangles(Native);
	}
}
