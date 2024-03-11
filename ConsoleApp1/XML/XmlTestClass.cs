using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;


public class XmlTestClass : IXmlSerializable
{
    public int classId;
    public string name;
    public string desc;

    XmlTestClass(int classId, string name, string desc)
    {
        this.classId = classId;
        this.name = name;
        this.desc = desc;
    }

    public XmlSchema? GetSchema()
    {
        throw new NotImplementedException();
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
