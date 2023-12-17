using System.ComponentModel.DataAnnotations;

namespace GestionEtudiant.Models.ViewModels
{
    public class EditRoleViewModeL
    {
        public EditRoleViewModeL()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
