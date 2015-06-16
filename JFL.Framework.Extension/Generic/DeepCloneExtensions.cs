using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JFL.Framework.Extension
{
    /// <summary>
    /// DeepCloneExtended
    /// </summary>
    public static class DeepCloneExtensions
    {

        /// <summary>
        /// Deeps clone an object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="a">Object</param>
        /// <returns>Object Cloned</returns>
        public static T DeepClone<T>(this T a) where T : ISerializable
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
