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
using System.Runtime.InteropServices;
using System.Security;
using System.Numerics;

namespace Tizen.NUI.Physics3D.Bullet
{
    /*
	public class SphereTriangleDetector : DiscreteCollisionDetectorInterface
	{
		internal SphereTriangleDetector(IntPtr native)
			: base(native)
		{
		}

		public SphereTriangleDetector(SphereShape sphere, TriangleShape triangle,
			float contactBreakingThreshold)
			: base(SphereTriangleDetector_new(sphere._native, triangle._native, contactBreakingThreshold))
		{
		}

		public bool Collide(global::System.Numerics.Vector3 sphereCenter, out global::System.Numerics.Vector3 point, out global::System.Numerics.Vector3 resultNormal,
			out float depth, out float timeOfImpact, float contactBreakingThreshold)
		{
			return SphereTriangleDetector_collide(_native, ref sphereCenter, out point,
				out resultNormal, out depth, out timeOfImpact, contactBreakingThreshold);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr SphereTriangleDetector_new(IntPtr sphere, IntPtr triangle, float contactBreakingThreshold);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool SphereTriangleDetector_collide(IntPtr obj, [In] ref global::System.Numerics.Vector3 sphereCenter, out global::System.Numerics.Vector3 point, out global::System.Numerics.Vector3 resultNormal, out float depth, out float timeOfImpact, float contactBreakingThreshold);
	}
    */
}
