using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.Modelos
{
    public class ModeloInstalacao
    {
        public ModeloInstalacao()
        {
            this.IdInstalacao = 0;
            this.IdCliente = 0;
            this.IdFuncionario = 0;
            this.IdEscalao = 0;
            this.Data.Equals("");
            this.Contador = 0;
            this.LocalAbastecimento = "";
        }

        public ModeloInstalacao(int idInstalacao, int cli, int func, int esc, int fact, DateTime data, int cont, string local)
        {
            this.IdInstalacao = idInstalacao;
            this.IdCliente = cli;
            this.IdFuncionario = func;
            this.IdEscalao = esc;
            this.Data = data;
            this.Contador = cont;
            this.LocalAbastecimento = local;
        }

        private int _idInstalacao;
        public int IdInstalacao
        {
            get { return this._idInstalacao; }
            set { this._idInstalacao = value; }
        }

        private string _local;
        public string LocalAbastecimento
        {
            get { return this._local; }
            set { this._local = value; }
        }

        private int _contador;
        public int Contador
        {
            get { return this._contador; }
            set { this._contador = value; }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        private int _cliente;
        public int IdCliente
        {
            get { return this._cliente; }
            set { this._cliente = value; }
        }
        private int _funcionario;
        public int IdFuncionario
        {
            get { return this._funcionario; }
            set { this._funcionario = value; }
        }

        private int _escalao;
        public int IdEscalao
        {
            get { return this._escalao; }
            set { this._escalao = value; }
        }
    }
}
