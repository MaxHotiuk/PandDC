//use Thread to calculate sum of matrix elements (number of threads can be regulated by user)
namespace LabWork1MatrixSumSub.ClassesLibrary;
public static class ParallelCalculations
{
    public static Matrix SumMatrices(Matrix matrix1, Matrix matrix2, Matrix resultMatrix, int threadsCount)
    {
        Thread[] threads = new Thread[threadsCount];
        int currentRow = 0; // Shared row index

        object lockObj = new object(); // Lock object to synchronize row access

        for (int i = 0; i < threadsCount; i++)
        {
            threads[i] = new Thread(() =>
            {
                while (true)
                {
                    int row;
                    // Lock to safely increment and get the current row
                    lock (lockObj)
                    {
                        if (currentRow >= matrix1.Rows)
                            break;
                        row = currentRow++;
                    }

                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        resultMatrix.MatrixArray[row, k] = matrix1.MatrixArray[row, k] + matrix2.MatrixArray[row, k];
                    }
                }
            });
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }
        return resultMatrix;
    }

    public static Matrix SubtractMatrices(Matrix matrix1, Matrix matrix2, Matrix resultMatrix, int threadsCount)
    {
        Thread[] threads = new Thread[threadsCount];
        int currentRow = 0; // Shared row index

        object lockObj = new object(); // Lock object to synchronize row access

        for (int i = 0; i < threadsCount; i++)
        {
            threads[i] = new Thread(() =>
            {
                while (true)
                {
                    int row;
                    // Lock to safely increment and get the current row
                    lock (lockObj)
                    {
                        if (currentRow >= matrix1.Rows)
                            break;
                        row = currentRow++;
                    }

                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        resultMatrix.MatrixArray[row, k] = matrix1.MatrixArray[row, k] - matrix2.MatrixArray[row, k];
                    }
                }
            });
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }
        return resultMatrix;
    }
}