using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlog.Models
{
    public class Access
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        [NotMapped]
        public string RoleName { get; set; }

        [NotMapped]
        public int RolessId { get; set; }
    }
    public class UserForm
    {
        [Required(ErrorMessage = "Username Harus Diisi")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Name Harus Diisi")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password Harus Diisi")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role Harus Diisi")]
        public int Role { get; set; }
        public string Picture { get; set; }
    }
    public class AccessUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
