using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;


public class XmlTestStudent : IXmlSerializable
{
    public int studentId;
    public int? classId;
    public string name;
    public DateTime dob;
    public string code;
    public int? math;
    public int? phys;

    public XmlTestStudent(int studentId, int? classId, string name, DateTime dob, string code, int? math, int? phys)
    {
        this.studentId = studentId;
        this.classId = classId;
        this.name = name;
        this.dob = dob;
        this.code = code;
        this.math = math;
        this.phys = phys;
    }

    public XmlSchema? GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        throw new NotImplementedException();
    }

    public void WriteXml(XmlWriter writer)
    {
        throw new NotImplementedException();
    }

    static public XmlSchemaObject getXmlSchemaObject()
    {
        var complexType = new XmlSchemaComplexType();
        complexType.Name = "Student";

        // Sequence of a billion relation attributes here
        var sequence = new XmlSchemaSequence();

        sequence.Items.Add(new XmlSqlInt("StudentID").getXmlSchemaObject());
        sequence.Items.Add(new XmlSqlInt("ClassID", true).getXmlSchemaObject());
        sequence.Items.Add(new XmlSqlNvarchar("Name", 256).getXmlSchemaObject());
        sequence.Items.Add(new XmlSqlDateTime("DOB").getXmlSchemaObject());
        sequence.Items.Add(new XmlSqlNvarchar("Code", 32).getXmlSchemaObject());
        sequence.Items.Add(new XmlSqlInt("Math", true).getXmlSchemaObject());
        sequence.Items.Add(new XmlSqlInt("Phys", true).getXmlSchemaObject());

        /*
        */

        complexType.Particle = sequence;

        return complexType;
    }
}
