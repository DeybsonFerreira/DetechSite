using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Tables
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string Email { get; set; }
        public string Img { get; set; }
        [Required]
        public int UserTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Fone { get; set; }
        public virtual IEnumerable<Endereco> Endereco { get; set; }
        public virtual IEnumerable<Login> Login { get; set; }


    }
}
