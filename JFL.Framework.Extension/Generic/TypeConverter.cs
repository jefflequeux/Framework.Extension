using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.ComponentModel;

namespace JFL.Framework.Extension
{
    /// <summary>
    /// Type converter
    /// </summary>
    /// <remarks>
    /// .Net 4.0 framework doesn't work correctly with type conversion if type is Nullable
    /// </remarks>
    public class TypeConverter
    {

        /// <summary>
        /// Chnage type of nullable object
        /// </summary>
        /// <param name="value">Object value</param>
        /// <param name="conversionType">Destination Type Object</param>
        /// <param name="culture">Culture used for convertion</param>
        /// <returns>new object</returns>
        public static object ChangeType(object value, Type conversionType, CultureInfo culture = null)
        {
            if (culture == null)
                culture = CultureInfo.CurrentCulture;
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            }

            if (conversionType.IsGenericType &&
              conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.ToString() == string.Empty)
                {
                    return null;
                }
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }

            return Convert.ChangeType(value, conversionType, culture);
        }
    }
}
