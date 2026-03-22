using System.ComponentModel.DataAnnotations;

namespace VideoGame.Application.Dtos.Developer
{
    public class SaveDeveloperDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 150 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El país es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El país debe tener entre 2 y 100 caracteres.")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año de fundación es obligatorio.")]
        [Range(1800, 2100, ErrorMessage = "El año de fundación debe estar entre 1800 y 2100.")]
        public int FoundedYear { get; set; }
    }
}
