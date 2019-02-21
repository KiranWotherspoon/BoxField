using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown;

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.White);

        // create a list to hold a column of boxes        
        List<Box> boxesLeft = new List<Box>();
        List<Box> boxesRight = new List<Box>();

        int boxspeed = 5;
        int boxCounter;
        Color randomColourLeft, randomColourRight;

        Random rng = new Random();

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            // set game start values
            Colourchooser();
            Box b1 = new Box(25, 24, 20, randomColourLeft);
            Box b2 = new Box(100, 24, 20, randomColourRight);
            boxesLeft.Add(b1);
            boxesRight.Add(b2);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;           
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            // update location of all boxes (drop down screen)
            foreach (Box b in boxesLeft) { b.y += boxspeed; }
            foreach (Box b in boxesRight) { b.y += boxspeed; }

            // remove box if it has gone of screen
            if (boxesLeft[0].y > this.Height) { boxesLeft.RemoveAt(0); }
            if (boxesRight[0].y > this.Height) { boxesRight.RemoveAt(0); }

            // add new box if it is time
            boxCounter++;
            if (boxCounter == 7)
            {
                Colourchooser();
                Box b1 = new Box(25, 24, 20, randomColourLeft);
                Box b2 = new Box(100, 24, 20, randomColourRight);
                boxesLeft.Add(b1);
                boxesRight.Add(b2);
                boxCounter = 0;
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // draw boxes to screen
            foreach (Box b in boxesLeft)
            {
                boxBrush.Color = b.colour;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }
            foreach (Box b in boxesRight)
            {
                boxBrush.Color = b.colour;
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }
        }

        private void Colourchooser ()
        {
            randomColourLeft = Color.FromArgb(rng.Next(0, 255), rng.Next(0, 255), rng.Next(0, 255));
            randomColourRight = Color.FromArgb(rng.Next(0, 255), rng.Next(0, 255), rng.Next(0, 255));
        }
    }
}
