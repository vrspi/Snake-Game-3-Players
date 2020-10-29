using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        private bool dm;
        private bool sm;
        private bool fs;
        private bool fd;
        private DateTime Counter;
        private List<Snake> Players = new List<Snake>(); // creating an list array for the snake
        private List<Food> food = new List<Food>(); // creating a single Snake class called food
        public Form1()
        {
            InitializeComponent();
            new Settings(); // linking the Settings Class to this Form

            gameTimer.Interval = 1000 / 10; // Changing the game time to settings speed
            gameTimer.Tick += updateSreen; // linking a updateScreen function to the timer
            gameTimer.Start(); // starting the timer

            startGame(); // running the start game function
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            // the key down event will trigger the change state from the Input class
            Input.changeState(e.KeyCode, true);

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            // the key up event will trigger the change state from the Input class
            Input.changeState(e.KeyCode, false);
        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            // this is where we will see the snake and its parts moving
            Brush snakeColour = Brushes.Blue;
            Graphics canvas = e.Graphics; // create a new graphics class called canvas
            int counterr = 0;
            foreach (var Player in Players)
            {

                counterr++;
                for (int x = 0; x < Player.Body.Count; x++)
                {
                    if (counterr == 1)
                    {
                        snakeColour = Brushes.Blue;
                    }
                    if (counterr == 2)
                    {
                        snakeColour = Brushes.Green;
                    }
                    if (counterr == 2)
                    {
                        snakeColour = Brushes.Red;
                    }

                    //draw snake body and head
                    canvas.FillRectangle(snakeColour,
                                   new Rectangle(
                                       Player.X * Settings.Width,
                                       Player.Y * Settings.Height,
                                       Settings.Width, Settings.Height
                                       ));

                }
            }


            //if (Settings.GameOver == true && Settings.GameOver2 == true && Settings.GameOver3 == true)
            //{
            //    // this part will run when the game is over
            //    // it will show the game over text and make the label 3 visible on the screen
            //    if (Settings.Score > int.Parse(P2.Text))
            //    {
            //        if(Settings.Score > int.Parse(P3.Text))
            //        {
            //            string gameOver = "Game Over \n" + "The winner is Player 1 \n" + "His Score is " + Settings.Score + "\n Press enter to Restart \n";
            //            label3.Text = gameOver;
            //            label3.Visible = true;
            //        }
                   
            //    }
            //   else if (Settings.Score < int.Parse(P2.Text))
            //    {
            //        if (int.Parse(P2.Text) > int.Parse(P3.Text))
            //        {
            //            string gameOver = "Game Over \n" + "The winner is Player 2 \n" + "His Score is " + int.Parse(P2.Text) + "\n Press enter to Restart \n";
            //            label3.Text = gameOver;
            //            label3.Visible = true;
            //        }

            //    }
            //    else if (Settings.Score < int.Parse(P3.Text))
            //    {
            //        if (int.Parse(P3.Text) > int.Parse(P2.Text))
            //        {
            //            string gameOver = "Game Over \n" + "The winner is Player 3 \n" + "His Score is " + int.Parse(P3.Text) + "\n Press enter to Restart \n";
            //            label3.Text = gameOver;
            //            label3.Visible = true;
            //        }

            //    }
            //    else
            //    {
            //        string gameOver = "Game Over \n" +" Draw match" +"\n Press enter to Restart \n";
            //        label3.Text = gameOver;
            //        label3.Visible = true;

            //    }

            //}
           
            //if (DateTime.Now.Second - Counter.Second == 1)
            //{
            //    Counter = DateTime.Now;
            //    Settings.seconds++;
            //    if (sm == true)
            //    {
            //        Settings.secondSpeed++;
            //    }
            //    if (dm == true)
            //    {
            //        Settings.secondDirection++;
            //    }
            //}
            //if (Settings.secondSpeed == 30)
            //{
            //    Settings.speedMulti1 = 1;
            //    Settings.speedMulti2 = 1;
            //    Settings.speedMulti3 = 1;
            //    sm = false;
            //    Settings.secondSpeed = 0;
            //}
            //if (Settings.secondSpeed == 30)
            //{
            //    dm = false;
            //}

            //if (Settings.seconds == 5)
            //{
            //    if (fs == false)
            //    {
            //     fs = true;
            //        generateFoodSpeed();

            //    }
            //    if (fd == false)
            //    {
            //          fd = true;
            //        //generateFoodDirection();
            //    }
               
            //    Settings.seconds = 0;

            //}
           
            //if (fs == true)
            //{
            //    canvas.FillRectangle(Brushes.Cyan,
            //                              new Rectangle(
            //                                  foodspeed[0].X * Settings.Width,
            //                                  foodspeed[0].Y * Settings.Height,
            //                                  Settings.Width, Settings.Height
            //                                  ));
            //    sm = false;
            //    Settings.speedMulti1 = 1;
            //    Settings.speedMulti2 = 1;
            //    Settings.speedMulti3 = 1;

            //}
            //if (fd== true)
            //{
            //    canvas.FillRectangle(Brushes.Brown,
            //                               new Rectangle(
            //                                   fooddirection[0].X * Settings.Width,
            //                                   fooddirection[0].Y * Settings.Height,
            //                                   Settings.Width, Settings.Height
            //                                   ));
                
            //    dm = false;

            //}
        }
        private void startGame()
        {
            Settings.secondSpeed = 0;
            dm = false;
            sm = false;
            fs = false;
            fd = false;
            Counter = DateTime.Now;
            //generateFood(); // run the generate food function
            //generateFoodBlack();
            //generateFoodPink();
            //generateFoodSpeed();
            //generateFoodDirection();
            // this is the start game function

            label3.Visible = false; // set label 3 to invisible
            new Settings(); // create a new instance of settings
            Players.Clear(); // clear all snake parts
           
            Snake head = new Snake { X = 10, Y = 5 }; // create a new head for the snake
            Snake head2 = new Snake { X = 11, Y = 5 }; // create a new head for the snake
            Snake head3= new Snake { X = 12, Y = 5 }; // create a new head for the snake
            P3.Text = "0";
            P2.Text = "0";
            
            Players.Add(head); // add the gead to the snake array
           
            if (Settings.mode2 == false)
            {
                P2.Visible = false;
                Score2.Visible = false;

            }
            if (Settings.mode3 == false)
            {
                P3.Visible = false;
                Score3.Visible = false;
            }
            label2.Text = Settings.Score.ToString(); // show the score to the label 2

            sm = false;


        }

        //private void generateFood()
        //{
        //    int maxXpos = pbCanvas.Size.Width / Settings.Width;
        //    // create a maximum X position int with half the size of the play area
        //    int maxYpos = pbCanvas.Size.Height / Settings.Height;
        //    // create a maximum Y position int with half the size of the play area
        //    Random rnd = new Random(); // create a new random class
        //    Snake fooda = new Snake { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) };

        //    food.Add(fooda);
        //    // add the part to the snakes array
        //    // create a new food with a random x and y

        //}
        //private void generateFoodPink()
        //{
        //    int maxXpos = pbCanvas.Size.Width / Settings.Width;
        //    // create a maximum X position int with half the size of the play area
        //    int maxYpos = pbCanvas.Size.Height / Settings.Height;
        //    // create a maximum Y position int with half the size of the play area
        //    Random rnd = new Random(); // create a new random class
        //    Snake fooda = new Snake { X = rnd.Next(6, maxXpos), Y = rnd.Next(6, maxYpos) };

        //    foodpink.Add(fooda);
        //    // add the part to the snakes array
        //    // create a new food with a random x and y

        //}
        //private void generateFoodBlack()
        //{
        //    int maxXpos = pbCanvas.Size.Width / Settings.Width;
        //    // create a maximum X position int with half the size of the play area
        //    int maxYpos = pbCanvas.Size.Height / Settings.Height;
        //    // create a maximum Y position int with half the size of the play area
        //    Random rnd1 = new Random(); // create a new random class
        //    Snake fooda = new Snake { X = rnd1.Next(3, maxXpos), Y = rnd1.Next(3, maxYpos) };

        //    foodblack.Add(fooda);
        //    // add the part to the snakes array
        //    // create a new food with a random x and y

        //}

        //private void generateFoodSpeed()
        //{
        //    int maxXpos = pbCanvas.Size.Width / Settings.Width;
        //    // create a maximum X position int with half the size of the play area
        //    int maxYpos = pbCanvas.Size.Height / Settings.Height;
        //    // create a maximum Y position int with half the size of the play area
        //    Random rnd1 = new Random(); // create a new random class
        //    Snake fooda = new Snake { X = rnd1.Next(9, maxXpos), Y = rnd1.Next(9, maxYpos) };

        //    foodspeed.Add(fooda);
        //    // add the part to the snakes array
        //    // create a new food with a random x and y
        //}
        //private void generateFoodDirection()
        //{
        //    int maxXpos = pbCanvas.Size.Width / Settings.Width;
        //    // create a maximum X position int with half the size of the play area
        //    int maxYpos = pbCanvas.Size.Height / Settings.Height;
        //    // create a maximum Y position int with half the size of the play area
        //    Random rnd1 = new Random(); // create a new random class
        //    Snake fooda = new Snake { X = rnd1.Next(13, maxXpos), Y = rnd1.Next(13, maxYpos) };

        //    fooddirection.Add(fooda);
        //    // add the part to the snakes array
        //    // create a new food with a random x and y
        //}
        //private void eat()
        //{
        //    // add a part to body

        //    Snake body = new Snake
        //    {
        //        X = Snake[Snake.Count - 1].X,
        //        Y = Snake[Snake.Count - 1].Y

        //    };

        //    Snake.Add(body); // add the part to the snakes array
            
        //    Settings.Score += Settings.Points; // increase the score for the game
        //    label2.Text = Settings.Score.ToString(); // show the score on the label 2
            
        //}
        //private void eat2()
        //{
        //    // add a part to body

        //    Snake body = new Snake
        //    {
        //        X = Snake[Snake.Count - 1].X,
        //        Y = Snake[Snake.Count - 1].Y

        //    };

        //    Snake.Add(body); // add the part to the snakes array
           
      


        //}
        //private void eat3()
        //{
        //    // add a part to body

        //    Snake body = new Snake
        //    {
        //        X = Snake[Snake.Count - 1].X,
        //        Y = Snake[Snake.Count - 1].Y

        //    };

        //    Snake.Add(body); // add the part to the snakes array
        //}
        //private void die()
        //{
        //    // change the game over Boolean to true
        //    Settings.GameOver = true;

        //}
        //private void die2()
        //{
        //    // change the game over Boolean to true
        //    Settings.GameOver2 = true;

        //}
        //private void die3()
        //{
        //    // change the game over Boolean to true
        //    Settings.GameOver3 = true;

        //}


        private void updateSreen(object sender, EventArgs e)
        {
            // this is the Timers update screen function. 
            // each tick will run this function

            if (Settings.GameOver == true && Settings.GameOver2 == true && Settings.GameOver3 == true )
            {

                // if the game over is true and player presses enter
                // we run the start game function

                if (Input.KeyPress(Keys.Enter))
                {
                    this.Close();
                }
            }
            else
            {
                //if the game is not over then the following commands will be executed

                // below the actions will probe the keys being presse by the player
                // and move the accordingly
                if(Settings.GameOver == false)
                {
                if ((Input.KeyPress(Keys.Right)) && Settings.direction != Directions.Left)
                {
                    Settings.direction = Directions.Right;
                }
                if ((Input.KeyPress(Keys.Left)) && Settings.direction != Directions.Right)
                {
                    Settings.direction = Directions.Left;
                }
                if ((Input.KeyPress(Keys.Up)) && Settings.direction != Directions.Down)
                {
                    Settings.direction = Directions.Up;
                }
                if ((Input.KeyPress(Keys.Down)) && Settings.direction != Directions.Up)
                {
                    Settings.direction = Directions.Down;
                }
                }

                /////////////////////////////////////////////////////////////////////////////////////////////////// Player 2 Movements
                if (Settings.GameOver2 == false) { 
                
                  if ((Input.KeyPress(Keys.D)) && Settings.directionSnake2 != Directions.Left)
                {
                        Settings.directionSnake2 = Directions.Right;
                }
                if ((Input.KeyPress(Keys.Q)) && Settings.directionSnake2 != Directions.Right)
                {
                    Settings.directionSnake2 = Directions.Left;
                }
                if ((Input.KeyPress(Keys.Z)) && Settings.directionSnake2 != Directions.Down)
                {
                    Settings.directionSnake2 = Directions.Up;
                }
                if ((Input.KeyPress(Keys.S)) && Settings.directionSnake2 != Directions.Up)
                {
                    Settings.directionSnake2 = Directions.Down;
                }
                }
              
                if (Settings.GameOver3 == false) {
                if ((Input.KeyPress(Keys.L)) && Settings.directionSnake2 != Directions.Left)
                {
                    Settings.directionSnake2 = Directions.Right;
                }
                if ((Input.KeyPress(Keys.J)) && Settings.directionSnake2 != Directions.Right)
                {
                    Settings.directionSnake2 = Directions.Left;
                }
                if ((Input.KeyPress(Keys.I)) && Settings.directionSnake2 != Directions.Down)
                {
                    Settings.directionSnake2 = Directions.Up;
                }
                if ((Input.KeyPress(Keys.K)) && Settings.directionSnake2 != Directions.Up)
                {
                    Settings.directionSnake2 = Directions.Down;
                }
                
                }

                
                movePlayer(); // run move player function
            }

            pbCanvas.Invalidate(); // refresh the picture box and update the graphics on it

        }
        private void movePlayer()
        {
            // the main loop for the snake head and parts
            foreach (var Player in Players)
            {
                Player.movements(pbCanvas, P2, P3, food);
            }
                
         
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void changecontrol()
        {
            Random random = new Random();
            int x = random.Next(1, 4);
            if(Settings.mode2==false && Settings.mode3 == false)
            {
                Random h = new Random();
                int z = h.Next(1, 3);
                if (z == 1)
                {
                    Settings.speedMulti1 = -1;
                    sm = true;

                }

            }
            else
            {
              
                if (x == 1)
                {

                    Settings.speedMulti1 = -1;
                    sm = true;
                }
                else if (x == 2)
                {
                    Settings.speedMulti2 = -1;
                    sm = true;
                }
                else if (x == 3)
                {

                    Settings.speedMulti3 = -1;
                    sm = true;


                }

            }
           

        }
        private void changeDirection()
        {

            Random random = new Random();
            int x = random.Next(1, 4);
            if (Settings.mode2 == false && Settings.mode3 == false)
            {
                Random h = new Random();
                int z = h.Next(1, 3);
                if (z == 1)
                {
                    Random ss = new Random();
                    int direction = ss.Next(1, 3);
                    if(Settings.direction != Directions.Right && Settings.direction != Directions.Left)
                    {

                    if (direction == 1)
                    {
                        Settings.direction = Directions.Left;
                    }
                    else if (direction == 2)
                    {
                        Settings.direction = Directions.Right;
                    }
                    dm = true;
                    }
                   

                }

            }
            else
            {

                if (x == 1)
                {

                    Random ss = new Random();
                    int direction = ss.Next(1, 3);
                    if (Settings.direction != Directions.Right && Settings.direction != Directions.Left)
                    {

                        if (direction == 1)
                        {
                            Settings.direction = Directions.Left;
                        }
                        else if (direction == 2)
                        {
                            Settings.direction = Directions.Right;
                        }
                        dm = true;
                    }

                }
                else if (x == 2)
                {
                    Random ss = new Random();
                    int direction = ss.Next(1, 3);
                    if (Settings.directionSnake2 != Directions.Right && Settings.directionSnake2 != Directions.Left)
                    {

                        if (direction == 1)
                        {
                            Settings.directionSnake2 = Directions.Left;
                        }
                        else if (direction == 2)
                        {
                            Settings.directionSnake2 = Directions.Right;
                        }
                        dm = true;
                    }

                }
                else if (x == 3)
                {

                    Random ss = new Random();
                    int direction = ss.Next(1, 3);
                    if (Settings.directionSnake3 != Directions.Right && Settings.directionSnake3 != Directions.Left)
                    {

                        if (direction == 1)
                        {
                            Settings.directionSnake3 = Directions.Left;
                        }
                        else if (direction == 2)
                        {
                            Settings.directionSnake3 = Directions.Right;
                        }
                        dm = true;
                    }


                }
            }
        }
    }
}
