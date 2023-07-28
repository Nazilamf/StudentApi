using System.ComponentModel.DataAnnotations;

namespace StudentApp.UI.ViewModels
{
    public class GroupCreateViewModel
    {
        [Required]
        [MaxLength(35)]
        [MinLength(2)]
        public string GroupNo { get; set; }
    }
}
