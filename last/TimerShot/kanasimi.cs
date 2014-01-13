namespace Microsoft.Samples.Kinect.ColorBasics
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Kinect;
    using System.Windows.Threading;


    class kanasimi
    {
         DispatcherTimer timer;
        int timecount;
        int count;
        int kai=0;

        public MainWindow()
        {

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1/2);
            timecount = 0;
            timer.Tick += timer_Tick;
            count = 0;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            while(timecount<=15){
                if((timecount<9))
                {
                    sensor.ElevationAngle =-27;
               
                }
                else
                {
                    sensor.ElevationAngle = 0;
                
                }

                timecount++;
            }
        }
        

         
    }
}
