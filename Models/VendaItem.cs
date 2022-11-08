using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Payment_api.Models
{
    public class VendaItem
    {
        public int ID{ get; set; }
        public int IDVendedor{ get; set; }
        public  DateTime Data{ get; set; }
        public string item{ get; set; }
        public EnumStatusVendaIteins StatusItemVenda { get; set; }
        
    }
}