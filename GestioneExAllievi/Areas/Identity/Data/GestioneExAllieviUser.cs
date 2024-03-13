using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GestioneExAllievi.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GestioneExAllieviUser class
public class GestioneExAllieviUser : IdentityUser
{
    [PersonalData]
    public string UserType { get; set; }

    [PersonalData]
    [RegularExpression(@"^[A-Z]{6}\d{2}[A-Z]\d{2}[A-Z]\d{3}[A-Z]$", ErrorMessage = "Il codice fiscale non è valido.")]
    public string CodiceFiscale { get; set; }
}

