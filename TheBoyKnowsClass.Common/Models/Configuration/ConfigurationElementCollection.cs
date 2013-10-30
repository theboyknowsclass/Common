using System;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Xml.Serialization;

namespace TheBoyKnowsClass.Common.Models.Configuration
{
    public class ConfigurationElementCollection<T> : ConfigurationElementCollection, IXmlSerializable
        where T : ConfigurationElement, new()
    {
        public ConfigurationElementCollection()
        {
            ProcessAttributes();
        }

        public ConfigurationElementCollection(IComparer comparer) : base(comparer)
        {
            ProcessAttributes();
        }

        private void ProcessAttributes()
        {
            var attribute = (ConfigurationCollectionAttribute)Attribute.GetCustomAttribute(GetType(), typeof (ConfigurationCollectionAttribute));
            
            if(attribute != null)
            {
                AddElementName = attribute.AddItemName;
                RemoveElementName = attribute.RemoveItemName;
                ClearElementName = attribute.ClearItemsName;
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            foreach (PropertyInformation property in element.ElementInformation.Properties)
            {
                if(property.IsKey)
                {
                    return property.Value;
                }
            }

            throw new ConfigurationErrorsException(String.Format("Key not found for element {0}", element));
        }

        public bool Contains(object key)
        {
            return BaseGetAllKeys().Any(existingKeys => existingKeys == key);
        }

        public T this[int index]
        {
            get { return (T) BaseGet(index); }
            set
            {
                if(BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public T this[object key]
        {
            get { return (T)BaseGet(key); }
            set
            {
                if (BaseGet(key) != null)
                {
                    BaseRemove(key);
                }
                BaseAdd(value);
            }
        }

        public void Add(T item)
        {
            BaseAdd(item);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(T element)
        {
            int index = BaseIndexOf(element);

            if(BaseIndexOf(element) >= 0)
            {
                BaseRemoveAt(index);
            } 
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            base.DeserializeElement(reader, false);
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            base.SerializeElement(writer, false);
        }

        #endregion
    }
}
