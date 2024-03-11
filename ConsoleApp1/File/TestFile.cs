class TestFile
{
    public static void AutomatedTest()
    {
        FileStream? input = null;
        FileStream? output = null;
        try
        {
            input = PromptInputFile();

            var result = ProcessInputFile(input);

            output = PromptOutputFile();
            StreamWriter writer = new StreamWriter(output);
            foreach (var line in result)
            {
                writer.WriteLine(line);
            }
            writer.Flush();
        }
        catch
        {
            throw;
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
            if (output != null)
            {
                output.Close();
            }
            Console.WriteLine("Xong roi do :>");
            Console.WriteLine();
        }
    }

    public static List<string> ProcessInputFile(FileStream input)
    {
        var reader = new StreamReader(input);
        var result = new List<string>();
        try
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("ReadLine bi null. Sao lai the duoc? @@");
                    continue;
                }
                var intCandidates = line.Split(" ").ToList();
                intCandidates = ExerciseList.RemoveWhere(intCandidates, (string str) => str == "");

                var failFormatCount = 0;
                var overflowCount = 0;
                var goodNumbers = new List<int> { };

                foreach (var i in intCandidates)
                {
                    try
                    {
                        goodNumbers.Add(int.Parse(i));
                    }
                    catch (FormatException)
                    {
                        failFormatCount += 1;
                    }
                    catch (OverflowException)
                    {
                        overflowCount += 1;
                    }
                }

                if (overflowCount > 0 || failFormatCount > 0)
                {
                    result.Add($"{failFormatCount} so bi sai format (khong phai int32). {overflowCount} so bi vuot gioi han kieu Int32.");
                }
                else
                {
                    goodNumbers.Sort();
                    goodNumbers.Reverse();
                    result.Add(string.Join("    ", goodNumbers));
                }
            }
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine($"Co cai gi do bi het memory. {e.Message}. {e.StackTrace}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"{e.Message}, {e.StackTrace}");
        }
        return result;
    }

    public static FileStream PromptInputFile()
    {
        while (true)
        {
            var inputFilePath = Input.GetString(Input.PredicateTrue, "Nhap duong dan file dau vao (input_file.txt): ");

            try
            {
                var fileStream = File.OpenRead(inputFilePath);
                return fileStream;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Khong tim thay file co duong dan '{e.FileName}'");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Duong dan qua dai. Vui long thu lai.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Chiu. Cha biet exception gi day: {e.Message}");
            }
        }

    }

    public static FileStream PromptOutputFile()
    {
        while (true)
        {
            var outputFilePath = Input.GetString(Input.PredicateTrue, "Nhap duong dan file dau ra (output_file.txt): ");

            try
            {
                var fileStream = File.OpenWrite(outputFilePath);
                return fileStream;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Khong tim thay thu muc cua duong dan '{outputFilePath}'. Loi chi tiet: {e.Message}.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Duong dan qua dai. Vui long thu lai.");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Khong co quyen truy cap '{outputFilePath}'. Chi tiet: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Chiu. Cha biet exception gi day: {e.Message}");
            }
        }

    }
}

