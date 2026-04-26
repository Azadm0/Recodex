//COMBINATORIAL RECURSION

//strings of length of 2

//using System.Net.NetworkInformation;
////prefix
//void go(string prefix)
//{
//    if (prefix.Length == 4)
//        Console.WriteLine(prefix);
//    else
//    {
//        foreach ( char c in "abcd")
//        {
//            go(prefix + c);
//        }

//    }
//}
//go("");

//stack
using System.Runtime.CompilerServices;
using System.Transactions;
//using System.Xml.Schema;

//Stack<char> stack = new();
//void go(int i)
//{
//    if (i ==3)
//    {
//        Console.WriteLine(string.Join("", stack.Reverse()));
//    }
//    else
//    {
//        foreach (char c in "abc")
//        {
//            stack.Push(c);
//            go(i + 1);
//            stack.Pop();
//        }
//    }
//}
//go(0);

//NOTES:
//there are 3 way of using combinatorial recursion:
//    1. prefix:
//    go(prefix + c); simple,copies data (inefficient)

//    2. stack/list:
//    push then go then pop; efficient, used in many problems (BEST)

//    3. array (fastest):
//    a[i] = value;
//    go(i + 1); notcopying , clean for fixed size

//also backtracking:
//    make choice -> explore -> undo
//    EXAMPLE:
//    stack.Push(some variable);
//    go();
//    stack.Pop();

//TIME COMPLEXITY:
// for strings : lets say abc -> O(3^n)
// subsets: O(2^n)
// permutations: O(N!)
// coin problems: exponential



//CORE TEMPLATE
//if (done)
//    print
//else
//    for each choice:
//        make choice
//        recurse
//        undo


//PROBLEM 1:
//void go(string prefix)
//{
//    if (prefix.Length == 3)
//    {
//        Console.WriteLine(prefix);

//    }
//    else
//    {
//        foreach ( char c in "01")
//        {
//            go(prefix + c);
//        }
//    }
//}
//go("");

//PROBLEM 2
//void go(string prefix, int i)
//{
//    if (i > 3)
//    {
//        Console.WriteLine("{" + prefix + "}");
//    }
//    else
//    {
//        go(prefix + i+ " ", i + 1);
//        go(prefix, i + 1);
//    }
//}
//go("",1);

//PROBLEM3:
//int[] coins = { 1, 2 };

//void go(int rem, List<int> current)
//{
//    if (rem == 0)
//    {
//        Console.WriteLine(string.Join(" + ", current));
//    }
//    else
//    {
//        foreach (int c in coins)
//        {
//            if (c <= rem)
//            {
//                current.Add(c);
//                go(rem - c, current);
//                current.RemoveAt(current.Count - 1);
//            }
//        }

//    }
//}
//go(3, []);


//int n = 3;
//int[] perm = new int[n];
//bool[] used = new bool[n + 1]; // numbers 1..n

//void go(int pos)
//{
//    if (pos == n)
//    {
//        Console.WriteLine(string.Join(" ", perm));
//        return;
//    }

//    for (int x = 1; x <= n; x++)
//    {
//        if (!used[x] && x != pos + 1) // 🔥 key condition
//        {
//            used[x] = true;
//            perm[pos] = x;

//            go(pos + 1);

//            used[x] = false; // undo
//        }
//    }
//}
//go(0);


//RANDOM DERANGEMENT
//void derange(string s)
//{
//    int n = s.Length;
//    char[] result = new char[n];
//    bool[] used = new bool[n];

//    void go(int pos)
//    {
//        if (pos == n)
//        {
//            Console.WriteLine(new string(result));
//            return;
//        }

//        for (int i = 0; i < n; i++)
//        {
//            // ❗ key condition
//            if (!used[i] && s[i] != s[pos])
//            {
//                used[i] = true;
//                result[pos] = s[i];

//                go(pos + 1);

//                used[i] = false; // backtrack
//            }
//        }
//    }

//    go(0);
//}


//PERFECT SQUARE DYNAMIC PROGRAMMING

//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main(string[] args)
//    {
//        int N = int.Parse(args[0]);

//        int[] dp = new int[N + 1];
//        int[] prev = new int[N + 1]; // to reconstruct solution

//        // initialize
//        for (int i = 1; i <= N; i++)
//            dp[i] = int.MaxValue;

//        dp[0] = 0;

//        // DP
//        for (int i = 1; i <= N; i++)
//        {
//            for (int j = 1; j * j <= i; j++)
//            {
//                int square = j * j;

//                if (dp[i - square] + 1 < dp[i])
//                {
//                    dp[i] = dp[i - square] + 1;
//                    prev[i] = square;
//                }
//            }
//        }

//        // reconstruct answer
//        List<int> result = new List<int>();

//        int cur = N;
//        while (cur > 0)
//        {
//            result.Add(prev[cur]);
//            cur -= prev[cur];
//        }

//        result.Sort(); // increasing order

//        Console.WriteLine(string.Join(" + ", result));
//    }
//}

class Program
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