using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo de duração é obrigatório")]
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máxio 600.")]
        public int Duracao { get; set; }

        [StringLength(100, ErrorMessage = "O nome do diretor não pode exceder 100 caracteres")]
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Genero { get; set; }

        public int ClassificacaoEtaria { get; set; }

        public virtual List<Sessao> Sessoes { get; set; }
    }
}
