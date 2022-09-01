using System.ComponentModel.DataAnnotations.Schema;

namespace BasicMVC.Models
{
    [Table("Produto")]
    public class Personagem
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
        [Column("Descricao")]
        public string? Descricao { get; set; }
    }
}
