﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GestioneExAllievi.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestioneExAllievi.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<GestioneExAllieviUser> _userManager;
        private readonly SignInManager<GestioneExAllieviUser> _signInManager;

        public IndexModel(
            UserManager<GestioneExAllieviUser> userManager,
            SignInManager<GestioneExAllieviUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Phone]
        [Display(Name = "Numero di Telefono")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Il campo Codice Fiscale o la partita iva è obbligatorio.")]
        [RegularExpression(@"^([a-zA-Z]{6}\d{2}[a-zA-Z]\d{2}[a-zA-Z]\d{3}[a-zA-Z])|(\d{11})$", ErrorMessage = "Il codice fiscale o la partita IVA non è valido.")]
        public string CodiceFiscale { get; set; }

        private async Task LoadAsync(GestioneExAllieviUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;
            PhoneNumber = phoneNumber;
            CodiceFiscale = user.CodiceFiscale;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossibile caricare l'utente con ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossibile caricare l'utente con ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Errore imprevisto durante il tentativo di impostare il numero di telefono.";
                    return RedirectToPage();
                }
            }

            if (CodiceFiscale != user.CodiceFiscale)
            {
                user.CodiceFiscale = CodiceFiscale;
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Il tuo profilo è stato aggiornato";
            return RedirectToPage();
        }
    }
}