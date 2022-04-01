using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PipeGame
{
    
    public class Box
    {
        private Grid GameGrid { get; set; }
        private int Column { get; set; }
        private int Row { get; set; }
        public List<bool> directions = new List<bool> 
        {
            false,
            false,
            false,
            false
        };
        public bool okState = false;
      

        public Box()
        {

        }
        public Box(Grid gameGrid, int row, int column)
        {
            this.GameGrid = gameGrid;
            this.Column = column;
            this.Row = row;
        }

        public int Random(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }

        public List<bool> Rotate(Grid grid, int angel, string dirLR) //rotate Box grid to specific angel with dir L or R
        {
            RotateTransform gridRotated = new RotateTransform(angel);
            gridRotated.CenterX = Settings.CenterOfRotation;
            gridRotated.CenterY = Settings.CenterOfRotation;
            grid.RenderTransform = gridRotated;

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
            
            return directions;
        }

            

    }
}
