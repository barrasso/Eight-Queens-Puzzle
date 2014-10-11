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

        // Set the board size (height and width)
        int boardsize = 400;

        // Set board coordinates (x and y)
        int boardXPosition, boardYPosition = 100;

        // Init brushes for cell color array
        Brush[] cellColor = {Brushes.Black, Brushes.White};

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Get graphics object
            Graphics g = e.Graphics;

        }
    }
}
