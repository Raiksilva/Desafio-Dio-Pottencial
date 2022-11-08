using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_api.Models
{
    public class Vendedor
    {
        public int ID{ get; set; }
        public string CPF{ get; set; }
        public string Nome{ get; set; }
        public string Email{ get; set; }
        public string Telefone{ get; set; }
    }
}