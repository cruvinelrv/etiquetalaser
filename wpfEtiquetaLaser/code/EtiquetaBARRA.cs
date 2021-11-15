using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace wpfEtiquetaLaser.code
{
    using Neodynamic.WinControls.BarcodeProfessional;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class EtiquetaBARRA
    {

        string diretorio = @"C:\set\impressoes_html\paginas\";

        public string geraArquivo(string codigo)
        {
            //string arquivo_diretorio_temp = diretorio + "temp.png";
            string arquivo_diretorio = diretorio + codigo + ".png";
            string arquivo = codigo + ".png";

            if (File.Exists(arquivo_diretorio))
                return arquivo;
            /**/
            int w = 150;
            int h = 50;
            Rectangle rect = new Rectangle(0, 0, w, h);
            Rectangle rectTrial = new Rectangle(0, 0, w, 10);
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);

            Brush brWhite = new SolidBrush(Color.White);
            Brush brBlack = new SolidBrush(Color.Black);

            Graphics g = Graphics.FromImage(bmp);
            g.FillRegion(brWhite, new Region(rect));

            //Create a Barcode Professional object
            BarcodeProfessional bcp = new BarcodeProfessional();
            bcp.Symbology = Symbology.Code128;
            bcp.BarHeight = 0.2f;
            bcp.Code = codigo;
            bcp.DrawToBitmap(bmp, rect);

            /*
            bcp.Save(arquivo_diretorio_temp, ImageFormat.Png);
            //agora temos que tirar o TRIAL
            Image img = Image.FromFile(arquivo_diretorio_temp);
            g = Graphics.FromImage(img);
            g.FillRegion(brWhite, new Region(rectTrial));
            img.Save(arquivo_diretorio, ImageFormat.Png);
            */
            //podemos salvar mesmo com o TRIAL
            bcp.Save(arquivo_diretorio, ImageFormat.Png);
            /*
            try
            {
                
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("ocorreu um erro ao gerar o código de barras "+codigo);
            }
            */
            return arquivo;
        }

    }
}
