namespace LabWork2MatrixMult.ClassesLibrary;
public static class ParallelCalculations
{
    public static Matrix MultiplyMatrices(Matrix matrix1, Matrix matrix2, Matrix resultMatrix, int threadsCount)
    {
        if (matrix1.Columns != matrix2.Rows)
        {
            throw new InvalidOperationException("The number of columns in the first matrix must match the number of rows in the second matrix.");
        }

        Thread[] threads = new Thread[threadsCount];
        int currentRow = 0;

        object lockObj = new object();

        for (int i = 0; i < threadsCount; i++)
        {
            threads[i] = new Thread(() =>
            {
                while (true)
                {
                    int row;
                    lock (lockObj)
                    {
                        if (currentRow >= matrix1.Rows)
                            break;
                        row = currentRow++;
                    }

                    for (int col = 0; col < matrix2.Columns; col++)
                    {
                        int sum = 0;
                        for (int k = 0; k < matrix1.Columns; k++)
                        {
                            sum += matrix1.MatrixArray[row, k] * matrix2.MatrixArray[k, col];
                        }
                        resultMatrix.MatrixArray[row, col] = sum;
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
    public static Matrix SumMatrices(Matrix matrix1, Matrix matrix2, Matrix resultMatrix, int threadsCount)
    {
        Thread[] threads = new Thread[threadsCount];
        int currentRow = 0;

        object lockObj = new object();

        for (int i = 0; i < threadsCount; i++)
        {
            threads[i] = new Thread(() =>
            {
                while (true)
                {
                    int row;
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
        int currentRow = 0;

        object lockObj = new object();

        for (int i = 0; i < threadsCount; i++)
        {
            threads[i] = new Thread(() =>
            {
                while (true)
                {
                    int row;
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