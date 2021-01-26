using System;
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
using System.Windows.Shapes;
using AForge.Video;
using AForge.Video.DirectShow;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using System.Threading;
using Microsoft.Win32;

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for Camera.xaml
    /// </summary>
    public partial class Camera : Window
    {

        VideoCaptureDevice LocalWebCam;
        public FilterInfoCollection LoaclWebCamsCollection;

        private BitmapImage _image;
        public BitmapImage Image
        {
            get { return _image; }
            set { Set(ref _image, value); }
        }

        private void Set(ref BitmapImage image, BitmapImage value)
        {
            _image = value;
        }



        void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                BitmapImage bi;
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    MemoryStream ms = new MemoryStream();
                    bitmap.Save(ms, ImageFormat.Bmp);
                    bi.StreamSource = ms;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.EndInit();
                }
                bi.Freeze();

                Dispatcher.BeginInvoke(new ThreadStart(delegate { ImgFrame.Source = bi; }));
            }
            catch (Exception ex)
            {
                //catch your error here
            }

        }
        public Camera()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoaclWebCamsCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            LocalWebCam = new VideoCaptureDevice(LoaclWebCamsCollection[0].MonikerString);
            LocalWebCam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);

            LocalWebCam.Start();
        }


        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }


        private void BtnSaveImg_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = "SnapShot";
            dialog.DefaultExt = ".png";
            var dialogResult = dialog.ShowDialog();
            if (dialogResult != true)
            {
                return;
            }

            Image = (BitmapImage)ImgFrame.Source.CloneCurrentValue();
            
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(Image));
            using (var filestream = new FileStream(dialog.FileName, FileMode.Create))
                encoder.Save(filestream);
        }

        private void BtnExitImg_Click(object sender, RoutedEventArgs e)
        {
            LocalWebCam.SignalToStop();
            this.Close();
        }
    }
}
