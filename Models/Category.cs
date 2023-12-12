using System.ComponentModel.DataAnnotations;

namespace INFO4042___Projet_Final.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // Primary Key

        [Required(ErrorMessage = "Vous devez donner un nom pour la catégorie")]
        public required string Name { get; set; }

        public virtual ICollection<Contact>? Contacts { get; set; }
    }
}
