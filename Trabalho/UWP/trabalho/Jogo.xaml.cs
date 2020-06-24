using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace jogo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            if (dificuldade == Dificuldade.facil)
            {
                GerarMinas(mines1);

            }
            /*else
            {
                GerarMinas(mines2);
            }*/
        }

        private enum Dificuldade { facil, medio }
        private Dificuldade dificuldade = Dificuldade.facil;

        private static readonly Random rnd = new Random();
        private int[] mines1 = new int[10];
        private int[] mines2 = new int[40];
        private string BotaoClicado;

        private int bombas = 10;
        private int quantidade_botoes;
        private int botoes_linha;

        string botao;

        private int time = 0;
        private bool isActive = false;
        private object rootPage;
        private object NotifyType;

        public object ImageLayout { get; private set; }

        //função para redimensionar o forms falta


        private void LayoutPanel(object sender, RoutedEvent e)
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
                Button button = new Button(); //é preciso alterar o estilo 
                button.Background = (SolidColorBrush)Resources["bluecolor"];
                button.Content = " ";
                button.Height = 26;
                button.Width = 26;
                button.Tag = i;    
                button.Name = string.Format("Button{0}", i);
               // button.Click += bunton_click; fazer o evento do click
               
              

                if (dificuldade == Dificuldade.facil && (i + 1) % 9 == 0)
                {
                   // Panel.SetFlowBreak(button, true);
                }
                else if (dificuldade == Dificuldade.medio && (i + 1) % 16 == 0)
                {
                 //  Panel.SetFlowBreak(button, true);
                }

            }

        }

        private void Right_Click(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*ContentDialog dialog = new ContentDialog()
            {
                Title = "Game Over!!!",
                Content = "Try again!!!",
                PrimaryButtonText = "OK"

            };
            await dialog.ShowAsync();*/

            Button button = (Button)sender;
            botao = button.Name;
            BotaoClicado = button.Name;

            isActive = true;

            if (TemBomba(BotaoClicado) == true)
            {
                //Abrir a bomba no button
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;

                ResetTime();
                isActive = false;

                /*ContentDialog dialog = new ContentDialog()
                {
                    Title = "Game Over!!!",
                    Content = "Try again!!!",
                    PrimaryButtonText = "OK"

                };
                await dialog.ShowAsync();*/

                /*if (dificuldade == Dificuldade.facil)
                {
                    FacilToolStripMenuItem_Click(null, null);
                }
                else
                {
                    MedioToolStripMenuItem1_Click(null, null);
                }*/
            }
            else if (BombasVolta(BotaoClicado) == 1)
            {
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;


            }
            else if (BombasVolta(BotaoClicado) == 2)
            {
                //img2
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;

            }
            else if (BombasVolta(BotaoClicado) == 3)
            {
                /// im3
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;

            }
            else if (BombasVolta(BotaoClicado) == 4)
            {
                //   im4 
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;

            }
            else if (BombasVolta(BotaoClicado) == 5)
            {
                //Abrir imagem 5
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;

            }
            else if (BombasVolta(BotaoClicado) == 6)
            {
                //Abrir imagem 6.png no button
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;

            }
            else if (BombasVolta(BotaoClicado) == 7)
            {
                //AAbrir imagem 7.png no button
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;


            }
            else if (BombasVolta(BotaoClicado) == 8)
            {
                //Abrir imagem 8.png no button
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;

            }
            else
            {
                //abrir imagem 0.png no button
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/smile.png")), Stretch = Stretch.None };

                button.IsEnabled = false;

                /*
                //MostrarTudo(BotaoClicado);
                MostrarEspacos(BotaoClicado);
                MostrarEspacos_y(BotaoClicado);
                MostrarEspacos_diagonal(BotaoClicado);*/
            }
        }

        private void GerarMinas(int[] mines1)
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

        private bool ExisteBomba(int posicao)
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
/* 
            foreach (Button button in Panel)
            {
                for (i = 0; i < quantidade_botoes; i++)
                {
                   button.Image = default(Image);
                    button.ForeColor = default(Color);
                    button.UseVisualStyleBackColor = true;
                    button.FlatStyle = FlatStyle.Standard;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Height = 26;
                    button.Width = 26;
                }
            }*/
        }

        private void ResetTime()
        {
            time = 0;
        }

        private void MedioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isActive = false;
            ResetTime();

            dificuldade = Dificuldade.medio;
            Jogo_Load(null, null);

           /* ChangeSize(502, 570);
            Panel.Size = new Size(450, 450);

            menuStrip1.Size = new Size(502, 24);

            Panel.Controls.Clear();*/
        }

        private void FacilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isActive = false;
            ResetTime();

            dificuldade = Dificuldade.facil;
            Jogo_Load(null, null);

            /*ChangeSize(310, 370);
            Panel.Size = new Size(270, 253);

            menuStrip1.Size = new Size(310, 24);

            Panel.Controls.Clear();*/
        }

        private void MostrarEspacos(string botaoC)
        {
            int i = 0;
            int j;
            int g;
            int num_botao = NumBotao(Convert.ToString(botaoC));
            string button;
            var botao = "Button" + num_botao;
            int x = x_botao(botao);
            int y = y_botao(botao);

            for (j = y; j >= 0; j--)
            {
                botao = "Button" + (num_botao - 9 * (y - j));
                if (TemBomba(botao) == false && BombasVolta(botao) == 0)
                {
                    for (i = x; i >= 0; i--)
                    {
                        button = "Button" + (i + (9 * j));
                        if (TemBomba(button) == false && BombasVolta(button) == 0)
                        {
                            show(button);
                        }
                        else
                        {
                            if (TemBomba(button) == false)
                            {
                                show(button);
                            }
                            break;
                        }
                    }

                    for (i = x; i <= 8; i++)
                    {
                        button = "Button" + (i + (9 * j));
                        if (TemBomba(button) == false && BombasVolta(button) == 0)
                        {
                            show(button);
                        }
                        else
                        {
                            if (TemBomba(button) == false)
                            {
                                show(button);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            for (g = y; g <= 8; g++)
            {
                botao = "Button" + (num_botao + 9 * (g - y));
                if (TemBomba(botao) == false && BombasVolta(botao) == 0)
                {
                    for (i = x; i >= 0; i--)
                    {
                        button = "Button" + (i + (9 * g));
                        if (TemBomba(button) == false && BombasVolta(button) == 0)
                        {
                            show(button);
                        }
                        else
                        {
                            if (TemBomba(button) == false)
                            {
                                show(button);
                            }
                            break;
                        }
                    }

                    for (i = x; i <= 8; i++)
                    {
                        button = "Button" + (i + (9 * g));
                        if (TemBomba(button) == false && BombasVolta(button) == 0)
                        {
                            show(button);
                        }
                        else
                        {
                            if (TemBomba(button) == false)
                            {
                                show(button);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

        }
        private void MostrarEspacos_y(string botaoC)
        {
            int i = 0;
            int j;
            int g;
            int num_botao = NumBotao(Convert.ToString(botaoC));
            string button;
            var botao = "Button" + num_botao;
            int x = x_botao(botao);
            int y = y_botao(botao);


            for (j = x; j >= 0; j--)
            {
                botao = "Button" + (num_botao - (x - j));
                if (TemBomba(botao) == false && BombasVolta(botao) == 0)
                {
                    for (i = y; i >= 0; i--)
                    {
                        button = "Button" + (j + (9 * i));
                        if (TemBomba(button) == false && BombasVolta(button) == 0)
                        {
                            show(button);
                        }
                        else
                        {
                            if (TemBomba(button) == false)
                            {
                                show(button);
                            }
                            break;
                        }
                    }

                    for (i = y; i <= 8; i++)
                    {
                        button = "Button" + (j + (9 * i));
                        if (TemBomba(button) == false && BombasVolta(button) == 0)
                        {
                            show(button);
                        }
                        else
                        {
                            if (TemBomba(button) == false)
                            {
                                show(button);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            for (g = x; g <= 8; g++)
            {
                botao = "Button" + (num_botao + (g - x));
                if (TemBomba(botao) == false && BombasVolta(botao) == 0)
                {
                    for (i = y; i >= 0; i--)
                    {
                        button = "Button" + (g + (9 * i));
                        if (TemBomba(button) == false && BombasVolta(button) == 0)
                        {
                            show(button);
                        }
                        else
                        {
                            if (TemBomba(button) == false)
                            {
                                show(button);
                            }
                            break;
                        }
                    }

                    for (i = y; i <= 8; i++)
                    {
                        button = "Button" + (g + (9 * i));
                        if (TemBomba(button) == false && BombasVolta(button) == 0)
                        {
                            show(button);
                        }
                        else
                        {
                            if (TemBomba(button) == false)
                            {
                                show(button);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void MostrarEspacos_diagonal(string botaoC)
        {
            int i = 0;
            int j;
            int num_botao = NumBotao(Convert.ToString(botaoC));
            string button;
            var botao = "Button" + num_botao;
            int x = x_botao(botao);
            int y = y_botao(botao);

            for (i = x - 1; i >= 0; i--) //diagonal cima-esquerda
            {
                j = y - 1;

                button = "Button" + ((j * 9) + i);
                if (TemBomba(button) == false && BombasVolta(button) == 0)
                {
                    show(button);
                }
                else
                {
                    if (TemBomba(button) == false)
                    {
                        show(button);
                    }
                    break;
                }

                j--;
            }

            for (i = x + 1; i <= 8; i++) //diagonal cima-direta
            {
                j = y - 1;

                button = "Button" + ((j * 9) + i);
                if (TemBomba(button) == false && BombasVolta(button) == 0)
                {
                    show(button);
                }
                else
                {
                    if (TemBomba(button) == false)
                    {
                        show(button);
                    }
                    break;
                }

                j--;
            }

            for (i = x - 1; i >= 0; i--) //diagonal baixo-esquerda
            {
                j = y + 1;

                button = "Button" + ((j * 9) + i);
                if (TemBomba(button) == false && BombasVolta(button) == 0)
                {
                    show(button);
                }
                else
                {
                    if (TemBomba(button) == false)
                    {
                        show(button);
                    }
                    break;
                }

                j++;
            }

            for (i = x + 1; i >= 8; i++) //diagonal baixo-direita
            {
                j = y + 1;

                button = "Button" + ((j * 9) + i);
                if (TemBomba(button) == false && BombasVolta(button) == 0)
                {
                    show(button);
                }
                else
                {
                    if (TemBomba(button) == false)
                    {
                        show(button);
                    }
                    break;
                }

                j++;

            }
        }

        private void MostrarTudo(string botaoC)
        {
            int i = 0;
            int j;
            int num_botao = NumBotao(Convert.ToString(botaoC));
            string button;
            var botao = "Button" + num_botao;
            int x = x_botao(botao);
            int y = y_botao(botao);

            for (j = y; j >= 0; j--)
            {
                for (i = x; i >= 0; i--)
                {
                    button = "Button" + (i + (9 * j));

                    if (TemBomba(button) == false && BombasVolta(button) == 0)
                    {
                        MostrarEspacos(button);
                        MostrarEspacos_y(button);
                        MostrarEspacos_diagonal(button);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (j = y; j >= 0; j--)
            {
                for (i = x; i >= 0; i--)
                {
                    button = "Button" + (i + (9 * j));

                    if (TemBomba(button) == false && BombasVolta(button) == 0)
                    {
                        MostrarEspacos(button);
                        MostrarEspacos_y(button);
                        MostrarEspacos_diagonal(button);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (j = y; j >= 0; j--)
            {
                for (i = x; i >= 0; i--)
                {
                    button = "Button" + (i + (9 * j));

                    if (TemBomba(button) == false && BombasVolta(button) == 0)
                    {
                        MostrarEspacos(button);
                        MostrarEspacos_y(button);
                        MostrarEspacos_diagonal(button);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (j = y; j >= 0; j--)
            {
                for (i = x; i >= 0; i--)
                {
                    button = "Button" + (i + (9 * j));

                    if (TemBomba(button) == false && BombasVolta(button) == 0)
                    {
                        MostrarEspacos(button);
                        MostrarEspacos_y(button);
                        MostrarEspacos_diagonal(button);
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }
        private int y_botao(string botao)
        {
            int y = 0;

            int num_botao = NumBotao(Convert.ToString(botao));

            if (num_botao >= 0 && num_botao <= 8)
            {
                y = 0;
            }
            else if (num_botao >= 9 && num_botao <= 17)
            {
                y = 1;
            }
            else if (num_botao >= 18 && num_botao <= 26)
            {
                y = 2;
            }
            else if (num_botao >= 27 && num_botao <= 35)
            {
                y = 3;
            }
            else if (num_botao >= 36 && num_botao <= 44)
            {
                y = 4;
            }
            else if (num_botao >= 45 && num_botao <= 53)
            {
                y = 5;
            }
            else if (num_botao >= 54 && num_botao <= 62)
            {
                y = 6;
            }
            else if (num_botao >= 63 && num_botao <= 71)
            {
                y = 7;
            }
            else if (num_botao >= 72 && num_botao <= 80)
            {
                y = 8;
            }

            return y;
        }

        private int x_botao(string botao)
        {
            int x = 0;

            int num_botao = NumBotao(Convert.ToString(botao));

            if (num_botao == 0 || num_botao % 9 == 0)
            {
                x = 0;
            }
            else if (num_botao == 1 || (num_botao - 1) % 9 == 0)
            {
                x = 1;
            }
            else if (num_botao == 2 || (num_botao - 2) % 9 == 0)
            {
                x = 2;
            }
            else if (num_botao == 3 || (num_botao - 3) % 9 == 0)
            {
                x = 3;
            }
            else if (num_botao == 4 || (num_botao - 4) % 9 == 0)
            {
                x = 4;
            }
            else if (num_botao == 5 || (num_botao - 5) % 9 == 0)
            {
                x = 5;
            }
            else if (num_botao == 6 || (num_botao - 6) % 9 == 0)
            {
                x = 6;
            }
            else if (num_botao == 7 || (num_botao - 7) % 9 == 0)
            {
                x = 7;
            }
            else if (num_botao == 8 || (num_botao - 8) % 9 == 0)
            {
                x = 8;
            }

            return x;
        }

        private void show(string button)
        {
            throw new NotImplementedException();
        }

        //---------------------------------------------------------------------------------------
        private void ButtonJogo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Perfil_Click(object sender, RoutedEventArgs e)
        {
            Frame view = new Frame();
            this.Frame.Navigate(typeof(perfil.MainPage));
        }

    }
}
