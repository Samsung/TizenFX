/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using System.Collections.Generic;
using NUnitLite.TUnit;
using NUnit.Framework.Interfaces;
using NUnit.Framework.TUnit;
using System.Reflection;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Tests
{
    class WearableManualTestNUI
    {
        class ListBridge : FlexibleViewAdapter
        {
            private List<string> _mDatas;
            private List<ItemData> _mlistItem;

            public ListBridge(List<string> datas, List<ItemData> item)
            {
                _mDatas = datas;
                _mlistItem = item;
            }

            public void UpdateItemData(int position, List<ItemData> item)
            {
                _mlistItem = item;
            }

            public override FlexibleViewViewHolder OnCreateViewHolder(int viewType)
            {
                FlexibleViewViewHolder viewHolder = new FlexibleViewViewHolder(new Button(new ButtonStyle()));
                return viewHolder;
            }

            public override void OnBindViewHolder(FlexibleViewViewHolder holder, int position)
            {
                string testcaseName = "#." + (position + 1).ToString() + _mDatas[position];
                string resultText = "[" + _mlistItem[(int)position].Result + "]";
                string text = testcaseName + resultText;

                Button btn = holder.ItemView as Button;
                if (btn)
                {
                    btn.Size = new Size(Window.Instance.Size.Width, 120);
                    btn.Name = position.ToString();
                    btn.Text = text;
                    btn.PointSize = 4.0f;
                    btn.TextAlignment = HorizontalAlignment.Begin;
                    btn.TextColor = Color.White;
                    btn.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/controller_btn_check_on.png";
                    btn.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
                }
            }

            public override void OnDestroyViewHolder(FlexibleViewViewHolder holder)
            {
                if (holder.ItemView != null)
                {
                    holder.ItemView.Dispose();
                }
            }

            public override int GetItemCount()
            {
                return _mDatas.Count;
            }
        }

        class DetailListBridge : FlexibleViewAdapter
        {
            private List<string> _mDatas;

            public DetailListBridge(List<string> datas)
            {
                _mDatas = datas;
            }

            public override FlexibleViewViewHolder OnCreateViewHolder(int viewType)
            {
                FlexibleViewViewHolder viewHolder = new FlexibleViewViewHolder(new TextLabel());
                return viewHolder;
            }

            public override void OnBindViewHolder(FlexibleViewViewHolder holder, int position)
            {
                TextLabel label =  holder.ItemView as TextLabel;
                if (label)
                {
                    label.TextColor = Color.White;
                    label.ParentOrigin = ParentOrigin.TopLeft;
                    label.PivotPoint = PivotPoint.TopLeft;
                    label.Position = new Position(0.0f, 0.0f, 0.0f);
                    label.Size = new Size(Window.Instance.Size.Width - 100, _detailScrollHeight);
                    label.HorizontalAlignment = HorizontalAlignment.Begin;
                    label.VerticalAlignment = VerticalAlignment.Center;
                    label.PointSize = 3.0f;
                    label.MultiLine = true;
                    label.Text = _mDatas[position];
                }
            }

            public override void OnDestroyViewHolder(FlexibleViewViewHolder holder)
            {
                if (holder.ItemView != null)
                {
                    holder.ItemView.Dispose();
                }
            }

            public override int GetItemCount()
            {
                return _mDatas.Count;
            }
        }

        private List<string> _tcIDList;
        private List<ItemData> _listItem;
        private TSettings _tsettings;
        private TRunner _tRunner;
        private Button _passButton, _failButton, _blockButton, _homeButton, _preButton, _nextButton, _doneButton;
        private TextLabel _notRun;
        private const string STEP_ATTRIBUTE_NAME = "NUnit.Framework.StepAttribute";
        private const string PRECONDITION_ATTRIBUTE_NAME = "NUnit.Framework.PreconditionAttribute";
        private const string POSTCONDITION_ATTRIBUTE_NAME = "NUnit.Framework.PostconditionAttribute";
        private List<string> _listNotPass;

        //Save the information of every single test case
        private List<TestcaseInfo> _tcInfoList;
        private List<string> _currentTCInfo;

        private static WearableManualTestNUI _instance;
        private static Object _lockObject = new object();

        //Show the result of all the test case
        private TextLabel _summaryLabel1, _summaryLabel2, _description;
        private View _initView;
        private View _detailView;
        private FlexibleView _initList;
        private ListBridge _adapter;
        private FlexibleView _detailList;
        private DetailListBridge _adapter_detail;
        private View _caseView;
        private Button _run;
        private Button _runButton;

        //Always save the current TC number;
        private int _currentTCNum = 0;
        private static int _detailScrollHeight = 60;

        public static WearableManualTestNUI GetInstance()
        {
            lock (_lockObject)
            {
                if (_instance == null)
                {
                    _instance = new WearableManualTestNUI();
                }
            }
            return _instance;
        }

        private WearableManualTestNUI()
        {
            Initialize();
        }
        public void Initialize()
        {
            Window.Instance.BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1.0f);
            Tizen.Log.Fatal("NUI", "Initialize=========================================");
            RunType.Value = RunType.MANUAL;
            _tRunner = new TRunner();
            _tRunner.LoadTestsuite();
            _tRunner.SingleTestDone += OnSingleTestDone;
            _listNotPass = new List<string>();
            _tcIDList = new List<string>();
            _listItem = new List<ItemData>();
            _listNotPass = TSettings.GetInstance().GetNotPassListManual();
            int count = 0;
            foreach (var tc in _listNotPass)
            {
                _listItem.Add(new ItemData { No = count, TCName = tc, Result = StrResult.NOTRUN });
                _tcIDList.Add(tc);
                count++;
            }
            Tizen.Log.Fatal("NUI", "TCT : count:" + count.ToString());
            foreach (String nameTc in _tcIDList)
            {
                Tizen.Log.Fatal("NUI", "TCT : TCName:" + nameTc.ToString());
            }


            _tsettings = TSettings.GetInstance();
            _tsettings.IsManual = true;

            InitData();
            _caseView = new View();
            Window.Instance.GetDefaultLayer().Add(_caseView);
            Window window = Window.Instance;

            _summaryLabel1 = new TextLabel();
            _summaryLabel1.TextColor = Color.White;
            _summaryLabel1.PointSize = 5.0f;
            _summaryLabel1.Size2D = new Size2D(200, 30);
            _summaryLabel1.ParentOrigin = ParentOrigin.TopLeft;
            _summaryLabel1.PivotPoint = PivotPoint.TopLeft;
            _summaryLabel1.Position = new Position(70, 12, 0);
            _summaryLabel1.HorizontalAlignment = HorizontalAlignment.Center;
            _summaryLabel1.VerticalAlignment = VerticalAlignment.Center;

            _summaryLabel2 = new TextLabel();
            _summaryLabel2.TextColor = Color.White;
            _summaryLabel2.PointSize = 5.0f;
            _summaryLabel2.Size2D = new Size2D(300, 30);
            _summaryLabel2.ParentOrigin = ParentOrigin.TopLeft;
            _summaryLabel2.PivotPoint = PivotPoint.TopLeft;
            _summaryLabel2.Position = new Position(20, 33, 0);
            _summaryLabel2.HorizontalAlignment = HorizontalAlignment.Center;
            _summaryLabel2.VerticalAlignment = VerticalAlignment.Center;

            SetSummaryResult();
            Window.Instance.GetDefaultLayer().Add(_summaryLabel1);
            Window.Instance.GetDefaultLayer().Add(_summaryLabel2);

            _initView = new View();

            _initView.Size2D = new Size2D((int)Window.Instance.Size.Width, 200);
            _initView.ParentOrigin = ParentOrigin.TopLeft;
            _initView.PivotPoint = PivotPoint.TopLeft;
            _initView.Position = new Position(0.0f, 60.0f, 0.0f);
            InitializeFirstPage();
            _initView.Show();

            _detailView = new View();
            _detailView.Size2D = new Size2D((int)Window.Instance.Size.Width, (int)Window.Instance.Size.Height - 65);
            _detailView.ParentOrigin = ParentOrigin.TopLeft;
            _detailView.PivotPoint = PivotPoint.TopLeft;
            _detailView.Position = new Position(0.0f, 70.0f, 0.0f);
            InitializeDetailPage();
            _detailView.Hide();

            window.GetDefaultLayer().Add(_initView);
            window.GetDefaultLayer().Add(_detailView);
        }

        void SetCommonButtonStyle(Button btn, string text)
        {
            if (!btn) return;
            btn.Text = text;
            btn.PointSize = 4.0f;
            btn.TextColor = new Color(0, 0, 0, 1);
            btn.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/controller_btn_check_on.png";
            btn.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            btn.TextColor = Color.White;
        }

        void InitializeFirstPage()
        {
            //Create Run Button, when you Click it, then the first test case will be executed.
            _doneButton = new Button(new ButtonStyle());
            _doneButton.Position = new Position(0, 0);
            _doneButton.Size = new Size(120, 60);
            SetCommonButtonStyle(_doneButton, "Done");
            _doneButton.Clicked += (obj, ee) =>
            {
                TSettings.GetInstance().SubmitManualResult();
            };

            _run = new Button(new ButtonStyle());
            _run.Position2D = new Position2D(150, 0);
            _run.Size = new Size(120, 60);
            SetCommonButtonStyle(_run, "Runner");
            _run.Clicked += (obj, ee) =>
            {
                Tizen.Log.Fatal("NUI", "Check all the test case from the first one.");
                _currentTCNum = 0;
                _initView.Hide();
                _caseView.Hide();
                UpdateDetailPage();
                _detailView.Show();
            };

            CreateInitList();

            _initView.Add(_doneButton);
            _initView.Add(_run);
            _initView.Add(_initList);
            Tizen.Log.Fatal("NUI", "TCT : InitializeFirstPage:");
        }

        //Update the Test Page before you want to show it(Click Run/Pre/nect Button, or Click on item in the List).
        void UpdateDetailPage()
        {
            UpdateCurrentTCInfo();
            Tizen.Log.Fatal("NUI", "UpdateDetailPage::::::::::::::::::::::");
            CreateTestCase();
        }

        void InitializeDetailPage()
        {
            _description = new TextLabel();
            _description.TextColor = Color.White;
            _description.PointSize = 3.0f;
            _description.ParentOrigin = ParentOrigin.TopLeft;
            _description.PivotPoint = PivotPoint.TopLeft;
            _description.Size2D = new Size2D(200, 20);
            _description.Position2D = new Position2D(50, 0);
            _detailView.Add(_description);

            CreateDetailList();
            //To Place the function button, such as PASS, FAIL.....
            CreateButtons();
        }

        //To show the detail information of the test case
        //Preconditions
        //Steps
        //PostConditions
        void CreateTestCase()
        {
            if(_detailList)
            {
                _detailView.Remove(_detailList);
                _detailList.Dispose();
            }
            Tizen.Log.Fatal("NUI", "Print the CurrentTCNum here::" + _currentTCNum);
            CreateDetailList();
            if (_notRun)
            {
                _notRun.Text = _listItem[_currentTCNum].Result;
            }
        }
        private TextLabel CreateTextLabel(string textStr, int left)
        {
            TextLabel text = new TextLabel();
            text.TextColor = Color.White;
            text.ParentOrigin = ParentOrigin.TopLeft;
            text.PivotPoint = PivotPoint.TopLeft;
            text.Text = textStr;
            text.PointSize = 5.0f;
            text.VerticalAlignment = VerticalAlignment.Bottom;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.Size2D = new Size2D(30, 30);
            text.Position2D = new Position2D(left, 0);
            return text;
        }
        //Create all the function buttons here, such as PASS, FAIL.....
        void CreateButtons()
        {
            _notRun = new TextLabel();
            _notRun.TextColor = Color.White;
            _notRun.Size = new Size(40, 30);
            _notRun.PointSize = 2.5f;
            _notRun.Position = new Position(100, 32);
            _notRun.HorizontalAlignment = HorizontalAlignment.Center;
            _notRun.VerticalAlignment = VerticalAlignment.Center;
            _notRun.MultiLine = true;
            _notRun.Text = "Not Run";
            _passButton = new Button(new ButtonStyle());
            SetCommonButtonStyle(_passButton, "P");
            _passButton.Size = new Size(70, 30);
            _passButton.Position = new Position(0, 0);
            _passButton.Clicked += (obj, ee) =>
            {
                Clear();
                if (!ManualTest.IsConfirmed())
                {
                    _tsettings.TCResult = StrResult.PASS;
                    ManualTest.Confirm();
                }
                Tizen.Log.Fatal("TBT", "Pass Button clicked!");
            };

            _failButton = new Button(new ButtonStyle());
            SetCommonButtonStyle(_failButton, "F");
            _failButton.Size = new Size(70, 30);
            _failButton.Position = new Position(72, 0);
            _failButton.Clicked += (obj, ee) =>
            {
                Clear();
                if (!ManualTest.IsConfirmed())
                {
                    _tsettings.TCResult = StrResult.FAIL;
                    ManualTest.Confirm();
                }
                Tizen.Log.Fatal("TBT", "Fail Button clicked!");
            };

            _blockButton = new Button(new ButtonStyle());
            SetCommonButtonStyle(_blockButton, "B");
            _blockButton.Size = new Size(70, 30);
            _blockButton.Position = new Position(144, 0);
            _blockButton.Clicked += (obj, ee) =>
            {
                Clear();
                if (!ManualTest.IsConfirmed())
                {
                    _tsettings.TCResult = StrResult.BLOCK;
                    ManualTest.Confirm();
                }
            };

            _runButton = new Button(new ButtonStyle());
            SetCommonButtonStyle(_runButton, "R");
            _runButton.Size = new Size(70, 30);
            _runButton.Position = new Position(216, 0);
            _runButton.Clicked += (obj, ee) =>
            {
                LockUIButton();
                Clear();
                _tsettings.Testcase_ID = _tcIDList[_currentTCNum];
                _tsettings.TCResult = "";
                _tRunner.Execute();
            };

            _homeButton = new Button(new ButtonStyle());
            SetCommonButtonStyle(_homeButton, "H");
            _homeButton.Size = new Size(70, 30);
            _homeButton.Position = new Position(0, 32);
            _homeButton.Clicked += (obj, ee) =>
            {
                Clear();
                if (!ManualTest.IsConfirmed())
                {
                    _tsettings.TCResult = StrResult.NOTRUN;
                    ManualTest.Confirm();
                }
                else
                {
                    _detailView.Hide();
                    _initView.Show();
                }
            };

            _preButton = new Button(new ButtonStyle());
            SetCommonButtonStyle(_preButton, "<<");
            _preButton.Size = new Size(60, 30);
            _preButton.Position = new Position(160, 32);
            _preButton.Clicked += (obj, ee) =>
            {
                Clear();
                if (!ManualTest.IsConfirmed())
                {
                    _tsettings.TCResult = StrResult.NOTRUN;
                    ManualTest.Confirm();
                }
                else
                {
                    if (_currentTCNum != 0)
                    {
                        _currentTCNum--;
                        _notRun.Text = _listItem[_currentTCNum].Result;
                        ManualTest.Confirm();
                        UpdateDetailPage();
                    }
                }
            };

            _nextButton = new Button(new ButtonStyle());
            SetCommonButtonStyle(_nextButton, ">>");
            _nextButton.Size = new Size(60, 30);
            _nextButton.Position = new Position(222, 32);
            _nextButton.Clicked += (obj, ee) =>
            {
                Clear();
                if (!ManualTest.IsConfirmed())
                {
                    _tsettings.TCResult = StrResult.NOTRUN;
                    ManualTest.Confirm();
                }
                if (_currentTCNum + 1 != ResultNumber.Total)
                {
                    Tizen.Log.Fatal("NUI", "Print the [not run] CurrentTCNum::" + _currentTCNum);
                    _currentTCNum++;
                    _notRun.Text = _listItem[_currentTCNum].Result;
                    UpdateDetailPage();
                }
            };

            View buttonView = new View();
            buttonView.ParentOrigin = ParentOrigin.TopLeft;
            buttonView.PivotPoint = PivotPoint.TopLeft;
            buttonView.Size2D = new Size2D(Window.Instance.Size.Width, 80);
            buttonView.Position2D = new Position2D(30, 170);

            buttonView.Add(_passButton);
            buttonView.Add(_failButton);
            buttonView.Add(_blockButton);
            buttonView.Add(_runButton);
            buttonView.Add(_homeButton);
            buttonView.Add(_notRun);
            buttonView.Add(_preButton);
            buttonView.Add(_nextButton);
            _detailView.Add(buttonView);
        }

        public void ExecuteTC(View view)
        {
            Tizen.Log.Fatal("ManualTCT", "Execute the manual test case!");

            _caseView = view;
            _caseView.ParentOrigin = Position.ParentOriginTopLeft;
            _caseView.PivotPoint = PivotPoint.TopLeft;
            _caseView.Position = new Position(40.0f, 120.0f, 0.0f);
            _detailView.Add(_caseView);
            _caseView.Show();
        }

        private void Clear()
        {
            if (_caseView.IsOnWindow == true)
            {
                _detailView.Remove(_caseView);
            }
        }

        public void ClearTestCase(View view)
        {
            Tizen.Log.Fatal("NUI", "Clear test case!");
            _detailView.Remove(view);
        }

        //Use to update the _summaryLabel.
        private void SetSummaryResult()
        {
            ResultNumber.NotRun = ResultNumber.Total - ResultNumber.Pass - ResultNumber.Fail - ResultNumber.Block;
            _summaryLabel1.Text = "T : " + ResultNumber.Total + ", P : " + ResultNumber.Pass;
            _summaryLabel2.Text = "F : " + ResultNumber.Fail + ", B : " + ResultNumber.Block + ", NR: " + ResultNumber.NotRun;
            Tizen.Log.Fatal("ManualTCT", "Set the result Text");
        }

        private void CreateInitList()
        {
            Tizen.Log.Fatal("ManualTCT", "CreateInitList");
            _initList = new FlexibleView();
            _initList.ParentOrigin = ParentOrigin.TopLeft;
            _initList.PivotPoint = PivotPoint.TopLeft;
            _initList.Size = new Size(Window.Instance.Size.Width, 400);
            _initList.Position = new Position(0, 80);
            _initList.ClippingMode = ClippingModeType.ClipChildren;
            _adapter = new ListBridge(_tcIDList, _listItem);
            _initList.SetAdapter(_adapter);
            LinearLayoutManager layoutManager = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            _initList.SetLayoutManager(layoutManager);
            _initList.FocusedItemIndex = 0;
            _initList.ItemClicked += (obj, e) =>
            {
                Button button = e.ClickedView.ItemView as Button;
                if (button)
                {
                    Tizen.Log.Fatal("TBT", "Item clicked!!::" + button.Name);
                    _currentTCNum = int.Parse(button.Name);
                    _initView.Hide();
                    UpdateDetailPage();
                    _caseView.Hide();
                    _detailView.Show();
                }
            };
        }

        private void CreateDetailList()
        {
            Tizen.Log.Fatal("NUI", "Print the CreateDetailList::count: " + _currentTCInfo.Count);
            _description.Text = _currentTCInfo[0];

            _detailList = new FlexibleView();
            _detailList.ParentOrigin = ParentOrigin.TopLeft;
            _detailList.PivotPoint = PivotPoint.TopLeft;
            _detailList.Size = new Size(Window.Instance.Size.Width - 100, _detailScrollHeight);
            _detailList.Position = new Position(30, 20);
            _detailList.BackgroundColor = Color.Black;
            _detailList.ClippingMode = ClippingModeType.ClipChildren;
            _adapter_detail = new DetailListBridge(_currentTCInfo);
            _detailList.SetAdapter(_adapter_detail);
            LinearLayoutManager layoutManager = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            _detailList.SetLayoutManager(layoutManager);
            _detailView.Add(_detailList);
        }

        //Init all the data, should be offered by Test Framework
        void InitData()
        {
            ResultNumber.Total = _tcIDList.Count;
            ResultNumber.Pass = 0;
            ResultNumber.Fail = 0;
            ResultNumber.Block = 0;
            _tcInfoList = new List<TestcaseInfo>();
            foreach (var testcaseItem in _listItem)
            {
                foreach (KeyValuePair<string, ITest> pair in _tRunner.GetTestList())
                {
                    if (testcaseItem.TCName.Equals(pair.Key))
                    {
                        List<string> preconditions = new List<string>();
                        preconditions.Add("Preconditions:");
                        List<string> steps = new List<string>();
                        steps.Add("Steps:");
                        List<string> postconditions = new List<string>();
                        postconditions.Add("Postconditions:\n");
                        IEnumerator<CustomAttributeData> customAttributes = pair.Value.Method.MethodInfo.CustomAttributes.GetEnumerator();
                        while (customAttributes.MoveNext())
                        {
                            if (customAttributes.Current.AttributeType.FullName.Equals(STEP_ATTRIBUTE_NAME))
                            {
                                steps.Add(customAttributes.Current.ConstructorArguments[0].Value + "." + customAttributes.Current.ConstructorArguments[1].Value);
                            }
                            else if (customAttributes.Current.AttributeType.FullName.Equals(PRECONDITION_ATTRIBUTE_NAME))
                            {
                                preconditions.Add(customAttributes.Current.ConstructorArguments[0].Value + "." + customAttributes.Current.ConstructorArguments[1].Value);
                            }
                            else if (customAttributes.Current.AttributeType.FullName.Equals(POSTCONDITION_ATTRIBUTE_NAME))
                            {
                                postconditions.Add(customAttributes.Current.ConstructorArguments[0].Value + "." + customAttributes.Current.ConstructorArguments[1].Value);
                            }
                        }
                        _tcInfoList.Add(new TestcaseInfo
                        {
                            TestcaseName = pair.Key,
                            Preconditions = preconditions,
                            Steps = steps,
                            Postconditions = postconditions,
                        });
                        break;
                    }
                }
                UpdateCurrentTCInfo();
            }
        }

        //The data in CurrentTCInfo list will be show in _detailList.
        void UpdateCurrentTCInfo()
        {
            _currentTCInfo = new List<string>();
            Tizen.Log.Fatal("NUI", "Print the CurrentTCNum::" + _currentTCNum);
            _currentTCInfo.Add("DESCRIPTION:#" + (_currentTCNum + 1));
            string[] str = _tcInfoList[_currentTCNum].TestcaseName.Split('.');
            _currentTCInfo.Add("CLASS:" + str[str.Length - 2]);
            _currentTCInfo.Add("METHOD:" + str[str.Length - 1]);
            for(int index = 0; index < _tcInfoList[_currentTCNum].Preconditions.Count; index++)
            {
                _currentTCInfo.Add(_tcInfoList[_currentTCNum].Preconditions[index]);
            }
            for(int index = 0; index < _tcInfoList[_currentTCNum].Steps.Count; index++ )
            {
                _currentTCInfo.Add(_tcInfoList[_currentTCNum].Steps[index]);
            }
            for(int index = 0; index < _tcInfoList[_currentTCNum].Postconditions.Count; index++ )
            {
                _currentTCInfo.Add(_tcInfoList[_currentTCNum].Postconditions[index]);
            }
            Tizen.Log.Fatal("NUI", "the CurrentTCNum::" + _currentTCNum);
        }

        private void OnSingleTestDone(object sender, SingleTestDoneEventArgs e)
        {
            //Test when will this event will be triggered
            Tizen.Log.Fatal("NUI", "OnSingleTestDone has been triggered!");
            // check old result
            if (_listItem[_currentTCNum].Result.Contains(StrResult.FAIL))
            {
                ResultNumber.Fail = ResultNumber.Fail - 1;
            }
            else if (_listItem[_currentTCNum].Result.Contains(StrResult.PASS))
            {
                ResultNumber.Pass = ResultNumber.Pass - 1;
            }
            else if (_listItem[_currentTCNum].Result.Contains(StrResult.BLOCK))
                ResultNumber.Block = ResultNumber.Block - 1;

            // Update new result
            _listItem[_currentTCNum].Result = e.Result;
            if (e.Result.Contains(StrResult.PASS))
            {
                ResultNumber.Pass += 1;
            }
            else if (e.Result.Contains(StrResult.FAIL))
            {
                ResultNumber.Fail += 1;
            }
            else if (e.Result.Contains(StrResult.BLOCK))
            {
                ResultNumber.Block += 1;
            }

            FlexibleViewViewHolder holder = _initList?.FindViewHolderForAdapterPosition(_currentTCNum);
            if (holder != null)
            {
                string testcaseName = "#." + (_currentTCNum + 1).ToString() + _tcIDList[_currentTCNum];
                string resultText = "[" + _listItem[(int)_currentTCNum].Result + "]";
                string text = testcaseName + resultText;
                Button btn = holder.ItemView as Button;
                btn.Text = text;
                _adapter?.UpdateItemData(_currentTCNum, _listItem);
            }
            SetSummaryResult();
            _notRun.Text = _listItem[_currentTCNum].Result;
        }

        public void LockUIButton()
        {
            _runButton.IsEnabled = false;
        }

        public void UnlockUIButton()
        {
            _runButton.IsEnabled = true;
        }
    }
}

