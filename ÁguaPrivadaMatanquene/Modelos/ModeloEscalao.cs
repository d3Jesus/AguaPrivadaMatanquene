using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.Modelos
{
    public class ModeloEscalao
    {
        public ModeloEscalao()
        {
            this.IdEscalao = 0;
            this.Especie = "";
            this.Quantidade = 0;
            this.ValorUn = 0.0;
            this.IVA = 0.0;
        }

        public ModeloEscalao(int idEscalao, string especie, int qnt, double valUn, double iva)
        {
            this.IdEscalao = idEscalao;
            this.Especie = especie;
            this.Quantidade = qnt;
            this.ValorUn = ValorUn;
            this.IVA = iva;
        }

        private int _idEscalao;
        public int IdEscalao
        {
            get { return this._idEscalao; }
            set { this._idEscalao = value; }
        }

        private string _especie;
        public string Especie
        {
            get { return this._especie; }
            set { this._especie = value; }
        }

        private int _quantidade;
        public int Quantidade
        {
            get { return this._quantidade; }
            set { this._quantidade = value; }
        }

        private double _valUn;
        public double ValorUn
        {
            get { return this._valUn; }
            set { this._valUn = value; }
        }

        private double _iva;
        public double IVA
        {
            get { return this._iva; }
            set { this._iva = value; }
        }
    }
}
