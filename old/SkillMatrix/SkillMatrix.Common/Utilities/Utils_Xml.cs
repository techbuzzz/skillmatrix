using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SkillMatrix.Common
{
    public static partial class Utilities
    {
        /// <summary>
        /// Remove illegal XML characters from a string.
        /// </summary>
        public static string SanitizeXmlString(string xml)
        {
            if (xml == null)
            {
                throw new ArgumentNullException("xml");
            }

            var buffer = new StringBuilder(xml.Length);

            foreach (char c in xml)
            {
                if (IsLegalXmlChar(c))
                {
                    buffer.Append(c);
                }
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Whether a given character is allowed by XML 1.0.
        /// </summary>
        public static bool IsLegalXmlChar(int character)
        {
            return
                (
                    character == 0x9 /* == '\t' == 9   */||
                    character == 0xA /* == '\n' == 10  */||
                    character == 0xD /* == '\r' == 13  */||
                    (character >= 0x20 && character <= 0xD7FF) ||
                    (character >= 0xE000 && character <= 0xFFFD) ||
                    (character >= 0x10000 && character <= 0x10FFFF)
                );
        }

        public static XElement ToXElement<T>(this T obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, obj);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
        }

        public static T FromXElement<T>(this XElement xElement)
        {
            using (var reader = xElement.CreateReader())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static XElement StripNamespaces(this XElement rootElement)
        {
            foreach (var element in rootElement.DescendantsAndSelf())
            {
                // update element name if a namespace is available
                if (element.Name.Namespace != XNamespace.None)
                {
                    element.Name = XNamespace.None.GetName(element.Name.LocalName);
                }

                // check if the element contains attributes with defined namespaces (ignore xml and empty namespaces)
                bool hasDefinedNamespaces = element.Attributes().Any(attribute => attribute.IsNamespaceDeclaration ||
                        (attribute.Name.Namespace != XNamespace.None && attribute.Name.Namespace != XNamespace.Xml));

                if (hasDefinedNamespaces)
                {
                    // ignore attributes with a namespace declaration
                    // strip namespace from attributes with defined namespaces, ignore xml / empty namespaces
                    // xml namespace is ignored to retain the space preserve attribute
                    var attributes = element.Attributes()
                                            .Where(attribute => !attribute.IsNamespaceDeclaration)
                                            .Select(attribute =>
                                                (attribute.Name.Namespace != XNamespace.None && attribute.Name.Namespace != XNamespace.Xml) ?
                                                    new XAttribute(XNamespace.None.GetName(attribute.Name.LocalName), attribute.Value) :
                                                    attribute
                                            );

                    // replace with attributes result
                    element.ReplaceAttributes(attributes);
                }
            }
            return rootElement;
        }

        
    }
}