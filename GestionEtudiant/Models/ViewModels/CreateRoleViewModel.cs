using System.ComponentModel.DataAnnotations;

namespace GestionEtudiant.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }

    }
}
