using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Square_Chaser
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(150, 150, 20, 20);
        Rectangle player2 = new Rectangle(450, 150, 20, 20);

        //Powerups
        Rectangle speedOrb = new Rectangle();
        Rectangle slowOrb = new Rectangle();
        Rectangle point = new Rectangle();

        //Random
        Random spaceRandom = new Random();
        //int xRandom = 0;
        //int yRandom = 0;



        int player1Score = 0;
        int player2Score = 0;

        int player1Speed = 7;
        int player2Speed = 7;

        ////Ball speed is for extra edition
        //int ballXSpeed = -2;
        //int ballYSpeed = 2;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        bool aDown = false;
        bool dDown = false;
        bool leftDown = false;
        bool rightDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            

            //g.Clear(Color.White);
            //g.DrawLine(borderTop, 40, 40, 100, 40);

            Random spaceRandom = new Random();

            //int xRandom = spaceRandom.Next(1, 600);
            //int yRandom = spaceRandom.Next(1, 450);
            //Rectangle slowOrb = new Rectangle(xRandom, yRandom, 7, 7);

            

            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }
            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }
            if (dDown == true && player1.X > 0)
            {
                player1.X += player1Speed;
            }
            if (aDown == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }
            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }
            if (rightDown == true && player2.X > 0)
            {
                player2.X += player2Speed;
            }
            if (leftDown == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }

            //check if  players hit  walls
            //NOTE:Create a method for these
            if (player1.X <= 0 && player1.X < 600 && player1.Y >= 0)
            {
                player1.X = 150;
                player1.Y = 150;
            }
            if (player1.Y <= 600 && player1.Y > 0 && player1.X >= 600)
            {
                player1.X = 150;
                player1.Y = 150;
            }

            if (player2.X <= 0 && player2.X < 600 && player2.Y >= 0)
            {
                player2.X = 450;
                player2.Y = 150;
            }
            if (player2.Y <= 600 && player2.Y > 0 && player2.X >= 600)
            {
                player2.X = 450;
                player2.Y = 150;
            }



            //Point powerup
            if (player1.IntersectsWith(point))
            {
                
                player1Score = player1Score + 1;
                player1scoreOutput.Text = $"{player1Score}";
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                Rectangle point = new Rectangle(xRandom, yRandom, 7, 7);

            }

            //speed powerup
            if (player1.IntersectsWith(speedOrb))
            {
                player1Speed = player1Speed + 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                Rectangle speedOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }

            //Slow powerup
            if (player1.IntersectsWith(slowOrb))
            {
                player1Speed = player1Speed - 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                Rectangle slowOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }



            //win system
            if (player1Score == 7)
            {
                winLabel.Text = $"Player 1 wins!!! with a score of {player1Score} to {player2Score}";
                Thread.Sleep(5000);
                Application.Exit();
            }
            if (player2Score == 7)
            {
                winLabel.Text = $"Player 2 wins!!! with a score of {player2Score} to {player1Score}";
                Thread.Sleep(5000);
                Application.Exit();
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.FillRectangle(orangeBrush, point);
            e.Graphics.FillRectangle(redBrush, slowOrb);
            e.Graphics.FillRectangle(yellowBrush, speedOrb);

        }

        private void player1scoreLabel_DoubleClick(object sender, EventArgs e)
        {
            player1Score++;
        }

        private void player2scoreLabel_DoubleClick(object sender, EventArgs e)
        {
            player2Score++;
        }
    }
}
