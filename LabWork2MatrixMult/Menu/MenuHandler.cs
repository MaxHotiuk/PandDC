using LabWork2MatrixMult.ClassesLibrary;
namespace LabWork2MatrixMult.Menu;
public static class MenuHandler
{
    public static Matrix[] GenerateMatricesOptions()
    {
        Console.WriteLine("Enter the number of columps for the matrice 1 (will apply as row count for 2-nd matrice):");
        int columns1rows2 = int.TryParse(Console.ReadLine(), out int parsedRows) ? parsedRows : 1;
        Console.WriteLine("Enter the number of rows for the matrice 1:");
        int rows1 = int.TryParse(Console.ReadLine(), out int parsedRows1) ? parsedRows1 : 1;
        Console.WriteLine("Enter the number of columns for the matrice 2:");
        int columns2 = int.TryParse(Console.ReadLine(), out int parsedColumns2) ? parsedColumns2 : 1;
        Matrix matrix1 = new(rows1, columns1rows2);
        Matrix matrix2 = new(columns1rows2, columns2);
        Matrix resultMatrix = new(rows1, columns2);
        matrix1.FillMatrix();
        matrix2.FillMatrix();
        return [matrix1, matrix2, resultMatrix];
    }

    public static void WriteOptions()
    {
        Console.Clear();
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Multiplicate matrices sequentially");
        Console.WriteLine("2. Multiplicate matrices in parallel");
        Console.WriteLine("3. Write matrices");
        Console.WriteLine("4. AutoCheck");
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
                SequentialCalculation.MultiplyMatrices(matrix1, matrix2, resultMatrix);
                timer1.Stop();
                Console.WriteLine($"Elapsed time: {timer1.GetElapsedMilliseconds()} ms");
                WriteOutput(matrix1, matrix2, resultMatrix);
                break;
            case 2:
                Console.WriteLine("Enter the number of threads:");
                int.TryParse(Console.ReadLine(), out int parsedThreadsCount3);
                ClassesLibrary.Timer timer3 = new();
                timer3.Start();
                ParallelCalculations.MultiplyMatrices(matrix1, matrix2, resultMatrix, parsedThreadsCount3);
                timer3.Stop();
                Console.WriteLine($"Elapsed time: {timer3.GetElapsedMilliseconds()} ms");
                WriteOutput(matrix1, matrix2, resultMatrix);
                break;
            case 3:
                OutputResult.PrintStart(matrix1, matrix2);
                break;
            case 4:
                Console.WriteLine("Enter the maximum number of threads:");
                int.TryParse(Console.ReadLine(), out int parsedThreadsCount6);
                AutoCheck.Check(matrix1, matrix2, resultMatrix, parsedThreadsCount6);
                break;
        }
    }
}