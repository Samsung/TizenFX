/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// TODO : Explain more detail
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AvatarPropertyMapper
    {
        /// <summary>
        /// Mapper between index and property name
        /// </summary>
        private Dictionary<uint, string> mapper = null;

        /// <summary>
        /// The counter of index. It will be increased one when we register custom index.
        /// </summary>
        private uint customIndexCounter = 0;

        /// <summary>
        /// Create an initialized AvatarPropertyNameMapper.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarPropertyMapper()
        {
            mapper = new Dictionary<uint, string>();
            customIndexCounter = 0u;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarPropertyMapper(AvatarPropertyMapper rhs)
        {
            if (rhs != null)
            {
                mapper = new Dictionary<uint, string>(rhs.Mapper);
                customIndexCounter = rhs.customIndexCounter;
            }
            else
            {
                mapper = new Dictionary<uint, string>();
                customIndexCounter = 0u;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected uint CustomIndexCounter
        {
            get
            {
                return customIndexCounter;
            }
            set
            {
                customIndexCounter = value;
            }
        }

        /// <summary>
        /// Get current mapper information.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dictionary<uint, string> Mapper
        {
            get
            {
                return mapper;
            }
        }

        /// <summary>
        /// TODO : Explain me.
        /// </summary>
        /// <param name="index">The index of property what we want to set</param>
        /// <returns>The index of property, or uint.MaxValue if not exist</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string this[uint index]
        {
            set
            {
                SetPropertyName(index, value);
            }
            get
            {
                return GetPropertyName(index);
            }
        }

        /// <summary>
        /// TODO : Explain me.
        /// </summary>
        /// <param name="name">The name of custom property</param>
        /// <returns>The index of property matched with name.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint RegisterCustomProperty(string name)
        {
            uint ret = GetPropertyIndexByName(name);
            if (ret >= customIndexCounter)
            {
                ret = customIndexCounter++;
                SetPropertyName(ret, name);
            }
            return ret;
        }

        /// <summary>
        /// TODO : Explain me.
        /// </summary>
        /// <param name="name">The name of property what we want to get index</param>
        /// <returns>The index of property, or uint.MaxValue if not exist</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetPropertyIndexByName(string name)
        {
            // TODO : Do this without iteration
            foreach (var pair in mapper)
            {
                if (pair.Value == name)
                {
                    return pair.Key;
                }
            }
            return uint.MaxValue;
        }

        /// <summary>
        /// TODO : Explain me.
        /// </summary>
        /// <param name="index">The index of property what we want to set</param>
        /// <param name="name">The name of property what we want to set</param>
        /// <remark>
        /// New property will be added if we use index that not exist in mapper.
        /// </remark>
        internal void SetPropertyName(uint index, string name)
        {
            mapper.TryAdd(index, name);
        }

        /// <summary>
        /// TODO : Explain me.
        /// </summary>
        /// <param name="index">The index of property what we want to set</param>
        /// <returns>The name of property, or null if not exist</returns>
        internal string GetPropertyName(uint index)
        {
            string ret = null;
            mapper.TryGetValue(index, out ret);
            return ret;
        }
    }
}
