/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.NUI
{
    internal class IntPtrPool
    {
        private Queue<IntPtr> ptrQueue = new Queue<IntPtr>();
        private CreatePtrCallback createPtrCb;
        private DeletePtrCallback deletePtrCb;

        private static List<IntPtrPool> pools = new List<IntPtrPool>();

        public delegate IntPtr CreatePtrCallback();
        public delegate void DeletePtrCallback(IntPtr ptr);

        public static void ClearPools()
        {
            foreach (var pool in pools)
            {
                pool.ClearPtrs();
            }
        }

        public IntPtrPool(CreatePtrCallback createPtrCb, DeletePtrCallback deletePtrCb)
        {
            this.createPtrCb = createPtrCb;
            this.deletePtrCb = deletePtrCb;
            pools.Add(this);
        }

        public IntPtr GetPtr()
        {
            IntPtr ret = IntPtr.Zero;

            if (0 == ptrQueue.Count)
            {
                if (null == createPtrCb)
                {
                    throw new Exception("createPtrCb can't be null");
                }

                ret = createPtrCb();
            }
            else
            {
                ret = ptrQueue.Dequeue();
            }

            return ret;
        }

        public void PutPtr(IntPtr ptr)
        {
            ptrQueue.Enqueue(ptr);
        }

        public void ClearPtrs()
        {
            while (ptrQueue.Count > 0)
            {
                var ptr = ptrQueue.Dequeue();
                deletePtrCb?.Invoke(ptr);
            }
        }
    }
}
