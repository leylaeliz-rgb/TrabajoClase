using System.ComponentModel.DataAnnotations;

namespace BackofficeApi.Dto
{
    public class CategoriaCrearDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(80)]
        public string Nombre { get; set; } = string.Empty;
        [StringLength(200)]
        public string? Descripcion { get; set; } /// más especifico para crear, y mas recomendabel
    }
}
