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
using System.Net;
using System.Xml.Linq;

namespace Minesweeper
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Program.V_Login.Hide();
            // Program.V_Jogo.Show();



            //Prepara o pedido ao servidor com o URL adequado
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/Autentica");
           
            // Com o acesso usa HTTPS e o servidor usar cerificados autoassinados, temos de configurar o cliente para aceitar sempre o certificado.
             ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            
            // prepara os dados do pedido a partir de uma string só com a estrutura do XML (sem dados)
            XDocument xmlPedido = XDocument.Parse("<credenciais><username></username><password></password></credenciais>");
            //preenche os dados no XML
             xmlPedido.Element("credenciais").Element("username").Value = "xcoelho"; // colocar aqui o username do utilizador
             xmlPedido.Element("credenciais").Element("password").Value = "1234"; // colocar aqui a palavra passe do utilizador
            
            string mensagem = xmlPedido.Root.ToString();
           
            byte[] data = Encoding.Default.GetBytes(mensagem); // note: choose appropriate encoding
            request.Method = "POST";// método usado para enviar o pedido
            request.ContentType = "application/xml"; // tipo de dados que é enviado com o pedido
            request.ContentLength = data.Length; // comprimento dos dados enviado no pedido
          
            Stream newStream = request.GetRequestStream(); // obtem a referência do stream associado ao pedido...
           newStream.Write(data, 0, data.Length);// ... que permite escrever os dados a ser enviados ao servidor
           newStream.Close();
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // faz o envio do pedido
            
            Stream receiveStream = response.GetResponseStream(); // obtem o stream associado à resposta.
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); // Canaliza o stream para um leitor de stream de nível superior com o
                                                                                      //formato de codificação necessário.    
            string resultado = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            // converte para objeto XML para facilitar a extração da informação e ...
             XDocument xmlResposta = XDocument.Parse(resultado);
             // ...interpretar o resultado de acordo com a lógica da aplicação (exemplificativo)
             if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
                 {
              // apresenta mensagem de erro usando o texto (contexto) da resposta
            MessageBox.Show(xmlResposta.Element("resultado").Element("contexto").Value,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
             }
            else
             {
                // assume a autenticação e obtem o ID do resultado...para ser usado noutros pedidos
                MessageBox.Show(xmlResposta.Element("resultado").Element("objeto").Element("id").Value, "Entrou", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
             }


        }
        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;

        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.V_Inscrever.Show();
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.PasswordChar = (char)0;

                textBoxPassword.Text = "Password";

                textBoxPassword.ForeColor = Color.Silver;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {            
                textBoxPassword.PasswordChar = '*';

                textBoxPassword.Text = "";

                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                textBoxUsername.Text = "Username";

                textBoxUsername.ForeColor = Color.Silver;
            }
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "Username")
            {
                textBoxUsername.Text = "";

                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
    }
}
