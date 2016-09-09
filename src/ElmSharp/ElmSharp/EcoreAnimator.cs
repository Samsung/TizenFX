using System;
using System.Collections.Generic;

namespace ElmSharp
{
    public static class EcoreAnimator
    {
        static readonly Dictionary<int, Func<bool>> _taskMap = new Dictionary<int, Func<bool>>();
        static readonly Object _taskLock = new Object();
        static int _newTaskId = 0;

        static Interop.Ecore.EcoreTaskCallback _nativeHandler;

        static EcoreAnimator()
        {
            _nativeHandler = NativeHandler;
        }

        public static double GetCurrentTime()
        {
            return Interop.Ecore.ecore_time_get();
        }

        public static IntPtr AddAmimator(Func<bool> handler)
        {
            int id = RegistHandler(handler);
            return Interop.Ecore.ecore_animator_add(_nativeHandler, (IntPtr)id);
        }

        public static void RemoveAnimator(IntPtr anim)
        {
            int taskId = (int)Interop.Ecore.ecore_animator_del(anim);
            _taskMap.Remove(taskId);
        }

        static int RegistHandler(Func<bool> task)
        {
            int taskId;
            lock (_taskLock)
            {
                taskId = _newTaskId++;
            }
            _taskMap[taskId] = task;
            return taskId;
        }

        static bool NativeHandler(IntPtr userData)
        {
            int task_id = (int)userData;
            Func<bool> userAction = null;
            _taskMap.TryGetValue(task_id, out userAction);
            return (userAction != null)?userAction():false;
        }

    }
}
