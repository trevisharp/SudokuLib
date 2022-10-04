using System.Text;

namespace SudokuLib;

using Internal;

public class Sudoku
{
    public static Sudoku New(DifficultyLevel level)
    {
        SudokuBuilder builder = new SudokuBuilder();
        return builder.Build(level);
    }

    private byte[] data = new byte[41];

    private byte get(int i, int j)
    {
        int index = 9 * j + i;
        byte value = data[index / 2];
        if (index % 2 == 0)
            return (byte)(value % 16);
        return (byte)(value >> 4);
    }

    private void set(int i, int j, byte newValue)
    {
        int index = 9 * j + i;
        byte value = data[index / 2];
        if (index % 2 == 0)
        {
            value &= 240;
            value += newValue;
            data[index / 2] = value;
        }
        else
        {
            value &= 15;
            value += (byte)(newValue << 4);
            data[index / 2] = value;
        }
    }

    public int this[int i, int j]
    {
        get => get(i, j);
        set => set(i, j, (byte)value);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("┌─┬─┬─┬─┬─┬─┬─┬─┬─┐\n");
        for (int j = 0; j < 9; j++)
        {
            for (int i = 0; i < 9; i++)
            {
                var numero = this[i, j];
                var str = numero == 0 
                    ? " " : numero.ToString();
                sb.Append($"│{str}");
            }
            if (j == 8)
                sb.Append("|\n└─┴─┴─┴─┴─┴─┴─┴─┴─┘\n");
            else sb.Append("|\n├─┼─┼─┼─┼─┼─┼─┼─┼─┤\n");
        }
        return sb.ToString();
    }
}