using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Tizen.GenericTextClassifier
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CategoryListStruct
    {
        internal char[] first_category;
        internal char[] second_category;
        internal char[] third_category;
        internal float first_category_score;
        internal float second_category_score;
        internal float third_category_score;
    }
    /// <Summary>
    /// API to create, delete category and get classification of categories.
    /// </Summary>
    public class GenericTextClassifier
    {
        internal const string LogTag = "Tizen.GenericTextClassifier";

        /// <Summary>
        /// Initializes the generic classifier module.
        /// </Summary>
        /// <exception cref="GenericTextClassifierError.AlreadyDone">Operation already done.</exception>
        public void TextClassifierInitialize()
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierInitialize();

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Initialize - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }
        }

        /// <Summary>
        /// De-Initializes the generic classifier module.
        /// </Summary>
        /// <exception cref="GenericTextClassifierError.AlreadyDone">Operation already done.</exception>
        public void TextClassifierDeinitialize()
        {   
            int ret;

            ret = Interop.GTCAPI.TextClassifierDeinitialize();

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Deinitialize - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }
        }

        /// <Summary>
        /// Creates a handle to the classifier for getting classification.
        /// </Summary>
        /// <param name="classifierHandle">classifierHandle pointer.</param>
        /// <param name="appId">appId pointer to a null terminated character array, containing unique ID for Application.</param>
        /// <param name="userId">userId pointer to a null terminated character array, containing unique ID for User.</param>
        /// <exception cref="GenericTextClassifierError.OutOfMemory">No more memory in system.</exception>
        /// <exception cref="GenericTextClassifierError.InvalidParameter">Invalid parameter.</exception>
        /// <exception cref="GenericTextClassifierError.AlreadyDone">Operation already done.</exception>
        /// <exception cref="GenericTextClassifierError.InitializedNotDone">Initialization not done.</exception>
        public void TextClassifierCreate(IntPtr classifierHandle, string appId, string userId)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierCreate(classifierHandle, appId, userId);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Create - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }
        }

        /// <Summary>
        /// Destroys the Classifier handle and releases all its resources
        /// </Summary>
        /// <param name="classifierHandle">classifierHandle pointer.</param>
        /// <exception cref="GenericTextClassifierError.InvalidParameter">Invalid parameter.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotCreated">Handle not created.</exception>
        /// <exception cref="GenericTextClassifierError.AlreadyDone">Operation already done.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotValid">Wrong handle passed.</exception>
        /// <exception cref="GenericTextClassifierError.InitializedNotDone">Initialization not done.</exception>
        public void TextClassifierDestroy(IntPtr classifierHandle)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierDestroy(classifierHandle);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Destroy - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }
        }

        /// <Summary>
        /// Gets predicted categories
        /// </Summary>
        /// <param name="classifierHandle">classifierHandle pointer.</param>
        /// <param name="textData">textData pointer to a null terminated character array, containing text data to be classified.</param>
        /// <param name="textDataLen">textDataLen length of text data to be classified.</param>
        /// <param name="categoryList">categoryList pointer to a CategoryListStruct struct, having its members as char array of top three predicted categories and corresponding scores as a float values.</param>
        /// <exception cref="GenericTextClassifierError.InvalidParameter">Invalid parameter.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotCreated">Handle not created.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotValid">Wrong handle passed.</exception>
        /// <exception cref="GenericTextClassifierError.InitializedNotDone">Initialization not done.</exception>
        public void TextClassifierGetCategory(IntPtr classifierHandle, string textData, int textDataLen, ref CategoryListStruct categoryList)
        {
            int ret;

            if (categoryList.first_category == null)
            {
                categoryList.first_category = new char[30];
            }
            if (categoryList.second_category == null)
            {
                categoryList.second_category = new char[30];
            }
            if (categoryList.third_category == null)
            {
                categoryList.third_category = new char[30];
            }

            ret = Interop.GTCAPI.TextClassifierGetCategory(classifierHandle,  textData, textDataLen, out categoryList);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Get Category - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }
        }

        /// <Summary>
        /// Adds user defined category
        /// </Summary>
        /// <param name="classifierHandle">classifierHandle pointer.</param>
        /// <param name="categoryName">categoryName pointer to a null terminated character array, containing category name.</param>
        /// <exception cref="GenericTextClassifierError.InvalidParameter">Invalid parameter.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotCreated">Handle not created.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotValid">Wrong handle passed.</exception>
        /// <exception cref="GenericTextClassifierError.InitializedNotDone">Initialization not done.</exception>
        public void TextClassifierAddCategory(IntPtr classifierHandle, string categoryName)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierAddCategory(classifierHandle, categoryName);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Add Category - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }
        }

        /// <Summary>
        /// Deletes user defined category
        /// </Summary>
        /// <param name="classifierHandle">classifierHandle pointer.</param>
        /// <param name="categoryName">categoryName pointer to a null terminated character array, containing category name.</param>
        /// <exception cref="GenericTextClassifierError.InvalidParameter">Invalid parameter.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotCreated">Handle not created.</exception>
        /// <exception cref="GenericTextClassifierError.AlreadyDone">Operation already done.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotValid">Wrong handle passed.</exception>
        /// <exception cref="GenericTextClassifierError.InitializedNotDone">Initialization not done.</exception>
        public void TextClassifierDeleteCategory(IntPtr classifierHandle, string categoryName)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierDeleteCategory(classifierHandle, categoryName);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Delete Category - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }
        }

        /// <Summary>
        /// Trains classifier with given text_data for given category
        /// </Summary>
        /// <param name="classifierHandle">classifierHandle pointer.</param>
        /// <param name="categoryName">categoryName pointer to a null terminated character array, containing category name.</param>
        /// <param name="textData">textData pointer to a null terminated character array, containing text data to be classified.</param>
        /// <param name="textDataLen">textDataLen length of text data to be classified.</param>
        /// <exception cref="GenericTextClassifierError.InvalidParameter">Invalid parameter.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotCreated">Handle not created.</exception>
        /// <exception cref="GenericTextClassifierError.HandleNotValid">Wrong handle passed.</exception>
        /// <exception cref="GenericTextClassifierError.InitializedNotDone">Initialization not done.</exception>
        public void TextClassifierUpdateCategory(IntPtr classifierHandle, string categoryName, string textData, int textDataLen)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierUpdateCategory(classifierHandle, categoryName, textData, textDataLen);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Update Category - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }
        }
    }
}
