using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace assmint.Models
{
    public class TeamMember
    {
        [Key]
        public int TeamMemberid { get; set; }

        [StringLength(100, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Email length can't be more than 100.") ]
        
        public string email { get; set; } = string.Empty;
        [StringLength(50, ErrorMessage = "Role length can't be more than 100.")]
        public string Role { get; set; }

        public List<Taske> tasks { get; set; }
    }

}
