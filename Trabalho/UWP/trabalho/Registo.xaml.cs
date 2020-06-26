using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.Linq;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace increver
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            paises();
        }

        private string firstName { get; set; }
        private string lastName { get; set; }
        public string userName { get; set; }
        private string password { get; set; }
        private string email { get; set; }
        private string pais { get; set; }
        private string fotografia { get; set; }

        private string registo;
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

        public string UserName
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


        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_2(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;

        }

        public void paises()
        {
            int i;
            string pais;

            StreamReader file1 = new StreamReader("paises.txt");

            for (i = 0; i < 196; i++)
            {
                pais = file1.ReadLine();
                comboBoxPais.Items.Add(Convert.ToString(pais));
            }
        }

        public bool contemNumeros(string text)
        {
            if (text.Where(c => char.IsNumber(c)).Count() > 0)
                return true;
            else
                return false;
        }

        public bool contemLetras(string text)
        {
            if (text.Where(c => char.IsLetter(c)).Count() > 0)
                return true;
            else
                return false;
        }

        int wordCount(string str)
        {
            string texto = str.Trim();

            // Remove as quebras de linhas substituindo-as por
            // espaços
            texto = texto.Replace("\n", " ");

            // remove os espaços em excesso
            texto = texto.Trim();

            // Obtém um array de palavras
            string[] palavras = texto.Split(' ');

            // Obtém a quantidade de palavras
            int words = palavras.Length;

            return words;
        }

        private bool VerificaEmail(string text)
        {
            if (text.Contains('@'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Existe_username(string username)
        {
            //Prepara o pedido ao servidor com o URL adequado
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/Autentica");

            // Com o acesso usa HTTPS e o servidor usar cerificados autoassinados, temos de configurar o cliente para aceitar sempre o certificado.
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            // prepara os dados do pedido a partir de uma string só com a estrutura do XML (sem dados)
            XDocument xmlPedido = XDocument.Parse("<credenciais><username></username><password></password></credenciais>");
            //preenche os dados no XML
            xmlPedido.Element("credenciais").Element("username").Value = textBoxUsername.Text; // colocar aqui o username do utilizador
            xmlPedido.Element("credenciais").Element("password").Value = textBoxPassword.Text; // colocar aqui a palavra passe do utilizador

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
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void FotoBase64(Image ImageControl) 
        {
            /*byte[] imageArray;

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    imageArray = memoryStream.ToArray();
                }
            }

            string base64Text = Convert.ToBase64String(imageArray);
            string fileEXT = file.Path.ToString();
            fotografia = base64Text;*/

            var bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(ImageControl);

            var image = (await bitmap.GetPixelsAsync()).ToArray();
            var width = (uint)bitmap.PixelWidth;
            var height = (uint)bitmap.PixelHeight;

            double dpiX = 96;
            double dpiY = 96;

            var encoded = new InMemoryRandomAccessStream();
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, encoded);

            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, width, height, dpiX, dpiY, image);
            await encoder.FlushAsync();
            encoded.Seek(0);

            var bytes = new byte[encoded.Size];
            await encoded.AsStream().ReadAsync(bytes, 0, bytes.Length);

            fotografia = Convert.ToBase64String(bytes);
        }

        private async void Registo(object sender, RoutedEventArgs e)
        {
            //CAMPOS NÂO NULOS
            if (string.IsNullOrEmpty(Convert.ToString(textBoxFirstName.Text)) == true && string.IsNullOrEmpty(Convert.ToString(textBoxLastName.Text)) == true)
            {
                //MessageBox.Show("Deixou campos em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "Deixou campos em branco!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }
            else if (string.IsNullOrEmpty(Convert.ToString(textBoxPassword.Text)) == true && string.IsNullOrEmpty(Convert.ToString(textBoxUsername.Text)) == true)
            {
                //MessageBox.Show("Deixou campos em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "Deixou campos em branco!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }
            else if (string.IsNullOrEmpty(Convert.ToString(textBoxEmail.Text)) == true)
            {
                //MessageBox.Show("Deixou campos em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "Deixou campos em branco!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }
            else if (wordCount(Convert.ToString(textBoxFirstName.Text)) != 1 || wordCount(Convert.ToString(textBoxLastName.Text)) != 1 || wordCount(Convert.ToString(textBoxUsername.Text)) != 1)
            {
                //MessageBox.Show("Deve inserir apenas uma palavra nos 3 primeiros campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "Deve inserir apenas uma palavra nos 3 primeiros campos!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }
            else if (contemNumeros(textBoxFirstName.Text) == true || contemNumeros(textBoxLastName.Text) == true)    //PRIMEIRO E ULTIMO NOME
            {
                //MessageBox.Show("O seu nome não pode conter numeros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "O seu nome não pode conter numeros!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }     //USERNAME
            else if (contemLetras(textBoxUsername.Text) == false)
            {
                //MessageBox.Show("O seu username deve conter letras!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "O seu username deve conter letras!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();


                registo = "erro";
            }//PASSWORD
            else if (contemLetras(textBoxPassword.Text) == false || contemNumeros(textBoxPassword.Text) == false)
            {
                //MessageBox.Show("A password deve conter letras e numeros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "A password deve conter letras e numeros!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }
            else if (wordCount(Convert.ToString(textBoxPassword.Text)) != 1)
            {
                //MessageBox.Show("Não deve inserir espaços na password!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "Não deve inserir espaços na password!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }
            else if (wordCount(Convert.ToString(textBoxEmail.Text)) != 1)
            {
                //MessageBox.Show("O email não deve ter espaços!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "O email não deve ter espaços!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }
            else if (VerificaEmail(Convert.ToString(textBoxEmail.Text)) == false)
            {
                //MessageBox.Show("O email não está no formato correto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "O email não está no formato correto!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }
            else if (comboBoxPais.SelectedIndex == -1)
            {
                //MessageBox.Show("Deve selecionar o seu país!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "Deve selecionar o seu país!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();

                registo = "erro";
            }
            else
            {
                firstName = Convert.ToString(textBoxFirstName.Text);
                lastName = Convert.ToString(textBoxLastName.Text);
                userName = Convert.ToString(textBoxUsername.Text);
                password = Convert.ToString(textBoxPassword.Text);
                email = Convert.ToString(textBoxEmail.Text);
                pais = Convert.ToString(comboBoxPais.Text);
                FotoBase64(pictureBox1);
                registo = "ok";
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Registo(null, null);

            if (registo == "ok")
            {
                //Prepara o pedido ao servidor com o URL adequado
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/registo");

                // Com o acesso usa HTTPS e o servidor usar cerificados autoassinados, temos de configurar o cliente para aceitar sempre o certificado.
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

                // prepara os dados do pedido a partir de uma string só com a estrutura do XML (sem dados)
                XDocument xmlPedido = XDocument.Parse("<registo><nomeabreviado></nomeabreviado><username></username><password></password><email></email><fotografia></fotografia><pais></pais></registo>");

                //preenche os dados no XML
                xmlPedido.Element("registo").Element("nomeabreviado").Value = Convert.ToString(firstName + " " + lastName);
                xmlPedido.Element("registo").Element("username").Value = userName;
                xmlPedido.Element("registo").Element("password").Value = password;
                xmlPedido.Element("registo").Element("email").Value = email;
                xmlPedido.Element("registo").Element("fotografia").Value = "data:image/png;base64," + fotografia;
                xmlPedido.Element("registo").Element("pais").Value = pais;

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
                    //MessageBox.Show(xmlResposta.Element("resultado").Element("contexto").Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Erro",
                        Content = "O seu username deve conter letras!",
                        PrimaryButtonText = "OK"

                    };
                    await dialog.ShowAsync();

                }
                else
                {
                    //MessageBox.Show("Registo concluído com sucesso!", "Registo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Erro",
                        Content = "O seu username deve conter letras!",
                        PrimaryButtonText = "OK"

                    };
                    await dialog.ShowAsync();

                    Frame view = new Frame();
                    this.Frame.Navigate(typeof(login.MainPage));
                }
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var image = new BitmapImage();
                image.SetSource(stream);
                pictureBox1.Source = image;
                pictureBox1.Stretch = Stretch.Fill;
            }
            else
            {
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erro",
                    Content = "Erro ao inserir a fotografia!",
                    PrimaryButtonText = "OK"

                };
            }


        }
    }
}
