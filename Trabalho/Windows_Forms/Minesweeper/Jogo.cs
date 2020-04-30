using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Jogo : Form
    {
        private enum Dificuldade { facil, medio }
        private Dificuldade dificuldade = Dificuldade.facil;

        private static readonly Random rnd = new Random();
        private int[] mines1 = new int[10];
        private int[] mines2 = new int[40];
        private string BotaoClicado;

        private int bombas = 10;
        private int quantidade_botoes;
        private int botoes_linha;

        private int time = 0;
        private bool isActive = false;

        public Jogo()
        {
            InitializeComponent();
        }

        public void ChangeSize(int width, int height)
        {
            this.Size = new Size(width, height);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LayoutPanel(object sender, LayoutEventArgs e)
        {
            if (dificuldade == Dificuldade.facil)
            {
                GerarMinas(mines1);

                DesenharPainel();
            }
            else
            {
                GerarMinas(mines2);

                DesenharPainel();
            }
        }

        private void DesenharPainel()
        {
            int i;

            for (i = 0; i < quantidade_botoes; i++)
            {
                Button button = new Button();
                button.Image = default(Image);
                button.FlatStyle = FlatStyle.Standard;
                button.Size = new Size(26, 26);
                button.Text = " ";
                button.Name = string.Format("Button{0}", i);
                button.Margin = new Padding(1, 1, 1, 1);
                button.Tag = i;
                button.Anchor = AnchorStyles.None;
                button.MouseDown += new MouseEventHandler(button_Click);
                Panel.Controls.Add(button);

                if (dificuldade == Dificuldade.facil && (i + 1) % 9 == 0)
                {
                    Panel.SetFlowBreak(button, true);
                }
                else if (dificuldade == Dificuldade.medio && (i + 1) % 16 == 0)
                {
                    Panel.SetFlowBreak(button, true);
                }
            }
        }

        public bool ExisteBomba(int posicao)
        {
            int i = 0;
            bool result = false;

            if (dificuldade == Dificuldade.facil)
            {
                for (i = 0; i < 10; i++)
                {
                    if (mines1[i] == Convert.ToInt32(posicao))
                    {
                        result = true;
                        break;
                    }
                }
            }
            else
            {
                for (i = 0; i < 40; i++)
                {
                    if (mines2[i] == Convert.ToInt32(posicao))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private void GerarMinas(int[] mines)
        {
            int i;

            int random;

            for (i = 0; i < bombas; i++)
            {
                do
                {
                    random = rnd.Next(0, quantidade_botoes - 1);

                } while (ExisteBomba(random) == true);

                if (dificuldade == Dificuldade.facil)
                {
                    mines1[i] = random;
                }
                else
                {
                    mines2[i] = random;
                }
            }
        }

        private bool TemBomba(string botao)
        {
            int i;
            string mina;
            int resultado = 0;

            if (dificuldade == Dificuldade.facil)
            {
                for (i = 0; i < mines1.Length; i++)
                {
                    mina = "Button" + mines1[i];

                    if (mina == botao)
                    {
                        resultado++;
                    }
                }
            }
            else
            {
                for (i = 0; i < mines2.Length; i++)
                {
                    mina = "Button" + mines2[i];

                    if (mina == botao)
                    {
                        resultado++;
                    }
                }
            }

            if (resultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int NumBotao(string a)
        {
            string b = string.Empty;
            int val = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }

            if (b.Length > 0)
                val = int.Parse(b);

            return val;
        }

        private int BombasVolta(string botao)
        {
            int bombas = 0;
            int num_botao = NumBotao(Convert.ToString(botao));
            string lado_direito = "Button" + (num_botao + 1);
            string lado_esquerdo = "Button" + (num_botao - 1);
            string cima = "Button" + (num_botao - botoes_linha);
            string baixo = "Button" + (num_botao + botoes_linha);
            string diagonal_esquerda_cima = "Button" + (num_botao - botoes_linha - 1);
            string diagonal_esquerda_baixo = "Button" + (num_botao + botoes_linha - 1);
            string diagonal_direita_cima = "Button" + (num_botao - botoes_linha + 1);
            string diagonal_direita_baixo = "Button" + (num_botao + botoes_linha + 1);

            if ((num_botao - (botoes_linha - 1)) % botoes_linha != 0)
            {
                if (TemBomba(lado_direito) == true)
                {
                    bombas++;
                }
            }

            if (num_botao % botoes_linha != 0 && num_botao != 0)
            {
                if (TemBomba(lado_esquerdo) == true)
                {
                    bombas++;
                }
            }


            if (num_botao >= botoes_linha)
            {
                if (TemBomba(cima) == true)
                {
                    bombas++;
                }

            }

            if (num_botao <= (quantidade_botoes - botoes_linha))
            {
                if (TemBomba(baixo) == true)
                {
                    bombas++;
                }
            }

            if ((num_botao - (botoes_linha - 1)) % botoes_linha != 0 && num_botao <= (quantidade_botoes - botoes_linha))
            {
                if (TemBomba(diagonal_direita_baixo) == true)
                {
                    bombas++;
                }
            }

            if ((num_botao - (botoes_linha - 1)) % botoes_linha != 0 && num_botao >= 9)
            {
                if (TemBomba(diagonal_direita_cima) == true)
                {
                    bombas++;
                }
            }

            if (num_botao % botoes_linha != 0 && num_botao >= botoes_linha && num_botao != 0)
            {
                if (TemBomba(diagonal_esquerda_cima) == true)
                {
                    bombas++;
                }
            }

            if (num_botao % botoes_linha != 0 && num_botao <= (quantidade_botoes - botoes_linha) && num_botao != 0)
            {
                if (TemBomba(diagonal_esquerda_baixo) == true)
                {
                    bombas++;
                }
            }

            return bombas;
        }

        private void button_Click(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            isActive = true;

            if (e.Button == MouseButtons.Left)
            {
                BotaoClicado = button.Name;

                if (TemBomba(BotaoClicado) == true)
                {
                    button.Image = Image.FromFile("bomba.jpg");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);

                    ResetTime();
                    isActive = false;

                    MessageBox.Show("   Game Over!", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (BombasVolta(BotaoClicado) == 1)
                {
                    button.Image = Image.FromFile("1.png");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }
                else if (BombasVolta(BotaoClicado) == 2)
                {
                    button.Image = Image.FromFile("2.png");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }
                else if (BombasVolta(BotaoClicado) == 3)
                {
                    button.Image = Image.FromFile("3.png");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }
                else if (BombasVolta(BotaoClicado) == 4)
                {
                    button.Image = Image.FromFile("4.png");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }
                else if (BombasVolta(BotaoClicado) == 5)
                {
                    button.Image = Image.FromFile("5.png");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }
                else if (BombasVolta(BotaoClicado) == 6)
                {
                    button.Image = Image.FromFile("6.png");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }
                else if (BombasVolta(BotaoClicado) == 7)
                {
                    button.Image = Image.FromFile("7.png");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }
                else if (BombasVolta(BotaoClicado) == 8)
                {
                    button.Image = Image.FromFile("8.png");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }
                else
                {
                    button.Image = Image.FromFile("0.png");
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }

                MostrarEspaços(null);
            }
            else if (e.Button == MouseButtons.Right && button.Image == default(Image))
            {
                BotaoClicado = button.Name;

                button.Image = Image.FromFile("bandeira.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Jogo_Load(object sender, EventArgs e)
        {
            if (dificuldade == Dificuldade.facil)
            {
                bombas = 10;
                botoes_linha = 9;
                quantidade_botoes = 81;
            }
            else
            {
                bombas = 40;
                botoes_linha = 16;
                quantidade_botoes = 256;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            isActive = false;
            ResetTime();

            GerarMinas(mines1);

            foreach (Button button in Panel.Controls)
            {
                for (i = 0; i < quantidade_botoes; i++)
                {
                    button.Image = default(Image);
                    button.ForeColor = default(Color);
                    button.UseVisualStyleBackColor = true;
                    button.FlatStyle = FlatStyle.Standard;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Size = new Size(26, 26);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActive == true)
            {
                time++;
            }

            if (time != 0)
            {
                textBoxTime.Text = Convert.ToString(+time);
            }
            else
            {
                textBoxTime.Text = null;
            }
        }

        private void ResetTime()
        {
            time = 0;
        }

        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void MedioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isActive = false;
            ResetTime();

            dificuldade = Dificuldade.medio;
            Jogo_Load(null, null);

            ChangeSize(502, 570);
            Panel.Size = new Size(450, 450);

            menuStrip1.Size = new Size(502, 24);

            Panel.Controls.Clear();
        }

        private void FacilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isActive = false;
            ResetTime();

            dificuldade = Dificuldade.facil;
            Jogo_Load(null, null);

            ChangeSize(310, 370);
            Panel.Size = new Size(270, 253);

            menuStrip1.Size = new Size(310, 24);

            Panel.Controls.Clear();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetTime();
            Program.V_Perfil.Show();
        }

        private void MostrarEspaços(object sender)
        {
            int i = 0;
            int j = 0;
            int num_botao = NumBotao(Convert.ToString(BotaoClicado));
            var botao = "Button" + num_botao;
            var button = Convert.ToString(botao).ToCharArray();
            int x = x_botao(botao);
            int y = y_botao(botao);

            if (TemBomba(botao) == false)
            {
                for (j = y; j <= 0; j--)
                {
                    for (i = x; i <= 0; i--)
                    {
                        num_botao = NumBotao(Convert.ToString(BotaoClicado));
                        num_botao = num_botao - i - 9 * j;
                        botao = "Button" + num_botao;

                        if (x != i)
                        {
                            if (TemBomba(botao) == false && BombasVolta(botao) == 0)
                            {
                                show(null, botao);
                            }
                            else if (TemBomba(botao) != false || BombasVolta(botao) != 0)
                            {
                                show(null, botao);
                                break;
                            }
                        }
                    }

                    for (i = x; i >= 9; i++)
                    {
                        num_botao = NumBotao(Convert.ToString(BotaoClicado));
                        num_botao = num_botao + i;
                        botao = "Button" + num_botao;

                        if (x != i)
                        {
                            if (TemBomba(botao) == false && BombasVolta(botao) == 0)
                            {
                                show(null, botao);
                            }
                            else if (TemBomba(botao) != false || BombasVolta(botao) != 0)
                            {
                                show(null, botao);
                                break;
                            }
                        }
                    }
                }

                for (j = y; j >= 9; j++)
                {
                    for (i = x; i <= 0; i--)
                    {
                        num_botao = NumBotao(Convert.ToString(BotaoClicado));
                        num_botao = num_botao - i + 9 * j;
                        botao = "Button" + num_botao;

                        if (x != i)
                        {
                            if (TemBomba(botao) == false && BombasVolta(botao) == 0)
                            {
                                show(null, botao);
                            }
                            else if (TemBomba(botao) != false || BombasVolta(botao) != 0)
                            {
                                show(null, botao);
                                break;
                            }
                        }
                    }

                    for (i = x; i >= 9; i++)
                    {
                        num_botao = NumBotao(Convert.ToString(BotaoClicado));
                        num_botao = num_botao + i;
                        botao = "Button" + num_botao;

                        if (x != i)
                        {
                            if (TemBomba(botao) == false)
                            {
                                show(null, botao);
                            }
                            else if (TemBomba(botao) != false)
                            {
                                show(null, botao);
                                break;
                            }
                        }
                    }
                }
            }

        }

        private int x_botao(string botao)
        {
            int x = 0;

            int num_botao =NumBotao(Convert.ToString(botao));

            if(num_botao >= 0 && num_botao <= 8)
            {
                x = 0;
            }
            else if (num_botao >= 9 && num_botao <= 17)
            {
                x = 1;
            }
            else if (num_botao >= 18 && num_botao <= 26)
            {
                x = 2;
            }
            else if (num_botao >= 27 && num_botao <= 35)
            {
                x = 3;
            }
            else if (num_botao >= 36 && num_botao <= 44)
            {
                x = 4;
            }
            else if (num_botao >= 45 && num_botao <= 53)
            {
                x = 5;
            }
            else if (num_botao >= 54 && num_botao <= 62)
            {
                x = 6;
            }
            else if (num_botao >= 63 && num_botao <= 71)
            {
                x = 7;
            }
            else if (num_botao >= 72 && num_botao <= 80)
            {
                x = 8;
            }

            return x;
        }

        private int y_botao(string botao)
        {
            int y = 0;

            int num_botao = NumBotao(Convert.ToString(botao));

            if (num_botao == 0 || num_botao % 9 == 0)
            {
                y = 0;
            }
            else if (num_botao == 1 || (num_botao - 1) % 9 == 0)
            {
                y = 1;
            }
            else if (num_botao == 2 || (num_botao - 2) % 9 == 0)
            {
                y = 2;
            }
            else if (num_botao == 3 || (num_botao - 3) % 9 == 0)
            {
                y = 3;
            }
            else if (num_botao == 4 || (num_botao - 4) % 9 == 0)
            {
                y = 4;
            }
            else if (num_botao == 5 || (num_botao - 5) % 9 == 0)
            {
                y = 5;
            }
            else if (num_botao == 6 || (num_botao - 6) % 9 == 0)
            {
                y = 6;
            }
            else if (num_botao == 7 || (num_botao - 7) % 9 == 0)
            {
                y = 7;
            }
            else if (num_botao == 8 || (num_botao - 8) % 9 == 0)
            {
                y = 8;
            }

            return y;
        }

        private void show(object sender,string botao)
        {
            Button button = sender as Button;


            if (TemBomba(botao) == true)
            {
                button.Image = Image.FromFile("bomba.jpg");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);

                ResetTime();
                isActive = false;

                MessageBox.Show("   Game Over!", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (BombasVolta(botao) == 1)
            {
                button.Image = Image.FromFile("1.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
            else if (BombasVolta(botao) == 2)
            {
                button.Image = Image.FromFile("2.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
            else if (BombasVolta(botao) == 3)
            {
                button.Image = Image.FromFile("3.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
            else if (BombasVolta(botao) == 4)
            {
                button.Image = Image.FromFile("4.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
            else if (BombasVolta(botao) == 5)
            {
                button.Image = Image.FromFile("5.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
            else if (BombasVolta(botao) == 6)
            {
                button.Image = Image.FromFile("6.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
            else if (BombasVolta(botao) == 7)
            {
                button.Image = Image.FromFile("7.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
            else if (BombasVolta(botao) == 8)
            {
                button.Image = Image.FromFile("8.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
            else
            {
                button.Image = Image.FromFile("0.png");
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Size = new Size(26, 26);
            }
          
        }
    }
}