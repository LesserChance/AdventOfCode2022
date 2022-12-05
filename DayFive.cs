using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DayFive {

    class Utils {
        public static (List<string> stacksLines, List<string> movesLines) parseFile(string filePath) {
            string[] lines = System.IO.File.ReadAllLines(filePath);

            List<string> stacksLines = new List<string>();
            List<string> movesLines = new List<string>();

            // parse the lines into appropriate chunks
            bool populateStacks = true;
            foreach (string line in lines) {
                if (populateStacks) {
                    if (line == "") {
                        populateStacks = false;
                    } else {
                        stacksLines.Add(line);
                    }
                } else {
                    movesLines.Add(line);
                }
            }

            return (stacksLines, movesLines);
        }

        public static void printStacks(List<List<string>> stacks) {
            int j = 0;
            stacks.ForEach((stack) => {
                Console.WriteLine("stack {0}:", j);
                stack.ForEach(x => Console.WriteLine(x));
                j++;
            });
        }

        public static void makeMoves(List<string> movesLines, Action<int, int, int> move) {
            // do the moves
            string moveRegex = @"move (\d+) from (\d+) to (\d+)";

            movesLines.ForEach(line => {
                Match m = Regex.Match(line, moveRegex);
                if (m.Success) {
                    int count = int.Parse(m.Groups[1].Value);
                    int fromStackIndex = int.Parse(m.Groups[2].Value) - 1;
                    int toStackIndex = int.Parse(m.Groups[3].Value) - 1;
                    move(count, fromStackIndex, toStackIndex);
                }
            });
        }

        public static List<List<string>> getInitialStacks(List<string> stacksLines) {
            List<List<string>> stacks = new List<List<string>>();
            string[] stackCountLine = stacksLines[stacksLines.Count - 1].TrimEnd().Split(" ");
            int stackCount = int.Parse(stackCountLine[stackCountLine.Length - 1]);

            // initialize the empty stacks
            for (int i = 0; i < stackCount; i++) {
                stacks.Add(new List<string>());
            }

            // push the initial state onto the stacks
            stacksLines.ForEach(line => {
                if (line.Contains("[")) {
                    for (int i = 0; i < stackCount * 4; i += 4) {
                        int stackIndex = i / 4;
                        string pushChar = line.Substring(i + 1, 1).Trim();

                        if (pushChar != "") {
                            stacks[stackIndex].Insert(0, pushChar);
                        }
                    }
                }
            });

            return stacks;
        }
    }

    class PartOne {
        public PartOne(string filePath) {
            DateTime start = DateTime.Now;

            var lines = Utils.parseFile(filePath);
            List<string> stacksLines = lines.stacksLines;
            List<string> movesLines = lines.movesLines;

            List<List<string>> stacks = Utils.getInitialStacks(stacksLines);
            Utils.printStacks(stacks);

            Utils.makeMoves(movesLines, (int count, int fromStackIndex, int toStackIndex) => {
                while (count-- > 0) {
                    stacks[toStackIndex].Add(stacks[fromStackIndex][stacks[fromStackIndex].Count - 1]);
                    stacks[fromStackIndex].RemoveAt(stacks[fromStackIndex].Count - 1);
                }
            });
            string result = "";
            for (int i = 0; i < stacks.Count; i++) {
                result += stacks[i][stacks[i].Count - 1];
            }

            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", result);
            Console.WriteLine("took {0}", (DateTime.Now - start));
        }
    }

    class PartTwo {
        public PartTwo(string filePath) {
            DateTime start = DateTime.Now;

            var lines = Utils.parseFile(filePath);
            List<string> stacksLines = lines.stacksLines;
            List<string> movesLines = lines.movesLines;

            List<List<string>> stacks = Utils.getInitialStacks(stacksLines);
            Utils.printStacks(stacks);

            Utils.makeMoves(movesLines, (int count, int fromStackIndex, int toStackIndex) => {
                while (count-- > 0) {
                    stacks[toStackIndex].Add(stacks[fromStackIndex][stacks[fromStackIndex].Count - (count + 1)]);
                    stacks[fromStackIndex].RemoveAt(stacks[fromStackIndex].Count - (count + 1));
                }
            });
            string result = "";
            for (int i = 0; i < stacks.Count; i++) {
                result += stacks[i][stacks[i].Count - 1];
            }

            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", result);
            Console.WriteLine("took {0}", (DateTime.Now - start));
        }
    }
}