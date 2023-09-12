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

using System.Numerics;
using System.ComponentModel;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConvexShape : CollisionShape
	{
		protected internal ConvexShape()
		{
		}

		/*
		public void BatchedUnitVectorGetSupportingVertexWithoutMargin(global::System.Numerics.Vector3 vectors,
		 	global::System.Numerics.Vector3 supportVerticesOut, int numVectors)
		{
			btConvexShape_batchedUnitVectorGetSupportingVertexWithoutMargin(Native,
				vectors.Native, supportVerticesOut.Native, numVectors);
		}
		*/

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetAabbNonVirtual(Matrix4x4 t, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btConvexShape_getAabbNonVirtual(Native, ref t, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetAabbSlow(Matrix4x4 t, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btConvexShape_getAabbSlow(Native, ref t, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetPreferredPenetrationDirection(int index, out global::System.Numerics.Vector3 penetrationVector)
		{
			btConvexShape_getPreferredPenetrationDirection(Native, index, out penetrationVector);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalGetSupportingVertex(global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btConvexShape_localGetSupportingVertex(Native, ref vec, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalGetSupportingVertexWithoutMargin(global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btConvexShape_localGetSupportingVertexWithoutMargin(Native, ref vec,
				out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalGetSupportVertexNonVirtual(global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btConvexShape_localGetSupportVertexNonVirtual(Native, ref vec, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalGetSupportVertexWithoutMarginNonVirtual(global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btConvexShape_localGetSupportVertexWithoutMarginNonVirtual(Native, ref vec,
				out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProjectRef(ref Matrix4x4 trans, ref global::System.Numerics.Vector3 dir, out float minProj, out float maxProj,
			out global::System.Numerics.Vector3 witnesPtMin, out global::System.Numerics.Vector3 witnesPtMax)
		{
			btConvexShape_project(Native, ref trans, ref dir, out minProj, out maxProj,
				out witnesPtMin, out witnesPtMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Project(Matrix4x4 trans, global::System.Numerics.Vector3 dir, out float minProj, out float maxProj,
			out global::System.Numerics.Vector3 witnesPtMin, out global::System.Numerics.Vector3 witnesPtMax)
		{
			btConvexShape_project(Native, ref trans, ref dir, out minProj, out maxProj,
				out witnesPtMin, out witnesPtMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MarginNonVirtual => btConvexShape_getMarginNonVirtual(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumPreferredPenetrationDirections => btConvexShape_getNumPreferredPenetrationDirections(Native);
	}
}
