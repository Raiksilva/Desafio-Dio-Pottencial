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
    public class VendedorController : ControllerBase
    {
        private readonly PagamentoApiContext _VendedorContext;

        public VendedorController(PagamentoApiContext vendedorContext)
        {
            _VendedorContext = vendedorContext;
        }

        [HttpGet("Obtendo_vendedor_por_ID{ID}")]
        public IActionResult ObterVendendorPorID(int ID)
        {
            var vendedor = _VendedorContext.Vendedor.Find(ID);

            if(vendedor == null)
                return BadRequest(new { Erro = "O ID do vendedor foi inserido errado" });

            return Ok(vendedor);
        }

        [HttpPost("Adicionando_Vendedor")]
        public IActionResult AdicionarVendedor(Vendedor vendedor)
        {
            _VendedorContext.Add(vendedor);
            _VendedorContext.SaveChanges();
            return CreatedAtAction(nameof(ObterVendendorPorID), new { ID = vendedor.ID }, vendedor);
        }
    }
}