using System;
using System.Collections.Generic;
namespace DayThree {

    class PartOne {

        public PartOne(string filePath) {
            string[] lines = parseFile(filePath);

            int totalPriority = 0;
            foreach (string line in lines) {
                int halfIndex = line.Length / 2;
                string secondCompartment = line.Substring(halfIndex);

                for (int i = 0; i < halfIndex; i++) {
                    if (secondCompartment.Contains(line[i])) {
                        int asciiVal = (int)line[i];
                        if (asciiVal <= 90) {
                            asciiVal -= 38;
                        } else {
                            asciiVal -= 96;
                        }

                        totalPriority += asciiVal;

                        // Console.WriteLine("{0}: {1}, {2}", i, line[i], asciiVal);
                        break;
                    }
                }
            }

            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", totalPriority);
        }

        private string[] parseFile(string filePath) {
            return System.IO.File.ReadAllLines(filePath);
        }
    }
    class PartTwo {

        public PartTwo(string filePath) {
            string[] lines = parseFile(filePath);

            int totalPriority = 0;
            for (int i = 0; i < lines.Length; i += 3) {
                string lineOne = lines[i];
                string lineTwo = lines[i + 1];
                string lineThree = lines[i + 2];

                for (int j = 0; j < lineOne.Length; j++) {
                    char currentChar = lineOne[j];
                    if (lineTwo.Contains(currentChar) && lineThree.Contains(currentChar)) {
                        int asciiVal = (int)currentChar;
                        if (asciiVal <= 90) {
                            asciiVal -= 38;
                        } else {
                            asciiVal -= 96;
                        }

                        totalPriority += asciiVal;

                        // Console.WriteLine("{0}: {1}, {2}", i, currentChar, asciiVal);
                        break;
                    }
                }
            }

            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", totalPriority);
        }

        private string[] parseFile(string filePath) {
            return System.IO.File.ReadAllLines(filePath);
        }
    }


}