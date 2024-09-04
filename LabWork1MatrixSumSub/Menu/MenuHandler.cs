using LabWork1MatrixSumSub.ClassesLibrary;
namespace LabWork1MatrixSumSub.Menu;
public static class MenuHandler
{
    public static Matrix[] GenerateMatricesOptions()
    {
        Console.WriteLine("Enter the number of rows for the matrices:");
        int rows = int.TryParse(Console.ReadLine(), out int parsedRows) ? parsedRows : 1;
        Console.WriteLine("Enter the number of columns for the matrices:");
        int columns = int.TryParse(Console.ReadLine(), out int parsedColumns) ? parsedColumns : 1;
        Matrix matrix1 = new(rows, columns);
        Matrix matrix2 = new(rows, columns);
        Matrix resultMatrix = new(rows, columns);
        matrix1.FillMatrix();
        matrix2.FillMatrix();
        return [matrix1, matrix2, resultMatrix];
    }

    public static void WriteOptions()
    {
        Console.Clear();
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Sum matrices sequentially");
        Console.WriteLine("2. Subtract matrices sequentially");
        Console.WriteLine("3. Sum matrices in parallel");
        Console.WriteLine("4. Subtract matrices in parallel");
        Console.WriteLine("5. Write matrices");
        Console.WriteLine("6. AutoCheck");
    }

    public static int ReadOption()
    {
        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 6)
        {
            Console.WriteLine("Invalid input. Try again.");
            Console.ReadLine();
        }
        return option;
    }

    public static void WriteOutput(Matrix matrix1, Matrix matrix2, Matrix resultMatrix)
    {
        Console.WriteLine("Write output? (y/n)");
        if (Console.ReadLine()?.Equals("y", StringComparison.CurrentCultureIgnoreCase) == true)
        {
            OutputResult.PrintResult(matrix1, matrix2, resultMatrix);
        }
    }

    public static void HandleOption(int option, Matrix matrix1, Matrix matrix2, Matrix resultMatrix)
    {
        switch (option)
        {
            case 1:
                ClassesLibrary.Timer timer1 = new();
                timer1.Start();
                SequentialCalculation.SumMatrices(matrix1, matrix2, resultMatrix);
                timer1.Stop();
                Console.WriteLine($"Elapsed time: {timer1.GetElapsedMilliseconds} ms");
                WriteOutput(matrix1, matrix2, resultMatrix);
                break;
            case 2:
                ClassesLibrary.Timer timer2 = new();
                timer2.Start();
                SequentialCalculation.SubtractMatrices(matrix1, matrix2, resultMatrix);
                WriteOutput(matrix1, matrix2, resultMatrix);
                timer2.Stop();
                Console.WriteLine($"Elapsed time: {timer2.GetElapsedMilliseconds} ms");
                break;
            case 3:
                Console.WriteLine("Enter the number of threads:");
                int.TryParse(Console.ReadLine(), out int parsedThreadsCount3);
                ClassesLibrary.Timer timer3 = new();
                timer3.Start();
                ParallelCalculations.SumMatrices(matrix1, matrix2, resultMatrix, parsedThreadsCount3);
                timer3.Stop();
                Console.WriteLine($"Elapsed time: {timer3.GetElapsedMilliseconds} ms");
                WriteOutput(matrix1, matrix2, resultMatrix);
                break;
            case 4:
                Console.WriteLine("Enter the number of threads:");
                int.TryParse(Console.ReadLine(), out int parsedThreadsCount4);
                ClassesLibrary.Timer timer4 = new();
                timer4.Start();
                ParallelCalculations.SubtractMatrices(matrix1, matrix2, resultMatrix, parsedThreadsCount4);
                timer4.Stop();
                Console.WriteLine($"Elapsed time: {timer4.GetElapsedMilliseconds} ms");
                WriteOutput(matrix1, matrix2, resultMatrix);
                break;
            case 5:
                OutputResult.PrintStart(matrix1, matrix2);
                break;
            case 6:
                Console.WriteLine("Enter the maximum number of threads:");
                int.TryParse(Console.ReadLine(), out int parsedThreadsCount6);
                AutoCheck.Check(matrix1, matrix2, resultMatrix, parsedThreadsCount6);
                break;
        }
    }
}