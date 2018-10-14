using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TesteUpload.Model;

namespace TesteUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly UP7WebApiContext _context;

        public CarrosController(UP7WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Carros
        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<ReturnModel> Getcarro()
        {
            ReturnModel result = new ReturnModel();
            var carro =  _context.carro.Include(x => x.Imagem).AsQueryable();

            result.Object =  carro.Select(p => new 
            {
               p.Id,
               p.Imagem,
               p.Marca,
               p.Modelo,
               p.Ano,
               p.Descricao,
               p.Preco,
               p.Cor,
               p.Quilometragem,
               p.Potencia,
               p.PaisOrigem,
               p.Bancos,
               p.ArCondicionado,
               p.Vidros,
               p.Freios,
               p.Tracao,
               p.Rodas,
               p.StatusCarro,
               p.CarroAntigo,
               p.CarroSeminovo 

           }).ToList();
            result.Success = true;
            result.Message = "sucesso!!";
            return result;

        }

        //[HttpGet]
        //public async Task<IActionResult> Getcarro()
        //{
        //    // return _context.carro;
        //    var carro = await _context.carro.Include(x => x.Imagem).ToListAsync();
        //    return Ok(carro);
        //}

        // GET: api/Carros/5
        [HttpGet("{id}")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> GetCarroModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carroModel = await _context.carro.FindAsync(id);

            if (carroModel == null)
            {
                return NotFound();
            }

            return Ok(carroModel);
        }

        // PUT: api/Carros/5
        [HttpPut("{id}")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> PutCarroModel([FromRoute] int id, [FromBody] CarroModel carroModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carroModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(carroModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [Produces("application/json")]
        [HttpPost, DisableRequestSizeLimit]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> UploadFile()
        {
            try
            {
                var carroImagem = new List<ImagemModel>();
                var carro = JsonConvert.DeserializeObject<CarroModel>(Request.Form["carro"]);
                var filePath = Path.GetTempPath();

                foreach (var arquivo in Request.Form.Files)
                {
                    if (arquivo.Length > 0)
                    {
                        carro.Imagem.Add(new ImagemModel { Caminho = $"{Path.GetTempPath()}{arquivo.FileName}" });
                        var imagem = $"{Path.GetTempPath()}{arquivo.FileName}";
                        using (var stream = new FileStream(imagem, FileMode.Create))
                        {
                            await arquivo.CopyToAsync(stream);
                        }
                    }
                }
                _context.carro.Add(carro);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("sucess");
        }

        // DELETE: api/Carros/5
        [HttpDelete("{id}")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> DeleteCarroModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carroModel = await _context.carro.FindAsync(id);
            if (carroModel == null)
            {
                return NotFound();
            }

            _context.carro.Remove(carroModel);
            await _context.SaveChangesAsync();

            return Ok(carroModel);
        }

        private bool CarroModelExists(int id)
        {
            return _context.carro.Any(e => e.Id == id);
        }
    }
}