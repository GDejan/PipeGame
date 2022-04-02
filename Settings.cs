using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;


namespace PipeGame
{
    /// <summary>
    /// helper class with game settings
    /// </summary>
    internal class Settings 
    {
        public static SolidColorBrush blockColor 
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb( 100, 0, 255, 255));
            }
        }
        public static SolidColorBrush strokeColor
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(50, 0, 255, 255));
            }
        }
        public static SolidColorBrush lineColor
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(100, 0, 0, 0));
            }
        }
        public static SolidColorBrush wincolor
        {
            get
            {
                return new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
        }
        public static SolidColorBrush looseColor
        {
            get
            {
                return new SolidColorBrush(Color.FromRgb( 255, 0, 0));
            }
        }

        public static int BoxHeight { get; private set; }
        public static int BoxWidth { get; private set; }

        public static int LineHeight { get; private set; }
        public static int LineWidth { get; private set; }
        public static int Marg { get;  private set; }
        public static int CenterOfRotation { get; private set; }
        public static int NoOfClicks { get; set; }
        public static int MaxNoOfClicks { get; private set; }
        public static bool GameOwer { get;  set; }

        public Settings()
        {
            BoxHeight = 50;
            BoxWidth = 50; 
            LineHeight = 25;
            LineWidth = 10;
            Marg = -25; 
            CenterOfRotation = 25; 
            NoOfClicks = -1;
            MaxNoOfClicks = 30;
            GameOwer = false;
        }
    }
}
