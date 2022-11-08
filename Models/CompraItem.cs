using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_api.Models
{
    public class CompraItem
    {
        public int ID{ get; set; }
        public int IDVendas{ get; set; }
        public int IDVendedor{ get; set; }
        public VendaItem Venda{ get; set; }
        public Vendedor Vendedor{ get; set; }
    }
}