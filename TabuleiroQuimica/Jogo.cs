using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabuleiroQuimica
{

    public partial class Jogo : Form
    {
        // DECLARAR VARÍAVEIS
        public int dado, i, casadojogador1 = 0, rodada = 1, casadojogador2 = 0;
        public static string x;

        public Jogo()
        {
            InitializeComponent();
        }

        // VOLTAR SE ERRAR PERGUNTA
        private void timerresposta_Tick(object sender, EventArgs e)
        {
            Panel[] casas = { inicio6, casa75, casa74, casa73, casa72, casa71, casa70, casa69, casa68, casa67, casa66, casa65, casa64, casa63, casa62, casa61, casa60, casa59, casa58, casa57, casa56, casa55, casa54, casa53, casa52, casa51, casa50, casa49, casa48, casa47, casa46, casa45, casa44, casa43, casa42, casa41, casa40, casa39, casa38, casa37, casa36, casa35, casa34, casa33, casa32, casa31, casa30, casa29, casa28, casa27, casa26, casa25, casa24, casa23, casa22, casa21, casa20, casa19, casa18, casa17, casa16, casa15, casa14, casa13, casa12, casa11, casa10, casa9, casa8, casa7, casa6, casa5, casa4, casa3, casa2, casa1, inicio6 };
            if (Class1.gatilho == 1)
            {
                Class1.gatilho = 0;
                if (rodada == 2)
                {
                    casadojogador1 -= dado;
                    pictureBox1.Parent = casas[casadojogador1];
                }
                else if(rodada == 1)
                {
                    casadojogador2 -= dado;
                    pictureBox2.Parent = casas[casadojogador2];
                }
            }
        }

        // ACIONAR O DADO
        private void acionardado_Click(object sender, EventArgs e)
        {
            timerdado.Enabled = true;
            i = 0;
        }

        // BOTÃO SAIR
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // BOTÃO VOLTAR
        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel3.Enabled = false;
            panel3.TabIndex = 0;
        }

        // BOTÃO MENU
        private void btn_menu_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
            panel3.Visible = true;
            panel3.Enabled = true;
        }

        // RODAR O DADO E MOVER
        private void timerdado_Tick(object sender, EventArgs e)
        {
            Panel[] casas = { inicio6, casa75, casa74, casa73, casa72, casa71, casa70, casa69, casa68, casa67, casa66, casa65, casa64, casa63, casa62, casa61, casa60, casa59, casa58, casa57, casa56, casa55, casa54, casa53, casa52, casa51, casa50, casa49, casa48, casa47, casa46, casa45, casa44, casa43, casa42, casa41, casa40, casa39, casa38, casa37, casa36, casa35, casa34, casa33, casa32, casa31, casa30, casa29, casa28, casa27, casa26, casa25, casa24, casa23, casa22, casa21, casa20, casa19, casa18, casa17, casa16, casa15, casa14, casa13, casa12, casa11, casa10, casa9, casa8, casa7, casa6, casa5, casa4, casa3, casa2, casa1, inicio6 };
            Panel[] vest = { vest1, vest2, vest3, vest4, vest5, vest6, vest7, vest8, vest9, vest10, vest11, vest12, vest13, vest14, vest15 };
            Panel[] perg = { casas[1], casas[3], casas[4], casas[7], casas[8], casas[9], casas[13], casas[16], casas[17], casas[18], casas[21], casas[23], casas[24], casas[28], casas[31], casas[32], casas[34], casas[36], casas[38], casas[41], casas[45], casas[49], casas[53], casas[54], casas[55], casas[59], casas[62], casas[63], casas[66], casas[70], casas[73], casas[73] };
            i++;
            Random rnd = new Random();
            dado = rnd.Next(1, 7);
            acionardado.BackgroundImage = System.Drawing.Image.FromFile("dado" + dado + ".png");

            // MOVER PRIMEIRO JOGADOR
            if (i > 20 && rodada == 1)
            {
                timerdado.Enabled = false;
                casadojogador1 += dado;
                rodada++;
                i = 0;
                if (casadojogador1 == 19 || casadojogador1 == 42 || casadojogador1 == 68)
                {
                    casadojogador1 = 0;
                    pictureBox1.Parent = casas[casadojogador1];
                }
                if (casadojogador1 > 75)
                {
                    MessageBox.Show("Você ganhou!!!!");
                }
                else
                {
                    pictureBox1.Parent = casas[casadojogador1];
                }
                for(int x = 0; x < perg.Length; x++)
                {
                    if (casas[casadojogador1] == perg[x])
                    {
                        perguntas frm = new perguntas();
                        frm.ShowDialog();
                    }
                }

                if(casadojogador1 == casadojogador2)
                {
                    pictureBox1.Top = 5;
                }
                else
                {
                    pictureBox1.Top = 0;
                }
            }

            // MOVER SEGUNDO JOGADOR
            if (i > 20 && rodada == 2)
            {
                timerdado.Enabled = false;
                casadojogador2 += dado;
                rodada--;
                i = 0;

                if (casadojogador2 == 19 || casadojogador2 == 42 || casadojogador2 == 68)
                {
                    casadojogador2 = 0;
                    pictureBox1.Parent = casas[casadojogador2];
                    MessageBox.Show("Que azar, volte todas as casas");
                }
                if (casadojogador2 > 75)
                {
                    MessageBox.Show("Você ganhou!!!!");
                }
                else
                {
                    pictureBox2.Parent = casas[casadojogador2];
                }
                for (int x = 0; x < perg.Length; x++)
                {
                    if (casas[casadojogador2] == perg[x])
                    {
                        perguntas frm = new perguntas();
                        frm.ShowDialog();
                    }
                }

                if (casadojogador1 == casadojogador2)
                {
                    pictureBox2.Top = 5;
                }
                else
                {
                    pictureBox2.Top = 0;
                }
            }
        }
    }
}
