using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    class Snake
    {
        public  List<Snake> Body = new List<Snake>();

        public int X { get; set; } // this is a public int class called X
        public int Y { get; set; } // this is a public int class called Y
       
        public Snake()
        {
            // this function is resetting the X and Y to 0
            X = 0;
            Y = 0;
            Body.Add(new Snake());
        }
        public void movements(PictureBox pbCanvas , Label P2, Label P3,List<Food> food)
        {
            
            new Form1();

            for (int i = Body.Count - 1; i >= 0; i--)
            {
                // if the snake head is active 
                if (i == 0)
                {
                    // move rest of the body according to which way the head is moving
                    switch (Settings.direction)
                    {
                        case Directions.Right:
                            Body[i].X += 1 * Settings.speedMulti1;
                            break;
                        case Directions.Left:
                            Body[i].X -= 1 * Settings.speedMulti1;
                            break;
                        case Directions.Up:
                            Body[i].Y -= 1 * Settings.speedMulti1;
                            break;
                        case Directions.Down:
                            Body[i].Y += 1 * Settings.speedMulti1;
                            break;
                    }


                    // restrict the snake from leaving the canvas
                    int maxXpos = pbCanvas.Size.Width / Settings.Width;
                    int maxYpos = pbCanvas.Size.Height / Settings.Height;

                    if (
                        Body[i].X < 0 || Body[i].Y < 0 ||
                        Body[i].X > maxXpos || Body[i].Y > maxYpos
                        )
                    {
                        // end the game is snake either reaches edge of the canvas

                        die();
                    }

                    // detect collision with the body
                    // this loop will check if the snake had an collision with other body parts
                    for (int j = 1; j < Body.Count; j++)
                    {
                        if (Body[i].X == Body[j].X && Body[i].Y == Body[j].Y)
                        {
                            // if so we run the die function
                            die();
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////
                    for (int j = 1; j < Body.Count; j++)
                    {
                        if (Body[0].X == Body[j].X && Body[0].Y == Body[j].Y)
                        {
                            // if so we run the die function
                            die();
                            P2.Text = (int.Parse(P2.Text) + 5).ToString();
                        }
                    }
                    for (int j = 1; j < Body.Count; j++)
                    {
                        if (Body[0].X == Body[j].X && Body[0].Y == Body[j].Y)
                        {
                            // if so we run the die function
                            die();
                            P3.Text = (int.Parse(P3.Text) + 5).ToString();
                        }
                    }

                    //for (int z = Snake.Count-1; z < food.Count; z++)
                    //{
                    for (int x = 0; x < food.Count; x++)
                    {

                        if (Body[i].X == food[x].X && Body[i].Y == food[x].Y)
                        {
                            // if so we run the die function
                            food.RemoveAt(x);

                            eat();

                             // run the generate food function

                            /* generateFood();*/ // run the generate food function
                        }


                    }
                  
                   


                }
                else
                {
                    // if there are no collisions then we continue moving the snake and its parts
                    Body[i].X = Body[i - 1].X;
                    Body[i].Y = Body[i - 1].Y;
                }
            }
        }
        public void die()
        {

        } public void eat()
        {

        }
        
    }
}
