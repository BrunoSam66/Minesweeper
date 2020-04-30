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
        private int quantidade_botoes=81;
        private int botoes_linha;

        private int time = 0;
        private bool isActive = false;

        public Jogo()
        {
            InitializeComponent();
            DesenharPainel();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LayoutPanel(object sender, LayoutEventArgs e)
        {

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

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Jogo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void MedioToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void FacilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void perfilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.V_Perfil.Show();
        }
    }
}