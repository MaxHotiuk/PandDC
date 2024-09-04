namespace LabWork1MatrixSumSub.ClassesLibrary;
public static class OutputResult
{
    public static void PrintResult(Matrix matrix1, Matrix matrix2, Matrix resultMatrix)
    {
        Console.Clear();
        Console.WriteLine("Matrix 1:");
        matrix1.PrintMatrix();
        Console.WriteLine("Matrix 2:");
        matrix2.PrintMatrix();
        Console.WriteLine("Result matrix:");
        resultMatrix.PrintMatrix();
    }
    public static void PrintStart(Matrix matrix1, Matrix matrix2)
    {
        Console.Clear();
        Console.WriteLine("Matrix 1:");
        matrix1.PrintMatrix();
        Console.WriteLine("Matrix 2:");
        matrix2.PrintMatrix();
    }
}