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
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
        }

        private string firstName { get; set; }
        private string lastName { get; set; }
        private string userName { get; set; }
        private string password { get; set; }
        private string email { get; set; }
        private string pais { get; set; }
        private string fotografia { get; set; }
        private string bestTime { get; set; }
        private string worstTime { get; set; }

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

        private string Fotografia
        {
            get => fotografia;
            set => fotografia = value;
        }

        private string BestTime
        {
            get => bestTime;
            set => bestTime = value;
        }

        private string WorstTime
        {
            get => worstTime;
            set => worstTime = value;
        }

        private void ImportarPerfil()
        {

            //Program.V_Login.Hide();

            //Prepara o pedido ao servidor com o URL adequado
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://prateleira.utad.priv:1234/LPDSW/2019-2020/perfil/");

            // Com o acesso usa HTTPS e o servidor usar cerificados autoassinados, temos de configurar o cliente para aceitar sempre o certificado.
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            // prepara os dados do pedido a partir de uma string só com a estrutura do XML (sem dados)
            XDocument xmlPedido = XDocument.Parse("<resultado><status></status><contexto></contexto><objeto><perfil><nomeabreviado></nomeabreviado><email></email><fotografia></fotografia><pais></pais><jogos><ganhos></ganhos><perdidos></perdidos></jogos><tempos><facil></facil><medio></medio></tempos></perfil></objeto></resultado>");
            //preenche os dados no XML

            xmlPedido.Element("resultado").Element("objeto").Element("perfil").Element("email").Value = email; 
            xmlPedido.Element("resultado").Element("objeto").Element("perfil").Element("fotografia").Value = fotografia; 
            xmlPedido.Element("resultado").Element("objeto").Element("perfil").Element("pais").Value = pais;


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
                MessageBox.Show(xmlResposta.Element("resultado").Element("contexto").Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // assume a autenticação e obtem o ID do resultado...para ser usado noutros pedidos
                MessageBox.Show(xmlResposta.Element("resultado").Element("objeto").Element("ID").Value, "Entrou", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Program.V_Jogo.Show();
            }
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
