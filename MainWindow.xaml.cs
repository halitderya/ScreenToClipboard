using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Interop;
using System.Windows.Forms;


namespace ScreenToClipboard
{


    public partial class MainWindow : Window
    {
        int p = 0;
        /// <hotkey>

        [DllImport("User32.dll")]
        private static extern bool RegisterHotKey(
         [In] IntPtr hWnd,
          [In] int id,
          [In] uint fsModifiers,
          [In] uint vk);

        [DllImport("User32.dll")]
        private static extern bool UnregisterHotKey(
            [In] IntPtr hWnd,
            [In] int id);
        public int ix, iy, iw, ih;

        public static string lang = "";
        private HwndSource _source;



        


        private const int HOTKEY_ID = 9000;
        const uint VK_F10 = 0x79;
        const uint MOD_CTRL = 0x0002;
        const uint PRINTSCREEN = 0x2C;
        const uint LSHIFT = 0xA0;
        uint FirstKey=0;
        uint SecondKey=0;

            







        /// </hotkey>

        public String ImagePath = "c:\\users\\halit.derya\\desktop\\" + "test.jpg";
     //   public String StoreTextFilePath = "c:\\users\\halit.derya\\desktop\\" + "SampleText.txt";

        public int i = 0;

        List<string> myCollection = new List<string>();


        string[] first, second, third, fourth, fifth;
        public NotifyIcon nef = new NotifyIcon();
        public static string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string vconfig = System.IO.Path.Combine(appPath, "Options.config");
        public double x;
        public double y;
        public double width;
        public double height;
        public bool isMouseDown = false;




        public MainWindow()
        {
            InitializeComponent();






        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var helper = new WindowInteropHelper(this);
            _source = HwndSource.FromHwnd(helper.Handle);
            _source.AddHook(HwndHook);
            RegisterHotKey();
        }

        protected override void OnClosed(EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            _source = null;
            UnregisterHotKey();
            base.OnClosed(e);
        }
        private void shortcut()
        {
            if (shiftkey.IsChecked==true)
            {
                FirstKey = LSHIFT;
            }

            else
            {
                FirstKey = MOD_CTRL;
            }
            if (Printscreenkey.IsChecked==true)

            {
                SecondKey = PRINTSCREEN;

            }

                    else
            {
                SecondKey = VK_F10;

            }


        }



        private void RegisterHotKey()
        {
            var helper = new WindowInteropHelper(this);

            

            if (!RegisterHotKey(helper.Handle, HOTKEY_ID, FirstKey, SecondKey))
            {
                // handle error
            }
        }

        private void UnregisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            UnregisterHotKey(helper.Handle, HOTKEY_ID);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID:
                            OnHotKeyPressed();
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        private void OnHotKeyPressed()
        {
            if (cbscrshoot.IsChecked == true)
            {
                i = 9;
                SendToCapture("nineth");
               
            }

            else
            {

                if (firstocrcb.IsChecked == true)
                {
                    i = 1;
                }
                if (secondocrcb.IsChecked == true)
                {
                    i = 2;

                }
                if (thirdocrcb.IsChecked == true)
                {
                    i = 3;
                }
                if (fourthocrcb.IsChecked == true)
                {
                    i = 4;
                }
                if (fifthocrcb.IsChecked == true)
                {
                    i = 5;
                }
            }
            catchscreen(i);
        }


        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {


        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {

        }




        private void firstocr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            SendToCapture("first");




        }

        private void secondocr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            SendToCapture("second");






        }


        private void SendToCapture(string hedef)
        {
            CaptureArea cap = new CaptureArea();
            switch (hedef)
            {
                case "first":
                    cap.str = "first";
                    break;
                case "second":
                    cap.str = "second";
                    break;
                case "thrid":
                    cap.str = "thrid";
                    break;
                case "fourth":
                    cap.str = "fourth";
                    break;
                case "fifth":
                    cap.str = "fifth";
                    break;
                case "nineth":
                    cap.str = "nineth";
                    break;
                        
                   


            }
            this.Hide();
            cap.ShowDialog();

        }

        public void SaveScreen(double x, double y, double width, double height, int p)
        {
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
        }

