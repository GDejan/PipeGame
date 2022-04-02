using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace PipeGame
{
    
    public class Box
    {
        public Grid GameGrid { get; private set; }
        public int Column { get; private set; }
        public int Row { get; private set; }
        public List<bool> directions = new List<bool> 
        {
            false,
            false,
            false,
            false
        };
        public bool OkState { get; set; } 
        public bool UpConn { get; set; } 
        public bool DownConn { get; set; } 
        public bool LeftConn { get; set; } 
        public bool RightConn { get; set; }

        public Box()
        {

        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="gameGrid">grid</param>
        /// <param name="row">row</param>
        /// <param name="column">column</param>
        public Box(Grid gameGrid, int row, int column)
        {
            this.GameGrid = gameGrid;
            this.Column = column;
            this.Row = row;
        }

        /// <summary>
        /// generate random number
        /// </summary>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <returns></returns>
        public int Random(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }
        /// <summary>
        /// rotate shape 
        /// </summary>
        /// <param name="Boxgrid">box</param>
        /// <param name="angel">angel</param>
        /// <param name="dirLR">direction</param>
        /// <returns></returns>
        public Grid Rotate(Grid Boxgrid, int angel, string dirLR) //rotate Box grid to specific angel with dir L or R
        {
            RotateTransform gridRotated = new RotateTransform(angel);
            gridRotated.CenterX = Settings.CenterOfRotation;
            gridRotated.CenterY = Settings.CenterOfRotation;
            Boxgrid.RenderTransform = gridRotated;

            RotateArray(dirLR);
            return Boxgrid;
        }
        /// <summary>
        /// rotate array - bitshift
        /// </summary>
        /// <param name="dirLR">direction of rotation L-left, R- right, R2- double rightt</param>
        private void RotateArray(string dirLR) 
        {
            if (dirLR == "L") //rotate direction array to left - bitshift left
            {
                bool memo = directions[0];
                directions[0] = directions[1];
                directions[1] = directions[2];
                directions[2] = directions[3];
                directions[3] = memo;

            }
            else if (dirLR == "R2") //rotate direction array to right right - bitshift right right
            {
                bool memo = directions[2];
                directions[2] = directions[0];
                directions[0] = memo;
                memo = directions[1];
                directions[1] = directions[3];
                directions[3] = memo;
            }
            else if (dirLR == "R") //rotate direction array to right - bitshift right
            {
                bool memo = directions[3];
                directions[3] = directions[2];
                directions[2] = directions[1];
                directions[1] = directions[0];
                directions[0] = memo;
            }
        }
    }
}
