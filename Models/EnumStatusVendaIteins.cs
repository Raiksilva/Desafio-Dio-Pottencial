using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_api.Models
{
     public enum EnumStatusVendaIteins
    {
        Aguardando_Pagamento,
        Pagamento_Aprovado,
        Enviado_para_Transportadora,
        Em_rota_de_entraga,
        Entregue,
        Cancelado
        
    }
}