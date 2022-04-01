using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PipeGame
{
    internal class DrawBox
        :Box
    {

        public DrawBox()
        {

        }
        public  DrawBox(Grid GameGrid, int row, int column)
            : base(GameGrid, row, column)
        {
            Grid BoxGrid = DrawGrid(row, column); //create Boxgrid

            Rectangle Block = DrawBlock();
            BoxGrid.Children.Add(Block); //add Background box to Boxgrid

            int shape = Random(0, 6); //random choose of shape
            
            if (shape == 5)
            {
                Rectangle Line = DrawLine(1);
                BoxGrid.Children.Add(Line);
                Rectangle Line2 = DrawLine(3);
                BoxGrid.Children.Add(Line2);
            }
            else 
            {
                while (shape > 0)
                {
                    Rectangle Line = DrawLine(shape);
                    BoxGrid.Children.Add(Line); //add line to BoxGrid
                    shape--;
                }
            }
            
            int angel = 0;
            string didLR = "";
            switch (Random(1, 4))
            {
                case 1: //no rotation
                    angel = 0;
                    break;
                case 2://rotation right for 90
                    angel = 90;
                    didLR="R"; 
                    break;
                case 3://rotation left for 90
                    angel = -90;
                    didLR = "L";
                    break;
                case 4://rotation right for 180
                    angel = 180;
                    didLR = "R2";
                    break;
                default:
                    break;
            }

            Rotate(BoxGrid, angel, didLR); //rotate Box grid to specific angel with dir L or R
            GameGrid.Children.Add(BoxGrid); //add BoxGrid to Main grid

        }

        private Rectangle DrawLine(int shape)
        {
            int Height = 0;
            int Width = 0;
            int Lmarg = 0;
            int Rmarg = 0;
            int Tmarg = 0;
            int Bmarg = 0;

            switch (shape)
            {
                case 1: //up line
                    Height = Settings.LineHeight;
                    Width = Settings.LineWidth;
                    Tmarg = Settings.Marg;
                    directions[0] = true;
                    break;
                case 2: //down line
                    Height = Settings.LineHeight;
                    Width = Settings.LineWidth;
                    Bmarg = Settings.Marg;
                    directions[2] = true;
                    break;
                case 3: //left line
                    Height = Settings.LineWidth;
                    Width = Settings.LineHeight;
                    Lmarg = Settings.Marg;
                    directions[3] = true;
                    break;
                case 4: //right line
                    Height = Settings.LineWidth;
                    Width = Settings.LineHeight;
                    Rmarg = Settings.Marg;
                    directions[1] = true;
                    break;
                default: //no line
                    break;
            }

            Rectangle Line = new Rectangle();

            Line.Height = Height;
            Line.Width = Width;
            Line.Fill = Settings.lineColor;
            Line.Stroke = Settings.lineColor;
            Line.RadiusX = Settings.LineHeight / 2;
            Line.RadiusY = Settings.LineWidth / 2;

            Line.Margin = new System.Windows.Thickness(Lmarg, Tmarg, Rmarg, Bmarg);

            return Line;
        }

        private Grid DrawGrid(int row, int column)
        {
            Grid TileGrid = new Grid();
            TileGrid.SetValue(Grid.RowProperty, row);
            TileGrid.SetValue(Grid.ColumnProperty, column);
            TileGrid.SetValue(Grid.RowSpanProperty, 1);
            TileGrid.SetValue(Grid.ColumnSpanProperty, 1);
            return TileGrid;
        }
        private Rectangle DrawBlock()
        {
            Rectangle Block = new Rectangle();
            Block.Fill = Settings.blockColor;
            Block.Stroke = Settings.strokeColor;
            return Block;
        }
    }
}
