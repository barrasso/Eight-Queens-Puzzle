using System;
using System.Collections;
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
        // Create array list to hold cells
        public ArrayList cellArray = new ArrayList();

        // Create array list to hold queens
        public ArrayList queenArray = new ArrayList();

        // Init brushes for cell color array
        Brush[] cellColor = {Brushes.White, Brushes.Black};

        // Set border color and size
        Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 2);

        // Set the board size (height and width)
        int boardSize = 400;

        // Set board coordinates (x and y)
        int boardPosition = 100;

        public Form1()
        {
            InitializeComponent();

            // Set form title text
            this.Text = @"Eight Queens by Mark Barrasso";

            // Set queen number label text
            label1.Text = String.Format("You have {0} queens on the board", queenArray.Count);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Get graphics object
            Graphics g = e.Graphics;

            // Set size of cells
            int cellSize = boardSize / 8;

            // Nested loop to create chess board
            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    // Make rectangle with black border
                    Rectangle rect = new Rectangle(boardPosition + col * cellSize, boardPosition + row * cellSize, cellSize, cellSize);

                    // Make rectangle with black border
                    g.DrawRectangle(blackPen, rect);

                    // Fill rectangles with alernating colors (white and black)
                    g.FillRectangle(cellColor[(row + col) % 2], rect);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear the queens
            this.queenArray.Clear();

            // Invalidate
            this.Invalidate();
        }
    }
}
