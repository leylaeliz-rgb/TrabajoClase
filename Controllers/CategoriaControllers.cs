using BackofficeApi.Dto;
using BackofficeApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace BackofficeApi.Controllers
{
    [ApiController] // el proyecto sabe que con este controlador va a trabajar
    [Route("api/[controller]")]
    public class CategoriaControllers : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriaControllers (ICategoriaService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoriaDto>> Listar ()
        {
            return Ok(_service.Listar());
        }
        [HttpGet("{id:int}")]
        public ActionResult<CategoriaDto> ObtenerPorId (int id)
        {
            var categoria = _service.ObtenerPorId(id);
            return categoria is null ? NotFound() : Ok(categoria);
        }

        [HttpPost]
        public ActionResult<CategoriaDto> Crear(CategoriaCrearDto dto)
        {
            var nueva = _service.Crear(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nueva.Id }, nueva);
        }
    }
}
