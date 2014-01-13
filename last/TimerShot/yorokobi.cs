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


    class yorokobi
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
            while(timecount<=13){
                if((timecount==10)||(timecount==12))
                {
                    sensor.ElevationAngle = 27;
               
                }
                else if((timecount==11)||(timecount==13))
                {
                    sensor.ElevationAngle = 25;
                
                }

                timecount++;
            }
            sensor.ElevationAngle = 0;
        }
        

         
    }
}
