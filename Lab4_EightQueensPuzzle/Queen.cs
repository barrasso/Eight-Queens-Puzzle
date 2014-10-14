using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Lab4_EightQueensPuzzle
{
    public class Queen
    {
        // Color flag
        public Brush queenColor;

        // Queen Position
        public Point queenCoords;

        public Queen(Brush color, Point queenPosition)
        {
            // set color
            this.queenColor = color;

            // set queen position to center to cell
            this.queenCoords = queenPosition;
        }
    }
}
