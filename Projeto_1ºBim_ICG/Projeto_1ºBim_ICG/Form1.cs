using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_1ºBim_ICG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int desenha = 0;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color cor = Color.FromArgb(0, 0, 0);
            if (desenha == 1)
            {
                linha(e, 100, 100, cor);
            }
        }

        public void Pintap(PaintEventArgs e, int x, int y, Color cor)
        {
            //Eixo X
            x = 0;
            y = 414;
            var xf = 1550;
            var yf = 414;
            Pen caneta1 = new Pen(cor, 0);
            e.Graphics.DrawLine(caneta1, x, y, xf, yf);

            //Eixo Y
            var x1 = 828;
            var y1 = 828;
            var x2 = 828;
            var y2 = 0;
            Pen caneta2 = new Pen(cor, 0);
            e.Graphics.DrawLine(caneta2, x1, y1, x2, y2);

            //Reta
            int xInicial = int.Parse(textBox1.Text);
            int yInicial = int.Parse(textBox2.Text);
            int m = int.Parse(textBox3.Text);
            int xFinal = int.Parse(textBox4.Text);
            int b = int.Parse(textBox5.Text);

            int xFormula = xFinal - xInicial;
                if (xFormula < 0)
                {
                    xFormula = xFormula * -1;
                }
            int yFinal = m * xFormula + b + yInicial;

            Color reta = Color.FromArgb(225, 0, 0);
            Pen caneta = new Pen(reta, 0);                     
            e.Graphics.DrawLine(caneta, xInicial + 828, 414 - yInicial, xFinal + 828 , 414 - yFinal);

            string equacao = "Y = " + m + "x "+ " + " + b;
            label1.Text = equacao;
        }

        public void linha(PaintEventArgs e, int x, int y, Color cor)
        {
            for (int i = 1; i <= 100; i++)
            {
                Pintap(e, x + i, y + i, cor);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            desenha = 1;
            Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
