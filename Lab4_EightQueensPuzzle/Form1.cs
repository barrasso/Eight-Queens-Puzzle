using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_EightQueensPuzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set form title text
            this.Text = @"Eight Queens by Mark Barrasso";

            // Set background color of form
            this.BackColor = Color.Gray;
        }

        // Init brushes for cell color array
        Brush[] cellColor = {Brushes.Black, Brushes.White};

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Set the board size (height and width)
            int boardSize = 400;

            // Set board coordinates (x and y)
            int boardPosition = 100;

            // Set size of cells
            int cellSize = boardSize / 8;

            // Get graphics object
            Graphics g = e.Graphics;

            // Nested loop to create chess board
            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row ++)
                {
                    // Fill rectangles with alernating colors, with each cell 1/8th of the board's size
                    g.FillRectangle(cellColor[(col + row) % 2], boardPosition + col * cellSize, boardPosition + row * cellSize, cellSize, cellSize);
                }
            }
        }
    }
}
