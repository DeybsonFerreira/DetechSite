using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Tables
{
    [Table("Endereco")]
    public partial class Endereco
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Cep { get; set; }
        [StringLength(2)]
        public string Uf { get; set; }
        [StringLength(60)]
        public string Rua { get; set; }
        [StringLength(50)]
        public string Cidade { get; set; }
        [StringLength(50)]
        public string Bairro { get; set; }
        [StringLength(10)]
        public string Numero { get; set; }
        [StringLength(80)]
        public string Complemento { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
