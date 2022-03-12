using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.Modelos
{
    public class ModeloPagamento
    {
        public ModeloPagamento()
        {
            this.IdPagamento = 0;
            this.IdFactura = 0;
            this.IdRecibo = 0;
            this.DataPag.Equals("");
            this.TipoPag = "";
            this.ValorTotal = 0.00;
            this.ChequeNr = null;
        }

        public ModeloPagamento(int idPagamento, DateTime dataPag, int fact, int rec, string tipo, double total, int cheque)
        {
            this.IdPagamento = idPagamento;
            this.IdFactura = fact;
            this.IdRecibo = rec;
            this.TipoPag = tipo;
            this.ValorTotal = total;
            this.DataPag = dataPag;
            this.ChequeNr = cheque;
        }

        private int _idPagamento;
        public int IdPagamento
        {
            get { return this._idPagamento; }
            set { this._idPagamento = value; }
        }

        private DateTime _dataPag;
        public DateTime DataPag
        {
            get { return this._dataPag; }
            set { this._dataPag = value; }
        }

        private int _idFactura;
        public int IdFactura
        {
            get { return this._idFactura; }
            set { this._idFactura = value; }
        }

        private int _idRecibo;
        public int IdRecibo
        {
            get { return this._idRecibo; }
            set { this._idRecibo = value; }
        }

        private string _tipoPag;
        public string TipoPag
        {
            get { return this._tipoPag; }
            set { this._tipoPag = value; }
        }

        private double _valorTotal;
        public double ValorTotal
        {
            get { return this._valorTotal; }
            set { this._valorTotal = value; }
        }

        private Nullable<int> _chequeNr;
        public Nullable<int> ChequeNr
        {
            get { return this._chequeNr; }
            set { this._chequeNr = value; }
        }
    }
}
