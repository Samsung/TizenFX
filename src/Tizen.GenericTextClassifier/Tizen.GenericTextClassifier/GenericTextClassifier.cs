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

    class GenericTextClassifier
    {
        internal const string LogTag = "Tizen.GenericTextClassifier";
        /*int text_classifier_initialize(void);*/
        public int TextClassifierInitialize()
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierInitialize();

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Initialize - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }

            return ret;
        }
        public int TextClassifierDeinitialize()
        {   
            int ret;

            ret = Interop.GTCAPI.TextClassifierDeinitialize();

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Deinitialize - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }

            return ret;
        }

        public int TextClassifierCreate(IntPtr classifier_handle, String app_id, String user_id)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierCreate(classifier_handle, app_id, user_id);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Create - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }

            return ret;
        }

        public int TextClassifierDestroy(IntPtr classifier_handle)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierDestroy(classifier_handle);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Destroy - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }

            return ret;
        }

        public int TextClassifierGetCategory(IntPtr classifier_handle, String text_data, int text_data_len, ref CategoryListStruct category_list)
        {
            int ret;

            if (category_list.first_category == null)
            {
                category_list.first_category = new char[30];
            }
            if (category_list.second_category == null)
            {
                category_list.second_category = new char[30];
            }
            if (category_list.third_category == null)
            {
                category_list.third_category = new char[30];
            }

            ret = Interop.GTCAPI.TextClassifierGetCategory( classifier_handle,  text_data,  text_data_len, ref category_list);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Get Category - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }

            return ret;
        }

        public int TextClassifierAddCategory(IntPtr classifier_handle, String category_name)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierAddCategory(classifier_handle, category_name);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Add Category - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }

            return ret;
        }
        public int TextClassifierDeleteCategory(IntPtr classifier_handle, String category_name)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierDeleteCategory(classifier_handle, category_name);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Delete Category - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }

            return ret;
        }
        public int TextClassifierUpdateCategory(IntPtr classifier_handle, String category_name, String text_data, int text_data_len)
        {
            int ret;

            ret = Interop.GTCAPI.TextClassifierUpdateCategory(classifier_handle, category_name, text_data, text_data_len);

            if (ret != (int)GenericTextClassifierError.None)
            {
                Log.Error(LogTag, "Failed to Update Category - " + (GenericTextClassifierError)ret);
                GenericTextClassifierErrorFactory.ThrowGenericTextClassifierException(ret);
            }

            return ret;
        }
    }
}
