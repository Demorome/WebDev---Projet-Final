using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;

namespace INFO4042___Projet_Final.Models
{
    // On doit stocker des informations de contact, telles que des noms, des adresses et des numéros de téléphone
    public class Contact
    {
        [Key]
        public int ContactId { get; set; } // Primary Key

        [Required(ErrorMessage = "Vous devez donner un nom pour le contact")]
        [Display(Name = "Nom du contact")]
        public required string Name { get; set; }

        // Code copiée de https://stackoverflow.com/a/28905087/22891557
        [Required(ErrorMessage = "Vous devez inclure un numéro de téléphone")]
        [Display(Name = "Numéro de téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Numéro de téléphone invalide!")]
        public required string PhoneNumber { get; set; }

        // Le nom de l'utilisateur qui possède ce contact
        // On l'utilisera pour but d'authentification
        public string? UserName { get; set; }

        [Display(Name = "Adresse")]
        public string? Address { get; set; }

        [Display(Name = "Ville")]
        public string? City { get; set; }

        public string? Province { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Courriel")]
        public string? Email { get; set; }

        [Display(Name = "Date de création")]
        [DataType(DataType.Date)]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Catégorie")]
        public int? CategoryId { get; set; }  // Foreign Key

        // Fait un lien avec la catégorie que l'utilisateur classifie ce contact avec (optionel).
        // On suppose qu'un contact appartient a seulement une catégorie au plus.
        [Display(Name = "Catégorie")]
        public virtual Category? Category { get; set; }
    }
}
