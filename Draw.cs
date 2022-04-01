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
    internal class Draw
        :Box
    {
        public Draw()
        {

        }

        public Grid DrawGrid(int row, int column)
        {
            Grid TileGrid = new Grid();
            TileGrid.SetValue(Grid.RowProperty, row);
            TileGrid.SetValue(Grid.ColumnProperty, column);
            TileGrid.SetValue(Grid.RowSpanProperty, 1);
            TileGrid.SetValue(Grid.ColumnSpanProperty, 1);
            return TileGrid;
        }
        public Rectangle DrawBlock()
        {
            Rectangle Block = new Rectangle();
            Block.Fill = Settings.blockColor;
            Block.Stroke = Settings.strokeColor;
            return Block;
        }
    }
}
