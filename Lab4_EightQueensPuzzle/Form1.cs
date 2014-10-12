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
        // Holds all the chess board cells 
        public List<BoardCell> allCells = new List<BoardCell>();

        // Create array list to hold cell info
        public ArrayList cellInfoArray = new ArrayList();

        // Create array list to hold queens
        public ArrayList queenArray = new ArrayList();

        // Init brushes for cell color array
        public Brush[] cellColor = {Brushes.White, Brushes.Black};

        // Set border color and size
        public Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 2);

        // Set the board size (height and width)
        public int boardSize = 400;

        // Set board coordinates (x and y)
        public int boardPosition = 100;

        // Set size of cells
        public int cellSize = 50;

        // Safe flag
        public bool isSafe;

        public Form1()
        {
            InitializeComponent();

            // Set form title text
            this.Text = @"Eight Queens by Mark Barrasso";

            // Set queen number label text
            label1.Text = String.Format("You have {0} queens on the board", queenArray.Count);

            // Nested loop to create chess board
            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    // Cell color
                    Brush currentColor = cellColor[(row + col) % 2];

                    // Make cell to hold coords
                    Rectangle cell = new Rectangle(boardPosition + col * cellSize, boardPosition + row * cellSize, cellSize, cellSize);

                    // Instantiate board cell
                    BoardCell chessBoardCell = new BoardCell(cell, currentColor, row.col);
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Get graphics object
            Graphics g = e.Graphics;

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
                    g.FillRectangle(brush.cellColor, rect);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear the queens array
            this.queenArray.Clear();

            // Invalidate
            this.Invalidate();
        }
    }
}
