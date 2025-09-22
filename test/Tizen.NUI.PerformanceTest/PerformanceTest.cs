/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;


class PerformanceTestExample : NUIApplication
{
    const uint ROWS_COUNT = 40;
    const uint COLUMNS_COUNT = 40;
    const uint TOTAL_COLUMNS_COUNT = 80;
    const uint DURATION_PER_COLUMNS = 50; // miliseconds
    // Increase animation time cause OnTick time can be delayed.
    const uint DURATION_OF_ANIMATION = (DURATION_PER_COLUMNS * (COLUMNS_COUNT * 4 / 3)); // miliseconds.
    

    const float VIEW_MARGIN_RATE = 0.2f;
    enum ViewTestType
    {
        TEST_TYPE_COLOR = 0,            ///< Test with simple color
        TEST_TYPE_IMAGE,                ///< Test with simple image
        TEST_TYPE_TEXT,                 ///< Test with simple text label
        TEST_TYPE_ROUNDED_COLOR,        ///< Test with rounded color
        TEST_TYPE_BORDER_COLOR,         ///< Test with borderline color
        TEST_TYPE_ROUNDED_BORDER_COLOR, ///< Test with rounded borderline color
        TEST_TYPE_BLUR_COLOR,           ///< Test with blur color
        TEST_TYPE_ROUNDED_BLUR_COLOR,   ///< Test with blur color
        TEST_TYPE_MAX,
    };

    static string TestTypeString(ViewTestType type)
    {
        switch(type)
        {
            case ViewTestType.TEST_TYPE_COLOR:               return "COLOR";
            case ViewTestType.TEST_TYPE_IMAGE:               return "IMAGE";
            case ViewTestType.TEST_TYPE_TEXT:                return "TEXT";
            case ViewTestType.TEST_TYPE_ROUNDED_COLOR:       return "ROUNDED COLOR";
            case ViewTestType.TEST_TYPE_BORDER_COLOR:        return "BORDER COLOR";
            case ViewTestType.TEST_TYPE_ROUNDED_BORDER_COLOR:return "ROUNDED BORDER COLOR";
            case ViewTestType.TEST_TYPE_BLUR_COLOR:          return "BLUR COLOR";
            case ViewTestType.TEST_TYPE_ROUNDED_BLUR_COLOR:  return "ROUNDED BLUR COLOR";
            default:                                         return "UNKNOWN";
        }
    }

    static string IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image/";
    readonly static string[] IMAGE_PATH = 
    {
        IMAGE_DIR + "gallery-small-1.jpg",
    };

    class Statistic
    {
        const double trimRate = 0.34;
        global::System.Collections.Generic.List<double> v;
        int vcnt;
        double vsum;
        public Statistic()
        {
            clear();
        }
        public void clear()
        {
            v = new global::System.Collections.Generic.List<double>();
            vcnt = 0;
            vsum = 0.0;
        }
        public void add(double x)
        {
            v.Add(x);
            vcnt++;
            vsum += x;
        }
        public double getAverage()
        {
            if(vcnt == 0)return 0.0;
            return vsum / vcnt;
        }
        public double getTrimedAverage()
        {
            if(vcnt == 0)return 0.0;
            v.Sort();
            double trimVsum = 0;
            int removedCnt = (int)(vcnt * trimRate * 0.5); // floor
            int trimVcnt = vcnt - removedCnt * 2;
            if(trimVcnt == 0)
            {
                trimVcnt += 2;
                removedCnt--;
            }
            for(int i = removedCnt; i < vcnt - removedCnt; i++)
            {
                trimVsum += v[i];
            }

            return trimVsum / trimVcnt;
        }
    };
    Statistic mCreationStatistic;
    Window mWindow;
    Vector2 mWindowSize;
    Vector2 mSize;
    ViewTestType mTestType = ViewTestType.TEST_TYPE_COLOR;

