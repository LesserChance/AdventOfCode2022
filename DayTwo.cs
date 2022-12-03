using System;
using System.Collections.Generic;

public static class opponentMoves {
    public const string ROCK = "A";
    public const string PAPER = "B";
    public const string SCISSORS = "C";
}

public static class selfMoves {
    public const string ROCK = "X";
    public const string PAPER = "Y";
    public const string SCISSORS = "Z";
}

public static class selfOutcomes {
    public const string LOSE = "X";
    public const string DRAW = "Y";
    public const string WIN = "Z";
}


namespace DayTwo {

    class PartOne {
        public PartOne(string filePath) {
            string[] lines = parseFile(filePath);
            int score = 0;

            foreach (string line in lines) {
                string[] moves = line.Split(' ');
                bool? selfWon = determineWinner(moves[0], moves[1]);

                if (selfWon == true) {
                    score += 6;
                } else if (selfWon == false) {
                    score += 0;
                } else {
                    score += 3;
                }

                switch (moves[1]) {
                    case selfMoves.ROCK:
                        score += 1;
                        break;
                    case selfMoves.PAPER:
                        score += 2;
                        break;
                    case selfMoves.SCISSORS:
                        score += 3;
                        break;
                }
            }

            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", score);
        }

        private bool? determineWinner(string opponentMove, string selfMove) {
            switch (opponentMove) {
                case opponentMoves.ROCK:
                    switch (selfMove) {
                        case selfMoves.PAPER:
                            return true;
                        case selfMoves.SCISSORS:
                            return false;
                    }
                    break;

                case opponentMoves.PAPER:
                    switch (selfMove) {
                        case selfMoves.SCISSORS:
                            return true;
                        case selfMoves.ROCK:
                            return false;
                    }
                    break;

                case opponentMoves.SCISSORS:
                    switch (selfMove) {
                        case selfMoves.ROCK:
                            return true;
                        case selfMoves.PAPER:
                            return false;
                    }
                    break;
            }

            // this is a draw
            return null;
        }

        private string[] parseFile(string filePath) {
            return System.IO.File.ReadAllLines(filePath);
        }
    }

    class PartTwo {
        private string[] parseFile(string filePath) {
            return System.IO.File.ReadAllLines(filePath);
        }

        private string determineMove(string opponentMove, string selfOutcome) {
            switch (opponentMove) {
                case opponentMoves.ROCK:
                    switch (selfOutcome) {
                        case selfOutcomes.WIN:
                            return selfMoves.PAPER;
                        case selfOutcomes.LOSE:
                            return selfMoves.SCISSORS;
                        case selfOutcomes.DRAW:
                            return selfMoves.ROCK;
                    }
                    break;

                case opponentMoves.PAPER:
                    switch (selfOutcome) {
                        case selfOutcomes.WIN:
                            return selfMoves.SCISSORS;
                        case selfOutcomes.LOSE:
                            return selfMoves.ROCK;
                        case selfOutcomes.DRAW:
                            return selfMoves.PAPER;
                    }
                    break;

                case opponentMoves.SCISSORS:
                    switch (selfOutcome) {
                        case selfOutcomes.WIN:
                            return selfMoves.ROCK;
                        case selfOutcomes.LOSE:
                            return selfMoves.PAPER;
                        case selfOutcomes.DRAW:
                            return selfMoves.SCISSORS;
                    }
                    break;
            }

            return null;
        }

        public PartTwo(string filePath) {
            string[] lines = parseFile(filePath);
            int score = 0;

            foreach (string line in lines) {
                string[] moves = line.Split(' ');
                string selfMove = determineMove(moves[0], moves[1]);

                switch (moves[1]) {
                    case selfOutcomes.WIN:
                        score += 6;
                        break;
                    case selfOutcomes.LOSE:
                        score += 0;
                        break;
                    case selfOutcomes.DRAW:
                        score += 3;
                        break;
                }

                switch (selfMove) {
                    case selfMoves.ROCK:
                        score += 1;
                        break;
                    case selfMoves.PAPER:
                        score += 2;
                        break;
                    case selfMoves.SCISSORS:
                        score += 3;
                        break;
                }
            }

            Console.WriteLine(this.GetType().Namespace + ", " + this.GetType().Name + ": {0}", score);
        }
    }
}