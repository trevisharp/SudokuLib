using System;
using System.Collections.Generic;

namespace SudokuLib.Internal;

internal class SudokuBuilder
{
    static Random rand = null;
    static SudokuBuilder()
    {
        rand = new Random(DateTime.Now.Millisecond);
    }

    public Sudoku Build(DifficultyLevel level)
    {
        Sudoku sudoku = new Sudoku();
        
        throw new NotImplementedException();
    }

    private int nextExcept(List<int> exceptList, Random rand)
    {
        int value = rand.Next(1, 10);
        while (exceptList.Contains(value))
        {
            value++;
            if (value == 10)
                value = 1;
        }
        return value;
    }
}