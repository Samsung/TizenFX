/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd.
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
    const uint ROWS_COUNT = 32;
    const uint COLUMNS_COUNT = 32;
    const uint TOTAL_COLUMNS_COUNT = 80;
    const uint DURATION_PER_COLUMNS = 50; // miliseconds
    const float VIEW_MARGIN_RATE = 0.1f;
    enum ViewTestType{
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
    readonly static string[] IMAGE_PATH = {
    IMAGE_DIR + "gallery-medium-1.jpg",
    IMAGE_DIR + "gallery-medium-2.jpg",
    IMAGE_DIR + "gallery-medium-3.jpg",
    IMAGE_DIR + "gallery-medium-4.jpg",
    IMAGE_DIR + "gallery-medium-5.jpg",
    IMAGE_DIR + "gallery-medium-6.jpg",
    IMAGE_DIR + "gallery-medium-7.jpg",
    IMAGE_DIR + "gallery-medium-8.jpg",
    IMAGE_DIR + "gallery-medium-9.jpg",
    IMAGE_DIR + "gallery-medium-10.jpg",
    IMAGE_DIR + "gallery-medium-11.jpg",
    IMAGE_DIR + "gallery-medium-12.jpg",
    IMAGE_DIR + "gallery-medium-13.jpg",
    IMAGE_DIR + "gallery-medium-14.jpg",
    IMAGE_DIR + "gallery-medium-15.jpg",
    IMAGE_DIR + "gallery-medium-16.jpg",
    IMAGE_DIR + "gallery-medium-17.jpg",
    IMAGE_DIR + "gallery-medium-18.jpg",
    IMAGE_DIR + "gallery-medium-19.jpg",
    IMAGE_DIR + "gallery-medium-20.jpg",
    IMAGE_DIR + "gallery-medium-21.jpg",
    IMAGE_DIR + "gallery-medium-22.jpg",
    IMAGE_DIR + "gallery-medium-23.jpg",
    IMAGE_DIR + "gallery-medium-24.jpg",
    IMAGE_DIR + "gallery-medium-25.jpg",
    IMAGE_DIR + "gallery-medium-26.jpg",
    IMAGE_DIR + "gallery-medium-27.jpg",
    IMAGE_DIR + "gallery-medium-28.jpg",
    IMAGE_DIR + "gallery-medium-29.jpg",
    IMAGE_DIR + "gallery-medium-30.jpg",
    IMAGE_DIR + "gallery-medium-31.jpg",
    IMAGE_DIR + "gallery-medium-32.jpg",
    IMAGE_DIR + "gallery-medium-33.jpg",
    IMAGE_DIR + "gallery-medium-34.jpg",
    IMAGE_DIR + "gallery-medium-35.jpg",
    IMAGE_DIR + "gallery-medium-36.jpg",
    IMAGE_DIR + "gallery-medium-37.jpg",
    IMAGE_DIR + "gallery-medium-38.jpg",
    IMAGE_DIR + "gallery-medium-39.jpg",
    IMAGE_DIR + "gallery-medium-40.jpg",
    IMAGE_DIR + "gallery-medium-41.jpg",
    IMAGE_DIR + "gallery-medium-42.jpg",
    IMAGE_DIR + "gallery-medium-43.jpg",
    IMAGE_DIR + "gallery-medium-44.jpg",
    IMAGE_DIR + "gallery-medium-45.jpg",
    IMAGE_DIR + "gallery-medium-46.jpg",
    IMAGE_DIR + "gallery-medium-47.jpg",
    IMAGE_DIR + "gallery-medium-48.jpg",
    IMAGE_DIR + "gallery-medium-49.jpg",
    IMAGE_DIR + "gallery-medium-50.jpg",
    IMAGE_DIR + "gallery-medium-51.jpg",
    IMAGE_DIR + "gallery-medium-52.jpg",
    IMAGE_DIR + "gallery-medium-53.jpg",
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
            int removedCnt = (int)(vcnt * trimRate * 0.5);
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
    global::System.Collections.Generic.LinkedList<View> mViewList;
    global::System.Collections.Generic.LinkedList<Timer> mTimerList;
    global::System.Collections.Generic.LinkedList<Animation> mAnimationList;

    uint mColumnsCount = ROWS_COUNT;
    uint mRowsCount = COLUMNS_COUNT;
    uint mTotalColumnsCount = TOTAL_COLUMNS_COUNT;
    uint mDurationPerColumns = DURATION_PER_COLUMNS; // miliseconds

    uint tickCount;
    uint deleteCount;

    DateTime appStartTime;
    DateTime appEndTime;
    protected void CreateScene()
    {
        appStartTime = DateTime.Now;

        mViewList  = new global::System.Collections.Generic.LinkedList<View>();
        mTimerList = new global::System.Collections.Generic.LinkedList<Timer>();
        mAnimationList = new global::System.Collections.Generic.LinkedList<Animation>();

        mWindow = Window.Instance;
        mWindow.BackgroundColor = Color.White;
        mWindowSize = mWindow.WindowSize;

        mSize = new Vector2(mWindowSize.X / mColumnsCount, mWindowSize.Y / mRowsCount);

        Timer timer = new Timer(mDurationPerColumns);
        timer.Tick += OnTick;
        mTimerList.AddLast(timer);

        tickCount = 0;
        deleteCount = 0;

        mCreationStatistic = new Statistic();

        timer.Start();

        mWindow.KeyEvent += OnKeyEvent;
    }
    bool OnTick(object o, EventArgs e)
    {
        tickCount++;
        if(tickCount < mTotalColumnsCount * (int)ViewTestType.TEST_TYPE_MAX)
        {
            // Start next phase.
            Timer timer = new Timer(mDurationPerColumns);
            timer.Tick += OnTick;
            mTimerList.AddLast(timer);

            timer.Start();
        }
        DateTime startTime;
        DateTime endTime;

        startTime = DateTime.Now;

        View columnView = new View()
        {
            BackgroundColor = Color.Blue,
            Size = new Size(mSize.X, mWindowSize.Y),
            Position = new Position(mWindowSize.X, 0.0f),
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
                    bgView = CreateBorderColor(Math.Min(mSize.X, mSize.Y) * VIEW_MARGIN_RATE);
                    break;
                }
                case ViewTestType.TEST_TYPE_ROUNDED_BORDER_COLOR:
                {
                    bgView = CreateRoundedBorderColor(Math.Min(mSize.X, mSize.Y) * VIEW_MARGIN_RATE);
                    break;
                }
                case ViewTestType.TEST_TYPE_BLUR_COLOR:
                {
                    bgView = CreateBlurColor(Math.Min(mSize.X, mSize.Y) * VIEW_MARGIN_RATE * 0.5f);
                    break;
                }
                case ViewTestType.TEST_TYPE_ROUNDED_BLUR_COLOR:
                {
                    bgView = CreateRoundedBlurColor(Math.Min(mSize.X, mSize.Y) * VIEW_MARGIN_RATE * 0.5f);
                    break;
                }
            }
            bgView.Size = new Size(mSize.X * (1.0f - VIEW_MARGIN_RATE), mSize.Y * (1.0f - VIEW_MARGIN_RATE));
            bgView.Position = new Position(mSize.X * VIEW_MARGIN_RATE * 0.5f, (mSize.Y * VIEW_MARGIN_RATE * 0.5f) + (mSize.Y * (float)i));
            columnView.Add(bgView);
        }

        mWindow.Add(columnView);
        mViewList.AddLast(columnView);

        // Add move animation
        Animation animation = new Animation((int)(mDurationPerColumns * (mColumnsCount + 1)));
        animation.AnimateTo(columnView, "PositionX", -mSize.X);
        animation.Finished += OnAnimationFinished;
        animation.Play();

        mAnimationList.AddLast(animation);

        endTime = DateTime.Now;

        mCreationStatistic.add((endTime - startTime).TotalMilliseconds);

        if(tickCount % mTotalColumnsCount == 0)
        {
            Tizen.Log.Error("NUI.PerfNew", $"Average of creation {mRowsCount} NUI({TestTypeString(mTestType)}) : {mCreationStatistic.getTrimedAverage()} ms\n");
            mCreationStatistic.clear();
            mTestType = (ViewTestType)(((int)(mTestType) + 1) % (int)(ViewTestType.TEST_TYPE_MAX));
        }

        return false;
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

    void OnAnimationFinished(object o, EventArgs e)
    {
        // We can assume that front of mViewLIst must be deleted.
        mViewList.First.Value.Unparent();
        mViewList.First.Value.Dispose();
        mViewList.RemoveFirst();

        // Dereference timer safety
        mTimerList.First.Value.Dispose();
        mTimerList.RemoveFirst();

        // Dereference animation safety
        mAnimationList.RemoveFirst();

        deleteCount++;

        Animation me = o as Animation;
        me.Dispose();

        // If all views are deleted, quit this application. byebye~
        if(deleteCount == mTotalColumnsCount * (int)ViewTestType.TEST_TYPE_MAX)
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
        View bgView = new View(){
            BackgroundColor = Color.Yellow,
        };
        return bgView;
    }
    private int gImageCount = 0;
    private View CreateImage()
    {
        ImageView bgView = new ImageView(){
            BackgroundColor = Color.Yellow,
            ResourceUrl = IMAGE_PATH[(gImageCount++) % (IMAGE_PATH.Length)],
        };
        return bgView;
    }
    private View CreateTextLabel()
    {
        TextLabel bgView = new TextLabel(){
            Text = "Hello, World!",
        };
        return bgView;
    }
    private View CreateRoundedColor()
    {
        View bgView = new View(){
            BackgroundColor = Color.Yellow,
            CornerRadius = 0.5f,
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        return bgView;
    }

    private View CreateBorderColor(float requiredBorderlineWidth)
    {
        View bgView = new View(){
            BackgroundColor = Color.Yellow,
            BorderlineColor = Color.Red,
            BorderlineWidth = requiredBorderlineWidth,
        };
        return bgView;
    }
    private View CreateRoundedBorderColor(float requiredBorderlineWidth)
    {
        View bgView = new View(){
            BackgroundColor = Color.Yellow,
            CornerRadius = 0.5f,
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,
            BorderlineColor = Color.Red,
            BorderlineWidth = requiredBorderlineWidth,
        };
        return bgView;
    }
    private View CreateBlurColor(float requiredBlurRadius)
    {
        View bgView = new View();

        using(PropertyMap map = new PropertyMap())
        {
            map.Insert((int)Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
            map.Insert((int)ColorVisualProperty.MixColor, new PropertyValue(Color.Yellow));
            map.Insert((int)ColorVisualProperty.BlurRadius, new PropertyValue(requiredBlurRadius));

            bgView.Background = map;
        }

        return bgView;
    }
    private View CreateRoundedBlurColor(float requiredBlurRadius)
    {
        View bgView = new View();

        using(PropertyMap map = new PropertyMap())
        {
            map.Insert((int)Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
            map.Insert((int)ColorVisualProperty.MixColor, new PropertyValue(Color.Yellow));
            map.Insert((int)ColorVisualProperty.BlurRadius, new PropertyValue(requiredBlurRadius));
            map.Insert((int)Visual.Property.CornerRadius, new PropertyValue(0.5f));
            map.Insert((int)Visual.Property.CornerRadiusPolicy, new PropertyValue((int)VisualTransformPolicyType.Relative));

            bgView.Background = map;
        }

        return bgView;
    }

    public void Activate()
    {
        CreateScene();
    }
    public void FullGC(){
        global::System.GC.Collect();
        global::System.GC.WaitForPendingFinalizers();
        global::System.GC.Collect();
    }

    public void Deactivate()
    {
        DestroyScene();
    }
    private void DestroyScene()
    {
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
