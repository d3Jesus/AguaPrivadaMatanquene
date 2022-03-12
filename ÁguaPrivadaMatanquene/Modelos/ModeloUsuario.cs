using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.Modelos
{
    public class ModeloUsuario
    {
        public ModeloUsuario()
        {
            this.IdUsuario = 0;
            this.IdFuncionario = 0;
            this.NomeUsuario = "";
            this.Senha = "";
            this.Cargo = "";
            this.Situacao = "";
        }

        public ModeloUsuario(int idUsuario, int idF, string nomeUsuario, string senha, string cargo, string sit)
        {
            this.IdUsuario = idUsuario;
            this.IdFuncionario = idF;
            this.NomeUsuario = nomeUsuario;
            this.Senha = senha;
            this.Cargo = cargo;
            this.Situacao = sit;
        }

        private int _idUsuario;
        public int IdUsuario
        {
            get { return this._idUsuario; }
            set { this._idUsuario = value; }
        }

        private int idF;
        public int IdFuncionario
        {
            get { return this.idF; }
            set { this.idF = value; }
        }

        private string _nomeUsuario;
        public string NomeUsuario
        {
            get { return this._nomeUsuario; }
            set { this._nomeUsuario = value; }
        }

        private string _senha;
        public string Senha
        {
            get { return this._senha; }
            set { this._senha = value; }
        }

        private string _cargo;
        public string Cargo
        {
            get { return this._cargo; }
            set { this._cargo = value; }
        }

        private string _situacao;
        public string Situacao
        {
            get { return this._situacao; }
            set { this._situacao = value; }
        }
    }
}
