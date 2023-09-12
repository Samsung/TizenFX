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
	public class CollisionObjectWrapper : BulletObject
	{
		internal CollisionObjectWrapper(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject CollisionObject
		{
			get => CollisionObject.GetManaged(btCollisionObjectWrapper_getCollisionObject(Native));
			set => btCollisionObjectWrapper_setCollisionObject(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShape CollisionShape
		{
			get => CollisionShape.GetManaged(btCollisionObjectWrapper_getCollisionShape(Native));
			set => btCollisionObjectWrapper_setShape(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Index
		{
			get => btCollisionObjectWrapper_getIndex(Native);
			set => btCollisionObjectWrapper_setIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObjectWrapper Parent
		{
			get => new CollisionObjectWrapper(btCollisionObjectWrapper_getParent(Native));
			set => btCollisionObjectWrapper_setParent(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PartId
		{
			get => btCollisionObjectWrapper_getPartId(Native);
			set => btCollisionObjectWrapper_setPartId(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 WorldTransform
		{
			get
			{
				Matrix4x4 value;
				btCollisionObjectWrapper_getWorldTransform(Native, out value);
				return value;
			}
		}
	}
}
