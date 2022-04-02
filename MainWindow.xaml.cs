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
        DrawBox[][] BoxArray = new DrawBox[7][] //inicialize of array of drawen boxes
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
                RotateTransform activGridAngel = activeGrid.RenderTransform as RotateTransform;

                int column = Grid.GetColumn(activeGrid);
                int row = Grid.GetRow(activeGrid);

                if (!((column == 2 && row == 1) || (column == 5 && row == 6)))
                {
                    activGridAngel.Angle = 0;
                    activeGrid.Children.Clear();
                    BoxArray[row][column] = new DrawBox((Grid)activeGrid, row, column);
                    clickCount();
                }
            }
        }

        private void clickCount()
        {
            Settings.NoOfClicks++;

            MaxNoOfClicks.Content = "Click " + Settings.NoOfClicks;
            NoOfClicks.Content = "Clicks " + Settings.MaxNoOfClicks;

            gameState.endGame(GameGrid);
            changeBoxState(BoxArray);
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
           new DrawStartEnd(GameGrid, 1, 2, true, BoxArray);
           new DrawStartEnd(GameGrid, 6, 5, false, BoxArray);
        }

        private void checkIfWon(int i, int j,string comesFrom)
        {
            if ((i==6) && (j==5))
            {
                gameState.wonGame(GameGrid);
                
            }
            bool upConn = false;
            bool downConn = false;
            bool leftConn = false;
            bool rightConn = false;

            if (((BoxArray[i][j].UpConn == true) && (BoxArray[i - 1][j].DownConn == true))&& (comesFrom != "up")) upConn = true; //check box up conection
            if (((BoxArray[i][j].DownConn == true) && (BoxArray[i + 1][j].UpConn == true))&& (comesFrom != "down")) downConn = true; //check box down conection
            if (((BoxArray[i][j].LeftConn == true) && (BoxArray[i][j - 1].RightConn == true))&& (comesFrom != "left")) leftConn = true;//check box left conection
            if (((BoxArray[i][j].RightConn == true) && (BoxArray[i][j + 1].LeftConn == true))&& (comesFrom != "right")) rightConn = true;//check box right conection

            comesFrom = "";
            if ((upConn)) //check up Box
            {
                i--;
                comesFrom = "down";
                checkIfWon(i, j, comesFrom);
            }
            else if ((leftConn)) //check left Box
            {
                j--;
                comesFrom = "right";
                checkIfWon(i, j, comesFrom);
            }
            else if ((rightConn)) //check right Box
            {
                j++;
                comesFrom = "left";
                checkIfWon(i, j, comesFrom);
            }
            else if ((downConn)) //check down Box
            {
                i++;
                comesFrom = "up";
                checkIfWon(i, j, comesFrom);
            }
        }
        
        private void changeBoxState(DrawBox[][] BoxArray)
        {
            for (int i = 2; i < 6; i++) //first iteration to check box to the connected box
            {
                for (int j = 2; j < 6; j++)
                {

                    if (BoolArrayToInt(BoxArray, i, j)) //check if box has only L or I shape
                    {
                        if ((BoxArray[i][j].directions[0] == true) && (BoxArray[i - 1][j].directions[2] == true)) //check box up conection
                            BoxArray[i][j].UpConn = true; 
                        else 
                            BoxArray[i][j].UpConn = false; 
                        
                        if ((BoxArray[i][j].directions[2] == true) && (BoxArray[i + 1][j].directions[0] == true)) //check box down conection
                            BoxArray[i][j].DownConn = true;
                        else
                            BoxArray[i][j].DownConn = false;

                        if ((BoxArray[i][j].directions[3] == true) && (BoxArray[i][j - 1].directions[1] == true)) //check box left conection
                            BoxArray[i][j].LeftConn = true;
                        else
                            BoxArray[i][j].LeftConn = false;

                        if ((BoxArray[i][j].directions[1] == true) && (BoxArray[i][j + 1].directions[3] == true)) //check box right conection
                            BoxArray[i][j].RightConn = true;
                        else
                            BoxArray[i][j].RightConn = false;
                    }
                }
            }
            checkIfWon(1,2,"up");
        }
        private bool BoolArrayToInt(DrawBox[][] BoxArray, int i, int j) //returns int value from directions, then box is OK, only one input, and one output
        {
            BitArray bitField = new BitArray(BoxArray[i][j].directions.ToArray());
            byte[] bytes = new byte[1];
            bitField.CopyTo(bytes, 0);

            if ((bytes[0] == 3) || (bytes[0] == 6) || (bytes[0] == 9) || (bytes[0] == 12) || (bytes[0] == 5) || (bytes[0] == 10))
            {
                BoxArray[i][j].OkState=true;
                return true;
            }
            else
            {
                BoxArray[i][j].OkState = false;
                return false;
            }
        }
    }
}