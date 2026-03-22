using System.ComponentModel.DataAnnotations;

namespace VideoGame.Application.Dtos.Game
{
    public class SaveGameDto
    {
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El título debe tener entre 2 y 200 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "El género es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El género debe tener entre 2 y 100 caracteres.")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de lanzamiento es obligatoria.")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 999.99, ErrorMessage = "El precio debe estar entre 0.01 y 999.99.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El desarrollador es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un desarrollador válido.")]
        public int DeveloperId { get; set; }

        [Required(ErrorMessage = "El publisher es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un publisher válido.")]
        public int PublisherId { get; set; }
    }
}
