using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Tables
{
    [Table("Login")]
    public partial class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Active { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [StringLength(10)]
        public string CodigoVerificacao { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