    // To keep reference count.
    global::System.Collections.Generic.LinkedList<View> mCreatingControlList;
    global::System.Collections.Generic.LinkedList<View> mRemovingControlList;
    global::System.Collections.Generic.LinkedList<Timer> mTimerList;
    global::System.Collections.Generic.LinkedList<Animation> mCreatingAnimationList;
    global::System.Collections.Generic.LinkedList<Animation> mRemovingAnimationList;

    uint mColumnsCount = ROWS_COUNT;
    uint mRowsCount = COLUMNS_COUNT;
    uint mTotalColumnsCount = TOTAL_COLUMNS_COUNT;
    uint mDurationPerColumns = DURATION_PER_COLUMNS; // miliseconds
    
    uint mCreateCount = 0u;
    uint mDeleteCount = 0u;
    uint mImageCount  = 0u;

    DateTime appStartTime;
    DateTime appEndTime;

    PropertyMap basicBackroundProperties;
    PropertyMap basicCornerRadiusProperties;
    PropertyMap basicBorderlineProperties;
    PropertyMap blurVisualMap;

    private void PreparePropertyMap()
    {
        float requiredBorderlineWidth = Math.Min(mSize.X, mSize.Y) * VIEW_MARGIN_RATE;
        float requiredBlurRadius = Math.Min(mSize.X, mSize.Y) * VIEW_MARGIN_RATE * 0.5f;

        using var dummyView = new View();

        basicBackroundProperties = new PropertyMap().Append(dummyView.GetPropertyIndex("Background"), Color.Yellow);
        basicCornerRadiusProperties = new PropertyMap().Append(dummyView.GetPropertyIndex("CornerRadius"), 0.5f)
                                                       .Append(dummyView.GetPropertyIndex("CornerRadiusPolicy"), (int)VisualTransformPolicyType.Relative);
        basicBorderlineProperties = new PropertyMap().Append(dummyView.GetPropertyIndex("BorderlineWidth"), requiredBorderlineWidth)
                                                     .Append(dummyView.GetPropertyIndex("BorderlineColor"), Color.Red);

        blurVisualMap = new PropertyMap().Append((int)Visual.Property.Type, (int)Visual.Type.Color)
                                         .Append((int)ColorVisualProperty.MixColor, Color.Yellow)
                                         .Append((int)ColorVisualProperty.BlurRadius, requiredBlurRadius);
    }

