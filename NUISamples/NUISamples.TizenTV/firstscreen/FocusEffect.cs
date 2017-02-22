using Tizen.NUI;
using Tizen.NUI.Constants;
using System;
using System.Collections.Generic;

namespace FirstScreen
{
    public class FocusEffect : IFocusEffect
    {
        private float _frameThickness;
        private FocusData[] _focusData; // Each FocusData is used for one key frame animation (total 6 key frame animations needed for EddenEffect)
        private Animation _animation;   // Animation used to apply all six key frame animations

        public FocusEffect()
        {
            _frameThickness = 10.0f;
            float _bottomFrameTime = 0.6f; // complete the halo/bottom animation 60% of the way through
            float _sideFrameTime = 0.8f;   // Start the side frame  animation after the bottom animation and complete at 80% of the way through
            float _topFrameTime = 1.0f;    // start the top frame animation after the side frame animation and complete at 100% way through

            // Six key frame animations (FocusData objects) needed for EddenEffect
            // Two key frame animations for top horizontal effect
            // Two key frame animations for bottom horizontal effect
            // Two key frame animations for vertical horizontal effect
            _focusData = new FocusData[6];

            FocusData focusData = new FocusData("halo", "halo.png", FocusData.Direction.Horizontal, ParentOrigin.TopCenter,
                                                new Size(50.0f, 20.0f, 0.0f), new Size(0.0f, 100.0f, 0.0f), 0.0f, _bottomFrameTime);
            _focusData[0] = focusData;

            focusData = new FocusData("bottom", "horizontalFrame.png", FocusData.Direction.Horizontal, ParentOrigin.TopCenter,
                                      new Size(0.0f, 0.0f, 0.0f), new Size(0.0f, _frameThickness, 0.0f), 0.0f, _bottomFrameTime);
            _focusData[1] = focusData;

            focusData = new FocusData("left", "verticalFrame.png", FocusData.Direction.Vertical, ParentOrigin.BottomLeft,
                                      new Size(0.0f, 0.0f, 0.0f), new Size(_frameThickness, 0.0f, 0.0f), _bottomFrameTime, _sideFrameTime);
            _focusData[2] = focusData;

            focusData = new FocusData("right", "verticalFrame.png", FocusData.Direction.Vertical, ParentOrigin.BottomRight,
                                      new Size(0.0f, 0.0f, 0.0f), new Size(_frameThickness, 0.0f, 0.0f), _bottomFrameTime, _sideFrameTime);
            _focusData[3] = focusData;

            focusData = new FocusData("top-left", "horizontalFrame.png", FocusData.Direction.Horizontal, ParentOrigin.BottomLeft,
                                      new Size(0.0f, 0.0f, 0.0f), new Size(0.0f, _frameThickness, 0.0f), _sideFrameTime, _topFrameTime);
            _focusData[4] = focusData;

            focusData = new FocusData("top-right", "horizontalFrame.png", FocusData.Direction.Horizontal, ParentOrigin.BottomRight,
                                      new Size(0.0f, 0.0f, 0.0f), new Size(0.0f, _frameThickness, 0.0f), _sideFrameTime, _topFrameTime);
            _focusData[5] = focusData;
        }

