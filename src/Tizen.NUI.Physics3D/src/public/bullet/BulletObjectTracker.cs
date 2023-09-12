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
using System.Collections.Generic;
using System.Linq;
#if !BULLET_OBJECT_TRACKING
using System.Diagnostics;
#endif

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class BulletObjectTracker
	{
		private readonly object _userOwnedObjectsLock = new object();
		private HashSet<BulletObject> _userOwnedObjects { get; set; } = new HashSet<BulletObject>();

		private BulletObjectTracker()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IList<BulletObject> GetUserOwnedObjects()
		{
			lock (_userOwnedObjectsLock)
			{
				return _userOwnedObjects.ToList();
			}
		}

#if BULLET_OBJECT_TRACKING
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static BulletObjectTracker Current { get; } = new BulletObjectTracker();

		internal static void Add(BulletDisposableObject obj)
		{
			Current.AddRef(obj);
		}

		internal static void Remove(BulletDisposableObject obj)
		{
			Current.RemoveRef(obj);
		}

		private void AddRef(BulletDisposableObject obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(nameof(obj));
			}

			if (obj.Owner == null)
			{
				lock (_userOwnedObjectsLock)
				{
					if (_userOwnedObjects.Contains(obj))
					{
						throw new Exception("Adding an object that is already being tracked. " +
							"Object info: " + obj.GetType());
					}
					_userOwnedObjects.Add(obj);
				}
			}
		}

		private void RemoveRef(BulletDisposableObject obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(nameof(obj));
			}

			if (obj.Owner == null)
			{
				lock (_userOwnedObjectsLock)
				{
					if (_userOwnedObjects.Contains(obj) == false)
					{
						throw new Exception("Removing object that is not being tracked. " +
							"Object info: " + obj.GetType());
					}
					_userOwnedObjects.Remove(obj);
				}
			}
		}
#else
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static BulletObjectTracker Current { get; } = null;

		[Conditional("BULLET_OBJECT_TRACKING")]
		internal static void Add(BulletDisposableObject obj)
		{
		}

		[Conditional("BULLET_OBJECT_TRACKING")]
		internal static void Remove(BulletDisposableObject obj)
		{
		}
#endif
	}
}
