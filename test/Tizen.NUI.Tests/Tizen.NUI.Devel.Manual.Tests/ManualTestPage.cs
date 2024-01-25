/*
* Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.Applications;

namespace Tizen.NUI.Tests
{
    class ManualTestNUI
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
                FlexibleViewViewHolder viewHolder = new FlexibleViewViewHolder(new Button());
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
                    btn.Focusable = true;
                    btn.Text = text;
                    btn.Feedback = false;
                    btn.Name = position.ToString();
                    btn.PointSize = ManualTest.GetPointSize();
                    btn.Size = new Size(Window.Instance.Size.Width, Window.Instance.Size.Height * 0.046f);
                    btn.TextColor = new Color(0, 0, 0, 1);
                    btn.ImageShadow = new ImageShadow
                    (
                        Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/rectangle_btn_shadow.png",
                        new Rectangle(5, 5, 5, 5)
                    );
                    btn.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/rectangle_toggle_btn_normal.png";
                    btn.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
                    btn.FocusGained += (obj, e) =>
                    {
                        btn.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/rectangle_point_btn_normal.png";
                    };
                    btn.FocusLost += (obj, e) =>
                    {
                        btn.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/rectangle_toggle_btn_normal.png";
                    };
                    btn.ParentOrigin = Position.ParentOriginTopLeft;
                    btn.PivotPoint = PivotPoint.TopLeft;
                    btn.TextAlignment = HorizontalAlignment.Begin;
                    btn.CellIndex = new Vector2(position, 0);
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
        private ToastMessage _toastMessage;
        //For TV
        private float _pointSize = 20.0f;

        //Save the information of every single test case
        private List<TestcaseInfo> _tcInfoList;
        private List<string> _currentTCInfo;

        private static ManualTestNUI _instance;
        private static Object _lockObject = new object();

        //Show the result of all the test case
        private TextLabel _summaryLabel;
        private View _initView;
        private View _detailView;
        private View _caseView;
        private FlexibleView _initList;
        private ListBridge _adapter;
        private TableView _detailList;
        private ScrollableBase _scrollableBase;
        private View _buttonContainer;
        private View _buttonContainer2;
        private TableView _firstPageContainer;
        private Button _run;
        private Button _runButton;

        //Always save the current TC number;
        private int _currentTCNum = 0;


        public static ManualTestNUI GetInstance()
        {
            lock (_lockObject)
            {
                if (_instance == null)
                {
                    _instance = new ManualTestNUI();
                }
            }
            return _instance;
        }

        private ManualTestNUI()
        {
            Initialize();
        }
        public void Initialize()
        {
            FocusManager.Instance.FocusIndicator = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = new Position(0, 0, 0),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BorderlineColor = Color.Orange,
                BorderlineWidth = 4.0f,
                BorderlineOffset = -1f,
                BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 0.2f),
            };

            Tizen.Log.Fatal("NUI", "Initialize window's width is " + Window.Instance.Size.Width + " Dpi is " + Window.Instance.Dpi.Length());
            Window.Instance.BackgroundColor = Color.White;

            _toastMessage = new ToastMessage();
            _pointSize = ManualTest.GetPointSize();
            RunType.Value = RunType.MANUAL;
            _tRunner = new TRunner();
            _tRunner.LoadTestsuite();
            _tRunner.SingleTestDone += OnSingleTestDone;
            _tcIDList = new List<string>();
            _listItem = new List<ItemData>();
            _listNotPass = TSettings.GetInstance().GetNotPassListManual();
            int count = 0;
            if (_listNotPass.Count == 0)
            {
                foreach (KeyValuePair<string, ITest> pair in _tRunner.GetTestList())
                {
                    count++;
                    _listItem.Add(new ItemData { No = count, TCName = pair.Key, Result = StrResult.NOTRUN });
                    _tcIDList.Add(pair.Key);
                }
            }
            else
            {
                foreach (var tc in _listNotPass)
                {
                    count++;
                    _listItem.Add(new ItemData { No = count, TCName = tc, Result = StrResult.NOTRUN });
                    _tcIDList.Add(tc);
                }
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

            _summaryLabel = new TextLabel();
            _summaryLabel.PointSize = _pointSize;
            _summaryLabel.Size = new Size(Window.Instance.Size.Width, Window.Instance.Size.Height * 0.055f);
            _summaryLabel.ParentOrigin = Position.ParentOriginTopLeft;
            _summaryLabel.PivotPoint = PivotPoint.TopLeft;
            _summaryLabel.HorizontalAlignment = HorizontalAlignment.Center;
            _summaryLabel.VerticalAlignment = VerticalAlignment.Center;
            Window.Instance.GetDefaultLayer().Add(_summaryLabel);
            SetSummaryResult();

            _initView = new View();
            _initView.Size = new Size(Window.Instance.Size.Width, Window.Instance.Size.Height * 0.9f);
            _initView.Position = new Position(0.0f, (int)(Window.Instance.Size.Height * 0.0648), 0.0f);
            _initView.ParentOrigin = Position.ParentOriginTopLeft;
            _initView.PivotPoint = PivotPoint.TopLeft;
            InitializeFirstPage();
            _initView.Show();
            Window.Instance.GetDefaultLayer().Add(_initView);

            _detailView = new View();
            _detailView.Size = new Size(Window.Instance.Size.Width, Window.Instance.Size.Height * 0.9f);
            _detailView.Position = new Position(0.0f, (int)(Window.Instance.Size.Height * 0.0648), 0.0f);
            _detailView.ParentOrigin = Position.ParentOriginTopLeft;
            _detailView.PivotPoint = PivotPoint.TopLeft;
            InitializeDetailPage();
            _detailView.Hide();
            Window.Instance.GetDefaultLayer().Add(_detailView);

            FocusManager.Instance.SetCurrentFocusView(_run);
        }

        public void LockUIButton()
        {
            _runButton.IsEnabled = false;
        }

        public void UnlockUIButton()
        {
            _runButton.IsEnabled = true;
        }

        void SetCommonButtonStyle(Button btn, string text)
        {
            if (!btn) return;
            btn.Focusable = true;
            btn.Text = text;
            btn.Feedback = false;
            btn.PointSize = _pointSize;
            float buttonWidth = ManualTest.IsMobile() ? Window.Instance.Size.Width * 0.18f : Window.Instance.Size.Width * 0.06f;
            btn.Size = new Size(buttonWidth, Window.Instance.Size.Height * 0.046f);
            btn.TextColor = new Color(0, 0, 0, 1);
            btn.ImageShadow = new ImageShadow
            (
                Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/rectangle_btn_shadow.png",
                new Rectangle(5, 5, 5, 5)
            );
            btn.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/rectangle_toggle_btn_normal.png";
            btn.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            btn.ParentOrigin = Position.ParentOriginTopLeft;
            btn.PivotPoint = PivotPoint.TopLeft;
            btn.FocusGained += (obj, e) =>
            {
                btn.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/rectangle_point_btn_normal.png";
            };
            btn.FocusLost += (obj, e) =>
            {
                btn.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/rectangle_toggle_btn_normal.png";
            };
        }

        void InitializeFirstPage()
        {
            //Create Run Button, when you Click it, then the first test case will be executed.
            _doneButton = new Button();
            SetCommonButtonStyle(_doneButton, "Done");
            _doneButton.Clicked += (obj, ee) =>
            {
                TSettings.GetInstance().SubmitManualResult();
            };

            _run = new Button();
            SetCommonButtonStyle(_run, "Runner");
            _run.Clicked += (obj, ee) =>
            {
                Tizen.Log.Fatal("NUI", "Check all the test case from the first one.");
                _currentTCNum = 0;
                _initView.Hide();
                _caseView.Hide();
                UpdateDetailPage();
                _detailView.Show();
                FocusManager.Instance.SetCurrentFocusView(_runButton);
            };
            _run.RightFocusableView = _doneButton;
            _doneButton.LeftFocusableView = _run;

            //To show all the test case information(Number _className._TCName  [result]).
            _initList = new FlexibleView();
            _initList.Position = new Position(0, Window.Instance.Size.Height * 0.0925f);
            _initList.Size = new Size(Window.Instance.Size.Width, Window.Instance.Size.Height * 0.74f);
            _adapter = new ListBridge(_tcIDList, _listItem);
            _initList.SetAdapter(_adapter);
            LinearLayoutManager layoutManager = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            _initList.SetLayoutManager(layoutManager);
            _initList.FocusedItemIndex = 0;
            _initList.Focusable = true;
            _initList.ItemClicked += (obj, e) =>
            {
                Button button = e.ClickedView.ItemView as Button;
                if (button)
                {
                    Tizen.Log.Fatal("NUI", "Item clicked!!::" + button.Name);
                    _currentTCNum = int.Parse(button.Name);
                    _initView.Hide();
                    UpdateDetailPage();
                    _caseView.Hide();
                    _detailView.Show();
                    FocusManager.Instance.SetCurrentFocusView(_runButton);
                }
            };
            _initList.FocusGained += (obj, e) =>
            {
                FlexibleViewViewHolder holder = _initList?.FindViewHolderForAdapterPosition(0);
                if (holder != null && holder.ItemView != null)
                {
                    FocusManager.Instance.SetCurrentFocusView(holder.ItemView);
                    _currentTCNum = 0;
                }
            };
            _initList.FocusLost += (obj, e) =>
            {
                _currentTCNum = 0;
            };
            _initList.KeyEvent += (obj, e) =>
            {
                if (e.Key.State == Key.StateType.Down)
                {
                    Tizen.Log.Fatal("NUI", "KeyEvent~KeyPressedName = " + e.Key.KeyPressedName + ",KeyCode = " + e.Key.KeyCode);
                    if (e.Key.KeyPressedName == "Up")
                    {
                        if (_currentTCNum == 0)
                        {
                            FocusManager.Instance.SetCurrentFocusView(_run);
                        }
                        else
                        {
                            FlexibleViewViewHolder holder = _initList?.FindViewHolderForAdapterPosition(_currentTCNum - 1);
                            if (holder != null && holder.ItemView != null)
                            {
                                FocusManager.Instance.SetCurrentFocusView(holder.ItemView);
                                _currentTCNum--;
                            }
                        }
                    }
                    else if (e.Key.KeyPressedName == "Down")
                    {
                        if (_currentTCNum == _initList.ChildCount - 1)
                        {
                            _currentTCNum = 0;
                        }
                        else
                        {
                            _currentTCNum++;
                        }
                        FlexibleViewViewHolder holder = _initList?.FindViewHolderForAdapterPosition(_currentTCNum);
                        if (holder != null && holder.ItemView != null)
                        {
                            FocusManager.Instance.SetCurrentFocusView(holder.ItemView);
                        }
                    }
                    else if (e.Key.KeyPressedName == "Return")
                    {
                        _initView.Hide();
                        UpdateDetailPage();
                        _caseView.Hide();
                        _detailView.Show();
                        FocusManager.Instance.SetCurrentFocusView(_runButton);
                    }
                }
                return true;
            };

            _firstPageContainer = new TableView(1, 2);
            _firstPageContainer.PivotPoint = Position.PivotPointTopLeft;
            _firstPageContainer.ParentOrigin = Position.ParentOriginTopLeft;
            _firstPageContainer.Size = new Size(Window.Instance.Size.Width, Window.Instance.Size.Height * 0.1f);
            _firstPageContainer.Focusable = true;
            _firstPageContainer.SetCellAlignment(new TableView.CellPosition(0, 0), HorizontalAlignmentType.Right, VerticalAlignmentType.Center);
            _firstPageContainer.SetCellAlignment(new TableView.CellPosition(0, 1), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
            _firstPageContainer.AddChild(_doneButton, new TableView.CellPosition(0, 0));
            _firstPageContainer.AddChild(_run, new TableView.CellPosition(0, 1));
            _run.DownFocusableView = _initList;
            _doneButton.DownFocusableView = _initList;

            _initView.Add(_firstPageContainer);
            _initView.Add(_initList);
            Tizen.Log.Fatal("NUI", "TCT : InitializeFirstPage:");
            FocusManager.Instance.SetCurrentFocusView(_run);
        }

        //Update the Test Page before you want to show it(Click Run/Pre/nect Button, or Click on item in the List).
        void UpdateDetailPage()
        {
            UpdateCurrentTCInfo();
            Tizen.Log.Fatal("NUI", "UpdateDetailPage:");
            CreateTestCase();
        }

        void InitializeDetailPage()
        {
            _scrollableBase = new ScrollableBase
            {
                Size = new Size(Window.Instance.Size.Width * 0.9739f, Window.Instance.Size.Height * 0.6629f),
                ScrollingDirection = ScrollableBase.Direction.Vertical,
            };
            _detailList = new TableView(23, 1);
            _detailList.Focusable = true;
            _detailList.Size = new Size(Window.Instance.Size.Width * 0.9739f, Window.Instance.Size.Height * 0.9f);
            _detailList.ParentOrigin = Position.ParentOriginTopLeft;
            _detailList.PivotPoint = PivotPoint.TopLeft;
            _detailList.Position = new Position(0.0f, 0.0f, 0.0f);
            CreateDetailList();
            _scrollableBase.Add(_detailList);
            _detailView.Add(_scrollableBase);

            //To Place the function button, such as PASS, FAIL.....
            _buttonContainer = new View();
            _buttonContainer.PivotPoint = PivotPoint.TopLeft;
            _buttonContainer.ParentOrigin = Position.ParentOriginTopLeft;
            _buttonContainer.Position = new Position(0, Window.Instance.Size.Height * 0.68f, 0);
            _buttonContainer.Size = new Size(Window.Instance.Size.Width * 0.8f, Window.Instance.Size.Height * 0.1f);
            _buttonContainer.Focusable = true;

            _buttonContainer2 = new View();
            _buttonContainer2.PivotPoint = PivotPoint.TopLeft;
            _buttonContainer2.ParentOrigin = Position.ParentOriginTopLeft;
            _buttonContainer2.Position = new Position(0, Window.Instance.Size.Height * 0.8f, 0);
            _buttonContainer2.Size = new Size(Window.Instance.Size.Width * 0.8f, Window.Instance.Size.Height * 0.1f);
            _buttonContainer2.Focusable = true;

            var flexlayout = new FlexLayout();
            flexlayout.Direction = FlexLayout.FlexDirection.Row;
            flexlayout.Justification = FlexLayout.FlexJustification.SpaceBetween;
            _buttonContainer.Layout = flexlayout;
            var flexlayout2 = new FlexLayout();
            flexlayout2.Direction = FlexLayout.FlexDirection.Row;
            flexlayout2.Justification = FlexLayout.FlexJustification.SpaceBetween;
            _buttonContainer2.Layout = flexlayout2;
            CreateButtons();
            _detailView.Add(_buttonContainer);
            _detailView.Add(_buttonContainer2);
        }

        //To show the detail information of the test case
        //Preconditions
        //Steps
        //PostConditions
        void CreateTestCase()
        {
            if (_detailList != null && _scrollableBase != null)
            {
                _detailView.Remove(_scrollableBase);
                _scrollableBase.Remove(_detailList);
                _detailList.Dispose();
                _detailList = null;
                _scrollableBase.Dispose();
                _scrollableBase = null;
            }
            Tizen.Log.Fatal("NUI", "Print the CurrentTCNum here::" + _currentTCNum);
            _scrollableBase = new ScrollableBase
            {
                Size = new Size(Window.Instance.Size.Width * 0.9739f, Window.Instance.Size.Height * 0.6629f),
                ScrollingDirection = ScrollableBase.Direction.Vertical,
            };
            _detailList = new TableView(10, 1);
            _detailList.Focusable = true;
            _detailList.Size = new Size(Window.Instance.Size.Width * 0.9739f, Window.Instance.Size.Height * 0.9f);
            _detailList.ParentOrigin = Position.ParentOriginTopLeft;
            _detailList.PivotPoint = PivotPoint.TopLeft;
            _detailList.Position = new Position(0.0f, 0.0f, 0.0f);
            CreateDetailList();
            _scrollableBase.Add(_detailList);
            _detailView.Add(_scrollableBase);
            if (_notRun)
            {
                _notRun.Text = _listItem[_currentTCNum].Result;
            }
        }

        //Create all the function buttons here, such as PASS, FAIL.....
        void CreateButtons()
        {
            _notRun = new TextLabel();
            _notRun.HorizontalAlignment = HorizontalAlignment.Center;
            _notRun.VerticalAlignment = VerticalAlignment.Center;
            _notRun.PointSize = _pointSize;
            _notRun.Text = "Not Run";
            float buttonWidth = ManualTest.IsMobile() ? Window.Instance.Size.Width * 0.18f : Window.Instance.Size.Width * 0.06f;
            _notRun.Size = new Size(buttonWidth, Window.Instance.Size.Height * 0.046f);

            _passButton = new Button();
            SetCommonButtonStyle(_passButton, "Pass");
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

            _failButton = new Button();
            SetCommonButtonStyle(_failButton, "Fail");
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

            _blockButton = new Button();
            SetCommonButtonStyle(_blockButton, "Block");
            _blockButton.Clicked += (obj, ee) =>
            {
                Clear();
                if (!ManualTest.IsConfirmed())
                {
                    _tsettings.TCResult = StrResult.BLOCK;
                    ManualTest.Confirm();
                }
            };

            _runButton = new Button();
            SetCommonButtonStyle(_runButton, "Run");
            _runButton.Clicked += (obj, ee) =>
            {
                LockUIButton();
                Clear();
                //should update the _caseView by the test case
                _tsettings.Testcase_ID = _tcIDList[_currentTCNum];
                _tsettings.TCResult = "";
                _tRunner.Execute();
            };

            _homeButton = new Button();
            SetCommonButtonStyle(_homeButton, "Home");
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
                    FocusManager.Instance.SetCurrentFocusView(_run);
                }
            };

            _preButton = new Button();
            SetCommonButtonStyle(_preButton, "<<");
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
                    else if (_currentTCNum == 0)
                    {
                        _toastMessage.Message = "This is first testcase";
                        _toastMessage.Post();
                    }
                }
            };

            _nextButton = new Button();
            SetCommonButtonStyle(_nextButton, ">>");
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
                else if (_currentTCNum + 1 == ResultNumber.Total)
                {
                    _toastMessage.Message = "This is last testcase";
                    _toastMessage.Post();
                }
            };

            _passButton.RightFocusableView = _failButton;
            _passButton.DownFocusableView = _homeButton;
            _failButton.LeftFocusableView = _passButton;
            _failButton.RightFocusableView = _blockButton;
            _blockButton.LeftFocusableView = _failButton;
            _blockButton.RightFocusableView = _runButton;
            _blockButton.DownFocusableView = _preButton;
            _runButton.LeftFocusableView = _blockButton;
            _runButton.DownFocusableView = _nextButton;
            _homeButton.UpFocusableView = _passButton;
            _homeButton.RightFocusableView = _preButton;
            _preButton.UpFocusableView = _blockButton;
            _preButton.LeftFocusableView = _homeButton;
            _preButton.RightFocusableView = _nextButton;
            _nextButton.UpFocusableView = _runButton;
            _nextButton.LeftFocusableView = _preButton;

            _buttonContainer.Add(_passButton);
            _buttonContainer.Add(_failButton);
            _buttonContainer.Add(_blockButton);
            _buttonContainer.Add(_runButton);
            _buttonContainer2.Add(_homeButton);
            _buttonContainer2.Add(_notRun);
            _buttonContainer2.Add(_preButton);
            _buttonContainer2.Add(_nextButton);
        }

        public void ExecuteTC(View view)
        {
            Tizen.Log.Fatal("NUI", "Execute the manual test case!");

            _caseView = view;
            _caseView.ParentOrigin = Position.ParentOriginTopLeft;
            _caseView.PivotPoint = PivotPoint.TopLeft;
            _caseView.Position = new Position(Window.Instance.Size.Width * 0.01f, Window.Instance.Size.Height * 0.74f, 0.0f);
            _detailView.Add(_caseView);
            _caseView.Show();
            FocusManager.Instance.SetCurrentFocusView(_caseView);
        }

        private bool OnKeyPressed(object source, View.KeyEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "CaseView OnKeyPressed 1 Down..." + e.Key.KeyPressedName);

            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Down")
                {
                    FocusManager.Instance.SetCurrentFocusView(_passButton);

                }
            }
            return false;
        }

        private bool OnRunnerKeyPressed(object source, View.KeyEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "Runner OnKeyPressed Down..." + e.Key.KeyPressedName);

            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Up")
                {
                    Tizen.Log.Fatal("NUI", "Set current focus view :: doneButton");
                    FocusManager.Instance.SetCurrentFocusView(_doneButton);
                }
            }
            return false;
        }

        private bool OnDownButtonKeyPressed(object source, View.KeyEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "DownButton OnKeyPressed Down..." + e.Key.KeyPressedName);

            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Down")
                {
                    Tizen.Log.Fatal("NUI", "Set current focus view :: run");
                    FocusManager.Instance.SetCurrentFocusView(_run);
                }
            }
            return false;
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
            FocusManager.Instance.SetCurrentFocusView(_runButton);
            Tizen.Log.Fatal("NUI", "Clear test case!");
            _detailView.Remove(view);
        }

        //Use to update the _summaryLabel.
        private void SetSummaryResult()
        {
            ResultNumber.NotRun = ResultNumber.Total - ResultNumber.Pass - ResultNumber.Fail - ResultNumber.Block;
            _summaryLabel.Text = "Total : " + ResultNumber.Total + ", Pass : " + ResultNumber.Pass + ", Fail : " + ResultNumber.Fail + ", Block : " + ResultNumber.Block + ", Not Run : " + ResultNumber.NotRun;
        }

        private void CreateDetailList()
        {
            Tizen.Log.Fatal("NUI", "Print the CreateDetailList::");
            int senNum = _currentTCInfo.Count;
            for (int index = 0; index < senNum; index++)
            {
                TextLabel description = new TextLabel();
                description.ParentOrigin = Position.ParentOriginTopLeft;
                description.PivotPoint = PivotPoint.TopLeft;
                description.Position = new Position(0.0f, 0.0f, 0.0f);
                description.Size2D = new Size2D((int)(Window.Instance.Size.Width * 0.9895), (int)(Window.Instance.Size.Height * 0.0462));
                description.HorizontalAlignment = HorizontalAlignment.Begin;
                description.PointSize = _pointSize;
                description.Text = _currentTCInfo[(int)index];
                description.MultiLine = true;
                _detailList.AddChild(description, new TableView.CellPosition((uint)index, 0));
                _detailList.SetFixedHeight((uint)index, Window.Instance.Size.Height * 0.0462f);
            }
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
                        IEnumerator<CustomAttributeData> customAttributes = pair.Value.Method.MethodInfo.CustomAttributes.GetEnumerator();
                        List<string> preconditions = new List<string>();
                        preconditions.Add("Preconditions:");
                        List<string> steps = new List<string>();
                        steps.Add("Steps:");
                        List<string> postconditions = new List<string>();
                        postconditions.Add("Postconditions:\n");

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
            }
            UpdateCurrentTCInfo();
        }

        //The data in CurrentTCInfo list will be show in _detailList.
        void UpdateCurrentTCInfo()
        {
            _currentTCInfo = new List<string>();
            Tizen.Log.Fatal("NUI.Components", "Print the CurrentTCNum::" + _currentTCNum);
            _currentTCInfo.Add("DESCRIPTION:#" + (_currentTCNum + 1));
            string[] str = _tcInfoList[_currentTCNum].TestcaseName.Split('.');
            _currentTCInfo.Add("CLASS:" + str[str.Length - 2]);
            _currentTCInfo.Add("METHOD:" + str[str.Length - 1]);
            for (int index = 0; index < _tcInfoList[_currentTCNum].Preconditions.Count; index++)
            {
                _currentTCInfo.Add(_tcInfoList[_currentTCNum].Preconditions[index]);
            }
            for (int index = 0; index < _tcInfoList[_currentTCNum].Steps.Count; index++)
            {
                _currentTCInfo.Add(_tcInfoList[_currentTCNum].Steps[index]);
            }
            for (int index = 0; index < _tcInfoList[_currentTCNum].Postconditions.Count; index++)
            {
                _currentTCInfo.Add(_tcInfoList[_currentTCNum].Postconditions[index]);
            }
            Tizen.Log.Fatal("NUI", "The CurrentTCNum::" + _currentTCNum);
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
    }
}

