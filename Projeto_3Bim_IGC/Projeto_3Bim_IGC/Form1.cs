/*Colegio Técnico Antônio Teixeira Fernandes (Univap)
 *Curso Técnico em Informática - Data de Entrega: 30 / 08 / 2023
* Autores do Projeto: Giovana Ferreira Fonseca
*                     Giulia Elisa Pereira
*
* Turma: 3H
* Projeto 3º Bim
 * Observação: < colocar se houver>
 * 
 * Projeto_3Bim_IGC.cs
 * ******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_3Bim_IGC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int coluna = 0;
        int linha = 0;
        int i, j;
        double K;
        Color cor;
        Bitmap img, panela, imgNova, imgCinza, imgBin;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\Imagens\\Imagem_A.jpg");
            pictureBox2.Load("C:\\Imagens\\Imagem_B.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tirarFundo();
            GerarImagem();
            GrayLevel();
            Binario();
            pictureBox1.Image = imgNova;
            pictureBox2.Image = panela;
        }
        public Color botaCor(int a, int r, int g, int b)
        {
            Color cor = Color.FromArgb(a, r, g, b);
            return cor;
        }

        Bitmap tirarFundo()
        {
            img = new Bitmap("C:\\Imagens\\Imagem_B.jpg");
            coluna = img.Width;
            linha = img.Height;
            panela = new Bitmap(coluna, linha);

            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    int r = img.GetPixel(i, j).R;
                    int g = img.GetPixel(i, j).G;
                    int b = img.GetPixel(i, j).B;


                    //1º tira o amarelo, média do r,g      2º reflexo da panela, média do r,g,b
                    if ((r + g) / 2 >= 220 && (r + g + b) / 3 <= 230)
                    {
                        cor = botaCor(0,0,0,0);
                    }
                    else
                    {
                        cor = botaCor(255, r, g, b);
                        panela.SetPixel(i, j, cor);
                    }
                }
            }
            return panela;
        }

        Bitmap GerarImagem()
        {
            imgNova = new Bitmap("C:\\Imagens\\Imagem_A.jpg");
            i = 140;

            for (int y = 0; y < coluna; y++)
            {
                i++;
                j = 0;
                for (int x = 0; x < linha; x++)
                {
                    j++;
                    Color pixels = panela.GetPixel(y, x);
                    if (pixels.A != 0)
                    {
                        imgNova.SetPixel(i, j, pixels);
                    }
                }
            }
            pictureBox3.Image = imgNova;
            imgNova.Save("C:\\Imagens\\Imagem_C.jpg");
            return imgNova;
        }

        public void GrayLevel()
        {
            img = imgNova;
            coluna = img.Width;
            linha = img.Height;
            imgCinza = new Bitmap(coluna, linha);
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    double r = img.GetPixel(i, j).R;
                    double g = img.GetPixel(i, j).G;
                    double b = img.GetPixel(i, j).B;

                    K = r * 0.3 + g * 0.59 + b * 0.11;

                    cor = botaCor(255, (int)K, (int)K, (int)K);
                    imgCinza.SetPixel(i, j, cor);

                }
            }
            imgCinza.Save("C:\\Imagens\\Cinza.jpg");
            pictureBox4.Image = imgCinza;
        }

        public void Binario()
        {
            img = imgNova;
            coluna = img.Width; 
            linha = img.Height; 
            imgBin = new Bitmap(coluna, linha);

            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    double r = img.GetPixel(i, j).R;
                    double g = img.GetPixel(i, j).G;
                    double b = img.GetPixel(i, j).B;

                    K = r * 0.3 + g * 0.59 + b * 0.11;

                    if (K >= 127)
                        K = 255;
                    else
                        K = 0;

                    cor = botaCor(255, (int)K, (int)K, (int)K);
                    imgBin.SetPixel(i, j, cor);

                }
            }
            imgBin.Save("C:\\Imagens\\Binaria.jpg");
            pictureBox5.Image = imgBin;
        }
    }
}
