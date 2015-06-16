using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JFL.Framework.Extension
{
    /// <summary>
    /// Helper for Enumeration
    /// </summary>
    public static class EnumsExtension
    {
        /// <summary>
        /// Retrieve Enumeration item from description value
        /// </summary>
        /// <param name="value">The description value.</param>
        /// <param name="enumType">Type of the Enumeration.</param>
        /// <returns>Enumeration item.</returns>
        public static object FromEnum(this string value, Type enumType)
        {
            foreach (string enumeration in Enum.GetNames(enumType))
            {
                FieldInfo field = enumType.GetField(enumeration);
                if (field != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null && value == attr.Description)
                    {
                        return Enum.Parse(enumType, enumeration);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the descriptions of an Enumeration value.
        /// </summary>
        /// <param name="enumerationValue">The Enumeration value.</param>
        /// <returns>descriptions of an Enumeration value.</returns>
        public static string ToDescription(this Enum enumerationValue)
        {
            Type enumType = enumerationValue.GetType();
            foreach (string enumeration in Enum.GetNames(enumType))
            {
                if (Enum.GetName(enumType, enumerationValue) == enumeration)
                {
                    FieldInfo field = enumType.GetField(enumeration);
                    if (field != null)
                    {
                        DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                        if (attr != null)
                        {
                            return attr.Description;
                        }
                    }
                }
            }

            return null;
        }
    }

    /// <summary>
    ///  Enumeration Manager helper class
    /// </summary>
    public class EnumManager
    {
        /// <summary>
        /// Gets all descriptions of an Enumeration.
        /// </summary>
        /// <param name="enumType">Type of the Enumeration.</param>
        /// <returns>All descriptions of Enumeration.</returns>
        public static List<string> GetDescriptions(Type enumType)
        {
            List<string> listOfDescription = new List<string>();
            foreach (string enumeration in Enum.GetNames(enumType))
            {
                FieldInfo field = enumType.GetField(enumeration);
                if (field != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        listOfDescription.Add(attr.Description);
                    }
                }
            }

            return listOfDescription;
        }
    }
}