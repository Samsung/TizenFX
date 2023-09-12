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
using System.Runtime.InteropServices;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class TaskScheduler
	{
		internal readonly IntPtr Native;

		internal TaskScheduler(IntPtr native)
		{
			Native = native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MaxNumThreads => btITaskScheduler_getMaxNumThreads(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string Name => Marshal.PtrToStringAnsi(btITaskScheduler_getName(Native));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumThreads
		{
			get => btITaskScheduler_getNumThreads(Native);
			set => btITaskScheduler_setNumThreads(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class TaskSchedulerSequential : TaskScheduler
	{
		internal TaskSchedulerSequential(IntPtr native)
			: base(native)
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class TaskSchedulerOpenMP : TaskScheduler
	{
		internal TaskSchedulerOpenMP(IntPtr native)
			: base(native)
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class TaskSchedulerTbb : TaskScheduler
	{
		internal TaskSchedulerTbb(IntPtr native)
			: base(native)
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class TaskSchedulerPpl : TaskScheduler
	{
		internal TaskSchedulerPpl(IntPtr native)
			: base(native)
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Threads
	{
		private static TaskSchedulerOpenMP _taskSchedulerOpenMP;
		private static TaskSchedulerPpl _taskSchedulerPpl;
		private static TaskSchedulerSequential _taskSchedulerSequential;
		private static TaskSchedulerTbb _taskSchedulerTbb;
		private static TaskScheduler _taskScheduler;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static TaskScheduler TaskScheduler
		{
			get => _taskScheduler;
			set
			{
				_taskScheduler = value;
				btThreads_btSetTaskScheduler(value != null ? value.Native : IntPtr.Zero);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static TaskSchedulerOpenMP GetOpenMPTaskScheduler()
		{
			if (_taskSchedulerOpenMP == null)
			{
				IntPtr native = btThreads_btGetOpenMPTaskScheduler();
				if (native != IntPtr.Zero)
				{
					_taskSchedulerOpenMP = new TaskSchedulerOpenMP(native);
				}
			}
			return _taskSchedulerOpenMP;
		}


		[EditorBrowsable(EditorBrowsableState.Never)]
		public static TaskSchedulerPpl GetPplTaskScheduler()
		{
			if (_taskSchedulerPpl == null)
			{
				IntPtr native = btThreads_btGetPPLTaskScheduler();
				if (native != IntPtr.Zero)
				{
					_taskSchedulerPpl = new TaskSchedulerPpl(native);
				}
			}
			return _taskSchedulerPpl;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static TaskSchedulerSequential GetSequentialTaskScheduler()
		{
			if (_taskSchedulerSequential == null)
			{
				_taskSchedulerSequential = new TaskSchedulerSequential(btThreads_btGetSequentialTaskScheduler());
			}
			return _taskSchedulerSequential;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static TaskSchedulerTbb GetTbbTaskScheduler()
		{
			if (_taskSchedulerTbb == null)
			{
				IntPtr native = btThreads_btGetTBBTaskScheduler();
				if (native != IntPtr.Zero)
				{
					_taskSchedulerTbb = new TaskSchedulerTbb(native);
				}
			}
			return _taskSchedulerTbb;
		}
	}
}
