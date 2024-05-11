using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScreenToClipboard
{
    public class OCRWorks
    {


        #region Methods

        public static string[] word = { "", "", "", "", "" };
        public static string w = ("");


        public static void ReadTextFromImage(String ImagePath, int sayi,string lang)
        { ;
            MODI.MiLANGUAGES mod = new MODI.MiLANGUAGES();

            switch(lang)
            {
                case "eng": mod = MODI.MiLANGUAGES.miLANG_ENGLISH;
                    break;
                case "tur": mod = MODI.MiLANGUAGES.miLANG_TURKISH;
                    break;
                case "fre":mod = MODI.MiLANGUAGES.miLANG_FRENCH;
                    break;
                case "sys":mod = MODI.MiLANGUAGES.miLANG_SYSDEFAULT;
                    break;
            }





            MainWindow mv = new MainWindow();
            try
            {
                if(sayi!=9)
                { 
                MODI.Document ModiObj = new MODI.Document();
                ModiObj.Create(ImagePath);
                ModiObj.OCR(mod, false, false);
                MODI.Image ModiImageObj = (MODI.Image)ModiObj.Images[0];
                word[sayi] = ModiImageObj.Layout.Text;
                    System.Windows.Forms.Clipboard.SetText(word[0] + word[1] + word[2] + word[3] + word[4]);

                }

                else if (sayi==9)
                {
                    MODI.Document ModiObj = new MODI.Document();
                    ModiObj.Create(ImagePath);
                    ModiObj.OCR(mod, false, false);
                    MODI.Image ModiImageObj = (MODI.Image)ModiObj.Images[0];
                    w = ModiImageObj.Layout.Text;
                    System.Windows.Forms.Clipboard.SetText(w);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion
    }


}

