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
    public partial class AlterarDados : Form
    {
        public AlterarDados()
        {
            InitializeComponent();
        }

        private void buttonAlterarDados_Click(object sender, EventArgs e)
        {
            Program.V_AlterarDados.Hide();
        }
    }
}
