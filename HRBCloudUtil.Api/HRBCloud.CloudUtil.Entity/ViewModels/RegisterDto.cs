
using System.ComponentModel.DataAnnotations;

namespace HRBCloud.CloudUtil.Entity.ViewModels
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string EmailId { get; set; }

    }
}
