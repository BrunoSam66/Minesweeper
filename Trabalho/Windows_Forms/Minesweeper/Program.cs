using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static Jogo V_Jogo { get; private set; }
        public static Inscrever V_Inscrever { get; private set; }
        public static Login V_Login { get; private set; }
        public static RedefinirSenha V_RedefinirSenha { get; private set; }
        public static Perfil V_Perfil{ get; private set; }
        public static AlterarDados V_AlterarDados { get; private set; }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            V_Jogo = new Jogo();
            V_Inscrever = new Inscrever();
            V_Login = new Login();
            V_RedefinirSenha = new RedefinirSenha();
            V_Perfil = new Perfil();
            V_AlterarDados = new AlterarDados();

            Application.Run(V_Login);
        }
    }
}
