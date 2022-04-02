using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PipeGame
{
    public class GameState
    {
        public GameState()
        {

        }

        /// <summary>
        /// check if game ends
        /// </summary>
        /// <param name="GameGrid">grid</param>
        public void endGame(Grid GameGrid)
        {
            if (Settings.NoOfClicks > Settings.MaxNoOfClicks)
            {
                GameGrid.Children.Clear();
                Grid TileGrid = new Grid();
                TileGrid.SetValue(Grid.RowProperty, 3);
                TileGrid.SetValue(Grid.ColumnProperty, 3);
                TileGrid.SetValue(Grid.RowSpanProperty, 3);
                TileGrid.SetValue(Grid.ColumnSpanProperty, 3);

                Label Label = new Label();
                Label.Content = "GAME OWER";
                Label.Foreground = Settings.looseColor;
                Label.FontSize = 20;

                TileGrid.Children.Add(Label);
                GameGrid.Children.Add(TileGrid);
                Settings.GameOwer = true;
            }
        }

        /// <summary>
        /// check if game won
        /// </summary>
        /// <param name="GameGrid">grid</param>
        public void wonGame(Grid GameGrid)
        {
            if (Settings.NoOfClicks <= Settings.MaxNoOfClicks)
            {
                GameGrid.Children.Clear();
                Grid TileGrid = new Grid();
                TileGrid.SetValue(Grid.RowProperty, 3);
                TileGrid.SetValue(Grid.ColumnProperty, 3);
                TileGrid.SetValue(Grid.RowSpanProperty, 3);
                TileGrid.SetValue(Grid.ColumnSpanProperty, 3);

                Label Label = new Label();
                Label.Content = "YOU WON";
                Label.Foreground = Settings.wincolor; 
                Label.FontSize = 20;

                TileGrid.Children.Add(Label);
                GameGrid.Children.Add(TileGrid);
                Settings.GameOwer = true;
            }
        }




    }
}

