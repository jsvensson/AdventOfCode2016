namespace AdventOfCode.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Day01A();

            System.Console.WriteLine(test.Solve(ProblemLoader.Load("01.txt")));
        }
    }
}
