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
	public class Element : BulletObject
	{
		internal Element(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Id
		{
			get => btElement_getId(Native);
			set => btElement_setId(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Sz
		{
			get => btElement_getSz(Native);
			set => btElement_setSz(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UnionFind : BulletObject
	{
		internal UnionFind(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Allocate(int n)
		{
			btUnionFind_allocate(Native, n);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Find(int p, int q)
		{
			return btUnionFind_find(Native, p, q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Find(int x)
		{
			return btUnionFind_find2(Native, x);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Free()
		{
			btUnionFind_Free(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Element GetElement(int index)
		{
			return new Element(btUnionFind_getElement(Native, index));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsRoot(int x)
		{
			return btUnionFind_isRoot(Native, x);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Reset(int n)
		{
			btUnionFind_reset(Native, n);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SortIslands()
		{
			btUnionFind_sortIslands(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Unite(int p, int q)
		{
			btUnionFind_unite(Native, p, q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumElements => btUnionFind_getNumElements(Native);
	}
}
