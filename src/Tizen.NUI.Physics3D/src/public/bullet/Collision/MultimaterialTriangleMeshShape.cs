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
	public class MultimaterialTriangleMeshShape : BvhTriangleMeshShape
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultimaterialTriangleMeshShape(StridingMeshInterface meshInterface,
			bool useQuantizedAabbCompression, bool buildBvh = true)
		{
			IntPtr native = btMultimaterialTriangleMeshShape_new(meshInterface.Native, useQuantizedAabbCompression,
				buildBvh);
			InitializeCollisionShape(native);
			InitializeMembers(meshInterface);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultimaterialTriangleMeshShape(StridingMeshInterface meshInterface,
			bool useQuantizedAabbCompression, global::System.Numerics.Vector3 bvhAabbMin, global::System.Numerics.Vector3 bvhAabbMax,
			bool buildBvh = true)
		{
			IntPtr native = btMultimaterialTriangleMeshShape_new2(meshInterface.Native, useQuantizedAabbCompression,
				ref bvhAabbMin, ref bvhAabbMax, buildBvh);
			InitializeCollisionShape(native);
			InitializeMembers(meshInterface);
		}
		/*
		public BulletMaterial GetMaterialProperties(int partID, int triIndex)
		{
			return btMultimaterialTriangleMeshShape_getMaterialProperties(Native,
				partID, triIndex);
		}
		*/
	}
}
