using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PipeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Box Tile = new Box(); 
        public MainWindow()
        {
            InitializeComponent();
            //GameGrid.Children.Clear();
            NewGame();
        }

        private void NewGame() 
        {
            for (int i = 2; i < 6; i++)
            {
                for (int j = 2; j < 6; j++)
                {
                    Tile.DrawBox(GameGrid, i, j);
                }
            }
        }

        private void MouseLeftDownEvent(object sender, MouseButtonEventArgs e)
        {
            Rectangle activeRec = (Rectangle)e.OriginalSource;
            Grid activeGrid = activeRec.Parent as Grid;
            RotateTransform activGridAngel = activeGrid.RenderTransform as RotateTransform;

            Tile.Rotate(activeGrid, (int)activGridAngel.Angle + 90);
        }

        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle activeRec = (Rectangle)e.OriginalSource;
            Grid activeGrid = activeRec.Parent as Grid;
            RotateTransform activGridAngel = activeGrid.RenderTransform as RotateTransform;

            Tile.Rotate(activeGrid, (int)activGridAngel.Angle - 90);
        }
    }
}
