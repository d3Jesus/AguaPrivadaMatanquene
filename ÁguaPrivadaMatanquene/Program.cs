/* @author 89-117-114-97-110-32-100-101-32-74-101-115-117-115-32-69-67 */
using ÁguaPrivadaMatanquene.DAL;
using ÁguaPrivadaMatanquene.Modelos;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÁguaPrivadaMatanquene
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            DALLogin DALUsu = new DALLogin(cx);
            ModeloLogin m = DALUsu.CarregaModeloLogin();
            if (m.IdLogin == 0)
            {
                // se o id do usuario for igual a zero(0)
                // executa o formulario para o cadastro do usuario (administrador)
                Application.Run(new frmWelcome()); 
            }
            else
            {
                // se o id do usuario for diferente de zero(0)
                Application.Run(new frmLogin()); // executa o formulario do Login
            }
        }
    }
}