        public void FocusAnimation(View parentItem, Size itemSize, int duration, FocusEffectDirection direction)
        {
            var itemWidth = itemSize.Width + _frameThickness / 2;
            var itemHeight = itemSize.Height + _frameThickness / 3;

            if (_animation)
            {
                _animation.Clear();
                _animation.Reset();
            }

            _animation = new Animation(duration);
            _animation.Duration = duration;

            if (direction == FocusEffectDirection.BottomToTop)
            {
                _focusData[0].ParentOrigin = ParentOrigin.BottomCenter;
                _focusData[1].ParentOrigin = ParentOrigin.BottomCenter;
                _focusData[2].ParentOrigin = ParentOrigin.BottomLeft;
                _focusData[3].ParentOrigin = ParentOrigin.BottomRight;
                _focusData[4].ParentOrigin = ParentOrigin.TopLeft;
                _focusData[5].ParentOrigin = ParentOrigin.TopRight;
            }
            else
            {
                _focusData[0].ParentOrigin = ParentOrigin.TopCenter;
                _focusData[1].ParentOrigin = ParentOrigin.TopCenter;
                _focusData[2].ParentOrigin = ParentOrigin.BottomLeft;
                _focusData[3].ParentOrigin = ParentOrigin.BottomRight;
                _focusData[4].ParentOrigin = ParentOrigin.BottomLeft;
                _focusData[5].ParentOrigin = ParentOrigin.BottomRight;
            }

            foreach (FocusData focusData in _focusData)
            {
                var currentParent = focusData.ImageItem.Parent;

                // first parent the controls
                if (parentItem != currentParent)
                {
                    parentItem.Add(focusData.ImageItem);
                }

                focusData.ImageItem.Size = new Size(100.0f, 100.0f, 0.0f);
                parentItem.Add(focusData.ImageItem);

                Size targetSize = focusData.TargetSize;
                Size initSize = focusData.InitSize;

                if (focusData.FocusDirection == FocusData.Direction.Horizontal)
                {
                    // adjust the width to match the parent
                    targetSize.Width = itemWidth;
                }
                else // vertical frame
                {
                    // adjust the height to match the parent
                    targetSize.Height = itemHeight;
                }

                // half the size for the top frame as we come out from both left / right sides
                if (focusData.Name == "top-right" || focusData.Name == "top-left")
                {
                    targetSize.Width = itemWidth - _frameThickness;
                }

                KeyFrames keyFrames = new KeyFrames();

                keyFrames.Add(0.0f, initSize);
                keyFrames.Add(focusData.KeyFrameStart, initSize);
                keyFrames.Add(focusData.KeyFrameEnd, targetSize);

                // for halo add an extra keyframe to shrink it ( in 20% of time after it has finished)
                if (focusData.Name == "halo")
                {
                    keyFrames.Add(focusData.KeyFrameEnd + 0.2f, initSize);
                }

                _animation.AnimateBetween(focusData.ImageItem, "Size", keyFrames, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine));

                // Simulate the vertical frame growing from the top.
                // Vertical items are anchored to the bottom of the parent... so when they grow
                // we need to move them to the middle of the parent ( otherwise they stick out the bottom)
                if (focusData.FocusDirection == FocusData.Direction.Vertical)
                {
                    //animate position as well so it looks like animation is coming from bottom
                    KeyFrames keyFramesV = new KeyFrames();

                    if (direction == FocusEffectDirection.BottomToTop)
                    {
                        keyFramesV.Add(0.0f, 0.0f);
                        keyFramesV.Add(focusData.KeyFrameStart, 0.0f);
                    }
                    else
                    {
                        keyFramesV.Add(0.0f, -itemHeight);
                        keyFramesV.Add(focusData.KeyFrameStart, -itemHeight);
                    }

                    keyFramesV.Add(focusData.KeyFrameEnd, (-itemHeight / 2)); // animate to halfway up the control


                    _animation.AnimateBetween(focusData.ImageItem, "PositionY", keyFramesV, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine));


                }

                // Simulate the top frame growing from the sides.
                if (focusData.Name == "top-left")
                {
                    KeyFrames keyFramesTL = new KeyFrames();

                    keyFramesTL.Add(0.0f, 0.0f);
                    keyFramesTL.Add(focusData.KeyFrameStart, 0.0f);
                    keyFramesTL.Add(focusData.KeyFrameEnd, (itemWidth / 2)); // animate to halfway up the control

                    // grow these from the left or right
                    _animation.AnimateBetween(focusData.ImageItem, "PositionX", keyFramesTL, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine));


                }

                if (focusData.Name == "top-right")
                {
                    KeyFrames keyFramesTR = new KeyFrames();

                    keyFramesTR.Add(0.0f, 0.0f);
                    keyFramesTR.Add(focusData.KeyFrameStart, 0.0f);
                    keyFramesTR.Add(focusData.KeyFrameEnd, (-itemWidth / 2)); // animate to halfway up the control

                    // grow these from the left or right
                    _animation.AnimateBetween(focusData.ImageItem, "PositionX", keyFramesTR, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine));

                }

                _animation.Finished += OnAnimationFinished;

                _animation.Play();
            }
        }

        private void OnAnimationFinished(object source, EventArgs e)
        {
            foreach (FocusData focusData in _focusData)
            {
                var currentParent = focusData.ImageItem.Parent;

                if (currentParent)
                {
                    currentParent.Remove(focusData.ImageItem);
                }
            }
        }
    }
}
