/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.IO;

namespace Tizen.Security.TEEC
{
    /// <summary>
    /// This type denotes the Session Login Method used in OpenSession.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class LoginMethod
    {
        /// <summary>No login data is provided.</summary>
        /// <since_tizen> 3 </since_tizen>
        public const uint Public      = 0x00000000;
        /// <summary>Login data about the user running the client application process is provided.</summary>
        /// <since_tizen> 3 </since_tizen>
        public const uint User        = 0x00000001;
        /// <summary>Login data about the group running the client application process is provided.</summary>
        /// <since_tizen> 3 </since_tizen>
        public const uint Group       = 0x00000002;
        /// <summary>Login data about the running client application itself is provided.</summary>
        /// <since_tizen> 3 </since_tizen>
        public const uint Application = 0x00000003;
    }

    /// <summary>
    /// This type denotes the Value parameter.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TEFValueType : UInt32
    {
        /// <summary>The parameter is a ValueType tagged as the input.</summary>
        Input  = 0x00000001,
        /// <summary>The parameter is a ValueType tagged as the output.</summary>
        Output = 0x00000002,
        /// <summary>The parameter is a ValueType tagged as both the input and the output.</summary>
        InOut  = 0x00000003,
    }

    /// <summary>
    /// This type denotes the TempMemoryReference parameter
    /// describing a region of memory which needs to be temporarily registered for the duration of the operation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TEFTempMemoryType : UInt32
    {
        /// <summary>The parameter is a TempMemoryType and is tagged as the input.</summary>
        Input  = 0x00000005,
        /// <summary>Same as the input, but the Memory Reference is tagged as the output.</summary>
        Output = 0x00000006,
        /// <summary>A Temporary Memory Reference tagged as both the input and the output.</summary>
        InOut  = 0x00000007,
    }

    /// <summary>
    /// This type denotes the SharedMemoryReference parameter.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TEFRegisteredMemoryType : UInt32
    {
        /// <summary>The parameter is a registered memory reference that refers to the entirety of its parent shared memory block.</summary>
        Whole         = 0x0000000C,
        /// <summary>A registered memory reference structure that refers to a partial region of its parent shared mMemory block and is tagged as the input.</summary>
        PartialInput  = 0x0000000D,
        /// <summary>A registered memory reference structure that refers to a partial region of its parent shared memory block and is tagged as the output.</summary>
        PartialOutput = 0x0000000E,
        /// <summary>A registered memory reference structure that refers to a partial region of its parent shared memory block and is tagged as both the input and the output.</summary>
        PartialInOut  = 0x0000000F,
    }

    /// <summary>
    /// This type denotes the SharedMemory access direction.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Flags]
    public enum SharedMemoryFlags : UInt32
    {
        /// <summary>A flag indicates the shared memory can be read.</summary>
        Input  = 0x00000001,
        /// <summary>A flag indicates the shared memory can be written.</summary>
        Output = 0x00000002,
        /// <summary>A flag indicates the shared memory can be read and written.</summary>
        InOut = Input | Output,
    }

    /// <summary>
    /// This type denotes a shared memory block which has been either registered
    /// with the implementation or allocated by it.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class SharedMemory : IDisposable
    {
        private bool disposed = false;
        private bool initialized = false;
        private Context context; // keep reference for correct finalizers order
        internal Interop.TEEC_SharedMemory shm;
        internal IntPtr shmptr;
        internal SharedMemory(Context context)
        {
            this.context = context;
            shmptr = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.TEEC_SharedMemory>());
        }
        internal void setShm(ref Interop.TEEC_SharedMemory shm)
        {
            this.shm = shm;
            Marshal.StructureToPtr(shm, shmptr, false);
            initialized = true;
            ++context.shmcnt;
        }
        private void Dispose(bool disposing)
        {
            if (disposed) {
                return ;
            }
            if (context == null) {
                throw new Exception("internal error: context is null");
            }
            if (initialized) {
                Interop.Libteec.ReleaseSharedMemory(ref shm);
                initialized = false;
                --context.shmcnt;
            }
            Marshal.FreeHGlobal(shmptr);
            shmptr = IntPtr.Zero;
            context = null;
            disposed = true;
        }

