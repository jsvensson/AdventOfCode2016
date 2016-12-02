using System.IO;

namespace AdventOfCode
{
    public static class ProblemLoader
    {
        private const string DataDir = @"D:\Dev\AdventOfCode2016\data\";

        public static string Load(string fileName)
        {
            string filePath = DataDir + fileName;
            try
            {

                return File.ReadAllText(filePath);

            }
            catch (FileNotFoundException)
            {
                
                throw new FileNotFoundException($@"Input data {filePath} not found");
            }
        }
    }
}
