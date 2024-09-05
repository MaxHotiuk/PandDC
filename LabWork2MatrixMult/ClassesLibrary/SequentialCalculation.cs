namespace LabWork2MatrixMult.ClassesLibrary;
public static class SequentialCalculation
{
    public static Matrix MultiplyMatrices(Matrix matrix1, Matrix matrix2, Matrix resultMatrix)
    {
        if (matrix1.Columns != matrix2.Rows)
        {
            throw new InvalidOperationException("The number of columns in the first matrix must match the number of rows in the second matrix.");
        }

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix2.Columns; j++)
            {
                resultMatrix.MatrixArray[i, j] = 0;

                for (int k = 0; k < matrix1.Columns; k++)
                {
                    resultMatrix.MatrixArray[i, j] += matrix1.MatrixArray[i, k] * matrix2.MatrixArray[k, j];
                }
            }
        }

        return resultMatrix;
    }
}