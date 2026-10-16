using BackofficeApi.Dto;

namespace BackofficeApi.Services
{
    public interface ICategoriaService
    {
        IEnumerable<CategoriaDto> Listar();
        CategoriaDto? ObtenerPorId(int id);
        CategoriaDto Crear(CategoriaCrearDto dto);
    }
}
