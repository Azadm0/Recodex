namespace ConsoleApp2;

internal class Homework1
{
    static void Main()
    {
        List<string> read = new List<string>();
        string? line;

        while ((line = Console.ReadLine()) != null)
        {
            read.Add(line);
        }
        int rows = read.Count;
        int columns = read[0].Length;
        char[,] grid = new char[rows, columns];
        double[,] possibility = new double[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                grid[i, j] = read[i][j];

                if (grid[i, j] == 'g')
                    possibility[i, j] = 1.0;
                else
                    possibility[i, j] = 0.0;
            }
        }
        while (true)
        {
            double maxdiff = 0;
            double[,] copy = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    if (grid[i, j] == 'g')
                    {
                        copy[i, j] = 1.0;
                        continue;
                    }

                    if (grid[i, j] == 'h')
                    {
                        copy[i, j] = 0.0;
                        continue;
                    }
                    double sum = 0;
                    int count = 0;


                    if (i > 0)
                    {
                        sum += possibility[i - 1, j];
                        count++;
                    }
                    if (i < rows - 1)
                    {
                        sum += possibility[i + 1, j];
                        count++;
                    }
                    if (j > 0)
                    {
                        sum += possibility[i, j - 1];
                        count++;
                    }
                    if (j < columns - 1)
                    {
                        sum += possibility[i, j + 1];
                        count++;
                    }

                    double averg = sum / count;
                    copy[i, j] = averg;


                    double diff = Math.Abs(averg - possibility[i, j]);
                    if (diff > maxdiff)
                        maxdiff = diff;
                }
            }
            possibility = copy;
            if (maxdiff < 0.000001)
                break;
        }
        Console.WriteLine($"{possibility[0, 0]:F3}");
    }
}

