using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Configuration;


namespace ScreenToClipboard
{

    public partial class CaptureArea : Window
    {
        public static string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string vconfig = System.IO.Path.Combine(appPath, "Options.config");
        public string str;
        public double x;
        public double y;
        public double width;
        public double height;
        public bool isMouseDown = false;
        MainWindow mv = new MainWindow();


        public CaptureArea()
        {

            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
            x = e.GetPosition(null).X-7;
            y = e.GetPosition(null).Y-7;
        }






        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.isMouseDown)
            {
               
                double curx = e.GetPosition(null).X;
                double cury = e.GetPosition(null).Y;

                System.Windows.Shapes.Rectangle r = new System.Windows.Shapes.Rectangle();
                SolidColorBrush brush = new SolidColorBrush(Colors.White);
                r.Stroke = brush;
                r.Fill = brush;
                r.StrokeThickness = 0;
                r.Width = Math.Abs(curx - x);
                r.Height = Math.Abs(cury - y);
                cnv.Children.Clear();
                cnv.Children.Add(r);
                Canvas.SetLeft(r, x);
                Canvas.SetTop(r, y);
                if (e.LeftButton == MouseButtonState.Released)
                {
                    cnv.Children.Clear();
                    width = e.GetPosition(null).X - x;
                    height = e.GetPosition(null).Y - y;
                    this.FirstCaptureScreen(x, y, width, height,str);
                    this.x = 0;
                    this.y = 0;
                    this.isMouseDown = false;
                    this.Hide();
                    
                }
            }
        }

        private void Screenshot()
        {

        }
        
        public void FirstCaptureScreen(double x, double y, double width, double height, string str)
        {
            int ix, iy, iw, ih;
            ix = Convert.ToInt32(x);
            iy = Convert.ToInt32(y);
            iw = Convert.ToInt32(width);
            ih = Convert.ToInt32(height);
            ExeConfigurationFileMap configFileMap = new System.Configuration.ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = vconfig;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);


            string strDeger = ix.ToString() + "," + iy.ToString() + "," + iw.ToString() + "," + ih.ToString();
            switch (str)
            {
                case "first":
                    config.AppSettings.Settings["FirstOcrArea"].Value = strDeger.ToString();
                    config.Save();
                    this.Hide();

                    mv.ShowDialog();
                    break;
                case "second":
                    config.AppSettings.Settings["SecondOcrArea"].Value = strDeger.ToString();
                    config.Save();
                    this.Hide();

                    mv.ShowDialog();
                    break;
                case "thrid":
                    config.AppSettings.Settings["ThirdOcrArea"].Value = strDeger.ToString();
                    config.Save();
                    mv.ShowDialog();
                    this.Hide();
                    break;
                case "fourth":
                    config.AppSettings.Settings["FourthOcrArea"].Value = strDeger.ToString();
                    config.Save();
                    mv.ShowDialog();
                    this.Hide();
                    break;
                case "fifth":
                    config.AppSettings.Settings["FifthOcrArea"].Value = strDeger.ToString();
                    config.Save();
                    mv.ShowDialog();
                    this.Hide();
                    break;
                case "nineth":
                    mv.catchscreenshot(ix,iy,iw,ih);
                    break;

             
            }







        }

        




    }

}

