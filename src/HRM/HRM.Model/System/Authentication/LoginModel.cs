using System.ComponentModel.DataAnnotations;

namespace HRM.Model.System
{
    public class LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public string Password { get; set; } = string.Empty;

        public string IpAddress { get; set; } = string.Empty;

    }
}
