using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PipeGame
{
    internal class Box
    {
        
        public void Rotate(Grid grid, int angel) 
        {
            RotateTransform gridRotated = new RotateTransform(angel);
            gridRotated.CenterX = 25;
            gridRotated.CenterY = 25;
            grid.RenderTransform = gridRotated;
            
        }
        public void DrawBox(Grid GameGrid, int row, int column) 
        {
            Random rand = new Random();
            SolidColorBrush blockColor = new SolidColorBrush();
            blockColor.Color = Color.FromArgb(100, 0, 255, 255);
            SolidColorBrush strokeColor = new SolidColorBrush();
            strokeColor.Color = Color.FromArgb(100, 0, 255, 255);
            SolidColorBrush lineColor = new SolidColorBrush();
            lineColor.Color = Color.FromArgb(100, 0, 0, 0);

            Grid TileGrid = new Grid();
            Rectangle Block = new Rectangle();
            Rectangle Line1 = new Rectangle();
            Rectangle Line2 = new Rectangle();

            TileGrid.Name = "Tile" + row + column; 
            Block.Name = "Block" + row + column;  
            Line1.Name = "Line1" + row + column;
            Line2.Name = "Line2" + row + column;

            Block.Fill = blockColor;
            Block.Stroke = strokeColor;

            Line1.Fill = lineColor;
            Line1.Stroke = lineColor;
            Line1.Height = 10;
            Line1.Width = 25;
            Line1.Margin = new System.Windows.Thickness(-25,0,0,0);

            //random dodavanje druge linije
            int Height = 0;
            int Width = 0;
            int Lmarg=0;
            int Rmarg = 0;
            switch (rand.Next(0, 3))
            {
                case 1:
                    Height = 25;
                    Width = 10;
                    Lmarg = 0;
                    Rmarg = -25;
                    break;
                case 2:
                    Height = 10;
                    Width = 25;
                    Lmarg = -25;
                    Rmarg = 0;
                    break;
                default:
                    Height = 0;
                    Width = 0;
                    break;
            }


            Line2.Fill = lineColor;
            Line2.Stroke = lineColor;
            Line2.Height = Height;
            Line2.Width = Width;
            Line2.Margin = new System.Windows.Thickness(Lmarg, Rmarg, 0,0);


            TileGrid.Children.Add(Block);
            TileGrid.Children.Add(Line1);
            TileGrid.Children.Add(Line2);

            TileGrid.SetValue(Grid.RowProperty, row);
            TileGrid.SetValue(Grid.ColumnProperty, column);
            TileGrid.SetValue(Grid.RowSpanProperty, 1);
            TileGrid.SetValue(Grid.ColumnSpanProperty, 1);

            GameGrid.Children.Add(TileGrid);
           
            

            //random rotiranje kucice
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
                    angel = 0;  
                    break;
            }

            Rotate(TileGrid, angel);
        }

    }
}

