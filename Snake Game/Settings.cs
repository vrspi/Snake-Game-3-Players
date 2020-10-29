using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public enum Directions
    {
        // this is a enum class called Directions
        // we are using enum because its easier to classify the directions
        // for this game

        Left,
        Right,
        Up,
        Down
    };
    class Settings
    {
       
        public static int Width { get; set; } // set the width as int class
        public static int Height { get; set; } // set the height as int class
        public static int Speed { get; set; } // set the speed as int class
        public static int Score { get; set; } // set the score as int class

        public static int speedMulti1 { get; set; }
        public static int speedMulti2 { get; set; }
        public static int speedMulti3 { get; set; }


        public static int Points { get; set; } // set the points as int class
        public static int PointsPink { get; set; } // set the points as int class
        public static int PointsBlack { get; set; } // set the points as int class

        //public static DateTime StartTime { get; set; } // set the points as int class

        public static bool GameOver { get; set; } // set the game over as Boolean class
        public static bool GameOver2 { get; set; } // set the game over as Boolean class
        public static bool GameOver3 { get; set; } // set the game over as Boolean class
        public static int foodi = -1;
        //public static bool mode1 = true;
        public static bool mode2 = false;
        public static bool mode3 = false;
        public static int seconds { get; set; }
        public static int secondSpeed{ get; set; }
        public static int secondDirection { get; set; }


        public static Directions direction { get; set; } // set the direction as the class we mentioned above
        public static Directions directionSnake2 { get; set; } // set the direction as the class we mentioned above
        public static Directions directionSnake3 { get; set; } // set the direction as the class we mentioned above



        public Settings()
        {
            // this is the default settings function
            Width = 16; // set the width to 16
            Height = 16; // set the height to 16
            Speed = 20; // set the speed to 20
            Score = 0; // set the score to 0
            Points = 1; // set points to 1
            PointsPink = 2;// set points to 2
            PointsBlack = 3;// set points to 3
            speedMulti1 = 1;
            speedMulti2 = 1;
            speedMulti3 = 1;
            seconds = 0;
            secondSpeed = 0;
            secondDirection = 0;

            GameOver = false; // set game over to false
            GameOver2 = false; // set game over to false
            GameOver3 = false; // set game over to false
            direction = Directions.Down; // the default direction will be down
            directionSnake2 = Directions.Down;
            directionSnake3 = Directions.Right;
            foodi++;
        }
    }
}
