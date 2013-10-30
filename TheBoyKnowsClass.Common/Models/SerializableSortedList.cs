using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TheBoyKnowsClass.Common.Models
{
    public class SerializableSortedList<TKey, TValue> : SortedList<TKey, TValue>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            ((IDictionary<TKey,TValue>)this).ReadXml(reader);
        }

        public void WriteXml(XmlWriter writer)
        {
            ((IDictionary<TKey, TValue>)this).WriteXml(writer);
        }
    }
}
