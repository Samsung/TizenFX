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

/*
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Tizen.NUI.Physics3D.Bullet
{
	public abstract class ContactConstraint : TypedConstraint
	{
		public PersistentManifold ContactManifold
		{
            get { return new PersistentManifold(btContactConstraint_getContactManifold(_native), true); }
			set { btContactConstraint_setContactManifold(_native, value._native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btContactConstraint_getContactManifold(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btContactConstraint_setContactManifold(IntPtr obj, IntPtr contactManifold);
	}
}
*/
