using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.Modelos
{
    public class ModeloFuncionario
    {
        public ModeloFuncionario()
        {
            this.IdFuncionario = 0;
            this.Nome = "";
            this.Sexo = "";
            this.Contacto = "";
            this.EstadoCivil = "";
            this.Endereco = "";
            this.DataNasc.Equals("");
        }

        public ModeloFuncionario(int idFuncionario, string nome, string sexo, string endereco, string contacto,
            string estadoCivil, DateTime dataNasc)
        {
            this.IdFuncionario = idFuncionario;
            this.Nome = nome;
            this.Sexo = sexo;
            this.Endereco = endereco;
            this.Contacto = contacto;
            this.EstadoCivil = estadoCivil;
            this.DataNasc = dataNasc;
        }

        private int _idFuncionario;
        public int IdFuncionario
        {
            get { return this._idFuncionario; }
            set { this._idFuncionario = value; }
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

        public string _endereco;
        public string Endereco
        {
            get { return this._endereco; }
            set { this._endereco = value; }
        }

        private DateTime _dataNasc;
        public DateTime DataNasc
        {
            get { return this._dataNasc; }
            set { this._dataNasc = value; }
        }

        private string _estadoCivil;
        public string EstadoCivil
        {
            get { return this._estadoCivil; }
            set { this._estadoCivil = value; }
        }

        private string _contacto;
        public string Contacto
        {
            get { return this._contacto; }
            set { this._contacto = value; }
        }
    }
}
