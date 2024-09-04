namespace LabWork1MatrixSumSub.ClassesLibrary;
public static class AutoCheck
{
    public static void Check(Matrix matrix1, Matrix matrix2, Matrix resultMatrix, int threadsCount)
    {
        Console.WriteLine("AutoCheck started");
        Console.WriteLine("Number of threads;Time ms;Acceleration; Effectiveness");
        float minTime = float.MaxValue;
        int optimalThreads = 0;
        Timer timer1 = new();
        timer1.Start();
        SequentialCalculation.SumMatrices(matrix1, matrix2, resultMatrix);
        timer1.Stop();
        Console.WriteLine($"1;{timer1.GetElapsedMilliseconds()} ms");
        float timeseq = timer1.GetElapsedMilliseconds();
        if (timer1.GetElapsedMilliseconds() < minTime)
        {
            minTime = timer1.GetElapsedMilliseconds();
            optimalThreads = 1;
        }
        for (int i = 2; i <= threadsCount; i++)
        {
            Timer timer = new();
            timer.Start();
            ParallelCalculations.SumMatrices(matrix1, matrix2, resultMatrix, i);
            timer.Stop();
            if (timer.GetElapsedMilliseconds() < minTime)
            {
                minTime = timer.GetElapsedMilliseconds();
                optimalThreads = i;
            }

            Console.WriteLine($"{i};{timer.GetElapsedMilliseconds()} ms;{timeseq / timer.GetElapsedMilliseconds()}x;{(timeseq / timer.GetElapsedMilliseconds()) / i}x");
        }
        Console.WriteLine($"Optimal number of threads: {optimalThreads}: {minTime} ms");
        Console.WriteLine("AutoCheck finished");
    }
}