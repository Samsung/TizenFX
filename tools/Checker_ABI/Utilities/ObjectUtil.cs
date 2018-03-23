using System;
using System.Reflection;

namespace Checker_ABI.Utilities
{
    /// -----------------------------------------------------------------------
    /// <summary>  
    /// This utility class contains a rich sets of utility methods that perform operations 
    /// on objects during runtime such as copying of property and field values
    /// between 2 objects, deep cloning of objects, etc.  
    /// </summary>
    /// -----------------------------------------------------------------------
    public abstract class ObjectUtils
    {
        /// <summary>
        /// Deep Comparison two objects if they are alike. The objects are consider alike if 
        /// they are:
        /// <list type="ordered">
        ///    <item>of the same <see cref="System.Type"/>,</item>
        ///    <item>have the same number of methods, properties and fields</item>
        ///    <item>the public and private properties and fields values reflect each other's. </item>
        /// </list>
        /// </summary>
        /// <param name="original"></param>
        /// <param name="comparedToObject"></param>
        /// <returns></returns>
        public static bool IsALike(object original, object comparedToObject)
        {

            if (original.GetType() != comparedToObject.GetType())
                return false;

            // ...............................................
            // Compare Number of Private and public Methods
            // ...............................................
            MethodInfo[] originalMethods = original
              .GetType()
              .GetMethods(BindingFlags.Instance |
              BindingFlags.NonPublic |
              BindingFlags.Public);

            MethodInfo[] comparedMethods = comparedToObject
              .GetType()
              .GetMethods(BindingFlags.Instance |
              BindingFlags.NonPublic |
              BindingFlags.Public);

            if (comparedMethods.Length != originalMethods.Length)
                return false;

            // ...............................................
            // Compare Number of Private and public Properties
            // ................................................
            PropertyInfo[] originalProperties = original
              .GetType()
              .GetProperties(BindingFlags.Instance |
              BindingFlags.NonPublic |
              BindingFlags.Public);

            PropertyInfo[] comparedProperties = comparedToObject
              .GetType()
              .GetProperties(BindingFlags.Instance |
              BindingFlags.NonPublic |
              BindingFlags.Public);


            if (comparedProperties.Length != originalProperties.Length)
                return false;


            // ...........................................
            // Compare number of public and private fields
            // ...........................................
            FieldInfo[] originalFields = original
              .GetType()
              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            FieldInfo[] comparedToFields = comparedToObject
              .GetType()
              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);


            if (comparedToFields.Length != originalFields.Length)
                return false;

            // ........................................
            // compare field values
            // ........................................
            foreach (FieldInfo fi in originalFields)
            {

                // check to see if the object to contains the field          
                FieldInfo fiComparedObj = comparedToObject.GetType().GetField(fi.Name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                if (fiComparedObj == null)
                    return false;

                // Get the value of the field from the original object        
                Object srcValue = original.GetType().InvokeMember(fi.Name,
                  BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                  null,
                  original,
                  null);



                // Get the value of the field
                object comparedObjFieldValue = comparedToObject
                  .GetType()
                  .InvokeMember(fiComparedObj.Name,
                  BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                  null,
                  comparedToObject,
                  null);


                // -------------------------------
                // now compare the field values
                // -------------------------------

                if (srcValue == null)
                {
                    if (comparedObjFieldValue != null)
                        return false;
                    else
                        return true;
                }

                if (srcValue.GetType() != comparedObjFieldValue.GetType())
                    return false;

                if (!srcValue.ToString().Equals(comparedObjFieldValue.ToString()))
                    return false;
            }

            // ........................................
            // compare each Property values
            // ........................................
            foreach (PropertyInfo pi in originalProperties)
            {

                // check to see if the object to contains the field          
                PropertyInfo piComparedObj = comparedToObject
                  .GetType()
                  .GetProperty(pi.Name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                if (piComparedObj == null)
                    return false;

                // Get the value of the property from the original object        
                Object srcValue = original
                  .GetType()
                  .InvokeMember(pi.Name,
                  BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                  null,
                  original,
                  null);

                // Get the value of the property
                object comparedObjValue = comparedToObject
                  .GetType()
                  .InvokeMember(piComparedObj.Name,
                  BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                  null,
                  comparedToObject,
                  null);


                // -------------------------------
                // now compare the property values
                // -------------------------------
                if (srcValue.GetType() != comparedObjValue.GetType())
                    return false;

                if (!srcValue.ToString().Equals(comparedObjValue.ToString()))
                    return false;
            }
            return true;
        }
    }
}