        /// <summary>
        /// Destructor of the class.
        /// </summary>
        ~SharedMemory()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposable interface implememtation.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// This property represents the shared memory size in bytes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        public UInt32 Size
        {
            get { return shm.size.ToUInt32(); }
        }
        /// <summary>
        /// This property represents the start address of the shared memory block.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        public IntPtr Address
        {
            get { return shm.buffer; }
        }

        /// <summary>
        /// This function makes a copy and is designed for convenient operations on small buffers.
        /// For large buffers, the direct address should be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <param name="data">The source data buffer to copy data from.</param>
        /// <param name="dstOffs">The starting offset in the destination shared memory.</param>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public void SetData(byte[] data, int dstOffs)
        {
            Marshal.Copy(data, 0, shm.buffer + dstOffs, data.Length);
        }
        /// <summary>
        /// This function makes a copy and is designed for convenient operations on small buffers.
        /// For large buffers, the direct address should be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <param name="data">The destination data buffer to copy data into.</param>
        /// <param name="srcOffs">The starting offset in the source shared memory.</param>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public void GetData(byte[] data, int srcOffs)
        {
            Marshal.Copy(shm.buffer + srcOffs, data, 0, data.Length);
        }
    };

    /// <summary>
    /// This type defines the payload of either an open session operation or an invoke command operation. It is
    /// also used for cancelation of operations, which may be desirable even if no payload is passed.
    /// Parameters are used to exchange data between CA and TA.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class Parameter
    {
        internal Parameter(uint t)
        {
            this.NativeType = t;
        }
        internal uint NativeType { get; }
    };

    /// <summary>
    /// This type defines a template for the parameter types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class BaseParameter<TEnum> : Parameter where TEnum : struct, IComparable, IFormattable, IConvertible // as close to Enum as possible
    {
        internal BaseParameter(TEnum t) : base((uint)(object)t)
        {
            Type = t;
        }

        /// <summary>
        /// This property represents the access type to this parameter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TEnum Type { get; }
    }

    /// <summary>
    /// This type defines a temporary memory reference.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class TempMemoryReference : BaseParameter<TEFTempMemoryType>
    {
        /// <summary>
        /// Constructs a parameter object which holds information about the temporary memory copied to or from TA.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="buffer">The address of the allocated memory buffer.</param>
        /// <param name="size">The size of the buffer.</param>
        /// <param name="type">The kind of access allowed for TA <see cref="TEFTempMemoryType"/>.</param>
        public TempMemoryReference(IntPtr buffer, uint size, TEFTempMemoryType type) :
                base(type)
        {
            this.Buffer = buffer;
            this.Size = size;
        }
        /// <summary>
        /// This property represents the memory address of the buffer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IntPtr Buffer { get; }
        /// <summary>
        /// This property represents the size of the buffer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Size { get; internal set; }
    };

    /// <summary>
    /// This type defines a memory reference that uses a pre-registered or pre-allocated shared memory block.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class RegisteredMemoryReference : BaseParameter<TEFRegisteredMemoryType>
    {
        /// <summary>
        /// Constructs a parameter object which holds information about the registered memory shared with TA.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <param name="parent">The shared memory - registered or allocated.</param>
        /// <param name="size">The size of the buffer part.</param>
        /// <param name="offset">The offset of the buffer in the shared memory.</param>
        /// <param name="type">The kind of access allowed for TA <see cref="TEFRegisteredMemoryType"/>.</param>
        public RegisteredMemoryReference(SharedMemory parent, uint size, uint offset, TEFRegisteredMemoryType type) :
                base(type)
        {
            this.Parent = parent;
            if (type == TEFRegisteredMemoryType.Whole) {
                this.Size = parent.Size;
                this.Offset = 0;
            }
            else {
                this.Size = size;
                this.Offset = offset;
            }
        }

        /// <summary>
        /// This property represents the shared memory that is referred to.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        public SharedMemory Parent { get; }
        /// <summary>
        /// This property represents the size (in bytes) of the shared memory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        public uint Size { get; internal set; }
        /// <summary>
        /// This property represents the offset (in bytes) from the start of the shared memory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        public uint Offset { get; }
    };

    /// <summary>
    /// This type defines a parameter that is not referencing the shared memory, but carries instead small raw data
    /// passed by a value.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class Value : BaseParameter<TEFValueType>
    {
        /// <summary>
        /// Constructs a parameter object which holds information about integer values copied to or from TA.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="a">User paramter A.</param>
        /// <param name="b">User paramter B.</param>
        /// <param name="type">The kind of access allowed for TA <see cref="TEFValueType"/>.</param>
        public Value(uint a, uint b, TEFValueType type) :
                base(type)
        {
            this.A = a;
            this.B = b;
        }
        /// <summary>
        /// This property represents an unsigned integer A.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint A { get; internal set; }
        /// <summary>
        /// This property represents an unsigned integer B.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint B { get; internal set; }
    };


    /// <summary>
    /// This type denotes a TEE Session, the logical container linking a client application with a particular trusted application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class Session : IDisposable
    {
        private bool disposed = false;
        private bool opened = false;
        private Context context;
        private IntPtr session_imp;
        private IntPtr opptr;
        private SharedMemory[] shm = new SharedMemory[4];

        internal Session(Context context) {
            this.context = context;
            this.session_imp = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.TEEC_Session>());
            this.opptr = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.TEEC_Operation64>());
            for (int i=0; i < 4; ++i) shm[i] = null;
        }

        private void Dispose(bool disposing)
        {
            if (disposed) {
                return ;
            }
            if (opened) {
                Interop.Libteec.CloseSession(session_imp);
                opened = false;
            }
            Marshal.FreeHGlobal(this.opptr);
            Marshal.FreeHGlobal(this.session_imp);
            this.opptr = IntPtr.Zero;
            this.session_imp = IntPtr.Zero;
            disposed = true;
        }

        /// <summary>
        /// Destructor of the class.
        /// </summary>
        ~Session()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposable interface implememtation.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal UInt32 InitParam(ref Interop.TEEC_Parameter32[] dst, int i, Parameter src)
        {
            if (IntPtr.Size != 4) throw new Exception("wrong arch - not 32bit");
            UInt32 rType = src.NativeType;
            switch (src.NativeType) {
                case (int)TEFValueType.Input:
                case (int)TEFValueType.Output:
                case (int)TEFValueType.InOut:
                    dst[i].value.a = ((Value)src).A;
                    dst[i].value.b = ((Value)src).B;
                    break;

                case (int)TEFTempMemoryType.Input:
                case (int)TEFTempMemoryType.Output:
                case (int)TEFTempMemoryType.InOut:
                    byte[] mem = new byte[(uint)((TempMemoryReference)src).Size];
                    Marshal.Copy(((TempMemoryReference)src).Buffer, mem, 0, mem.Length);
                    shm[i] = context.AllocateSharedMemory((uint)mem.Length, SharedMemoryFlags.InOut);
                    Marshal.Copy(mem, 0, shm[i].shm.buffer, mem.Length);
                    dst[i].tmpref.size = (uint)mem.Length;
                    dst[i].tmpref.buffer = shm[i].shm.buffer.ToInt32();
                    break;

                case (int)TEFRegisteredMemoryType.Whole:
                    RegisteredMemoryReference rmrw = (RegisteredMemoryReference)src;
                    rType = ((int)TEFRegisteredMemoryType.PartialInput & (int)TEFRegisteredMemoryType.PartialOutput) | rmrw.Parent.shm.flags;
                    dst[i].memref.parent = rmrw.Parent.shmptr.ToInt32();
                    dst[i].memref.size = rmrw.Size;
                    dst[i].memref.offset = rmrw.Offset;
                    break;

                case (int)TEFRegisteredMemoryType.PartialInput:
                case (int)TEFRegisteredMemoryType.PartialOutput:
                case (int)TEFRegisteredMemoryType.PartialInOut:
                    RegisteredMemoryReference rmr = (RegisteredMemoryReference)src;
                    dst[i].memref.parent = rmr.Parent.shmptr.ToInt32();
                    dst[i].memref.size = rmr.Size;
                    dst[i].memref.offset = rmr.Offset;
                    break;

                default: return 0;
            }
            return rType;
        }

        internal void UpdateParam(Interop.TEEC_Parameter32 src, ref Parameter[] dst, int i)
        {
            if (IntPtr.Size != 4) throw new Exception("wrong arch - not 32bit");
            switch (dst[i].NativeType) {
                case (int)TEFValueType.Input:
                case (int)TEFValueType.Output:
                case (int)TEFValueType.InOut:
                    ((Value)dst[i]).A = src.value.a;
                    ((Value)dst[i]).B = src.value.b;
                    break;

                case (int)TEFTempMemoryType.Input:
                case (int)TEFTempMemoryType.Output:
                case (int)TEFTempMemoryType.InOut:
                    byte[] mem = new byte[src.tmpref.size];
                    Marshal.Copy(shm[i].shm.buffer, mem, 0, mem.Length);
                    Marshal.Copy(mem, 0, ((TempMemoryReference)dst[i]).Buffer, mem.Length);
                    ((TempMemoryReference)dst[i]).Size = src.tmpref.size;
                    break;

                case (int)TEFRegisteredMemoryType.Whole:
                case (int)TEFRegisteredMemoryType.PartialInput:
                case (int)TEFRegisteredMemoryType.PartialOutput:
                case (int)TEFRegisteredMemoryType.PartialInOut:
                    ((RegisteredMemoryReference)dst[i]).Size = src.memref.size;
                    break;

                default: break;
            }
        }

        static internal Interop.TEEC_Operation32 Create_TEEC_Operation32() {
            Interop.TEEC_Operation32 op = new Interop.TEEC_Operation32();
            op.started=0;
            op.paramTypes=0;
            op.paramlist = new Interop.TEEC_Parameter32[4];
            return op;
        }

        internal UInt32 InitParam(ref Interop.TEEC_Parameter64[] dst, int i, Parameter src)
        {
            if (IntPtr.Size != 8) throw new Exception("wrong arch - not 64bit");
            UInt32 rType = src.NativeType;
            switch (src.NativeType) {
                case (int)TEFValueType.Input:
                case (int)TEFValueType.Output:
                case (int)TEFValueType.InOut:
                    dst[i].value.a = ((Value)src).A;
                    dst[i].value.b = ((Value)src).B;
                    break;

                case (int)TEFTempMemoryType.Input:
                case (int)TEFTempMemoryType.Output:
                case (int)TEFTempMemoryType.InOut:
                    byte[] mem = new byte[(uint)((TempMemoryReference)src).Size];
                    Marshal.Copy(((TempMemoryReference)src).Buffer, mem, 0, mem.Length);
                    shm[i] = context.AllocateSharedMemory((uint)mem.Length, SharedMemoryFlags.InOut);
                    Marshal.Copy(mem, 0, shm[i].shm.buffer, mem.Length);
                    dst[i].tmpref.size = (UInt64)mem.Length;
                    dst[i].tmpref.buffer = shm[i].shm.buffer.ToInt64();
                    break;

                case (int)TEFRegisteredMemoryType.Whole:
                    RegisteredMemoryReference rmrw = (RegisteredMemoryReference)src;
                    rType = ((int)TEFRegisteredMemoryType.PartialInput & (int)TEFRegisteredMemoryType.PartialOutput) | rmrw.Parent.shm.flags;
                    dst[i].memref.parent = rmrw.Parent.shmptr.ToInt64();
                    dst[i].memref.size = rmrw.Size;
                    dst[i].memref.offset = rmrw.Offset;
                    break;

                case (int)TEFRegisteredMemoryType.PartialInput:
                case (int)TEFRegisteredMemoryType.PartialOutput:
                case (int)TEFRegisteredMemoryType.PartialInOut:
                    RegisteredMemoryReference rmr = (RegisteredMemoryReference)src;
                    dst[i].memref.parent = rmr.Parent.shmptr.ToInt64();
                    dst[i].memref.size = rmr.Size;
                    dst[i].memref.offset = rmr.Offset;
                    break;

                default:
                    break;
            }
            return rType;
        }

        internal void UpdateParam(Interop.TEEC_Parameter64 src, ref Parameter[] dst, int i)
        {
            if (IntPtr.Size != 8) throw new Exception("wrong arch - not 64bit");
            switch (dst[i].NativeType) {
               case (int)TEFValueType.Input:
               case (int)TEFValueType.Output:
               case (int)TEFValueType.InOut:
                   ((Value)dst[i]).A = src.value.a;
                   ((Value)dst[i]).B = src.value.b;
                   break;

               case (int)TEFTempMemoryType.Input:
               case (int)TEFTempMemoryType.Output:
               case (int)TEFTempMemoryType.InOut:
                    byte[] mem = new byte[src.tmpref.size];
                    Marshal.Copy(shm[i].shm.buffer, mem, 0, mem.Length);
                    Marshal.Copy(mem, 0, ((TempMemoryReference)dst[i]).Buffer, mem.Length);
                   ((TempMemoryReference)dst[i]).Size = (uint)src.tmpref.size;
                   break;

               case (int)TEFRegisteredMemoryType.Whole:
               case (int)TEFRegisteredMemoryType.PartialInput:
               case (int)TEFRegisteredMemoryType.PartialOutput:
               case (int)TEFRegisteredMemoryType.PartialInOut:
                   ((RegisteredMemoryReference)dst[i]).Size = (uint)src.memref.size;
                   break;

               default: break;
            }
        }

        static internal Interop.TEEC_Operation64 Create_TEEC_Operation64() {
            Interop.TEEC_Operation64 op = new Interop.TEEC_Operation64();
            op.started=0;
            op.paramTypes=0;
            op.paramlist = new Interop.TEEC_Parameter64[4];
            return op;
        }

        internal void Open32(Guid destination, uint loginMethod, byte[] connectionData, Parameter[] paramlist)
        {
            Interop.TEEC_UUID uuid = Interop.TEEC_UUID.ToTeecUuid(destination);

            int ret;
            uint ro;
            if (paramlist != null) {
                Interop.TEEC_Operation32 op = Create_TEEC_Operation32();
                for (int i=0; i < 4 && i < paramlist.Length; ++i) {
                    op.paramTypes |= InitParam(ref op.paramlist, i, paramlist[i]) << (8*i);
                }
                Marshal.StructureToPtr(op, opptr, false);
                ret = Interop.Libteec.OpenSession(context.context_imp, session_imp, ref uuid, loginMethod, connectionData, opptr, out ro);
                op = Marshal.PtrToStructure<Interop.TEEC_Operation32>(opptr);
                for (int i=0; i < 4 && i < paramlist.Length; ++i) {
                    UpdateParam(op.paramlist[i], ref paramlist, i);
                }
            }
            else {
                ret = Interop.Libteec.OpenSession(context.context_imp, session_imp, ref uuid, loginMethod, connectionData, IntPtr.Zero, out ro);
            }

            for (int i=0; i < 4; ++i) {
                if (shm[i] != null) {
                    shm[i].Dispose();
                    shm[i] = null;
                }
            }

            //MAYBE map origin of return code to specyfic Exception
            Interop.CheckNThrowException(ret, string.Format("OpenSession('{0}')", destination));
            opened = true;
        }
        internal void Open64(Guid destination, uint loginMethod, byte[] connectionData, Parameter[] paramlist)
        {
            Interop.TEEC_UUID uuid = Interop.TEEC_UUID.ToTeecUuid(destination);

            int ret;
            uint ro;
            if (paramlist != null) {
                Interop.TEEC_Operation64 op = Create_TEEC_Operation64();
                for (int i=0; i < 4 && i < paramlist.Length; ++i) {
                    op.paramTypes |= InitParam(ref op.paramlist, i, paramlist[i]) << (8*i);
                }
                Marshal.StructureToPtr(op, opptr, false);
                ret = Interop.Libteec.OpenSession(context.context_imp, session_imp, ref uuid, loginMethod, connectionData, opptr, out ro);
                op = Marshal.PtrToStructure<Interop.TEEC_Operation64>(opptr);
                for (int i=0; i < 4 && i < paramlist.Length; ++i) {
                    UpdateParam(op.paramlist[i], ref paramlist, i);
                }
            }
            else {
                ret = Interop.Libteec.OpenSession(context.context_imp, session_imp, ref uuid, loginMethod, connectionData, IntPtr.Zero, out ro);
            }

            for (int i=0; i < 4; ++i) {
                if (shm[i] != null) {
                    shm[i].Dispose();
                    shm[i] = null;
                }
            }

            //MAYBE map origin of return code to specyfic Exception
            Interop.CheckNThrowException(ret, string.Format("OpenSession('{0}')", destination));
            opened = true;
        }

        /// <summary>
        /// This function closes a session which has been opened with a trusted application.
        /// All commands within the session must be completed before this function can be called.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public void Close() {
            Dispose();
        }

        /// <summary>
        /// This function invokes a command within the specified session.
        /// The parameter commandID is an identifier that is used to indicate which of the exposed trusted
        /// application functions should be invoked. The supported command identifier values are defined by the
        /// trusted application's protocol.
        /// There can be up to four parameter objects given in the <paramref name="paramlist"/> array.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="commandID">The command.</param>
        /// <param name="paramlist">The array of parameters.</param>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">The argument <paramref name="paramlist"/> is wrong.</exception>
        public void InvokeCommand(uint commandID, Parameter[] paramlist)
        {
            int ret;
            uint ro;
            if (paramlist != null) {
                if (IntPtr.Size == 4) {
                    Interop.TEEC_Operation32 op = Create_TEEC_Operation32();
                    for (int i=0; i < 4 && i < paramlist.Length; ++i) {
                        op.paramTypes |= InitParam(ref op.paramlist, i, paramlist[i]) << (8*i);
                    }
                    Marshal.StructureToPtr(op, opptr, false);
                    ret = Interop.Libteec.InvokeCommand(session_imp, commandID, opptr, out ro);
                    op = Marshal.PtrToStructure<Interop.TEEC_Operation32>(opptr);
                    for (int i=0; i < 4 && i < paramlist.Length; ++i) {
                        UpdateParam(op.paramlist[i], ref paramlist, i);
                    }
                }
                else {
                    Interop.TEEC_Operation64 op = Create_TEEC_Operation64();
                    for (int i=0; i < 4 && i < paramlist.Length; ++i) {
                        op.paramTypes |= InitParam(ref op.paramlist, i, paramlist[i]) << (8*i);
                    }
                    Marshal.StructureToPtr(op, opptr, false);
                    ret = Interop.Libteec.InvokeCommand(session_imp, commandID, opptr, out ro);
                    op = Marshal.PtrToStructure<Interop.TEEC_Operation64>(opptr);
                    for (int i=0; i < 4 && i < paramlist.Length; ++i) {
                        UpdateParam(op.paramlist[i], ref paramlist, i);
                    }
                }
            }
            else {
                ret = Interop.Libteec.InvokeCommand(session_imp, commandID, IntPtr.Zero, out ro);
            }

            for (int i=0; i < 4; ++i) {
                if (shm[i] != null) {
                    shm[i].Dispose();
                    shm[i] = null;
                }
            }

            //MAYBE map origin of return code to specific Exception
            Interop.CheckNThrowException(ret, string.Format("InvokeCommand({0})", commandID));
        }

        /// <summary>
        /// The asynchronous version of the InvokeCommand.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="commandID">The command.</param>
        /// <param name="paramlist">The array of parameters.</param>
        /// <param name="token">The token for task manipulation.</param>
        /// <returns>Returns a task executing an invoke command in the background.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">One of the arguments is wrong.</exception>
        public async Task InvokeCommandAsync(uint commandID, Parameter[] paramlist, CancellationToken token = default(CancellationToken))
        {
            await Task.Factory.StartNew(() => InvokeCommand(commandID, paramlist));
        }

    };

    static internal class TeeFeature
    {
        private static string name = "http://tizen.org/feature/security.tee";
        public static bool IsEnabled() {
            /* FIXME - System.Information does not provide a Try-less variant of GetValue */
            if (!Tizen.System.Information.TryGetValue(name, out bool enabled)) {
                unchecked {
                    Interop.CheckNThrowException((int)Interop.LibteecError.Generic, "Failed to query for TEE feature");
                }
            }
            return enabled;
        }
    }

    /// <summary>
    /// This type denotes a TEE Context, the main logical container linking a Client Application with a particular TEE.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class Context : IDisposable
    {
        private bool disposed = false;
        private bool initialized = false;
        internal IntPtr context_imp;
        internal uint shmcnt = 0;

        /// <summary>
        /// This function (constructor) initializes a new TEE Context, forming a connection between this client application and the
        /// TEE identified by the string identifier name (empty or null name denotes a default TEE).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="name">The TEE name.</param>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public Context(string name)
        {
            if (!TeeFeature.IsEnabled())
                unchecked {
                    Interop.CheckNThrowException((int)Interop.LibteecError.NotSupported, string.Format("InitializeContext('{0}')", name));
                }

            context_imp = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.TEEC_Context>());
            if (name != null && name.Length == 0)
                name = null;
            try {
                int ret = Interop.Libteec.InitializeContext(name, context_imp);
                Interop.CheckNThrowException(ret, string.Format("InitializeContext('{0}')", name));
                initialized = true;
            }
            catch (global::System.DllNotFoundException e)
            {
                unchecked {
                    Interop.CheckNThrowException((int)Interop.LibteecError.NotImplemented, "Not found: " + e.Message);
                }
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposed) {
                return ;
            }
            if (initialized) {
                Interop.Libteec.FinalizeContext(context_imp);
                initialized = false;
            }
            Marshal.FreeHGlobal(context_imp);
            context_imp = IntPtr.Zero;
            disposed = true;
        }

        /// <summary>
        /// Destructor of the class.
        /// </summary>
        ~Context()
        {
            Dispose(false);
        }

        /// <summary>
        /// This function implements the IDisposable interface.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        public void Dispose() {
            if (shmcnt != 0) {
                Tizen.Log.Error("TZ_CLIENTAPI", "Context.Dispose not all shm released yet!");
                return ;
            }
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// This function opens a new session between the client application and the specified trusted application.
        /// The target trusted application is identified by an UUID passed in the parameter destination.
        /// There can be up to four parameter objects given in the <paramref name="paramlist"/> array.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="destination">The UUID of the destination TA.</param>
        /// <param name="loginMethod">The authentication algorithm <see cref="LoginMethod" />.</param>
        /// <param name="connectionData">The data to be verified by a given login method.</param>
        /// <param name="paramlist">The parameters to be passed to TA open-session-callback.</param>
        /// <returns>Returns opened session.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">One of the arguments is wrong.</exception>
        public Session OpenSession(Guid destination, uint loginMethod, byte[] connectionData, Parameter[] paramlist)
        {
            Session ses = new Session(this);
            if (IntPtr.Size == 4)
                ses.Open32(destination, loginMethod, connectionData, paramlist);
            else if (IntPtr.Size == 8)
                ses.Open64(destination, loginMethod, connectionData, paramlist);
            else throw new NotSupportedException("unsupported arch");
            return ses;
        }
        /// <summary>
        /// @see OpenSession (Guid destination, uint connectionMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="destination">The UUID of the destination TA.</param>
        /// <returns>Returns opened session.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public Session OpenSession(Guid destination)
        {
            Session ses = new Session(this);
            if (IntPtr.Size == 4)
                ses.Open32(destination, LoginMethod.Public, null, null);
            else if (IntPtr.Size == 8)
                ses.Open64(destination, LoginMethod.Public, null, null);
            else throw new NotSupportedException("unsupported arch");
            return ses;
        }

        /// <summary>
        /// The asynchronous version of the OpenSession.
        /// @see OpenSession (Guid destination, uint connectionMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="destination">The UUID of the destination TA.</param>
        /// <param name="loginMethod">The authentication algorithm <see cref="LoginMethod" />.</param>
        /// <param name="connectionData">The data to be verified by a given login method.</param>
        /// <param name="paramlist">The parameters to be passed to the TA open-session-callback.</param>
        /// <param name="token">The token for the task manipulation.</param>
        /// <returns>Returns a Task executing the session open in the background.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">One of the arguments is wrong.</exception>
        public async Task<Session> OpenSessionAsync(Guid destination, uint loginMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token = default(CancellationToken))
        {
            Task<Session> task = Task<Session>.Factory.StartNew(() =>
            {
                return OpenSession(destination, loginMethod, connectionData, paramlist);
            });
            return await task;
        }
        /// <summary>
        /// The asynchronous version of the OpenSession.
        /// @see OpenSession (Guid destination, uint connectionMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="destination">The UUID of the destination TA.</param>
        /// <param name="token">The token for a task manipulation.</param>
        /// <returns>Returns a task executing session open in the background.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public async Task<Session> OpenSessionAsync(Guid destination, CancellationToken token = default(CancellationToken))
        {
            Task<Session> task = Task<Session>.Factory.StartNew(() =>
            {
                return OpenSession(destination);
            });
            return await task;
        }

        /// <summary>
        /// This function registers a block of the existing client application memory as a block of shared memory within
        /// the scope of the specified context, in accordance with the parameters.
        /// The input <paramref name="memaddr"/> must point to the shared memory region to register.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="memaddr">The address of the shared memory.</param>
        /// <param name="size">The size of the shared memory.</param>
        /// <param name="flags">The flags describing the access modes (Input and/or Output).</param>
        /// <returns>Returns the SharedMemory handler.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">The argument <paramref name="memaddr"/> is wrong.</exception>
        public SharedMemory RegisterSharedMemory(IntPtr memaddr, UInt32 size, SharedMemoryFlags flags)
        {
            SharedMemory sharedmem =  new SharedMemory(this);
            Interop.TEEC_SharedMemory shm = new Interop.TEEC_SharedMemory();
            shm.buffer = memaddr;
            shm.size = (UIntPtr)size;
            shm.flags = (UInt32)flags;
            int ret = Interop.Libteec.RegisterSharedMemory(context_imp, ref shm);
            Interop.CheckNThrowException(ret, "RegisterSharedMemory");
            sharedmem.setShm(ref shm);
            return sharedmem;
        }

        /// <summary>
        /// This function allocates a new block of memory as a block of shared memory within the scope of the
        /// specified context, in accordance with the parameters.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="size">The size of shared memory.</param>
        /// <param name="flags">The flags describing access modes (Input and/or Output).</param>
        /// <returns>Returns the Shared Memory handler.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public SharedMemory AllocateSharedMemory(UInt32 size, SharedMemoryFlags flags)
        {
            SharedMemory sharedmem =  new SharedMemory(this);
            Interop.TEEC_SharedMemory shm = new Interop.TEEC_SharedMemory();
            shm.size = (UIntPtr)size;
            shm.flags = (UInt32)flags;
            int ret = Interop.Libteec.AllocateSharedMemory(context_imp, ref shm);
            Interop.CheckNThrowException(ret, "AllocateSharedMemory");
            sharedmem.setShm(ref shm);
            return sharedmem;
        }

        /// <summary>
        /// This function deregisters or deallocates a previously initialized block of the shared memory.
        /// </summary>
        /// <remarks>
        /// For a memory buffer allocated using AllocateSharedMemory, the implementation must free the
        /// underlying memory and the client application must not access this region after this function has been
        /// called. In this case, the implementation must clear the buffer and size fields of the shared memory
        /// structure before returning.
        /// For memory registered using RegisterSharedMemory, the implementation must deregister the
        /// underlying memory from the TEE, but the memory region will stay available to the client application for
        /// other purposes as the memory is owned by it.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="shm">The shared memory object returned by RegisterSharedMemory or AllocateSharedMemory.</param>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">The argument is wrong.</exception>
        public void ReleaseSharedMemory(SharedMemory shm)
        {
            shm.Dispose();
        }
    };

}
