/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Binding
{
    internal abstract class Condition
    {
        Action<BindableObject, bool, bool> _conditionChanged;

        bool _isSealed;

        internal Condition()
        {
        }

        internal Action<BindableObject, bool, bool> ConditionChanged
        {
            get { return _conditionChanged; }
            set
            {
                if (_conditionChanged == value)
                    return;
                if (_conditionChanged != null)
                    throw new InvalidOperationException("The same condition instance can not be reused");
                _conditionChanged = value;
            }
        }

        internal bool IsSealed
        {
            get { return _isSealed; }
            set
            {
                if (_isSealed == value)
                    return;
                if (!value)
                    throw new InvalidOperationException("What is sealed can not be unsealed.");
                _isSealed = value;
                OnSealed();
            }
        }

        internal abstract bool GetState(BindableObject bindable);

        internal virtual void OnSealed()
        {
        }

        internal abstract void SetUp(BindableObject bindable);
        internal abstract void TearDown(BindableObject bindable);
    }
}
 
