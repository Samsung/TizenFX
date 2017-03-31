using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

using Tizen.Security.TEEC;

class Test {
	static void Main() {
		Guid ta_uuid = new Guid();
		Context ctx = new Context(null);
		Session ses = null;

		ctx.OpenSession(ta_uuid);
		ses.Close();

		CancellationTokenSource token = new CancellationTokenSource();
		Task<Session> ses_task = ctx.OpenSessionAsync(ta_uuid, token.Token);
		ses = ses_task.Result;
		ses.Close();

		IntPtr buf = Marshal.AllocHGlobal(20*1024);
		SharedMemory shm = ctx.RegisterSharedMemory(buf, 20*1024, SharedMemoryFlags.Input|SharedMemoryFlags.Output);
		ctx.ReleaseSharedMemory(shm);
		Marshal.FreeHGlobal(buf);

		shm = ctx.AllocateSharedMemory(10*1024, SharedMemoryFlags.Input);
		ctx.ReleaseSharedMemory(shm);
	}
}
