using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JFL.Framework.Extension
{
    /// <summary>
    /// Fast Compare
    /// </summary>
    public static class FastCompareExtensions
    {
        /// <summary>
        /// Compare 2 object data using byte compare.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>true is equals, false otherwise</returns>
        public static bool FastCompare(this object obj1, object obj2)
        {
            byte[] obj1Byte = ObjectToByteArray(obj1);
            byte[] obj2Byte = ObjectToByteArray(obj2);

            if (obj1Byte.Length != obj2Byte.Length && !obj1Byte.SequenceEqual(obj2Byte))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Objects to byte array.
        /// </summary>
        /// <param name="_Object">The _ object.</param>
        /// <returns>Object concerted to byte</returns>
        private static byte[] ObjectToByteArray(object _Object)
        {
            // create new memory stream
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();

            // create new BinaryFormatter
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter _BinaryFormatter
                        = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            // Serializes an object, or graph of connected objects, to the given stream.
            _BinaryFormatter.Serialize(_MemoryStream, _Object);

            // convert stream to byte array and return
            return _MemoryStream.ToArray();
        }
    }
}
