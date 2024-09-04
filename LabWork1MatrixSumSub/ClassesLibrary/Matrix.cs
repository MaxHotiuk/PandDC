namespace LabWork1MatrixSumSub.ClassesLibrary;
public class Matrix(int rows, int columns)
{
    public int[,] MatrixArray { get; set; } = new int[rows, columns];

    public int Rows { get; set; } = rows;

    public int Columns { get; set; } = columns;

    public void FillMatrix()
    {
        Random random = new();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                MatrixArray[i, j] = random.Next(0, 10);
            }
        }
    }

    public void PrintMatrix()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Console.Write(MatrixArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void FillZero()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                MatrixArray[i, j] = 0;
            }
        }
    }
}