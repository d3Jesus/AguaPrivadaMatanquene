using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.Modelos
{
    public class ModeloFactura
    {
        public ModeloFactura()
        {
            this.IdFactura = 0;
            this.IdInstalacao = 0;
            this.IdCliente = 0;
            this.Data.Equals("");
            this.IVA = 0.0;
            this.ValorTot = 0.0;
            this.Estado = "";
        }

        public ModeloFactura(int idFactura, int instal, int cli, DateTime data, double iva, double val, string est)
        {
            this.IdFactura = idFactura;
            this.IdInstalacao = instal;
            this.IdCliente = cli;
            this.Data = data;
            this.IVA = iva;
            this.ValorTot = val;
            this.Estado = est;
        }

        private int _idFactura;
        public int IdFactura
        {
            get { return this._idFactura; }
            set { this._idFactura = value; }
        }

        private int _idInstalacao;
        public int IdInstalacao
        {
            get { return this._idInstalacao; }
            set { this._idInstalacao = value; }
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return this._idCliente; }
            set { this._idCliente = value; }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        private double _iva;
        public double IVA
        {
            get { return this._iva; }
            set { this._iva = value; }
        }

        private double _valor;
        public double ValorTot
        {
            get { return this._valor; }
            set { this._valor = value; }
        }

        private string _estado;
        public string Estado
        {
            get { return this._estado; }
            set { this._estado = value; }
        }
    }
}
