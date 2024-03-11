using System.Xml;
using System.Xml.Schema;

abstract public class XmlSqlPrimitive
{
    // TODO: Chua dung den
    protected string name;
    protected bool nullable;

    protected XmlSqlPrimitive(string name, bool nullable)
    {
        this.name = name;
        this.nullable = nullable;
    }

    abstract public XmlSchemaObject getXmlSchemaObject();
}

public class XmlSqlNvarchar : XmlSqlPrimitive
{
    uint maxLength;

    public XmlSqlNvarchar(string name, uint maxLength, bool nullable = false) : base(name, nullable)
    {
        this.maxLength = maxLength;
    }

    override public XmlSchemaObject getXmlSchemaObject()
    {
        var xmlObject = new XmlSchemaElement();
        var restriction = new XmlSchemaSimpleTypeRestriction();
        restriction.BaseTypeName = new XmlQualifiedName("string");
        var maxLengthRestriction = new XmlSchemaMaxLengthFacet();
        maxLengthRestriction.Value = maxLength.ToString();
        restriction.Facets.Add(maxLengthRestriction);

        xmlObject.Name = name;
        xmlObject.SchemaTypeName = new XmlQualifiedName("string");
        return xmlObject;
    }
}

public class XmlSqlInt : XmlSqlPrimitive
{
    public XmlSqlInt(string name, bool nullable = false) : base(name, nullable)
    {
    }

    override public XmlSchemaObject getXmlSchemaObject()
    {
        var xmlObject = new XmlSchemaElement();
        xmlObject.Name = name;
        xmlObject.SchemaTypeName = new XmlQualifiedName("base64Binary");
        return xmlObject;
    }
}

public class XmlSqlDateTime : XmlSqlPrimitive
{
    public XmlSqlDateTime(string name, bool nullable = false) : base(name, nullable)
    {
    }

    override public XmlSchemaObject getXmlSchemaObject()
    {
        var xmlObject = new XmlSchemaElement();
        xmlObject.Name = name;
        xmlObject.SchemaTypeName = new XmlQualifiedName("dateTime");
        return xmlObject;
    }
}