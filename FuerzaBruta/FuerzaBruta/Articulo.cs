using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuerzaBruta
{
    public class Articulo
    {
        private int itemCode;
        private String itemName;
        private String itemClasification;

        public Articulo(int ItemCode, string ItemName, String ItemClasification)
        {
            itemCode = ItemCode;
            itemName = ItemName;
            itemClasification = ItemClasification;
        }

        public int ItemCode { get => itemCode; set => itemCode = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public String ItemClasification { get => itemClasification; set => itemClasification = value; }
        
    }
}
