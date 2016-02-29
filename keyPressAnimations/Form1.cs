using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* Created by Mr. T
 * to demonstrate how to use key presses to control the animation
 * of an object on screen
 */

namespace keyPressAnimations
{
    public partial class Form1 : Form
    {
        //initial starting points for black rectangle
        int drawX = 100;
        int drawY = 200;

        //determines whether a key is being pressed or not
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        //Array
        Image[] backgrounds = new Image[2];
        Image[] redGuy = new Image[4];

        public Form1()
        {
            InitializeComponent();
            //Background
            backgrounds[0] = Properties.Resources.forest; //Image image0 = Properties.Resources.forest;
            backgrounds[1] = Properties.Resources.pirate; //Image image1 = Properties.Resources.pirate;
            this.BackgroundImage = backgrounds[0];  //Image[] backgrounds = { image0, image1 };

            //Character
            redGuy[0] = Properties.Resources.RedGuyDown;
            redGuy[1] = Properties.Resources.RedGuyUp;
            redGuy[2] = Properties.Resources.RedGuyLeft;
            redGuy[3] = Properties.Resources.RedGuyRight;

            //start the timer when the program starts
            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                default:
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //checks to see if any keys have been pressed and adjusts the X or Y value
            //for the rectangle appropriately
            if (leftArrowDown == true)
            {
                drawX--;
            }
            if (downArrowDown == true)
            {
                drawY++;
            }
            if (rightArrowDown == true)
            {
                drawX++;
            }
            if (upArrowDown == true)
            {
                drawY--;
            }

            //refresh the screen, which causes the Form1_Paint method to run
            Refresh();

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle to screen
            e.Graphics.FillRectangle(drawBrush, drawX, drawY, 10, 20);
        }

    }

}
