using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment_api.Context;
using Payment_api.Models;

namespace Payment_api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly PagamentoApiContext _VendaContext;
        public VendaController(PagamentoApiContext vendaContext)
        {
            _VendaContext = vendaContext;
        }

        [HttpPost("Adicionar_Venda")]
         public IActionResult AdicionarVenda(VendaItem venda)
         {
            var Vendedor = _VendaContext.Vendedor.Find(venda.IDVendedor);

            if(Vendedor == null)
                return BadRequest(new { Erro = "O vendedor não foi adicionado" });

            if(string.IsNullOrEmpty(venda.item))
                return BadRequest(new { Erro = "O item está vazio" });

            venda.StatusItemVenda = EnumStatusVendaIteins.Aguardando_Pagamento;
            _VendaContext.vendaItem.Add(venda);
            _VendaContext.SaveChanges();
            return CreatedAtAction(nameof(ObterVendaPorID), new { ID = venda.ID }, venda);
        }

        [HttpPatch("Atualizar_Venda{ID}")]
        public IActionResult AtualizarVenda(int ID, VendaItem venda, EnumStatusVendaIteins status)
        {
            var VendaBanco = _VendaContext.vendaItem.Find(ID);

            if(VendaBanco == null)
                return NotFound();

            if(venda.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "Precisa inserir uma data para a compra" });

            VendaBanco.Data = venda.Data;
            VendaBanco.IDVendedor = venda.IDVendedor;
            VendaBanco.item = venda.item;

            if(venda.StatusItemVenda == EnumStatusVendaIteins.Aguardando_Pagamento)
            {
                if(status != EnumStatusVendaIteins.Pagamento_Aprovado && status != EnumStatusVendaIteins.Cancelado)
                {
                    return BadRequest(new { Erro = "Atualização invalida. Verifique se o status da venda está correto." });
                }
            }

             if(venda.StatusItemVenda == EnumStatusVendaIteins.Pagamento_Aprovado)
            {
                if(status != EnumStatusVendaIteins.Enviado_para_Transportadora && status != EnumStatusVendaIteins.Cancelado)
                {
                    return BadRequest(new { Erro = "Atualização invalida. Verifique se o status da venda está correto."});
                }
            }

            if(venda.StatusItemVenda == EnumStatusVendaIteins.Enviado_para_Transportadora)
            {
                if(status != EnumStatusVendaIteins.Em_rota_de_entraga && status != EnumStatusVendaIteins.Cancelado)
                {
                    return BadRequest(new { Erro = "Atualização invalida. Verifique se o status da venda está correto." });
                }
            }
        
            if(venda.StatusItemVenda == EnumStatusVendaIteins.Em_rota_de_entraga)
            {
                if(status != EnumStatusVendaIteins.Entregue && status != EnumStatusVendaIteins.Cancelado)
                {
                    return BadRequest(new { Erro = "Atualização invalida. Verifique se o status da venda está correto." });
                }
            }

            VendaBanco.StatusItemVenda = status;
            _VendaContext.vendaItem.Update(VendaBanco);
            _VendaContext.SaveChanges();

            return Ok(VendaBanco);
        }

        [HttpGet("Visualizar_venda_por_ID{ID}")]
        public IActionResult ObterVendaPorID(int ID)
        {
            var venda = _VendaContext.vendaItem.Find(ID);

            if(venda == null)
                return BadRequest(new { Erro = "A venda não pode ser nula" });

            return Ok(venda);
        }
    }
}