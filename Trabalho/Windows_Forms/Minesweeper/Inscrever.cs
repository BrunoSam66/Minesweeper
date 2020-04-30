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

namespace Minesweeper
{
    public partial class Inscrever : Form
    {       

        public Inscrever()
        {
            InitializeComponent();
        }

        private string firstName { get; set; }
        private string lastName { get; set; }
        private string userName { get; set; }
        private string password { get; set; }
        private string email { get; set; }
        private string pais { get; set; }

        private string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        private string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        private string UserName
        {
            get => userName;
            set => userName = value;
        }

        private string Password
        {
            get => password;
            set => password = value;
        }

        private string Email
        {
            get => email;
            set => email = value;
        }

        private string Pais
        {
            get => pais;
            set => pais = value;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.V_Inscrever.Hide();
        }

        private void Inscrever_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                
        }

        private void comboBoxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
