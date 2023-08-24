/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    internal class OnIdiom<T>
    {
        public T Phone { get; set; }

        public T Tablet { get; set; }

        public T Desktop { get; set; }

        public T TV { get; set; }

        public T Watch { get; set; }

        public static implicit operator T(OnIdiom<T> onIdiom)
        {
            switch (Device.Idiom)
            {
                default:
                case TargetIdiom.Phone:
                    return onIdiom.Phone;
                case TargetIdiom.Tablet:
                    return onIdiom.Tablet;
                case TargetIdiom.Desktop:
                    return onIdiom.Desktop;
                case TargetIdiom.TV:
                    return onIdiom.TV;
                case TargetIdiom.Watch:
                    return onIdiom.Watch;
            }
        }
    }
}
