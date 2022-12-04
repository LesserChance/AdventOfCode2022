using System;
using System.Collections.Generic;
namespace DayFour {

    class PartOne {
        public PartOne(string filePath) {
            DateTime start = DateTime.Now;
            string[] lines = parseFile(filePath);

            int fullyContained = 0;
            foreach (string line in lines) {
                string[] sections = line.Split(",");
                string[] sectionOneMinMax = sections[0].Split("-");
                string[] sectionTwoMinMax = sections[1].Split("-");

                int sectionOneMin = int.Parse(sectionOneMinMax[0]);
                int sectionOneMax = int.Parse(sectionOneMinMax[1]);
                int sectionTwoMin = int.Parse(sectionTwoMinMax[0]);
                int sectionTwoMax = int.Parse(sectionTwoMinMax[1]);

                if ((sectionOneMin <= sectionTwoMin && sectionOneMax >= sectionTwoMax) ||
                    (sectionTwoMin <= sectionOneMin && sectionTwoMax >= sectionOneMax)) {
                    fullyContained++;
                }
            }

            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", fullyContained);
            Console.WriteLine("took {0}", (DateTime.Now - start));
        }

        private string[] parseFile(string filePath) {
            return System.IO.File.ReadAllLines(filePath);
        }
    }

    class PartTwo {
        public PartTwo(string filePath) {
            DateTime start = DateTime.Now;
            string[] lines = parseFile(filePath);

            int hasOverlap = 0;
            foreach (string line in lines) {
                string[] sections = line.Split(",");
                string[] sectionOneMinMax = sections[0].Split("-");
                string[] sectionTwoMinMax = sections[1].Split("-");

                int sectionOneMin = int.Parse(sectionOneMinMax[0]);
                int sectionOneMax = int.Parse(sectionOneMinMax[1]);
                int sectionTwoMin = int.Parse(sectionTwoMinMax[0]);
                int sectionTwoMax = int.Parse(sectionTwoMinMax[1]);

                if (
                    // section one min in range
                    (sectionOneMin >= sectionTwoMin && sectionOneMin <= sectionTwoMax) ||
                    // section two min in range
                    (sectionTwoMin >= sectionOneMin && sectionTwoMin <= sectionOneMax)) {
                    hasOverlap++;
                }
            }

            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", hasOverlap);
            Console.WriteLine("took {0}", (DateTime.Now - start));
        }

        private string[] parseFile(string filePath) {
            return System.IO.File.ReadAllLines(filePath);
        }
    }
}