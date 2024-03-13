using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace GestioneExAllievi.Models
{
    public class DatiExAllievi
    {
        [Key]
        [Required(ErrorMessage = "Il campo Codice Fiscale è obbligatorio.")]
        [RegularExpression(@"^[A-Z]{6}\d{2}[A-Z]\d{2}[A-Z]\d{3}[A-Z]$", ErrorMessage = "Il Codice Fiscale non è valido.")]
        public string CodiceFiscale { get; set; }

        [Required(ErrorMessage = "È richiesto il nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "È richiesto il cognome.")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "È richiesto l'indirizzo.")]
        public string Indirizzo { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Il numero di telefono deve essere composto da 10 cifre.")]
        public string NumTelefono { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Il formato dell'email non è valido.")]
        public string Email { get; set; }

        public SocialMediaType SocialMedia { get; set; }

        [Display(Name = "Username Social Media")]
        public string? UsernamesSocialMedia { get; set; }

        [Required(ErrorMessage = "È richiesto il titolo di studio.")]
        public string TitoloDiStudio { get; set; }

        [Required(ErrorMessage = "È richiesta la specializzazione del titolo di studio.")]
        public string Specializzazione { get; set; }

        public bool FrequentaUniversita { get; set; }
        public bool CercaLavoro { get; set; }
        public bool EOccupato { get; set; }
        public decimal? StipendioMensileAttuale { get; set; } 
        public decimal? StipendioMensileRichiesto { get; set; }
        public string? CurriculumFilePath { get; set; }
    }

    public enum SocialMediaType
    {
        Nessuno,
        Facebook,
        Twitter,
        Instagram,
        LinkedIn,
        YouTube,
        TikTok,
        Altro
    }
}
