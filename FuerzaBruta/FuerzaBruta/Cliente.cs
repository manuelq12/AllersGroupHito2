using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuerzaBruta
{
    public class Cliente
    {
        private String cardCode;
        private String groupName;
        private String city;
        private String department;
        private String paymentGroup;

        public Cliente(string cardCode, string groupName, string city, string department, string paymentGroup)
        {
            this.cardCode = cardCode;
            this.groupName = groupName;
            this.city = city;
            this.department = department;
            this.paymentGroup = paymentGroup;
        }

        public string CardCode { get => cardCode; set => cardCode = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public string City { get => city; set => city = value; }
        public string Department { get => department; set => department = value; }
        public string PaymentGroup { get => paymentGroup; set => paymentGroup = value; }
    }
}
