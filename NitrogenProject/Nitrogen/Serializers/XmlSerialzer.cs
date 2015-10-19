namespace Nitrogen.Serializers
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class XmlSerialzer
    {
        public string Serialize<T>(T value)
        {
            StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, value);
            return writer.ToString();
        }

        public T ParseXml<T>(string filePath) where T : class, new()
        {
            string xmlTextToParse = string.Empty;

            using (var sr = new StreamReader(filePath))
            {
                xmlTextToParse = sr.ReadToEnd();
            }

            if (string.IsNullOrEmpty(xmlTextToParse))
            {
                throw new XmlException("Invalid string input. Cannot parse an empty or null string.", new ArgumentException("xmlTestToParse"));
            }


            var stringReader = new StringReader(xmlTextToParse);
            var serializer = new XmlSerializer(typeof(T));
            try
            {
                return serializer.Deserialize(stringReader) as T;
            }
            catch (Exception e)
            {
                throw new XmlException(string.Format("Unable to convert to given string into the type {0}. See inner exception for details.", typeof(T)), e);
            }
        }

    }
}
