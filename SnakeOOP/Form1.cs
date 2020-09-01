using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeOOP
{
    public partial class Form1 : Form
    {

        List<Snake> snakeList = new List<Snake>();
        Logic logic = new Logic();
        public Form1()
        {
            InitializeComponent();

            timer1.Tick += GameLoop;
            timer1.Start();

            logic.StartGame(snakeList);
        }

        private void DrawGraphics(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (Settings.gameOver == false)
            {
                Brush snakeColor;

                for (int i = 0; i < snakeList.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColor = Brushes.Orange;
                    }
                    else
                    {
                        snakeColor = Brushes.Black;
                    }

                    g.FillEllipse(snakeColor, new Rectangle(snakeList[i].snakePosX,
                        snakeList[i].snakePosY, Settings.Width, Settings.Height));

                    g.FillEllipse(Brushes.Red, new Rectangle(logic.FoodPositionX(), logic.FoodPositionY(),
                        Settings.Width, Settings.Height));
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            KeyInput.ChangeState(e.KeyCode, true);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            KeyInput.ChangeState(e.KeyCode, false);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            if (Settings.gameOver == true)
            {
                if (KeyInput.KeyPress(Keys.R))
                {
                    logic.StartGame(snakeList);
                }
            }
            else
            {
                if (KeyInput.KeyPress(Keys.W) && Settings.direction != Directions.Down)
                {
                    Settings.direction = Directions.Up;
                }
                else if (KeyInput.KeyPress(Keys.S) && Settings.direction != Directions.Up)
                {
                    Settings.direction = Directions.Down;
                }
                else if (KeyInput.KeyPress(Keys.A) && Settings.direction != Directions.Right)
                {
                    Settings.direction = Directions.Left;
                }
                else if (KeyInput.KeyPress(Keys.D) && Settings.direction != Directions.Left)
                {
                    Settings.direction = Directions.Right;
                }
                logic.MoveSnake(snakeList);
                logic.IDied(snakeList);
            }
            lScore.Text = $"Score: {Settings.Score}";
            Invalidate();
        }
    }
}
