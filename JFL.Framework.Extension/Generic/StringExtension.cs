using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace JFL.Framework.Extension
{
    /// <summary>
    /// Extensions for <see cref="System.String"/>
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// A better way of calling <see cref="System.String.IsNullOrEmpty(string)"/>
        /// </summary>
        /// <param name="value">The string.</param>
        /// <returns>true if string is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// A better way of calling the negation of <see cref="System.String.IsNullOrEmpty(string)"/>
        /// </summary>
        /// <param name="value">The string.</param>
        /// <returns>true if string is not null and not empty; otherwise, false.</returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// A better way of calling <see cref="System.String.Format(string, object[])"/>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// Separates a PascalCase string
        /// </summary>
        /// <example>
        /// "ThisIsPascalCase".SeparatePascalCase(); // returns "This Is Pascal Case"
        /// </example>
        /// <param name="value">The value to split</param>
        /// <returns>The original string separated on each uppercase character.</returns>
        public static string SeparatePascalCase(this string value)
        {
            Ensure.Argument.NotNullOrEmpty(value, "value");
            return Regex.Replace(value, "([A-Z])", " $1").Trim();
        }

        /// <summary>
        /// Returns a string array containing the trimmed substrings in this <paramref name="value"/>
        /// that are delimited by the provided <paramref name="separators"/>.
        /// </summary>
        public static IEnumerable<string> SplitAndTrim(this string value, params char[] separators)
        {
            Ensure.Argument.NotNull(value, "source");
            return value.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
        }

        /// <summary>
        /// Return a string trimmed if original string is not null
        /// </summary>
        /// <param name="value">The original string</param>
        /// <returns>The string trimmed</returns>
        public static string IsNotNullThenTrim(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return value.Trim();
            else
                return value;
        }

        /// <summary>
        /// Checks if the <paramref name="source"/> contains the <paramref name="input"/> based on the provided <paramref name="comparison"/> rules.
        /// </summary>
        public static bool Contains(this string source, string input, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return source.IndexOf(input, comparison) >= 0;
        }

        /// <summary>
        /// Converts the specified source to a specify Type.
        /// </summary>
        /// <typeparam name="T">Destination type</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>string converted to destination type</returns>
        public static T Convert<T>(this string source)
        {
            return (T)TypeConverter.ChangeType(source, typeof(T));
        }

        /// <summary>
        /// Uppercase the first letter in the string.
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>string with first letter in uppercase</returns>
        /// <example>
        /// string value = "dot net perls";
        /// value = value.UppercaseFirstLetter();
        /// 
        /// //Return "Dot net perls"
        /// </example>
        public static string UppercaseFirstLetter(this string source)
        {
            if (source.Length > 0)
            {
                char[] array = source.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return source;
        }

        /// <summary>
        /// Truncates the string to a specified length and replace the truncated to a ...
        /// </summary>
        /// <param name="text">string that will be truncated</param>
        /// <param name="maxLength">total length of characters to maintain before the truncate happens</param>
        /// <returns>truncated string</returns>
        /// <example>
        /// string newText = "this is the palce i want to be, Cindys is the place to be!";
        /// Console.WriteLine("New Text: {0}", newText.Truncate(40));
        /// </example>
        public static string Truncate(this string text, int maxLength)
        {
            // replaces the truncated string to a ...
            const string suffix = "...";
            string truncatedString = text;

            if (maxLength <= 0) return truncatedString;
            int strLength = maxLength - suffix.Length;

            if (strLength <= 0) return truncatedString;

            if (text == null || text.Length <= maxLength) return truncatedString;

            truncatedString = text.Substring(0, strLength);
            truncatedString = truncatedString.TrimEnd();
            truncatedString += suffix;
            return truncatedString;
        }

        /// <summary>
        /// Check if a string is a date
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>true is the string is a date, false otherwise</returns>
        /// <example>
        /// string nonDate = "Foo";
        /// string someDate = "Jan 1 2010";
        /// 
        /// bool isDate = nonDate.IsDate(); //false
        /// isDate = someDate.IsDate(); //true
        /// </example>
        public static bool IsDate(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                DateTime dt;
                return (DateTime.TryParse(input, out dt));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if a string is a integer
        /// </summary>
        /// <param name="theValue">the string value</param>
        /// <returns>true if the string is a integer, false otherwise</returns>
        /// <example>
        /// string value = "abc";
        /// bool isnumeric = value.IsInteger();// Will return false;
        /// value = "11";
        /// isnumeric = value.IsInteger();// Will return true;
        /// </example>
        public static bool IsInteger(this string theValue)
        {
            long retNum;
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }

        /// <summary>
        /// Check if a string is a decimal
        /// </summary>
        /// <param name="theValue">the string value</param>
        /// <returns>true if the string is a decimal, false otherwise</returns>
        /// <example>
        /// string value = "abc";
        /// bool isnumeric = value.IsDecimal();// Will return false;
        /// value = "11.0";
        /// isnumeric = value.IsDecimal();// Will return true;
        /// </example>
        public static bool IsDecimal(this string theValue)
        {
            decimal retNum;
            return decimal.TryParse(theValue, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }

        /// <summary>
        /// Check if a string is a boolean
        /// </summary>
        /// <param name="theValue">the string value</param>
        /// <returns>true if the string is a boolean, false otherwise</returns>
        /// <example>
        /// string value = "abc";
        /// bool isnumeric = value.IsBoolean();// Will return false;
        /// value = "true";
        /// isnumeric = value.IsBoolean();// Will return true;
        /// "yes".IsBoolean() //returns true
        /// "n".IsBoolean() //returns true
        /// </example>
        public static bool IsBoolean(this string value)
        {
            var val = value.ToLower().Trim();
            if (val == "false")
                return true;
            if (val == "f")
                return true;
            if (val == "true")
                return true;
            if (val == "t")
                return true;
            if (val == "yes")
                return true;
            if (val == "no")
                return true;
            if (val == "y")
                return true;
            if (val == "n")
                return true;

            return false;
        }


        /// <summary>
        /// Converts string to enum object
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <returns>Returns enum object</returns>
        /// <example>
        /// var myEnum = "Pending".ToEnum<Status>();
        /// </example>
        public static T ToEnum<T>(this string value)
            where T : struct
        {
            return (T)System.Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Uppercase with null check
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <example>
        /// string g = "potatoe";
        /// return g.ToUpperCheckForNull();
        /// will return "POTATOE"
        /// </example>
        public static String ToUpperCheckForNull(this string input)
        {
            string retval = input;

            if (!String.IsNullOrEmpty(retval))
            {
                retval = retval.ToUpper();
            }
            return retval;
        }

        /// <summary>
        /// Lowercase with null check
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <example>
        /// string g = "POTATOE";
        /// return g.ToLowerCheckForNull();
        /// will return "potatoe"
        /// </example>
        public static String ToLowerCheckForNull(this string input)
        {
            string retval = input;

            if (!String.IsNullOrEmpty(retval))
            {
                retval = retval.ToUpper();
            }
            return retval;
        }

        #region with var

        /// <summary>
        /// ex) "{a}, {a:000}, {b}".WithVar(new {a, b});
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">A composite format string (equal string.Format's format)</param>
        /// <param name="arg">class or anonymouse type</param>
        /// <example>int count = 10</example>
        /// <example>var message2 = "{count:00000} Rows Deleted!".WithVar(new {count});</example>
        /// <example>// message2 : 00010 Rows Deleted!</example>
        /// <example>var query = "select * from {TableName} where id >= {Id};".WithVar(new {TableName = "Foo", Id = 10});</example>
        /// <example>// query : select * from Foo where id >= 10;</example>
        /// <returns></returns>
        public static string WithVar<T>(this string str, T arg) where T : class
        {
            var type = typeof(T);
            foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (!(member is FieldInfo || member is PropertyInfo))
                    continue;
                var pattern = @"\{" + member.Name + @"(\:.*?)?\}";
                var alreadyMatch = new HashSet<string>();
                foreach (Match m in Regex.Matches(str, pattern))
                {
                    if (alreadyMatch.Contains(m.Value)) continue; else alreadyMatch.Add(m.Value);
                    string oldValue = m.Value;
                    string newValue = null;
                    string format = "{0" + m.Groups[1].Value + "}";
                    if (member is FieldInfo)
                        newValue = format.With(((FieldInfo)member).GetValue(arg));
                    if (member is PropertyInfo)
                        newValue = format.With(((PropertyInfo)member).GetValue(arg));
                    if (newValue != null)
                        str = str.Replace(oldValue, newValue);
                }
            }
            return str;
        }


        /// <summary>
        /// alias for string.format
        /// </summary>
        /// <param name="str">A composite format string (equal string.Format's format)</param>
        /// <param name="param">format parameters</param>
        /// <returns></returns>
        public static string With(this string str, params object[] param)
        {
            return string.Format(str, param);
        }

        #endregion

    }
}