    protected void CreateScene()
    {
        appStartTime = DateTime.Now;

        mCreatingControlList  = new global::System.Collections.Generic.LinkedList<View>();
        mRemovingControlList  = new global::System.Collections.Generic.LinkedList<View>();
        mTimerList = new global::System.Collections.Generic.LinkedList<Timer>();
        mCreatingAnimationList = new global::System.Collections.Generic.LinkedList<Animation>();
        mRemovingAnimationList = new global::System.Collections.Generic.LinkedList<Animation>();

        mWindow = Window.Default;
        mWindow.BackgroundColor = Color.White;
        mWindowSize = mWindow.WindowSize;

        mSize = new Vector2(mWindowSize.X / mColumnsCount, mWindowSize.Y / mRowsCount);

        Timer timer = new Timer(mDurationPerColumns);
        timer.Tick += OnTick;
        mTimerList.AddLast(timer);

        mDeleteCount = 0;

        mCreationStatistic = new Statistic();

        timer.Start();

        mWindow.KeyEvent += OnKeyEvent;
    }
    bool OnTick(object o, EventArgs e)
    {
        CreateColumnView();
        if(mCreateCount < mColumnsCount)
        {
            // Start next phase.
            Timer timer = new Timer(mDurationPerColumns);
            timer.Tick += OnTick;
            mTimerList.AddLast(timer);

            timer.Start();
        }
        return false;
    }
    void CreateColumnView()
    {
        DateTime startTime;
        DateTime endTime;

        startTime = DateTime.Now;

        View columnView = new View()
        {
            BackgroundColor = Color.Blue,
            SizeWidth = mSize.X,
            SizeHeight = mWindowSize.Y,
            PositionX = mSize.X * (mCreateCount % mColumnsCount),
            PositionY = -mWindowSize.Y,
        };

        for(int i = 0; i < mRowsCount; ++i)
        {
            View bgView;
            switch(mTestType)
            {
                case ViewTestType.TEST_TYPE_COLOR:
                default:
                {
                    bgView = CreateColor();
                    break;
                }
                case ViewTestType.TEST_TYPE_IMAGE:
                {
                    bgView = CreateImage();
                    break;
                }
                case ViewTestType.TEST_TYPE_TEXT:
                {
                    bgView = CreateTextLabel();
                    break;
                }
                case ViewTestType.TEST_TYPE_ROUNDED_COLOR:
                {
                    bgView = CreateRoundedColor();
                    break;
                }
                case ViewTestType.TEST_TYPE_BORDER_COLOR:
                {
                    bgView = CreateBorderColor();
                    break;
                }
                case ViewTestType.TEST_TYPE_ROUNDED_BORDER_COLOR:
                {
                    bgView = CreateRoundedBorderColor();
                    break;
                }
                case ViewTestType.TEST_TYPE_BLUR_COLOR:
                {
                    bgView = CreateBlurColor();
                    break;
                }
                case ViewTestType.TEST_TYPE_ROUNDED_BLUR_COLOR:
                {
                    bgView = CreateRoundedBlurColor();
                    break;
                }
            }
            bgView.SizeWidth = mSize.X * (1.0f - VIEW_MARGIN_RATE);
            bgView.SizeHeight = mSize.Y * (1.0f - VIEW_MARGIN_RATE);
            bgView.PositionX = mSize.X * VIEW_MARGIN_RATE * 0.5f;
            bgView.PositionY = (mSize.Y * VIEW_MARGIN_RATE * 0.5f) + (mSize.Y * (float)i);
            columnView.Add(bgView);
        }

        mWindow.Add(columnView);
        mCreatingControlList.AddLast(columnView);

        // Add appearing animation
        Animation appearingAnimation = new Animation((int)(DURATION_OF_ANIMATION));
        appearingAnimation.AnimateTo(columnView, "PositionY", 0.0f);
        appearingAnimation.Finished += OnAppearAnimationFinished;
        appearingAnimation.Play();

        mCreatingAnimationList.AddLast(appearingAnimation);

        endTime = DateTime.Now;

        mCreationStatistic.add((endTime - startTime).TotalMilliseconds);

        mCreateCount++;

        if(mCreateCount % mTotalColumnsCount == 0)
        {
            Tizen.Log.Error("NUI.PerfNew", $"Average of creation {mRowsCount} NUI({TestTypeString(mTestType)}) : {mCreationStatistic.getTrimedAverage()} ms\n");
            mCreationStatistic.clear();
            mTestType = (ViewTestType)(((int)(mTestType) + 1) % (int)(ViewTestType.TEST_TYPE_MAX));
        }
    }

