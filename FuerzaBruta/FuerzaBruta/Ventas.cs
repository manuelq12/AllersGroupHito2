using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuerzaBruta
{
    public class Ventas
    {
        private String cardCode;
        private String docNum;
        private DateTime docDate;
        private String itemCode;
        private int cantidad;
        private int precio;
        private int totalVenta;

        public Ventas(string cardCode, string docNum, DateTime docDate, string itemCode, int cantidad, int precio, int totalVenta)
        {
            this.cardCode = cardCode;
            this.docNum = docNum;
            this.docDate = docDate;
            this.itemCode = itemCode;
            this.cantidad = cantidad;
            this.precio = precio;
            this.totalVenta = totalVenta;
        }

        public string CardCode { get => cardCode; set => cardCode = value; }
        public string DocNum { get => docNum; set => docNum = value; }
        public DateTime DocDate { get => docDate; set => docDate = value; }
        public string ItemCode { get => itemCode; set => itemCode = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Precio { get => precio; set => precio = value; }
        public int TotalVenta { get => totalVenta; set => totalVenta = value; }
    }
}
