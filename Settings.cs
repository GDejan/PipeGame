using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace PipeGame
{
    public class Settings
    {
        public SolidColorBrush blockColor 
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(100, 0, 255, 255));
            }
        }
        public SolidColorBrush strokeColor
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(100, 0, 255, 255));
            }
        }
        public SolidColorBrush lineColor
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(100, 0, 0, 0));
            }
        }
        public int BoxHeight { get { return 50; } private set { } }
        public int BoxWidth { get { return 50; } private set { } }

        public int LineHeight { get { return 25; } private set { } }
        public int LineWidth { get { return 10; } private set { } }
        public int Marg { get { return -25; } private set { } }
        public int CenterOfRotation { get { return 25; } private set { } }

        public Settings() 
        {

        }

    }
}
