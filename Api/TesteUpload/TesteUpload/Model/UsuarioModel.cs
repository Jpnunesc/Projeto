using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TesteUpload.Model
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Estado { get; set; }

        public bool? Ganhador  { get; set; }

        public bool? Ativo { get; set; }

        public virtual RifaModel Rifa { get; set; }


    }
}