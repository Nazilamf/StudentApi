using System.ComponentModel.DataAnnotations;

namespace StudentApp.UI.ViewModels
{
    public class GroupEditViewModel
    {
        [Required]
        [MaxLength(35)]
        [MinLength(2)]
        public string GroupNo { get; set; }
    }
}
