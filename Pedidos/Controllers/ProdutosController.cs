using Microsoft.AspNetCore.Mvc;
using Pedidos.Domain.Pedidos;
using Pedidos.Repositories;
using Pedidos.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtosRepository;
        public ProdutosController(IProdutoRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }
        // GET: api/<ProdutosController>
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return Ok(_produtosRepository.GetAll());
        }

        // POST api/<ProdutosController>
        //[HttpPost]
        //public ActionResult<bool> Post([FromBody] Produto value)
        //{
        //    return Ok(_produtosRepository.Create(value));
        //}

        // PUT api/<ProdutosController>/5
        //[HttpPut("{id}")]
        //public ActionResult<bool> Put(int id, [FromBody] Produto value)
        //{
        //    if (id != value.Id)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_produtosRepository.Update(value));
        //}

        // DELETE api/<ProdutosController>/5
        //[HttpDelete("{id}")]
        //public ActionResult<bool> Delete(int id)
        //{
        //    return Ok(_produtosRepository.Delete(id));
        //}
    }
}
