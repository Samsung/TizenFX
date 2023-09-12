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
	public class MultiBodyPoint2Point : MultiBodyConstraint
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBodyPoint2Point(MultiBody body, int link, RigidBody bodyB, global::System.Numerics.Vector3 pivotInA,
		 	global::System.Numerics.Vector3 pivotInB)
		{
			IntPtr native = btMultiBodyPoint2Point_new(body.Native, link, bodyB != null ? bodyB.Native : IntPtr.Zero,
				ref pivotInA, ref pivotInB);
			InitializeUserOwned(native);
			InitializeMembers(body, null);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBodyPoint2Point(MultiBody bodyA, int linkA, MultiBody bodyB,
			int linkB, global::System.Numerics.Vector3 pivotInA, global::System.Numerics.Vector3 pivotInB)
		{
			IntPtr native = btMultiBodyPoint2Point_new2(bodyA.Native, linkA, bodyB.Native,
				linkB, ref pivotInA, ref pivotInB);
			InitializeUserOwned(native);
			InitializeMembers(bodyA, bodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 PivotInB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBodyPoint2Point_getPivotInB(Native, out value);
				return value;
			}
			set => btMultiBodyPoint2Point_setPivotInB(Native, ref value);
		}
	}
}
