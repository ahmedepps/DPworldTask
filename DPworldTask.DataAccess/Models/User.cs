using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPworldTask.DataAccess.Models
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; } = string.Empty;
        [Required]
        [Display(Name = "PasswordHash")]
        public byte[] PasswordHash { get; set; }
        [Required]
        [Display(Name = "PasswordSalt")]
        public byte[] PasswordSalt { get; set; }
        [Display(Name = "JwtToken")]
        public string JwtToken { get; set; } = string.Empty;

        [Display(Name = "RefreshToken")]
        public string RefreshToken { get; set; } = string.Empty;

        [Display(Name = "TokenCreated")]
        public DateTime TokenCreated { get; set; }

        [Display(Name = "TokenExpires")]
        public DateTime TokenExpires { get; set; }
    }
}
