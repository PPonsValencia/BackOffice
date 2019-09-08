using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.Models.Context
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodCategoria { get; set; }
        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public string ImageMimeType { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
