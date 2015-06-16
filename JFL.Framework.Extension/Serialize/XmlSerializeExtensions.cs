using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Reflection;

namespace JFL.Framework.Extension
{

    /// <summary>
    /// Serialization Helper
    /// </summary>
    public static class XmlSerializeExtensions
    {

        /// <summary>
        /// Return a Xml string corresponding to the object.
        /// Object is serialize in Xml
        /// </summary>
        /// <param name="value">The model.</param>
        /// <returns>String representing the object using Xml Serialization</returns>
        public static string SerializeXml<T>(this T value)
        {

            if (value == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = false;
            settings.OmitXmlDeclaration = false;

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, value);
                }
                return textWriter.ToString();
            }
        }


        /// <summary>
        /// Return a Xml string corresponding to the object.
        /// Object is serialize in Xml
        /// </summary>
        /// <param name="value">The model.</param>
        /// <returns>String representing the object using Xml Serialization</returns>
        public static string SerializeXml(this object value)
        {

            if (value == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(value.GetType());

            XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, value);
                }
                return textWriter.ToString();
            }
        }

        /// <summary>
        /// Return a Xml string corresponding to the object.
        /// Object is serialize in Xml, then transform using IE5 Xsl
        /// </summary>
        /// <param name="Model">The model.</param>
        /// <returns>String representing the object using Xml Serialization and Xsl transformation</returns>
        public static string DisplayXml(object Model)
        {
            string value = Model.SerializeXml();
            value = value.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            value = value.Replace("xsi:nil=\"true\"", "");
            value = value.Replace("xsi:nil=\"false\"", "");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(value);

            StringBuilder resultString = new StringBuilder();
            using (XmlTextWriter xmlWriter = new XmlTextWriter(new StringWriter(resultString)))
            {
                using (XmlTextReader xmlReader = new XmlTextReader(new StringReader(doc.OuterXml)))
                {
#pragma warning disable 618
                    using (Stream strm = Assembly.LoadWithPartialName("JFL.Framework.Extension").GetManifestResourceStream("JFL.Framework.Extension.Tools.defaultss.xsl"))
                    {
                        System.Xml.Xsl.XslCompiledTransform xslTransform = new System.Xml.Xsl.XslCompiledTransform();
                        using (XmlReader reader = XmlReader.Create(strm))
                        {
                            xslTransform.Load(reader);
                        }
                        xslTransform.Transform(xmlReader, xmlWriter);
                    }
#pragma warning restore 618
                }
            }

            return "<div style='border:1px solid black; background-color:white;padding:4px;font-size:11px;' class='xmlContentDbg'>" + resultString.ToString() + "</div>";
        }

        /// <summary>
        /// Return a Xml string corresponding to the object.
        /// Object is serialize in Xml, then transform using IE5 Xsl
        /// </summary>
        /// <param name="document">The Xml Document as tring.</param>
        /// <returns>String representing the object using Xml Serialization and Xsl transformation</returns>
        public static string DisplayXml(string document)
        {
            string value = document;
            value = value.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            value = value.Replace("xsi:nil=\"true\"", "");
            value = value.Replace("xsi:nil=\"false\"", "");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(value);

            StringBuilder resultString = new StringBuilder();
            using (XmlTextWriter xmlWriter = new XmlTextWriter(new StringWriter(resultString)))
            {
                using (XmlTextReader xmlReader = new XmlTextReader(new StringReader(doc.OuterXml)))
                {
#pragma warning disable 618
                    using (Stream strm = Assembly.LoadWithPartialName("MvcApplication5.Core").GetManifestResourceStream("MvcApplication5.Core.Tools.defaultss.xsl"))
                    {
                        System.Xml.Xsl.XslCompiledTransform xslTransform = new System.Xml.Xsl.XslCompiledTransform();
                        using (XmlReader reader = XmlReader.Create(strm))
                        {
                            xslTransform.Load(reader);
                        }
                        xslTransform.Transform(xmlReader, xmlWriter);
                    }
#pragma warning restore 618
                }
            }

            return "<div style='border:1px solid black; background-color:white;padding:4px;font-size:11px;' class='xmlContentDbg'>" + resultString.ToString() + "</div>";
        }
    }
}
