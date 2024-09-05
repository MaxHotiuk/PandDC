namespace LabWork2MatrixMult.ClassesLibrary;
public static class SequentialCalculation
{
    public static Matrix SumMatrices(Matrix matrix1, Matrix matrix2, Matrix resultMatrix)
    {
        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                resultMatrix.MatrixArray[i, j] = matrix1.MatrixArray[i, j] + matrix2.MatrixArray[i, j];
            }
        }
        return resultMatrix;
    }
    
    public static Matrix SubtractMatrices(Matrix matrix1, Matrix matrix2, Matrix resultMatrix)
    {
        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                resultMatrix.MatrixArray[i, j] = matrix1.MatrixArray[i, j] - matrix2.MatrixArray[i, j];
            }
        }
        return resultMatrix;
    }

    public static Matrix MultiplyMatrices(Matrix matrix1, Matrix matrix2, Matrix resultMatrix)
    {
        if (matrix1.Columns != matrix2.Rows)
        {
            throw new InvalidOperationException("The number of columns in the first matrix must match the number of rows in the second matrix.");
        }

        // Initialize result matrix dimensions
        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix2.Columns; j++)
            {
                resultMatrix.MatrixArray[i, j] = 0; // Initialize each element to 0

                for (int k = 0; k < matrix1.Columns; k++)
                {
                    // Multiply and accumulate the values
                    resultMatrix.MatrixArray[i, j] += matrix1.MatrixArray[i, k] * matrix2.MatrixArray[k, j];
                }
            }
        }

        return resultMatrix;
    }
}