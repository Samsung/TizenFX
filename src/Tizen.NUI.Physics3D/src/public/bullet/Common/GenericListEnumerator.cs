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

using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class GenericListEnumerator<T> : IEnumerator<T>
	{
		private int _i;
		private readonly int _count;
		private readonly IList<T> _list;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GenericListEnumerator(IList<T> list)
		{
			_list = list;
			_count = list.Count;
			_i = -1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public T Current => _list[_i];

		object IEnumerator.Current => _list[_i];

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool MoveNext()
		{
			_i++;
			return _i != _count;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Reset()
		{
			_i = 0;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
		}
	}
}
