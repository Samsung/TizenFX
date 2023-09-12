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
	public class HeightfieldTerrainShape : ConcaveShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HeightfieldTerrainShape(int heightStickWidth, int heightStickLength,
			IntPtr heightfieldData, float heightScale, float minHeight, float maxHeight,
			int upAxis, PhyScalarType heightDataType, bool flipQuadEdges)
		{
			IntPtr native = btHeightfieldTerrainShape_new(heightStickWidth, heightStickLength,
				heightfieldData, heightScale, minHeight, maxHeight, upAxis, heightDataType,
				flipQuadEdges);
			InitializeCollisionShape(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PerformRaycast(TriangleCallback callback, ref global::System.Numerics.Vector3 raySource, ref global::System.Numerics.Vector3 rayTarget)
		{
			btHeightfieldTerrainShape_performRaycast(Native, callback.Native, ref raySource, ref rayTarget);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildAccelerator(int chunkSize)
		{
			btHeightfieldTerrainShape_buildAccelerator(Native, chunkSize);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearAccelerator()
		{
			btHeightfieldTerrainShape_clearAccelerator(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFlipTriangleWinding(bool flipTriangleWinding)
		{
			btHeightfieldTerrainShape_setFlipTriangleWinding(Native, flipTriangleWinding);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetUseDiamondSubdivision()
		{
			btHeightfieldTerrainShape_setUseDiamondSubdivision(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetUseDiamondSubdivision(bool useDiamondSubdivision)
		{
			btHeightfieldTerrainShape_setUseDiamondSubdivision2(Native, useDiamondSubdivision);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetUseZigzagSubdivision()
		{
			btHeightfieldTerrainShape_setUseZigzagSubdivision(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetUseZigzagSubdivision(bool useZigzagSubdivision)
		{
			btHeightfieldTerrainShape_setUseZigzagSubdivision2(Native, useZigzagSubdivision);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UpAxis => btHeightfieldTerrainShape_getUpAxis(Native);
	}
}
