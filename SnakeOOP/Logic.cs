using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeOOP
{
    class Logic
    {
        Food food = new Food();
        public void MoveSnake(List<Snake> snakeList)
        {
            for (int i = snakeList.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Directions.Left:
                            snakeList[i].snakePosX -= Settings.Speed;
                            break;
                        case Directions.Right:
                            snakeList[i].snakePosX += Settings.Speed;
                            break;
                        case Directions.Up:
                            snakeList[i].snakePosY -= Settings.Speed;
                            break;
                        case Directions.Down:
                            snakeList[i].snakePosY += Settings.Speed;
                            break;
                    }
                    if (snakeList[0].snakePosX == FoodPositionX() && snakeList[0].snakePosY == FoodPositionY())
                    {
                        MakeFood();
                        AddBody(snakeList);
                        Settings.Score += Settings.Points;
                    }
                }
                else
                {
                    snakeList[i].snakePosX = snakeList[i - 1].snakePosX;
                    snakeList[i].snakePosY = snakeList[i - 1].snakePosY;
                }
            }
        }

        public void IDied(List<Snake> snakeList)
        {
            for (int i = snakeList.Count; i >= 0; i--)
            {
                if (i == 0)
                {
                    if (snakeList[i].snakePosX < -10 || snakeList[i].snakePosY < -10 ||
                        snakeList[i].snakePosX > 600 || snakeList[i].snakePosY > 450)
                    {
                        OnDead();
                    }
                }
            }
            for (int x = 2; x < snakeList.Count; x++)
            {
                if (snakeList[0].snakePosX == snakeList[x].snakePosX &&
                    snakeList[0].snakePosY == snakeList[x].snakePosY)
                {
                    OnDead();
                }
            }
        }

        public void StartGame(List<Snake> snakeList)
        {
            new Settings();
            snakeList.Clear();
            Snake head = new Snake { snakePosX = 100, snakePosY = 100 };
            snakeList.Add(head);
            Random rand = new Random();
            food = new Food
            {
                FoodPosX = rand.Next(5, 55) * 10,
                FoodPosY = rand.Next(5, 40) * 10
            };
        }

        public void MakeFood()
        {
            Random rand = new Random();
            food = new Food
            {
                FoodPosX = rand.Next(0, 60) * 10,
                FoodPosY = rand.Next(0, 45) * 10
            };
        }

        public void AddBody(List<Snake> snakeList)
        {
            Snake body = new Snake
            {
                snakePosX = snakeList[snakeList.Count - 1].snakePosX,
                snakePosY = snakeList[snakeList.Count - 1].snakePosY
            };

            snakeList.Add(body);
        }

        public int FoodPositionX()
        {
            return food.FoodPosX;
        }

        public int FoodPositionY()
        {
            return food.FoodPosY;
        }


        public void OnDead()
        {
            Settings.gameOver = true;
        }
    }
}
