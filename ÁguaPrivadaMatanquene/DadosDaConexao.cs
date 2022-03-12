/* @author 89-117-114-97-110-32-100-101-32-74-101-115-117-115-32-69-67 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexao
    {
        public static String servidor = @"Dell\SQLEXPRESS";
        public static String nomeDB = "Matanquene";
        public static String usuario = "sa";
        public static String senha = "@yuranJunior13#";
        
        public static String StringDeConexao
        {
            get
            {
                return "Data Source="+ servidor +";Initial Catalog="+ nomeDB +";User ID="+ 
                    usuario +";Password="+ senha +"";
            }
        }
    }
}
