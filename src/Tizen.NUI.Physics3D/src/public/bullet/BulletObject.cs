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

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class BulletObject
	{
		internal IntPtr Native;

		protected internal void Initialize(IntPtr native)
		{
			if (native == IntPtr.Zero)
			{
				throw new ArgumentNullException(nameof(native));
			}

			if (Native != IntPtr.Zero)
			{
				throw new InvalidOperationException("Bullet object already initialized.");
			}

			Native = native;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class BulletDisposableObject : BulletObject, IDisposable
	{
		// Initialize an object that should be disposed by the user.
		protected internal void InitializeUserOwned(IntPtr native)
		{
			Initialize(native);
#if !BULLET_OBJECT_TRACKING
			IsUserOwned = true;
#endif
			BulletObjectTracker.Add(this);
		}

		// Initialize an object that is part of another object or deleted by another object.
		// These objects should not be deleted in the Dispose method of this wrapper class.
		protected internal void InitializeSubObject(IntPtr native, BulletObject owner)
		{
			Initialize(native);
#if BULLET_OBJECT_TRACKING
			Owner = owner;
#endif
			BulletObjectTracker.Add(this);
			GC.SuppressFinalize(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsDisposed { get; private set; }
#if BULLET_OBJECT_TRACKING
		internal BulletObject Owner { get; private set; }

		internal bool IsUserOwned => Owner == null;
#else
		internal bool IsUserOwned { get; private set; }
#endif

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
			if (IsDisposed == false)
			{
				Dispose(true);

				IsDisposed = true;
				BulletObjectTracker.Remove(this);

				GC.SuppressFinalize(this);
			}
		}

		protected abstract void Dispose(bool disposing);

		~BulletDisposableObject()
		{
			if (IsDisposed == false)
			{
				Dispose(false);

				IsDisposed = true;
				BulletObjectTracker.Remove(this);
			}
		}
	}

	// This class is used to differentiate between a public constructor
	// without parameters and an internal constructor that initializes a base class.
	internal sealed class ConstructionInfo
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static ConstructionInfo Null = null;
	}
}
