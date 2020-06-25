using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace perfil
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender,RoutedEventArgs e)
        {
            ImportarPerfil();
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

        private async void ImportarPerfil()
        {
            //Prepara o pedido ao servidor com o URL adequado
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/perfil/" +"bct7"); // ou outro qualquer username

            // Com o acesso usa HTTPS e o servidor usar cerificados autoassinados, tempos de configurar o cliente para aceitar sempre o certificado.
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            request.Method = "GET"; // método usado para enviar o pedido
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // faz o envio do pedido

            Stream receiveStream = response.GetResponseStream(); // obtem o stream associado à resposta.
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); // Canaliza o stream para um leitor de stream de nível superior com o formato de codificação necessário.
            string resultado = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            // converte para objeto XML para facilitar a extração da informação e ...
            XDocument xmlResposta = XDocument.Parse(resultado);
            // ...interpretar o resultado de acordo com a lógica da aplicação (exemplificativo)
            if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
            {
                // apresenta mensagem de erro usando o texto (contexto) da resposta
                //MessageBox.Show(xmlResposta.Element("resultado").Element("contexto").Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "Erro ao tentar importar perfil!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();
            }
            else
            {
                string base64Imagem = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("fotografia").Value;
                string base64 = base64Imagem.Split(',')[1]; // retira a parte da string correspondente aos bytes da imagem..
                byte[] bytes = Convert.FromBase64String(base64); //...converte para array de bytes...

                InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
                await stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);

                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                WriteableBitmap writebleBitmap = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
                await writebleBitmap.SetSourceAsync(stream);
                // When SelectedImage value is changed, it will notify the front end
                pictureBox1.Source = writebleBitmap;

                string nomeabreviado = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("nomeabreviado").Value;
                firstName = nomeabreviado.Split(' ').FirstOrDefault();
                lastName = nomeabreviado.Split(' ').LastOrDefault();

                textBoxFirstName.Text = Convert.ToString(firstName);
                textBoxLastName.Text = Convert.ToString(lastName);
                textBoxEmail.Text = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("email").Value;

                textBoxPais.Text = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("pais").Value;

                textBoxDJogos.Text = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("jogos").Element("ganhos").Value;
                textBoxVJogos.Text = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("jogos").Element("perdidos").Value;
                //textBoxTFacil.Text = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("tempos").Element("facil").Value;
                //textBoxTMedio.Text = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("tempos").Element("medio").Value;
            }
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_2(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
