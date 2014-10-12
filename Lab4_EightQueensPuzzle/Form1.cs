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

        // Create list to hold queens
        public List<Queen> allQueens = new List<Queen>();

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
            label1.Text = String.Format("You have {0} queens on the board", this.allQueens.Count);

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
                    BoardCell chessBoardCell = new BoardCell(cell, currentColor, row, col);

                    // Add chess board cell to list
                    this.allCells.Add(chessBoardCell);
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Get graphics object
            Graphics g = e.Graphics;

            for (int i = 0; i < this.allQueens.Count; i++ )
            {
                Queen currentQueen = this.allQueens[i];

                Font drawFont = new Font("Arial", 30);

                g.DrawString("Q", drawFont, new SolidBrush(Color.Green), 100, 50);
            }

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
            // Clear the queens array
            this.allQueens.Clear();

            label1.Text = String.Format("You have {0} queens on the board", this.allQueens.Count);

            // Invalidate
            this.Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {

                foreach (BoardCell cell in this.allCells)
                {
                    // mouse click coords
                    Point mouseClick = new Point(e.X, e.Y);

                    // Figure out which cell was clicked
                    if ((mouseClick.X > cell.cellOrigin.X) && (mouseClick.X < cell.cellOrigin.X + 50) && (mouseClick.Y > cell.cellOrigin.Y) && (mouseClick.Y < cell.cellOrigin.Y + 50))
                    {
                        // if cell is not safe
                        if (cell.isSafe == false)
                        {
                            // Beep
                            System.Media.SystemSounds.Beep.Play();
                        }

                        // check if the cell is safe
                        if (cell.isSafe)
                        {
                            if (cell.cellColor == Brushes.Black)
                            {
                                // Add a black queen to array 
                                Queen newQueen = new Queen(Brushes.White, cell.cellOrigin);
                                this.allQueens.Add(newQueen);

                                // Mark not safe  and figure out how to mark row and column safe too
                                cell.isSafe = false;

                                label1.Text = String.Format("You have {0} queens on the board", this.allQueens.Count);
                            }

                            if ((cell.cellColor == Brushes.White))
                            {
                                // Add a white queen to array
                                Queen newQueen = new Queen(Brushes.Black, cell.cellOrigin);
                                this.allQueens.Add(newQueen);

                                // Make not safe
                                cell.isSafe = false;

                                label1.Text = String.Format("You have {0} queens on the board", this.allQueens.Count);
                            }
                        }
                    }
                }

                // Must invalidate
                this.Invalidate();
            }

        }
    }
}
