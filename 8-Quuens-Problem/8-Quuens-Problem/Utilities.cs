using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Quuens_Problem
{
    public class Utilities
    {
        protected int heuristic;
        public Utilities() { }


        public int GetHeuristic()
        {
            return heuristic;
        }
        //Heuristic is getting bigger each time two pieces are in the same row/are sharing the same diagonal line
        public int CountHeuristic(int[] chessboard)
        {
            int heuristic = 0;

            for (int i = 0; i < chessboard.Length; i++)
            {
                for (int j = i + 1; j < chessboard.Length; j++)
                {
                    if (chessboard[i] == chessboard[j] || Math.Abs(chessboard[i] - chessboard[j]) == j - i)
                        heuristic += 1;
                }
            }
            return heuristic;
        }


        protected bool ArrayNotChanged(int[] firstA, int[] secondA)
        {
            for (int i = 0; i < firstA.Length; i++)
            {
                if (firstA[i] != secondA[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
