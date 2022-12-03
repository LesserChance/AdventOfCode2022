using System;
using System.Collections.Generic;
class DayOne {
    public DayOne(string filePath, bool partOne = true, bool partTwo = false) {
        if (partOne) runPartOne(filePath);
        if (partTwo) runPartTwo(filePath);
    }

    private string[] parseFile(string filePath) {
        return System.IO.File.ReadAllLines(filePath);
    }

    private void runPartOne(string filePath) {
        string[] lines = parseFile(filePath);
        List<int> elfCalories = new List<int>();
        elfCalories.Add(0);

        int currentElf = 0;
        int maxCalories = 0;

        foreach (string line in lines) {
            if (line.Equals("")) {
                if (elfCalories[currentElf] > maxCalories) {
                    maxCalories = elfCalories[currentElf];
                }
                elfCalories.Add(0);
                currentElf++;
            } else {
                elfCalories[currentElf] += int.Parse(line);
            }
        }

        Console.WriteLine("Day 1, part one: {0}", maxCalories);
    }

    private void runPartTwo(string filePath) {
        string[] lines = parseFile(filePath);
        List<int> elfCalories = new List<int>();
        elfCalories.Add(0);

        int currentElf = 0;

        foreach (string line in lines) {
            if (line.Equals("")) {
                elfCalories.Add(0);
                currentElf++;
            } else {
                elfCalories[currentElf] += int.Parse(line);
            }
        }

        elfCalories.Sort();
        elfCalories.Reverse();

        Console.WriteLine("Day 1, part two: {0}", (elfCalories[0] + elfCalories[1] + elfCalories[2]));
    }

}