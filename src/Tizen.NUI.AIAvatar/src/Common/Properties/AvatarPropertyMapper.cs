/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// The AvatarPropertyMapper class manages property mapping information for specific attributes of an Avatar model.
    /// It primarily maps the names of AvatarProperty to their actual storage locations.
    /// By doing so, developers can directly read or write the values of these properties using their respective names.
    /// This approach provides consistency and convenience when working with Avatar models.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class AvatarPropertyMapper
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
        /// Get current mapper information.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dictionary<uint, string> Mapper
        {
            get
            {
                return mapper;
            }
        }

        /// <summary>
        /// Indexer method. Allows accessing and setting the property names using array notation.
        /// </summary>
        /// <param name="index">The index of property what we want to set</param>
        /// <returns>The index of property, or uint.MaxValue if not exist</returns>
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
        /// Create an initialized AvatarPropertyNameMapper.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarPropertyMapper()
        {
            mapper = new Dictionary<uint, string>();
            customIndexCounter = 0u;
        }

        /// <summary>
        /// Copy constructor.
        /// Creates a new instance of the AvatarPropertyMapper class by copying the contents of another existing AvatarPropertyMapper instance.
        /// </summary>
        /// <param name="source">The source AvatarPropertyMapper instance to be copied.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarPropertyMapper(AvatarPropertyMapper source)
        {
            if (source != null)
            {
                mapper = new Dictionary<uint, string>(source.Mapper);
                customIndexCounter = source.customIndexCounter;
            }
            else
            {
                mapper = new Dictionary<uint, string>();
                customIndexCounter = 0u;
            }
        }

        /// <summary>
        /// Registers a custom property by name and returns its index.
        /// </summary>
        /// <param name="name">The name of custom property</param>
        /// <returns>The index of property matched with name.</returns>
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
        /// Returns the index of a property by its name.
        /// </summary>
        /// <param name="name">The name of property what we want to get index</param>
        /// <returns>The index of property, or uint.MaxValue if not exist</returns>
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
        /// Sets the property name at the given index.
        /// </summary>
        /// <param name="index">The index of property what we want to set</param>
        /// <param name="name">The name of property what we want to set</param>
        /// <remark>
        /// New property will be added if we use index that not exist in mapper.
        /// </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPropertyName(uint index, string name)
        {
            mapper.TryAdd(index, name);
        }

        /// <summary>
        /// Gets the property name at the given index.
        /// </summary>
        /// <param name="index">The index of property what we want to set</param>
        /// <returns>The name of property, or null if not exist</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetPropertyName(uint index)
        {
            string ret = null;
            mapper.TryGetValue(index, out ret);
            return ret;
        }

        /// <summary>
        /// Clear AvatarPropertyNameMapper.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            mapper.Clear();
            customIndexCounter = 0u;
        }
    }
}
