using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Lab4_EightQueensPuzzle
{
    public class BoardCell
    {
        // Cell row and column and diaganol
        public int rowNumber;
        public int colNumber;

        // Cell origin coords
        public Point cellOrigin;

        // Cell center coords
        public Point cellCenter;
        
        // Cell color
        public Brush cellColor;

        // Default flag to true
        public bool isSafe = true;

        // Default constructor
        public BoardCell(Rectangle cell, Brush color, int row,int column)
        {
            // The point in the center of the cell
            this.cellCenter = new Point(cell.X + 25, cell.Y + 25);

            // Set coords for origin
            this.cellOrigin = new Point(cell.X, cell.Y);

            // Set cell color
            this.cellColor = color;

            // Set cell labels
            this.rowNumber = row;
            this.colNumber = column;
        }
    }
}
