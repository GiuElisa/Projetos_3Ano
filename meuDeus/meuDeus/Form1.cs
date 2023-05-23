/*Colegio Técnico Antônio Teixeira Fernandes (Univap)
* Curso Técnico em Informática - Data de Entrega: 24 / 05 / 2023
* Autores do Projeto: Giovana Ferreira Fonseca
*                     Giulia Elisa Pereira
*
* Turma: 3H
* Observação:
* 
* Projeto2BIm.cs
* ******************************************************************/

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meuDeus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Declaração de Variáveis 
        Color cor;
        Pen caneta;
        int esp;
        int estilo = -1;

        bool line;
        bool circle;
        bool elipse;
        bool square;
        bool tri;
        bool pen;
        bool los;
        bool select;

        int[] pontos = new int[10];

        int clique = 0;

        int raio;
        int raioX;
        int raioY;

        //Funções
        public void falso()
        {
            line = false;
            circle = false;
            elipse = false;
            square = false;
            tri = false;
            pen = false;
            los = false;
            select = false;
        } //Seta as variáveis booleanas como falsas
        public void zerar()
        {
            for (int i = 0; i <= pontos.Length - 1; i++)
            {
                pontos[i] = 0;
            }

            clique = 0;
        } //Zera os pontos gravados no array pontos

        //Primitivas
        public Color botaCor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }
        public Pen canetinha(Color cor, int esp)
        {
            return new Pen(cor, esp);
        }
        public Pen estiloLinha(float[] linha, Pen caneta)
        {
            caneta.DashPattern = linha;
            return caneta;
        }
        public void desenharReta(PaintEventArgs e, int x0, int y0, int x1, int y1, Pen caneta)
        {
            e.Graphics.DrawLine(caneta, x0, y0, x1, y1);
        }
        public void desenharForma(PaintEventArgs e, int[] pontos, Pen caneta)
        {
            for (int i = 0; i < pontos.Length - 2; i += 2)
            {
                desenharReta(e, pontos[i], pontos[i + 1], pontos[i + 2], pontos[i + 3], caneta);
            }
            desenharReta(e, pontos[0], pontos[1], pontos[pontos.Length - 2], pontos[pontos.Length - 1], caneta);
        }



        //Botões das Cores
        private void button8_Click(object sender, EventArgs e)
        {
            cor = botaCor(0, 0, 0); //Preto
        }
        private void button27_Click(object sender, EventArgs e)
        {
            cor = botaCor(255, 255, 255); //Branco
        }
        private void button9_Click(object sender, EventArgs e)
        {
            cor = botaCor(105, 105, 105); //Cinza escuro
        }
        private void button26_Click(object sender, EventArgs e)
        {
            cor = botaCor(192, 192, 192); //Cinza claro
        }
        private void button10_Click(object sender, EventArgs e)
        {
            cor = botaCor(128, 0, 0); //Vinho
        }
        private void button25_Click(object sender, EventArgs e)
        {
            cor = botaCor(160, 82, 45); //Marrom
        }
        private void button11_Click(object sender, EventArgs e)
        {
            cor = botaCor(255, 0, 0); //Vermelho
        }
        private void button24_Click(object sender, EventArgs e)
        {
            cor = botaCor(255, 182, 193); //Rosa
        }
        private void button23_Click(object sender, EventArgs e)
        {
            cor = botaCor(255, 215, 0); //Amarelo escuro
        }
        private void button12_Click(object sender, EventArgs e)
        {
            cor = botaCor(255, 198, 0); //Laranja
        }
        private void button13_Click(object sender, EventArgs e)
        {
            cor = botaCor(255, 255, 0); //Amarelo
        }
        private void button22_Click(object sender, EventArgs e)
        {
            cor = botaCor(255, 255, 192); //Amarelo claro
        }
        private void button14_Click(object sender, EventArgs e)
        {
            cor = botaCor(0, 128, 0); //Verde escuro
        }
        private void button21_Click(object sender, EventArgs e)
        {
            cor = botaCor(0, 255, 0); //Verde
        }
        private void button15_Click(object sender, EventArgs e)
        {
            cor = botaCor(0, 0, 255); //Azul
        }
        private void button20_Click(object sender, EventArgs e)
        {
            cor = botaCor(0, 255, 255); //Azul claro
        }
        private void button16_Click(object sender, EventArgs e)
        {
            cor = botaCor(72, 61, 139); //Roxo
        }
        private void button18_Click(object sender, EventArgs e)
        {
            cor = botaCor(70, 130, 180); //Azul escuro
        }
        private void button19_Click(object sender, EventArgs e)
        {
            cor = botaCor(186, 85, 211); //Rosa
        }
        private void button17_Click(object sender, EventArgs e)
        {
            cor = botaCor(192, 195, 255); //Lilás
        }



        //Espessura
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != null)
            {
                esp = int.Parse(comboBox1.SelectedIndex.ToString());
            }
        }



        //Estilo
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != null)
            {
                estilo = comboBox2.SelectedIndex;
            }
        }

        public float[] definirEstilo(int estilo)
        {
            if (estilo == 0)
            {
                return new float[4] { 5, 2, 1, 2 };
            }
            else if (estilo == 1)
            {
                return new float[4] { 10, 2, 1, 2 };
            }
            else if (estilo == 2)
            {
                return new float[6] { 5, 2, 1, 1, 1, 2};
            }
            else if (estilo == 3)
            {
                return new float[2] { 15, 2 };
            }
            else if (estilo == 4)
            {
                return new float[2] { 5, 5 };
            }
            else
            {
                return new float[2] { 0, 0 };
            }
        }



        //Botões das Formas
        private void button1_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            line = true;
            select = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            circle = true;
            select = true;
            try
            {
                raio = int.Parse(Interaction.InputBox("Informe o raio:", "Círculo", "", 200, 200));

            }
            catch
            {
                //Tratamento de erro
            }

        }
        private void button7_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            elipse = true;
            select = true;

            try
            {
                raioX = int.Parse(Interaction.InputBox("Informe o raio X", "Elipse", "", 400, 400));
                raioY = int.Parse(Interaction.InputBox("Informe o raio Y", "Elipse", "", 400, 400));
            }
            catch
            {
                //Tratamento de erro
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            square = true;
            select = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            los = true;
            select = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            tri = true;
            select = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            pen = true;
            select = true;
        }

        ///Formas

        //Retângulo
        public void desenharRetangulo(PaintEventArgs e, int x0, int y0, int x1, int y1, Pen caneta)
        {
            desenharReta(e, x0, y0, x1, y0, caneta);
            desenharReta(e, x1, y0, x1, y1, caneta);
            desenharReta(e, x1, y1, x0, y1, caneta);
            desenharReta(e, x0, y1, x0, y0, caneta);
        }

        //Triângulo
        public void desenharTriangulo(PaintEventArgs e, int x0, int y0, int x1, int y1, int x2, int y2, Pen caneta)
        {
            desenharReta(e, x0, y0, x1, y1, caneta);
            desenharReta(e, x1, y1, x2, y2, caneta);
            desenharReta(e, x2, y2, x0, y0, caneta);
        }

        //Losango
        public void desenharLosango(PaintEventArgs e, int x, int y, Pen caneta)
        {
            int[] coordenada = new int[8] { x, y - 150, x + 75, y, x, y + 150, x - 75, y }; //desenha o losango a partir do ponto que foi clicado
            desenharForma(e, coordenada, caneta);
        }

        //Pentágono
        public void desenharPentagono(PaintEventArgs e, int x, int y, Pen caneta)
        {
            int[] coordenada = new int[10] { x, y - 100, x + 75, y, x + 75, y + 100, x - 75, y + 100, x - 75, y }; //desenha o pentágono a partir do ponto que foi clicado
            desenharForma(e, coordenada, caneta);
        }

        //Círculo
        public void desenharCirculo(PaintEventArgs e, int xc, int yc, int raio, Pen caneta)
        {
            int x;
            int y;
            double angulo;

            for (int i = 0; i < 360; i++)
            {
                angulo = i * Math.PI / 180;
                x = (int)(xc + raio * Math.Cos(angulo));
                y = (int)(yc + raio * Math.Sin(angulo));
                desenharReta(e, x, y, x + 1, y, caneta);

            }
        }

        //Elipse
        public void desenharElipse(PaintEventArgs e, int xc, int yc, int raiox, int raioy, Pen caneta)
        {
            int x;
            int y;
            double angulo;
            for (int i = 0; i < 360; i++)
            {
                angulo = i * Math.PI / 180;
                x = (int)(xc + raiox * Math.Cos(angulo));
                y = (int)(yc + raioy * Math.Sin(angulo));
                desenharReta(e, x, y, x + 1, y, caneta);
            }
        }



        //Módulo Principal
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (cor.IsEmpty)
            {
                caneta = canetinha(botaCor(0,0,0), esp);
            }
            else
            {
                caneta = canetinha(cor, esp);
            }

            if(estilo >= 0)
            {
                float[] linhaEst = definirEstilo(estilo);
                caneta = estiloLinha(linhaEst, caneta);
            }

            if (line ==  true)
            {    
                desenharReta(e, pontos[0], pontos[1], pontos[2], pontos[3], caneta);
                zerar();
            }

            if (circle == true)
            {
                desenharCirculo(e, pontos[0] - raio / 2, pontos[1] - raio / 2, raio, caneta);
                zerar();
            }

            if (elipse == true)
            {
                desenharElipse(e, pontos[0] - raioX / 2, pontos[1] - raioY / 2, raioX, raioY, caneta);
                zerar();
            }

            if (square == true)
            {
                desenharRetangulo(e, pontos[0], pontos[1], pontos[2], pontos[3], caneta);
                zerar();
            }

            if (tri == true)
            {
                desenharTriangulo(e, pontos[0], pontos[1], pontos[2], pontos[3], pontos[4], pontos[5], caneta);
                zerar();
            }

            if (pen == true)
            {
                desenharPentagono(e, pontos[0], pontos[1], caneta);
                zerar();
            }

            if (los == true)
            {
                desenharLosango(e, pontos[0], pontos[1], caneta);
                zerar();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (select == true)
            {
                clique++;
                pontos[(clique * 2) - 2] = e.X; //Pega as coordenadas X e coloca nas posições pares do array
                pontos[(clique * 2) - 1] = e.Y; //Pega as coordenadas Y e coloca nas posições ímpares do array

                if (line == true && clique == 2)
                {
                    Invalidate();
                }
                else if (tri == true && clique == 3)
                {
                    Invalidate();
                }
                else if (square ==  true && clique == 2)
                {
                    Invalidate();
                }
                else if (pen == true && clique == 1)
                {
                    Invalidate();
                }
                else if (los == true && clique == 1)
                {
                    Invalidate();
                }
                else if (circle == true && clique == 1)
                {
                    Invalidate();
                }
                else if (elipse == true && clique == 1)
                {
                    Invalidate();
                }
            }
        }
    }
}
