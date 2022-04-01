using System;
using System.Collections;
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
        private DrawBox[][] BoxArray = new DrawBox[7][] //inicialize of array of drawen boxes
        {
            new DrawBox[]  {new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(), },
            new DrawBox[]  {new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(), },
            new DrawBox[]  {new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(), },
            new DrawBox[]  {new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(), },
            new DrawBox[]  {new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(), },
            new DrawBox[]  {new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(), },
            new DrawBox[]  {new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(),new DrawBox(), },
        };
        GameState gameState = new GameState();
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
            clickCount();
        }

        private void MouseLeftDownEvent(object sender, MouseButtonEventArgs e)
        {
            if (!Settings.GameOwer)
            {
                Rectangle activeRec = (Rectangle)e.OriginalSource;
                Grid activeGrid = activeRec.Parent as Grid;

                RotateTransform activGridAngel = activeGrid.RenderTransform as RotateTransform;

                int column = Grid.GetColumn(activeGrid);
                int row = Grid.GetRow(activeGrid);

                if (!((column == 2 && row == 1) || (column == 5 && row == 6)))
                {
                    BoxArray[row][column].Rotate(activeGrid, (int)activGridAngel.Angle + 90, "R");
                    clickCount();
                }
            }
        }

        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Settings.GameOwer)
            {
                Rectangle activeRec = (Rectangle)e.OriginalSource;
                Grid activeGrid = activeRec.Parent as Grid;

                int column = Grid.GetColumn(activeGrid);
                int row = Grid.GetRow(activeGrid);

                if (!((column == 2 && row == 1) || (column == 5 && row == 6)))
                {
                    activeGrid.Children.Clear();
                    BoxArray[row][column] = new DrawBox((Grid)activeGrid, row, column);
                    clickCount();
                }
            }
        }

        public void NewGame()
        {
            for (int i = 2; i < 6; i++)
            {
                for (int j = 2; j < 6; j++)
                {
                    BoxArray[i][j] = new DrawBox(GameGrid, i, j);
                }
            }
            DrawStartEnd DrawStart = new DrawStartEnd(GameGrid, 1, 2, true);
            DrawStartEnd DrawEnd = new DrawStartEnd(GameGrid, 6, 5, false);
            BoxArray[1][2].directions[1] = DrawStart.directions[1];
            BoxArray[1][2].okState = true;
            BoxArray[6][5].directions[1] = DrawEnd.directions[0];
            BoxArray[6][5].okState = true;
        }


        private void clickCount()
        {
            Settings.NoOfClicks++;

            MaxNoOfClicks.Content = "Click " + Settings.NoOfClicks;
            NoOfClicks.Content = "Clicks " + Settings.MaxNoOfClicks;

            gameState.endGame(GameGrid);
            checkWin(BoxArray);
        }

        //napisati rekurzivnu funkciju koja provjerava da li je sljedeci blok u nizu dobar. Sve dok ne dodje do kraja


        private void checkWin(DrawBox[][] BoxArray)
        {
            for (int i = 2; i < 6; i++) //first iteration to check box to the connected box
            {
                for (int j = 2; j < 6; j++)
                {
                    if (BoolArrayToInt(BoxArray, i, j)) //check if box has only L or I shape
                    {
                        bool upConn = false;
                        bool downConn = false;
                        bool leftConn = false;
                        bool rightConn = false;

                        if ((BoxArray[i][j].directions[0] == true) && (BoxArray[i - 1][j].directions[1] == true)) upConn = true; //check box up conection
                        if ((BoxArray[i][j].directions[0] == true) && (BoxArray[i + 1][j].directions[1] == true)) downConn = true; //check box down conection
                        if ((BoxArray[i][j].directions[0] == true) && (BoxArray[i][j - 1].directions[1] == true)) leftConn = true;//check box left conection
                        if ((BoxArray[i][j].directions[0] == true) && (BoxArray[i][j + 1].directions[1] == true)) rightConn = true;//check box right conection

                        if ((upConn && downConn) || (upConn && leftConn) || (upConn && rightConn) || (upConn && leftConn) || (downConn && leftConn) || (downConn && rightConn) || (leftConn && rightConn))
                        {
                            BoxArray[i][j].okState = true;
                        }
                    }
                    else
                    {
                        BoxArray[i][j].okState = false;
                    }
                }
            }

            for (int i = 2; i < 6; i++) //second iteration to check box to the second box state
            {
                for (int j = 2; j < 6; j++)
                {
                    bool upConn = false;
                    bool downConn = false;
                    bool leftConn = false;
                    bool rightConn = false;

                    if ((BoxArray[i][j].okState == true) && (BoxArray[i - 1][j].okState == true)) upConn = true; //check box up conection
                    if ((BoxArray[i][j].okState == true) && (BoxArray[i + 1][j].okState == true)) downConn = true; //check box down conection
                    if ((BoxArray[i][j].okState == true) && (BoxArray[i][j - 1].okState == true)) leftConn = true;//check box left conection
                    if ((BoxArray[i][j].okState == true) && (BoxArray[i][j + 1].okState == true)) rightConn = true;//check box right conection

                    if ((upConn && downConn) || (upConn && leftConn) || (upConn && rightConn) || (upConn && leftConn) || (downConn && leftConn) || (downConn && rightConn) || (leftConn && rightConn))
                    {
                        BoxArray[i][j].okState = true;
                    }
                    else 
                    {
                        BoxArray[i][j].okState = false;
                    }

                }
            }
        }
        private bool BoolArrayToInt(DrawBox[][] BoxArray, int i, int j) //returns int value from directions, then box is OK, only one input, and one output
        {
            BitArray bitField = new BitArray(BoxArray[i][j].directions.ToArray());
            byte[] bytes = new byte[1];
            bitField.CopyTo(bytes, 0);

            if ((bytes[0] == 3) || (bytes[0] == 5) || (bytes[0] == 6) || (bytes[0] == 9) || (bytes[0] == 10) || (bytes[0] == 12))
            {
                return true;
            }
            else
            {
                return false;
            }
            //return bytes[0];
        }
    }
}
