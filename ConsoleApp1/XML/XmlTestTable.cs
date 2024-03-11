using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

public class XmlTestTable : IXmlSerializable
{
    public XmlTestTable() { }

    public XmlSchema? GetSchema()
    {
        var schema = new XmlSchema();
        schema.Items.Add(XmlTestStudent.getXmlSchemaObject());
        return schema;
    }

    public void ReadXml(XmlReader reader)
    {
        throw new NotImplementedException();
    }

    public void WriteXml(XmlWriter writer)
    {
        throw new NotImplementedException();
    }
}


