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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class MultiBodyLinkCollider : CollisionObject
	{
		private MultiBody _multiBody;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBodyLinkCollider(MultiBody multiBody, int link)
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btMultiBodyLinkCollider_new(multiBody.Native, link);
			InitializeCollisionObject(native);

			_multiBody = multiBody;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static MultiBodyLinkCollider Upcast(CollisionObject colObj)
		{
			return GetManaged(btMultiBodyLinkCollider_upcast(colObj.Native)) as MultiBodyLinkCollider;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Link
		{
			get => btMultiBodyLinkCollider_getLink(Native);
			set => btMultiBodyLinkCollider_setLink(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBody MultiBody
		{
			get => _multiBody;
			set
			{
				btMultiBodyLinkCollider_setMultiBody(Native, value.Native);
				_multiBody = value;
			}
		}
	}
}
