using Microsoft.AspNetCore.Mvc;
using Pedidos.Model;
using Pedidos.Domain.Interfaces;
using Pedidos.Sevices;
using Pedidos.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoService _pedidoService;
        public PedidosController(IPedidoRepository pedidoRepository, IPedidoService pedidoService)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoService = pedidoService;
        }
       

        // GET api/<PedidosController>/5
        [HttpGet("{id}")]
        public ActionResult<PedidoDTO> Get(int id)
        {
            return Ok(_pedidoService.GetByIdPedido(id));
        }

        [HttpGet]
        public ActionResult<PedidoDTO> GetAll()
        {
            return Ok(_pedidoService.GetAll());
        }

        // POST api/<PedidosController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] PedidoModel pedido)
        {
            return Ok(_pedidoService.Create(pedido));
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PedidoModel pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            return Ok(_pedidoService.Update(pedido));
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_pedidoRepository.Delete(id));
        }
    }
}
