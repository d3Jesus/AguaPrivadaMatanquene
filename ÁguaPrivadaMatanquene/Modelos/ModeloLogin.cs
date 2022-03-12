using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.Modelos
{
    public class ModeloLogin
    {
        private int _idLogin;
        public int IdLogin
        {
            get { return this._idLogin; }
            set { this._idLogin = value; }
        }

        private string _tipoUsuario;
        public string TipoDeUsuario
        {
            get { return this._tipoUsuario; }
            set { this._tipoUsuario = value; }
        }

        private string _usuario;
        public string Usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }
        }

        private string _senha;
        public string Senha
        {
            get { return this._senha; }
            set { this._senha = value; }
        }

        private string _estadoUsuario;
        public string EstadoUsuario
        {
            get { return this._estadoUsuario; }
            set { this._estadoUsuario = value; }
        }
    }
}
