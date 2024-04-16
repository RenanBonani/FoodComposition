using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodComposition.Infrastructure.Entities
{
    [Table("FoodComposition")]
    public class Composition
    {
        public Composition()
        {
            Componentes = new List<string>();
        }

        [Key]
        public  int id { get; set; }
        [Column("code")]
        public string Code { get; set; } = string.Empty;

        [Column("namefood")]
        public string NameFood { get; set; } = string.Empty;

        [Column("scientificname")]
        public string? ScientificName { get; set; } = string.Empty;

        [Column("groupfood")]
        public string GroupFood { get; set; } = string.Empty;

        [Column("componentes")]
        public List<string> Componentes { get; set; }
    }
}
