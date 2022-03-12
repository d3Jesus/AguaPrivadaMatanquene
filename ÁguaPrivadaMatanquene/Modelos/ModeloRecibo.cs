using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.Modelos
{
    public class ModeloRecibo
    {
        public ModeloRecibo()
        {
            this.IdRecibo = 0;
            this.NrFactura = 0;
            this.IVA = 0.0;
            this.Data.Equals("");
            this.ValorPag = 0.0;
        }

        public ModeloRecibo(int idRecibo, int nrFactura, DateTime data, double valPag, double iva)
        {
            this.IdRecibo = idRecibo;
            this.NrFactura = nrFactura;
            this.IVA = iva;
            this.Data = data;
            this.ValorPag = valPag;
        }

        private int _idRecibo;
        public int IdRecibo
        {
            get { return this._idRecibo; }
            set { this._idRecibo = value; }
        }

        private int _nrFactura;
        public int NrFactura
        {
            get { return this._nrFactura; }
            set { this._nrFactura = value; }
        }
        
        private double _valPag;
        public double ValorPag
        {
            get { return this._valPag; }
            set { this._valPag = value; }
        }

        private double _iva;
        public double IVA
        {
            get { return this._iva; }
            set { this._iva = value; }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return this._data; }
            set { this._data = value; }
        }
    }
}
