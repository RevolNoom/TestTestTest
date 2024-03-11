using ConsoleApp1.ClassObject;
using ConsoleApp1.PrimitiveTests;
using System.Xml;

/// Primitive type tests
internal class Program
{
    private static void Main(string[] args)
    {


        ExerciseString.AutomatedTest();
        ExerciseInt.AutomatedTest();
        ExerciseBool.AutomatedTest();
        ExerciseDecimal.AutomatedTest();
        ExerciseDateTime.AutomatedTest();
        ExerciseList.AutomatedTest();
        ExerciseDictionary.AutomatedTest();

        Employee.AutomatedTest();

        //TestException.orderOfFinallyExecution();

        TestFile.AutomatedTest();


        /*
        try
        {
            var schema = new XmlTestTable().GetSchema();
            schema!.Write(Console.Out);
        }
        catch (Exception ex)
        {
             Console.WriteLine(ex.ToString());
             Console.WriteLine(ex.StackTrace);
        }*/
    }
}