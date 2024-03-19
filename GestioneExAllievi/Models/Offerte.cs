using System.ComponentModel.DataAnnotations;

namespace GestioneExAllievi.Models
{
    public class Offerte
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il titolo è obbligatorio.")]
        public string Titolo { get; set; }

        [Required(ErrorMessage = "La specializzazione è obbligatoria.")]
        public string Specializzazione { get; set; }

        [Required(ErrorMessage = "La descrizione è obbligatoria.")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Il luogo è obbligatorio.")]
        public string Luogo { get; set; }

        [Required(ErrorMessage = "Il salario è obbligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Il salario deve essere un numero intero positivo.")]
        public int Salario { get; set; }
    }
}
