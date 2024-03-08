using System.Xml;

/// Primitive type tests
internal class Program
{
    private static void Main(string[] args)
    {


        ExerciseString.automatedTest();
        ExerciseInt.automatedTest();
        ExerciseBool.automatedTest();
        ExerciseDecimal.automatedTest();
        ExerciseDateTime.automatedTest();
        ExerciseList.automatedTest();
        ExerciseDictionary.automatedTest();

        Employee.automatedTest();

        //TestException.orderOfFinallyExecution();

        TestFile.automatedTest();


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