using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.Models.Context
{
    [Table("Curso")]
    public class Curso
    {
        public Curso()
        {
            Destacado = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodCurso { get; set; }
        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public string ImageMimeType { get; set; }
        [ForeignKey("Categoria")]
        public int? CodCategoria { get; set; }
        public bool Destacado { get; set; }
        public DateTime? Fecha { get; set; }

        public Categoria Categoria { get; set; }

    }
}
