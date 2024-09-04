namespace LabWork1MatrixSumSub.ClassesLibrary;
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
}