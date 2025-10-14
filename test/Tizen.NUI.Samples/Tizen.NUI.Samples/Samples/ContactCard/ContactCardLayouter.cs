using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class ContactCardLayouter
    {
        private const float DEFAULT_PADDING = 25.0f;

        private const float MINIMUM_ITEMS_PER_ROW_OR_COLUMN = 3.0f;

        private const float HEADER_HEIGHT_TO_UNFOLDED_SIZE_RATIO = 0.1f;
        private readonly Vector2 HEADER_FOLDED_POSITION_AS_RATIO_OF_SIZE = new Vector2(-0.05f, -1.5f);
        private readonly Vector2 HEADER_UNFOLDED_POSITION = new Vector2(0.0f, 0.0f);

        const float IMAGE_SIZE_AS_RATIO_TO_FOLDED_SIZE = 0.5f;
        private readonly Vector2 IMAGE_FOLDED_POSITION_AS_RATIO_OF_SIZE = new Vector2(0.5f, 0.25f);

        const float FOLDED_TEXT_POSITION_AS_RATIO_OF_IMAGE_SIZE = 1.01f;

        private readonly Vector4 ROOTVIEW_COLOR = new Vector4(211.0f / 255.0f, 211.0f / 255.0f, 211.0f / 255.0f, 1.0f);


        private ContactCardLayoutInfo mContactCardLayoutInfo;
        private List<ContactCard> mContactCards;

        private Vector2 mLastPosition;
        private Vector2 mPositionIncrementer;
        private int mItemsPerRow;

        private bool mInitialized;

        private View rootView;

        public ContactCardLayouter()
        {
            Initialize();
        }

        public void Clear()
        {
            if (null != rootView)
            {
                if (null != rootView.GetParent())
                {
                    rootView.GetParent().Remove(rootView);
                }
                rootView.Dispose();
                rootView = null;
            }
        }

        private void Initialize()
        {
            mContactCardLayoutInfo = new ContactCardLayoutInfo();
            mContactCards = new List<ContactCard>();
            mLastPosition = new Vector2();
            mPositionIncrementer = new Vector2();
            mItemsPerRow = 0;
            mInitialized = false;

            rootView = new View()
            {
                Size2D = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height),
                BackgroundColor = ROOTVIEW_COLOR,
                PositionUsesPivotPoint = false,
            };

            NUIApplication.GetDefaultWindow().Add(rootView);

        }

        public void AddContact(string contactName, string contactAddress, string imagePath)
        {
            if(!mInitialized)
            {
                // Set up the common layouting info shared between all contact cards when first called
                mContactCardLayoutInfo.unfoldedPosition = mContactCardLayoutInfo.padding = new Vector2(DEFAULT_PADDING, DEFAULT_PADDING);
                Vector2 windowSize = new Vector2(NUIApplication.GetDefaultWindow().Size.Width, NUIApplication.GetDefaultWindow().Size.Height);
                mContactCardLayoutInfo.unfoldedSize = windowSize - mContactCardLayoutInfo.padding * (MINIMUM_ITEMS_PER_ROW_OR_COLUMN - 1.0f);

                // Calculate the size of the folded card (use the minimum of width/height as size)
                mContactCardLayoutInfo.foldedSize = (mContactCardLayoutInfo.unfoldedSize - (mContactCardLayoutInfo.padding * (MINIMUM_ITEMS_PER_ROW_OR_COLUMN - 1.0f))) / MINIMUM_ITEMS_PER_ROW_OR_COLUMN;
                float calculatedSize = Math.Min(mContactCardLayoutInfo.foldedSize.Width, mContactCardLayoutInfo.foldedSize.Height);
                mContactCardLayoutInfo.foldedSize = new Vector2(calculatedSize, calculatedSize);

                // Set the size and positions of the header
                mContactCardLayoutInfo.headerSize = new Vector2(mContactCardLayoutInfo.unfoldedSize.Width, mContactCardLayoutInfo.unfoldedSize.Height * HEADER_HEIGHT_TO_UNFOLDED_SIZE_RATIO);
                mContactCardLayoutInfo.headerFoldedPosition = mContactCardLayoutInfo.headerSize * HEADER_FOLDED_POSITION_AS_RATIO_OF_SIZE;
                mContactCardLayoutInfo.headerUnfoldedPosition = HEADER_UNFOLDED_POSITION;

                // Set the image size and positions
                mContactCardLayoutInfo.imageSize = mContactCardLayoutInfo.foldedSize * IMAGE_SIZE_AS_RATIO_TO_FOLDED_SIZE;
                mContactCardLayoutInfo.imageFoldedPosition = mContactCardLayoutInfo.imageSize * IMAGE_FOLDED_POSITION_AS_RATIO_OF_SIZE;
                mContactCardLayoutInfo.imageUnfoldedPosition = new Vector2(mContactCardLayoutInfo.padding.Width, mContactCardLayoutInfo.headerSize.Height + mContactCardLayoutInfo.padding.Height);

                // Set the positions of the contact name
                mContactCardLayoutInfo.textFoldedPosition = new Vector2(0.0f, mContactCardLayoutInfo.imageFoldedPosition.X + mContactCardLayoutInfo.imageSize.Height * FOLDED_TEXT_POSITION_AS_RATIO_OF_IMAGE_SIZE);
                mContactCardLayoutInfo.textUnfoldedPosition = new Vector2(mContactCardLayoutInfo.padding.Width, mContactCardLayoutInfo.imageUnfoldedPosition.Y + mContactCardLayoutInfo.imageSize.Height + mContactCardLayoutInfo.padding.Height);

                // Figure out the positions of the contact cards
                mItemsPerRow = (int)((mContactCardLayoutInfo.unfoldedSize.Width + mContactCardLayoutInfo.padding.Width) / (mContactCardLayoutInfo.foldedSize.Width + mContactCardLayoutInfo.padding.Width));
                mLastPosition = new Vector2(mContactCardLayoutInfo.unfoldedPosition.X, mContactCardLayoutInfo.unfoldedPosition.Y);
                mPositionIncrementer = new Vector2(mContactCardLayoutInfo.foldedSize.Width + mContactCardLayoutInfo.padding.Width, mContactCardLayoutInfo.foldedSize.Height + mContactCardLayoutInfo.padding.Height);

                mInitialized = true;
            }

            mContactCards.Add(new ContactCard(mContactCardLayoutInfo, contactName, contactAddress, imagePath, NextCardPosition(), rootView));

        }

        private Vector2 NextCardPosition()
        {
            int currentNumOfCards = mContactCards.Count();

            if(currentNumOfCards > 0)
            {
                float positionX = mLastPosition.X;
                float positionY = mLastPosition.Y;
                if(currentNumOfCards % mItemsPerRow != 0)
                {
                    positionX += mPositionIncrementer.X;
                }
                else
                {
                    positionX = mContactCardLayoutInfo.unfoldedPosition.X;
                    positionY += mPositionIncrementer.Y;
                }
                mLastPosition = new Vector2(positionX, positionY);
            }

            return mLastPosition;
        }

    }
}
