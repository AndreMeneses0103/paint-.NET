using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {


        // Variaveis globais

        int mx = 0;
        int my = 0;
        int mx2 = 0;
        int my2 = 0;
        int mx3 = 0;
        int my3 = 0;
        int mx4 = 0;
        int my4 = 0;
        int mx5 = 0;
        int my5 = 0;
        int a = 0;
        int red = 0;
        int green = 0;
        int blue = 0;
        int forma = 0;
        float[] tracejado = { 1 };
        float espessura = 0.1f;
        int raio;
        int raiox;
        int raioy;


        public Form1()
        {
            InitializeComponent();
        }


        // Estilo da Caneta
        public Color Cores(int R, int G, int B)
        {
            Color cor = new Color();
            cor = Color.FromArgb(R, G, B);
            return cor;
        }

        public Pen estiloLinha(float[] flinha, Color cor, float esp)
        {
            Pen caneta = new Pen(cor, esp);
            caneta.DashPattern = flinha;
            return caneta;
        }


        //Desenho dos Formatos


        public void pintap(PaintEventArgs e, Pen caneta, int x, int y)
        {
            e.Graphics.DrawLine(estiloLinha(tracejado, Cores(red, green, blue), espessura), x, y, x + 1, y);
        }

        public void retaBres(PaintEventArgs e, Pen caneta, int x0, int y0, int x1, int y1)
        {
            e.Graphics.DrawLine(caneta, x0, y0, x1, y1);
        }

        public void retangulo(PaintEventArgs e, Pen caneta, int x, int y, int largura, int altura)
        {
            int posX;
            int posY;
            if (largura > x)
            {
                posX = x;
                largura = largura - x;
            }
            else
            {
                posX = largura;
                largura = x - largura;
            }

            if (altura > y)
            {
                posY = y;
                altura = altura - y;
            }
            else
            {
                posY = altura;
                altura = y - altura;
            }


            e.Graphics.DrawRectangle(estiloLinha(tracejado, Cores(red, green, blue), espessura + 1), posX, posY, largura, altura);

        }

        public void triangulo(PaintEventArgs e, Pen caneta, int x, int y, int x1, int y1, int x2, int y2)
        {
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x, y, x1, y1);
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x1, y1, x2, y2);
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x2, y2, x, y);
        }

        public void losango(PaintEventArgs e, Pen caneta, int x, int y, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x, y, x1, y1);
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x1, y1, x2, y2);
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x2, y2, x3, y3);
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x3, y3, x, y);
        }

        public void pentagono(PaintEventArgs e, Pen caneta, int x, int y, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x, y, x1, y1);
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x1, y1, x2, y2);
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x2, y2, x3, y3);
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x3, y3, x4, y4);
            retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), x4, y4, x, y);

        }

        public void circulo(PaintEventArgs e, Pen caneta, float raio, float xc, float yc)
        {
            double xi;
            double yi;
            for (int teta = 0; teta <= 360; teta++)
            {
                xi = xc + (raio * Math.Cos(teta));
                yi = yc + (raio * Math.Sin(teta));
                pintap(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), (int)xi, (int)yi);
            }



        }

        public void elipse(PaintEventArgs e, Pen caneta, float raiox, float raioy, float xc, float yc)
        {
            double xi;
            double yi;
            for (int teta = 0; teta <= 360; teta++)
            {
                xi = xc + (raioy * Math.Cos(teta));
                yi = yc + (raiox * Math.Sin(teta));
                pintap(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), (int)xi, (int)yi);
            }
        }





        //Botao da reta
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("CLICOU RETA");
            forma = 0;
        }
        //Botao do Circulo
        private void button2_Click(object sender, EventArgs e)
        {
            forma = 1;
            raio = int.Parse(Interaction.InputBox("Digite o valor do raio", "Raio", "", -1, -1));

        }
        //Botao do elipse
        private void button3_Click(object sender, EventArgs e)
        {
            forma = 2;
            raioy = int.Parse(Interaction.InputBox("Digite o valor da Largura", "RaioX", "", -1, -1));
            raiox = int.Parse(Interaction.InputBox("Digite o valor da Altura", "RaioY", "", -1, -1));
        }
        //Botao do retangulo
        private void button4_Click(object sender, EventArgs e)
        {
            forma = 3;
        }
        //Botao do pentagono
        private void button7_Click(object sender, EventArgs e)
        {
            forma = 4;
        }
        //Botao do losango
        private void button6_Click(object sender, EventArgs e)
        {
            forma = 5;
        }
        //Botao do triangulo
        private void button5_Click(object sender, EventArgs e)
        {
            forma = 6;
        }





        //Botao do contorno
        private void button31_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            tracejado = Form2.traco;
        }

        //Como pedido, nao havera preenchimento, fazendo o botao de preenchimento apenas como design


        //Botao da espessura
        private void button8_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            espessura = Form3.espessura;
        }
        //Botao da Cor Selecionada
        private void button9_Click(object sender, EventArgs e)
        {

        }
        //Botao da Cor Secundaria
        private void button10_Click(object sender, EventArgs e)
        {

        }





        //BOTOES DE CORES

        //Cor Preto
        private void button11_Click(object sender, EventArgs e)
        {
            red = 0;
            green = 0;
            blue = 0;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Cinza
        private void button12_Click(object sender, EventArgs e)
        {
            red = 105;
            green = 105;
            blue = 105;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Vermelho Escuro
        private void button13_Click(object sender, EventArgs e)
        {
            red = 139;
            green = 0;
            blue = 0;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Vermelho Claro
        private void button14_Click(object sender, EventArgs e)
        {
            red = 255;
            green = 0;
            blue = 0;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Laranja
        private void button15_Click(object sender, EventArgs e)
        {
            red = 255;
            green = 165;
            blue = 0;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Amarelo
        private void button16_Click(object sender, EventArgs e)
        {
            red = 255;
            green = 255;
            blue = 0;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Verde Escuro
        private void button17_Click(object sender, EventArgs e)
        {
            red = 50;
            green = 205;
            blue = 50;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Azul Escuro
        private void button18_Click(object sender, EventArgs e)
        {
            red = 30;
            green = 144;
            blue = 255;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Roxo Escuro
        private void button19_Click(object sender, EventArgs e)
        {
            red = 75;
            green = 0;
            blue = 130;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Roxo Claro
        private void button20_Click(object sender, EventArgs e)
        {
            red = 186;
            green = 85;
            blue = 211;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Branco
        private void button30_Click(object sender, EventArgs e)
        {
            red = 255;
            green = 255;
            blue = 255;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Cinza Claro
        private void button29_Click(object sender, EventArgs e)
        {
            red = 211;
            green = 211;
            blue = 211;
            button9.BackColor = (Cores(red, green, blue));
        }

        //Cor Marrom
        private void button28_Click(object sender, EventArgs e)
        {
            red = 205;
            green = 133;
            blue = 63;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Rosa Claro
        private void button27_Click(object sender, EventArgs e)
        {
            red = 255;
            green = 182;
            blue = 193;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Amarelo Escuro
        private void button26_Click(object sender, EventArgs e)
        {
            red = 255;
            green = 215;
            blue = 0;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Bege
        private void button25_Click(object sender, EventArgs e)
        {
            red = 238;
            green = 232;
            blue = 170;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Verde Claro
        private void button24_Click(object sender, EventArgs e)
        {
            red = 173;
            green = 255;
            blue = 47;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Azul Claro
        private void button23_Click(object sender, EventArgs e)
        {
            red = 135;
            green = 206;
            blue = 235;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Cinza Azul
        private void button22_Click(object sender, EventArgs e)
        {
            red = 95;
            green = 158;
            blue = 160;
            button9.BackColor = (Cores(red, green, blue));
        }
        //Cor Roxo Claro
        private void button21_Click(object sender, EventArgs e)
        {
            red = 221;
            green = 160;
            blue = 221;
            button9.BackColor = (Cores(red, green, blue));
        }


        // Eventos do Form
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (a == 0)
            {
                //Clique 1
                mx = e.X;
                my = e.Y;

                if (forma == 1 || forma == 2)
                {
                    a = 0;
                    Invalidate();
                }
                else
                {
                    a++;
                }
            }
            else if (a == 1)
            {
                //Clique 2
                mx2 = e.X;
                my2 = e.Y;

                if (forma == 0 || forma == 3)
                {
                    a = 0;
                    Invalidate();
                }
                else
                {
                    a++;
                }
            }
            else if (a == 2)
            {
                //CLique 3
                mx3 = e.X;
                my3 = e.Y;
                if (forma == 6)
                {
                    a = 0;
                    Invalidate();
                }
                else
                {
                    a++;
                }
            }
            else if (a == 3)
            {
                //Clique 4
                mx4 = e.X;
                my4 = e.Y;
                if (forma == 5)
                {
                    a = 0;
                    Invalidate();
                }
                else
                {
                    a++;
                }
            }
            else if (a == 4)
            {
                //Clique 5
                mx5 = e.X;
                my5 = e.Y;
                a = 0;
                Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (forma == 0)
            {
                retaBres(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), mx, my, mx2, my2);
            }
            else if (forma == 1)
            {
                circulo(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), raio, mx, my);
            }
            else if (forma == 2)
            {
                elipse(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), raiox, raioy, mx, my);
            }
            else if (forma == 3)
            {
                retangulo(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), mx, my, mx2, my2);
            }
            else if (forma == 4)
            {
                pentagono(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), mx, my, mx2, my2, mx3, my3, mx4, my4, mx5, my5);
            }
            else if (forma == 5)
            {
                losango(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), mx, my, mx2, my2, mx3, my3, mx4, my4);
            }
            else if (forma == 6)
            {
                triangulo(e, estiloLinha(tracejado, Cores(red, green, blue), espessura), mx, my, mx2, my2, mx3, my3);
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
        }
    }
}