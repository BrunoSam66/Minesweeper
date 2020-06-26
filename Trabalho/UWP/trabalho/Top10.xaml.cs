using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Minesweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Top10 : Page
    { 
        public Top10()
        {
            this.InitializeComponent();
            Servidor_Top10();
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

        private void TextBlock_SelectionChanged_4(object sender, RoutedEventArgs e)
        {

        }

        private void Servidor_Top10()
        {
            //Prepara o pedido ao servidor com o URL adequado
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/top10");

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
               // MessageBox.Show(xmlResposta.Element("resultado").Element("contexto").Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //facil

               
                
                    labelf1.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Element("jogador").Attribute("username").Value;
                    textBoxf1.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Element("jogador").Attribute("tempo").Value;

                    labelf2.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(1).Attribute("username").Value;
                    textBoxf2.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(1).Attribute("tempo").Value;

                    labelf3.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(2).Attribute("username").Value;
                    textBoxf3.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(2).Attribute("tempo").Value;

                    labelf4.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(3).Attribute("username").Value;
                    textBoxf4.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(3).Attribute("tempo").Value;

                    labelf5.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(4).Attribute("username").Value;
                    textBoxf5.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(4).Attribute("tempo").Value;

                    labelf6.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(5).Attribute("username").Value;
                    textBoxf6.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(5).Attribute("tempo").Value;

                    labelf7.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(6).Attribute("username").Value;
                    textBoxf7.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(6).Attribute("tempo").Value;

                    labelf8.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(7).Attribute("username").Value;
                    textBoxf8.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(7).Attribute("tempo").Value;

                    labelf9.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(8).Attribute("username").Value;
                    textBoxf9.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(8).Attribute("tempo").Value;

                    labelf10.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(9).Attribute("username").Value;
                    textBoxf10.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").Elements("jogador").ElementAt(9).Attribute("tempo").Value;

                    //medio 

                    labelm1.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(0).Attribute("username").Value;
                    textBoxm1.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(0).Attribute("tempo").Value;

                    labelm2.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(1).Attribute("username").Value;
                    textBoxm2.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(1).Attribute("tempo").Value;

                    labelm3.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(2).Attribute("username").Value;
                    textBoxm3.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(2).Attribute("tempo").Value;

                    labelm4.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(3).Attribute("username").Value;
                    textBoxm4.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(3).Attribute("tempo").Value;

                    labelm5.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(4).Attribute("username").Value;
                    textBoxm5.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(4).Attribute("tempo").Value;

                    labelm6.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(5).Attribute("username").Value;
                    textBoxm6.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(5).Attribute("tempo").Value;

                    labelm7.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(6).Attribute("username").Value;
                    textBoxm7.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(6).Attribute("tempo").Value;

                    labelm8.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(7).Attribute("username").Value;
                    textBoxm8.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(7).Attribute("tempo").Value;

                    labelm9.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(8).Attribute("username").Value;
                    textBoxm9.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(8).Attribute("tempo").Value;

                    labelm10.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(9).Attribute("username").Value;
                    textBoxm10.Text = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel").ElementsAfterSelf("nivel").Elements("jogador").ElementAt(9).Attribute("tempo").Value;
                
            }
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_5(object sender, RoutedEventArgs e)
        {

        }
    }
}
