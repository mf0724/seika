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


    class unazuki
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
            while(timecount<=3){
                if((timecount==0)||(timecount==2))
                {
                    sensor.ElevationAngle = -3;
               
                }
                else if((timecount==1)||(timecount==3))
                {
                    sensor.ElevationAngle = 0;
                
                }

                timecount++;
            }
        }
        

         
    }
}
