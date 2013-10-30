using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace TheBoyKnowsClass.Common.Models
{
    public static class Serializer
    {
        public static void SerialiseObject<T>(string filename, T objectToSerialize)
        {
           Stream stream = File.Open(filename, FileMode.Create);
           var binaryFormatter = new BinaryFormatter();
           binaryFormatter.Serialize(stream, objectToSerialize);
           stream.Close();
        }
 
        public static T DeSerialiseObject<T>(string filename)
        {
            Stream stream = File.Open(filename, FileMode.Open);
            var binaryFormatter = new BinaryFormatter();
            var objectToSerialize = (T)binaryFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }

        public static void ReadXml<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, System.Xml.XmlReader reader)
        {
            var keySerializer = new XmlSerializer(typeof(TKey));
            var valueSerializer = new XmlSerializer(typeof(TValue));

            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty)
            { return; }


            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
                reader.ReadStartElement("key");
                var key = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                var value = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                dictionary.Add(key, value);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        public static void WriteXml<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, System.Xml.XmlWriter writer)
        {
            var keySerializer = new XmlSerializer(typeof(TKey));
            var valueSerializer = new XmlSerializer(typeof(TValue));

            foreach (TKey key in dictionary.Keys)
            {
                writer.WriteStartElement("item");
                writer.WriteStartElement("key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement("value");
                var value = dictionary[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }
}