        public void catchscreenshot(int x, int y, int width, int height)
        {
            sendtoocrscreen(9,x,y,width,height);
        }
        private void catchscreen(int i)
        {
            if (i != 9)
            {

                for (p = 0; p < i; p++)
                {


                    string[] dosya = { };

                    switch (p)
                    {
                        case 0:
                            dosya = first;
                            break;
                        case 1:
                            dosya = second;
                            break;
                        case 2:
                            dosya = third;
                            break;
                        case 3:
                            dosya = fourth;
                            break;
                        case 4:
                            dosya = fifth;
                            break;
                        default:
                            sendtoocr(9);
                            break;
                    }


                    double x = Convert.ToDouble(dosya[0]);
                    double y = Convert.ToDouble(dosya[1]);
                    double w = Convert.ToDouble(dosya[2]);
                    double h = Convert.ToDouble(dosya[3]);



                    ix = Convert.ToInt32(x);
                    iy = Convert.ToInt32(y);
                    iw = Convert.ToInt32(w);
                    ih = Convert.ToInt32(h);
                    sendtoocr(p);

                }
            }

            else if (i == 9)
            {
                sendtoocrscreen(9, ix, iy, iw, ih);
            }




            






        }
        private void sendtoocrscreen (int p, int x, int y, int w, int h)
        {
            try
            {
                Rectangle rect = new Rectangle(x, y, w, h);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format16bppRgb555);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                string Path = "C:\\users\\halit.derya\\desktop\\test";
                bmp.Save(Path + p.ToString() + ".tiff", ImageFormat.Tiff);
                OCRWorks.ReadTextFromImage(Path + p.ToString() + ".tiff", p, lang);
            }
            catch { }
        }
        public void sendtoocr(int p)
        {
            try
            {
                Rectangle rect = new Rectangle(ix, iy, iw, ih);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format16bppRgb555);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                string Path = "C:\\users\\halit.derya\\desktop\\test";
                bmp.Save(Path + p.ToString() + ".tiff", ImageFormat.Tiff);
                OCRWorks.ReadTextFromImage(Path + p.ToString() + ".tiff", p, lang);
            }
            catch { }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           



        }

        private void button1_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {



        }
        private void fillocrs()
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = vconfig;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            lang = config.AppSettings.Settings["lang"].Value;
            firstocr.Content = config.AppSettings.Settings["FirstOcrArea"].Value;
            secondocr.Content = config.AppSettings.Settings["SecondOcrArea"].Value;
            thirdocr.Content = config.AppSettings.Settings["ThirdOcrArea"].Value;
            fourthocr.Content = config.AppSettings.Settings["FourthOcrArea"].Value;
            fifthocr.Content = config.AppSettings.Settings["FifthOcrArea"].Value;
           

            switch(lang)
            {
                case "eng": cbeng.IsChecked = true;
                    break;
                case "tur": cbtur.IsChecked = true;
                    break;
                case "fre":cbfre.IsChecked = true;
                    break;
                case "sys":cbsys.IsChecked = true;
                    break;
            }
        }

        private void thirdocr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SendToCapture("thrid");

        }

        private void fourthocr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SendToCapture("fourth");

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
          
           



        }

        private void minimize()
        {

            nef.MouseClick += delegate
            {

                this.Show();
                this.WindowState = WindowState.Normal;
                
            };
            this.WindowState = WindowState.Minimized;
            nef.Icon = new Icon(appPath + "\\icon.ico");
            nef.Text = "Screen To Clipboard";
          
            nef.Visible = true;
            nef.ShowBalloonTip(100, "Screen To Clipboard", "Will be read automatically",  ToolTipIcon.Info);
            this.Hide();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            minimize();
        

        }

        private void fifthocrcb_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void mycbevent(object sender, RoutedEventArgs e)
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = vconfig;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            string cbname = ((System.Windows.Controls.CheckBox)sender).Name;
            switch (cbname)
            {
                case "firstocrcb":
                    config.AppSettings.Settings["cb1"].Value = "false";
                    config.Save();
                    firstocr.IsEnabled = false;

                    break;
                case "secondocrcb": 
                    config.AppSettings.Settings["cb2"].Value = "false";
                    config.Save();
                    secondocr.IsEnabled = false;


                    break;
                case "thirdocrcb":
                    config.AppSettings.Settings["cb3"].Value = "false";
                    config.Save();
                    thirdocr.IsEnabled = false;

                    break;
                case "fourthocrcb":
                    config.AppSettings.Settings["cb4"].Value = "false";
                    fourthocr.IsEnabled = false;
                    config.Save();

                    break;
                case "fifthocrcb":
                    config.AppSettings.Settings["cb5"].Value = "false";
                    config.Save();
                    fifthocr.IsEnabled = false;

                    break;
                  
            }
        }

        private void cbchecked(object sender, RoutedEventArgs e)
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = vconfig;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            string cbname = ((System.Windows.Controls.CheckBox)sender).Name;
            switch (cbname)
            {
                case "firstocrcb":
                    config.AppSettings.Settings["cb1"].Value = "true";
                    config.Save();
                    firstocr.IsEnabled = true;

                    break;
                case "secondocrcb":
                    config.AppSettings.Settings["cb2"].Value = "true";
                    config.Save();
                    secondocr.IsEnabled = true;


                    break;
                case "thirdocrcb":
                    config.AppSettings.Settings["cb3"].Value = "true";
                    config.Save();
                    thirdocr.IsEnabled = true;

                    break;
                case "fourthocrcb":
                    config.AppSettings.Settings["cb4"].Value = "true";
                    fourthocr.IsEnabled = true;
                    config.Save();

                    break;
                case "fifthocrcb":
                    config.AppSettings.Settings["cb5"].Value = "true";
                    config.Save();
                    fifthocr.IsEnabled = true;

                    break;






            }
        }

        private void screenshotchked(object sender, RoutedEventArgs e)
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = vconfig;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            config.AppSettings.Settings["mode"].Value = "Screenshot";
            config.Save();

        }

        private void predeterminedchked(object sender, RoutedEventArgs e)
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = vconfig;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            config.AppSettings.Settings["mode"].Value = "Predetermined";
            config.Save();

        }

        private void langcbchecked(object sender, RoutedEventArgs e)
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = vconfig;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            string langcbname = ((System.Windows.Controls.RadioButton)sender).Name;

            switch(langcbname)
            {
                case "cbeng":
                    config.AppSettings.Settings["lang"].Value = "eng";
                    config.Save();
                    break;
                case "cbfre":
                    config.AppSettings.Settings["lang"].Value = "fre";
                    config.Save();
                    break;
                case "cbtur":
                    config.AppSettings.Settings["lang"].Value = "tur";
                    config.Save();
                    break;
                case "cbsys":
                    config.AppSettings.Settings["lang"].Value = "sys";
                    config.Save();
                    break;

               

            }



        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                minimize();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            nef.Visible = false;

            System.Windows.Forms.Application.Exit();

        }

        private void fifthocr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SendToCapture("fifth");

        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            char kar = ',';

            fillocrs();
            shortcut();

            first = firstocr.Content.ToString().Split(kar);
            second = secondocr.Content.ToString().Split(kar);
            third = thirdocr.Content.ToString().Split(kar);
            fourth = fourthocr.Content.ToString().Split(kar);
            fifth = fifthocr.Content.ToString().Split(kar);
            ExeConfigurationFileMap configFileMap = new System.Configuration.ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = vconfig;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            string mode = config.AppSettings.Settings["mode"].Value;
            switch (mode)
            {
                case "Screenshot":
                    cbscrshoot.IsChecked = true;
                    break;
                case "Predetermined":
                    cbpredetermined.IsChecked = true;
                    break;
            }



            firstocr.Content = config.AppSettings.Settings["FirstOcrArea"].Value;
            string lang = config.AppSettings.Settings["lang"].Value;
            if (config.AppSettings.Settings["cb1"].Value == "true")
            { firstocrcb.IsChecked = true;
                firstocr.IsEnabled = true;
            }

            if (config.AppSettings.Settings["cb2"].Value == "true")
            {
                secondocrcb.IsChecked = true;
                secondocr.IsEnabled = true;
            }
            if (config.AppSettings.Settings["cb3"].Value == "true")
            {
                thirdocrcb.IsChecked = true;
                thirdocr.IsEnabled = true;
            }
            if (config.AppSettings.Settings["cb4"].Value == "true")
            {
                fourthocrcb.IsChecked = true;
                fourthocr.IsEnabled = true;
            }
            if (config.AppSettings.Settings["cb5"].Value == "true")
            {
                fifthocrcb.IsChecked = true;
                fifthocr.IsEnabled = true;
            }


        }

        private void firstocrcb_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void firstocrcb_Unchecked(object sender, RoutedEventArgs e)
        {
           

        }
    }

    internal class NativeMethods
    {

        [DllImport("user32.dll")]
        public extern static IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("gdi32.dll")]
        public static extern UInt64 BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, System.Int32 dwRop);

    }

}
