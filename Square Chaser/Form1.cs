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
        Rectangle speedOrb = new Rectangle(200,400,10,10);
        Rectangle doomOrb = new Rectangle(400,100,10,10);
        Rectangle point = new Rectangle(40,300,10,10);

        //powerup speed
        int powerupXspeed = 4;
        int powerupYspeed = 4;

        //ball code
        Rectangle ball = new Rectangle(295, 195, 25, 25);
        Rectangle ball2 = new Rectangle(195, 195, 25, 25);
        int ballXSpeed = -6;
        int ballYSpeed = 6;

        int curveball;

        //Random
        Random spaceRandom = new Random();
        Random rand = new Random();

        //Score
        int player1Score = 1;
        int player2Score = 1;


        //Player speeds
        int player1Speed = 7;
        int player2Speed = 7;

        //movement keys
        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        bool aDown = false;
        bool dDown = false;
        bool leftDown = false;
        bool rightDown = false;

        //surpise
        bool supriseP1 = false;
        bool supriseP2 = false;

        //paint
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
                //Player 1 Ability
                case Keys.R:
                    supriseP1 = false;
                    break;
                //Player 2 Ability
                case Keys.M:
                    supriseP2 = false;
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
                //Player 1 Ability
                case Keys.R:
                    supriseP1 = true;
                    break;
                //Player 2 Ability
                case Keys.M:
                    supriseP2 = true;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Random spaceRandom = new Random();
            //check player score
            player1scoreOutput.Text = $"{player1Score}";
            player2scoreOutput.Text = $"{player2Score}";

            //move ball 
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            //check if ball hit top or bottom wall and change direction if it does 
            if (ball.Y < 0 || ball.Y > this.Height - ball.Height)
            {
                ballYSpeed *= -1;
            }

            //check if ball collides with wall
            if (ball.X <= 0 && ball.X < 600 && ball.Y >= 0)
            {
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                
                ball.X = xRandom;
                ball.Y = yRandom;

                ballXSpeed *= -1;
            }
            if (ball.Y <= 600 && ball.Y > 0 && ball.X >= 600)
            {
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                
                ball.X = xRandom;
                ball.Y = yRandom;

                ballXSpeed *= -1;
            }
            if (ball.Y <600 && ball.Y > 450)
            {
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);

                ball.X = xRandom;
                ball.Y = yRandom;

                ballXSpeed *= -1;
            }

            //check if ball collides with a player
            if (ball.IntersectsWith(player1))
            {
                player1Score = player1Score - 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);

                ball.X = xRandom;
                ball.Y = yRandom;

                ballXSpeed *= -1;
            }
            if (ball.IntersectsWith(player2))
            {
                player2Score = player2Score - 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);

                ball.X = xRandom;
                ball.Y = yRandom;

                ballXSpeed *= -1;
            }


            //check if ball collides with a powerup


            //ball random curve
            int curveball = rand.Next(1, 7);
            if (curveball > 1 && curveball < 3)
            {
                if (ball.X < 50 || ball.X > this.Height - ball.Width)
                {
                    ballYSpeed *= -1;
                }
            }
            //Ball player 1 control
            if (supriseP1 == true)
            {
                int curveballP1 = rand.Next(1, 7);
                if (curveball > 1 && curveball < 6)
                {
                    if (ball.X < 50 || ball.X > this.Height - ball.Width)
                    {
                        ballYSpeed *= -1;
                    }
                }
            }

            //Ball player 2 control
            if (supriseP2 == true)
            {
                int curveballP2 = rand.Next(1, 7);
                if (curveball > 1 && curveball < 6)
                {
                    if (ball.X < 50 || ball.X > this.Height - ball.Width)
                    {
                        ballYSpeed *= -1;
                    }
                }
            }
            ////Player 2 ball
            //move ball 
            ball2.X += ballXSpeed;
            ball2.Y += ballYSpeed;

            //check if ball hit top or bottom wall and change direction if it does 
            if (ball2.Y < 0 || ball2.Y > this.Height - ball2.Height)
            {
                ballYSpeed *= -1;
            }

            //check if ball collides with wall
            if (ball2.X <= 0 && ball2.X < 600 && ball2.Y >= 0)
            {
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);

                ball2.X = xRandom;
                ball2.Y = yRandom;

                ballXSpeed *= -1;
            }
            if (ball2.Y <= 600 && ball2.Y > 0 && ball2.X >= 600)
            {
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);

                ball2.X = xRandom;
                ball2.Y = yRandom;

                ballXSpeed *= -1;
            }
            if (ball2.Y < 600 && ball2.Y > 450)
            {
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);

                ball2.X = xRandom;
                ball2.Y = yRandom;

                ballXSpeed *= -1;
            }

            //check if ball collides with a player
            if (ball2.IntersectsWith(player1))
            {
                player1Score = player1Score - 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);

                ball2.X = xRandom;
                ball2.Y = yRandom;

                ballXSpeed *= -1;
            }
            if (ball2.IntersectsWith(player2))
            {
                player2Score = player2Score - 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);

                ball2.X = xRandom;
                ball2.Y = yRandom;

                ballXSpeed *= -1;
            }

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


            //Player 1 powerups
            //Point powerup
            if (player1.IntersectsWith(point))
            {
                
                player1Score = player1Score + 1;
                player1scoreOutput.Text = $"{player1Score}";
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                point = new Rectangle(xRandom, yRandom, 7, 7);

            }

            //speed powerup
            if (player1.IntersectsWith(speedOrb))
            {
                player1Speed = player1Speed + 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                speedOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }

            //Slow powerup
            if (player1.IntersectsWith(doomOrb))
            {
                player1Speed = player1Speed - 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                doomOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }

            //Player 2 powerups
            //Point powerup
            if (player2.IntersectsWith(point))
            {

                player2Score = player2Score + 1;
                player2scoreOutput.Text = $"{player2Score}";
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                point = new Rectangle(xRandom, yRandom, 7, 7);

            }

            //speed powerup
            if (player2.IntersectsWith(speedOrb))
            {
                player2Speed = player2Speed + 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                speedOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }

            //Slow powerup
            if (player2.IntersectsWith(doomOrb))
            {
                player2Speed = player2Speed - 1;
                int xRandom = spaceRandom.Next(1, 600);
                int yRandom = spaceRandom.Next(1, 450);
                doomOrb = new Rectangle(xRandom, yRandom, 7, 7);
            }
            //Move powerups
            ball.X += powerupXspeed;
            ball.Y += powerupYspeed;

            //check for player speed dropping under 1
            if (player1Speed < 1)
            {
                winLabel.Text = $"player 2 wins to speed";
            }
            if (player2Speed < 1)
            {
                winLabel.Text = $"player 1 wins to speed";
            }

            //check for player score dropping under 0

            if(player1Score <= 0)
            {
                winLabel.Text = "player 2 wins to score";
                Thread.Sleep(3000);
                Application.Exit();
            }
            if (player2Score <= 0)
            {
                winLabel.Text = "player 1 wins to score";
                Thread.Sleep(3000);
                Application.Exit();
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
            e.Graphics.FillRectangle(redBrush, doomOrb);
            e.Graphics.FillRectangle(yellowBrush, speedOrb);
            e.Graphics.FillRectangle(redBrush, ball);
            e.Graphics.FillRectangle(redBrush, ball2);
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
