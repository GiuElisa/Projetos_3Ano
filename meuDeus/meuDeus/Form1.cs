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
using System.IO;

namespace meuDeus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Declaração de Variáveis 
        Pen caneta;
        int r, g, b;
        int esp;
        int estilo = -1;
        int tipo;

        bool line;
        bool circle;
        bool elipse;
        bool square;
        bool tri;
        bool pen;
        bool los;
        bool select;
        bool desenhado;

        int[] pontos = new int[10];

        int clique = 0;

        int raio;
        int raioX;
        int raioY;

        bool carregar;
        string[] dados;

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
            desenhado = false;
        } //Seta as variáveis booleanas como falsas
        public void zerar()
        {
            for (int i = 0; i <= pontos.Length - 1; i++)
            {
                pontos[i] = 0;
            }

            clique = 0;
        } //Zera os pontos gravados no array pontos

        public string concatenarPontos(string ponto)
        {
            for (int i = 0; i <= pontos.Length - 2; i++)
            {
                if (pontos[i] != 0)
                {
                    ponto += pontos[i] + ", ";
                }
            }
            ponto += pontos[pontos.Length - 1];
            return ponto;
        }//Concatena os pontos para passar no arquivo
        public void pegarPontos(string pontosSalvos)
        {
            string[] points = pontosSalvos.Split(new string[] { ", " }, StringSplitOptions.None);
            for (int i = 0; i <= points.Length - 1; i++)
            {
                pontos[i] = int.Parse(points[i]);
            }
        }//Pega os pontos do array

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
            r = 0;
            g = 0;
            b = 0;
            //Preto
        }
        private void button27_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 255;
            b = 255;
            //Branco
        }
        private void button9_Click(object sender, EventArgs e)
        {
            r = 105;
            g = 105;
            b = 105;
            //Cinza escuro
        }
        private void button26_Click(object sender, EventArgs e)
        {
            r = 192;
            g = 192;
            b = 192;
            //Cinza claro
        }
        private void button10_Click(object sender, EventArgs e)
        {
            r = 128;
            g = 0;
            b = 0;
            //Vinho
        }
        private void button25_Click(object sender, EventArgs e)
        {
            r = 160;
            g = 82;
            b = 45;
            //Marrom
        }
        private void button11_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 0;
            b = 0;
            //Vermelho
        }
        private void button24_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 182;
            b = 193;
            //Rosa
        }
        private void button23_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 215;
            b = 0;
            //Amarelo escuro
        }
        private void button12_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 198;
            b = 0;
            //Laranja
        }
        private void button13_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 255;
            b = 0;
            //Amarelo
        }
        private void button22_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 255;
            b = 192;
            //Amarelo claro
        }
        private void button14_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 128;
            b = 0;
            //Verde escuro
        }
        private void button21_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 255;
            b = 0;
            //Verde
        }
        private void button15_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 0;
            b = 255;
            //Azul
        }
        private void button20_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 255;
            b = 255;
            //Azul claro
        }
        private void button16_Click(object sender, EventArgs e)
        {
            r = 72;
            g = 61;
            b = 139;
            //Roxo
        }
        private void button18_Click(object sender, EventArgs e)
        {
            r = 70;
            g = 130;
            b = 180;
            //Azul escuro
        }
        private void button19_Click(object sender, EventArgs e)
        {
            r =186;
            g = 85;
            b = 211;
            //Rosa
        }
        private void button17_Click(object sender, EventArgs e)
        {
            r = 192;
            g = 195;
            b = 255;
            //Lilás
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
                return new float[] { 1.0f };
            }
        }



        //Botões das Formas
        private void button1_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            line = true;
            select = true;
            tipo = 1;
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
            tipo = 2;

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
            tipo = 3;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            square = true;
            select = true;
            tipo = 4;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            los = true;
            select = true;
            tipo = 5;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            tri = true;
            select = true;
            tipo = 6;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            zerar();
            falso();
            pen = true;
            select = true;
            tipo = 7;
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



        ///Arquivos

        //Criar
        private void button29_Click(object sender, EventArgs e)
        {
            SaveFileDialog criar = new SaveFileDialog();
            criar.Filter = "Arquivo (.dat)|.dat";

            if (criar.ShowDialog() == DialogResult.OK)
            {
                string arquivo = criar.FileName;
                string coordenadas = concatenarPontos("");
                File.AppendAllText(arquivo, tipo + Environment.NewLine);
                File.AppendAllText(arquivo, estilo + Environment.NewLine);
                File.AppendAllText(arquivo, esp + Environment.NewLine);
                File.AppendAllText(arquivo, r + Environment.NewLine);
                File.AppendAllText(arquivo, g + Environment.NewLine);
                File.AppendAllText(arquivo, b + Environment.NewLine);
                File.AppendAllText(arquivo, coordenadas + Environment.NewLine);
                File.AppendAllText(arquivo, raio + Environment.NewLine);
                File.AppendAllText(arquivo, raioX + Environment.NewLine);
                File.AppendAllText(arquivo, raioY + Environment.NewLine);

                MessageBox.Show("Arquivo criado com sucesso!");
            }
        }

        //Abrir
        private void button28_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();

            string arquivo = "";
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                arquivo = abrir.FileName;
                if (File.Exists(arquivo))
                {
                    dados = File.ReadAllLines(arquivo);
                    carregar = true;
                    Invalidate();
                }
                else
                {
                    MessageBox.Show("Arquivo não encontrado!");
                }
            } 
        }

        //Salvar
        private void button30_Click(object sender, EventArgs e)
        {
            OpenFileDialog salvar = new OpenFileDialog();

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                string arquivo = salvar.FileName;
                string coordenadas = concatenarPontos("");
                File.AppendAllText(arquivo, tipo + Environment.NewLine);
                File.AppendAllText(arquivo, estilo + Environment.NewLine);
                File.AppendAllText(arquivo, esp + Environment.NewLine);
                File.AppendAllText(arquivo, r + Environment.NewLine);
                File.AppendAllText(arquivo, g + Environment.NewLine);
                File.AppendAllText(arquivo, b + Environment.NewLine);
                File.AppendAllText(arquivo, coordenadas + Environment.NewLine);
                File.AppendAllText(arquivo, raio + Environment.NewLine);
                File.AppendAllText(arquivo, raioX + Environment.NewLine);
                File.AppendAllText(arquivo, raioY + Environment.NewLine);

                MessageBox.Show("Arquivo salvo com sucesso!");
            }
        }

        //Módulo Principal
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            caneta = canetinha(botaCor(r, g, b), esp);

            if(estilo >= 0)
            {
                float[] linhaEst = definirEstilo(estilo);
                caneta = estiloLinha(linhaEst, caneta);
            }

            if (line ==  true)
            {    
                desenharReta(e, pontos[0], pontos[1], pontos[2], pontos[3], caneta);
            }

            if (circle == true)
            {
                desenharCirculo(e, pontos[0] - raio / 2, pontos[1] - raio / 2, raio, caneta);
            }

            if (elipse == true)
            {
                desenharElipse(e, pontos[0] - raioX / 2, pontos[1] - raioY / 2, raioX, raioY, caneta);
            }

            if (square == true)
            {
                desenharRetangulo(e, pontos[0], pontos[1], pontos[2], pontos[3], caneta);
            }

            if (tri == true)
            {
                desenharTriangulo(e, pontos[0], pontos[1], pontos[2], pontos[3], pontos[4], pontos[5], caneta);
            }

            if (pen == true)
            {
                desenharPentagono(e, pontos[0], pontos[1], caneta);
            }

            if (los == true)
            {
                desenharLosango(e, pontos[0], pontos[1], caneta);
            }

            if (carregar == true)
            {
                for(int i = 0; i <= dados.Length - 1; i += 10)
                {
                    Pen canetaArquivo = canetinha(botaCor(int.Parse(dados[i + 3]), int.Parse(dados[i + 4]), int.Parse(dados[i + 5])), int.Parse(dados[i + 2]));
                    float[] estiloCarregado = definirEstilo(int.Parse(dados[i + 1]));
                    canetaArquivo = estiloLinha(estiloCarregado, canetaArquivo);
                    pegarPontos(dados[i + 6]);
                    if (int.Parse(dados[i]) == 1)
                    {
                        desenharReta(e, pontos[0], pontos[1], pontos[2], pontos[3], canetaArquivo);
                    }
                    else if (int.Parse(dados[i]) == 2)
                    {
                        raio = int.Parse(dados[i + 7]);
                        desenharCirculo(e, pontos[0] - raio / 2, pontos[1] - raio / 2, raio, canetaArquivo);
                    }
                    else if (int.Parse(dados[i]) == 3)
                    {
                        raioX = int.Parse(dados[i + 8]);
                        raioY = int.Parse(dados[i + 9]);
                        desenharElipse(e, pontos[0] - raioX / 2, pontos[1] - raioY / 2, raioX, raioY, canetaArquivo);
                    }
                    else if (int.Parse(dados[i]) == 4)
                    {
                        desenharRetangulo(e, pontos[0], pontos[1], pontos[2], pontos[3], canetaArquivo);
                    }
                    else if (int.Parse(dados[i]) == 5)
                    {
                        desenharLosango(e, pontos[0], pontos[1], canetaArquivo);
                    }
                    else if (int.Parse(dados[i]) == 6)
                    {
                        desenharTriangulo(e, pontos[0], pontos[1], pontos[2], pontos[3], pontos[4], pontos[5], canetaArquivo);
                    }
                    else
                    {
                        desenharPentagono(e, pontos[0], pontos[1], canetaArquivo);
                    }
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (desenhado == true)
            {
                zerar();
                desenhado = false;
            }
            if (select == true)
            {
                clique++;
                pontos[(clique * 2) - 2] = e.X; //Pega as coordenadas X e coloca nas posições pares do array
                pontos[(clique * 2) - 1] = e.Y; //Pega as coordenadas Y e coloca nas posições ímpares do array

                if (line == true && clique == 2)
                {
                    Invalidate();
                    desenhado = true;
                }
                else if (tri == true && clique == 3)
                {
                    Invalidate();
                    desenhado = true;
                }
                else if (square ==  true && clique == 2)
                {
                    Invalidate();
                    desenhado = true;
                }
                else if (pen == true && clique == 1)
                {
                    Invalidate();
                    desenhado = true;
                }
                else if (los == true && clique == 1)
                {
                    Invalidate();
                    desenhado = true;
                }
                else if (circle == true && clique == 1)
                {
                    Invalidate();
                    desenhado = true;
                }
                else if (elipse == true && clique == 1)
                {
                    Invalidate();
                    desenhado = true;
                }
            }
        }
    }
}
