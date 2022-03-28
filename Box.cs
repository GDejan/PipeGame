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
        Settings Settings = new Settings();
        Random rand = new Random();
        List<int> list = new List< int>();

        public void DrawBox(Grid GameGrid, int row, int column) 
        {
            Grid TileGrid = DrawGrid(row, column);

            Rectangle Block = DrawBlock();
            TileGrid.Children.Add(Block);

            list.Clear();
            list.Add(0);
            int noOfLines = rand.Next(2, 4);
            int noOfLineMax = noOfLines;
            while (noOfLines > 0)
            {
                Rectangle Line = DrawLine(noOfLineMax, noOfLines);
                TileGrid.Children.Add(Line);
                noOfLines--;
            }

            int angel = 0;
            switch (rand.Next(1, 4))
            {
                case 1: 
                    angel = 0; 
                    break;
                case 2:
                    angel = 90;
                    break;
                case 3:
                    angel = -90;
                    break;
                case 4:
                    angel = 180;
                    break;
                default:
                    break;
            }
            
            Rotate(TileGrid, angel);
            GameGrid.Children.Add(TileGrid);

        }
        public void Rotate(Grid grid, int angel)
        {
            RotateTransform gridRotated = new RotateTransform(angel);
            gridRotated.CenterX = Settings.CenterOfRotation;
            gridRotated.CenterY = Settings.CenterOfRotation;
            grid.RenderTransform = gridRotated;

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

        private Rectangle DrawLine(int noOfLineMax, int noOfLines) 
        {
            Rectangle Line = new Rectangle();
            Line.Fill = Settings.lineColor;
            Line.Stroke = Settings.lineColor;
            
            int Height = 0;
            int Width = 0;
            int Lmarg = 0;
            int Rmarg = 0;
            int Tmarg = 0;
            int Bmarg = 0;
            int random = 0;
            bool next = true;

            if (noOfLineMax > 2)
            {
                random = noOfLines;
            }
            else
            {
                do
                {
                    random = rand.Next(1, 4);
                    foreach (int item in list)
                    {
                        if (item == random)
                        {
                            next = false;
                            break;
                        }
                        else 
                        {
                            next = true;
                        }
                    }
                } while (!next);
            }

            list.Add(random);
            switch (random)
            {
                case 1:
                    Height = Settings.LineHeight;
                    Width = Settings.LineWidth;
                    Tmarg = Settings.Marg;
                    break;
                case 2:
                    Height = Settings.LineHeight;
                    Width = Settings.LineWidth;
                    Bmarg = Settings.Marg;

                    break;
                case 3:
                    Height = Settings.LineWidth;
                    Width = Settings.LineHeight;
                    Lmarg = Settings.Marg;
                    break;
                case 4:
                    Height = Settings.LineWidth;
                    Width = Settings.LineHeight;
                    Rmarg = Settings.Marg;
                    break;
                default:
                    break;
            }

            if (random!=0)
            {
                Line.Height = Height;
                Line.Width = Width;
                Line.Margin = new System.Windows.Thickness(Lmarg, Tmarg, Rmarg, Bmarg);
            }
            
            return Line;
        }
    }
}
