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
        /// <summary>
        /// draw start and end point of the game depends of bool
        /// </summary>
        /// <param name="GameGrid">game grid</param>
        /// <param name="row">row</param>
        /// <param name="column">column</param>
        /// <param name="startEnd">1=start, 0=end</param>
        public DrawStartEnd(Grid GameGrid, int row, int column, bool startEnd, DrawBox[][] BoxArray) 
        {
            Grid TileGrid = DrawGrid(row, column);
            Rectangle Block = DrawBlock();
            TileGrid.Children.Add(Block);

            Rectangle Line = new Rectangle();
            
            Line.Fill = Settings.lineColor;
            Line.Height = Settings.LineHeight;
            Line.Width = Settings.LineWidth;
            
            if (startEnd)
            {
                Line.Margin=new System.Windows.Thickness(0, 0, 0, Settings.Marg);
                BoxArray[1][2].directions[2] = true;
                BoxArray[1][2].OkState = true;
                BoxArray[1][2].DownConn = true;
            }
            else
            {
                Line.Margin = new System.Windows.Thickness(0, Settings.Marg, 0, 0);
                BoxArray[6][5].directions[0] = true;
                BoxArray[6][5].OkState = true;
                BoxArray[6][5].UpConn = true;
            }

            TileGrid.Children.Add(Line);
            GameGrid.Children.Add(TileGrid);

            
            
        }

        
    }
}
