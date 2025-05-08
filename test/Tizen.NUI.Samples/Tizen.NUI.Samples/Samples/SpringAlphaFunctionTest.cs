
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using NUnit.Framework;

namespace Tizen.NUI.Samples
{
    public class SpringAlphaFunctionTest : IExample
    {
        private Window window;
        private TextLabel mGentle, mQuick, mBouncy, mSlow, mS100D10M1, mS4420D20_8M1, mS1000D10M10;
        private Animation animationGentle, animationQuick, animationBouncy, animationSlow, animationS100D10M1, animationS4420D20_8M1, animationS1000D10M10;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.SetBackgroundColor(Color.White);

            View pink = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                Size = new Size(250.0f, 1000.0f),
                PositionX = 250.0f,
                BackgroundColor = Color.Pink
            };
            window.Add(pink);

            const float positionDiff = 100.0f;
            float positionY = 0.0f;
            mGentle = new TextLabel("Gentle")
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                Name = "Gentle",
                PositionY = positionY,
            };
            window.Add(mGentle);
            positionY += positionDiff;

            mQuick = new TextLabel("Quick")
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                Name = "Quick",
                PositionY = positionY,
            };
            window.Add(mQuick);
            positionY += positionDiff;

            mBouncy = new TextLabel("Bouncy")
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                Name = "Bouncy",
                PositionY = positionY,
            };
            window.Add(mBouncy);
            positionY += positionDiff;

            mSlow = new TextLabel("Slow")
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                Name = "Slow",
                PositionY = positionY,
            };
            window.Add(mSlow);
            positionY += positionDiff;

            mS100D10M1 = new TextLabel("S100D10M1")
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                Name = "S100D10M1",
                PositionY = positionY,
            };
            window.Add(mS100D10M1);
            positionY += positionDiff;

            mS4420D20_8M1 = new TextLabel("S4420D20_8M1")
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                Name = "S4420D20_8M1",
                PositionY = positionY,
            };
            window.Add(mS4420D20_8M1);
            positionY += positionDiff;

            mS1000D10M10 = new TextLabel("S1000D10M10")
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                Name = "S1000D10M10",
                PositionY = positionY,
            };
            window.Add(mS1000D10M10);
            positionY += positionDiff;

            animationGentle = new Animation(1000);  // Set the longest duration.
            animationGentle.AnimateTo(mGentle, "PositionX", 500.0f, new AlphaFunction(AlphaFunctionSpringType.Gentle));
            animationGentle.Looping = true;
            animationGentle.Play();

            animationQuick = new Animation(1000);  // Set the longest duration.
            animationQuick.AnimateTo(mQuick, "PositionX", 500.0f, new AlphaFunction(AlphaFunctionSpringType.Quick));
            animationQuick.Looping = true;
            animationQuick.Play();

            animationBouncy = new Animation(1000);  // Set the longest duration.
            animationBouncy.AnimateTo(mBouncy, "PositionX", 500.0f, new AlphaFunction(AlphaFunctionSpringType.Bouncy));
            animationBouncy.Looping = true;
            animationBouncy.Play();

            animationSlow = new Animation(1000);  // Set the longest duration.
            animationSlow.AnimateTo(mSlow, "PositionX", 500.0f, new AlphaFunction(AlphaFunctionSpringType.Slow));
            animationSlow.Looping = true;
            animationSlow.Play();

            animationS100D10M1 = new Animation(new AlphaFunctionSpringData(100.0f, 10.0f, 1.0f).GetDuration());  // Set the longest duration.
            animationS100D10M1.AnimateTo(mS100D10M1, "PositionX", 500.0f, new AlphaFunction(new AlphaFunctionSpringData(100.0f, 10.0f, 1.0f)));
            animationS100D10M1.Looping = true;
            animationS100D10M1.Play();

            animationS4420D20_8M1 = new Animation(new AlphaFunctionSpringData(4420.0f, 20.8f, 1.0f).GetDuration());  // Set the longest duration.
            animationS4420D20_8M1.AnimateTo(mS4420D20_8M1, "PositionX", 500.0f, new AlphaFunction(new AlphaFunctionSpringData(4420.0f, 20.8f, 1.0f)));
            animationS4420D20_8M1.Looping = true;
            animationS4420D20_8M1.Play();

            animationS1000D10M10 = new Animation(new AlphaFunctionSpringData(1000.0f, 10.0f, 10.0f).GetDuration());  // Set the longest duration.
            animationS1000D10M10.AnimateTo(mS1000D10M10, "PositionX", 500.0f, new AlphaFunction(new AlphaFunctionSpringData(1000.0f, 10.0f, 10.0f)));
            animationS1000D10M10.Looping = true;
            animationS1000D10M10.Play();
        }

        public void Deactivate()
        {
        }
    }
}
