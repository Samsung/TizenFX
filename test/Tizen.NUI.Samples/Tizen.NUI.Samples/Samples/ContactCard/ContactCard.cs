using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class ContactCard
    {
        private TapGestureDetector mTapDetector;
        private View mContactCard;
        private View mHeader;
        private View mClippedImage;
        private View mMaskedImage;
        private TextLabel mNameText;
        private TextLabel mDetailText;

        private Animation mAnimation;
        private ContactCardLayoutInfo mContactCardLayoutInfo;
        private Vector2 foldedPosition;
        private int mClippedImagePropertyIndex;
        private bool mFolded;


        private readonly TimePeriod TIME_PERIOD_UNFOLD_X = new TimePeriod(0, 360); ///< Start at 0ms, duration 360ms
        private readonly TimePeriod TIME_PERIOD_UNFOLD_Y = new TimePeriod(40, 360); ///< Start at 40ms, duration 360ms
        private readonly TimePeriod TIME_PERIOD_UNFOLD_WIDTH = new TimePeriod(0, 360); ///< Start at 0ms, duration 360ms
        private readonly TimePeriod TIME_PERIOD_UNFOLD_HEIGHT = new TimePeriod(40, 360); ///< Start at 40ms, duration 360ms
        private readonly TimePeriod TIME_PERIOD_UNFOLD_NAME_OPACITY = new TimePeriod(0, 80); ///< Start at 0ms, duration 80ms
        private readonly TimePeriod TIME_PERIOD_UNFOLD_DETAIL_OPACITY = new TimePeriod( 80, 80 ); ///< Start at 80ms, duration 80ms
        private readonly TimePeriod TIME_PERIOD_UNFOLD_SIBLING_OPACITY = new TimePeriod( 0, 80 ); ///< Start at 0ms, duration 80ms
        private readonly TimePeriod TIME_PERIOD_UNFOLD_MESH_MORPH = new TimePeriod( 0, 400 ); ///< Start at 0ms, duration 400ms

        private readonly TimePeriod TIME_PERIOD_FOLD_X = new TimePeriod( 64, 336 ); ///< Start at 64ms, duration 336ms
        private readonly TimePeriod TIME_PERIOD_FOLD_Y = new TimePeriod( 0, 336 ); ///< Start at 0ms, duration 336ms
        private readonly TimePeriod TIME_PERIOD_FOLD_WIDTH = new TimePeriod( 64, 336 ); ///< Start at 64ms, duration 336ms
        private readonly TimePeriod TIME_PERIOD_FOLD_HEIGHT = new TimePeriod( 0, 336 ); ///< Start at 0ms, duration 336ms
        private readonly TimePeriod TIME_PERIOD_FOLD_NAME_OPACITY = new TimePeriod( 80, 80 ); ///< Start at 80ms, duration 80ms
        private readonly TimePeriod TIME_PERIOD_FOLD_DETAIL_OPACITY = new TimePeriod( 0, 80 ); ///< Start at 0ms, duration 80ms
        private readonly TimePeriod TIME_PERIOD_FOLD_SIBLING_OPACITY = new TimePeriod( 320, 80 ); ///< Start at 320ms, duration 80ms
        private readonly TimePeriod TIME_PERIOD_FOLD_MESH_MORPH = new TimePeriod( 0, 400 ); ///< Start at 0ms, duration 400ms

        private AlphaFunction.BuiltinFunctions ALPHA_FUNCTION_UNFOLD = AlphaFunction.BuiltinFunctions.Default;
        private AlphaFunction.BuiltinFunctions ALPHA_FUNCTION_FOLD = AlphaFunction.BuiltinFunctions.EaseInOut;

        private readonly Color HEADER_COLOR = new Color( 231.0f / 255.0f, 231.0f / 255.0f, 231.0f / 255.0f, 1.0f );


        public ContactCard(ContactCardLayoutInfo contactCardLayoutInfo, string contactName, string contactAddress, string imagePath, Vector2 position, View rootView)
        {
            mContactCardLayoutInfo = contactCardLayoutInfo;
            foldedPosition = new Vector2(position.X, position.Y);
            mClippedImagePropertyIndex = -1;
            mFolded = true;

            //NUIApplication.GetDefaultWindow().KeyEvent += OnKeyEvent;

            // Create a View which will be used for the background and to clip the contents
            mContactCard = new View();
            mContactCard.BackgroundColor = Color.White;
            mContactCard.ClippingMode = ClippingModeType.ClipChildren;
            mContactCard.ParentOrigin = ParentOrigin.TopLeft;
            mContactCard.PivotPoint = PivotPoint.TopLeft;
            mContactCard.PositionUsesPivotPoint = true;
            mContactCard.Position2D = new Position2D((int)foldedPosition.X, (int)foldedPosition.Y);
            mContactCard.Size2D = new Size2D((int)mContactCardLayoutInfo.foldedSize.Width, (int)mContactCardLayoutInfo.foldedSize.Height);
            mContactCard.KeyEvent += OnKeyEvent;

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(mContactCard);
            rootView.Add(mContactCard);

            // Create the header which will be shown only when the contact is unfolded
            mHeader = new View();
            mHeader.Size2D = new Size2D((int)mContactCardLayoutInfo.headerSize.Width, (int)mContactCardLayoutInfo.headerSize.Height);
            mHeader.BackgroundColor = HEADER_COLOR;
            mHeader.ParentOrigin = ParentOrigin.TopLeft;
            mHeader.PivotPoint = PivotPoint.TopLeft;
            mHeader.PositionUsesPivotPoint = true;
            mHeader.Position2D = new Position2D((int)mContactCardLayoutInfo.headerFoldedPosition.X, (int)mContactCardLayoutInfo.headerFoldedPosition.Y);

            // Create a clipped image (whose clipping can be animated)
            mClippedImage = ClippedImage.Create(imagePath);
            mClippedImage.Size2D = new Size2D((int)mContactCardLayoutInfo.imageSize.Width, (int)mContactCardLayoutInfo.imageSize.Height);
            mClippedImage.ParentOrigin = ParentOrigin.TopLeft;
            mClippedImage.PivotPoint = PivotPoint.TopLeft;
            mClippedImage.PositionUsesPivotPoint = true;
            mClippedImage.Position2D = new Position2D((int)mContactCardLayoutInfo.imageFoldedPosition.X, (int)mContactCardLayoutInfo.imageFoldedPosition.Y);
            mClippedImage.Hide();
            mContactCard.Add(mClippedImage);

            // Create an image with a mask which is to be used when the contact is folded
            mMaskedImage = MaskedImage.Create(imagePath);
            mMaskedImage.Size2D = new Size2D((int)mContactCardLayoutInfo.imageSize.Width, (int)mContactCardLayoutInfo.imageSize.Height);
            mMaskedImage.ParentOrigin = ParentOrigin.TopLeft;
            mMaskedImage.PivotPoint = PivotPoint.TopLeft;
            mMaskedImage.PositionUsesPivotPoint = true;
            mMaskedImage.Position2D = new Position2D((int)mContactCardLayoutInfo.imageFoldedPosition.X, (int)mContactCardLayoutInfo.imageFoldedPosition.Y);
            mContactCard.Add(mMaskedImage);

            // Add the text label for just the name
            mNameText = new TextLabel(contactName);
            //mNameText.StyleName = "ContactNameTextLabel";
            mNameText.TextColor = new Color(0, 0, 0, 1);
            mNameText.HorizontalAlignment = HorizontalAlignment.Center;
            mNameText.PointSize = 14;
            mNameText.ParentOrigin = ParentOrigin.TopLeft;
            mNameText.PivotPoint = PivotPoint.TopLeft;
            mNameText.PositionUsesPivotPoint = true;
            mNameText.WidthResizePolicy = ResizePolicyType.FillToParent;
            mNameText.Position2D = new Position2D((int)mContactCardLayoutInfo.textFoldedPosition.X, (int)mContactCardLayoutInfo.textFoldedPosition.Y);
            mContactCard.Add(mNameText);

            // Create the detail text-label
            string detailString = contactName;
            detailString += "\n\n";
            detailString += contactAddress;

            mDetailText = new TextLabel(detailString);
            //mDetailText.StyleName = "ContactDetailTextLabel";
            mDetailText.TextColor = new Color(0, 0, 0, 1);
            mDetailText.MultiLine = true;
            mDetailText.PointSize = 20;
            mDetailText.ParentOrigin = ParentOrigin.TopLeft;
            mDetailText.PivotPoint = PivotPoint.TopLeft;
            mDetailText.PositionUsesPivotPoint = true;
            mDetailText.Position2D = new Position2D((int)mContactCardLayoutInfo.textFoldedPosition.X, (int)mContactCardLayoutInfo.textFoldedPosition.Y);
            mDetailText.Size2D = new Size2D((int)(mContactCardLayoutInfo.unfoldedSize.Width - mContactCardLayoutInfo.textFoldedPosition.X * 2.0f), 0);
            mDetailText.Opacity = 0.0f;

            // Attach tap detection to the overall clip control
            mTapDetector = new TapGestureDetector();
            mTapDetector.Attach(mContactCard);
            mTapDetector.Detected += OnTap;
        }

        private void Animate()
        {
            FocusManager focusManager = FocusManager.Instance;
            mAnimation = new Animation(0);

            if(mFolded)
            {
                mContactCard.Focusable = true;
                focusManager.SetCurrentFocusView(mContactCard);

                mContactCard.Add(mHeader);
                mContactCard.Add(mDetailText);

                // Show clipped-image to animate geometry and hide the masked-image
                mClippedImage.Show();
                mMaskedImage.Hide();

                // Animate the size of the control (and clipping area)
                mAnimation.AnimateTo(mContactCard, "PositionX", mContactCardLayoutInfo.unfoldedPosition.X, TIME_PERIOD_UNFOLD_X.start, TIME_PERIOD_UNFOLD_X.start + TIME_PERIOD_UNFOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mContactCard, "PositionY", mContactCardLayoutInfo.unfoldedPosition.Y, TIME_PERIOD_UNFOLD_Y.start, TIME_PERIOD_UNFOLD_Y.start + TIME_PERIOD_UNFOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mContactCard, "SizeWidth", mContactCardLayoutInfo.unfoldedSize.Width, TIME_PERIOD_UNFOLD_WIDTH.start, TIME_PERIOD_UNFOLD_WIDTH.start + TIME_PERIOD_UNFOLD_WIDTH.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mContactCard, "SizeHeight", mContactCardLayoutInfo.unfoldedSize.Height, TIME_PERIOD_UNFOLD_HEIGHT.start, TIME_PERIOD_UNFOLD_HEIGHT.start + TIME_PERIOD_UNFOLD_HEIGHT.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));

                // Animate the header area into position
                mAnimation.AnimateTo(mHeader, "PositionX", mContactCardLayoutInfo.headerUnfoldedPosition.X, TIME_PERIOD_UNFOLD_X.start, TIME_PERIOD_UNFOLD_X.start + TIME_PERIOD_UNFOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mHeader, "PositionY", mContactCardLayoutInfo.headerUnfoldedPosition.Y, TIME_PERIOD_UNFOLD_Y.start, TIME_PERIOD_UNFOLD_Y.start + TIME_PERIOD_UNFOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));

                // Animate the clipped image into the unfolded position and into a quad
                mAnimation.AnimateTo(mClippedImage, "PositionX", mContactCardLayoutInfo.imageUnfoldedPosition.X, TIME_PERIOD_UNFOLD_X.start, TIME_PERIOD_UNFOLD_X.start + TIME_PERIOD_UNFOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mClippedImage, "PositionY", mContactCardLayoutInfo.imageUnfoldedPosition.Y, TIME_PERIOD_UNFOLD_Y.start, TIME_PERIOD_UNFOLD_Y.start + TIME_PERIOD_UNFOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mClippedImage, "uDelta", ClippedImage.QUAD_GEOMETRY, TIME_PERIOD_UNFOLD_MESH_MORPH.start , TIME_PERIOD_UNFOLD_MESH_MORPH.start + TIME_PERIOD_UNFOLD_MESH_MORPH.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));

                // Fade out the opacity of the name, and animate into the unfolded position
                mAnimation.AnimateTo(mNameText, "ColorAlpha", 0.0f, TIME_PERIOD_UNFOLD_NAME_OPACITY.start, TIME_PERIOD_UNFOLD_NAME_OPACITY.start + TIME_PERIOD_UNFOLD_NAME_OPACITY.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mNameText, "PositionX", mContactCardLayoutInfo.textUnfoldedPosition.X, TIME_PERIOD_UNFOLD_X.start, TIME_PERIOD_UNFOLD_X.start + TIME_PERIOD_UNFOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mNameText, "PositionY", mContactCardLayoutInfo.textUnfoldedPosition.Y, TIME_PERIOD_UNFOLD_Y.start, TIME_PERIOD_UNFOLD_Y.start + TIME_PERIOD_UNFOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));

                // Fade in the opacity of the detail, and animate into the unfolded position
                mAnimation.AnimateTo(mDetailText, "ColorAlpha", 1.0f, TIME_PERIOD_UNFOLD_NAME_OPACITY.start, TIME_PERIOD_UNFOLD_NAME_OPACITY.start + TIME_PERIOD_UNFOLD_NAME_OPACITY.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mDetailText, "PositionX", mContactCardLayoutInfo.textUnfoldedPosition.X, TIME_PERIOD_UNFOLD_X.start, TIME_PERIOD_UNFOLD_X.start + TIME_PERIOD_UNFOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                mAnimation.AnimateTo(mDetailText, "PositionY", mContactCardLayoutInfo.textUnfoldedPosition.Y, TIME_PERIOD_UNFOLD_Y.start, TIME_PERIOD_UNFOLD_Y.start + TIME_PERIOD_UNFOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));

                // Fade out all the siblings
                View parent = mContactCard.GetParent() as View;
                for (uint i = 0; i < parent.GetChildCount(); ++i)
                {
                    View sibling = parent.GetChildAt(i);
                    if (sibling != mContactCard)
                    {
                        mAnimation.AnimateTo(sibling, "ColorAlpha", 0.0f, TIME_PERIOD_UNFOLD_SIBLING_OPACITY.start, TIME_PERIOD_UNFOLD_SIBLING_OPACITY.start + TIME_PERIOD_UNFOLD_SIBLING_OPACITY.duration, new AlphaFunction(ALPHA_FUNCTION_UNFOLD));
                        sibling.Sensitive = false;
                    }
                }

                mAnimation.Finished += OnAnimationFinished;
                mAnimation.Play();
            }
            else
            {
                // Remove key-input-focus from our contact-card when we are folded
                FocusManager.Instance.ClearFocus();

                mContactCard.Add(mNameText);

                // Animate the size of the control (and clipping area)
                mAnimation.AnimateTo(mContactCard, "PositionX", foldedPosition.X, TIME_PERIOD_FOLD_X.start, TIME_PERIOD_FOLD_X.start + TIME_PERIOD_FOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mContactCard, "PositionY", foldedPosition.Y, TIME_PERIOD_FOLD_Y.start, TIME_PERIOD_FOLD_Y.start + TIME_PERIOD_FOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mContactCard, "SizeWidth", mContactCardLayoutInfo.foldedSize.Width, TIME_PERIOD_FOLD_WIDTH.start, TIME_PERIOD_FOLD_WIDTH.start + TIME_PERIOD_FOLD_WIDTH.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mContactCard, "SizeHeight", mContactCardLayoutInfo.foldedSize.Height, TIME_PERIOD_FOLD_HEIGHT.start, TIME_PERIOD_FOLD_HEIGHT.start + TIME_PERIOD_FOLD_HEIGHT.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));

                // Animate the header area out of position
                mAnimation.AnimateTo(mHeader, "PositionX", mContactCardLayoutInfo.headerFoldedPosition.X, TIME_PERIOD_FOLD_X.start, TIME_PERIOD_FOLD_X.start + TIME_PERIOD_FOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mHeader, "PositionY", mContactCardLayoutInfo.headerFoldedPosition.Y, TIME_PERIOD_FOLD_Y.start, TIME_PERIOD_FOLD_Y.start + TIME_PERIOD_FOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));

                // Animate the clipped image into the folded position and into a circle
                mAnimation.AnimateTo(mClippedImage, "PositionX", mContactCardLayoutInfo.imageFoldedPosition.X, TIME_PERIOD_FOLD_X.start, TIME_PERIOD_FOLD_X.start + TIME_PERIOD_FOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mClippedImage, "PositionY", mContactCardLayoutInfo.imageFoldedPosition.Y, TIME_PERIOD_FOLD_Y.start, TIME_PERIOD_FOLD_Y.start + TIME_PERIOD_FOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mClippedImage, "uDelta", 0.0f, TIME_PERIOD_FOLD_MESH_MORPH.start, TIME_PERIOD_FOLD_MESH_MORPH.start + TIME_PERIOD_FOLD_MESH_MORPH.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));

                // Fade in the opacity of the name, and animate into the folded position
                mAnimation.AnimateTo(mNameText, "ColorAlpha", 1.0f, TIME_PERIOD_FOLD_NAME_OPACITY.start, TIME_PERIOD_FOLD_NAME_OPACITY.start + TIME_PERIOD_FOLD_NAME_OPACITY.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mNameText, "PositionX", mContactCardLayoutInfo.textFoldedPosition.X, TIME_PERIOD_FOLD_X.start, TIME_PERIOD_FOLD_X.start + TIME_PERIOD_FOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mNameText, "PositionY", mContactCardLayoutInfo.textFoldedPosition.Y, TIME_PERIOD_FOLD_Y.start, TIME_PERIOD_FOLD_Y.start + TIME_PERIOD_FOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));

                // Fade out the opacity of the detail, and animate into the folded position
                mAnimation.AnimateTo(mDetailText, "ColorAlpha", 0.0f, TIME_PERIOD_FOLD_DETAIL_OPACITY.start, TIME_PERIOD_FOLD_DETAIL_OPACITY.start + TIME_PERIOD_FOLD_DETAIL_OPACITY.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mDetailText, "PositionX", mContactCardLayoutInfo.textFoldedPosition.X, TIME_PERIOD_FOLD_X.start, TIME_PERIOD_FOLD_X.start + TIME_PERIOD_FOLD_X.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                mAnimation.AnimateTo(mDetailText, "PositionY", mContactCardLayoutInfo.textFoldedPosition.Y, TIME_PERIOD_FOLD_Y.start, TIME_PERIOD_FOLD_Y.start + TIME_PERIOD_FOLD_Y.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));

                // Slowly fade in all the siblings
                View parent = mContactCard.GetParent() as View;
                for (uint i = 0; i < parent.GetChildCount(); ++i)
                {
                    View sibling = parent.GetChildAt(i);
                    if (sibling != mContactCard)
                    {
                        mAnimation.AnimateTo(sibling, "ColorAlpha", 1.0f, TIME_PERIOD_FOLD_SIBLING_OPACITY.start, TIME_PERIOD_FOLD_SIBLING_OPACITY.start + TIME_PERIOD_FOLD_SIBLING_OPACITY.duration, new AlphaFunction(ALPHA_FUNCTION_FOLD));
                        sibling.Sensitive = true;
                    }
                }

                mAnimation.Finished += OnAnimationFinished;
                mAnimation.Play();
            }

            mFolded = !mFolded;
        }

        private void OnAnimationFinished(object sender, EventArgs e)
        {
            Animation animation = sender as Animation;

            // Ensure the finishing animation is the latest as we do not want to change state if a previous animation has finished
            if (mAnimation == animation)
            {
                if(mFolded)
                {
                    mHeader.Unparent();
                    mDetailText.Unparent();

                    // Hide the clipped-image as we have finished animating the geometry and show the masked-image again
                    mClippedImage.Hide();
                    mMaskedImage.Show();
                }
            }
        }

        private bool OnKeyEvent(object sender, View.KeyEventArgs e)
        {
            if((!mFolded) && (e.Key.State == Key.StateType.Down))
            {
                if(e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "BackSpace")
                {
                    FocusManager focusManager = FocusManager.Instance;
                    if(focusManager.GetCurrentFocusView() == mContactCard)
                    {
                        // Our contact - card is set to receive focus and we're unfolded so animate back to the folded state
                        Animate();
                    }
                }
            }

            return true;
        }

        private void OnTap(object sender, TapGestureDetector.DetectedEventArgs e)
        {
            View view = sender as View;
            if(view = mContactCard)
            {
                Animate();
            }
        }

        public class TimePeriod
        {
            public int start;
            public int duration;

            public TimePeriod(int _start, int _duration)
            {
                start = _start;
                duration = _duration;
            }
        }
    }
}
