using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.Modelos
{
    public class ModeloCliente
    {
        public ModeloCliente()
        {
            this.IdCliente = 0;
            this.Nome = "";
            this.Sexo = "";
            this.DataNasc.Equals("");
            this.Provincia = "";
            this.Bairro = "";
            this.Quarteirao = 0;
            this.Rua = "";
            this.EstadoCivil = "";
            this.Contacto = "";
        }

        public ModeloCliente(int idCliente, string nome, string sexo, string provincia, string bairro, 
            string contacto, int qrter, string rua, DateTime nasc, string estCiv)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.Sexo = sexo;
            this.Provincia = provincia;
            this.Bairro = bairro;
            this.EstadoCivil = estCiv;
            this.Rua = rua;
            this.DataNasc = nasc;
            this.Quarteirao = qrter;
            this.Contacto = contacto;
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return this._idCliente; }
            set { this._idCliente = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return this._nome; }
            set { this._nome = value; }
        }

        private string _sexo;
        public string Sexo
        {
            get { return this._sexo; }
            set { this._sexo = value; }
        }

        private string _provincia;
        public string Provincia
        {
            get { return this._provincia; }
            set { this._provincia = value; }
        }

        public string _bairro;
        public string Bairro
        {
            get { return this._bairro; }
            set { this._bairro = value; }
        }

        private string _contacto;
        public string Contacto
        {
            get { return this._contacto; }
            set { this._contacto = value; }
        }

        private string _estadoCivil;
        public string EstadoCivil
        {
            get { return this._estadoCivil; }
            set { this._estadoCivil = value; }
        }

        private string _rua;
        public string Rua
        {
            get { return this._rua; }
            set { this._rua = value; }
        }

        private DateTime _dataNascimento;
        public DateTime DataNasc
        {
            get { return this._dataNascimento; }
            set { this._dataNascimento = value; }
        }

        private int _quart;
        public int Quarteirao
        {
            get { return this._quart; }
            set { this._quart = value; }
        }
    }
}
