//------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.ColorBasics
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Kinect;
    using System.Windows.Threading; // for timer

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;

        /// <summary>
        /// Bitmap that will hold color information
        /// </summary>
        private WriteableBitmap colorBitmap;

        /// <summary>
        /// Intermediate storage for the color data received from the camera
        /// </summary>
        private byte[] colorPixels;

        // タイマー
        DispatcherTimer timer;
        // 残り時間をカウントする
        int timeCount;

        // 音声を再生するための自作クラスを定義
        SoundPlayer soundPlayer;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
            
            // サウンドクラスをインスタンス化
            soundPlayer = new SoundPlayer();
            // タイマーのインスタンス化
            timer = new DispatcherTimer();
            // タイマーのインターバルを指定（1秒）
            timer.Interval = new TimeSpan(0, 0, 1);
            timeCount = 3;
            // タイマーイベントの登録
            timer.Tick += timer_Tick;
            Title = "Kinect プリント倶楽部";
            ShotPictureButton.Content = "撮影する";
            TimerLabel.Content = "「撮影する」を押してください。";
            VersionInfoButton.Content = "バージョン情報";
        }

        // タイマーイベント
        void timer_Tick(object sender, EventArgs e)
        {
            sensor.ElevationAngle = 0;
            // サウンドを再生する
            soundPlayer.SoundPlay(timeCount);
            TimerLabel.Content = "撮影まで【" + timeCount + "】秒";
            timeCount--;
            if (timeCount == 0)
            {
                TimerLabel.Content = "撮影まで【" + timeCount + "】秒";

                // 音声を止める
                soundPlayer.StopSound();
                // 画像の撮影
                ShotPicture();

                MessageBox.Show("撮影しました！", "撮影完了", MessageBoxButton.OK, MessageBoxImage.Information);
                KinectCameraElevation();
                timeCount = 3;
                timer.Stop();
            }
        }

        /// <summary>
        /// Execute startup tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Look through all sensors and start the first connected one.
            // This requires that a Kinect is connected at the time of app startup.
            // To make your app robust against plug/unplug, 
            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            if (null != this.sensor)
            {
                // Turn on the color stream to receive color frames
                this.sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

                // Allocate space to put the pixels we'll receive
                this.colorPixels = new byte[this.sensor.ColorStream.FramePixelDataLength];

                // This is the bitmap we'll display on-screen
                this.colorBitmap = new WriteableBitmap(this.sensor.ColorStream.FrameWidth, this.sensor.ColorStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);

                // Set the image we display to point to the bitmap where we'll put the image data
                this.Image.Source = this.colorBitmap;

                // Add an event handler to be called whenever there is new color frame data
                this.sensor.ColorFrameReady += this.SensorColorFrameReady;

                // Start the sensor!
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

            if (null == this.sensor)
            {
                this.statusBarText.Text = Properties.Resources.NoKinectReady;
            }
        }

        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (null != this.sensor)
            {
                sensor.ElevationAngle = 0;
                this.sensor.Stop();
            }
        }

        /// <summary>
        /// Event handler for Kinect sensor's ColorFrameReady event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void SensorColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (colorFrame != null)
                {
                    // Copy the pixel data from the image to a temporary array
                    colorFrame.CopyPixelDataTo(this.colorPixels);

                    // Write the pixel data into our bitmap
                    this.colorBitmap.WritePixels(
                        new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight),
                        this.colorPixels,
                        this.colorBitmap.PixelWidth * sizeof(int),
                        0);
                }
            }
        }

        // 「撮影する」ボタンをおした時の動作
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // タイマーをスタートさせる
            timer.Start();
        }

        // Kinectセンサーの首振り
        public void KinectCameraElevation()
        {
            sensor.ElevationAngle = 27;

            // センサーが動く時間の猶予
            System.Threading.Thread.Sleep(500);

            sensor.ElevationAngle = -27;
        }


        public void ShotPicture()
        {
             if (null == this.sensor)
            {
                this.statusBarText.Text = Properties.Resources.ConnectDeviceFirst;
                return;
            }

            // create a png bitmap encoder which knows how to save a .png file
            BitmapEncoder encoder = new PngBitmapEncoder();

            // create frame from the writable bitmap and add to encoder
            encoder.Frames.Add(BitmapFrame.Create(this.colorBitmap));

            string time = System.DateTime.Now.ToString("hh'-'mm'-'ss", CultureInfo.CurrentUICulture.DateTimeFormat);

            string myPhotos = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            string path = Path.Combine(myPhotos, time + ".png");

            // write the new file to disk
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    encoder.Save(fs);
                }

                this.statusBarText.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}", Properties.Resources.ScreenshotWriteSuccess, path);
            }
            catch (IOException)
            {
                this.statusBarText.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}", Properties.Resources.ScreenshotWriteFailed, path);
            }
        }

        // バージョン情報をおした時の動作
        private void VersionInfoButton_Click(object sender, RoutedEventArgs e)
        {
            VersionInfo verInfo = new VersionInfo();

            verInfo.Show();
        }
    }
}