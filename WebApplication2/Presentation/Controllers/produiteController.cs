using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Domain.Interfaces;
using WebApplication2.Domain.Models;
using WebApplication2.Presentation.Filters;

namespace WebApplication2.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TokenAuthenticationFilter]
    public class produiteController : ControllerBase
    {
        private readonly IProduiteDAO _dao;

        public produiteController(IProduiteDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public ActionResult GetAllProduite()
        {
            var produites = _dao.GetAll();
            return Ok(produites);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetProduiteById([FromRoute] int id)
        {
            var produite = _dao.GetById(id);
            if (produite == null)
            {
                return BadRequest($"Produite {id} Not found");
            }
            return Ok(produite);
        }

        [HttpDelete]
        public ActionResult DeleteProduiteById(int id)
        {
            if (_dao.DeleteProduite(id))
            {
                return Ok("le produite Deleted !");
            }
            return NotFound("No Data found !!");
        }

        [HttpPost]
        public ActionResult CreateProduite([FromBody] produite produite)
        {
            _dao.Create(produite);
            return Ok("Created le produite successfully");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduite(int id, produite produite)
        {
            var prod = _dao.UpdateProduite(id, produite);
            if (prod == null)
            {
                return NotFound();
            }
            return Ok(prod);
        }
    }
}

