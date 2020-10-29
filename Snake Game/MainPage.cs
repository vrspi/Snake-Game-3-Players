using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.mode2 = true;
            Form1 Game = new Form1();
            Game.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.mode3 = true;
            Form1 Game = new Form1();
            Game.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.mode2 = false;
            Settings.mode3 = false;
            Form1 Game = new Form1();
            Game.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello there,\n welcome to my Snake Game , there is some instructions that can help you in the game.\n" +
                "there is 3 types of food \n" +
                "YELLOW : GIVES YOU 1 POINT \n" +
                "PINK : GIVES YOU 2 POINTS\n" +
                "BLACK : GIVES YOU 3 POINTS\n" +
                "CYAN : CHANGES THE CONTROL OF A RANDOM PLAYER. WARNING : YOU CAN DIE\n" +
                "BROWN : CHANGES DIRECTION TO RIGHT OR LEFT FOR A RANDOM PLAYER. WARNING : YOU CAN DIE\n ", "INSTRUCTIONS");
        }
    }
}
