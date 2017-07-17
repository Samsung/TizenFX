/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ElmSharp.Test
{
    [Flags]
    public enum TargetProfile
    {
        Mobile = 1,
        Tv = 2,
        Wearable = 4
    }
    public abstract class TestCaseBase
    {
        public abstract string TestName { get; }
        public abstract string TestDescription { get; }
        public virtual TargetProfile TargetProfile => TargetProfile.Mobile | TargetProfile.Tv;
        public abstract void Run(Window window);
    }

    public abstract class WearableTestCase : TestCaseBase
    {
        public override TargetProfile TargetProfile => TargetProfile.Wearable;
    }
}
