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

        //public T Parse<T>(string filePath)
        //{
        //    var result = new StringWriter();
        //    XmlReader reader = new XmlTextReader();
        //}

        //public static T ReadXmlSerializableElement<T>(this XmlReader reader, String elementName) where T : IXmlSerializable
        //{
        //    reader.ReadToElement(elementName);
        //    Type elementType = Type.GetType(reader.GetAttribute("TYPE"));
        //    T element = (T)Activator.CreateInstance(elementType);
        //    element.ReadXml(reader);
        //    return element;
        //}
    }
}
