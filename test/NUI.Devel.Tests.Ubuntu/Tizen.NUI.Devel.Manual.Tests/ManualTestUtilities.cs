/*
 *  Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Reflection;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;
using NUnitLite.TUnit;
using NUnit.Framework.TUnit;
using NUnit.Framework.Interfaces;

namespace Tizen.NUI.Devel.Manual.Tests
{
    using tlog = Tizen.Log;

    public enum TestState
    {
        Untested,
        Passed,
        Failed,
        Blocked,
    }


    public class ManualTestItem : INotifyPropertyChanged
    {
        private int testIndex;
        private string testCaseName;
        private List<string> preConditions;
        private List<string> steps;
        private List<string> postConditions;
        private TestState testState = TestState.Untested;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        public ManualTestItem(int index, string name)
        {
            testIndex = index;
            testCaseName = name;
        }

        public int TestIndex
        {
            get => testIndex;
            set { testIndex = value; OnPropertyChanged("TestIndex"); }
        }

        public string TestCaseName
        {
            get => testCaseName.Substring(29); // Remove Tizen.NUI.Devel.Manual.Tests.
        }

        public string TestCaseFullName
        {
            get => testCaseName;
            set
            {
                testCaseName = value;
                OnPropertyChanged("TestCaseName");
                OnPropertyChanged("TestCaseFullName");
            }
        }

        public List<string> PreConditions
        {
            get => preConditions;
            set { preConditions = value; OnPropertyChanged("PreConditions"); }
        }
        public List<string> Steps
        {
            get => steps;
            set { steps = value; OnPropertyChanged("Steps"); }
        }

        public List<string> PostConditions
        {
            get => postConditions;
            set { postConditions = value; OnPropertyChanged("PostConditions"); }
        }

        public TestState TestState
        {
            get => testState;
            set
            {
                testState = value;
                OnPropertyChanged("TestState");
                OnPropertyChanged("TestStateName");
                OnPropertyChanged("TestStateColor");
            }
        }

        public string TestStateName
        {
            get => testState.ToString();
        }
        public Color TestStateColor
        {
            get
            {
                switch (testState)
                {
                    case TestState.Passed :
                        return new Color(ManualTest.COLOR_PASSED);
                    case TestState.Failed :
                        return new Color(ManualTest.COLOR_FAILED);
                    case TestState.Blocked :
                        return new Color(ManualTest.COLOR_BLOCKED);
                    case TestState.Untested :
                    default :
                        return new Color(ManualTest.COLOR_UNTESTED);
                }
            }
        }
    }

    public class ManualTestList : ObservableCollection<ManualTestItem>, INotifyPropertyChanged
    {
        int passedCount = 0;
        int failedCount = 0;
        int blockedCount = 0;

        private static ManualTestList instance = null;
        private static Object lockObject = new object();

        public ManualTestList()
        {
            CollectionChanged += FullObservableCollectionCollectionChanged;
        }

        public static ManualTestList GetInstance()
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new ManualTestList();
                }
            }
            return instance;
        }

        public int PassedCount
        {
            get => passedCount;
        }

        public int FailedCount
        {
            get => failedCount;
        }
        public int BlockedCount
        {
            get => blockedCount;
        }

        public string Title
        {
            get => "NUI Manual Test " + $"Total:{Count} Passed: {PassedCount} Failed: {FailedCount} Blocked: {BlockedCount}";
        }


        private void FullObservableCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Object item in e.NewItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged += ItemPropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (Object item in e.OldItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged -= ItemPropertyChanged;
                }
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "TestState")
            {
                // we can update individual count but for the safefy verify all passed items.
                int passed = 0;
                int failed = 0;
                int blocked = 0;
                foreach(ManualTestItem item in this)
                {
                    switch (item.TestState)
                    {
                        case TestState.Passed :
                            passed++;
                            break;
                        case TestState.Failed :
                            failed++;
                            break;
                        case TestState.Blocked :
                            blocked++;
                            break;
                        case TestState.Untested :
                        default :
                            break;
                    }
                }

                passedCount = passed;
                failedCount = failed;
                blockedCount = blocked;

                OnPropertyChanged(new PropertyChangedEventArgs("PassedCount"));
                OnPropertyChanged(new PropertyChangedEventArgs("FailedCount"));
                OnPropertyChanged(new PropertyChangedEventArgs("BlockedCount"));
                OnPropertyChanged(new PropertyChangedEventArgs("Title"));
            }
        }
    }

    public class ManualTest
    {
        ManualTestItem currentTest;
        ManualTestPage currentPage;
        private static ManualTest instance = null;
        private static Object lockObject = new object();
        public static ManualTestList TestList = ManualTestList.GetInstance();
        public static readonly string COLOR_PASSED = "#0B5345";
        public static readonly string COLOR_FAILED = "#922B21";
        public static readonly string COLOR_BLOCKED = "#76448A";
        public static readonly string COLOR_UNTESTED = "#909497";

        public static ManualTest GetInstance()
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new ManualTest();
                }
            }
            return instance;
        }

        private static bool testConfirmed = true;

        public static bool IsConfirmed()
        {
            return testConfirmed;
        }

        public static void Confirm()
        {
            testConfirmed = true;
        }

        public ManualTestItem CurrentTest
        {
            get => currentTest;
            set => currentTest = value;
        }

        public ManualTestPage CurrentPage
        {
            get => currentPage;
            set => currentPage = value;
        }

        public static async Task WaitForConfirm()
        {
            testConfirmed = false;
            while (true)
            {
                await Task.Delay(200);
                if (testConfirmed)
                    break;
            }
        }

    }
}

