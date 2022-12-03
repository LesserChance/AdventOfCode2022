using System;
using System.Collections.Generic;
namespace DayTemplate
{

    class PartOne
    {

        public PartOne(string filePath)
        {
            string[] lines = parseFile(filePath);
            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", "");
        }

        private string[] parseFile(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath);
        }
    }
    class PartTwo
    {

        public PartTwo(string filePath)
        {
            string[] lines = parseFile(filePath);
            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", "");
        }

        private string[] parseFile(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath);
        }
    }


}