    void OnKeyEvent(object source, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down)
        {
            FullGC();
            //Streamline.AnnotateChannelEnd(0);

            switch( e.Key.KeyPressedName )
            {
                case "Escape":
                case "Back":
                {
                    Deactivate();
                    Exit();
                }
                break;
            }
        }
    }

    void OnAppearAnimationFinished(object o, EventArgs e)
    {
        // We can assume that front of mControlList must be disappearing.
        var currentControl = mCreatingControlList.First.Value;
        mCreatingControlList.RemoveFirst();

        // Dereference timer safety
        if(mTimerList.Count > 0)
        {
            mTimerList.First.Value.Dispose();
            mTimerList.RemoveFirst();
        }

        // Dereference animation safety
        mCreatingAnimationList.First.Value.Dispose();
        mCreatingAnimationList.RemoveFirst();

        mRemovingControlList.AddLast(currentControl);

        if(mCreateCount < mTotalColumnsCount * (int)(ViewTestType.TEST_TYPE_MAX))
        {
            CreateColumnView();
        }

        // Add disappearing animation
        Animation disappearingAnimation = new Animation((int)(DURATION_OF_ANIMATION));
        disappearingAnimation.AnimateTo(currentControl, "PositionY", (float)mWindowSize.Y);
        disappearingAnimation.Finished += OnDisappearAnimationFinished;
        disappearingAnimation.Play();

        mRemovingAnimationList.AddLast(disappearingAnimation);
    }
    void OnDisappearAnimationFinished(object o, EventArgs e)
    {
        // We can assume that front of mControlList must be disappearing.
        var currentControl = mRemovingControlList.First.Value;
        mRemovingControlList.RemoveFirst();

        // We can assume that front of mViewList must be deleted.
        currentControl.Unparent();
        currentControl.DisposeRecursively();

        // Dereference animation safety
        mRemovingAnimationList.First.Value.Dispose();
        mRemovingAnimationList.RemoveFirst();

        mDeleteCount++;

        // If all views are deleted, quit this application. byebye~
        if(mDeleteCount == mTotalColumnsCount * (int)ViewTestType.TEST_TYPE_MAX)
        {
            appEndTime = DateTime.Now;
            Tizen.Log.Error("NUI.PerfNew", $"Duration of all app running time : {((appEndTime - appStartTime)).TotalMilliseconds} ms\n");
            Deactivate();
            FullGC();
            Exit();
        }
    }

    private View CreateColor()
    {
        View bgView = new View();
        bgView.SetProperties(basicBackroundProperties);
        return bgView;
    }
    private View CreateImage()
    {
        ImageView bgView = new ImageView()
        {
            ResourceUrl = IMAGE_PATH[(mImageCount++) % (IMAGE_PATH.Length)],
        };
        return bgView;
    }
    private View CreateTextLabel()
    {
        TextLabel bgView = new TextLabel()
        {
            Text = "Hello, World!",
        };
        return bgView;
    }
    private View CreateRoundedColor()
    {
        View bgView = new View();
        bgView.SetProperties(basicBackroundProperties);
        bgView.SetProperties(basicCornerRadiusProperties);
        return bgView;
    }

    private View CreateBorderColor()
    {
        View bgView = new View();
        bgView.SetProperties(basicBackroundProperties);
        bgView.SetProperties(basicBorderlineProperties);
        return bgView;
    }
    private View CreateRoundedBorderColor()
    {
        View bgView = new View();
        bgView.SetProperties(basicBackroundProperties);
        bgView.SetProperties(basicCornerRadiusProperties);
        bgView.SetProperties(basicBorderlineProperties);
        return bgView;
    }
    private View CreateBlurColor()
    {
        View bgView = new View()
        {
            Background = blurVisualMap,
        };

        return bgView;
    }
    private View CreateRoundedBlurColor()
    {
        View bgView = new View()
        {
            Background = blurVisualMap,
        };
        bgView.SetProperties(basicCornerRadiusProperties);
        return bgView;
    }

    public void Activate()
    {
        CreateScene();
        PreparePropertyMap();
    }
    public void FullGC()
    {
        global::System.GC.Collect();
        global::System.GC.WaitForPendingFinalizers();
        global::System.GC.Collect();
    }

    public void Deactivate()
    {
        DestroyScene();
    }

    private void CleanList<T>(ref global::System.Collections.Generic.LinkedList<T> list) where T : BaseHandle
    {
        while(list.Count > 0)
        {
            list.First.Value.Dispose();
            list.RemoveFirst();
        }
        list = null;
    }

    private void DestroyScene()
    {
        // Dereference safety
        CleanList(ref mCreatingControlList);
        CleanList(ref mRemovingControlList);
        CleanList(ref mTimerList);
        CleanList(ref mCreatingAnimationList);
        CleanList(ref mRemovingAnimationList);
    }

    protected override void OnCreate()
    {
        // Up call to the Base class first
        base.OnCreate();
        Activate();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        PerformanceTestExample example = new PerformanceTestExample();
        example.Run(args);
    }
}
