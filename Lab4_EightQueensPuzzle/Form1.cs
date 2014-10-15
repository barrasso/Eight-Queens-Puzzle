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

        // Create list to hold queens
        public List<Queen> allQueens = new List<Queen>();

        // Init brushes for cell color array
        public Brush[] cellColor = {Brushes.White, Brushes.Black};

        // Set border color and size
        public Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 2);

        // Hint checkbox flag
        public bool isHintsChecked;

        // Set the board size (height and width)
        public int boardSize = 400;

        // Set board coordinates (x and y)
        public int boardPosition = 100;

        // Set size of cells
        public int cellSize = 50;

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

            // Nested loop to create chess board (Normal chess board)
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

            // if the hint box is checked
            if(isHintsChecked)
            {
                // Nested loop to create chess board (Hints chess board)
                foreach (BoardCell cell in this.allCells)
                {
                    //check for queens
                    this.checkForQueens(cell);

                    if(cell.isSafe == false)
                    {
                        g.DrawRectangle(blackPen, cell.cellOrigin.X, cell.cellOrigin.Y, cellSize, cellSize);
                        g.FillRectangle(Brushes.Red, cell.cellOrigin.X,  cell.cellOrigin.Y, cellSize, cellSize);
                    }
                }
            }

            // Draw Queens
            foreach (Queen queen in this.allQueens)
            {
                // Custom Font
                Font drawFont = new Font("Arial", 30, FontStyle.Bold);

                // Draw Queen
                if (isHintsChecked) g.DrawString("Q", drawFont, Brushes.Black, queen.queenCoords);
                if (!isHintsChecked) g.DrawString("Q", drawFont, queen.queenColor, queen.queenCoords);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear the queens array
            this.allQueens.Clear();

            // update label
            label1.Text = String.Format("You have {0} queens on the board", this.allQueens.Count);

            // For each board cell, set to safe again
            foreach (BoardCell cell in this.allCells)
            {
                cell.isSafe = true;
            }

            // Invalidate
            this.Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                foreach (BoardCell cell in this.allCells)
                {
                    //check for queens
                    this.checkForQueens(cell);

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

                                //check for queens
                                this.checkForQueens(cell);

                                // If there are 8 queens, display winning message
                                if(this.allQueens.Count == 8)
                                {
                                    // Show winning messages
                                    MessageBox.Show(@"You did it!");
                                }

                                // update label
                                label1.Text = String.Format("You have {0} queens on the board", this.allQueens.Count);
                            }

                            if ((cell.cellColor == Brushes.White))
                            {
                                // Add a white queen to array
                                Queen newQueen = new Queen(Brushes.Black, cell.cellOrigin);
                                this.allQueens.Add(newQueen);

                                //check for queens
                                this.checkForQueens(cell);

                                // If there are 8 queens, display winning message
                                if (this.allQueens.Count == 8)
                                {
                                    // Show winning messages
                                    MessageBox.Show(@"You did it!");
                                }

                                // update label
                                label1.Text = String.Format("You have {0} queens on the board", this.allQueens.Count);
                            }
                        }
                    }
                }

                // Must invalidate
                this.Invalidate();
            }

            // If right click
            if(e.Button == MouseButtons.Right)
            {
                // mouse click coords
                Point mouseClick = new Point(e.X, e.Y);

                foreach (BoardCell cell in this.allCells)
                {
                    if ((mouseClick.X > cell.cellOrigin.X) && (mouseClick.X < cell.cellOrigin.X + 50) && (mouseClick.Y > cell.cellOrigin.Y) && (mouseClick.Y < cell.cellOrigin.Y + 50))
                    {
                            // Remove the last queen 
                            foreach (Queen currentQueen in this.allQueens)
                            {
                                // if queen is found
                                if (cell.cellOrigin == currentQueen.queenCoords)
                                {
                                    // Set cells to be safe
                                    this.markCellsSafe(cell);

                                    // remove queen
                                    this.allQueens.Remove(currentQueen);

                                    // break out if removed queen
                                    break;
                                }
                            }

                            // update text
                            label1.Text = String.Format("You have {0} queens on the board", this.allQueens.Count);
                    }
                }

                // Must invalidate
                this.Invalidate();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // if checked, set flag true
            if(!isHintsChecked)
            {
                isHintsChecked = true;
            }

            // else unchecked, set flag false
            else
            {
                isHintsChecked = false;
            }

            this.Invalidate();
        }

        // method to mark cells as safe
        public void markCellsSafe (BoardCell currentCell)
        {
            foreach (BoardCell cell in this.allCells)
            {
                // check rows and columns
                if ((currentCell.cellOrigin.X == cell.cellOrigin.X) || (currentCell.cellOrigin.Y == cell.cellOrigin.Y)) cell.isSafe = true;

                // check diagonals
                int dy = Math.Abs(cell.cellOrigin.Y - currentCell.cellOrigin.Y);
                int dx = Math.Abs(cell.cellOrigin.X - currentCell.cellOrigin.X);
                if (dx == dy) cell.isSafe = true;
            }
        }

        // check board for queens
        public void checkForQueens(BoardCell b)
        {
            foreach (Queen activeQueen in this.allQueens)
            {
                // check rows and columns
                if ((b.cellOrigin.X == activeQueen.queenCoords.X) || (b.cellOrigin.Y == activeQueen.queenCoords.Y)) b.isSafe = false;

                // check diagonals
                int dy = Math.Abs(activeQueen.queenCoords.Y - b.cellOrigin.Y);
                int dx = Math.Abs(activeQueen.queenCoords.X - b.cellOrigin.X);
                if (dx == dy) b.isSafe = false;
            }
        }
    }
}
