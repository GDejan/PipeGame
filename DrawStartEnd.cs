using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PipeGame
{
    internal class DrawStartEnd
        :Draw
    {
        public DrawStartEnd()
        {

        }
        public DrawStartEnd(Grid GameGrid, int row, int column, bool startEnd) //draw start and end point of the game depends of 
        {
            Grid TileGrid = DrawGrid(row, column);
            Rectangle Block = DrawBlock();
            TileGrid.Children.Add(Block);

            directions[1] = true;

            Rectangle Line = new Rectangle();
            
            Line.Fill = Settings.lineColor;
            Line.Height = Settings.LineHeight;
            Line.Width = Settings.LineWidth;
            
            if (startEnd)
            {
                Line.Margin=new System.Windows.Thickness(0, 0, 0, Settings.Marg);
                directions[1] = true;
            }
            else
            {
                Line.Margin = new System.Windows.Thickness(0, Settings.Marg, 0, 0);
                directions[0] = true;
            }


            TileGrid.Children.Add(Line);

            GameGrid.Children.Add(TileGrid);
        }

        
    }
}
