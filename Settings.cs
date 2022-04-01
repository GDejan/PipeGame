using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;


namespace PipeGame
{
    internal class Settings //helpers 
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
        public static int BoxHeight { get { return 50; } private set { } }
        public static int BoxWidth { get { return 50; } private set { } }

        public static int LineHeight { get { return 25; } private set { } }
        public static int LineWidth { get { return 10; } private set { } }
        public static int Marg { get { return -25; } private set { } }
        public static int CenterOfRotation { get { return 25; } private set { } }
        public static int NoOfClicks=-1;
        public static int MaxNoOfClicks = 20;
        public static bool GameOwer=false;

        

    }
}
